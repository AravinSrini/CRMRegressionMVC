@50767 @PrioritySprint2
Feature: Customer Invoice - List View With Multiple DAGRT - Preview or Run Report
	

Scenario: 50767_Verify the grid display for multiple DAGRT number 
	Given I am any user with access to the CRM Customer Invoice Page
	And I am on the Customer Invoice page
	And I expand the custom report section
	And I select a station with MULTIPLE DAGRT numbers
	And I select All Accounts for the selected station
	And I enter a Custom Report Name
	When I click the Preview / Run Button
	Then the grid will display all invoices where the invoice DAGRT number matches any DAGRT number within the station DAGRT list
	And display the results of the report based on the values entered in the Create Custom Report section
