using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IScreenCaptureService
    {
        Task AddScreenCaptureAsync(ScreenCapture screenCapture);
        Task<ScreenCapture> GetScreenCaptureAsync(Guid activityId);
    }
}