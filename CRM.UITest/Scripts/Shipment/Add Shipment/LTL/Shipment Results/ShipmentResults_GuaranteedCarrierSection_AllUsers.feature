@ShipmentResults_GuaranteedCarrierSection_AllUsers @28161  
Feature: ShipmentResults_GuaranteedCarrierSection_AllUsers 

@GUI 
Scenario Outline: Verify the Guaranteed rates section displayed in Shipment Result LTL page for All User
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then I will see the Guaranteed rates section bottom of the shipment result LTL page

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry             | Te$t1234 | External | ZZZ - Czar Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |
| S2       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |


@GUI 
Scenario Outline: Verify the column are same for Guaranteed and non Guaranteed rate section for All User
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	Then Verified that Guaranteed and non Guaranteed rate section will have the same columns and functionality for <Usertype>


Examples: 
| Scenario | Username              | Password |Usertype  | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry             | Te$t1234 | External | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |
| S2       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |


@GUI 
Scenario Outline: Verify the GUARANTEED RATE below the carrier name in Guaranteed rate section for All User
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then Verify the Guaranteed section have GUARANTEED RATE below the carrier name 

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry             | Te$t1234 | External | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |
| S2       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |



@GUI @Functional @DBVerification
Scenario Outline: Verify the Guaranteed Rate Available button of any displayed carrier for All User
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then I will see a Guaranteed Rate Available button for any offered Guaranteed rate carrier in the Guaranteed carrier section
Examples: 
| Scenario | Username              | Password | Usertype     | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com | Te$t1234 | StationOwner | ZZZ - GS Customer Test | Oname      | Oname1      | 30013         | Dname           | Dname2           | 30013              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |
| S2       | shp.entry             | Te$t1234 | External     | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234    | 5        | 1000   | Itemdesc       |


@GUI @Functional @DBVerification
Scenario Outline: Verify the click functionality of Guaranteed Rate Available button for All User
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	And I click on Guaranteed Rate Available button of any offered Guaranteed rate carrier
	Then The page will focus to the Guaranteed carrier section 

Examples: 
| Scenario | Username              | Password | Usertype     | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com | Te$t1234 | StationOwner | ZZZ - GS Customer Test | Oname      | Oname1      | 30013         | Dname           | Dname2           | 30013              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |
| S2       | shp.entry             | Te$t1234 | External     | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234    | 5        | 1000   | Itemdesc       |



@GUI @Functional 
Scenario Outline: Verify the short column functionality of Guaranteed rate Section for All User
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	And I scroll the page for Guaranteed rate section	
	Then I should be able to sort Carrier Column in ascending and descending order for Guaranteed section
	And I should be able to sort Service days Column in ascending and descending order for Guaranteed section
	And I should be able to sort Distance Column in ascending and descending order for Guaranteed section
	And I should be able to sort EST COST Column in ascending and descending order for Guaranteed section <Usertype>
	And I should be able to sort Rate Column in ascending and descending order for Guaranteed section <Usertype>

Examples: 
| Scenario | Username              | Password | Usertype     | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com | Te$t1234 | StationOwner | ZZZ - GS Customer Test | Oname      | Oname1      | 30013         | Dname           | Dname2           | 30013              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |
| S2       | shp.entry             | Te$t1234 | External     | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234    | 5        | 1000   | Itemdesc       |
