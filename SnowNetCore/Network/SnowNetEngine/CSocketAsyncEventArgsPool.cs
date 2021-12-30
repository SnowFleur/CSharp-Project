/*
 * 닷넷이 비동기 프로그래밍을 진행할 때 필요한 SocketAsyncEventArgs의 풀을 만든다.
 */

using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace SnowNetEngine
{
    //추상클래스 느낌으로
    public class CSocketAsyncEventArgsPool
    {
        protected Stack<SocketAsyncEventArgs> eventArgPool_;
        protected readonly Int32 poolSize_;

        //생성할 때 풀의 사이즈를 정한다.
        //생성자 자체를 상속받은 클래스가 아님면 실행못하게 해서 막자
        protected CSocketAsyncEventArgsPool(Int32 poolSize)
        {
            poolSize_ = poolSize;
            eventArgPool_ = new Stack<SocketAsyncEventArgs>(poolSize);
        }
    }

    //Send용 EventPool ---> Lock여부에 따라 다르기 때문에 2개를 만든다.
    public class CSendEventArgsPool : CSocketAsyncEventArgsPool
    {
        public CSendEventArgsPool(int poolSize) : base(poolSize)
        {
        }

        public void Push(SocketAsyncEventArgs item)
        {
            if (item == null)
            {
                Console.WriteLine("Item Is null");
                return;
            }

            //샌드는 경쟁상태가 발생할 여지가 있음
            lock (eventArgPool_)
            {
                eventArgPool_.Push(item);
            }
        }

        public SocketAsyncEventArgs Pop()
        {
            //샌드는 경쟁상태가 발생할 여지가 있음
            lock (eventArgPool_)
            {
                return eventArgPool_.Pop();
            }
        }
    }

    public class CRecvEventArgsPool : CSocketAsyncEventArgsPool
    {
        public CRecvEventArgsPool(int poolSize) : base(poolSize)
        {
        }

        public void Push(SocketAsyncEventArgs item)
        {
            if (item == null)
            {
                Console.WriteLine("Item Is null");
                return;
            }

            //Recv는 경쟁이 발생하지 않는다.
            eventArgPool_.Push(item);
        }

        public SocketAsyncEventArgs Pop()
        {
            //Recv는 경쟁이 발생하지 않는다.
            return eventArgPool_.Pop();
        }
    }
}