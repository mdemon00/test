﻿using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IDataSyncService
    {
        Task SendActivityToServer(Activity activity);
    }
}