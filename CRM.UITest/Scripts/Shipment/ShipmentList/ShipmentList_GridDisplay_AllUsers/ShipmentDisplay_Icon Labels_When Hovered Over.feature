@34584 @Sprint77 
Feature: ShipmentDisplay_Icon Labels_When Hovered Over

@GUI
Scenario: 34584 - Verify tool tip label when Hovered over More information icon for external user
	Given I am an external user who has access to the application
	And I am on Shipment List page
	And I search for LTL Shipments
	When I mouse hover on More Information icon for LTL shipments
	Then I should be able to view a tool tip labeled More Information.

@GUI
Scenario: 34584 - Verify tool tip label when Hovered over More information icon for internal user
	Given I am an internal user who has access to the application
	And I am on Shipment List page
	And I choose a Customer from the dropdown list
	And I search for LTL Shipments
	When I mouse hover on More Information icon for LTL shipments
	Then I should be able to view a tool tip labeled More Information.

@GUI
Scenario: 34584 - Verify tool tip label when Hovered over Copy Shipment icon for external user
	Given I am an external user who has access to the application
	And I am on Shipment List page
	And I search for LTL Shipments
	When I mouse hover on Copy shipment icon for LTL shipments
	Then I should be able to view a tool tip labeled Copy Shipment.

@GUI
Scenario: 34584 - Verify tool tip label when Hovered over Copy Shipment icon for internal user
	Given I am an internal user who has access to the application
	And I am on Shipment List page
	And I choose a Customer from the dropdown list
	And I search for LTL Shipments
	When I mouse hover on Copy shipment icon for LTL shipments
	Then I should be able to view a tool tip labeled Copy Shipment.

@GUI
Scenario: 34584 - Verify tool tip label when Hovered over Return Shipment icon for external user
	Given I am an external user who has access to the application
	And I am on Shipment List page
	And I search for LTL Shipments
	When I mouse hover on Return shipment icon for LTL shipments
	Then I should be able to view a tool tip labeled Return Shipment.

@GUI
Scenario: 34584 - Verify tool tip label when Hovered over Return Shipment icon for internal user
	Given I am an internal user who has access to the application
	And I am on Shipment List page
	And I choose a Customer from the dropdown list
	And I search for LTL Shipments
	When I mouse hover on Return shipment icon for LTL shipments
	Then I should be able to view a tool tip labeled Return Shipment.