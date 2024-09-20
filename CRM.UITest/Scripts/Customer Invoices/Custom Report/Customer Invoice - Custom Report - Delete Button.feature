@Sprint80 
Feature: Customer Invoice - Custom Report - Delete Button
	

@Functional
Scenario: 38921 - Verify if the report is deleted after clicking on Delete button
	Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	And A Custom Report has been selected from the Select Existing Custom Report dropdown
	And I expanded the Create or Edit Custom Report section
	When I click on the Delete button
	Then the report will be deleted

@Functional
Scenario: 38921 - Verify if the custom report section is getting collapse after clicking on Delete button
	Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	And A Custom Report has been selected from the Select Existing Custom Report dropdown
	And I expanded the Create or Edit Custom Report section
	When I click on the Delete button
	Then the Create or Edit Custom Report section will collapse

@Functional
Scenario: 38921 - Verify if custom report name has removed from the header section
	Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	And A Custom Report has been selected from the Select Existing Custom Report dropdown
	And I expanded the Create or Edit Custom Report section
	When I click on the Delete button
	Then the custom report name will be removed from the section header

@Functional
Scenario: 38921 - Verify if the deleted report is available in report drop down list
	Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	And A Custom Report has been selected from the Select Existing Custom Report dropdown
	And I expanded the Create or Edit Custom Report section
	When I click on the Delete button
	Then the deleted custom report will not be available to select from the report drop down list

@Functional
Scenario: 38921 - Verify by deleting a custom report which has scheduled run time
	Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	And I selected a Custom Report which has scheduled run time 
	#And I expanded the Create or Edit Custom Report section
	When I click on the Delete button
	Then the report will be deleted
	And the schedule report will also be deleted

@Functional
Scenario: 38921 - Verify the report name after deleting the scheduled custom report
	Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	And I selected a Custom Report which has scheduled run time 
	When I click on the Delete button
	Then the custom report name will be removed from the section header

@Functional
Scenario: 38921 - Verify if the deleted scheduled report is not available in the report drop down list
	Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner 
	And I arrive on the Customer Invoice page
	And I selected a Custom Report which has scheduled run time 
	When I click on the Delete button
	Then the deleted scheduled custom report will not be available to select from the report drop down list

