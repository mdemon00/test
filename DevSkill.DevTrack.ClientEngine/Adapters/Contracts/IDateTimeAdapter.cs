using System;

namespace DevSkill.DevTrack.ClientEngine.Adapters.Contracts
{
    public interface IDateTimeAdapter
    {
        DateTime UtcNow { get; }
    }
}