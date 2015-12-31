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

            string adres;
            int port;
            Console.WriteLine("PROGRAM KTORY DLA PODANEGO SERWISU WWW\nSPRAWDZA OTWARTOSC WYZNACZONEGO PORTU\n");
            Console.WriteLine("Wpisz nazwe serwisu: ");
            adres = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("Wpisz numer portu: ");
            port = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            IPHostEntry adresWWW = Dns.GetHostEntry(adres);
            IPAddress adresIP = adresWWW.AddressList[0];
            System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
            try
            {
                socket.Connect(adresIP, port);
                if (socket.Connected == true)
                    Console.WriteLine("Port " + port + " jest otwarty");
            }
            catch (Exception)
            {
                Console.WriteLine("Port " + port + " jest zamkniety");
            }
            finally
            {
                socket.Close();
                Console.WriteLine("\nPo nacisnieciu dowolnego klawisza program zostanie zamkniety");
            }
            Console.ReadKey();

        }
    }
}
