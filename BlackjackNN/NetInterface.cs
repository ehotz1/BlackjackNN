using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackNN
{
    public partial class NetInterface : Form
    {
        GeneticAlgorithm GA;

        public NetInterface(GeneticAlgorithm ga)
        {
            GA = ga;
            InitializeComponent();
        }

        public void UpdateDisplay(string text)
        {
            InterfaceTextBox.Text = text + "\n" + InterfaceTextBox.Text;
        }

        public void Reset()
        {
            RunButton.Enabled = false;
            ParamsButton.Enabled = true;
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (GA.Stop)
            {
                RunButton.Text = "Pause";
                GA.Stop = false;
                try
                {
                    ParamsButton.Enabled = false;
                    GA.Run();
                    GA.Stop = true;
                    RunButton.Text = "Run";
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            else
            {
                RunButton.Text = "Run";
                GA.Stop = true;
            }
        }

        private void ParamsButton_Click(object sender, EventArgs e)
        {
            InterfaceTextBox.Text = "";
            try
            {
                GA.SetParams(Int32.Parse(PopSizeBox.Text), Int32.Parse(GenBox.Text),(int)RoundNumControl.Value,(int)WinPercentageControl.Value);
                RunButton.Enabled = true;
            } catch (Exception ex)
            {
                MessageBox.Show("Please enter valid integers in the population/generation fields");
            }
        }

        private void TestTopNetworkButton_Click(object sender, EventArgs e)
        {
            try
            {
                GA.TestTopNetwork();
            } catch (Exception ex)
            {
                InterfaceTextBox.Text = "No networks available \n" + InterfaceTextBox.Text;
            }
        }

        private void WeightsButton_Click(object sender, EventArgs e)
        {
            try
            {
                NetWeights NW = new NetWeights(GA.GetTopNetworkWeights());
                NW.Show();
            }
            catch (Exception ex)
            {
                InterfaceTextBox.Text = "No networks available \n" + InterfaceTextBox.Text;
                Console.WriteLine(ex);
            }
        }
        
    }
}
