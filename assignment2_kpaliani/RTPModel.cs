using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_kpaliani {
    class RTPModel {

        private IPEndPoint _serverIPEndPoint;
        private EndPoint _serverEndPoint;
        private Socket _rtpSocket;

        private Queue<RTPPacketStuff> _rtpPacketQueue;

        public RTPModel(IPAddress ipAddress, int port) {

            _serverIPEndPoint = new IPEndPoint(ipAddress, port);
            _serverEndPoint = (EndPoint)_serverIPEndPoint;
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 25000);

            //Create socket for client connection
            _rtpSocket = new Socket(_serverIPEndPoint.Address.AddressFamily,
                 SocketType.Dgram,
                 ProtocolType.Udp);

            //Bind rtp socket
            _rtpSocket.Bind(clientEndPoint);

            //Set timeout for rtp socket
            _rtpSocket.ReceiveTimeout = 2000;

            //Queue for RTP packets
            _rtpPacketQueue = new Queue<RTPPacketStuff>();

        }

        //Close RTP socket
        public void closeRTPSocket() {
            _rtpSocket.Close();
        }

        //Listen loop to listen for new RTP packets
        public void listen(EventHandler callback, ref bool paused) {

            //Loop to listen for rtp packets
            while (true) {

                byte[] receiveBytes = new byte[100000];

                try {
                    if (!paused) {
                        //Receive rtp packets
                        int numBytes = _rtpSocket.Receive(receiveBytes);
                        Console.WriteLine(numBytes);

                        //Parse packet
                        RTP_Packet rtpPacket = new RTP_Packet(receiveBytes, numBytes);
                        string packetReport = rtpPacket.getPacketReport();
                        byte[] packetHeader = rtpPacket.getPacketHeader();
                        byte[] packetContents = rtpPacket.getPacketContents();

                        //Add packet stuff to queue
                        RTPPacketStuff rtpPacketStuff = new RTPPacketStuff(packetReport, packetHeader, packetContents);
                        _rtpPacketQueue.Enqueue(rtpPacketStuff);
                    }
                    else {
                        // Paused, give up time slice
                        System.Threading.Thread.Sleep(30);
                    }

                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(paused);
                    if (!paused)
                        {
                        Console.WriteLine("Paused");
                        callback(null, new EventArgs());
                        break;
                    }
                }
            }

        }

        //Return oldest packet
        public RTPPacketStuff getRTPPacket() {
            try {
                return _rtpPacketQueue.Dequeue();
            } catch (Exception e) {
                return null;
            }
        }

    }

    //Helper class to store rtp packet information
    class RTPPacketStuff {

        private string _packetReport;
        private byte[] _packetHeader;
        private byte[] _packetContents;


        //Constructor
        public RTPPacketStuff(string packetReport, byte[] packetHeader, byte[] packetContents) {
            _packetReport = packetReport;
            _packetHeader = packetHeader;
            _packetContents = packetContents;
        }

        //Return packet report
        public string getPacketReport() {
            return _packetReport;
        }

        //Return packet header
        public byte[] getPacketHeader() {
            return _packetHeader;
        }

        //Return packet contents
        public byte[] getPacketContents() {
            return _packetContents;
        }

    }
}
