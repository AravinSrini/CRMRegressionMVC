@90798 @Sprint91 @Regression
Feature: 90798 - Edit Shipment - Customer Users - Credit Hold
	
Scenario Outline: 90798_Verify the Edit Shipment button not displayed when a Customer on Credit Hold for the Customer Users
	Given I am a shp.entry or shp.entrynorates user whose <customer> is on Credit Hold
	When I navigated to Shipment List page
	Then I will not be displayed with the Edit button for any eligible LTL shipments

	Examples: 
	| customer       |
	| zzz-webservice |

Scenario Outline: 90798_Verify the Edit Shipment button displayed when a Customer is not on Credit Hold for the Customer Users
	Given I am a shp.entry or shp.entrynorates user whose <customer> is not on Credit Hold
	When I navigated to Shipment List page
	Then I will see the Edit button for any eligible LTL shipments

	Examples: 
	| customer               |
	| ZZZ - GS Customer Test |