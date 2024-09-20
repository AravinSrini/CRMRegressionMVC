 @Sprint70 @28174
Feature: ShipmentResults_ExportReport_AllUsers

@Functional
Scenario Outline: Compare and verify the displaying excel data with UI for customer users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I enter data in add shipment page  <Usertype>, <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	And I enter <InsuredRate> and click on show insured rate button
	When I click on export button in ltl shipment results page
	Then displaying data in excel should match with UI data for customer users

Examples: 
| Scenario | Username      | Password | UserType | CustomerName | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc | quantity | weight | desc | InsuredRate |
| S1       | Both@test.com | Te$t1234 | External |              | 33126 | test  | add  | 85282 | test  | add  | 50             | nmfc | 1        | 100    | data | 100         |

@Functional
Scenario Outline: Compare and verify the displaying excel data with UI for station users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I enter data in add shipment page  <Usertype>, <CustomerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	And I enter <InsuredRate> and click on show insured rate button
	When I click on export button in ltl shipment results page
	Then displaying data in excel should match with UI data for station users

Examples: 
| Scenario | Username   | Password | Usertype | CustomerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc | quantity | weight | desc | InsuredRate |
| S1       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | test  | add  | 85282 | test  | add  | 50             | nmfc | 1        | 100    | data | 100         |
