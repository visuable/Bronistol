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
            using var bronistolContext = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<BronistolContext>();
            while (!stoppingToken.IsCancellationRequested)
            {
                var firstEntity = await bronistolContext.BookingEntities.FirstOrDefaultAsync();
                await Offset(firstEntity);
            }
        }
        private async Task Offset(BookingEntity bookingEntity)
        {
            using var bronistolContext = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<BronistolContext>();
            var nextEntity = await bronistolContext.BookingEntities
                .FirstOrDefaultAsync(x => x.AssignedDate.Date == bookingEntity.AssignedDate.Date);
            if(nextEntity != null && nextEntity.Priority.Priority > bookingEntity.Priority.Priority)
            {
                var priorityEntityElapsedTime = nextEntity.AssignedDate.Date - nextEntity.SubmitDate.Date;
                bookingEntity.AssignedDate.Date = bookingEntity.AssignedDate.Date - priorityEntityElapsedTime;
                await Offset(nextEntity);
            }
            if (nextEntity != null && nextEntity.Priority.Priority < bookingEntity.Priority.Priority)
            {
                var priorityEntityElapsedTime = nextEntity.AssignedDate.Date - nextEntity.SubmitDate.Date;
                bookingEntity.AssignedDate.Date = bookingEntity.AssignedDate.Date + priorityEntityElapsedTime;
                await Offset(nextEntity);
            }
            else
            {
                return;
            }
            bronistolContext.BookingEntities.Update(bookingEntity);
            await bronistolContext.SaveChangesAsync();
        }
    }
}
