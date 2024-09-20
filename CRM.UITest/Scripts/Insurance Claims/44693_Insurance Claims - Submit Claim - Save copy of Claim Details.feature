@44693 @Sprint84 
Feature: 44693_Insurance Claims - Submit Claim - Save copy of Claim Details
	

@GUI @Functional @DBVerification
Scenario: 44693_Verify save the copy of Claim details separately in database
	Given I am a CRM user
	When I submit a claim
	Then Save the copy of claim details separately in database

@GUI @Functional @DBVerification 
Scenario: 44693_Verify the updates for existing saved claim and saved copy of claim details in database
	Given I am a claim specialist user
	And I am on the Claim Details page of existing claim
	And I updated the fields on claim Details page
	When I click on Save Claim Details button 
	Then The saved copy of Claim details will not be updated in database   
	And The existing saved claim details will be updated in database

	 
	 
	


	