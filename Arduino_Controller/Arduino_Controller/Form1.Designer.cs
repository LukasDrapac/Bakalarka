
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
            this.camConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.serialPortsLabel = new System.Windows.Forms.Label();
            this.camLabel = new System.Windows.Forms.Label();
            this.qualitySelectorLabel = new System.Windows.Forms.Label();
            this.makeSnapshot = new System.Windows.Forms.Button();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.inventoryNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowsingButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPorts
            // 
            this.serialPorts.FormattingEnabled = true;
            this.serialPorts.Location = new System.Drawing.Point(19, 439);
            this.serialPorts.Name = "serialPorts";
            this.serialPorts.Size = new System.Drawing.Size(121, 21);
            this.serialPorts.TabIndex = 2;
            // 
            // connectedCheckBox
            // 
            this.connectedCheckBox.AutoSize = true;
            this.connectedCheckBox.Enabled = false;
            this.connectedCheckBox.Location = new System.Drawing.Point(154, 442);
            this.connectedCheckBox.Name = "connectedCheckBox";
            this.connectedCheckBox.Size = new System.Drawing.Size(115, 17);
            this.connectedCheckBox.TabIndex = 3;
            this.connectedCheckBox.Text = "Přípravek připojen";
            this.connectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(300, 436);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Připojit";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(300, 474);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Odpojit";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(582, 433);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // qualitySelectComboBox
            // 
            this.qualitySelectComboBox.FormattingEnabled = true;
            this.qualitySelectComboBox.Location = new System.Drawing.Point(400, 436);
            this.qualitySelectComboBox.Name = "qualitySelectComboBox";
            this.qualitySelectComboBox.Size = new System.Drawing.Size(121, 21);
            this.qualitySelectComboBox.TabIndex = 7;
            this.qualitySelectComboBox.SelectedIndexChanged += new System.EventHandler(this.qualitySelectComboBox_SelectedIndexChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(11, 8);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(574, 375);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // camBox
            // 
            this.camBox.FormattingEnabled = true;
            this.camBox.Location = new System.Drawing.Point(19, 490);
            this.camBox.Name = "camBox";
            this.camBox.Size = new System.Drawing.Size(121, 21);
            this.camBox.TabIndex = 11;
            // 
            // camConnectCheckBox
            // 
            this.camConnectCheckBox.AutoSize = true;
            this.camConnectCheckBox.Enabled = false;
            this.camConnectCheckBox.Location = new System.Drawing.Point(154, 492);
            this.camConnectCheckBox.Name = "camConnectCheckBox";
            this.camConnectCheckBox.Size = new System.Drawing.Size(109, 17);
            this.camConnectCheckBox.TabIndex = 12;
            this.camConnectCheckBox.Text = "Kamera připojena";
            this.camConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // serialPortsLabel
            // 
            this.serialPortsLabel.AutoSize = true;
            this.serialPortsLabel.Location = new System.Drawing.Point(19, 420);
            this.serialPortsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.serialPortsLabel.Name = "serialPortsLabel";
            this.serialPortsLabel.Size = new System.Drawing.Size(88, 13);
            this.serialPortsLabel.TabIndex = 13;
            this.serialPortsLabel.Text = "Výběr COM portu";
            // 
            // camLabel
            // 
            this.camLabel.AutoSize = true;
            this.camLabel.Location = new System.Drawing.Point(19, 472);
            this.camLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.camLabel.Name = "camLabel";
            this.camLabel.Size = new System.Drawing.Size(71, 13);
            this.camLabel.TabIndex = 14;
            this.camLabel.Text = "Výběr kamery";
            // 
            // qualitySelectorLabel
            // 
            this.qualitySelectorLabel.AutoSize = true;
            this.qualitySelectorLabel.Location = new System.Drawing.Point(398, 419);
            this.qualitySelectorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qualitySelectorLabel.Name = "qualitySelectorLabel";
            this.qualitySelectorLabel.Size = new System.Drawing.Size(73, 13);
            this.qualitySelectorLabel.TabIndex = 15;
            this.qualitySelectorLabel.Text = "Počet snímků";
            // 
            // makeSnapshot
            // 
            this.makeSnapshot.Location = new System.Drawing.Point(300, 519);
            this.makeSnapshot.Name = "makeSnapshot";
            this.makeSnapshot.Size = new System.Drawing.Size(75, 23);
            this.makeSnapshot.TabIndex = 16;
            this.makeSnapshot.Text = "Test snímku";
            this.makeSnapshot.UseVisualStyleBackColor = true;
            this.makeSnapshot.Click += new System.EventHandler(this.makeSnapshot_Click);
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Location = new System.Drawing.Point(641, 8);
            this.videoSourcePlayer.Margin = new System.Windows.Forms.Padding(2);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(574, 375);
            this.videoSourcePlayer.TabIndex = 17;
            this.videoSourcePlayer.Text = "videoSourcePlayer1";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // inventoryNumber
            // 
            this.inventoryNumber.Location = new System.Drawing.Point(400, 491);
            this.inventoryNumber.Margin = new System.Windows.Forms.Padding(2);
            this.inventoryNumber.Name = "inventoryNumber";
            this.inventoryNumber.Size = new System.Drawing.Size(121, 20);
            this.inventoryNumber.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 472);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Inventární číslo kraslice";
            // 
            // folderBrowsingButton
            // 
            this.folderBrowsingButton.Location = new System.Drawing.Point(400, 543);
            this.folderBrowsingButton.Name = "folderBrowsingButton";
            this.folderBrowsingButton.Size = new System.Drawing.Size(88, 23);
            this.folderBrowsingButton.TabIndex = 22;
            this.folderBrowsingButton.Text = "Uložit do složky";
            this.folderBrowsingButton.UseVisualStyleBackColor = true;
            this.folderBrowsingButton.Click += new System.EventHandler(this.folderBrowsingButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 524);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Kořenová složka se snímky kraslic";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 584);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderBrowsingButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inventoryNumber);
            this.Controls.Add(this.videoSourcePlayer);
            this.Controls.Add(this.makeSnapshot);
            this.Controls.Add(this.qualitySelectorLabel);
            this.Controls.Add(this.camLabel);
            this.Controls.Add(this.serialPortsLabel);
            this.Controls.Add(this.camConnectCheckBox);
            this.Controls.Add(this.camBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.qualitySelectComboBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.connectedCheckBox);
            this.Controls.Add(this.serialPorts);
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
        private System.Windows.Forms.CheckBox camConnectCheckBox;
        private System.Windows.Forms.Label serialPortsLabel;
        private System.Windows.Forms.Label camLabel;
        private System.Windows.Forms.Label qualitySelectorLabel;
        private System.Windows.Forms.Button makeSnapshot;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.TextBox inventoryNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button folderBrowsingButton;
        private System.Windows.Forms.Label label1;
    }
}

