@35767 @NinjaSprint16
Feature: Customer Invoice - Reporting Options

@Functional
Scenario: 35767 - Verify the option to select custom report from dropdown list
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	When I arrive on the Customer Invoice page
	Then I have the option to Select a Custom report from a drop down list

@Functional
Scenario: 35767 - Verify the option to create custom report
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	When I arrive on the Customer Invoice page
	Then I have the option to Create Custom Report

@Functional
Scenario: 35767 - Verify the custom report list
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	When I click in the Select Existing Custom Report field
	Then I will see a list of my Custom reports

@Functional
Scenario: 35767 - Verify if the custom reports are displaying in alphabetical order
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	When I click in the Select Existing Custom Report field
	Then the Custom reports will be displayed in alphabetical order

@Functional
Scenario: 35767 - Verify if the customer invoice grid is getting refresh after selecting the report
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	And I clicked in the Select Existing Custom Report field
	When I select a Custom report for valid data
	Then the Customer Invoice grid will refresh to display the data related to the report selected
	And the selected report name will be displayed in the Create Custom Report section header

@Functional
Scenario: 35767 - Verify the customer invoice list when selected custom report does not return any records
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	And I clicked in the Select Existing Custom Report field
	When I selected a Custom report which wil return no invoice record
	Then the customer invoice grid will update to display the message <No Results Found>

