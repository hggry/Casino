namespace CasinoLib.TimeOnTableAllowed
{
    public class ExpertTimeOnTableAllowed : IDealerTimeOnTableAllowed
    {
        public int GetMaxHoursAllowed()
        {
            return 8;
        }
    }
}
