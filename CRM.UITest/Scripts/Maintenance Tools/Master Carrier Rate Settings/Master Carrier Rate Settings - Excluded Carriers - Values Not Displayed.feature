@36834 @Sprint75

Feature: Master Carrier Rate Settings - Excluded Carriers - Values Not Displayed
	
	@Functionality @Gui 
	Scenario Outline:36834-Verify the value<None> for Bump,Surge,Gainshare,Minimum,Min Threshold,Min Amount,Master Accessorial Charge,Accessorial fields for the excluded carrieres value in gird
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	And  I must be navigated to <MasterCarrierRateSettings> Page
	And  I have selected a customer<Customer_Name> has one or more excluded carriers from gainshare pricing
    Then Verfiy Bump,Surge,Gainshare,Minimum,Min Threshold,Min Amount,Master Accessorial Charge,Accessorial fields <Customer_Name>

Examples: 
| Scenario | Username    | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | Customer_Name            |
| s1       | SystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | ZZZ - Czar Customer Test |
|s2        | pricuser       | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | ZZZ - Czar Customer Test  |

@Functionality @Gui 
	Scenario Outline:36834-Verify value for Bump,Surge,Gainshare,Minimum,Min Threshold,Min Amount,Master Accessorial Charge,Accessorial fields for the not- excluded carrieres value in gird
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	And  I must be navigated to <MasterCarrierRateSettings> Page
	And  I have selected a customer<Customer_Name> has no excluded carriers from gainshare pricing
    Then Verfiy Bump,Surge,Gainshare,Minimum,Min Threshold,Min Amount,Master Accessorial Charge,Accessorial fields <Customer_Name>

Examples: 
| Scenario | Username    | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | Customer_Name              |
| s1       | SystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | Liberty Pittsburgh Systems |
|s2        | pricuser       | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | Liberty Pittsburgh Systems  |

