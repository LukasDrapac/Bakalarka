
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
            this.SuspendLayout();
            // 
            // serialPorts
            // 
            this.serialPorts.FormattingEnabled = true;
            this.serialPorts.Location = new System.Drawing.Point(28, 305);
            this.serialPorts.Name = "serialPorts";
            this.serialPorts.Size = new System.Drawing.Size(121, 21);
            this.serialPorts.TabIndex = 2;
            // 
            // connectedCheckBox
            // 
            this.connectedCheckBox.AutoSize = true;
            this.connectedCheckBox.Enabled = false;
            this.connectedCheckBox.Location = new System.Drawing.Point(28, 355);
            this.connectedCheckBox.Name = "connectedCheckBox";
            this.connectedCheckBox.Size = new System.Drawing.Size(78, 17);
            this.connectedCheckBox.TabIndex = 3;
            this.connectedCheckBox.Text = "Connected";
            this.connectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(234, 305);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(234, 355);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(594, 305);
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
            this.qualitySelectComboBox.Location = new System.Drawing.Point(401, 305);
            this.qualitySelectComboBox.Name = "qualitySelectComboBox";
            this.qualitySelectComboBox.Size = new System.Drawing.Size(121, 21);
            this.qualitySelectComboBox.TabIndex = 7;
            this.qualitySelectComboBox.SelectedIndexChanged += new System.EventHandler(this.qualitySelectComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.qualitySelectComboBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.connectedCheckBox);
            this.Controls.Add(this.serialPorts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
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
    }
}

