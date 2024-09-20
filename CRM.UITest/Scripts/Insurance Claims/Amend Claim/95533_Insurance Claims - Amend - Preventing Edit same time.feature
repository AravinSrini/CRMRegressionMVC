@Sprint94 @95533
Feature: 95533_Insurance Claims - Amend - Preventing Edit same time

Scenario Outline:95533_Verify the behaviour when two users are editing same time
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the Claims List page
And I clicked on the edit icon of a <claimnumber> in Amend status
And I clicked on the Resubmit Claim button on the Submit a Claim page
When the status of the claim has been changed,
Then I will show a modal popup with a message:The status of this claim has been changed and cannot be amended at this time.Please return to the Claims List.
And I have the option to close the message

Examples: 
| user            | Username                              | Password                              | claimnumber|
| claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | 2019000597 |
| Sales           | username-CurrentSprintSales           | password-CurrentSprintSales           | 2019000494 |
| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        | 2019000494 |
| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      | 2019000591 |

Scenario Outline:95533_Verify the behaviour when close button selected on pop-up modal
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the Claims List page
And I clicked on the edit icon of a <claimnumber> in Amend status
And I clicked on the Resubmit Claim button on the Submit a Claim page
And I am on the Error Notification Pop up
When I click on close button,
Then the Modal pop up will be closed.

Examples: 
| user            | Username                              | Password                              | claimnumber      |
| claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | 2019000597 |
| Sales           | username-CurrentSprintSales           | password-CurrentSprintSales           |  2019000494|
| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |  2019000494|
| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      | 2019000591 |