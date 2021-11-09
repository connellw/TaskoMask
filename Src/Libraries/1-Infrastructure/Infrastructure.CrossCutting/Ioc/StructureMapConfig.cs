﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using TaskoMask.Application.Team.Projects.Services;
using TaskoMask.Infrastructure.Data.DbContext;
using TaskoMask.Infrastructure.Data.EventSourcing;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Infrastructure.CrossCutting.Bus;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Common.Base.Queries.Models;
using TaskoMask.Application.Common.Base.Queries.Handlers;
using TaskoMask.Domain.Team.Data;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Domain.Team.Entities;
using TaskoMask.Domain.Workspace.Entities;
using TaskoMask.Application.Core.Commands;

namespace Infrastructure.CrossCutting.Ioc
{

    /// <summary>
    /// 
    /// </summary>
    public static class StructureMapConfig
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider ConfigureIocContainer(this IServiceCollection services, IConfiguration configuration)
        {
            var container = new Container();
            container.Configure(config =>
            {
                //Automatic resolve dependency by default conventions where we have SomeService : ISomeService
                config.Scan(s =>
                {
                    //scan application dll
                    s.AssemblyContainingType<IProjectService>();
                    //scan application.Core dll
                    s.AssemblyContainingType<IInMemoryBus>();
                    //scan Domain dll
                    s.AssemblyContainingType<IProjectRepository>();
                    //scan Domain.Core dll
                    s.AssemblyContainingType<IDomainEvent>();
                    //Scan Infrastructre.Data dll
                    s.AssemblyContainingType<IMongoDbContext>();
                    //Scan Infrastructure.CrossCutting dll
                    s.AssemblyContainingType<InMemoryBus>();
                    s.WithDefaultConventions().OnAddedPluginTypes(c => c.ContainerScoped());
                });

                config.For<IConfiguration>().Use(()=> configuration).Singleton();
                config.For<IEventStore>().Use<RedisEventStore>().ContainerScoped();
              
                #region Generic Query Handlers

                //TODO Handel Generic Command And Queries
                //  config.For(typeof(IRequestHandler<GetCountQuery<Operator>, long>)).Use(typeof(BaseQueryHandlers<Operator>)).ContainerScoped();

                services.AddScoped<IRequestHandler<GetCountQuery<Operator>, long>, BaseQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Member>, long>, BaseQueryHandlers<Member>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Organization>, long>, BaseQueryHandlers<Organization>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Project>, long>, BaseQueryHandlers<Project>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Board>, long>, BaseQueryHandlers<Board>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Task>, long>, BaseQueryHandlers<Task>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Card>, long>, BaseQueryHandlers<Card>>();


                #endregion


            });


            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }
    }
}
