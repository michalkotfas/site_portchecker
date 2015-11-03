using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace site_portchecker
{
    class Program
    {
        static void Main(string[] args)
        {

            IPHostEntry adresWWW = Dns.GetHostEntry("www.github.com");
            IPAddress adresIP = adresWWW.AddressList[0];
            System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
            try
            {
                socket.Connect(adresIP, 80);
                if (socket.Connected == true)
                    Console.WriteLine("Port jest otwarty");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Port jest zamkniety");
            }
            finally
            {
                socket.Close();
            }
            Console.ReadKey();

        }
    }
}
