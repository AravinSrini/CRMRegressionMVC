@Sprint80 
Feature: Customer Invoice - Custom Report - Create New Button
	
@GUI
Scenario: 38919 - Verify the behaviour of Create New button and Delete button when Report Name field is edited
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or an access rrd user.
	And I am on Customer Invoice page
	And A Custom Report has been selected from the Select Existing Custom Report dropdown
	And The Create Custom Report section has been expanded
	When I edit the Report Name field
	Then The Create New button should become active
	And The Delete button should become inactive

@Functional @GUI
Scenario: 38919 - Verify the functionality of Create New button of Create Custom report section
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or an access rrd user.
	And I am on Customer Invoice page
	And The Create Custom Report section has been expanded
	And Data is been passed to all the required fields of Create Custom report section
	When I click on Create New button
	Then The Custom report should get saved
	And The Create Custom Report section should collapse
	And The newly created report should be available to select from the Select Existing Custom Report drop down list.

@Functional @GUI
Scenario: 38919 - Verify validation of Create Custom report fields when values are not passed to all the required fields
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or an access rrd user.
	And I am on Customer Invoice page
	And Data is not passed to all the required fields
	When I click on Create New button
	Then The report should not get saved
	And The missing fields should get highlighted
	And An error message should be displayed stating - Please enter all required information

@Functional @GUI
Scenario: 38919 - Verify the functionality of Create New button when an edit is made to the Report Name field of an existing Custom report
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or an access rrd user.
	And I am on Customer Invoice page
	And A Custom Report has been selected from the Select Existing Custom Report dropdown
	And The Create Custom Report section has been expanded
	And Report Name field is been edited
	When I click on Create New button
	Then The new report will be saved
	And The Create Custom Report section should collapse
	And The newly created report should be available to select from the Select Existing Custom Report drop down list.

@GUI
Scenario: 38919 - Verify the display of error message when user tries to edit a Custom report by giving an existing Report name
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or an access rrd user.
	And I am on Customer Invoice page
	And A Custom Report has been selected from the Select Existing Custom Report dropdown
	And The Create Custom Report section has been expanded
	And Report Name field is been edited by giving an existing name
	When I click on Create New button
	Then An error message should get displayed  

@GUI
Scenario: 38919 - Verify the display of error message when user tries to create a Custom report by giving an existing Report name
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or an access rrd user.
	And I am on Customer Invoice page
	And The Create Custom Report section has been expanded
	And Data is been passed to all the required fields of Create Custom report section
	And Report Name field is passed with an existing report name
	When I click on Create New button
	Then An error message should get displayed  