@Sprint92 @91184

Feature: Insurance Claims (B) - Save Claim Details button not saving various Info Updates

Scenario Outline: 91184_Verify the editing made in DLSW OS&D Actions, Insurance Info, Carrier OS&D Actions, Key Dates sections in Claim Details page is saved after clicking on Save Claim Details 
	Given I am a Claim specialist user
    And I click on the hyperlink of the claim which i have submitted
	And I am on the Claim Details page
	And I have edited the <section>
	And I click on Save Claim Details button on the Claim Details page
	When I clicked on the Back to Claims List button
	Then I will arrive on the Claims List page

Examples: 
| section            |
| DLSWOS&DActions    |
| InsuranceInfo      |
| CarrierOS&DActions |
| KeyDates           |               


Scenario: 91184_Validation for Shipper, Consignee sections in Claim Details page  
	Given I am a Claim specialist user
    And I click on the hyperlink of the claim which i have submitted
	And I am on the Claim Details page
	And I keep all the fields of Shipper, Consignee sections blank
	When I click on Save Claim Details button on the Claim Details page
	Then All the required fields of Shipper, Consignee sections will be highlighted with red color

	