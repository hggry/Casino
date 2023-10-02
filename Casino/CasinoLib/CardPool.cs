using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLib
{
    public class CardPool
    {
        public List<Card> Cards { get; set; }

        private int _deckAmound;
        private string[] _suits = { "♣Club♣", "♦Diamond♦", "♥Heart♥", "♠Spade♠" };
        private string[] _faceCards = { "Jack", "Queen", "King"};
        private Random ran = new Random();

        public CardPool(int deckAmound)
        {
            _deckAmound = deckAmound;
            FillCardList();
        }

        private void FillCardList()
        {
            Cards = new List<Card>();

            for (int i = 0; i < _deckAmound; i++)
            {
                foreach (string suit in _suits)
                {
                    for (int j = 2; j <= 10; j++)
                    {
                        Cards.Add(new Card(j.ToString(), suit, j));
                    }

                    foreach (string faceCard in _faceCards)
                    {
                        Cards.Add(new Card(faceCard, suit, 10));
                    }
                    Cards.Add(new Card("Ace", suit, 11));
                }
            }
        }

        public void ShuffleCards()
        {
            List<Card> shuffledCards = new List<Card>();

            for (int i = Cards.Count; i > 0; i--)
            {
                Card c = Cards[ran.Next(0, Cards.Count)];

                Cards.Remove(c);
                shuffledCards.Add(c);
            }

            Cards = shuffledCards;
        }

        public Card PopCard()
        {
            if(Cards.Count <= _deckAmound * 52 / 3)
            {
                FillCardList();
                ShuffleCards();
            }

            Card c = Cards[0];
            Cards.Remove(c);

            return c;
        }

        public void ShowDeck()
        {
            foreach (Card c in Cards)
            {
                Console.WriteLine($"{c.DisplayName} {c.Suit}");
            }
        }
    }
}
