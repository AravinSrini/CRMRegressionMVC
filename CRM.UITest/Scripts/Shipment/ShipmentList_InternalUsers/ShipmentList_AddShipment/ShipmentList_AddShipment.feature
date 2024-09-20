Feature: ShipmentList_AddShipment
	
@mytag
Scenario Outline: Verify Add Shipment for ShipInq
Given I am user and login into application with valid <Username> and <Password> 
And I am landed on the Shipment List page 
When I should not be displayed with the Add Shipment Button
#And  I clicked on LTL
Then I should not be landed on the Add Shipment Page 


Examples: 
 | Scenario    | Username     | Password | 
 | s1          | shpinq       | Te$t1234 | 
 #| s2          | shpinqnorts  | Te$t1234 |     

