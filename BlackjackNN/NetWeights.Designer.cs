namespace BlackjackNN
{
    partial class NetWeights
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
            this.InputLabel = new System.Windows.Forms.Label();
            this.HiddenLabel = new System.Windows.Forms.Label();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.PlayerLabel = new System.Windows.Forms.Label();
            this.DealerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(76, 13);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(60, 13);
            this.InputLabel.TabIndex = 0;
            this.InputLabel.Text = "Input Layer";
            // 
            // HiddenLabel
            // 
            this.HiddenLabel.AutoSize = true;
            this.HiddenLabel.Location = new System.Drawing.Point(273, 13);
            this.HiddenLabel.Name = "HiddenLabel";
            this.HiddenLabel.Size = new System.Drawing.Size(70, 13);
            this.HiddenLabel.TabIndex = 1;
            this.HiddenLabel.Text = "Hidden Layer";
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(491, 13);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(68, 13);
            this.OutputLabel.TabIndex = 2;
            this.OutputLabel.Text = "Output Layer";
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Location = new System.Drawing.Point(13, 90);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(36, 13);
            this.PlayerLabel.TabIndex = 3;
            this.PlayerLabel.Text = "Player";
            // 
            // DealerLabel
            // 
            this.DealerLabel.AutoSize = true;
            this.DealerLabel.Location = new System.Drawing.Point(13, 227);
            this.DealerLabel.Name = "DealerLabel";
            this.DealerLabel.Size = new System.Drawing.Size(38, 13);
            this.DealerLabel.TabIndex = 4;
            this.DealerLabel.Text = "Dealer";
            // 
            // NetWeights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 332);
            this.Controls.Add(this.DealerLabel);
            this.Controls.Add(this.PlayerLabel);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.HiddenLabel);
            this.Controls.Add(this.InputLabel);
            this.Name = "NetWeights";
            this.Text = "NetWeights";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.Label HiddenLabel;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Label PlayerLabel;
        private System.Windows.Forms.Label DealerLabel;
    }
}