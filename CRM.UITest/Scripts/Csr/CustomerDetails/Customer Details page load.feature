@Sprint92 @108730 @Bug
Feature: Customer Details page load

Scenario: Verify if user is able to navigate to Customer details page when user Clicks on any account from Customer Profiles page_ConfigManager
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I am on Customer Profiles page
	When I click on any account from the customer Profiles page
	Then I should be navigated to Customer Details page

Scenario: Verify if user is able to navigate to Customer details page when user Clicks on any account from Customer Profiles page_SystemConfig
	Given I am a user who have access to Account Management module 'username-CurrentsprintSystemconfiguration' , 'password-CurrentsprintSystemconfiguration'
	And I am on Customer Profiles page
	When I click on any account from the customer Profiles page
	Then I should be navigated to Customer Details page

Scenario: Verify if user is able to navigate to Customer details page when user Clicks on any account from Customer Profiles page_PricingConfig
	Given I am a user who have access to Account Management module 'username-CurrentsprintPricingconfig' , 'password-CurrentsprintPricingconfig'
	And I am on Customer Profiles page
	When I click on any account from the customer Profiles page
	Then I should be navigated to Customer Details page

Scenario: Verify if user is able to navigate to Customer details page when user clicks on Account Management module_Shipentry
	Given I am a user who have access to Account Management module 'username-CurrentSprintshpentry' , 'password-CurrentSprintshpentry'
	When I click on Account Management icon
	Then I should be navigated to the Customer Details page 

Scenario: Verify if user is able to navigate to Customer details page when user Clicks on any account from Customer Profiles page_OperationUser
	Given I am a user who have access to Account Management module 'username-CurrentSprintOperations' , 'password-CurrentSprintOperations'
	And I am on Customer Profiles page
	When I click on an account from the Customer Profiles page
	Then I should be navigated to Customer Details page
