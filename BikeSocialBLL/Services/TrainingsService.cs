using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using BikeSocialBLL.Extensions;


namespace BikeSocialBLL.Services
{
    public class TrainingsService : ITrainingsService
    {
        private readonly ITrainingsRepository _repository;

        public TrainingsService(ITrainingsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(CreateTrainingDto training)
        {
            if (await _repository.Add(training.AsTraining()) != null)
                return true;

            return false;
        }
    }
}
