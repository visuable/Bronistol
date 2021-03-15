Feature: BookingServiceGetFeature
	Method for getting the booking entity by any predicate from database

@mytag
Scenario: Get the booking entity from the database
	Given I have the booking entity in the database
	When I call the Get method by id predicate
	Then I will must get the equal booking entity