@39279 @Sprint84
Feature: InsuranceClaims_ClaimForm_FreightChargesUpdate

	@GUI
	Scenario: 39279 Verify the Freight Charges field validations when add freight charges radio button is selected as Yes
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist
	And I am on Submit a Claim page
	When I Select Yes for the <Do you wish to add freight charges?> question
	Then the Original Freight Charges will become active
	And the Return Freight Charges will become active
	And the Replacement Freight Charges will become active
	And the Original Freight Charges option will be auto-selected
	And the Original Freight Charges check box is inactive
	And I am required to enter a value in the Value field of the Original Freight Charges option
	And the Value field will be currency formatted ($xx,xxx.xx)
	And I have the option to select Return Freight Charges
	And I have the option to select Replacement Freight Charges
	

	@GUI
	Scenario Outline: 39279 Verify Return,Replacement Freight Charges field validations when Return,Replacement Freight Charges option has been checked
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist
	And I am on Submit a Claim page
	And I select Yes for the <Do you wish to add freight charges?> question
	When I check the <FreightCharges> option
	Then the <FreightCharges> Value and DLSW Ref # fields become active
	And I am required to enter a value in the Value field of the <FreightCharges>option
	And the <FreightCharges> Value field will be currency formatted ($xx,xxx.xx)
	And I am required to enter a DLSW Ref # for the <FreightCharges>
	Examples: 
	|FreightCharges					  |
	| Return Freight Charges		  |
	| Replacement Freight Charges	  |

	@GUI
	Scenario Outline: 39279 Verify Return,Replacement Freight Charges fields is disabled when the Return,Replacement Freight Charges option is unchecked
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist
	And I am on Submit a Claim page
	And I select Yes for the <Do you wish to add freight charges?> question
	And I check the <FreightCharges> option
	And the <FreightCharges> Value and DLSW Ref # fields become active
	When I uncheck <FreightCharges> option
	Then the <FreightCharges> Value and DLSW Ref # fields becomes disabled
	Examples: 
	| FreightCharges					  |
	| Return Freight Charges			  |
	| Replacement Freight Charges		  |

	@GUI
	Scenario: 39279 Verify the Freight Charges field sections is hidden when the add freight charges radio button is selected as No
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist
	And I am on Submit a Claim page
	When I Select No for the <Do you wish to add freight charges?> question
	Then the Freight Charges field sections will be hidden

