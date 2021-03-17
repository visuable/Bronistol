using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

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
