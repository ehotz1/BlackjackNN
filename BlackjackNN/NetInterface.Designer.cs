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
            this.RunButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PopSizeBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GenBox = new System.Windows.Forms.TextBox();
            this.ParamsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RoundNumControl = new System.Windows.Forms.NumericUpDown();
            this.WinPercentageControl = new System.Windows.Forms.NumericUpDown();
            this.TestTopNetworkButton = new System.Windows.Forms.Button();
            this.WeightsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RoundNumControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinPercentageControl)).BeginInit();
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
            // RunButton
            // 
            this.RunButton.Enabled = false;
            this.RunButton.Location = new System.Drawing.Point(542, 296);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 23;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Population Size";
            // 
            // PopSizeBox
            // 
            this.PopSizeBox.Location = new System.Drawing.Point(413, 16);
            this.PopSizeBox.Name = "PopSizeBox";
            this.PopSizeBox.Size = new System.Drawing.Size(77, 20);
            this.PopSizeBox.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "# of Generations";
            // 
            // GenBox
            // 
            this.GenBox.Location = new System.Drawing.Point(413, 56);
            this.GenBox.Name = "GenBox";
            this.GenBox.Size = new System.Drawing.Size(77, 20);
            this.GenBox.TabIndex = 27;
            // 
            // ParamsButton
            // 
            this.ParamsButton.Location = new System.Drawing.Point(515, 13);
            this.ParamsButton.Name = "ParamsButton";
            this.ParamsButton.Size = new System.Drawing.Size(89, 23);
            this.ParamsButton.TabIndex = 30;
            this.ParamsButton.Text = "Set Parameters";
            this.ParamsButton.UseVisualStyleBackColor = true;
            this.ParamsButton.Click += new System.EventHandler(this.ParamsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Rounds Per Network";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Win Percentage Required";
            // 
            // RoundNumControl
            // 
            this.RoundNumControl.Location = new System.Drawing.Point(442, 89);
            this.RoundNumControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RoundNumControl.Name = "RoundNumControl";
            this.RoundNumControl.Size = new System.Drawing.Size(47, 20);
            this.RoundNumControl.TabIndex = 33;
            this.RoundNumControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WinPercentageControl
            // 
            this.WinPercentageControl.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WinPercentageControl.Location = new System.Drawing.Point(470, 119);
            this.WinPercentageControl.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.WinPercentageControl.Name = "WinPercentageControl";
            this.WinPercentageControl.Size = new System.Drawing.Size(36, 20);
            this.WinPercentageControl.TabIndex = 34;
            this.WinPercentageControl.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // TestTopNetworkButton
            // 
            this.TestTopNetworkButton.Location = new System.Drawing.Point(336, 250);
            this.TestTopNetworkButton.Name = "TestTopNetworkButton";
            this.TestTopNetworkButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TestTopNetworkButton.Size = new System.Drawing.Size(127, 23);
            this.TestTopNetworkButton.TabIndex = 35;
            this.TestTopNetworkButton.Text = "Test Top Network";
            this.TestTopNetworkButton.UseVisualStyleBackColor = true;
            this.TestTopNetworkButton.Click += new System.EventHandler(this.TestTopNetworkButton_Click);
            // 
            // WeightsButton
            // 
            this.WeightsButton.Location = new System.Drawing.Point(470, 250);
            this.WeightsButton.Name = "WeightsButton";
            this.WeightsButton.Size = new System.Drawing.Size(134, 23);
            this.WeightsButton.TabIndex = 36;
            this.WeightsButton.Text = "View Top Weights";
            this.WeightsButton.UseVisualStyleBackColor = true;
            this.WeightsButton.Click += new System.EventHandler(this.WeightsButton_Click);
            // 
            // NetInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 331);
            this.Controls.Add(this.WeightsButton);
            this.Controls.Add(this.TestTopNetworkButton);
            this.Controls.Add(this.WinPercentageControl);
            this.Controls.Add(this.RoundNumControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ParamsButton);
            this.Controls.Add(this.GenBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PopSizeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.InterfaceTextBox);
            this.Name = "NetInterface";
            this.Text = "NetInterface";
            ((System.ComponentModel.ISupportInitialize)(this.RoundNumControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinPercentageControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox InterfaceTextBox;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PopSizeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox GenBox;
        private System.Windows.Forms.Button ParamsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RoundNumControl;
        private System.Windows.Forms.NumericUpDown WinPercentageControl;
        private System.Windows.Forms.Button TestTopNetworkButton;
        private System.Windows.Forms.Button WeightsButton;
    }
}