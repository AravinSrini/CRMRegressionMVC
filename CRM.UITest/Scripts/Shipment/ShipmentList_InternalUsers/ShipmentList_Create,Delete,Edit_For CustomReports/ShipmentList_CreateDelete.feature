Feature: ShipmentList_CreateDelete
	
@GUI
Scenario Outline: Verify presence of Delete Report hyperlink when user selected the custom report_all external users
Given I am user and login into application with valid <Username> and <Password> 
And I am a landed on the Shipment List page 
#And I navigate to shipment list <ShipmentList_Header> page
And And I create a customreport <Customreport>
When I Clicked on Show Filter link
 #I should be displayed with Delete Report link
Then I click on Delete Report link
#And I should be displayed with Delete Report modal pop up
#And I click on Cancel button in Delete report modal

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | Customreport |
| s1       | shpinq      | Te$t1234 | Shipment List       | CusRepDel8  |

