@28901 @Sprint70 
Feature: Review and Submit Shipment (LTL)_Edit Shipping Info - All Users

@Functional
Scenario Outline: Verify Edit functionality of ShipInfo section on Review and Submit Page
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	And I click on Create Shipment button of any carrier displayed 
	And I am on the Review and Submit page
	And I click on Edit buttton of ShipInfo section
	Then I must be navigated to Add Shipment (LTL) page
	And All of the previously entered Shipping Information and Freight Description information should be populated - <originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<classification>,<nmfc>,<quantity>,<weight>,<itemdesc>

Examples: 
| Scenario | Username   | Password | Usertype     | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | classification | nmfc | quantity | weight | itemdesc    |
| S1       | shp.entry  | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | test       | address     | 33126         | Dname           | Desaddress       | 85282              | 50             | 1234 | 1        | 1      | 100         |
| S2       | stationown | Te$t1234 | Internal     | ZZZ - GS Customer Test   | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 55             | 4563 | 6        | 1980   | Item double |
