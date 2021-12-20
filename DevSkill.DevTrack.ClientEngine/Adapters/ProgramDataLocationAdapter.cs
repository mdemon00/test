using System;
using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class ProgramDataLocationAdapter : IProgramDataLocationAdapter
    {
        public string Location => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    }
}
