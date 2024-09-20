@74958 @Sprint89
Feature: 74958-Customer Invoice - Custom Report - Sorted Stations List

Scenario Outline: Sorting the Stations List
	Given I am a <user> user with access to Customer Invoices
	And I am on the customer invoice page
	When I Click on the Stations field of the Create Custom Report section 
	Then the list of stations in the dropdown should be Numerically and Alphabetically sorted
Examples: 
| user             |
| AccessRRD        |
| Sales            |
| Operations       |