using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IWebcamCaptureService
    {
        Task AddWebCaptureAsync(WebcamCapture webcamCapture);
        Task<WebcamCapture> GetWebCaptureAsync(Guid activityId);
    }
}