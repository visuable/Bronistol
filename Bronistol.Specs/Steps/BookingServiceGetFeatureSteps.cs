using Bronistol.Database.DbEntities;
using Bronistol.Tests.Contexts;

using System;
using System.Threading.Tasks;

using TechTalk.SpecFlow;

using Xunit;

namespace Bronistol.Specs.Steps
{
    [Binding]
    public class BookingServiceGetFeatureSteps
    {
        private readonly BookingServiceContext _bookingServiceContext;
        private BookingEntity _bookingEntity;
        private BookingEntity _actual;

        public BookingServiceGetFeatureSteps(BookingServiceContext bookingServiceContext)
        {
            _bookingServiceContext = bookingServiceContext;
        }
        [Given(@"I have the booking entity in the database")]
        public async Task GivenIHaveTheBookingEntityInTheDatabase()
        {
            _bookingEntity = new BookingEntity();
            await _bookingServiceContext.BookingService.Add(_bookingEntity);
        }
        
        [When(@"I call the Get method by id predicate")]
        public async Task WhenICallTheGetMethodByIdPredicate()
        {
            _actual = await _bookingServiceContext.BookingService.Get(x => x.Id == _bookingEntity.Id);
        }
        
        [Then(@"I will must get the equal booking entity")]
        public void ThenIWillMustGetTheEqualBookingEntity()
        {
            Assert.Equal(_bookingEntity, _actual);
        }
    }
}
