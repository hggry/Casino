namespace CasinoLib.TimeOnTableAllowed
{
    public class U30TimeOnTableAllowed : IPlayerTimeOnTableAllowed
    {
        public int GetMaxHoursAllowed()
        {
            return 4;
        }
    }
}
