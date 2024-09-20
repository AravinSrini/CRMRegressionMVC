@27968 @Sprint69 
Feature: AddShipmentLTL_MVC5_DefaultItem_AllUsers

@GUI @Functional @DBVerification
Scenario Outline: Verify the Freight description section when saved item has been designated as default item for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name>
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
Then Classification, NMFC, Quantity, Quantity Type, Weight, Weight Type, Dimensions, Dimensions Type, Hazardous materials should be autopopulated if the account has the default items in DB <Customer_Name>
Then all the autopopulated fields will remain editable in Freight description section

Examples: 
| scenario | Username     | Password | ShipmentList_Header | Customer_Name          |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts          |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - GS Customer Test |
| s3       | stationowner | Te$t1234 | Shipment List       | Dunkin Donuts          |

@GUI @Functional @DBVerification
Scenario Outline: Verify the Freight description section when saved item has been designated as default item for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
Then Classification, NMFC, Quantity, Quantity Type, Weight, Weight Type, Dimensions, Dimensions Type, Hazardous materials should be autopopulated if the account has the default items in DB <Customer_Name>
Then all the autopopulated fields will remain editable in Freight description section

Examples: 
| scenario | Username     | Password | ShipmentList_Header | Customer_Name |
| s1       | shpentry     | Te$t1234 | Shipment List       | Dunkin Donuts |
| s2       | Entyrnorates | Te$t1234 | Shipment List       | Dunkin Donuts |

