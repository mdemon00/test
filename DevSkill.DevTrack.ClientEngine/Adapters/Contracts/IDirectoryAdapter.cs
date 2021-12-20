namespace DevSkill.DevTrack.ClientEngine.Adapters.Contracts
{
    public interface IDirectoryAdapter
    {
        void CreateDirectory(string path);
        bool DoesExists(string path);
        string CombinePath(params string[] paths);
    }
}