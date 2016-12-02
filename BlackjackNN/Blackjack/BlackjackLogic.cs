using BlackjackNN.Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public class BlackjackLogic //Handles game logic and acts as dealer
    {
        private static BlackjackLogic logic;
        public bool CanAct { get; private set; }
        private CardDeck Deck;
        private int DeckNumber = 3;
        public BJHand DealerHand { get; private set; }
        public BJPlayer Player { get; private set; }

        public GeneticAlgorithm GA;
        public RoundReplay round_replay;

        private BlackjackLogic()
        {
            Player = new BJPlayer();
            DealerHand = new BJHand();
            round_replay = new RoundReplay();
            NewGame();
        }
        public string CardCounts()
        {
            return "Deck: " + Deck.Deck.Count + " Discard: " + Deck.DiscardPile.Count;
        }

        public static BlackjackLogic GetInstance()
        {
            if (logic == null)
            {
                logic = new BlackjackLogic();
                return logic;
            }
            else return logic;
        }

        private void NewGame()
        {
            Deck = new CardDeck();
            for (int i = 0; i < DeckNumber; i++) //Add predetermined number of decks into total stack
            {
                Deck.AddDeck();
            }
            Deck.Shuffle();
            foreach (Card c in Deck.Deck) //Assign number values to each card
            {
                if (c.StringValue == "A")
                {
                    c.NumValue = 1;
                }
                else if (c.StringValue == "J" || c.StringValue == "Q" || c.StringValue == "K")
                {
                    c.NumValue = 10;
                } else
                {
                    c.NumValue = Int32.Parse(c.StringValue);
                }
            }
        }

        public void NewGA() 
        {
            GA = new GeneticAlgorithm();
            
        }

        public List<Card> DealHand()
        {
            List<Card> hand = new List<Card>();
            hand.Add(Deck.DrawCard());
            hand.Add(Deck.DrawCard());
            return hand;
        }

        public void ReturnHand(BJHand hand)
        {
            Deck.DiscardHand(hand.ClearHand());
            
        }

        public void DiscardHands()
        {
            ReturnHand(DealerHand);
            ReturnHand(Player.Hand);
        }

        public void PlayRound()
        {
            DiscardHands();
            DealerHand.SetHand(DealHand());
            Player.DealHand(DealHand());
            round_replay.ClearActions();
            CanAct = true;
        }

        public void BlackJackCheck()
        {
            if (Player.Hand.HasBlackJack()) EndRound(true);
            if (DealerHand.HasBlackJack()) EndRound(false);
        }

        public void Hit()
        {
            if (!CanAct) return;
            round_replay.PushAction(1, Player.Hand.GetHighValue(), DealerHand.Cards[1].NumValue);
            Player.Hand.AddCard(Deck.DrawCard());
            if (Player.Hand.HasBlackJack()) EndRound(true);
            else if (Player.Hand.HasBusted()) EndRound(false);
        }

        public void Stay()
        {
            round_replay.PushAction(0, Player.Hand.GetHighValue(), DealerHand.Cards[1].NumValue);
            while (DealerShouldHit()) { DealerHand.AddCard(Deck.DrawCard()); }

            if (DealerHand.HasBlackJack() && !Player.Hand.HasBlackJack()) EndRound(false);
            else if (DealerHand.GetHighValue() > 21) EndRound(true);
            else if (Player.Hand.GetHighValue() >= DealerHand.GetHighValue()) EndRound(true);
            else EndRound(false);
        }

        public bool DealerShouldHit() //Dealer stays on all 17's
        {
            if (DealerHand.GetHighValue() < 17) return true;
            return false;
        }

        public void EndRound(bool win)
        {
            CanAct = false;
            round_replay.PushAction(2, Player.Hand.GetHighValue(), DealerHand.GetHighValue());
            round_replay.SetWin(win);
        }

        

    }
    
    public class RoundReplay
    {
        private List<int[]> actions;
        public bool win { get; private set; }
        public RoundReplay()
        {
            actions = new List<int[]>();
            win = false;
        }

        public void PushAction(int action, int player, int dealer)
        {
            actions.Add(new int[] { action, player, dealer });
        }

        public void SetWin(bool w)
        {
            win = w;
        }

        public void ClearActions()
        {
            actions.Clear();
            win = false;
        }

        public string PrintReplay()
        {
            if (actions.Count == 0) return "No replay available";
            string s = "";
            for (int i = 0; i < actions.Count - 1; i++)
            {
                s += "Player: " + actions[i][1] + "; Dealer: " + actions[i][2];
                s += (actions[i][0] == 1) ? "; Hit \n" : "; Stay \n";
            }
            s+= "Final Results: Player: " + actions[actions.Count-1][1] + "; Dealer: " + actions[actions.Count - 1][2];
            s += (win) ? "; Player wins." : "; Dealer wins.";
            return s;
        }

        public int[] GetRoundResults()
        {
            return new int[] { Convert.ToInt32(win), actions[actions.Count - 1][1], actions[actions.Count - 1][2] };
        }
    }
}
