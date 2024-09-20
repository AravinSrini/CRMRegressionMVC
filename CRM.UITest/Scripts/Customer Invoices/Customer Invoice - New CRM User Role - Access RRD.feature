@31846 @Sprint79 @Ignore
Feature: Customer Invoice - New CRM User Role - Access RRD

@Acceptance @GUI @Functional
Scenario:31846_Test to verify RRD Access user not loaded with customer invoice list
         Given I am an RRD Access user logged into CRM
         When I arrive on Customer Invoice List page
         Then I have no other CRM navigation options
         And I will be displayed the message "Please select a Station or Customer to view Invoices" in the empty grid
         And I will be displayed the station and customer options selections to view the grid

@Acceptance @GUI @Functional
Scenario: 31846_Test to verify Customer Invoice displayed in New Tab for RRD Access user 
         Given I am an RRD Access user logged into CRM
         And I am on the Customer Invoices list page
         When I click on any invoice number        
         Then Invoice will be displayed in new tab of pdf format

@Acceptance @GUI @Functional
Scenario: 31846_Test to verify the error message when customer invoice doesnot exist for RRD user     
        Given I am an RRD Access user logged into CRM
        And I am on the Customer Invoices list page
        When I click on any invoice number        
        Then I will receive a message of Invoice not available

@Acceptance @GUI @Functional
Scenario: 31846_Test to verify Customer Invoice grid display on station selection 
        Given I am an RRD Access user logged into CRM
        And I am on the Customer Invoices list page
        When I select the Station from  dropdown   
        Then grid will be displayed with invoices of selected station

@Acceptance @GUI @Functional
Scenario: 31846_Test to verify Customer Invoice grid display on Customer selection 
        Given I am an RRD Access user logged into CRM
        And I am on the Customer Invoices list page
        When I select the Customer from  dropdown   
        Then grid will be displayed with invoices of selected customer