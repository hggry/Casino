using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLib
{
    public class Hand : IHand
    {
        private List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>();
        }

        public void RecieveCard(Card c)
        {
            _cards.Add(c);
        }

        public List<Card> GetCards()
        {
            return _cards;
        }
    }
}
