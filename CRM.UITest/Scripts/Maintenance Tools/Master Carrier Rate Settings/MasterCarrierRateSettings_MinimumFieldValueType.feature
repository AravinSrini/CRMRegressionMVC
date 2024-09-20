@Sprint75 @36835
Feature: MasterCarrierRateSettings_MinimumFieldValueType
	

@GUI
Scenario Outline:36835- Verify Minimum value type is defaulted to percentage
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then the value type for the Minimum field will be defaulted to Percentage

	Examples:
	| Scenario | Username    | Password | CustomerName           |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |
	| s2       | pricuser    | Te$t1234 |ZZZ - GS Customer Test  |

@GUI
Scenario Outline:36835- Verify User don't have option to select another value type from the Minimum field
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then I don't have option to select another value type from the Minimum field

	Examples:
	| Scenario | Username    | Password | CustomerName           |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |
	| s2       | pricuser    | Te$t1234 |ZZZ - GS Customer Test  |