@Sprint86 @49480
Feature: CRM Customer Invoice - Remove loading Invoices on Initial Launch
	
@GUI
Scenario: 49480 - Test to verify no Customer invoices loads on page load
	Given I am a Station owner, Operations or SalesManagement user
	When I navigate to the customer invoice page
	Then invoices will no longer load on page load