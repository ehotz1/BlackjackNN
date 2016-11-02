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
        int generation;

        public NetInterface(GeneticAlgorithm ga)
        {
            GA = ga;
            generation = 0;
            InitializeComponent();
        }

        public void UpdateDisplay(string text)
        {
            InterfaceTextBox.Text = generation + ": " + text + "\n" + InterfaceTextBox.Text;
            
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (GA.Stop)
            {
                StopButton.Text = "Pause";
                GA.Stop = false;
                try
                {
                    GA.Run();
                    GA.Stop = true;
                    StopButton.Text = "Run";
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            else
            {
                StopButton.Text = "Run";
                GA.Stop = true;
            }
        }
    }
}
