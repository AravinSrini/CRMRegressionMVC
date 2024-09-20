@Sprint94 @91197
Feature: 91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit Weight

Scenario Outline: 91197-Verify renamed weight to Unit weight for submit claim page
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the Claims List,
And I clicked on the Submit a Claim button,
When I arrive on the Submit a Claim page,
Then the Weight (LBS) field in the Claim Details section will be renamed Unit Weight (LBS).

Examples: 
	| Username                              | Password                              |
	| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |
	| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
	| username-CurrentSprintOperations      | password-CurrentSprintOperations      |

Scenario Outline: 91197-Verify renamed weight to Unit weight for submit claim page with Additonal item
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the Claims List,
And I clicked on the Submit a Claim button,
And I am on the submit a Claim page,
When I click on the Add Another Item button in the Claim Details section,
Then the Weight (LBS) field of the additional item will be renamed Unit Weight (LBS).

Examples: 
	| Username                              | Password                              |
	| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |
	| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
	| username-CurrentSprintOperations      | password-CurrentSprintOperations      |

Scenario Outline: 91197-Verify renamed weight to Unit weight for resubmit claim page
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the Claims List,
And in Show Status Amend box is checked 
And I clicked on Edit button of a claim that is in Amend status for <user>
When I arrive on the Resubmit a Claim page,
Then the Weight (LBS) field in the Claim Details section of resubmit page will be renamed Unit Weight (LBS).


Examples: 
	| user            | Username                              | Password                              |
	| claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |
	| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
	| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      |
	

Scenario Outline: 91197-Verify renamed weight to Unit weight for resubmit claim page with Additonal item
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the Claims List,
And in Show Status Amend box is checked 
And I clicked on Edit button of a claim that is in Amend status for <user>
And I am on the Submit a Claim page,
When I click on the Add Another Item button in the Claim Details section,
Then the Weight (LBS) field of the additional item of resubmit page will be renamed Unit Weight (LBS).


Examples: 
	| user            | Username                              | Password                              |
	| claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |
	| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
	| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      |
