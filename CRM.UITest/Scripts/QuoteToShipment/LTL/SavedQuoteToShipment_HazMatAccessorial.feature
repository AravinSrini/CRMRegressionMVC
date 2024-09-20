@NinjaSprint15 @37600
Feature: SavedQuoteToShipment_HazMatAccessorial

@GUI
Scenario Outline: 37600_Verify that the hazardous material is set as Yes and the details section is expanded while converting a saved quote containing Hazmat accessorial to shipment for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I have a quote with Saved Item with Hazmat as accessorial for External user <Item>
	And I am in the Quote Details Section of a LTL non expired quote with Saved Item For External user
	And I click on the Create Shipment button from Quote list
	When I arrive on the LTL Add Shipment page
	Then the Hazardous Materials Yes button will be checked
	And I am unable to edit the Hazardous Materials to No
	And the Hazardous Materials section in the Add Shipment Page is expanded

Examples: 
| Scenario | UserType  | Item  |
| s1       | shipentry | NOHAZ |

@GUI
Scenario Outline: 37600_Verify that the hazardous material is set as Yes and the details section is expanded while converting a saved quote containing Hazmat accessorial to shipment for Inernal User
	Given I am Sales, Sales Management, Operations, or Station Owner user logged in to CRM Application <UserType>
	And I have a quote with Saved Item with Hazmat as accessorial for Internal user <CustomerName> <Item>
	And I am in the Quote Details Section of a LTL non expired quote with Saved Item For Internal user <CustomerName>
	And I click on the Create Shipment button from Quote list
	When I arrive on the LTL Add Shipment page
	Then the Hazardous Materials Yes button will be checked
	And I am unable to edit the Hazardous Materials to No
	And the Hazardous Materials section in the Add Shipment Page is expanded

Examples: 
| Scenario | UserType     | CustomerName             | Item           |
| s1       | stationowner | ZZZ - Czar Customer Test | TEST-HAZARDOUS |