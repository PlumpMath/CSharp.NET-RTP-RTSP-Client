namespace assignment2_kpaliani {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.serverIPText = new System.Windows.Forms.TextBox();
            this.videoNameText = new System.Windows.Forms.TextBox();
            this.portText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setupButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.teardownButton = new System.Windows.Forms.Button();
            this.clientStatusText = new System.Windows.Forms.TextBox();
            this.serverResponseText = new System.Windows.Forms.TextBox();
            this.packetReportCheckbox = new System.Windows.Forms.CheckBox();
            this.printHeaderCheckbox = new System.Windows.Forms.CheckBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // serverIPText
            // 
            this.serverIPText.Location = new System.Drawing.Point(527, 40);
            this.serverIPText.Name = "serverIPText";
            this.serverIPText.Size = new System.Drawing.Size(162, 31);
            this.serverIPText.TabIndex = 0;
            this.serverIPText.Text = "127.0.0.1";
            // 
            // videoNameText
            // 
            this.videoNameText.Location = new System.Drawing.Point(883, 40);
            this.videoNameText.Name = "videoNameText";
            this.videoNameText.Size = new System.Drawing.Size(152, 31);
            this.videoNameText.TabIndex = 1;
            this.videoNameText.Text = "video1.mjpeg";
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(195, 40);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(100, 31);
            this.portText.TabIndex = 2;
            this.portText.Text = "3000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connect to Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Server IP Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(727, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Video Name:";
            // 
            // setupButton
            // 
            this.setupButton.Location = new System.Drawing.Point(79, 599);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(130, 130);
            this.setupButton.TabIndex = 6;
            this.setupButton.Text = "Setup";
            this.setupButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(291, 599);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(130, 130);
            this.playButton.TabIndex = 7;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(508, 599);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(130, 130);
            this.pauseButton.TabIndex = 8;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // teardownButton
            // 
            this.teardownButton.Location = new System.Drawing.Point(732, 599);
            this.teardownButton.Name = "teardownButton";
            this.teardownButton.Size = new System.Drawing.Size(130, 130);
            this.teardownButton.TabIndex = 9;
            this.teardownButton.Text = "Teardown";
            this.teardownButton.UseVisualStyleBackColor = true;
            // 
            // clientStatusText
            // 
            this.clientStatusText.Location = new System.Drawing.Point(79, 786);
            this.clientStatusText.Multiline = true;
            this.clientStatusText.Name = "clientStatusText";
            this.clientStatusText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientStatusText.Size = new System.Drawing.Size(652, 286);
            this.clientStatusText.TabIndex = 10;
            // 
            // serverResponseText
            // 
            this.serverResponseText.Location = new System.Drawing.Point(79, 1129);
            this.serverResponseText.Multiline = true;
            this.serverResponseText.Name = "serverResponseText";
            this.serverResponseText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverResponseText.Size = new System.Drawing.Size(652, 272);
            this.serverResponseText.TabIndex = 11;
            // 
            // packetReportCheckbox
            // 
            this.packetReportCheckbox.AutoSize = true;
            this.packetReportCheckbox.Location = new System.Drawing.Point(803, 866);
            this.packetReportCheckbox.Name = "packetReportCheckbox";
            this.packetReportCheckbox.Size = new System.Drawing.Size(180, 29);
            this.packetReportCheckbox.TabIndex = 12;
            this.packetReportCheckbox.Text = "Packet Report";
            this.packetReportCheckbox.UseVisualStyleBackColor = true;
            this.packetReportCheckbox.CheckedChanged += new System.EventHandler(this.packetReportCheckbox_CheckedChanged);
            // 
            // printHeaderCheckbox
            // 
            this.printHeaderCheckbox.AutoSize = true;
            this.printHeaderCheckbox.Location = new System.Drawing.Point(803, 966);
            this.printHeaderCheckbox.Name = "printHeaderCheckbox";
            this.printHeaderCheckbox.Size = new System.Drawing.Size(164, 29);
            this.printHeaderCheckbox.TabIndex = 13;
            this.printHeaderCheckbox.Text = "Print Header";
            this.printHeaderCheckbox.UseVisualStyleBackColor = true;
            this.printHeaderCheckbox.CheckedChanged += new System.EventHandler(this.printHeaderCheckbox_CheckedChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(816, 1237);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(120, 39);
            this.connectButton.TabIndex = 14;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(816, 1328);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(120, 40);
            this.exitButton.TabIndex = 15;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 1101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Server Responses:";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(56, 121);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(942, 439);
            this.pictureBox.TabIndex = 17;
            this.pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1055, 1446);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.printHeaderCheckbox);
            this.Controls.Add(this.packetReportCheckbox);
            this.Controls.Add(this.serverResponseText);
            this.Controls.Add(this.clientStatusText);
            this.Controls.Add(this.teardownButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.setupButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.videoNameText);
            this.Controls.Add(this.serverIPText);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverIPText;
        private System.Windows.Forms.TextBox videoNameText;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button setupButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button teardownButton;
        private System.Windows.Forms.TextBox clientStatusText;
        private System.Windows.Forms.TextBox serverResponseText;
        private System.Windows.Forms.CheckBox packetReportCheckbox;
        private System.Windows.Forms.CheckBox printHeaderCheckbox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

