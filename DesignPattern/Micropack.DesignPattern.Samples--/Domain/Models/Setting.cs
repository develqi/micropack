namespace Micropack.DesignPattern.Domain
{
    public class Setting
    {
        public RoundingMethods RoundingMethod { get; set; }

        public SpecialDaysDurations SpecialDaysDuration { get; set; }

        public int SpecialDaysDurationBackwardDay { get; set; }

        public int SpecialDaysDurationForwardDay { get; set; }
    }
}
