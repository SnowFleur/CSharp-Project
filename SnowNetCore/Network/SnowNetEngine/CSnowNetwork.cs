/*
 * Network기능을 제공하는 Service 클래스
 * 
 */

using System;
using System.Net.Sockets;

namespace SnowNetEngine
{
    public class CSnowNetwork
    {
        private const int EVENT_ARGS_POOL_SIZE = 500;

        private CRecvEventArgsPool receiveEventArgsPool_; //리시브용 Event
        private CSendEventArgsPool sendEventArgsPool_; //샌드용 Event

        public CSnowNetwork()
        {
            receiveEventArgsPool_ = new CRecvEventArgsPool(EVENT_ARGS_POOL_SIZE);
            sendEventArgsPool_ = new CSendEventArgsPool(EVENT_ARGS_POOL_SIZE);


            CSnowSession session = new CSnowSession();

            //Receive
            SocketAsyncEventArgs args;
            args = new SocketAsyncEventArgs();
            args.Completed += new EventHandler<SocketAsyncEventArgs>(PostRecv);
            args.UserToken = session;

            receiveEventArgsPool_.Push(args);
            //Send
            args = new SocketAsyncEventArgs();
            args.Completed += new EventHandler<SocketAsyncEventArgs>(PostSend);
            args.UserToken = session;
            sendEventArgsPool_.Push(args);

        }

        public void PostSend(object sender, SocketAsyncEventArgs e)
        {
            //전송이 끝난 세션
            CSnowSession snowSession = e.UserToken as CSnowSession;
        }

        public void PostRecv(object sender, SocketAsyncEventArgs e)
        {
            //리시브가 끝난 세션
            CSnowSession snowSession = e.UserToken as CSnowSession;
        }
        
    }
}