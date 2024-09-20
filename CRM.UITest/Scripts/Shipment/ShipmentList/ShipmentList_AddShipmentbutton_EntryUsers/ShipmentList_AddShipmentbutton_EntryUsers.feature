@26808 @Sprint69
Feature: ShipmentList_AddShipmentbutton_EntryUsers

@GUI
Scenario Outline: Verify Add Shipment button functionality
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipment list <ShipmentList_Header> page
Then I should be displayed with Add Shipment button
And I click on Add Shipment button
And I should navigate to Add Shipment page

Examples: 
| Scenario | Username    | Password | ShipmentList_Header |
| s1       | shpent      | Te$t1234 | Shipment List       |
| s2       | shpentnorts | Te$t1234 | Shipment List       |
