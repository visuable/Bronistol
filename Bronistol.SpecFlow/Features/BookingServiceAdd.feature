Feature: BookingServiceAdd
	Method for adding a booking entity to the database

@pozitive
Scenario: Add booking entity to the database
	Given I want to book a meeting room
	And I have the empty booking entity
	When I added this entity
	Then Entity from database will be equal source-entity