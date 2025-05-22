using System;

namespace IDF.model
{
    public class IntelligenceMessage
    {
        public Terrorist Target { get; set; }

        public string LastKnownLocation { get; set; }

        public DateTime TimeStamp { get; set; }

        public IntelligenceMessage(Terrorist target, string lastKnownLocation, DateTime timeStamp)
        {
            Target = target;
            LastKnownLocation = lastKnownLocation;
            TimeStamp = timeStamp;
        }

        public string GetInfo()
        {
            return $"Intelligence Report:\n" +
                   $"Target: {Target.Name}\n" +
                   $"Location: {LastKnownLocation}\n" +
                   $"Timestamp: {TimeStamp}";
        }
    }
}
