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
        private CardDeck Deck;
        private int DeckNumber = 3;
        public BlackjackLogic()
        {
            NewGame();
        }

        //public static BlackjackLogic getState()
        //{
        //    if (logic == null)
        //    {
        //        logic = new BlackjackLogic();
        //        return logic;
        //    }
        //    return logic;
        //}

        public void NewGame()
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

        public void ReturnHand(List<Card> hand)
        {
            Deck.DiscardHand(hand);
        }



    }
    
}
