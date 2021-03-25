using Bronistol.Core.HostedServices.PriorityService;
using Bronistol.Core.Supports;
using Bronistol.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bronistol.Core.Extensions
{
    public static class DIExtensions
    {
        public static TService GetServiceFromScope<TService>(this IServiceScopeFactory serviceScopeFactory)
        {
            return serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<TService>();
        }
    }
}