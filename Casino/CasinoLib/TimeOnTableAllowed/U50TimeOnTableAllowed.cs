namespace CasinoLib.TimeOnTableAllowed
{
    public class U50TimeOnTableAllowed : IPlayerTimeOnTableAllowed
    {
        public int GetMaxHoursAllowed()
        {
            return 8;
        }
    }
}
