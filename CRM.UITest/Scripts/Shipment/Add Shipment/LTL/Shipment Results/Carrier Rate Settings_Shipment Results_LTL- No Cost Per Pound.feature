@35642 @Sprint74 

Feature: Carrier Rate Settings_Shipment Results_LTL- No Cost Per Pound


@GUI @Functional
Scenario Outline: Verify the Carrier information section functionality when Carrier does not have Cost per Pound values in Shipment Results page without Shipment value
    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	Then Verify the labels, fields and verbiage change for the associated carrier on the carrier information section on Shipment Results page
Examples:	
| Scenario | Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc               |
| S1       | shp.entry  | Te$t1234 |          | ZZZ - GS Customer Test | TestOrigin | TestOAddr1  | 33126         | DestName        | TestDAddr1       | 85282              | 50             | 123  | 5        | 1000   | Cost per pound testing |
| S2       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | TestOrigin | TestOAddr1  | 33126         | DestName        | TestDAddr1       | 85282              | 50             | 123  | 5        | 1000   | Cost per pound testing |

@GUI @Functional
Scenario Outline: Verify the Carrier information section functionality when Carrier does not have Cost per Pound values in Shipment Results page with Shipment value
    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down
	When I click on View rates button in add shipment ltl page
	Then Verify the labels, fields and verbiage change for the associated carrier on the carrier information section on Shipment Results page
Examples:	
| Scenario | Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc               | InsuredValue | InsuredType |
| S1       | shp.entry  | Te$t1234 |          | ZZZ - GS Customer Test | TestOrigin | TestOAddr1  | 33126         | DestName        | TestDAddr1       | 85282              | 50             | 123  | 5        | 1000   | Cost per pound testing |   234        |   New       |
| S2       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | TestOrigin | TestOAddr1  | 33126         | DestName        | TestDAddr1       | 85282              | 50             | 123  | 5        | 1000   | Cost per pound testing |  234         |   New       |



@GUI @Functional
Scenario Outline: Verify the Carrier information section functionality when Carrier does not have Cost per Pound values in Review and Submit page for standard rates
    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	And I select any carrier which is associated with Carrier Rate Settings and click on create shipment button <Usertype>
	Then Verify the labels, fields and verbiage change for the associated carrier on the carrier information section on Review and Submit page
Examples:	
| Scenario | Username | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc               |
| S1       | shp.entry| Te$t1234 |          | ZZZ - GS Customer Test | TestOrigin | TestOAddr1  | 33126         | DestName        | TestDAddr1       | 85282              | 50             | 123  | 5        | 1000   | Cost per pound testing |

@GUI @Functional
Scenario Outline: Verify the Carrier information section functionality when Carrier does not have Cost per Pound values in Review and Submit page for insured rates
    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down
	When I click on View rates button in add shipment ltl page
	And I select any carrier which is associated with Carrier Rate Settings and click on create Insured shipment button <Usertype>
	Then Verify the labels, fields and verbiage change for the associated carrier on the carrier information section on Review and Submit page
Examples:	
| Scenario | Username  | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc               | InsuredValue | InsuredType |
| S1       | shp.entry | Te$t1234 |          | ZZZ - GS Customer Test | TestOrigin | TestOAddr1  | 33126         | DestName        | TestDAddr1       | 85282              | 50             | 123  | 5        | 1000   | Cost per pound testing | 100          | New         |  




