using System;
using System.Threading.Tasks;
using Bronistol.Database;
using Bronistol.Database.DbEntities;
using Bronistol.Tests.Contexts;
using TechTalk.SpecFlow;
using Xunit;

namespace Bronistol.Specs.Steps
{
    [Binding]
    public class BookingServiceAddFeatureSteps
    {
        private readonly BookingServiceContext _bookingServiceContext;
        private BookingEntity _bookingEntity;

        public BookingServiceAddFeatureSteps(BookingServiceContext bookingServiceContext)
        {
            _bookingServiceContext = bookingServiceContext;
        }

        [Given(@"I want to book a meeting room")]
        public void GivenIWantToBookAMeetingRoom()
        {
        }
        
        [Given(@"I have the empty booking entity")]
        public void GivenIHaveTheEmptyBookingEntity()
        {
            _bookingEntity = new BookingEntity();
        }
        
        [When(@"I added this entity")]
        public async Task WhenIAddedThisEntity()
        {
            await _bookingServiceContext.BookingService.Add(_bookingEntity);
        }
        
        [Then(@"Entity from database will be equal source entity")]
        public async Task ThenEntityFromDatabaseWillBeEqualSourceEntity()
        {
            var actualEntity = await _bookingServiceContext.Context.BookingEntities.FindAsync(_bookingEntity.Id);
            Assert.Equal(_bookingEntity.Id, actualEntity.Id);
        }
    }
}
