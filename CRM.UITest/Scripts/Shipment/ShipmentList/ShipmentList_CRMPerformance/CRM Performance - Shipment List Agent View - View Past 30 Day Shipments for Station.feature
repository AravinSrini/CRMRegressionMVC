@NinjaSprint36 @97761 @Regression

Feature: CRM Performance - Shipment List Agent View - View Past 30 Day Shipments for Station


Scenario: 97761 - Verify the grid will display results in 10 seconds or less after receiving data from source
	 
	Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations 
	And I am on the Shipment List page
	When I choose the station "ZZZ - Web Services Test" from the shipment list account drop down
	Then the grid will display results within 10 seconds or less after receiving data from source system

