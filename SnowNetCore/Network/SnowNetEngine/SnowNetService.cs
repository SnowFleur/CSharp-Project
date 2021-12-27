/*
 * Network기능을 제공하는 Service 클래스
 * 
 */

using System;

namespace SnowNetEngine
{
    public class CSnowNetService
    {
        private CSnowConnector connector_; //서버와 연결을 해줄 커넥트 클래스

        
        public CSnowNetService()
        {
            connector_ = new CSnowConnector();
        }

        public void ConnectToServer(string ip, int port)
        {
            connector_.OnConnect(ip, port);
        }
    }
}