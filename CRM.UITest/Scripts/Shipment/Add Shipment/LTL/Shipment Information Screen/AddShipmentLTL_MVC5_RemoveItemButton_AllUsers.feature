@28009 @Sprint69
Feature: AddShipmentLTL_MVC5_RemoveItemButton_AllUsers

@GUI @Functional
Scenario Outline: Verify the Remove Item button functionality for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And  I have selected Customer from the dropdown <Customer_Name>
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I click on Add Additional Item button
And I click on Remove Item button
Then I should not be displayed with additional item added
And I should not be displayed with Remove Item button

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             |
| s1       | crmOperation | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide |

@GUI @Functional
Scenario Outline: Verify the Remove Item button functionality for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I click on Add Additional Item button
And I click on Remove Item button
Then I should not be displayed with additional item added
And I should not be displayed with Remove Item button

Examples: 
| Scenario | Username    | Password | ShipmentList_Header |
| s1       | shpent      | Te$t1234 | Shipment List       |
| s2       | shpentnorts | Te$t1234 | Shipment List       |