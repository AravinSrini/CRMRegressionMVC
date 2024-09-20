@Sprint92 @95525
Feature: 95525_Insurance Claims - Amend - Binding

Scenario Outline:95525_Verify the Claim Number, Verbiage, Populate Form button on the Submit a Claim Page upon click on Edit button of Amend Status Claim
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the Claims List page
And the claim is in Amend status
When I clicked on the Edit icon of Amend status Claim
Then I will see the claim number displayed to the right of the Submit a Claim page header
And I will be able to see the verbiage Amend a previously submitted motor carrier shortage or damage claim beneath the Submit a Claim page header
And I will not see the Enter DLSW Ref to Start Process field
And I will not able to see Populate Form button
And I will not see the verbiage Or fill out the form below manually

Examples: 
| Username                              | Password                              |
| username-CurrentSprintOperations      | password-CurrentSprintOperations      |
| username-CurrentSprintSales           | password-CurrentSprintSales           |
| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |


Scenario Outline:95525_Verify the Station and Customer fields on the Submit a Claim Page upon click on Edit button of Amend Status Claim
Given I am a user and login into application with valid <UserName> and <Password>,
And I am on the Claims List page
And the claim is in Amend status
When I clicked on the Edit icon of Amend status Claim
Then I will see the fields Station and Customer in the Station and Customer section
And these fields are auto-populated with the details of the original claim,
And I am not able to edit the fields

Examples: 
| UserName                              | Password                              |
| username-CurrentSprintOperations      | password-CurrentSprintOperations      |
| username-CurrentSprintSales           | password-CurrentSprintSales           |
| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |

@Sprint94 @107648
Scenario Outline: 107648 Verify the presence of new field Customer Claim Ref # (alpha-numeric, text, special characters, max length 20) and its binding for the Amend Status Claim
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
And I am on the Claims List page
And I Clicked on the edit icon of <claim> in Amend status
When I arrive on the Submit A Claim page for the <claim> which is in Amend status
Then I will see a new optional field "Customer Claim Ref #" (editable, alpha-numeric, text, special characters, max length 20)
And the previously entered Customer Claim Ref # value will be bound

Examples: 
		| UserType	  | UserName                              | Password                          | claim      |
| claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | 2019000597 |
| Sales           | username-CurrentSprintSales           | password-CurrentSprintSales           | 2019000494 |
| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        | 2019000494 |
| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      | 2019000591 |

@Sprint94 @107648
Scenario Outline: 107648 Verify the save functionality of Customer Claim Ref from Re-Submit a Claim and also verifying the same is pushed to Claims List page
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
And I am on the Claims List page
And I Clicked on the edit icon of <claim> in Amend status
And I am on the Submit A Claim page of a <claim> in Amend status
When I Click Resubmit a Claim button
Then the "value" of Customer Claim Ref field will be saved for the Corresponding <claim>
And the "value" of the Customer Claim Ref will be pushed to the Customer Ref column of the Claims List page for the <claim> numbers <UserType>

Examples: 
| UserType	  | UserName                              | Password                          | claim      |
| claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | 2019000597 |
| Sales           | username-CurrentSprintSales           | password-CurrentSprintSales           | 2019000494 |
| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        | 2019000494 |
| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      | 2019000591 |