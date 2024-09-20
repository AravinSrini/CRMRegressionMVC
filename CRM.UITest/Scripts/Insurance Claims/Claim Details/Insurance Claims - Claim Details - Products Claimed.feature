@44612 @Sprint83
Feature: Insurance Claims - Claim Details - Products Claimed
	
@DB
Scenario: 44612_Verify the edits saved for the Products Claimed when user clicked on Save Claim Details
	Given I am a Claims Specialist user
	And I am on Claim Detailspage with valid Products Claimed values
	And I have edited the fields Clm Type,Art Type,Qty, Item #, Desc, Unit Wt,Unit Val of Products Claimed section in Details Tab
	When I click on SaveClaimDetails button
	Then  Products Claimed values should be saved with the updated item values in DB

@DB
Scenario Outline: 44612_Verify the edits saved for the any of Products Claimed fields when user clicked on Save Claim Details
	Given I am a Claims Specialist user
	And I am on Claim Detailspage with valid Products Claimed values
	And I have edited the any <ProductsClaimedfield> in Products Claimed section of Details page
	When I click on SaveClaimDetails button
	Then  <ProductsClaimedfield> should be saved with the updated values in DB

Examples:     
| ProductsClaimedfield  |
| ClmType               |
| ArtType               |
| Item                  |
| Desc                  |
| UnitWt                |
| UnitVal               |
| Quantity              |
| Total Shipment Weight |
