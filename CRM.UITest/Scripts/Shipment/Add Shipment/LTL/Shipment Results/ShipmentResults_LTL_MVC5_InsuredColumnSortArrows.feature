@ShipmentResultsInsuredColumnSortArrows @31796 @Sprint71 
Feature: ShipmentResults_LTL_MVC5_InsuredColumnSortArrows


@GUI
Scenario Outline: 31796_Verify the sorting for Insured Rate Column in Shipment Result Page
    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	And I must be naviagted to the Shipment Results page
	And I enter the <Insured_value> and click on show Isnured Rate button
	And I should see the Insured Rate column in the List
	Then I should be able to sort Insured Rate column in ascending and descending order

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | Insured_value |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          |
| S2       | zzzext                | Te$t1234 | External |                          | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          |


@GUI
Scenario Outline: 31796_Verify the sorting for Guaranteed Insured Rate Column in Shipment Result Page
    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	And I must be naviagted to the Shipment Results page
	And I enter the <Insured_value> and click on show Isnured Rate button
	And I should see the Insured Rate column in Guaranteed Rate section
	Then I should be able to sort Guaranteed Insured Rate column in ascending and descending order

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | Insured_value |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          |
| S2       | zzzext                | Te$t1234 | External |                          | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          |



