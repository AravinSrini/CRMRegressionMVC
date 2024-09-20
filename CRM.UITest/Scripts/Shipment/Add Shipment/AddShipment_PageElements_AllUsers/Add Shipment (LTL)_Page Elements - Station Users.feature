@28333 @Sprint69 
Feature: Add Shipment (LTL)_Page Elements - Station Users

@GUI
Scenario Outline: Verify the existence of Station name - customer name on Add Shipment(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a Customer of TMS type MG or Both from the customer selection dropdown list -<Customer>
	And I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	When I arrive on Add shipment LTL page
	Then I must be able to view Station name - customer name on Add Shipment(LTL) page - <Customer>

Examples: 
| Username              | Password | Customer               |
| crmOperation@user.com | Te$t1234 | ZZZ - GS Customer Test |