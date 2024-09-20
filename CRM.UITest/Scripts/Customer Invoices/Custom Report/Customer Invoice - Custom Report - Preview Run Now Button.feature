@38920 @Sprint80 

Feature: Customer Invoice - Custom Report - Preview Run Now Button
	

@GUI @Functional
Scenario: 38920-Verify the Preview Run Now button functionality when I select the existing custom report from the custom report list
Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I arrived on Customer Invoice List page
And I click on the Custom Report list drop down and Select Existing Custom Report from the list
And I expanded the Create Custom Report section
And I verify data is autopopulated in the Create Custom Section for the selected Report name
When I click on the Preview/Run Now button
Then the invoice grid will refresh and display the results of the report based on the selected Custom Report section
	
@GUI @Functional
Scenario: 38920-Verify the Preview Run Now button functionality when I am creating custom report 
Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I arrived on Customer Invoice List page
And I expanded the Create Custom Report section
And I entered all required information for a custom report
When I click on the Preview/Run Now button
Then the invoice grid will refresh and display the results of the report based on the values entered in the Create Custom Report section


@GUI
Scenario: 38920-Verify the message and highlight feilds for the required fields on the Custom Report Section
Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I arrived on Customer Invoice List page
And I expanded the Create Custom Report section
When I click on the Preview/Run Now button without entering data for all required fields in the custom report section
Then I should see the message as 'Please enter all required information'
And the required missing data fields should be highlighted