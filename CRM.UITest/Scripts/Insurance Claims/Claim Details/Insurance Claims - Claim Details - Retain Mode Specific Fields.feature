@Sprint83 @43568
Feature: Insurance Claims - Claim Details - Retain Mode Specific Fields
	

Scenario: 43568 - Verify if the claimMode is getting saved in DB after modifying
	Given I am a claims specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim from Claim List page
	And  I am on the Details tab of the Claims Details page
	When I change the Claim Mode
	Then the Claim Mode will be updated for the claim
