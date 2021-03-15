using Bronistol.Database.DbEntities;
using Bronistol.Tests.Contexts;

using System;
using System.Threading.Tasks;

using TechTalk.SpecFlow;

using Xunit;

namespace Bronistol.Specs.Steps
{
    [Binding]
    public class BookingServiceRemoveFeatureSteps
    {
        private readonly BookingServiceContext _bookingServiceContext;
        private BookingEntity _bookingEntity;

        public BookingServiceRemoveFeatureSteps(BookingServiceContext bookingServiceContext)
        {
            _bookingServiceContext = bookingServiceContext;
        }
        [Given(@"I have the empty booking entity in the database")]
        public async Task GivenIHaveTheEmptyBookingEntityInTheDatabase()
        {
            _bookingEntity = new BookingEntity();
            await _bookingServiceContext.BookingService.Add(_bookingEntity);
        }
        
        [When(@"I call the Remove method with any predicate")]
        public async Task WhenICallTheRemoveMethodWithAnyPredicate()
        {
            await _bookingServiceContext.BookingService.Remove(x => x.Id == _bookingEntity.Id);
        }
        
        [Then(@"I will have not the current entity in the database")]
        public async Task ThenIWillHaveNotTheCurrentBookingEntityInTheDatabase()
        {
            var actual  = await _bookingServiceContext.Context.BookingEntities.FindAsync(1);
            Assert.Null(actual);
        }
    }
}
