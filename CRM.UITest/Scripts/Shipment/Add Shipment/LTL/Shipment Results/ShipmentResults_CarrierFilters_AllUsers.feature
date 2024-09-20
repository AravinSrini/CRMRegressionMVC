@ShipmentResults_CarrierFilters_AllUsers @28162 @Sprint70 
Feature: ShipmentResults_CarrierFilters_AllUsers


@GUI
Scenario Outline: Verify the carrier filter selected by default on shipment result LTL page for All user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then I will see the <Quickest_Service> and <Least_Cost> carrier filter
	And Verified that Quickest Service carrier filter is selected by default

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | Quickest_Service | Least_Cost |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Quickest Service | Least Cost |
| S2       | shp.entry             | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Quickest Service | Least Cost |          


@GUI @Functional
Scenario Outline: Verify the Click functionality of Least Cost carrier filter on shipment result LTL page for All user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then Verify that by selecting the Least cost on Result page will resort to display the carrier options begning with least cost <Usertype>

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |
| S2       | shp.entry             | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |	   


@GUI @Functional 
Scenario Outline: Verify the Click functionality of Quickest Service carrier filter on shipment result LTL page for All user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then Verify that by selecting the Quickest Service on results page will resort to display the carrier options begning with the lowest number of service days and least cost <Usertype>

Examples: 
| Scenario | Username              | Password |Usertype  | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification    | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 30013         | Dname           | Dname2           | 30013              | 55 CLEANING WIPES | 6789-01 | 5        | 100    | CLEANING WIPES |
| S2       | shp.entry             | Te$t1234 |          |                        | Oname      | Oname1      | 30013         | Dname           | Dname2           | 30013              | 55 CLEANING WIPES | 6789-01 | 5        | 100    | CLEANING WIPES |    

