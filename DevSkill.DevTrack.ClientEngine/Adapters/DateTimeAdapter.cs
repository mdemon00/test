using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;
using System;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}