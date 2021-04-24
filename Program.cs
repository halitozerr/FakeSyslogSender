using System;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            UdpClient udpClient = new UdpClient();
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //Port and connection
            udpClient.Connect("localhost", 517);
            int a = 1;
            while (a < 100000)
            {
                try
                {
                    message = "Is anybody there?";
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                    udpClient.Send(sendBytes, sendBytes.Length);
                    Console.WriteLine(a + ". " + "Message sent");
                    a++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
