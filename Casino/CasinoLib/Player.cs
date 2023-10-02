using CasinoLib.TimeOnTableAllowed;

namespace CasinoLib
{
    public class Player : Person, IPlayer
    {
        private Hand _hand;
        private int _chips;
        private int _betAmount;
        private bool _doneWithRound;

        public Player(string name, IPlayerTimeOnTableAllowed tota) : base(tota)
        {
            _hand = new Hand();
            _chips = 1000;
            Name = name;
            _betAmount = 0;
        }

        public void Reset()
        {
            _doneWithRound = false;
            _betAmount = 0;
            _hand = new Hand();
        }

        public int GetChips()
        {
            return _chips;
        }

        public void SetChips(int value)
        {
            _chips = value;
        }

        public int GetBetAmount()
        {
            return _betAmount;
        }

        public void SetBetAmount(int value)
        {
            _betAmount = value;
        }

        public bool GetDoneWithRound()
        {
            return _doneWithRound;
        }

        public void SetDoneWithRound(bool value)
        {
            _doneWithRound = value;
        }

        public Hand GetHand()
        {
            return _hand;
        }
    }
}
