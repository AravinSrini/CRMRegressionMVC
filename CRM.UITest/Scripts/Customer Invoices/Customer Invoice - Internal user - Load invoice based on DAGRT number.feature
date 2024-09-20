@Sprint83 @45250 
Feature: Customer Invoice - Internal user - Load invoice based on DAGRT number
	
@GUI
Scenario: 45250-Verify display of Open invoices and filter options on Customer Invoice Grid section
	Given I am a Station owner, Operations or SalesManagement user
	When I am on the Customer Invoices page
	Then All Open invoices based on DAGRT numbers of the associated stations should get displayed
	And I should be able to view Open as filter option
	And I should be able to view Closed as filter option

@GUI @Functional
Scenario: 45250-Verify display of invoices on Customer invoice grid when user selects 'Closed' Invoices
	Given I am a Station owner, Operations or SalesManagement user
	And I am on Customer Invoices Page
	When I select Closed Invoices
	Then I should see last two years closed invoices based on DAGRT numbers of the associated stations and closed dates
	
@Functional
Scenario Outline: 45250-Verify if user is able to select "All Accounts" from the customer dropdown of Create Custom Report section
	Given I am a Station owner, Operations, SalesManagement user or AccessRRD user
	And I am on Customer Invoices Page
	And The Create Custom Report section has been expanded
	When I have selected one or more <Stations>
	Then I should be able to select 'All Accounts'

Examples: 
| Stations        |
| SingleStation   |
| MultipleStation |

@Functional
Scenario Outline: 45250-Verify the functionality of Preview/Run now button when user selects 'All Accounts' from the customer dropdown with filter option 'Open'
	Given I am a Station owner, Operations, SalesManagement user or AccessRRD user
	And I am on Customer Invoices Page
	And The Create Custom Report section has been expanded
	And One or more <Stations> along with 'All Accounts' has been selected by choosing Open as filter option
	When I click Preview/Run now button
	Then All Open Invoices should be listed based on DAGRT numbers of selected <Stations>

Examples: 
| Stations        |
| SingleStation   |
| MultipleStation |

@Functional
Scenario Outline: 45250-Verify the functionality of Preview/Run now button when user selects 'All Accounts' from the customer dropdown with filter option 'Closed'
	Given I am a Station owner, Operations, SalesManagement user or AccessRRD user
	And I am on Customer Invoices Page
	And The Create Custom Report section has been expanded
	And One or more <Stations> along with 'All Accounts' has been selected by choosing Closed as filter option.
	When I click Preview/Run now button
	Then Last two years Closed Invoices should be listed based on DAGRT numbers of selected <Stations> and closed dates

Examples: 
| Stations        |
| SingleStation   |
| MultipleStation |

@Functional
Scenario Outline: 45250-Verify the functionality of Preview/Run now button when user selects 'All Accounts' from the customer dropdown with filter option 'Closed' and Date Range selected
	Given I am a Station owner, Operations, SalesManagement user or AccessRRD user
	And I am on Customer Invoices Page
	And The Create Custom Report section has been expanded
	And Date Range has been selected  
	And One or more <Stations> along with 'All Accounts' has been selected by choosing Closed as filter option.
	When I click Preview/Run now button
	Then Closed Invoices should be listed based on DAGRT numbers of selected <Stations>,date range and closed dates

Examples: 
| Stations        |
| SingleStation   |
| MultipleStation |

@Functional
Scenario Outline: 45250-Verify the functionality of Display Invoices button when 'All Accounts' have been selected from the Customer dropdown
	Given I am an AccessRRD user
	And I am on Customer Invoices Page
	And One or more <Stations> along with 'All Accounts' has been selected 
	When I click Display Invoices button
	Then Invoices should be listed based on DAGRT numbers of selected <Stations>
	And I should be able to view Open as filter option
	And I should be able to view Closed as filter option

Examples: 
| Stations        |
| SingleStation   |
| MultipleStation |

@Functional
Scenario Outline: 45250-Verify the functionality of Display Invoices button when 'All Accounts' have been selected from the Customer dropdown with filter option Closed
	Given I am an AccessRRD user
	And I am on Customer Invoices Page
	And One or more <Stations> along with 'All Accounts' has been selected 
	And Display Invoices button has been clicked
	When I select 'Closed' option
	Then Last two years Closed Invoices should be listed based on DAGRT numbers of selected <Stations> and closed dates

Examples: 
| Stations        |
| SingleStation   |
| MultipleStation |






