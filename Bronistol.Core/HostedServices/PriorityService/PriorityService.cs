using System.Threading;
using System.Threading.Tasks;
using Bronistol.Core.Extensions;
using Bronistol.Database.DbEntities;
using Bronistol.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            while (!stoppingToken.IsCancellationRequested)
            {
                var firstEntity = await bookingEntityRepository.FirstAsync();
                if (firstEntity == null) continue;
                await Offset(firstEntity);
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
            if (nextEntity == null)
            {
                return;
            }

            if (nextEntity.Priority.Priority > currentEntity.Priority.Priority)
            {
                currentEntity.SubmitDate.Date = nextEntity.AssignedDate.Date;
                await bookingEntityRepository.UpdateAsync(currentEntity);
            }
            else if (nextEntity.Priority.Priority < currentEntity.Priority.Priority)
            {
                nextEntity.SubmitDate.Date = currentEntity.AssignedDate.Date;
                await bookingEntityRepository.UpdateAsync(nextEntity);
            }
            else
            {
                return;
            }

            await Offset(nextEntity);
        }
    }
}