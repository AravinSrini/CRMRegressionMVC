@Regression @Quote @29501 @Sprint79
Feature: Rate Request - Allow Customer Users access to Sub-Accounts - Customer drop down
	
@Acceptance @GUI
Scenario: 29501_Verify Customer List drop down defaulted to Select and quote list grid
Given I am a shp.inquiry or shp.entry user associated to a primary account that has sub-accounts
When I arrive on Quote List page
Then the grid will be displayed with the message Please select a customer to view Quotes
And the customer drop down will be displayed with Select

@Acceptance @GUI
Scenario: 29501_Verify Customer List drop down options and Submit Rate Request button 
Given I am a shp.inquiry or shp.entry user associated to a primary account that has sub-accounts
When I arrive on Quote List page
Then the Customer drop down list will be displayed with options Select All Customers, primary account and mapped subaccounts
Then the Submit Rate Request button will be hidden

@Acceptance @GUI
Scenario: 29501_Verify Customer List drop down hierarchy and sub accounts in alphabetical order
Given I am a shp.inquiry or shp.entry user associated to a primary account that has sub-accounts
And I am on the Quote List page
When I click on the customer list drop down
Then the customers will be displayd in hierarchy format 
And the sub-accounts will be displayed in alphabetical order