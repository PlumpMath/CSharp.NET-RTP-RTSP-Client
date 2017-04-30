using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_kpaliani {

    class RTSPModel {

        private IPAddress _ipAddress;
        private int _port;
        private string _videoName;

        private Socket _rtspSocket;

        private int _sequenceNum;
        private int _sessionNum;

        private bool _torndown = true;

        //Constructor
        public RTSPModel(IPAddress ipAddress, int port, string videoName) {

            _ipAddress = ipAddress;
            _port = port;
            _videoName = videoName;

            //Create new RTSP soscket
            _rtspSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverIPEndPoint = new IPEndPoint(ipAddress, port);

            //Connect to RTSP socket
            _rtspSocket.Connect(serverIPEndPoint);

        }

        //Close RTSP socket
        public void close() {
            _rtspSocket.Close();
        }

        //SETUP RTSP
        public string setup() {

            //Initialize sequence num
            _sequenceNum = 1;

            //Create message
            string message = "SETUP rtsp://" + _ipAddress.ToString() + ":" + _port.ToString() + "/" + _videoName + " RTSP/1.0" + "\r\n"
                + "CSeq: " + _sequenceNum.ToString() + "\r\n" + "Transport: RTP/UDP; client_port= 25000";

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] receiveBytes = new byte[4096];

            try {

                //Send and recieve RTSP
                _rtspSocket.Send(messageBytes);
                _rtspSocket.Receive(receiveBytes);

                //Get string response
                string response = Encoding.UTF8.GetString(receiveBytes).TrimEnd(new char[] { (char)0 });

                //Parsing the RTSP packet
                string[] responseLines = response.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                string[] sessionLine = responseLines[2].Split(' ');
                _sessionNum = Int32.Parse(sessionLine[1]);

                //Increase sequence number
                _sequenceNum++;

                return response;

            } catch (Exception err) {
                Console.WriteLine(err.Message);
                return null;
            }

        }

        //PLAY RTSP
        public string play() {

            //Play message
            string message = "PLAY rtsp://" + _ipAddress.ToString() + ":" + _port.ToString() + "/" + _videoName + " RTSP/1.0" + "\r\n"
                + "CSeq: " + _sequenceNum.ToString() + "\r\n" + "Session: " + _sessionNum.ToString();

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] receiveBytes = new byte[4096];

            try {

                //Send and recieve RTSP
                _rtspSocket.Send(messageBytes);
                _rtspSocket.Receive(receiveBytes);

                //Get string response
                string response = Encoding.UTF8.GetString(receiveBytes).TrimEnd(new char[] { (char)0 });

                //Increase sequence num
                _sequenceNum++;

                return response;

            } catch (SocketException err) {
                Console.WriteLine(err.Message);
                return null;
            }

        }

        //PAUSE RTSP
        public string pause() {

            //Pause message
            string message = "PAUSE rtsp://" + _ipAddress.ToString() + ":" + _port.ToString() + "/" + _videoName + " RTSP/1.0" + "\r\n"
                + "CSeq: " + _sequenceNum.ToString() + "\r\n" + "Session: " + _sessionNum.ToString();

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] receiveBytes = new byte[4096];

            try {

                //Send and recieve RTSP
                _rtspSocket.Send(messageBytes);
                _rtspSocket.Receive(receiveBytes);

                //Get string response
                string response = Encoding.UTF8.GetString(receiveBytes).TrimEnd(new char[] { (char)0 });

                //Increase sequence num
                _sequenceNum++;

                return response;

            } catch (SocketException err) {
                Console.WriteLine(err.Message);
                return null;
            }

        }

        //TEARDOWN RTSP
        public string teardown() {

            if (!_torndown) {

                _torndown = true;

                //Teardown message
                string message = "TEARDOWN rtsp://" + _ipAddress.ToString() + ":" + _port.ToString() + "/" + _videoName + " RTSP/1.0" + "\r\n"
                    + "CSeq: " + _sequenceNum.ToString() + "\r\n" + "Session: " + _sessionNum.ToString();

                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                byte[] receiveBytes = new byte[4096];

                try {

                    //Send and recieve RTSP
                    _rtspSocket.Send(messageBytes);
                    _rtspSocket.Receive(receiveBytes);

                    //Get string response
                    string response = Encoding.UTF8.GetString(receiveBytes).TrimEnd(new char[] { (char)0 });

                    //Increase sequence num
                    _sequenceNum = 1;

                    return response;

                } catch (SocketException err) {
                    Console.WriteLine(err.Message);
                    return null;
                }
            } else {
                return null;
            }

        }

    }
}
