@Sprint71 @30557 @DashboardAddShipment(LTL)(MVC5)CustomerUser 
Feature: DashboardAddShipment(LTL)(MVC5)CustomerUser

@GUI @fixed @Regression
Scenario: 30557 - Verify User navigated to Add Shipment(LTL) page
	Given I am Shipment Entry User
	When I have selected LTL service in the create a Shipment section of the dashboard page
	Then I will be navigated to Add Shipment(LTL) page<AddShipmentHeader>

