@38018 @Sprint76 
Feature: MasterCarrierRateSettings_Format_IndividualAccessorialField

@GUI
Scenario Outline: Verify the currency format for Individual Accessorial field
    Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	When I have selected Customer from Master carrier Rate settings page <Customer_Name>
	And Customer has one or more <Individual_Accessorial> set 
	And Individual Accessorial have <Numeric> value
	Then The value displayed will be in <dollor_sign> currency format
	And The value will be preceded by the <dollor_sign>
	And Each value will have two <decimal_places>

	Examples:
	| Scenario | Username    | Password | Customer_Name          | Individual_Accessorial | Numeric | dollor_sign | decimal_places |
	| s1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test | Appointment            | 50      | $           | .00            |
	| s2       | pricuser    | Te$t1234 | ZZZ - GS Customer Test | Appointment            | 50      | $           | .00            |

