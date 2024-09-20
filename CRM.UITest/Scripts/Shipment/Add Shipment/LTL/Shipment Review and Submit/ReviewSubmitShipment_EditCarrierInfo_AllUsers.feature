@28902 @Sprint70
Feature: ReviewSubmitShipment_EditCarrierInfo_AllUsers

@GUI @Functional
Scenario Outline: Verify the funcitonality of edit carrier info icon in review and submit page for all uers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I enter data in add shipment page  <Usertype>, <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	And I click on create shipment button for any carrier <Usertype>
	When I click on edit icon in carrier info section 
	And I will arrive on the Shipment Results page,
	Then previously displayed carriers will be listed

Examples: 
| Scenario | Username      | Password | Usertype | CustomerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc | quantity | weight | desc |
| S1       | Both@test.com | Te$t1234 | External |                        | 33126 | test  | add  | 85282 | test  | add  | 50             | nmfc | 1        | 100    | data |
| S2       | stationown    | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | test  | add  | 85282 | test  | add  | 50             | nmfc | 1        | 100    | data |
	
