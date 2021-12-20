using System.IO;
using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class DirectoryAdapter : IDirectoryAdapter
    {
        public void CreateDirectory(string path)
        {
             Directory.CreateDirectory(path);
        }

        public bool DoesExists(string path)
        {
            return Directory.Exists(path);
        }

        public string CombinePath(params string[] paths)
        {
            return Path.Combine(paths);
        }
    }
}
