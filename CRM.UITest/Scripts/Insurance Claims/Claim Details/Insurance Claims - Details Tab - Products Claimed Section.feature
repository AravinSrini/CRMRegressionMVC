@Sprint82 @39562
Feature: Insurance Claims - Details Tab - Products Claimed Section

@GUI
Scenario: 39562 - Verify the presence of columns for the Products Claimed section in the Claim Details Page
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlswclaim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will see the Clm Typ,Art Typ,Qty,Item,Desc
	And I will see Unit wt,Ext Wt with comma when greater than 3 digits, always display 2 decimal places
	And I will see Unit Val,Ext Val in format of 2 decimal places, auto fill $ ,comma when greater than 3 digits
	And I will see Ttl Pcs
	And I will see Ttl Wt,Total Shipment Weight in format of format with comma when greater than 3 digits, always display 2 decimal places
	And I will display with Ttl Val in format of 2 decimal places, auto fill $,comma when greater than 3 digits

@GUI @Functional 
Scenario: 39562 - Verify the total values for the Products Claimed section in the Claim Details Page
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlswclaim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then Ttl Pcs field will display the sum of the Qty of all of the displayed products
    And Ttl Wt field will display the sum of the EXT WGT of all of the displayed products
    And Ttl Val field will display the sum of the EXT VAL  of all of the displayed products

@GUI @Functional 
Scenario: 39562 - Verify the Total Shipment Weight field for the Products Claimed section in the Claim Details Page
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlswclaim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then the Total Shipment Weight field will be defaulted to blank
	
@GUI @Functional 
Scenario: 39562 - Verify calculations of Ext Wt,Ext Val for the Products Claimed section in the Claim Details Page
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlswclaim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then the Ext Wt calculation will be made for each Products Claimed line item:Qty * Unit Wt
	And the Ext Val calculation will be made for each Products Claimed line item:Qty * Unit Val
