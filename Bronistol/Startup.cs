using System;
using System.Text.Json.Serialization;
using AutoMapper;
using Bronistol.Core.HostedServices.PriorityService;
using Bronistol.Core.Supports;
using Bronistol.Database;
using Bronistol.Database.DbEntities;
using Bronistol.Database.Repositories;
using Bronistol.Extensions;
using Bronistol.Options;
using Bronistol.Profiles;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bronistol
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScopedServices()
                .AddHostedServices()
                .AddRepositories()
                .ConfigureAutoMapper()
                .ConfigureDbContext(Configuration)
                .ConfigureControllers()
                .ConfigureMediatR()
                .ConfigureOptions(Configuration)
                .ConfigureSwagger()
                .ConfigureValidators();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });
        }
    }
}