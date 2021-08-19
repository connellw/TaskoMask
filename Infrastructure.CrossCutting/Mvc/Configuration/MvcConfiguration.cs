﻿using Infrastructure.CrossCutting.Ioc;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Mapper;
using TaskoMask.Infrastructure.CrossCutting.Identity;
using TaskoMask.Infrastructure.Data.DataProviders;

namespace TaskoMask.Infrastructure.CrossCutting.Mvc.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static  class MvcConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider MvcConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
         
            services.AddMediatR(typeof(BoardCommand));
            services.AddIdentityConfiguration(configuration);
            services.AddAutoMapperSetup();

            return services.ConfigureIocContainer(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void MvcConfigure(this IApplicationBuilder app, IServiceScopeFactory serviceScopeFactory)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            serviceScopeFactory.InitialMongoDb();
            serviceScopeFactory.MongoDbSeedData();

        }



    }
}
