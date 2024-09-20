@38916 @NinjaSprint16 
Feature: Customer Invoice - Custom Report - Date Range Selector

@GUI
Scenario: 38916_Verify that there is option to select a Starting Date and Ending Date for shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on the Customer Invoice page
	And I expanded the Create Custom Report section
	When I click on the Date Range box
	Then I have the option to select a Starting Date
	And I have the option to select an Ending Date

@GUI @Functional
Scenario: 38916_Verify that the date range will be displayed in mm/dd/yyyy-mm/dd/yyyy format for shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on the Customer Invoice page
	And I expanded the Create Custom Report section
	When I have selected a starting and ending date in the Date Range field
	Then I will see the date range displayed in the format mm/dd/yyyy - mm/dd/yyyy

@GUI @Functional
Scenario: 38916_Verify that the date range field is not displayed when only one of the required dates is selected for shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on the Customer Invoice page
	And I expanded the Create Custom Report section
	And I have selected only one of the two required dates
	When I close the date range calendar picker
	Then I will not see a date range displayed in the Date Range field