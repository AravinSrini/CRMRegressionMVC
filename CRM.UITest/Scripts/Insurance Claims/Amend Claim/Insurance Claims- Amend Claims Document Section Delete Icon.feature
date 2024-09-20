@Sprint94 @112015
Feature: Insurance Claims- Amend Claims Document Section Delete Icon

@Functional
Scenario Outline: 112015_Verify elements on the Delete confirmation modal popup on Amend claim page
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Claims List page
	And I am creating claim and Amend it for a <User>	
	And I clicked on the edit icon of a claim in Amend status for a <User>		
	And I will see Display documents originally submitted with delete icon in documents section	
	When I click on Delete Icon of any displayed document
	Then I will see a confirmation popup dialog with text - Are you sure you want to delete this file?
	And I will see Cancel and Delete buttons

	Examples: 
	| Username                              | Password                              | User            |
	| username-CurrentSprintSales           | password-CurrentSprintSales           | Sales           |
	| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        | External        |
	| username-CurrentSprintOperations      | password-CurrentSprintOperations      | Internal        |
	| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | claimspecialist |

@Functional
Scenario Outline: 112015_Verify Cancel button functionality of Delete confirmation modal popup on Amend claim page
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Claims List page
	And I am creating claim and Amend it for a <User>
	And I clicked on the edit icon of a claim in Amend status for a <User>		
	And I will see Display documents originally submitted with delete icon in documents section	
	And I click on Delete Icon of any displayed document
	And I will see a delete confirmation popup
	When I click on Cancel button of the modal popup
	Then the delete popup will close
	And document will not be deleted
		
	Examples: 
	| Username                              | Password                              | User            |
	| username-CurrentSprintSales           | password-CurrentSprintSales           | Sales           |
	| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        | External        |
	| username-CurrentSprintOperations      | password-CurrentSprintOperations      | Internal        |
	| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | claimspecialist |

@Functional
Scenario Outline: 112015_Verify Delete button functionality of Delete confirmation modal popup on Amend claim page
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Claims List page
	And I am creating claim and Amend it for a <User>
	And I clicked on the edit icon of a claim in Amend status for a <User>		
	And I will see Display documents originally submitted with delete icon in documents section	
	And I click on Delete Icon of any displayed document
	And I will see a delete confirmation popup
	When I click on Delete button of the modal popup
	Then the delete popup will close
	And document will be deleted
	And Document type should not be deleted
		
	Examples: 	
	| Username                              | Password                              | User            |
	| username-CurrentSprintSales           | password-CurrentSprintSales           | Sales           |
	| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        | External        |
	| username-CurrentSprintOperations      | password-CurrentSprintOperations      | Internal        |
	| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | claimspecialist |

@Functional
Scenario Outline: 112015_Verify that the user is able to upload a document after deleting the original document on Amend claim page
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Claims List page
	And I am creating claim and Amend it for a <User>
	And I clicked on the edit icon of a claim in Amend status for a <User>		
	And I will see Display documents originally submitted with delete icon in documents section
	And I click on Delete Icon of any displayed document
	And I will see a delete confirmation popup
	When I click on Delete button of the modal popup
	Then Upload Document icon should be active
	And No File Currently uploaded should be displayed
	And User should be able to upload another document	
		
	Examples: 
	| Username                              | Password                              | User            |
	| username-CurrentSprintSales           | password-CurrentSprintSales           | Sales           |
	| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        | External        |
	| username-CurrentSprintOperations      | password-CurrentSprintOperations      | Internal        |
	| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | claimspecialist |