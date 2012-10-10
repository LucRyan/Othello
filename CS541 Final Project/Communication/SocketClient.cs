using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace CS541_Final_Project
{
    class SocketClient
    {
        public static Socket StartClient(string ServerIpAdd, int port)
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                IPAddress ipA2 = IPAddress.Parse(ServerIpAdd);
                IPEndPoint remoteEP = new IPEndPoint(ipA2, port);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}",sender.RemoteEndPoint.ToString());

                return sender;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }

        public static int Get(Socket sender)
        {
            // return -2 if exception.
            byte[] bytes = new byte[1024];
            try
            {


                // Encode the data string into a byte array.
                //byte[] msg = Encoding.Default.GetBytes("12");

                int bytesRec = sender.Receive(bytes);

                // Receive the response from the remote device.
                //int bytesRec = sender.Receive(bytes);
                //MessageBox.Show("Received: "+ bytes[0].ToString());

                return bytes[0];
                // Release the socket.

            }
            catch (ArgumentNullException ane)
            {
                MessageBox.Show("ArgumentNullException : {0}", ane.ToString());
                return -2;
            }
            catch (SocketException se)
            {
                MessageBox.Show("SocketException : {0}", se.ToString());
                return -2;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unexpected exception : {0}", e.ToString());
                return -2;
            }
        }
        public static int Send(Socket sender, int num)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];
            try
            {
                // Encode the data string into a byte array.
                //byte[] msg = Encoding.Default.GetBytes("12");

                //int bytesRec = sender.Receive(bytes);
                byte[] msg = new byte[1];
                msg[0] = byte.Parse(num.ToString());

                // Send the data through the socket.
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.
                int bytesRec = sender.Receive(bytes);
                //MessageBox.Show("Received:"+ bytes[0].ToString());

                return bytes[0];
                // Release the socket.

            }
            catch (ArgumentNullException ane)
            {
                MessageBox.Show("ArgumentNullException : {0}", ane.ToString());
                return -2;
            }
            catch (SocketException se)
            {
                MessageBox.Show("SocketException : {0}", se.ToString());
                return -2;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unexpected exception : {0}", e.ToString());
                return -2;
            }
        }
        public void ReleaseSocket(Socket sender)
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}