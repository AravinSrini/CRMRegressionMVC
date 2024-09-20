@49481 @PrioritySprint
Feature: CRM Customer Invoice - Expand Custom Reports Section
	
@GUI
Scenario: 49481_Test to verify the Expand custom reports section no longer available
	Given I am Station owner, Operations or SalesManagement user
	When I navigate to the customer invoice page
	Then the Create Custom Report section will be expanded
	And I will no longer have the option to collapse the section