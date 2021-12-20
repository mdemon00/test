namespace DevSkill.DevTrack.ClientEngine.Adapters.Contracts
{
    public interface IScreenSizeAdapter
    {
        (int width, int height) GetScreenSize();
    }
}
