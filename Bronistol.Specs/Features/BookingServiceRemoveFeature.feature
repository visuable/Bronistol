Feature: BookingServiceRemoveFeature
	Method for the remove bokking entities in the databse

@pozitive
Scenario: Removing the booking entity 
	Given I have the empty booking entity in the database
	When I call the Remove method with any predicate
	Then I will have not the current entity in the database