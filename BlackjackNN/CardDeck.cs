using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public class CardDeck
    {
        public List<Card> Deck { get; private set; }
        public List<Card> DiscardPile { get; private set; }
        private String[] CardValues = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private String[] SuitValues = { "H", "D", "C", "S" };
        private static Random random = new Random();

        public CardDeck()
        {
            Deck = new List<Card>(NewDeck());
            
        }

        public List<Card> NewDeck()
        {
            List<Card> d = new List<Card>();
            for (int i = 0; i < SuitValues.Length; i++)
            {
                for (int j = 0; j < CardValues.Length; j++)
                {
                    d.Add(new Card(""+SuitValues[i]+CardValues[j]));

                }
            }
            return d;
        }

        public void AddDeck()
        {
            Deck.AddRange(NewDeck());
        }

        public void ClearDeck()
        {
            Deck.Clear();
        }

        public Card DrawCard()
        {
            Card draw = Deck[0];
            Deck.Remove(Deck[0]);
            return draw;
        }

        public void DiscardHand(List<Card> hand)
        {
            DiscardPile.AddRange(hand);
        }

        public List<Card> DealHand(int size)
        {
            List<Card> hand = new List<Card>();
            if (Deck.Count < size)
            {
                ReShuffle();
            }
            for (int i = 0; i < size; i++)
            {
                hand.Add(DrawCard());
            }
            return hand;
        }


        public void Shuffle() //Fisher-Yates shuffle
        {
            for (int n = Deck.Count - 1; n > 0; --n)
            {
                int k = random.Next(n + 1);
                Card temp = Deck[n];
                Deck[n] = Deck[k];
                Deck[k] = temp;
            }

        }

        public void ReShuffle()
        {
            Deck.AddRange(DiscardPile);
            Shuffle();
        }
    }

    public class Card
    {
        public enum SuitType
        {
            Hearts, Diamonds, Spades, Clubs
        }

        public SuitType Suit { get; private set; }
        public String StringValue { get; set; }
        public int NumValue { get; set; } //Evaluated during game logic init

        public Card(String input)
        {

            switch(input[0])
            {
                case ('H'):
                    Suit = SuitType.Hearts;
                    break;
                case ('D'):
                    Suit = SuitType.Diamonds;
                    break;
                case ('C'):
                    Suit = SuitType.Clubs;
                    break;
                case ('S'):
                    Suit = SuitType.Spades;
                    break;

            }
            String v = input.Substring(1);
            StringValue = v;

        }


        public String toString()
        {
            return StringValue + " of " + Suit;
        }
    }
}
