using CasinoLib.TimeOnTableAllowed;

namespace CasinoLib
{
    public class Dealer : Person, IDealer
    {
        private Hand _hand;
        private CardPool _cardPool;

        public Dealer(IDealerTimeOnTableAllowed tota) : base(tota)
        {
            _hand = new Hand();

            _cardPool = new CardPool(4);
            _cardPool.ShuffleCards();
        }

        public void Deal(Hand hand)
        {
            Card card = _cardPool.PopCard();
            hand.RecieveCard(card);
        }

        public void Reset()
        {
            _hand = new Hand();
        }

        public Hand GetHand()
        {
            return _hand;
        }
    }
}
