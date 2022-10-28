// FTClient.cs
//
// Pete Myers
// CST 415
// Fall 2019
// 

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace FTClient
{
    class FTClient
    {
        private string ftServerAddress;
        private ushort ftServerPort;
        bool connected;
        Socket clientSocket;
        NetworkStream stream;
        StreamReader reader;
        StreamWriter writer;

        public FTClient(string ftServerAddress, ushort ftServerPort)
        {
            // save server address/port
            this.ftServerAddress = ftServerAddress;
            this.ftServerPort = ftServerPort;

            // initialize to not connected to server
            connected = false;
            clientSocket = null;
            stream = null;
            reader = null;
            writer = null;
        }

        public void Connect()
        {
            if (!connected)
            {
                // create a client socket and connect to the FT Server's IP address and port
                clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ftServerAddress), ftServerPort));

                // establish the network stream, reader and writer
                stream = new NetworkStream(clientSocket);
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                // now connected
                connected = true;
            }
        }

        public void Disconnect()
        {
            // TODO: FTClient.Disconnect()

            if (connected)
            {
                // send exit to FT server
                SendExit();
                
                // close writer, reader and stream
                writer.Close();
                reader.Close();
                stream.Close();

                // disconnect and close socket
                clientSocket.Disconnect(false);
                clientSocket.Close();

                // now disconnected
                connected = false;
            }
        }

        public void GetDirectory(string directoryName)
        {
            // TODO: FTClient.GetDirectory()

            // send get to the server for the specified directory and receive files
            if (connected)
            {
                // send get command for the directory
                
                // receive and process files
                
            }
        }

        #region implementation

        private void SendGet(string directoryName)
        {
            // TODO: FTClient.SendGet()
            // send get message for the directory

        }

        private void SendExit()
        {
            // send exit message
            writer.WriteLine("exit");
            writer.Flush();
        }

        private void SendInvalidMessage()
        {
            // TODO: FTClient.SendInvalidMessage()
            // allows for testing of server's error handling code

        }

        private bool ReceiveFile(string directoryName)
        {
            // TODO: FTClient.ReceiveFile()
            // receive a single file from the server and save it locally in the specified directory

            // expect file name from server

            // when the server sends "done", then there are no more files!

            // handle error messages from the server

            // received a file name

            // receive file length from server

            // receive file contents

            // loop until all of the file contenst are received
            //while (charsToRead > 0)
            {
                // receive as many characters from the server as available

                // accumulate bytes read into the contents

            }

            // create the local directory if needed
            
            // save the file locally on the disk
            
            return true;
        }

        #endregion
    }
}
