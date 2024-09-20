@36833 @NinjaSprint10
 
Feature: MasterCarrierRateSettings_GainshareField

@GUI
Scenario Outline: 36833_MasterCarrierRateSettings_Verify_Option_To_Update_Gainshare_Percentage
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	Then I will have the option to enter a Gainshare percentage value
	And Value type label will be %
	And To the right of the Gainshare percentage value field will be a button labeled Gainshare %
	
	Examples: 
	| scenario | Username    | Password | CustomerName   |
	| s1       | systemadmin | Te$t1234 | MasterCRSPTest |

@GUI @Functional
Scenario Outline: 36833_MasterCarrierRateSettings_Verify_Entered_Gainshare_Percentage_Is_Updated_In_Grid
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	And I have selected one or more carriers
	And I have entered a gainshare value in the Gainshare percentage value field <gainshareVal>
	When I click on the Gainshare % button
	Then The values will be saved<CustomerName>
	And The grid will update gainshare to display the updated values for Customers <gainshareVal> ,<CustomerName>
	
	Examples: 
	| scenario | Username    | Password | CustomerName   | gainshareVal |
	| s1       | systemadmin | Te$t1234 | MasterCRSPTest | 50.00        |

@GUI @Functional
Scenario Outline: 36833_MasterCarrierRateSettings_Verify_Entering_Gainshare_Percentage_More_Than_100
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected any Customer from Master carrier Rate settings page<CustomerName>
	And I have selected one or more carriers
	And I have entered a gainshare value in the Gainshare percentage value field <gainshareVal>
	When I click the Gainshare % button to save the values
	Then The Gainshare field of the selected carrier(s) will be formatted as percentage <gainshareVal>
	And Each value will have 2 decimal places
	And The maximum value will be 100.00
	And % is displayed after the numerical value.
	
	Examples:
	| scenario | Username    | Password | CustomerName   | gainshareVal |
	| s1       | systemadmin | Te$t1234 | MasterCRSPTest | 99           |

