@NinjaSprint15 @38326
Feature: SavedQuoteToShipment_AutoPopulate Saved Item Details

@Functional
Scenario Outline: 38326_Verify that NMFC, Item Descritpion are auto-populated in the Freight Description section for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I have a quote with Saved Item for External user <Item>
	And I am in the Quote Details Section of a non expired LTL quote with Saved Item For External user
	And I click on the Create Shipment button from Quote list
	When I arrive on the LTL Add Shipment page
	Then NMFC and Item Description fields are auto-populated in the Freight Description section <CustomerName> <Item>
		
Examples: 
| Scenario | UserType  | Username        | CustomerName             | Item  |
| s1       | shipentry | ZZZext@user.com | ZZZ - Czar Customer Test | NOHAZ |

#@Functional
Scenario Outline: 38326_Verify that Hazardous material details are auto-populated in the Hazardous Details of Freight Description section for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I have a quote with Saved Item containing Hazardous material for External user <Item>
	And I am in the Quote Details Section of a non expired LTL quote with Saved Item For External user
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then Hazardous material details are auto-populated in the Hazardous Details of Freight Description section <CustomerName> <Item>

Examples: 
| Scenario | UserType  | Username        | CustomerName             | Item           |
| s1       | shipentry | ZZZext@user.com | ZZZ - Czar Customer Test | TEST-HAZARDOUS | 

##Scenarios for Intenal Users

@Functional
Scenario Outline: 38326_Verify that NMFC, Item Descritpion are auto-populated in the Freight Description section for internal users
	Given I am Sales, Sales Management, Operations, or Station Owner user logged in to CRM Application <UserType>
	And I have a quote with Saved Item for Internal user <CustomerName> <Item>
	And I am in the Quote Details Section of a non expired LTL quote with Saved Item For Internal user <CustomerName>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then NMFC and Item Description fields are auto-populated in the Freight Description section <CustomerName> <Item>

Examples: 
| Scenario | UserType     | Username               | CustomerName             | Item  |
| s1       | stationowner | salesmanager@stage.com | ZZZ - Czar Customer Test | NOHAZ |

@Functional
Scenario Outline: 38326_Verify that Hazardous material details are auto-populated in the Hazardous Details of Freight Description section for internal users
	Given I am Sales, Sales Management, Operations, or Station Owner user logged in to CRM Application <UserType>
	And I have a quote with Saved Item for Internal user <CustomerName> <Item>
	And I am in the Quote Details Section of a non expired LTL quote with Saved Item For Internal user <CustomerName>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then Hazardous material details are auto-populated in the Hazardous Details of Freight Description section <CustomerName> <Item>

Examples: 
| Scenario | UserType     | Username               | CustomerName             | Item           |
| s1       | stationowner | salesmanager@stage.com | ZZZ - Czar Customer Test | TEST-HAZARDOUS |
