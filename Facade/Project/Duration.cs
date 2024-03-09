namespace Facade.Project
{
    [Serializable]
    public class Duration
    {
        public int Hours { get; set; }

        public int Minutes { get; set; }

        public Duration() { } // Needed for JSON searlization

        public Duration(TimeSpan timeSpan)
        {
            Hours = timeSpan.Hours;
            Minutes = timeSpan.Minutes;
        }

        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(Hours, Minutes, 0);
        }
    }
}
