@NinjaSprint11 @38248

Feature: MasterCarrierRateSettings_EliminateCarrierSpecificPricingUpdates

@Functional @DBVerification
Scenario Outline: 38248_Verify carrier-specific pricing records are not created on updating Surge value
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	And I have selected one or more carriers from Master carrier Rate settings page <CustomerName>
	And I update Surge value <Surge>
	Then the carrier-specific pricing records are not created or updated for the customer

	Examples:
	| Scenario | Username    | Password | CustomerName           | Surge |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test | 25    |
	| s2       | pricuser    | Te$t1234 | ZZZ - GS Customer Test | 25    |

@Functional @DBVerification
Scenario Outline: 38248_Verify carrier-specific pricing records are not created on updating Bump value
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	And I have selected one or more carriers from Master carrier Rate settings page <CustomerName>
	And I update Bump value <Bump>
	Then the carrier-specific pricing records are not created or updated for the customer

	Examples:
	| Scenario | Username    | Password | CustomerName                                       | Bump |
	| s1       | systemadmin | Te$t1234 | AutoTestEliminateCarrierSpPricingUpdateCustLevelGS | 25   |
	| s2       | pricuser    | Te$t1234 | AutoTestEliminateCarrierSpPricingUpdateCustLevelGS | 25   |
	
