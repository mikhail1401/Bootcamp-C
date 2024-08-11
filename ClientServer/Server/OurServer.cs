using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    class OurServer
    {
        TcpListener server;

        public OurServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            server.Start();

            LoopClients();
        }

        // infinite loop to accept new clients
        void LoopClients()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                Thread thread = new Thread(() => HandleClient(client));
                thread.Start();
            }
        }

        // infinite loop to keep connection with a client
        void HandleClient(TcpClient client)
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);

            while (true)
            {
                string clientMessage = sReader.ReadLine();
                Console.WriteLine($"Client wrote - {clientMessage}");

                string answer = Console.ReadLine();
                sWriter.WriteLine(answer);
                sWriter.Flush();
            }
        }
    }
}
