@97764 @NinjaSprint36
Feature: Edit Shipment Details Performance - Benchmarking Page Load Times

Scenario: 97764 Clicking edit shipment page loads and fields pre-populated
	Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
	And I navigate to the Shipment List page
	And I search for the shipment shipref using the shipment reference lookup
	When I go to edit a shipment
	Then the existing information for that shipment will be displayed on the page