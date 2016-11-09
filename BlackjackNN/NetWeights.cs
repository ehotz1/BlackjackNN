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
    public partial class NetWeights : Form
    {
        Rectangle I1;
        Rectangle I2;
        Rectangle H1;
        Rectangle H2;
        Rectangle O;
        List<double[][]> weights;

        public NetWeights(List<double[][]> w)
        {
            
            weights = w;
            InitializeComponent();
            I1 = new Rectangle(InputLabel.Left, PlayerLabel.Top, 75, 75);
            I2 = new Rectangle(InputLabel.Left, DealerLabel.Top, 75, 75);
            H1 = new Rectangle(HiddenLabel.Left, PlayerLabel.Top, 75, 75);
            H2 = new Rectangle(HiddenLabel.Left, DealerLabel.Top, 75, 75);
            O = new Rectangle(OutputLabel.Left, PlayerLabel.Bottom + 30, 75, 75);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawNetwork(this, e);
        }

        private void DrawNetwork(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 3);
            Brush b = new SolidBrush(Color.Black);
            Font f = new Font(FontFamily.GenericSansSerif, 12);
            g.DrawEllipse(p, I1);
            g.DrawEllipse(p, I2);
            g.DrawEllipse(p, H1);
            g.DrawEllipse(p, H2);
            g.DrawEllipse(p, O);
            g.DrawString(GetWeights(0,0), f, b, I1.X, I1.Y - 25);
            g.DrawString(GetWeights(0, 1), f, b, I2.X, I2.Y - 25);
            g.DrawString(GetWeights(1, 0), f, b, H1.X, H1.Y - 25);
            g.DrawString(GetWeights(1, 1), f, b, H2.X, H2.Y - 25);
            g.DrawString(GetWeights(2, 0), f, b, O.X, O.Y - 25);
        }

        private string GetWeights(int i, int j)
        {
            string s = "";
            foreach (double d in weights[i][j])
            {
                s += d.ToString("#.00") + ", ";
            }
            return s;
        }
    }
}
