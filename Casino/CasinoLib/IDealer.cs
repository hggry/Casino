namespace CasinoLib
{
    public interface IDealer
    {
        Hand GetHand();
        void Deal(Hand h);
        void Reset();
    }
}
