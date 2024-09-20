@43794 @NinjaSprint19
Feature: Access RRD User - All Stations

@Functional 
Scenario: 43794_Verify_All_Stations_Are_Available_In_Alphabetical_Order
	Given I am an Access RRD user logged in to CRM Application
	And I am on the Customer Invoices list page
	When I click in the Stations dropdown for accessRRD User
	Then I get all stations in alphabetical order

@Functional @Regression
Scenario: 43794_Verify_All_Stations_Are_Available_In_Alphabetical_Order_Inside_Create_Custom_Report_Section
	Given I am an Access RRD user logged in to CRM Application
	And I am on the Customer Invoices list page
	And I expanded the Create Custom Report section
	When I click in the Stations field
	Then I get all stations in alphabetical order under custom report section