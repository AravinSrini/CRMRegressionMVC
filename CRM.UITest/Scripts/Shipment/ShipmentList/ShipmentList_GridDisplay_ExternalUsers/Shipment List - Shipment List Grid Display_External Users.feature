@Sprint68 @28253
Feature: Shipment List - Shipment List Grid Display_External Users

@Functional 
Scenario Outline: Compare and Verify displayed Shipment List with API for external users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button 
	When I arrive on Shipment list page
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then Displayed last thirty days shipments should match with API results '<Account>'

Examples:
| Username        | Password | Option | Account                  |
| zzzext@user.com | Te$t1234 | ALL    | ZZZ - Czar Customer Test |