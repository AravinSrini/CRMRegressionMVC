@Sprint92 @107791
Feature: 107791_Insurance Claims - Amend Claim Details Section Editable

Scenario Outline: Verify the editable and required fields in Claim Details Section
Given I am a user and login into application with valid <UserName> and <Password>,
And I am on the Claims List page
And I click on the edit icon of a claim in Amend Claim status<UserName>
When I arrive on the Submit a Claim page of Amend claim,
Then the Submit a Claim form will be auto-populated with the data of the claim
And I verify the Articles Insured field is editable
And I verify the Insured Value Amount field is editable and required if Articles Insured All Risk = Yes, currency formatted
And I verify the Claim Type field is editable
And I verify the Articles Type field is editable
And I verify the Item/Model field is editable, alpha-numeric, text, special characters, max length 50
And I verify the Unit Value field is editable and currency formated
And I verify the Quantity field is editable, numeric, whole numbers, greater than 0
And I verify the Weight field is editable, numeric, 2 decimal places <xxx,xxx.xx>
And I verify the Description of Claimed Articles field is editable, alpha-numeric, text, special characters, 500 characters
And I verify Add Another Item hyperlink is active
And I verify the Do you wish to add freight charges field is editable
And I verify the Original Freight Charges option field is editable, displayed when Do you wish to add freight charges = Yes
And I verify the Original Freight Charges Value field is editable, displayed when Do you wish to add freight charges = Yes, currency format $xxx,xxx.xxx
And I verify the Return Freight Charges option field is editable, displayed when Do you wish to add freight charges = Yes
And I verify the Return Freight Charges Value field is editable, displayed when Do you wish to add freight charges = Yes, currency format $xxx,xxx.xx
And I verify the DLSW Ref # field is editable, displayed when Do you wish to add freight charges = Yes, alpha-numeric, max length 20
And I verify the Replacement Freight Charges option field is editable, displayed when Do you wish to add freight charges = Yes
And I verify the Replacement Freight Charges Value field is editable, displayed when Do you wish to add freight charges = Yes, currency format $xxx,xxx.xx
And I verify the DLSW Ref # of Replacement Freight Charges Value field is editable, displayed when Do you wish to add freight charges = Yes, alpha-numeric, max length 20
And I verify the Subtotal All Claim Value field is uneditable


Examples: 
| UserName                              | Password                              |
| username-CurrentSprintOperations      | password-CurrentSprintOperations      |
| username-CurrentSprintSales           | password-CurrentSprintSales           |
| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |

Scenario Outline: Verify the fields displayed in documents section
Given I am a user and login into application with valid <UserName> and <Password>,
And I am on the Claims List page
And I click on the edit icon of a claim in Amend Claim status<UserName>
When I arrive on the Submit a Claim page of Amend claim,
Then I will see Display documents originally submitted with delete icon in documents section
And I will see Add Additional Document button in documents section

Examples: 
| UserName                              | Password                              |
| username-CurrentSprintOperations      | password-CurrentSprintOperations      |
| username-CurrentSprintSales           | password-CurrentSprintSales           |
| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |

Scenario Outline: Verify the fields displayed in Sign Off Section
Given I am a user and login into application with valid <UserName> and <Password>,
And I am on the Claims List page
And I click on the edit icon of a claim in Amend Claim status<UserName>
When I arrive on the Submit a Claim page of Amend claim,
Then I verify Remarks field - uneditable in Sign Off Section
And I will see Resubmit Claim Button in Sign Off Section

Examples: 
| UserName                              | Password                              |
| username-CurrentSprintOperations      | password-CurrentSprintOperations      |
| username-CurrentSprintSales           | password-CurrentSprintSales           |
| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |
| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |

@Functional @112131 @Sprint94
Scenario Outline: 112131_Verify that the user is unable to Re-submit a claim when no document is added in Documents section
	Given I am a user and login into application with valid <UserName> and <Password>,
	And I am on the Claims List page
	And I am creating claim and Amend it for a <User>
    And I clicked on the edit icon of a claim in Amend status for a <User>
	And I did not complete all required fields in the Documents section
	When I click on the Resubmit Claim button,
	Then the required field(s) missing information will be displayed in red,
	And the Submit a Claim page will refocus to the first required field that is missing information	

Examples: 
| UserName                              | Password                              | User            |
| username-CurrentSprintOperations      | password-CurrentSprintOperations      | Internal        |
| username-CurrentSprintSales           | password-CurrentSprintSales           | Sales           |
| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | claimspecialist |  