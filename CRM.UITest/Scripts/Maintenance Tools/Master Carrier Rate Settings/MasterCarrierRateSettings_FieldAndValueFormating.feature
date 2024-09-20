@NinjaSprint10 @36799
Feature: MasterCarrierRateSettings_FieldAndValueFormatting

@GUI
Scenario Outline: 36799_Verify Surge value type is defaulted to percentage with 2 decimal places in the Grid on selection of customer
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then the value type for the Surge field in the grid will be defaulted to Percentage with 2 decimal places

	Examples:
	| Scenario | Username    | Password | CustomerName           |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |
	| s2       | pricuser    | Te$t1234 |ZZZ - GS Customer Test  |
	
@GUI
Scenario Outline: 36799_Verify Bump value type is defaulted to percentage with 2 decimal places in the Grid on selection of customer
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then the value type for the Bump field in the grid will be defaulted to Percentage with 2 decimal places

	Examples:
	| Scenario | Username    | Password | CustomerName           |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |
	| s2       | pricuser    | Te$t1234 |ZZZ - GS Customer Test  |

@GUI
Scenario Outline: 36799_Verify Gainshare value type is defaulted to percentage with 2 decimal places in the Grid on selection of customer
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then the value type for the Gainshare field in the grid will be defaulted to Percentage with 2 decimal places

	Examples:
	| Scenario | Username    | Password | CustomerName           |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |
	| s2       | pricuser    | Te$t1234 |ZZZ - GS Customer Test  |

@GUI
Scenario Outline: 36799_Verify Minimum value type is defaulted to percentage with 2 decimal places in the Grid on selection of customer
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then the value type for the Minimum field in the grid will be defaulted to Percentage with 2 decimal places

	Examples:
	| Scenario | Username    | Password | CustomerName           |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |
	| s2       | pricuser    | Te$t1234 |ZZZ - GS Customer Test  |

@GUI
Scenario Outline: 36799_Verify Master Accessorial Charge value type is defaulted to percentage with 2 decimal places in the Grid on selection of customer
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then the value type for the Master Accessorial Charge field in the grid will be defaulted to Percentage with 2 decimal places

	Examples:
	| Scenario | Username    | Password | CustomerName           |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |
	| s2       | pricuser    | Te$t1234 |ZZZ - GS Customer Test  |

@GUI
Scenario Outline: 36799_Verify Min Threshold value type is defaulted to dollar with 2 decimal places in the Grid on selection of customer
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then the value for the Min Threshold field in the grid will be defaulted to dollar with 2 decimal places

	Examples:
	| Scenario | Username    | Password | CustomerName           |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |
	| s2       | pricuser    | Te$t1234 |ZZZ - GS Customer Test  |

@GUI
Scenario Outline: 36799_Verify Min Amount value type is defaulted to Dollar with 2 decimal places in the Grid on selection of customer
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then the value type for the Min Amount field in the grid will be defaulted to dollar with 2 decimal places

	Examples:
	| Scenario | Username    | Password | CustomerName           |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |
	| s2       | pricuser    | Te$t1234 |ZZZ - GS Customer Test  |

