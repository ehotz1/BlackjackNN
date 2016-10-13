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

        private BlackjackLogic()
        {
            Player = new BJPlayer();
            DealerHand = new BJHand();
            NewGame();
        }

        public static BlackjackLogic GetInstance()
        {
            if (logic == null) return new BlackjackLogic();
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

        public void NewGA(int pop, int gen) 
        {
            GA = new GeneticAlgorithm(); //Change, when saving is enabled
            GA.SetParams(pop, gen);
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
            CanAct = true;
        }

        public void BlackJackCheck() //Immediate Blackjacks are thrown out of NN fitness pool
        {
            if (Player.Hand.HasBlackJack()) EndRound(2);
            if (DealerHand.HasBlackJack()) EndRound(2);
        }

        public void Hit()
        {
            if (!CanAct) return;
            Player.Hand.AddCard(Deck.DrawCard());
            if (Player.Hand.HasBlackJack()) EndRound(0);
            else if (Player.Hand.HasBusted()) EndRound(1);
        }

        public void Stay()
        {
            while (DealerShouldHit()) { DealerHand.AddCard(Deck.DrawCard()); }

            if (DealerHand.HasBlackJack() && !Player.Hand.HasBlackJack()) EndRound(1);
            else if (DealerHand.GetHandValue() > 21) EndRound(0);
            else if (Player.Hand.GetHandValue() >= DealerHand.GetHandValue()) EndRound(0);
            else EndRound(1);
        }

        public bool DealerShouldHit() //Dealer stays on all 17's
        {
            if (DealerHand.GetHandValue() < 17) return true;
            return false;
        }

        public void EndRound(int condition)
        {
            CanAct = false;
            switch (condition) {
                case 0:
                    Console.WriteLine("NN wins");
                    GA.SetNetworkFitness(true);
                    break;
                case 1:
                    Console.WriteLine("NN loses");
                    GA.SetNetworkFitness(false);
                    break;
                case 2:
                    Console.WriteLine("Blackjack: round results discarded");
                    GA.SetNetworkFitness(false);
                    break;
            }
            
        }

        public void DiscardHands()
        {
            ReturnHand(DealerHand);
            ReturnHand(Player.Hand);
            Deck.Shuffle();
        }

    }
    
    
}
