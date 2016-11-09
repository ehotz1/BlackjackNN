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
    public partial class MainForm : Form
    {
        private BlackjackLogic logic;
        private Point DealerPoint;
        private Point PlayerPoint;
        //Draw variables
        private Graphics graphics;
        private SolidBrush brush;
        private Font font;
        private int CardWidth;
        private int CardHeight;

        public MainForm()
        {
            logic = BlackjackLogic.GetInstance();

            font = new Font(FontFamily.GenericSansSerif, 25);
            CardWidth = 75;
            CardHeight = 100;

            InitializeComponent();

            DealerPoint = new Point(DealerHandLabel.Left, DealerHandLabel.Top);
            PlayerPoint = new Point(PlayerHandLabel.Left, PlayerHandLabel.Top);
            HitButton.Enabled = false;
            StayButton.Enabled = false;
        }

        private void NewRoundButton_Click(object sender, EventArgs e)
        {
            logic.PlayRound();
            ReDrawCards(false);
            logic.BlackJackCheck();
            CheckRunning();
        }

        private void HitButton_Click(object sender, EventArgs e)
        {
            logic.Hit();
            ReDrawCards(false);
            CheckRunning();
        }

        private void StayButton_Click(object sender, EventArgs e)
        {
            logic.Stay();
            ReDrawCards(true);
            CheckRunning();
        }

        private void CheckRunning()
        {
            if (logic.CanAct)
            {
                HitButton.Enabled = true;
                StayButton.Enabled = true;
            } else
            {
                HitButton.Enabled = false;
                StayButton.Enabled = false;
                ReDrawCards(true);
                graphics = this.CreateGraphics();
                brush = new SolidBrush(Color.Black);
                string results = (BlackjackLogic.GetInstance().round_replay.win) ? "You win!" : "You lose!";
                graphics.DrawString(results, font, brush, Width / 2, Height / 2);
            }
        }

        private void ReDrawCards(bool DealerVisible)
        {
            graphics = this.CreateGraphics();
            brush = new SolidBrush(Color.Black);
            graphics.Clear(Color.ForestGreen);
            for (int i = 0; i < logic.DealerHand.Cards.Count; i++)
            {
                if (i == 0 && !DealerVisible)
                {
                    brush.Color = Color.Black;
                    Rectangle card = new Rectangle(DealerPoint.X + 75, DealerPoint.Y, CardWidth, CardHeight);
                    graphics.FillRectangle(brush, card);
                    
                }
                else
                {
                    brush.Color = Color.White;
                    Rectangle card = new Rectangle(DealerPoint.X + 75 + i * 100, DealerPoint.Y, CardWidth, CardHeight);
                    graphics.FillRectangle(brush, card);
                    brush.Color = logic.DealerHand.Cards[i].CardColor;
                    graphics.DrawString(logic.DealerHand.Cards[i].ToString(), font, brush, card);
                   
                }
            }
            
            for (int i = 0; i < logic.Player.Hand.Cards.Count; i++)
            {
                brush.Color = Color.White;
                Rectangle card = new Rectangle(PlayerPoint.X + 75 + i * 100, PlayerPoint.Y, CardWidth, CardHeight);
                graphics.FillRectangle(brush, card);
                brush.Color = logic.Player.Hand.Cards[i].CardColor;
                graphics.DrawString(logic.Player.Hand.Cards[i].ToString(), font, brush, card);
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            logic.NewGA();
        }
        
    }
}
