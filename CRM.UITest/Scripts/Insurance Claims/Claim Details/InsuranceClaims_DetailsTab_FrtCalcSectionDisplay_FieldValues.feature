@Sprint82 @39563
Feature: InsuranceClaims_DetailsTab_FrtCalcSectionDisplay_FieldValues
	
	@GUI
Scenario: Verify the Freight Calculations Fields and Column Header and its field value format
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will see Type,Claimable?,Claimed Freight,Carreier Charges to DLSW,DLSW Charges to Cust,DLSW Ref# Header Column and its field value is formatted
	And I will see Proration % and Total Claimed Freight and its value formatted
	And I will an information icon displayed next to the Proration % field label

	@GUI
	Scenario: Verify the Proration calculated value
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then the Proration value will be calculated as TTL WGT field divided by Total Shipment Weight from Products Claimed section

	@GUI
	Scenario: Verify the message on hover over the Proration information icon
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I hover over the Proration % information icon in the Claim Details page
	Then I will see the message as <The proration % is determined by dividing the Total claimed weight by the Total shipment weight> 

	@GUI
	Scenario: Verify Freight Calculation section grid Row types
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will see Freight Calculation grid rows Original,Return,Replacement

	@GUI
	Scenario: Verify the rows of Claimable Columns are flagged to N and all the field values is left blank for the claim with No Freight description
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked any claim reference hyperlink with No Freight Charge on the Claims List page
	When I arrive on the Claim Details page
	Then I will see Original,Return,Replacement of Claimable Columns are flagged to N in the Freight description section
	And the field value for each row of the Claimed Freight column will be blank
	And the field value for each row of the Carrier Charges to DLSW column will be blank
	And the field value for each row of the DLW Charges to Cust will be blank
	And the field value of the Total Claimed Freight field will be blank
	And the field value of the DLSW Ref# field will be blank

	@GUI
	Scenario: 39563 - Verify the Freight Calculation Original row and it's values for the Claim with Original Freight Charges
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked any Claim reference hyperlink contains Freight Charges with Original Freight Charge
	When I arrive on the Claim Details page
	Then I will see Claimable ? field of the Original row on the Freight Calculations grid will be flagged Y
	And the Claimed Freight field of the Original row of the Freight Calculation grid will display the value entered in the Original Freight Charges/ Value field of the Submit A Claim page
	And the Carrier Charges to DLSW field of the Original row will be blank
	And the DLSW Charges to Cust field of the Original row will be blank
	And the DLSW Ref # field of the Original row on the Freight Calculations grid will display the DLSW Ref # of the claim

	@GUI
	Scenario: 39563 - Verify the Freight Calculation Return row and it's values for the Claim with Return Freight Charges
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked any Claim reference hyperlink contains Freight Charges with Return Freight Charge
	When I arrive on the Claim Details page
	Then I will see Claimable ? field of the Return row on the Freight Calculations grid will be flagged Y
	And the Claimed Freight field of the Return row will be blank
	And the Carrier Charges to DLSW field of the Return row will be blank
	And the DLSW Charges to Cust field of the Return row will be blank
	And the DLSW Ref # field of the Return row will display the DLSW Ref # of the Return shipment from the Submit A Claim form

	@GUI
	Scenario:Verify the Freight Calculation Replacement row and it's values for the Claim with Replacement Freight Charges
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked any Claim reference hyperlink contains Freight Charges with Replacement Freight Charge
	When I arrive on the Claim Details page
	Then I will see Claimable field of the Replacement row on the Freight Calculations grid will be flagged Y
	And the Claimed Freight field of the Replacement row will be blank
	And the Carrier Charges to DLSW field of the Replacement row will be blank
	And the DLSW Charges to Cust field of the Replacement row will be blank
	And the DLSW Ref # field of the Replacement row will display the DLSW Ref # of the Replacement shipment from the Submit A Claim form

	#@GUI
	#Scenario:happy)  Verify Freight Calculation grid Values are red font when all Claimable? types are flagged to Y
	#Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	#And I clicked any Claim reference hyperlink with Freight Charges contains all Claimable? types are flagged to Y
	#When I arrive on the Claim Details page
	#Then I will see Freight Calculation grid values in red font