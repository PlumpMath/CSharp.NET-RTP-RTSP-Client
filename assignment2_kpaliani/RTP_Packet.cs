using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_kpaliani {
    class RTP_Packet {

        private string _packetReport;

        private byte[] _packetHeader;
        private byte[] _packetContents;

        //RTP packet contrctor
        public RTP_Packet(byte[] receiveBytes, int numBytes) {
            //Parse packet
            parsePacket(receiveBytes, numBytes);
        }

        //Parse packet
        public void parsePacket(byte[] receiveBytes, int numBytes) {

            byte[] rtpPacket = new byte[numBytes];
            Buffer.BlockCopy(receiveBytes, 0, rtpPacket, 0, numBytes);

            //Header info bytes
            _packetHeader = new byte[12];
            byte[] typeBytes = new byte[1];
            byte[] sequenceNumBytes = new byte[2];
            byte[] timeStampBytes = new byte[4];

            //Packet contents
            _packetContents = new byte[numBytes - 12];

            //Get packet header info and contents from rtppacket with blockcopy
            Buffer.BlockCopy(rtpPacket, 0, _packetHeader, 0, 12);
            Buffer.BlockCopy(rtpPacket, 1, typeBytes, 0, 1);
            Buffer.BlockCopy(rtpPacket, 2, sequenceNumBytes, 0, 2);
            Buffer.BlockCopy(rtpPacket, 4, timeStampBytes, 0, 4);
            Buffer.BlockCopy(rtpPacket, 12, _packetContents, 0, numBytes - 12);

            //Convert header bytes to ints
            int type = typeBytes[0];
            int sequenceNum = BitConverter.ToInt16(sequenceNumBytes, 0);
            int timeStamp = BitConverter.ToInt32(timeStampBytes, 0);

            //Create packet report
            _packetReport = "Got RTP packet with SeqNum # " + sequenceNum + " TimeStamp " + timeStamp + " ms, of type " + type;

        }

        //Returns packet report
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
