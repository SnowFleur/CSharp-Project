/*
 * 비동기 Connect을 진행할 클래스
 *
 * 
 */

using System;
using System.Net;
using System.Net.Sockets;

namespace SnowNetEngine
{
    public class CSnowConnector
    {
        private Socket     socket_;
        private IPEndPoint serverAddr_;
        public CSnowConnector()
        {
        }

        public void OnConnect(string host, int port)
        {
            socket_ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //연결을 시도할 서버 주소
            serverAddr_ = new IPEndPoint(IPAddress.Parse(host), port);

            //접속을 완료했을 경우 호출될 함수   
            SocketAsyncEventArgs socketEvent = new SocketAsyncEventArgs();
            socketEvent.Completed += PostConnect;
            socketEvent.RemoteEndPoint = serverAddr_;

            //비동기입출력에함수 이벤트 등록
            bool ioPending =  socket_.ConnectAsync(socketEvent);
            if (ioPending == false)
            {
                PostConnect(null, socketEvent);
            }
        }

        public void PostConnect(object sender, SocketAsyncEventArgs e)
        {
            //성공
            if (e.SocketError == SocketError.Success)
            {
                Console.WriteLine("Connect Sucess");
                //성공했으니까 해당정보를 기반으로 Session 생성
            }
            //실패
            else
            {
                Console.WriteLine("Connect fail" + e.SocketError);
            }
        }
    }
}