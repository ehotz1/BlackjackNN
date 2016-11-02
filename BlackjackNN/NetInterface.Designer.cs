namespace BlackjackNN
{
    partial class NetInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InterfaceTextBox = new System.Windows.Forms.RichTextBox();
            this.GenLabel = new System.Windows.Forms.Label();
            this.GenNumber = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InterfaceTextBox
            // 
            this.InterfaceTextBox.Location = new System.Drawing.Point(13, 13);
            this.InterfaceTextBox.Name = "InterfaceTextBox";
            this.InterfaceTextBox.ReadOnly = true;
            this.InterfaceTextBox.Size = new System.Drawing.Size(308, 306);
            this.InterfaceTextBox.TabIndex = 0;
            this.InterfaceTextBox.Text = "";
            // 
            // GenLabel
            // 
            this.GenLabel.AutoSize = true;
            this.GenLabel.Location = new System.Drawing.Point(328, 13);
            this.GenLabel.Name = "GenLabel";
            this.GenLabel.Size = new System.Drawing.Size(62, 13);
            this.GenLabel.TabIndex = 1;
            this.GenLabel.Text = "Generation:";
            // 
            // GenNumber
            // 
            this.GenNumber.AutoSize = true;
            this.GenNumber.Location = new System.Drawing.Point(397, 13);
            this.GenNumber.Name = "GenNumber";
            this.GenNumber.Size = new System.Drawing.Size(13, 13);
            this.GenNumber.TabIndex = 2;
            this.GenNumber.Text = "0";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(542, 296);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 23;
            this.StopButton.Text = "Run";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // NetInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 331);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.GenNumber);
            this.Controls.Add(this.GenLabel);
            this.Controls.Add(this.InterfaceTextBox);
            this.Name = "NetInterface";
            this.Text = "NetInterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox InterfaceTextBox;
        private System.Windows.Forms.Label GenLabel;
        private System.Windows.Forms.Label GenNumber;
        private System.Windows.Forms.Button StopButton;
    }
}