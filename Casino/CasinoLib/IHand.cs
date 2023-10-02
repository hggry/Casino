using System.Collections.Generic;

namespace CasinoLib
{
    public interface IHand
    {
        List<Card> GetCards();
        void RecieveCard(Card c);
    }
}