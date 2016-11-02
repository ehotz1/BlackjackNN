namespace BlackjackNN
{
    partial class MainForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.NewRoundButton = new System.Windows.Forms.Button();
            this.HitButton = new System.Windows.Forms.Button();
            this.StayButton = new System.Windows.Forms.Button();
            this.PlayerHandLabel = new System.Windows.Forms.Label();
            this.DealerHandLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PopSizeBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GenBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PauseTime = new System.Windows.Forms.NumericUpDown();
            this.RunButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PauseTime)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(54, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "BlackJack";
            // 
            // NewRoundButton
            // 
            this.NewRoundButton.Location = new System.Drawing.Point(12, 65);
            this.NewRoundButton.Name = "NewRoundButton";
            this.NewRoundButton.Size = new System.Drawing.Size(75, 23);
            this.NewRoundButton.TabIndex = 3;
            this.NewRoundButton.Text = "New Round";
            this.NewRoundButton.UseVisualStyleBackColor = true;
            this.NewRoundButton.Click += new System.EventHandler(this.NewRoundButton_Click);
            // 
            // HitButton
            // 
            this.HitButton.Location = new System.Drawing.Point(375, 279);
            this.HitButton.Name = "HitButton";
            this.HitButton.Size = new System.Drawing.Size(75, 23);
            this.HitButton.TabIndex = 8;
            this.HitButton.Text = "Hit";
            this.HitButton.UseVisualStyleBackColor = true;
            this.HitButton.Click += new System.EventHandler(this.HitButton_Click);
            // 
            // StayButton
            // 
            this.StayButton.Location = new System.Drawing.Point(506, 279);
            this.StayButton.Name = "StayButton";
            this.StayButton.Size = new System.Drawing.Size(75, 23);
            this.StayButton.TabIndex = 9;
            this.StayButton.Text = "Stay";
            this.StayButton.UseVisualStyleBackColor = true;
            this.StayButton.Click += new System.EventHandler(this.StayButton_Click);
            // 
            // PlayerHandLabel
            // 
            this.PlayerHandLabel.AutoSize = true;
            this.PlayerHandLabel.Location = new System.Drawing.Point(140, 155);
            this.PlayerHandLabel.Name = "PlayerHandLabel";
            this.PlayerHandLabel.Size = new System.Drawing.Size(75, 13);
            this.PlayerHandLabel.TabIndex = 10;
            this.PlayerHandLabel.Text = "Player\'s Hand:";
            // 
            // DealerHandLabel
            // 
            this.DealerHandLabel.AutoSize = true;
            this.DealerHandLabel.Location = new System.Drawing.Point(140, 9);
            this.DealerHandLabel.Name = "DealerHandLabel";
            this.DealerHandLabel.Size = new System.Drawing.Size(77, 13);
            this.DealerHandLabel.TabIndex = 11;
            this.DealerHandLabel.Text = "Dealer\'s Hand:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Game Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Game:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Neural Net Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Population Size";
            // 
            // PopSizeBox
            // 
            this.PopSizeBox.Location = new System.Drawing.Point(12, 171);
            this.PopSizeBox.Name = "PopSizeBox";
            this.PopSizeBox.Size = new System.Drawing.Size(77, 20);
            this.PopSizeBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "# of Generations";
            // 
            // GenBox
            // 
            this.GenBox.Location = new System.Drawing.Point(12, 210);
            this.GenBox.Name = "GenBox";
            this.GenBox.Size = new System.Drawing.Size(77, 20);
            this.GenBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Pause";
            // 
            // PauseTime
            // 
            this.PauseTime.Location = new System.Drawing.Point(54, 237);
            this.PauseTime.Name = "PauseTime";
            this.PauseTime.Size = new System.Drawing.Size(35, 20);
            this.PauseTime.TabIndex = 20;
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(14, 263);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 21;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(715, 323);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.PauseTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GenBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PopSizeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DealerHandLabel);
            this.Controls.Add(this.PlayerHandLabel);
            this.Controls.Add(this.StayButton);
            this.Controls.Add(this.HitButton);
            this.Controls.Add(this.NewRoundButton);
            this.Controls.Add(this.comboBox1);
            this.Name = "MainForm";
            this.Text = "Blackjack";
            ((System.ComponentModel.ISupportInitialize)(this.PauseTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button NewRoundButton;
        private System.Windows.Forms.Button HitButton;
        private System.Windows.Forms.Button StayButton;
        private System.Windows.Forms.Label PlayerHandLabel;
        private System.Windows.Forms.Label DealerHandLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PopSizeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox GenBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown PauseTime;
        private System.Windows.Forms.Button RunButton;
    }
}

