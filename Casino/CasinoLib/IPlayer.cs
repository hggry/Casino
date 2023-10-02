using CasinoLib.TimeOnTableAllowed;

namespace CasinoLib
{
    public interface IPlayer
    {
        int GetChips();
        void SetChips(int value);
        
        int GetBetAmount();
        void SetBetAmount(int value);

        bool GetDoneWithRound();
        void SetDoneWithRound(bool value);

        void Reset();
        Hand GetHand();
    }
}
