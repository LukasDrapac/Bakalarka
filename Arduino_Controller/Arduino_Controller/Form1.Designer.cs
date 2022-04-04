
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
            this.measureButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPorts
            // 
            this.serialPorts.FormattingEnabled = true;
            this.serialPorts.Location = new System.Drawing.Point(25, 540);
            this.serialPorts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serialPorts.Name = "serialPorts";
            this.serialPorts.Size = new System.Drawing.Size(160, 24);
            this.serialPorts.TabIndex = 2;
            // 
            // connectedCheckBox
            // 
            this.connectedCheckBox.AutoSize = true;
            this.connectedCheckBox.Enabled = false;
            this.connectedCheckBox.Location = new System.Drawing.Point(205, 544);
            this.connectedCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectedCheckBox.Name = "connectedCheckBox";
            this.connectedCheckBox.Size = new System.Drawing.Size(145, 21);
            this.connectedCheckBox.TabIndex = 3;
            this.connectedCheckBox.Text = "Přípravek připojen";
            this.connectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(400, 537);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(100, 28);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Připojit";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(400, 583);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(100, 28);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Odpojit";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(776, 533);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.qualitySelectComboBox.Location = new System.Drawing.Point(533, 537);
            this.qualitySelectComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.qualitySelectComboBox.Name = "qualitySelectComboBox";
            this.qualitySelectComboBox.Size = new System.Drawing.Size(160, 24);
            this.qualitySelectComboBox.TabIndex = 7;
            this.qualitySelectComboBox.SelectedIndexChanged += new System.EventHandler(this.qualitySelectComboBox_SelectedIndexChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(15, 10);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(765, 462);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // camBox
            // 
            this.camBox.FormattingEnabled = true;
            this.camBox.Location = new System.Drawing.Point(25, 603);
            this.camBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.camBox.Name = "camBox";
            this.camBox.Size = new System.Drawing.Size(160, 24);
            this.camBox.TabIndex = 11;
            // 
            // camConnectCheckBox
            // 
            this.camConnectCheckBox.AutoSize = true;
            this.camConnectCheckBox.Enabled = false;
            this.camConnectCheckBox.Location = new System.Drawing.Point(205, 606);
            this.camConnectCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.camConnectCheckBox.Name = "camConnectCheckBox";
            this.camConnectCheckBox.Size = new System.Drawing.Size(142, 21);
            this.camConnectCheckBox.TabIndex = 12;
            this.camConnectCheckBox.Text = "Kamera připojena";
            this.camConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // serialPortsLabel
            // 
            this.serialPortsLabel.AutoSize = true;
            this.serialPortsLabel.Location = new System.Drawing.Point(25, 517);
            this.serialPortsLabel.Name = "serialPortsLabel";
            this.serialPortsLabel.Size = new System.Drawing.Size(117, 17);
            this.serialPortsLabel.TabIndex = 13;
            this.serialPortsLabel.Text = "Výběr COM portu";
            // 
            // camLabel
            // 
            this.camLabel.AutoSize = true;
            this.camLabel.Location = new System.Drawing.Point(25, 581);
            this.camLabel.Name = "camLabel";
            this.camLabel.Size = new System.Drawing.Size(95, 17);
            this.camLabel.TabIndex = 14;
            this.camLabel.Text = "Výběr kamery";
            // 
            // qualitySelectorLabel
            // 
            this.qualitySelectorLabel.AutoSize = true;
            this.qualitySelectorLabel.Location = new System.Drawing.Point(531, 516);
            this.qualitySelectorLabel.Name = "qualitySelectorLabel";
            this.qualitySelectorLabel.Size = new System.Drawing.Size(92, 17);
            this.qualitySelectorLabel.TabIndex = 15;
            this.qualitySelectorLabel.Text = "Počet snímků";
            // 
            // makeSnapshot
            // 
            this.makeSnapshot.Location = new System.Drawing.Point(400, 639);
            this.makeSnapshot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.makeSnapshot.Name = "makeSnapshot";
            this.makeSnapshot.Size = new System.Drawing.Size(100, 28);
            this.makeSnapshot.TabIndex = 16;
            this.makeSnapshot.Text = "Test snímku";
            this.makeSnapshot.UseVisualStyleBackColor = true;
            this.makeSnapshot.Click += new System.EventHandler(this.makeSnapshot_Click);
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Location = new System.Drawing.Point(855, 10);
            this.videoSourcePlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(765, 462);
            this.videoSourcePlayer.TabIndex = 17;
            this.videoSourcePlayer.Text = "videoSourcePlayer1";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // inventoryNumber
            // 
            this.inventoryNumber.Location = new System.Drawing.Point(533, 604);
            this.inventoryNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inventoryNumber.Name = "inventoryNumber";
            this.inventoryNumber.Size = new System.Drawing.Size(160, 22);
            this.inventoryNumber.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 581);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Inventární číslo kraslice";
            // 
            // folderBrowsingButton
            // 
            this.folderBrowsingButton.Location = new System.Drawing.Point(533, 668);
            this.folderBrowsingButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.folderBrowsingButton.Name = "folderBrowsingButton";
            this.folderBrowsingButton.Size = new System.Drawing.Size(117, 28);
            this.folderBrowsingButton.TabIndex = 22;
            this.folderBrowsingButton.Text = "Uložit do složky";
            this.folderBrowsingButton.UseVisualStyleBackColor = true;
            this.folderBrowsingButton.Click += new System.EventHandler(this.folderBrowsingButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 645);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Kořenová složka se snímky kraslic";
            // 
            // measureButton
            // 
            this.measureButton.Location = new System.Drawing.Point(776, 603);
            this.measureButton.Name = "measureButton";
            this.measureButton.Size = new System.Drawing.Size(100, 34);
            this.measureButton.TabIndex = 24;
            this.measureButton.Text = "Změřit výšku";
            this.measureButton.UseVisualStyleBackColor = true;
            this.measureButton.Click += new System.EventHandler(this.measureButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 719);
            this.Controls.Add(this.measureButton);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button measureButton;
    }
}

