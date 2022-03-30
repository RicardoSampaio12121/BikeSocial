﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories.Interfaces
{
    public interface ITrainingInvitesRepository : IGenericRepository<TrainingInvites>
    {
        Task<bool> InviteAthletesToTraining(List<TrainingInvites> athletes);
    }
}