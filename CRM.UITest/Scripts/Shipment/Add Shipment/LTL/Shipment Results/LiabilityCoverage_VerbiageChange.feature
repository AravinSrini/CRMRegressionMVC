@ShipmentResultsLiabilityCoverageVerbiageChange @29167 @Sprint70 

Feature: LiabilityCoverage_VerbiageChange_ShipmentsResults
	
@GUI 
Scenario Outline: Verify the new Verbiage above the Cost per Pound New and Used fields in the Shipment Results for the standard rates
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then the new verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier 
	
Examples: 
| Scenario | Username     | Password | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry    | Te$t1234 |          |                          | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |
| S2       | stationown   | Te$t1234 | Internal | ZZZ - GS Customer Test   | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |


@GUI
Scenario Outline: Verify the new Verbiage above Cost per Pound New and Used fields in the Shipment Results for the Guaranteed rates
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then the new verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier for Guaranteed Rates
	
Examples: 
| Scenario | Username     | Password | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry    | Te$t1234 |          |                          | test       | test        | 33126         | fdgf            | Dngtr ame        | 85282              | 50             | 1234 | 6        | 1000   | item     |
| S2       | stationown   | Te$t1234 | Internal | ZZZ - GS Customer Test   | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |

@GUI @Regression @Functional
Scenario Outline:29167-VerifyVerbiage above Cost per Pound New and Used fields in the Shipment Results when Insured type is New for shipentry user
	Given I login as Ship entry user
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down
	When I click on View rates button in add shipment ltl page	
	Then the new verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier 
	
Examples: 
| Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | InsuredValue | InsuredType |
| ShipEntry  |          |          |                        | test       | test        | 33126         | fdgf            | Dngtr ame        | 85282              | 50             | 1234 | 6        | 1000   | item     |  1000        |  New        |
@GUI @Regression @Functional
Scenario Outline: VerifyVerbiage above Cost per Pound New and Used fields in the Shipment Results when Insured type is New for stationowner
	Given I  login into application as StationOwner
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down
	When I click on View rates button in add shipment ltl page	
	Then the new verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier 
	
Examples: 
| Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | InsuredValue | InsuredType |
| stationown|  | Internal | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |  12345       |   New       |

@GUI @Regression @Functional
Scenario Outline:Verbiage Cost per Pound New and Used fields in the Shipment Results when Insured type is Used for stationowner
	Given I  login into application as StationOwner
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down
	When I click on View rates button in add shipment ltl page
	Then the new verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier 
	
Examples: 
| Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | InsuredValue | InsuredType |
| stationown |  | Internal | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc |  267         |   Used      |
@GUI @Regression @Functional
Scenario Outline:29167-Verbiage Cost per Pound New and Used fields in the Shipment Results when Insured type is Used shipentry user
	Given I login as Ship entry user
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down
	When I click on View rates button in add shipment ltl page
	Then the new verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier 
	
Examples: 
| Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | InsuredValue | InsuredType |
| shp.entry  |  |          |                        | test       | test        | 33126         | fdgf            | Dngtr ame        | 85282              | 50             | 1234 | 6        | 1000   | item     |  1999        |  Used       |
