using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN.Blackjack
{
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
            Value = GetLowValue();
        }

        public int GetHighValue() //Evaluates for Aces
        {
            if (AceFlag && Value < 12) return Value + 10;
            else return Value;
        }

        public List<Card> ClearHand()
        {
            List<Card> tList = new List<Card>(Cards);
            Cards.Clear();
            return tList;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
            GetLowValue();
        }

        public void SetHand(List<Card> hand)
        {
            Cards = hand;
            AceFlag = false;
            GetLowValue();
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

        public int GetLowValue()
        {
            Value = 0;
            foreach (Card c in Cards)
            {
                if (c.NumValue == 1) AceFlag = true;
                Value += c.NumValue;
            }

            return Value;
        }

        public override string ToString()
        {
            string output = "";
            foreach (Card c in Cards)
            {
                output += c.ToString();
            }
            return output;
        }
    }
}
