@ShipmentStationUsers_EstimateMargin_FieldBinding @32158 @Sprint71  
Feature: ShipmentStationUsers_Estimate Margin field binding

@GUI
Scenario Outline: 32158_Verify the N/A binding for the Est margin field in shipment result page
	Given I am a operations, sales, sales management or station user <Username> <Password>
    And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then I should see the N/A is binding for the Est margin field in shipment result page if Est margin field is not available for carrier
	
Examples: 
| Scenario | Username              | Password | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |



@GUI
Scenario Outline: 32158_Verify the N/A binding for the Est margin field in Review and submit page
	Given I am a operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
    When I click on View rates button in add shipment ltl page	
	And Est margin field is not available for the carrier in Shipment result page
	And I arrive on Review and Submit Shipment LTL page
	Then I should see the N/A is binding for the Est margin field in Review and submit page


Examples: 
| Scenario | Username              | Password | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |







