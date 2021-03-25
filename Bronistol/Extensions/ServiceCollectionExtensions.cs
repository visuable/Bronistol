using System;
using System.Text.Json.Serialization;
using Bronistol.Core.HostedServices.PriorityService;
using Bronistol.Core.Supports;
using Bronistol.Database;
using Bronistol.Database.DbEntities;
using Bronistol.Database.Repositories;
using Bronistol.Options.Validations;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bronistol.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BronistolContext>(x =>
                x.UseNpgsql(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
            return services;
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingSupport, BookingSupport>();
            return services;
        }

        public static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<PriorityService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<BookingEntity>, BookingEntityRepository>();
            return services;
        }

        public static IServiceCollection ConfigureOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<ValidationOptions>(configuration.GetSection(nameof(ValidationOptions)));
            services.Configure<GetReservedTablesCommandValidatorOptions>(
                configuration.GetSection(nameof(GetReservedTablesCommandValidatorOptions)));
            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }

        public static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }

        public static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            return services;
        }
    }
}