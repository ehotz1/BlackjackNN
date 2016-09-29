using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public class BlackjackLogic //Handles game logic and acts as dealer
    {
        //private static BlackjackLogic logic;
        public bool GameRunning { get; private set; }
        private CardDeck Deck;
        private int DeckNumber = 3;
        public BJHand DealerHand { get; private set; }
        public BJPlayer Player { get; private set; }
        public BlackjackLogic()
        {
            Player = new BJPlayer();
            DealerHand = new BJHand();
            NewGame();
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

        public List<Card> DealHand()
        {
            List<Card> hand = new List<Card>();
            hand.Add(Deck.DrawCard());
            hand.Add(Deck.DrawCard());
            return hand;
        }

        public void ReturnHand(BJHand hand)
        {
            Deck.DiscardHand(hand.ReturnHand());
        }


        public void PlayRound()
        {
            DiscardHands();
            DealerHand.SetHand(DealHand());
            Player.DealHand(DealHand());
            GameRunning = true;
        }

        public void BlackJackCheck() //Players always win in case of a tie
        {
            if (Player.Hand.HasBlackJack()) EndRound(true);
            if (DealerHand.HasBlackJack()) EndRound(false);
        }

        public void Hit()
        {
            Player.Hand.AddCard(Deck.DrawCard());
            if (Player.Hand.HasBlackJack()) EndRound(true);
            else if (Player.Hand.HasBusted()) EndRound(false);
        }

        public void Stay()
        {
            while (DealerShouldHit()) { DealerHand.AddCard(Deck.DrawCard()); }

            if (DealerHand.HasBlackJack() && !Player.Hand.HasBlackJack()) EndRound(false);
            else if (DealerHand.GetHandValue() > 21) EndRound(true);
            else if (Player.Hand.GetHandValue() >= DealerHand.GetHandValue()) EndRound(true);
            else EndRound(false);
        }

        public bool DealerShouldHit() //Dealer stays on all 17's
        {
            if (DealerHand.GetHandValue() < 17) return true;
            return false;
        }

        public void EndRound(bool win)
        {
            String results = "Dealer: " + DealerHand.GetHandValue() + ". You: " + Player.Hand.GetHandValue();
            results += (win) ? ". You win!" : ". You lose!";
            Console.WriteLine(results);
            GameRunning = false;
        }

        public void DiscardHands()
        {
            ReturnHand(DealerHand);
            ReturnHand(Player.Hand);
            Deck.Shuffle();
        }

    }
    
    public class BJHand
    {
        public List<Card> Cards { get; private set; }
        public int Value { get; private set; }
        public bool AceFlag { get; private set; }
        public BJHand()
        {
            Cards = new List<Card>();
            Value = 0;
            AceFlag = false;
        }

        public BJHand(List<Card> h)
        {
            Cards = h;
            AceFlag = false;
            Value = CalculateValue();
        }

        public int GetHandValue() //Evaluates for Aces
        {
            if (AceFlag && Value < 12) return Value + 10;
            else return Value;
        }

        public List<Card> ReturnHand()
        {
            List<Card> tList = Cards;
            Cards.Clear();
            return tList;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
            CalculateValue();
        }

        public void SetHand(List<Card> hand)
        {
            Cards = hand;
            AceFlag = false;
            CalculateValue();
        }

        public bool HasBlackJack()
        {
            if (Value == 21 || (AceFlag && Value == 11)) return true;
            return false;
        }

        public bool HasBusted()
        {
            return (Value < 22) ? false : true;
        }

        public int CalculateValue()
        {
            Value = 0;
            foreach (Card c in Cards)
            {
                if (c.NumValue == 1) AceFlag = true;
                Value += c.NumValue;
            }
            
            return Value;
        }
        
    }
}
