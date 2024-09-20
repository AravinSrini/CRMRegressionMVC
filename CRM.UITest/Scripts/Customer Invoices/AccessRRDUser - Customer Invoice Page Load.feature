@41352 @NinjaSprint17
Feature: AccessRRDUser - Customer Invoice Page Load

@Functional
Scenario: 41352_Verify_That the Customer Invoice grid will no longer auto-populate for AccessRRD User
	Given I am an Access RRD user logged in to CRM Application
	When I am on the Customer Invoices list page
	Then the Customer Invoice grid will no longer auto-populate

@GUI 
Scenario: 41352_Verify_That the Customer Invoice page has options to select stations, customer accounts and Display Invoices button for AccessRRD User
	Given I am an Access RRD user logged in to CRM Application
	When I am on the Customer Invoices list page
	Then I will be presented with an option to select Stations that I am associated to
	And I will be presented with an option to select Customer Accounts I am associated to
	And I will see a Display Invoices button
	And the Display Invoices button is inactive

@Functional
Scenario: 41352_Verify_Stations dropdown functionality in the Customer Invoice page for AccessRRD User
	Given I am an Access RRD user logged in to CRM Application
	And I am on the Customer Invoices list page
	When I click in the Stations dropdown for accessRRD User
	Then I will see a list of stations associated
	And I have the option to select multiple stations associated
	And I have the option to search for a station for RRD AccessUser
	And I am required to select one or more stations

@Functional
Scenario: 41352_Verify_Customer accounts dropdown functionality in the Customer Invoice page for AccessRRD User
	Given I am an Access RRD user logged in to CRM Application
	And I am on the Customer Invoices list page
	And I have selected one or more Stations from the Station list
	When I click in the Customer Accounts field
	Then I will see the selected station names displayed in ascending order
	And the accounts for each station will be displayed in hierarchical format
	And the accounts will be displayed in alphabetical order within the hierarchy format
	And I am unable to select a station displayed in the Account list for AccessRRDUser
	And I have the option to select one or more accounts
	And I have the option to search for accounts in dropdown
	And I am required to select at least one account

@Functional
Scenario: 41352_Verify_That the Display Invoice button is active when one or more stations and accounts are selected in the Customer Invoice page for AccessRRD User
	Given I am an Access RRD user logged in to CRM Application
	And I am on the Customer Invoices list page
	And I have selected one or more Stations from the Station list
	When I select a customer from the Customer Accounts dropdown ZZZ - CZar Customer Test
	Then the Display Invoices button will become active

@Functional @Regression @fixed
Scenario: 41352_Verify_That the invoice grid is populated when Display Invoice button is clicked in the Customer Invoice page for AccessRRD User
	Given I am an Access RRD user logged in to CRM Application
	And I am on the Customer Invoices list page
	And I have selected one or more Stations from the Station list
	And I select a customer from the Customer Accounts dropdown ZZZ - CZar Customer
	When I click on the Display Invoices button
	Then the grid will refresh to populate the associated Customer Invoice details ZZZ - CZar Customer Test

@Functional
Scenario: 41352_Verify_That the invoice grid is populated with 0 results when Display Invoice button is clicked in the Customer Invoice page for AccessRRD User
	Given I am an Access RRD user logged in to CRM Application
	And I am on the Customer Invoices list page
	And I have selected one or more Stations from the Station list
	And I select a customer from the Customer Accounts dropdown ZZZ - GS Customer Test
	When I click on the Display Invoices button
	Then the grid will refresh to populate zero results for the associated Customer Invoice details


@Functional @49382
Scenario: 41352_Verify the accounts under dropdown on customer invoice page
	Given I am an Access RRD user logged in to CRM Application
	And I am on the Customer Invoices list page
	And I selected any Station from the dropdown for accessRRD User
	When I click on accounts drop down
	Then  All the accounts associated to the selected station should be load in drop down