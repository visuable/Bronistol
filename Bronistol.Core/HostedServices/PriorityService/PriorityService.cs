using Bronistol.Database;

using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Bronistol.Database.DbEntities;
using Microsoft.Extensions.DependencyInjection;
using Bronistol.Database.Repositories;
using Bronistol.Core.Extensions;

namespace Bronistol.Core.HostedServices.PriorityService
{
    public class PriorityService : BackgroundService
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public PriorityService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var bookingEntityRepository = _serviceScopeFactory.GetServiceFromScope<IRepository<BookingEntity>>();
            while (!stoppingToken.IsCancellationRequested)
            {
                var firstEntity = await bookingEntityRepository.FirstAsync();
                if (firstEntity == null) continue;
                await Offset(firstEntity);
            }
        }
        private async Task Offset(BookingEntity currentEntity)
        {
            using var bookingEntityRepository = _serviceScopeFactory.GetServiceFromScope<IRepository<BookingEntity>>();
            var nextEntity = await bookingEntityRepository
                .GetAsync(x => x.SubmitDate.Date.EqualWithoutSeconds(currentEntity.SubmitDate.Date));
            if (nextEntity == null) return;
            else if (nextEntity.Priority.Priority > currentEntity.Priority.Priority)
            {
                currentEntity.SubmitDate.Date = nextEntity.AssignedDate.Date;
                await bookingEntityRepository.UpdateAsync(currentEntity);
            }
            else if (nextEntity.Priority.Priority < currentEntity.Priority.Priority)
            {
                nextEntity.SubmitDate.Date = currentEntity.AssignedDate.Date;
                await bookingEntityRepository.UpdateAsync(nextEntity);
            }
            await Offset(nextEntity);
        }
    }
}
