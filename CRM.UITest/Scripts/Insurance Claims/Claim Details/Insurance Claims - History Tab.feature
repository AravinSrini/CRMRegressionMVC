@40456 @Sprint84
Feature: Insurance Claims - History Tab
	
@GUI
Scenario: 40456_Verify the 'Add Comment' button and 'Edit Icon' in history tab of Claim Details page
	Given I am a claims specialist user	
	And I am on ClaimDetails page
	When I click on the History Tab
	Then I will see the button <Add Comment>
	And  I will see an Edit icon displayed next to each Comment

@GUI
Scenario: 40456_Verify the Edit comment functionality when the category of any history entry is 'Status Update'
	Given I am a claims specialist user
	And I am on ClaimDetails page
	And I clicked on the History Tab
	When the Category is <Status update> for any displayed history entry
	Then I should not be able to edit the entry

@GUI @DB Verification
Scenario: 40456_Verify the history when user edited the claim status on claim details page
	Given I am a claims specialist user
	And I am on ClaimDetails page	
	When the claim status is edited
	Then Date/Time field will be updated with new values
	And Updated By field will be updated with new values
	And Category field will be Status update
	And Comment field will be updated with new values

@GUI
Scenario: 40456_Verify the 'Add Comment' button and 'Edit Icon' in history tab of Claim Details page by login with internnal user credentails
	Given I am a sales, sales management, operations, or station owner user
	And I am on ClaimDetailspage
	When I click on the History Tab
	Then I will not be displayed with the button Add Comment
	And  I will not be displayed an Edit icon displayed next to each Comment
