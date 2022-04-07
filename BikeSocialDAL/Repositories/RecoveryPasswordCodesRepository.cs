﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialEntities;
using BikeSocialDAL.Repositories.Interfaces;

namespace BikeSocialDAL.Repositories
{
    public class RecoveryPasswordCodesRepository : GenericRepository<PasswordRecoveryCodes>, IRecoveryPasswordCodesRepository
    {
        private readonly DataContext.DataContext _dbContext;

        public RecoveryPasswordCodesRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}
