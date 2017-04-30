using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment2_kpaliani {
    public partial class Form1 : Form {

        private Controller _controller;

        private bool _printHeader = false;
        private bool _printPacketReport = false;

        public Form1() {

            InitializeComponent();

            //Get reference to controller
            _controller = new Controller(this);

            //Initally disable buttons
            setupButton.Enabled = false;
            playButton.Enabled = false;
            pauseButton.Enabled = false;
            teardownButton.Enabled = false;

            //Send events to controller to handle
            this.connectButton.Click += new System.EventHandler(_controller.connectButton_Click);
            this.exitButton.Click += new System.EventHandler(_controller.exitButton_Click);
            this.setupButton.Click += new System.EventHandler(_controller.setupButton_Click);
            this.playButton.Click += new System.EventHandler(_controller.playButton_Click);
            this.pauseButton.Click += new System.EventHandler(_controller.pauseButton_Click);
            this.teardownButton.Click += new System.EventHandler(_controller.teardownButton_Click);
        }

        //Return port number
        public int getPort() {
            return Int32.Parse(portText.Text);
        }

        //Return IP address
        public IPAddress getIP() {
            return IPAddress.Parse(serverIPText.Text);
        }

        //Get video name
        public string getVideoName() {
            return videoNameText.Text;
        }

        //Enable connect button
        public void enableConnectButton() {
            connectButton.Enabled = true;
        }

        //Disable connect button
        public void disableConnectButton() {
            connectButton.Enabled = false;
        }

        //Enable setup button
        public void enableSetupButton() {
            setupButton.Enabled = true;
        }

        //Disable setup button
        public void disableSetupButton() {
            setupButton.Enabled = false;
        }

        //Enable play button
        public void enablePlayButton() {
            playButton.Enabled = true;
        }

        //Disable play button
        public void disablePlayButton() {
            playButton.Enabled = false;
        }

        //Enable pause button
        public void enablePauseButton() {
            pauseButton.Enabled = true;
        }

        //Disable pause button
        public void disablePauseButton() {
            pauseButton.Enabled = false;
        }

        //Enable teardown button
        public void enableTeardownButton() {
            teardownButton.Enabled = true;
        }

        //Disable teardown button
        public void disableTeardownButton() {
            teardownButton.Enabled = false;
        }

        //Update client status text area
        public void updateClientStatusText(string status) {
            Console.WriteLine(status);
            clientStatusText?.Invoke(new MethodInvoker(delegate { clientStatusText.AppendText(status + "\r\n"); }));
        }

        //Update server response text area area
        public void updateServerResponseText(string status) {
            serverResponseText?.Invoke(new MethodInvoker(delegate { serverResponseText.AppendText(status + "\r\n"); }));
        }

        //Update picture box
        public void updatePictureBox(Image image) {
            pictureBox.Image = image;
        }

        //Packet report checkbox clicked
        private void packetReportCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (packetReportCheckbox.Checked) {
                _printPacketReport = true;
            } else {
                _printPacketReport = false;
            }
        }

        //Print header checkbox clicked
        private void printHeaderCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (printHeaderCheckbox.Checked) {
                _printHeader = true;
            } else {
                _printHeader = false;
            }
        }

        //Returns if print packet report checkbox is clicked
        public bool printPacketReport() {
            return _printPacketReport;
        }

        //Returns if print header checkbox is clicked
        public bool printHeader() {
            return _printHeader;
        }
    }
}
