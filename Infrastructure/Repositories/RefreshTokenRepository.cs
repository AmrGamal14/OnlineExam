using Data.Entities.Identity;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        private readonly DbSet<UserRefreshToken> userRefreshToken;
        #endregion
        #region Constructors
        public RefreshTokenRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            userRefreshToken=dBContext.Set<UserRefreshToken>();
        }
        #endregion
    }
}


