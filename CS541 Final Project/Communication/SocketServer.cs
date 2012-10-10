using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace CS541_Final_Project
{
    class SocketServer
    {
        public static string data = null;

        public static Socket StartListening(int firstNum, int port)
        {
            // Data buffer for incoming data.
            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            Socket handler;
            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (true)
                {
                    MessageBox.Show("Click to wait connection"+ipAddress.ToString()+":"+port.ToString());
                    // Program is suspended while waiting for an incoming connection.
                    handler = listener.Accept();
                    //MessageBox.Show("Connected");
                    data = null;


                    // Echo the data back to the client.
                    byte[] msg = new byte[1];
                    msg[0] = byte.Parse(firstNum.ToString());

                    handler.Send(msg);

                    break;

                    // Show the data on the console.
                    //Console.WriteLine("Text received : {0}", numberIn.ToString());


                }
                return handler;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }

        public static int Get(Socket handler)
        {
            int numberIn = 0;
            byte[] bytes = new Byte[1024];
            bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);
            numberIn = bytes[0];
            return numberIn;
        }


        public static int Send(Socket handler, int num)
        {
            byte[] bytes = new Byte[1024];
            byte[] msg = new byte[1];
            int numberIn = 0;

            msg[0] = byte.Parse(num.ToString());
            handler.Send(msg);

            //Start receiving numbers.
            bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);
            numberIn = bytes[0];

            return numberIn;
        }

        public static void ShutDownSocket(Socket handler)
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}