@NinjaSprint19 @43328
Feature: Customer Invoices - List Page - Export Button Change Remove All 

@GUI
Scenario: 43328_Verify Export Button Option will not have "All-"
Given I am a CRM user with access to the Customer Invoice list page
And I arrive on the Customer Invoices list page
When I click on the Export button
Then I will no longer see the word All- before each export option.