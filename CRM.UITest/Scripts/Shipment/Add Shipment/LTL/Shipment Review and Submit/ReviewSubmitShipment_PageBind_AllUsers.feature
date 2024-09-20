@Sprint70 @31430
Feature: ReviewSubmitShipment_PageBind_AllUsers

@Functional
Scenario Outline: Verify required fields in shipping from, shipping to and item section data in review and submit page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I enter data in add shipment page  <Usertype>, <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	When I click on create shipment button for any carrier <Usertype>
	Then entered data in shipment information page should be displayed in review and submit page <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>,<classification>,<nmfc>, <quantity>, <weight>, <desc>

Examples: 
| Scenario | Username      | Password | Usertype | CustomerName           | oZip  | oName       | oAdd    | dZip  | dName       | dAdd     | classification | nmfc | quantity | weight | desc |
| S1       | Both@test.com | Te$t1234 | External |                        | 33126 | test O Name | Ori add | 85282 | test D Name | Dest add | 50             | nmfc | 1        | 100    | data |
| S2       | stationown    | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | test        | add     | 85282 | test        | add      | 50             | nmfc | 1        | 100    | data |

@Functional
Scenario Outline: Verify required fields in shipping from, shipping to and item section data in review and submit page for shipentry no rates user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I enter data in add shipment page  <Usertype>, <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	Then entered data in shipment information page should be displayed in review and submit page <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>,<classification>,<nmfc>, <quantity>, <weight>, <desc>

Examples: 
| Scenario | Username    | Password | Usertype | CustomerName | oZip  | oName       | oAdd    | dZip  | dName       | dAdd     | classification | nmfc | quantity | weight | desc |
| S1       | datanoentry | Te$t1234 | External |              | 33126 | test O Name | Ori add | 85282 | test D Name | Dest add | 50             | nmfc | 1        | 100    | data |

@Functional
Scenario Outline: Verify all the fields in shipping from, shipping to and item section data in review and submit page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I enter data in required fields in add shipment page  <Usertype>, <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	And I pass data in remaining fields <ShipFromName>, <ShipFromPhone>,<ShipFromEmail>, <ShipFromFax>,<ShipToName>, <ShipToPhone>,<ShipToEmail>, <ShipToFax>,<ReadyTime>,<ReadyClose>,<UNNumb>,<CCNNumb>,<Group>,<HClass>,<HConNmame>,<HPhone>,<DefaultSpecialIns>,<InsAmount>,<InsType>
	And I pass data in reference section <Ref1>, <Ref2>, <MoveType>, <LocType>
	And I click on view rates button in add shipment button
	When I click on create shipment button for any carrier <Usertype>
	Then entered optional data should be displayed in review and submit page   <ShipFromName>, <ShipFromPhone>,<ShipFromEmail>, <ShipFromFax>,<ShipToName>, <ShipToPhone>,<ShipToEmail>, <ShipToFax>,<ReadyTime>,<ReadyClose>,<UNNumb>,<CCNNumb>,<Group>,<HClass>,<HConNmame>,<HPhone>,<DefaultSpecialIns>,<InsAmount>,<InsType>
	And I reference data should be displayed in review and submit page <Ref1>, <Ref2>, <MoveType>, <LocType>

Examples: 
| Scenario | Username                   | Password | Usertype | CustomerName | oZip  | oName       | oAdd    | dZip  | dName       | dAdd     | classification | nmfc | quantity | weight | desc | ShipFromName | ShipFromPhone  | ShipFromEmail  | ShipFromFax    | ShipToName  | ShipToPhone    | ShipToEmail  | ShipToFax      | ReadyTime | ReadyClose | UNNumb | CCNNumb | Group | HClass | HConNmame | HPhone         | DefaultSpecialIns | InsAmount | InsType | Ref1 | Ref2 | MoveType | LocType          |
| S1       | Allstateshipentry@user.com | Te$t2345 | External |              | 33126 | test O Name | Ori add | 85282 | test D Name | Dest add | 50             | nmfc | 1        | 100    | data | Test C Name  | (111) 111-1111 | origin@rrd.com | (222) 111-1111 | Test D Name | (333) 111-1111 | dest@rrd.com | (444) 111-1111 | 12:30 AM  | 12:00 PM   | 1111   | 1234567 | II    | 2      | test name | (222) 111-1111 | Testing data      | 1000      | Used    | 123  | 234  | Cust     | 02 – Black Creek |

@Functional
Scenario Outline: Verify carrier info section data in review and submit page for station users
	Given I am a DLS user and Login into application as a Station Owner
	And I enter data in required fields in add shipment page  <Usertype>, <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	Then selected carrier section CarrierName, LiabilityInformation, EstServiceDays>, Distance, EstRevenue, EstCost should be displayed in review and submit page <Usertype>

Examples: 
| Scenario | Username   | Password | Usertype | CustomerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc | quantity | weight | desc |
| S1       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | test  | add  | 85282 | test  | add  | 50             | nmfc | 1        | 100    | data |

@Functional
Scenario Outline: Verify carrier info section data in review and submit page for customer uers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I enter data in add shipment page  <Usertype>, <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	And I click on view rates button in add shipment button
	Then selected carrier section CarrierName, LiabilityInformation, EstServiceDays, Distance, EstCost should be displayed in review and submit page <Usertype>
	
Examples: 
| Scenario | Username      | Password | Usertype | CustomerName | oZip  | oName       | oAdd    | dZip  | dName       | dAdd     | classification | nmfc | quantity | weight | desc |
| S1       | Both@test.com | Te$t1234 | External |              | 33126 | test O Name | Ori add | 85282 | test D Name | Dest add | 50             | nmfc | 1        | 100    | data |


@52699 @Sprint87
Scenario Outline: Verify the Est Cost value of the Shipment on the Review and Submit page matches the Est Cost value of the carrier selected_Quote to Shipment Flow
	Given I am a DLS user and Login into application as a Station Owner
	And I create a Quote <Customer Name>
	When I navigate to Review and Submit page of the Shipment created from the Quote	
	Then Est Cost value for Shipment in the Review And Submit page should match the Est Cost of the Carrier selected

Examples: 
| Customer Name          |
| ZZZ - GS Customer Test |

@52699 @Sprint87
Scenario Outline: Verify the Est Cost value of the Shipment Shipment Rate Results page matches the Est Cost value of the carrier Quote to Shipment Flow	
	Given I am a DLS user and Login into application as a Station Owner
	And I create a Quote <Customer Name>
	When I navigate to the Shipment Rate Results page by creating Shipment from the quote created and 
	Then Est Cost value in the Shipment Rate Results page for Shipment should match the Est Cost of the Carrier selected

Examples: 
| Customer Name          |
| ZZZ - GS Customer Test |