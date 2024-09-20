@38914 @NinjaSprint16
Feature: Customer Invoice - Custom Report - Invoice Type Radio Buttons

@GUI @Functional
Scenario: 38914_Verify that Invoice Type has open, Closed and All as options to select
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I arrived on Customer Invoice List page
	When I expanded the Create Custom Report section
	Then the Invoice Type selection will be defaulted to Open
	And I have the option to select Closed
	And I have the option to select All
	
@GUI @Functional
Scenario: 38914_Verify that the DaysPastDue field is disabled when Invoice Type is selected as Closed
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I arrived on Customer Invoice List page
	And I expanded the Create Custom Report section
	When I Select Closed as the Invoice Type
	Then I am unable to enter a Days Past Due value

@GUI @49366 @PrioritySprint
Scenario: 49366_Verify that the Days Past Due column doesn't display in the grid when the user generates Custom Report by selecting Closed radio button
Given I am any user with access to the CRM Customer Invoice Page
And I created a CustomReport
When I click the Preview/Run Now button
Then I will no longer see the Days Past Due column in my grid results.

@GUI @49366 @PrioritySprint
Scenario: 49366_Verify that a new column Payment Date displays to the right of Due Date in the grid when the user generates Custom Report by selecting Closed radio button
Given I am any user with access to the CRM Customer Invoice Page
And I created a CustomReport
When I click the Preview/Run Now button
Then I will see a New column labeled Payment Date to the right of column Due Date
And the value for this column will be the Last Payment Date from Table from SAP
