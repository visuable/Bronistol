using System;
using System.Threading;
using System.Threading.Tasks;
using Bronistol.Core.Extensions;
using Bronistol.Core.Options;
using Bronistol.Database.DbEntities;
using Bronistol.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Bronistol.Core.HostedServices.PriorityService
{
    public class PriorityService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PriorityService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var bookingEntityRepository = _serviceScopeFactory.GetServiceFromScope<IRepository<BookingEntity>>();
            var options = _serviceScopeFactory.GetServiceFromScope<IOptions<AutoClearOptions>>();
            while (!stoppingToken.IsCancellationRequested)
            {
                var firstEntity = await bookingEntityRepository.FirstAsync();
                if (firstEntity == null) continue;
                await Offset(firstEntity);
                await ClearOverdue(bookingEntityRepository, options);
            }
        }

        private async Task Offset(BookingEntity currentEntity)
        {
            var bookingEntityRepository = _serviceScopeFactory.GetServiceFromScope<IRepository<BookingEntity>>();
            var nextEntity = await bookingEntityRepository
                .GetAsync(x =>
                    x.SubmitDate.Date.Year == currentEntity.SubmitDate.Date.Year
                    && x.SubmitDate.Date.Month == currentEntity.SubmitDate.Date.Month
                    && x.SubmitDate.Date.Day == currentEntity.SubmitDate.Date.Day
                    && x.SubmitDate.Date.Hour == currentEntity.SubmitDate.Date.Hour
                    && x.SubmitDate.Date.Minute == currentEntity.SubmitDate.Date.Minute && x.Id != currentEntity.Id);
            if (nextEntity == null) return;

            if (nextEntity.Priority.Priority > currentEntity.Priority.Priority)
            {
                var offset = currentEntity.AssignedDate.Date - currentEntity.SubmitDate.Date;
                currentEntity.SubmitDate.Date = nextEntity.AssignedDate.Date;
                currentEntity.AssignedDate.Date = currentEntity.SubmitDate.Date + offset;
                await bookingEntityRepository.UpdateAsync(nextEntity);
            }
            else if (nextEntity.Priority.Priority < currentEntity.Priority.Priority)
            {
                var offset = nextEntity.AssignedDate.Date - nextEntity.SubmitDate.Date;
                nextEntity.SubmitDate.Date = currentEntity.AssignedDate.Date;
                nextEntity.AssignedDate.Date = nextEntity.SubmitDate.Date + offset;
                await bookingEntityRepository.UpdateAsync(nextEntity);
            }
            else
            {

                return;
            }
            await Offset(nextEntity);
        }
        private async Task ClearOverdue(IRepository<BookingEntity> repository, IOptions<AutoClearOptions> options)
        {
            var dateTimeNow = DateTime.UtcNow;
            var bookingEntities = await repository
                .WhereAsync(x => x.AssignedDate.Date
                    .AddDays(options.Value.DaysLater) < dateTimeNow);
            foreach (var bookingEntity in bookingEntities)
            {
                await repository.RemoveAsync(x => x.Id == bookingEntity.Id);
            }
        }
    }
}