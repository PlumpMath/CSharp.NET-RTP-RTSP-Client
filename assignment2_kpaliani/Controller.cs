using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace assignment2_kpaliani {
    class Controller {

        private Form1 _view;
        private RTSPModel _rtspModel;
        private RTPModel _rtpModel;

        private bool paused = false;
        private Thread rtpThread = null;

        private System.Timers.Timer _timer;

        public Controller(Form1 view) {

            //Get reference to view
            _view = view;

            //Setup timer
            _timer = new System.Timers.Timer(100/3);
            _timer.Elapsed += getRTPPacket;
            _timer.AutoReset = true;

        }

        //Event raised whenever the timer runs out
        private void getRTPPacket(Object source, ElapsedEventArgs e) {

            //Gets the most recent packet
            RTPPacketStuff rtpPacketStuff = _rtpModel.getRTPPacket();

            //Checks to make sure a packet was returned
            if (rtpPacketStuff != null) {

                //Get packet information
                string packetReport = rtpPacketStuff.getPacketReport();
                byte[] packetHeader = rtpPacketStuff.getPacketHeader();
                byte[] packetContents = rtpPacketStuff.getPacketContents();

                //Print packet report
                if (_view.printPacketReport()) {
                    _view.updateClientStatusText(packetReport);
                }

                //Print header
                if (_view.printHeader()) {

                    string byteString = "";
                    foreach (byte b in packetHeader) {
                        byteString += Convert.ToString(b, 2).PadLeft(8, '0');
                        byteString += " ";
                    }

                    _view.updateClientStatusText(byteString);
                }

                //Get image and resize
                int maxwidth = 450;
                int maxheight = 230;
                ImageConverter imageConverter = new ImageConverter();
                Image image = (Image)(imageConverter.ConvertFrom(packetContents));
                if (image.Width > maxwidth | image.Height > maxheight)
                {
                    Bitmap bitmap = new Bitmap(maxwidth, maxheight);
                    using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                        graphics.DrawImage(image, 0, 0, maxwidth, maxheight);
                    image = bitmap;
                }

                //Print packet contents to screen in view
                _view.updatePictureBox(image);

            }
        }

        //Connect button clicked
        public void connectButton_Click(object sender, EventArgs e) {

            IPAddress ipAddress = _view.getIP();
            int port = _view.getPort();
            string videoName = _view.getVideoName();

            try {

                //Create new rtsp model
                _rtspModel = new RTSPModel(ipAddress, port, videoName);

                //Enable/disable buttons
                _view.disableConnectButton();
                _view.enableSetupButton();

            } catch (Exception ex) {
                Console.WriteLine("Exception caught: " + ex);
            }

        }

        //Exit button clicked
        public void exitButton_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        //Setup button clicked
        public void setupButton_Click(object sender, EventArgs e) {

            IPAddress ipAddress = _view.getIP();
            int port = _view.getPort();

            //Create new rtp model
            _rtpModel = new RTPModel(ipAddress, port);           

            //RTSP setup
            string response = _rtspModel.setup();

            //Update view with response
            _view.updateClientStatusText("New RTSP state: READY");
            _view.updateServerResponseText(response);

            rtpThread = new Thread(new ThreadStart(() => _rtpModel.listen(
                (a, b) => _view?.Invoke(new MethodInvoker(delegate { teardownButton_Click(null, new EventArgs()); }))
            , ref paused)));

            //Enable/disable buttons
            _view.disableSetupButton();
            _view.enablePlayButton();
            _view.enableTeardownButton();

        }

        //Play button clicked
        public void playButton_Click(object sender, EventArgs e) {

            //RTSP play
            string response = _rtspModel.play();

            //Start the rtpmodel to start listening
            if ((rtpThread.ThreadState & ThreadState.Unstarted) == ThreadState.Unstarted) {
                rtpThread.Start();
            }

            //Update view with response
            _view.updateClientStatusText("New RTSP state: PLAYING");
            _view.updateServerResponseText(response);

            //Enable/disable buttons
            _view.disablePlayButton();
            _view.enablePauseButton();

            //Enable timer
            _timer.Enabled = true;
            paused = false;
        }

        //Play button clicked
        public void pauseButton_Click(object sender, EventArgs e) {

            //RTSP pause
            string response = _rtspModel.pause();

            //Update view with response
            _view.updateClientStatusText("New RTSP state: PAUSED");
            _view.updateServerResponseText(response);

            //Enable/disable buttons
            _view.disablePauseButton();
            _view.enablePlayButton();

            //Disable timer
            _timer.Enabled = false;
            paused = true;
        }

        //Teardown button clicked
        public void teardownButton_Click(object sender, EventArgs e) {

            //RTSP teardown
            string response = _rtspModel.teardown();

            //Update view with response
            if (sender != null) {
                _view.updateClientStatusText("New RTSP state: TEARING DOWN");
                _view.updateServerResponseText(response);
            }

            //Enable/disable buttons
            _view.disableSetupButton();
            _view.disablePlayButton();
            _view.disablePauseButton();   
            _view.disableTeardownButton();
            _view.enableConnectButton();

            //Disable timer
            _timer.Enabled = false;
            paused = false;

            //Close RTP connection
            _rtpModel.closeRTPSocket();

            //Close RTSP socket
            _rtspModel.close();

            // Destroy thread
            try {
                rtpThread.Abort();
            } catch (Exception) { }
        }

    }
}
