using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackNN
{
    public class BJPlayer
    {
        public BJHand Hand { get; private set; }
        public BJPlayer()
        {
            Hand = new BJHand();
        }

        public void DealHand(List<Card> h)
        {
            Hand.SetHand(h);
        }

        
    }
}
