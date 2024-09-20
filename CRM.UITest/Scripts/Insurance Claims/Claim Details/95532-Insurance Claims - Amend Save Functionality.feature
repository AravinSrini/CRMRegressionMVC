@95532 @Sprint92
Feature: 95532-Insurance Claims - Amend Save Functionality


Scenario Outline: 01-95532-Verify Resubmition of Amend status claim for external user
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Claims List page
	And I am creating claim and Amend it for a <user>
	And I clicked on the edit icon of a claim in Amend status for a <user>
	And I am on the Submit a Claim page,
	When I completed all required information and click On the Resubmit Claim button
	Then the Submit a Claim page will close
	And the updated data will be saved
	And the claim status will be updated to Submitted
	And an entry will be recorded on the Status/History tab of the Claim Details page for a <user>
	And I will arrive on the claims List page
	And I will not see the edit icon associated to the amended claim.

	Examples: 
	| user            | Username                              | Password                              |
	| claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |
	| Sales           | username-CurrentSprintSales           | password-CurrentSprintSales           |
	| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
	| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      |
	

Scenario: 02-95532-Verify Status/History of Resubmition  Amend status claim for sales user
	Given I am a sales user
	And I am on the Claim Details page of a claim that was Resubmitted
	When I click on the Status/History tab
	Then I will see an entry recording the re-submission and the entry will include the following: Date/Time - Date and time that the claim was resubmitted,Updated By - name of the user that resubmitted the claim,Category - (Status Update),Comment - (Claim was resubmitted)
	And the entry is not editable.


Scenario: 03-95532-Verify Status/History of Resubmition  Amend status claim for claimspecialist user
	Given I am a claimspecialist user
	And I am on the Claim Details page of a claim that was Resubmitted
	When I click on the Status/History tab
	Then I will see an entry recording the re-submission and the entry will include the following: Date/Time - Date and time that the claim was resubmitted,Updated By - name of the user that resubmitted the claim,Category - (Status Update),Comment - (Claim was resubmitted)
	And the entry is not editable.

Scenario Outline: 04-95532-Verify delete doc from resubmit page	
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Claims List page
	And I am creating claim and Amend it for a <user>
	And I clicked on the edit icon of a claim in Amend status for a <user>
	And I am on the Submit a Claim page,
	When I delete a doc from Amend Edit page and click On the Resubmit Claim button
	Then the Submit a Claim page will close
	And Deleted doc should not be available in detail page

Examples: 
	| user            | Username                              | Password                              |
	| claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |
	| Sales           | username-CurrentSprintSales           | password-CurrentSprintSales           |
	| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
	| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      |

Scenario Outline: 05-95532-Verify Updated doctype is binding in claimdetails page	
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Claims List page
	And I am creating claim and Amend it for a <user>
	And I clicked on the edit icon of a claim in Amend status for a <user>
	And I am on the Submit a Claim page,
	When I updated a doctype to new doctype from Amend Edit page and click On the Resubmit Claim button
	Then the Submit a Claim page will close
	And Updated doctype should be Bind in claimdetails page.
	
Examples: 
	| user            | Username                              | Password                              |
	| claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |
	| Sales           | username-CurrentSprintSales           | password-CurrentSprintSales           |
	| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
	| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      |