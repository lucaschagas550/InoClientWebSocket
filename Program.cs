using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace InoClientSocketTCP_3_1
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            await StartClient();
            Console.Read();

            return 0;
        }

        public static async Task StartClient()
        {
            try
            {

                ConnectionSocket socket = new ConnectionSocket();
                try
                {
                    //socket.SendMessage();
                    await socket.MonitorIncomingMessage();

                    //while (true)
                    //{
                    //    Debug.WriteLine("oi");
                    //};

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());

                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());

                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
