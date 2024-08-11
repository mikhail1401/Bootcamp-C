using System.Net.Sockets;
using System.Text;

namespace Client
{
    class OurClient
    {
        private TcpClient client;
        private StreamWriter sWriter;
        private StreamReader sReader;

        // Constructor - is a method that called upon object initiallization
        // In C# it mush have the same name as the class
        public OurClient()
        {
            client = new TcpClient("127.0.0.1", 5555);
            sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            sReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            
            HandleCommunication();
        }

        void HandleCommunication()
        {
            while (true)    // infinite loop
            {
                Console.Write("> ");
                string message = Console.ReadLine();
                sWriter.WriteLine(message); // the message is prepared for sending
                sWriter.Flush();    // send the message immidiately

                string answerServer = sReader.ReadLine();
                Console.WriteLine($"Server replied -> {answerServer}");
            }
        }
    }
}