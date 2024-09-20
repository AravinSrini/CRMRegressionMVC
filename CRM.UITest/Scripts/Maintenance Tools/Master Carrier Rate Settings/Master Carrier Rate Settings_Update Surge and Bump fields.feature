@34302 @Sprint73 
Feature: Master Carrier Rate Settings_Update Surge and Bump fields

@Functional @GUI
Scenario Outline: Try to update Bump or Surge values for one carrier and verify if the values entered are saved in database and displayed on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected a customer <CustomerName>
	And I have selected one carriers
	And I have updated any of the following fields <Surge>,<Bump>
	Then The values will be saved and displayed on the Master Carrier Rate Settings page - <CustomerName>,<Bump>,<Surge>

Examples: 
| Scenario | Username    | Password | MasterCarrierPageTitle       | CustomerName             | Bump  | Surge |
| S1       | pricuser    | Te$t1234 | Master Carrier Rate Settings | ZZZ - Czar Customer Test | 21.00 | 2.00  |
| S2       | systemadmin | Te$t1234 | Master Carrier Rate Settings | ZZZ - Czar Customer Test | 1.00  | 7.00  |


@Functional @GUI
Scenario Outline: Try to update Bump or Surge values for two carrier and verify if the values entered are saved in database and displayed on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected a customer <CustomerName>
	And I selected two carriers
	And I update Surge or Bump fields <Surge>,<Bump>
	Then The values entered for Surge or Bump fields will get saved and displayed on the Master Carrier Rate Settings page-<CustomerName>,<Bump>,<Surge>

Examples: 
| Scenario | Username    | Password | MasterCarrierPageTitle       | CustomerName             | Bump  | Surge |
| S1       | pricuser    | Te$t1234 | Master Carrier Rate Settings | ZZZ - Czar Customer Test | 21.00 | 2.00  |
| S2       | systemadmin | Te$t1234 | Master Carrier Rate Settings | ZZZ - Czar Customer Test | 1.00  | 7.00  |


@Functional @GUI
Scenario Outline: Try to update Bump or Surge values for all carriers and verify if the values entered are saved in database and displayed on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected a customer <CustomerName>
	And I have selected all carriers
	And I update Surge or Bump fields <Surge>,<Bump>
	Then The values entered for all the Surge or Bump fields will get saved and displayed on the Master Carrier Rate Settings page-<CustomerName>,<Bump>,<Surge>

Examples: 
| Scenario | Username    | Password | MasterCarrierPageTitle       | CustomerName             | Bump  | Surge |
| S1       | pricuser    | Te$t1234 | Master Carrier Rate Settings | ZZZ - Czar Customer Test | 21.00 | 5.00  |
| S2       | systemadmin | Te$t1234 | Master Carrier Rate Settings | ZZZ - Czar Customer Test | 1.00  | 7.00  |


@Functional @GUI
Scenario Outline: Verify display of Surge and Bump values on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected a customer <CustomerName>
	And I have selected one or more carriers
	Then Surge and Bump values will be displayed on the Master Carrier Rate Settings page - <CustomerName>

Examples: 
| Scenario | Username    | Password | MasterCarrierPageTitle       | CustomerName             |
| S1       | pricuser    | Te$t1234 | Master Carrier Rate Settings | ZZZ - Czar Customer Test |
| S2       | systemadmin | Te$t1234 | Master Carrier Rate Settings | ZZZ - Czar Customer Test | 

