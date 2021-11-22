
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
            this.redLEDButton = new System.Windows.Forms.Button();
            this.redLEDCheckBox = new System.Windows.Forms.CheckBox();
            this.serialPorts = new System.Windows.Forms.ComboBox();
            this.connectedCheckBox = new System.Windows.Forms.CheckBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.greenLEDButton = new System.Windows.Forms.Button();
            this.yellowLEDButton = new System.Windows.Forms.Button();
            this.greenLEDCheckBox = new System.Windows.Forms.CheckBox();
            this.yellowLEDCheckBox = new System.Windows.Forms.CheckBox();
            this.qualitySelector = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // redLEDButton
            // 
            this.redLEDButton.Location = new System.Drawing.Point(407, 223);
            this.redLEDButton.Name = "redLEDButton";
            this.redLEDButton.Size = new System.Drawing.Size(75, 23);
            this.redLEDButton.TabIndex = 0;
            this.redLEDButton.Text = "Red LED";
            this.redLEDButton.UseVisualStyleBackColor = true;
            this.redLEDButton.Click += new System.EventHandler(this.redLEDButton_Click);
            // 
            // redLEDCheckBox
            // 
            this.redLEDCheckBox.AutoSize = true;
            this.redLEDCheckBox.Location = new System.Drawing.Point(407, 167);
            this.redLEDCheckBox.Name = "redLEDCheckBox";
            this.redLEDCheckBox.Size = new System.Drawing.Size(65, 17);
            this.redLEDCheckBox.TabIndex = 1;
            this.redLEDCheckBox.Text = "Red ON";
            this.redLEDCheckBox.UseVisualStyleBackColor = true;
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
            // greenLEDButton
            // 
            this.greenLEDButton.Location = new System.Drawing.Point(531, 223);
            this.greenLEDButton.Name = "greenLEDButton";
            this.greenLEDButton.Size = new System.Drawing.Size(75, 23);
            this.greenLEDButton.TabIndex = 6;
            this.greenLEDButton.Text = "Green LED";
            this.greenLEDButton.UseVisualStyleBackColor = true;
            this.greenLEDButton.Click += new System.EventHandler(this.greenLEDButton_Click);
            // 
            // yellowLEDButton
            // 
            this.yellowLEDButton.Location = new System.Drawing.Point(663, 223);
            this.yellowLEDButton.Name = "yellowLEDButton";
            this.yellowLEDButton.Size = new System.Drawing.Size(75, 23);
            this.yellowLEDButton.TabIndex = 7;
            this.yellowLEDButton.Text = "Yellow LED";
            this.yellowLEDButton.UseVisualStyleBackColor = true;
            this.yellowLEDButton.Click += new System.EventHandler(this.yellowLEDButton_Click);
            // 
            // greenLEDCheckBox
            // 
            this.greenLEDCheckBox.AutoSize = true;
            this.greenLEDCheckBox.Location = new System.Drawing.Point(531, 167);
            this.greenLEDCheckBox.Name = "greenLEDCheckBox";
            this.greenLEDCheckBox.Size = new System.Drawing.Size(74, 17);
            this.greenLEDCheckBox.TabIndex = 8;
            this.greenLEDCheckBox.Text = "Green ON";
            this.greenLEDCheckBox.UseVisualStyleBackColor = true;
            // 
            // yellowLEDCheckBox
            // 
            this.yellowLEDCheckBox.AutoSize = true;
            this.yellowLEDCheckBox.Location = new System.Drawing.Point(663, 167);
            this.yellowLEDCheckBox.Name = "yellowLEDCheckBox";
            this.yellowLEDCheckBox.Size = new System.Drawing.Size(76, 17);
            this.yellowLEDCheckBox.TabIndex = 9;
            this.yellowLEDCheckBox.Text = "Yellow ON";
            this.yellowLEDCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.qualitySelector);
            this.Controls.Add(this.yellowLEDCheckBox);
            this.Controls.Add(this.greenLEDCheckBox);
            this.Controls.Add(this.yellowLEDButton);
            this.Controls.Add(this.greenLEDButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.connectedCheckBox);
            this.Controls.Add(this.serialPorts);
            this.Controls.Add(this.redLEDCheckBox);
            this.Controls.Add(this.redLEDButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button redLEDButton;
        private System.Windows.Forms.CheckBox redLEDCheckBox;
        private System.Windows.Forms.ComboBox serialPorts;
        private System.Windows.Forms.CheckBox connectedCheckBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button greenLEDButton;
        private System.Windows.Forms.Button yellowLEDButton;
        private System.Windows.Forms.CheckBox greenLEDCheckBox;
        private System.Windows.Forms.CheckBox yellowLEDCheckBox;
        private System.Windows.Forms.ComboBox qualitySelector;
    }
}

