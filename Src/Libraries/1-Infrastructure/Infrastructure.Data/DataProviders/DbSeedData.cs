﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Linq;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Domain.Core.Services;

using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class DbSeedData
    {


        /// <summary>
        /// 
        /// </summary>
        public static void MongoDbSeedData(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<IMongoDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                var _encryptionService = serviceScope.ServiceProvider.GetService<IEncryptionService>();
                var _operators = _dbContext.GetCollection<Operator>();

                if (!_operators.AsQueryable().Any())
                {
                    var user = new Operator(_configuration["SuperUser:DisplayName"],"", _configuration["SuperUser:Email"], _configuration["SuperUser:Email"], _configuration["SuperUser:Password"], _encryptionService);
                    _operators.InsertOne(user);
                }

            }
        }

    }
}
