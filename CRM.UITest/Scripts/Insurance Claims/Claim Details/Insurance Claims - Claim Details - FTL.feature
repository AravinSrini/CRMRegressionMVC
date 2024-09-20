@Sprint83 @44614 
Feature: Insurance Claims - Claim Details - FTL

@Functional
Scenario: 44614 - Verify the save functionality of Save Claim Details button when user edits all FTL fields
	Given I am a Claims Specialist user
	And I am on the Claim Details page.
	And I have made edit to the following FTL specific fields : Carrier MC #, Seal Intact, Seal #, Vehicle #
	When I click on Save Claim Details button
	Then The edits should get saved.

@Functional
Scenario Outline: 44614 - Verify the save fuctionality of Save Claim Details button when user edits any of the FTL fields
	Given I am a Claims Specialist user
	And I am on the Claim Details page.
	And I have made an edit to any of the following FTL specific fields : Carrier MC #, Seal Intact, Seal #, Vehicle # - <FTLField>
	When I click on Save Claim Details button
	Then The edits should get saved - <FTLField>

Examples: 
| FTLField   |
| CarrierMC# |
| SealIntact |
| Seal#      |
| Vehicle#   |
