@Sprint69 @27400 
Feature: ShipmentList_ Add Shipment (LTL) page._StationUsers

@Functional 
Scenario Outline: Test to verify the Add Shipment button when the custsomer type is MG
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type MG customer <Account> from the customer dropdown in shipment list
	Then I should be displayed with Add Shipment option

 Examples: 
| Scenario | Username              | Password | Account                   | 
| 1        | stationowner@test.com | Te$t1234 | Prakash MG                |
| 2        | crmOperation@user.com | Te$t1234 | Prakash MG                |
| 3        | saleTest              | Te$t1234 | GMS Company               |
| 4        | crmsalesusr           | Te$t1234 | ZZZ Sandbox DLS Worldwide | 


@Functional 
Scenario Outline: Test to verify the Add Shipment button when the custsomer type is Both
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type both customer <Account> from the customer dropdown in shipment list
	Then I should be displayed with Add Shipment option
	

 Examples: 
| Scenario | Username              | Password | Account                  | 
| 1        | stationowner@test.com | Te$t1234 |prakash BOTH              |
| 2        | crmOperation@user.com | Te$t1234 |prakash BOTH              |
| 3        | saleTest              | Te$t1234 |GMS Company               |


@Functional 
Scenario Outline: Test to verify the Add Shipment button when the custsomer type is csa
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type csa customer <Account> from the customer dropdown in shipment list
	Then I should not be displayed with Add Shipment option
	

 Examples: 
| Scenario | Username              | Password | Account                   | 
| 1        | stationowner@test.com | Te$t1234 | Prakash CSA               |
| 2        | crmOperation@user.com | Te$t1234 | Prakash CSA               |
| 3        | saleTest              | Te$t1234 | Bob                       |



@Functional 
Scenario Outline: Test to verify the Add Shipment button functionality when the custsomer type is MG
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type MG customer <Account> from the customer dropdown in shipment list
	And I click on the add Shipment Button
	Then I should be displayed with LTL tile
	

 Examples: 
| Scenario | Username              | Password | Account                   | 
| 1        | stationowner@test.com | Te$t1234 | ZZZ - GS Customer Test    |
| 2        | crmOperation@user.com | Te$t1234 | Dunkin Donuts             |
| 3        | saleTest              | Te$t1234 | GMS Company               |
| 4        | crmsalesusr           | Te$t1234 | ZZZ Sandbox DLS Worldwide | 


@Functional 
Scenario Outline: Test to verify the Add Shipment button functionality when the custsomer type is Both
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type both customer <Account> from the customer dropdown in shipment list
    And I click on the add Shipment Button
	Then I should be displayed with LTL tile
	
 Examples: 
| Scenario | Username              | Password | Account                  | 
| 1        | stationowner@test.com | Te$t1234 |prakash BOTH              |
| 2        | crmOperation@user.com | Te$t1234 |prakash BOTH              |
| 3        | saleTest              | Te$t1234 |GMS Company               |


@Functional 
Scenario Outline: Test to verify the LTL tile on the Add Shipment landing page click functionality when the custsomer type is MG
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type MG customer <Account> from the customer dropdown in shipment list
	And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	Then I should navigate to Add Shipment (LTL) page
	
 Examples: 
| Scenario | Username              | Password | Account                   | 
| 1        | stationowner@test.com | Te$t1234 | ZZZ - GS Customer Test    |
| 2        | crmOperation@user.com | Te$t1234 | Dunkin Donuts             |
| 3        | saleTest              | Te$t1234 | GMS Company               |
| 4        | crmsalesusr           | Te$t1234 | ZZZ Sandbox DLS Worldwide | 



@Functional 
Scenario Outline: Test to verify the LTL tile on the Add Shipment landing page click functionality  when the custsomer type is Both
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type both customer <Account> from the customer dropdown in shipment list
    And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	Then I should navigate to Add Shipment (LTL) page
	
 Examples: 
| Scenario | Username              | Password | Account                  | 
| 1        | stationowner@test.com | Te$t1234 |prakash BOTH              |
| 2        | crmOperation@user.com | Te$t1234 |prakash BOTH              |
| 3        | saleTest              | Te$t1234 |GMS Company               |
