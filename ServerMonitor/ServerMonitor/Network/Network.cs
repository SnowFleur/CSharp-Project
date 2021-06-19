using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace ServerMonitor
{
    class CNetwork: SocketAsyncEventArgs
    {
        const int MAX_BUFFER_SIZE = 1024;

        Socket      socket_;
        byte[]      buffer_;

        public CNetwork(IPAddress ip,Int32 port) {

            IPEndPoint ipe = new IPEndPoint(ip, port);

            socket_ = new Socket(ipe.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            buffer_ = new byte[MAX_BUFFER_SIZE];

            //메모리 버퍼 초기화
            base.SetBuffer(buffer_, 0, MAX_BUFFER_SIZE);
            
            base.UserToken = socket_;

            base.Completed += CallBack_ReceiveData;

            this.socket_.ReceiveAsync(this);
        }


        private void CallBack_ReceiveData(object sender, EventArgs e)
        {

            //연결되어 있으며 byte가 1이상 왔으면
            if (socket_.Connected == true && base.BytesTransferred > 0) { 

            
            }


        }


    }
}
