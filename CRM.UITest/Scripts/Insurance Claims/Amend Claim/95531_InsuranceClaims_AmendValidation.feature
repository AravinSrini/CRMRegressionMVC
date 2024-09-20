@Sprint93 @95531
Feature: 95531_InsuranceClaims_AmendValidation
	To verify whether "required field(s) missing information will be highlighted in red" when mandatory fields are not entered.
	To verify whether error message "Leaving this page will not update the claim.  Are you sure you want to leave this page?" on clicking button "Back to Claims List" without submitting.
	To verify whether on clicking "yes" user navigated to claim list page, when clicking button "Back to Claims List" without submitting.
	To verify whether on clicking "No" the modal closes, when clicking button "Back to Claims List" without submitting.


Background: Create And Move Claim to amend
	Given I am a CurrentsprintClaimspecialist user
	And I have Navigated to the Claim list page
	And I have successfully created a Claim
	And I have forwarded the claim to Amend status
	

Scenario Outline: Insurance Claims - Amend Validation field highlight
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
	And I have Navigated to the Claim list page
	And I have clicked on the Edit Icon for Claim in Amend Status
	When I click on Resubmit Claim without entering valid details in the Claim Details
	Then Empty mandatory fields in Claim Section should be highlighted in red
	And the control should be focused to the first mandatory empty field


Examples: 
		| UserType        | UserName								 | Password								   |
		| Internal        | username-CurrentSprintOperations         | password-CurrentSprintOperations        |
		| Sales           |	username-CurrentSprintSales			     | password-CurrentSprintSales			   |
		| Claimspecialist | username-CurrentsprintClaimspecialist    | password-CurrentsprintClaimspecialist   |
		| External        | username-CurrentSprintshpentry           | password-CurrentSprintshpentry          |
	

Scenario Outline: Insurance Claims - Amend Edit- Unsaved back to Claim list validation
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
	And I have Navigated to the Claim list page
	And I have clicked on the Edit Icon for Claim in Amend Status
	And I have made changes in the Claim Details section of the page
	When I click on Back to Claims List- Button without saving the entered details
	Then I should get a <Error Message> message
	And it should have two options yes or no
	Examples: 
		| UserType | UserName                         | Password											   | Error Message |
		| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations					   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| Sales           |	username-CurrentSprintSales			     | password-CurrentSprintSales			   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| Claimspecialist | username-CurrentsprintClaimspecialist    | password-CurrentsprintClaimspecialist   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| External        | username-CurrentSprintshpentry           | password-CurrentSprintshpentry          |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
	

Scenario Outline: Insurance Claims - Document Edit- Unsaved back to Claim list validation
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
	And I have Navigated to the Claim list page
	And I have clicked on the Edit Icon for Claim in Amend Status
	And I have made changes in the Document Details section of the page
	When I click on Back to Claims List- Button without saving the entered details
	Then I should get a <Error Message> message
	And it should have two options yes or no
	Examples: 
		| UserType | UserName                         | Password											   | Error Message |
		| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations					   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| Sales           |	username-CurrentSprintSales			     | password-CurrentSprintSales			   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| Claimspecialist | username-CurrentsprintClaimspecialist    | password-CurrentsprintClaimspecialist   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| External        | username-CurrentSprintshpentry           | password-CurrentSprintshpentry          |Leaving this page will not update the claim. Are you sure you want to leave this page?  |

	
Scenario Outline: Insurance Claims - Amend - Unsaved back to Claim list - Yes option validation
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
	And I have Navigated to the Claim list page
	And I have clicked on the Edit Icon for Claim in Amend Status
	And I have made changes in the Claim Details section of the page
	And I click on Back to Claims List- Button without saving the entered details
	And I should get a <Error Message> message
	And it should have two options yes or no
	When I click on the Yes options
	Then I should be navigated back to the Claim List page
	Examples: 
		| UserType        | UserName								 | Password								   |Error Message | 
		| Internal        | username-CurrentSprintOperations         | password-CurrentSprintOperations        |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| Sales           |	username-CurrentSprintSales			     | password-CurrentSprintSales			   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| Claimspecialist | username-CurrentsprintClaimspecialist    | password-CurrentsprintClaimspecialist   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| External        | username-CurrentSprintshpentry           | password-CurrentSprintshpentry          |Leaving this page will not update the claim. Are you sure you want to leave this page? |
	

Scenario Outline: Insurance Claims - Amend - Unsaved back to Claim list - No option validation
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
	And I have Navigated to the Claim list page
	And I have clicked on the Edit Icon for Claim in Amend Status
	And I have made changes in the Claim Details section of the page
	And I click on Back to Claims List- Button without saving the entered details
	And I should get a <Error Message> message
	And it should have two options yes or no
	When I click on the No options
	Then It should stay on the Edit claim page
	
	Examples: 
		| UserType        | UserName								 | Password								   |Error Message |
		| Internal        | username-CurrentSprintOperations         | password-CurrentSprintOperations        |Leaving this page will not update the claim. Are you sure you want to leave this page? |
		| Sales           |	username-CurrentSprintSales			     | password-CurrentSprintSales			   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| Claimspecialist | username-CurrentsprintClaimspecialist    | password-CurrentsprintClaimspecialist   |Leaving this page will not update the claim. Are you sure you want to leave this page?  |
		| External        | username-CurrentSprintshpentry           | password-CurrentSprintshpentry          |Leaving this page will not update the claim. Are you sure you want to leave this page?  |

