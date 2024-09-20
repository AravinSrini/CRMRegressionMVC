@33977 @Sprint74 
Feature: CRM Invoicing - Shipment List Page
	
@GUI
Scenario Outline: 33977_Verify Customer Invoice option for the Delivered Shipment of Mg
	Given I am a shp.entry, shp.inquiry, operations, sales, sales management, or station owner user <userName> <password>
	When I click on the Shipment Icon
	And I arrive on shipment list page with Customer Invoice access
	Then I must be displaying with view Customer Invoice option for Delivered status of Mg Shipments

Examples: 
| Scenario | userName     | password |
| s1       | zzzext       | Te$t1234 |
| s2       | crmoperation | Te$t1234 |

@GUI @Functional
Scenario Outline: 33977_Verify when user mouse hover on the Customer Invoice option
	Given I am a shp.entry, shp.inquiry, operations, sales, sales management, or station owner user <userName> <password>
	When I click on the Shipment Icon
	And I arrive on shipment list page with Customer Invoice access
	And I hover over the Customer Invoice option for the Delivered shipment
	Then the name of Customer Invoice option will display

Examples: 
| Scenario | userName     | password |
| s1       | zzzext       | Te$t1234 |
| s2       | crmoperation | Te$t1234 |

@GUI @Functional
Scenario Outline: 33977_Verify Customer Invoice option Click functionality
	Given I am a shp.entry, shp.inquiry, operations, sales, sales management, or station owner user <userName> <password>
	When I click on the Shipment Icon
	And I arrive on shipment list page with Customer Invoice access
	And I click on Customer Invoice for the Delivered shipment
	Then New tab will open for the selected customer Invoice  

Examples: 
| Scenario | userName     | password |
| s1       | zzzext       | Te$t1234 |
| s2       | crmoperation | Te$t1234 |
