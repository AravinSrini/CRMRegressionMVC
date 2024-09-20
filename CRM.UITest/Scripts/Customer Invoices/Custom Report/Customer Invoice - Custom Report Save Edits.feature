@38918 @NinjaSprint23
Feature: Customer Invoice - Custom Report Save Edits

@GUI
Scenario: 38918 - Verify that the save edits button is inactive when the create or edit customer report section is opened
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list
When I expand the Create or Edit Custom Report section
Then I will see a Save Edits button for the report
And the Save Edits button for the report will be inactive

@GUI
Scenario: 38918 - Verify that the save edits button is hidden when the create or edit customer report section is opened on page load
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
When I expand the Create or Edit Custom Report section
Then I will not see a Save Edits button for the  custom reports section

@GUI
Scenario: 38918 - Verify that the save edits button becomes active when the invoice type in the custom report is edited
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list
And I expand the Create or Edit Custom Report section
When I edit the invoice type of the custom report
Then the Save Edits button for the report will be active

@GUI
Scenario: 38918 - Verify that the save edits button becomes active when the days past due section is edited using the text field
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list
And I expand the Create or Edit Custom Report section
When I edit the days past due of the custom report using the text field
Then the Save Edits button for the report will be active

@GUI
Scenario: 38918 - Verify that the save edits button becomes active when the date range section is edited
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list
And I expand the Create or Edit Custom Report section
When I edit the date range of the custom report
Then the Save Edits button for the report will be active

@GUI
Scenario: 38918 - Verify that the save edits button becomes active when the invoice value is edited using the text field
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list
And I expand the Create or Edit Custom Report section
When I edit the invoice value of the custom report by using the text field
Then the Save Edits button for the report will be active

@GUI
Scenario: 38918 - Verify that the save edits button becomes active when the invoice value is edited using the drop down menu
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list
And I expand the Create or Edit Custom Report section
When I edit the invoice value of the custom report by using the drop down menu
Then the Save Edits button for the report will be active

@GUI
Scenario:38918 -  Verify that the save edits button becomes active when a station is added to the custom report
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list
And I expand the Create or Edit Custom Report section
When I edit the station of the custom report by adding a station
Then the Save Edits button for the report will be active

@GUI
Scenario: 38918 - Verify that the save edits button becomes active when an account is added to the custom report
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list
And I expand the Create or Edit Custom Report section
When I edit the account of the custom report by adding an account
Then the Save Edits button for the report will be active

@GUI
Scenario: 38918 - Verify that the save edits button remains inactive when the report name field is edited
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list
And I expand the Create or Edit Custom Report section
When I edit the custom Report Name field
Then the Save Edits button for the report will be inactive

@GUI
Scenario: 38918 - Verify that when the save edits button is clicked the edits will be saved to the custom report and the grid is updated to display invoice matching the new criteria
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature zzzext
And  I am on the Customer Invoice page as an accepted user
And I selected a Custom Report from the Select Standard or Existing Custom Report list for zzzext
And I expand the Create or Edit Custom Report section
And I edited Any field or sections of the CUSTOM REPORT with the exception of the following REPORT NAME
When I click on the Save Edits button for the report
Then the edits will be saved to the custom report
And the grid will update to display invoices matching the new criteria