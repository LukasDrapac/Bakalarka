
namespace Arduino_Controller
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.serialPorts = new System.Windows.Forms.ComboBox();
            this.connectedCheckBox = new System.Windows.Forms.CheckBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.qualitySelectComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.camBox = new System.Windows.Forms.ComboBox();
            this.camCheckBox = new System.Windows.Forms.CheckBox();
            this.serialPortsLabel = new System.Windows.Forms.Label();
            this.camLabel = new System.Windows.Forms.Label();
            this.qualitySelectorLabel = new System.Windows.Forms.Label();
            this.makeSnapshot = new System.Windows.Forms.Button();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPorts
            // 
            this.serialPorts.FormattingEnabled = true;
            this.serialPorts.Location = new System.Drawing.Point(27, 393);
            this.serialPorts.Margin = new System.Windows.Forms.Padding(4);
            this.serialPorts.Name = "serialPorts";
            this.serialPorts.Size = new System.Drawing.Size(160, 24);
            this.serialPorts.TabIndex = 2;
            // 
            // connectedCheckBox
            // 
            this.connectedCheckBox.AutoSize = true;
            this.connectedCheckBox.Enabled = false;
            this.connectedCheckBox.Location = new System.Drawing.Point(206, 396);
            this.connectedCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.connectedCheckBox.Name = "connectedCheckBox";
            this.connectedCheckBox.Size = new System.Drawing.Size(98, 21);
            this.connectedCheckBox.TabIndex = 3;
            this.connectedCheckBox.Text = "Connected";
            this.connectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(402, 389);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(100, 28);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(402, 436);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(100, 28);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(778, 385);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 28);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // qualitySelectComboBox
            // 
            this.qualitySelectComboBox.FormattingEnabled = true;
            this.qualitySelectComboBox.Location = new System.Drawing.Point(535, 389);
            this.qualitySelectComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.qualitySelectComboBox.Name = "qualitySelectComboBox";
            this.qualitySelectComboBox.Size = new System.Drawing.Size(160, 24);
            this.qualitySelectComboBox.TabIndex = 7;
            this.qualitySelectComboBox.SelectedIndexChanged += new System.EventHandler(this.qualitySelectComboBox_SelectedIndexChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(979, 45);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(375, 294);
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // camBox
            // 
            this.camBox.FormattingEnabled = true;
            this.camBox.Location = new System.Drawing.Point(27, 455);
            this.camBox.Margin = new System.Windows.Forms.Padding(4);
            this.camBox.Name = "camBox";
            this.camBox.Size = new System.Drawing.Size(160, 24);
            this.camBox.TabIndex = 11;
            // 
            // camCheckBox
            // 
            this.camCheckBox.AutoSize = true;
            this.camCheckBox.Enabled = false;
            this.camCheckBox.Location = new System.Drawing.Point(206, 458);
            this.camCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.camCheckBox.Name = "camCheckBox";
            this.camCheckBox.Size = new System.Drawing.Size(98, 21);
            this.camCheckBox.TabIndex = 12;
            this.camCheckBox.Text = "Connected";
            this.camCheckBox.UseVisualStyleBackColor = true;
            // 
            // serialPortsLabel
            // 
            this.serialPortsLabel.AutoSize = true;
            this.serialPortsLabel.Location = new System.Drawing.Point(27, 369);
            this.serialPortsLabel.Name = "serialPortsLabel";
            this.serialPortsLabel.Size = new System.Drawing.Size(76, 17);
            this.serialPortsLabel.TabIndex = 13;
            this.serialPortsLabel.Text = "COM Ports";
            // 
            // camLabel
            // 
            this.camLabel.AutoSize = true;
            this.camLabel.Location = new System.Drawing.Point(27, 434);
            this.camLabel.Name = "camLabel";
            this.camLabel.Size = new System.Drawing.Size(91, 17);
            this.camLabel.TabIndex = 14;
            this.camLabel.Text = "Video Device";
            // 
            // qualitySelectorLabel
            // 
            this.qualitySelectorLabel.AutoSize = true;
            this.qualitySelectorLabel.Location = new System.Drawing.Point(532, 368);
            this.qualitySelectorLabel.Name = "qualitySelectorLabel";
            this.qualitySelectorLabel.Size = new System.Drawing.Size(52, 17);
            this.qualitySelectorLabel.TabIndex = 15;
            this.qualitySelectorLabel.Text = "Quality";
            // 
            // makeSnapshot
            // 
            this.makeSnapshot.Location = new System.Drawing.Point(402, 491);
            this.makeSnapshot.Margin = new System.Windows.Forms.Padding(4);
            this.makeSnapshot.Name = "makeSnapshot";
            this.makeSnapshot.Size = new System.Drawing.Size(100, 28);
            this.makeSnapshot.TabIndex = 16;
            this.makeSnapshot.Text = "Snapshot";
            this.makeSnapshot.UseVisualStyleBackColor = true;
            this.makeSnapshot.Click += new System.EventHandler(this.makeSnapshot_Click);
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Location = new System.Drawing.Point(30, 45);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(387, 294);
            this.videoSourcePlayer.TabIndex = 17;
            this.videoSourcePlayer.Text = "videoSourcePlayer1";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(525, 45);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(387, 294);
            this.videoSourcePlayer1.TabIndex = 18;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 554);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Controls.Add(this.videoSourcePlayer);
            this.Controls.Add(this.makeSnapshot);
            this.Controls.Add(this.qualitySelectorLabel);
            this.Controls.Add(this.camLabel);
            this.Controls.Add(this.serialPortsLabel);
            this.Controls.Add(this.camCheckBox);
            this.Controls.Add(this.camBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.qualitySelectComboBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.connectedCheckBox);
            this.Controls.Add(this.serialPorts);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox serialPorts;
        private System.Windows.Forms.CheckBox connectedCheckBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox qualitySelectComboBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox camBox;
        private System.Windows.Forms.CheckBox camCheckBox;
        private System.Windows.Forms.Label serialPortsLabel;
        private System.Windows.Forms.Label camLabel;
        private System.Windows.Forms.Label qualitySelectorLabel;
        private System.Windows.Forms.Button makeSnapshot;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
    }
}

