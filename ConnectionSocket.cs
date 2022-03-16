using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace InoClientSocketTCP_3_1
{
    public class ConnectionSocket
    {
        private Socket _socket;
        private List<TagReceived> tagReceiveds = new List<TagReceived>();

        public ConnectionSocket()
        {
            //192.168.0.105 LOCAL
            //192.168.4.1 MACHINE
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("172.17.144.1"), 14150);

            if (_socket == null)
            {
                _socket = new Socket(remoteEP.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                _socket.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}", _socket.RemoteEndPoint.ToString());
            }
        }

        public void SendMessage()
        {
            byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");
            int bytesSent = _socket.Send(msg);
        }

        public async Task MonitorIncomingMessage()
        {
            while (true)
            {
                try
                {

                    byte[] bytes = new byte[1024];

                    int bytesRec = _socket.Receive(bytes);
                    string obj = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    //Console.WriteLine("objeto:{obj}");

                    if (obj.Contains("epc"))
                    {
                        TagReceived response = JsonConvert.DeserializeObject<TagReceived>(obj);
                        Console.WriteLine($"{DateTime.Now} - Tag Recebida: {response.epc}");

                        //if (!tagReceiveds.Any(t => t.epc.Equals(response.epc)))
                        //{
                        //tagReceiveds.Add(response);
                        //}
                        //else
                        //{
                        //Console.WriteLine("Tag já lida.");
                        //}
                        obj = null;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        public void StopMonitoring()
        {
            _socket.Shutdown(SocketShutdown.Both);
        }
    }
}
