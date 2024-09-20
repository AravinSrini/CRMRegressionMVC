@44610 @Sprint83 @Regression
Feature: Insurance Claims - Claim Details - Shipper
	
@GUI @DB
Scenario: 44610_Verify the edits saved for the Shipper when user clicked on Save Claim Details
	Given I am a Claims Specialist user
	And I am on Claim Detailspage
	And I have updated Name, Address, City, State, Zip, Country in the Shipper Section
	And I have updated Date Ack to Claimant, Date Filed in the DLSW OS&D Actions Section
	And I have updated Program,Amount,Company in the Insurance Info Section
	When I click on Save Claim Details button
	Then updated values should be saved in DB

	@GUI @DB
Scenario Outline: 44610_Verify the edits saved for the any field from Shipper when user clicked on Save Claim Details
	Given I am a Claims Specialist user
	And I am on Claim Detailspage
	And I have updated any <shippersectionfield> in the Shipper Section
	When I click on Save Claim Details button
	Then updated <shippersectionfield> values should be saved in DB

	Examples: 
	| shippersectionfield |
	| Name                |
	| Address             |
	| City                |
	| State               |
	| Zip                 |
	| Country             |
	| DateAck             |
	| Date Filed          |
	| Amount              |

	
@91189
Scenario: 91189_Verify the Date Ack To Claimant saved in DB for the claim
	Given I am a claim specialist user
	And I am on the Details Tab of Claim Details page
	And I selected a date in the Date Ack To Claimant field
	When I click on the Save Claim Details button
	Then the date will be saved to the claim
	| Amount              |

@108612 @Sprint92
Scenario:108612_Verify the state/prov field value in claim details screen
Given I am a sales, sales management, operations, station owner, or claim specialist user
When I am on the Claim Details page of existing claim submitted2019000158
Then I verify the State/Prov field in Shipper Information section
And I verify state field value in DB data for claim number2019000158

