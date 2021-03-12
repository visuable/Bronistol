using System;
using TechTalk.SpecFlow;

namespace Bronistol.Tests
{
    [Binding]
    public class BookingServiceAddSteps
    {
        public BookingServiceAddSteps(BookingServiceContext)
        {

        }
        [Given(@"I want to book a meeting room")]
        public void GivenIWantToBookAMeetingRoom()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have the empty booking entity")]
        public void GivenIHaveTheEmptyBookingEntity()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I added this entity")]
        public void WhenIAddedThisEntity()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Entity from database will be equal source-entity")]
        public void ThenEntityFromDatabaseWillBeEqualSource_Entity()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
