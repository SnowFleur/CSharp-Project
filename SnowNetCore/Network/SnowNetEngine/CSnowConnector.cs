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
        private Socket socket_;
        private IPEndPoint serverAddr_;
        private CSnowNetwork network_;

        //델리게이트 설정
        public delegate void ConnectHandler(CSnowSession session);

        public ConnectHandler CallBackPostConnect { get; set; }

        public CSnowConnector(CSnowNetwork network)
        {
            //C#의 클래스는 참조다
            network_ = network;
            CallBackPostConnect = null;
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
            bool ioPending = socket_.ConnectAsync(socketEvent);
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

                if (CallBackPostConnect != null)
                {
                    //접속이 완료됐으니 세션을 넘겨준다.
                    CSnowSession session = new CSnowSession();
                    CallBackPostConnect(session);
                }
            }
            //실패
            else
            {
                Console.WriteLine("Connect fail" + e.SocketError);
            }
        }
    }
}