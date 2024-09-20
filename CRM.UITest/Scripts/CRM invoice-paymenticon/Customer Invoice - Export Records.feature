@41891 @Sprint78 
Feature: Customer Invoice - Export Records

@Acceptance @GUI 
Scenario: 41891_Test to verify Export dropdown arrow options for internal users
Given I am an operations, sales, sales management, or station owner user
And I am on the Customer Invoices list page
When I click on the Export drop down arrow
Then I will be displayed the option to select All or Displayed 

@Acceptance @GUI 
Scenario: 41891_Test to verify Export dropdown arrow options for external users
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
And I am on the Customer Invoices list page
When I click on the Export drop down arrow
Then I will be displayed the option to select All or Displayed 

@Functional @Acceptance @Ignore
Scenario: 41891_Test to verify Export dropdown arrow_Select All functionality for internal users
Given I am an operations, sales, sales management, or station owner user
And I am on the Customer Invoices list page
And I click on the Export drop down
When I select All option
Then Verify the downloaded export file name<FileName>
Then report<FileName> will be generated of all records of the Customer Invoices grid
And the customer number and name from the Invoices grid will be displayed in the Customer Number column,Customer Name column seperately on the exported report
And the remaining all columns will be exported to report<FileName> from Customer Invoices grid 


@Functional @Acceptance @Ignore 
Scenario: 41891_Test to verify Export dropdown arrow_Select All functionality for external users
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
And I am on the Customer Invoices list page
And I click on the Export drop down
When I select All option
Then Verify the downloaded export file name<FileName>
Then report<FileName> will be generated of all records of the Customer Invoices grid
And the customer number and name from the Invoices grid will be displayed in the Customer Number column,Customer Name column seperately on the exported report
And the remaining all columns will be exported to report<FileName> from Customer Invoices grid 


@Functional @Ignore
Scenario: 41891_Test to verify Export dropdown arrow_Displayed functionality for internal users
Given I am an operations, sales, sales management, or station owner user
And I am on the Customer Invoices list page
And I click on the Export drop down
When I select Displayed option
Then Verify the downloaded export file name<FileName>
Then report<FileName> will be generated of displayed records of the Customer Invoices grid
And the customer number and name from the Invoices grid will be displayed in the Customer Number column,Customer Name column seperately on the exported report
And the remaining all columns will be exported to report<FileName> from Customer Invoices grid 


@Functional @Acceptance @Ignore
Scenario: 41891_Test to verify Export dropdown arrow_Displayed functionality for external users
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
And I am on the Customer Invoices list page
And I click on the Export drop down
When I select Displayed option
Then Verify the downloaded export file name<FileName>
Then report<FileName> will be generated of displayed records of the Customer Invoices grid
And the customer number and name from the Invoices grid will be displayed in the Customer Number column,Customer Name column seperately on the exported report
And the remaining all columns will be exported to report<FileName> from Customer Invoices grid 
