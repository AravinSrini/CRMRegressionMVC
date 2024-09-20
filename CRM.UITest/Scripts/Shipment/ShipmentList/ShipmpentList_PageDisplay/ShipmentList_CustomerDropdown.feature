@37596 @Sprint76
Feature: ShipmentList_CustomerDropdown
	

@GUI 
Scenario Outline: Verify the customer display from customer dropdown
	Given I am a sales, sales management, station owner, or operations user <Username>,<Password>
	And I am on the Shipment List page
	When I click in the customer list
	Then the customers will be listed in hierarchy format
	And the customers will be listed alphabetically

Examples:
| Scenario | Username     | Password |
| S1       | crmOperation | Te$t1234 |
| s2       | stationown   | Te$t1234 |
