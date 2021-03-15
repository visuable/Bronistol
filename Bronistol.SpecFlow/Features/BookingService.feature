Feature: BookingService
	Method for adding a booking entity to the database

@pozitive
Scenario: Adding a booking entity to the database
	Given I want to book a meeting room
	And I have the empty booking entity
	When I added this entity
	Then Entity from database will be equal source entity

Scenario: Removing a booking entity from the database
	Given I want to remove the booking entity from the database
	And I have the empty booking entity
	And I have this entity in the database
	When I will remove this entity
	Then Its Id will not be found in the database

Scenario: Get a booking entity form the database
	Given I want to get the booking entity from the database
	And I have the empty booking entity
	And I have this entity in the database
	When I got this entity
	Then Its will be equal source booking entity