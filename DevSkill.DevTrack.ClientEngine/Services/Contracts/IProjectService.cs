using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IProjectService
    {
        Task AddProjectsAsync(Project project);
        Task<List<Project>> GetProjectsAsync();
    }
}