using System.Collections.Generic;

namespace DevSkill.DevTrack.ClientEngine.BusinessObjects
{
    public class KeyboardActivity
    {
        public Dictionary<string, int> KeyCounts { get; set; }
        public int TotalHits { get; set; }
    }
}
