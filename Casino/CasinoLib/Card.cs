using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLib
{
    public class Card
    {
        public string DisplayName { get; set; }
        public string Suit { get; set; }
        public int Number { get; set; }

        public Card(string displayName, string suit, int number)
        {
            DisplayName = displayName;
            Suit = suit;
            Number = number;
        }
    }
}
