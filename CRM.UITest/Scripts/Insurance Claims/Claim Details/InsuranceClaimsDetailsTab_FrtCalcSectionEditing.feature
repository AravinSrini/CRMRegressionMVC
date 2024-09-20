@Sprint83 @40066
Feature: InsuranceClaimsDetailsTab_FrtCalcSectionEditing
	
	@GUI
	Scenario Outline:40066 Verify Original,Return,Replacement Freight Calculations section is editable when its Corresponding Freight Type is Flagged to Yes
	Given I am Claims Specialist User
	And I on the clicked any dlsw claim reference hyper link on the Claims List page
	And I am on the Claim Details page
	When the Claimable field is Y for any of the Freight<Type>
	Then the Claimed Freight will be editable as for each Freight<Type> as Optional, currency formatted, always display 2 decimal places, always display <$> before the value - $xx,xxx.xx
	And the Carrier Charges to DLSW will be editable for each Freight<Type> as Optional, currency formatted, always display 2 decimal places, always display <$> before the value - $xx,xxx.xx
	And the Charges to Cust will be editable for each Freight<Type> as Optional, currency formatted, always display 2 decimal places, always display <$> before the value - $xx,xxx.xx
	And the DLSW Ref # will be editable for each Freight<Type> as Optional, alpha-numeric, text, max length 20 characters
	Examples: 
	| Type		  |
	| Original    |
	| Return      |
	| Replacement |

	@GUI
	Scenario Outline:40066 Verify Original,Return,Replacement Freight Calculations section is Non-editable when its Corresponding Freight Type is Flagged to No
	Given I am Claims Specialist User
	And I on the clicked any dlsw claim reference hyper link on the Claims List page
	And I am on the Claim Details page
	When the Claimable field is N for any of the FreightTypes<Type>
	Then the Claimed Freight field be Non-editable for each Freight<Type>
	And the Carrier Charges to DLSW field will be Non-editable for each Freight<Type> 
	And the DLSW Charges to Cust field will be Non-editable for each Freight<Type> 
	And the DLSW Ref # field will be Non-editable for each Freight<Type>
	Examples: 
	| Type		  |
	| Original    |
	| Return      |
	| Replacement |



	@GUI
	Scenario Outline:40066 Verify Original,Return,Replacement Freight Calculations section is Non-editable for the Non Claim Specialist Users
	Given I am Non Claims Specialist User
	And I on the clicked any dlsw claim reference hyper link on the Claims List page
	When I am on the Claim Details page
	Then the Claimable Freight Type will be Non-editable for each Freight<Type>
	And the Claimed Freight field be Non-editable for each Freight<Type> 
	And the Carrier Charges to DLSW field will be Non-editable for each Freight<Type>
	And the DLSW Charges to Cust field will be Non-editable for each Freight<Type> 
	And the DLSW Ref # field will be Non-editable for each Freight<Type>
	Examples: 
	| Type		  |
	| Original    |
	| Return      |
	| Replacement |

	
