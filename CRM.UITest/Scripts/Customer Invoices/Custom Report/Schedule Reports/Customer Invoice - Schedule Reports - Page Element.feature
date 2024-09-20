@Sprint80 @39165
Feature: Customer Invoice - Schedule Reports - Page Element

@GUI @Acceptance
Scenario: 39165_Verify the all fields on Schedule Report Modal
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on the Create Custom Report section for the selected custom Report
	When I click on the Schedule Report button on custom report section
	Then I will arrive on Schedule Report modal
	And I will display with custom report name on the top of the modal on both weekly and monthly tabs
	And I will be displaying with Report Delivery options To, CC, Reply To, Report format selection, subject and comment on both weekly and monthly tabs
	And Cancel, Delete Schedule and Schedule Report buttons should be displayed on both weekly and monthly tabs
	And I have an option to select both excel and pdf reports

@GUI @Acceptance
Scenario: 39165_Verify the validations for Report Delivery options on Schedule Report Modal
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on the Create Custom Report section for the selected custom Report
	When I click on the Schedule Report button on custom report section
	Then To is a mandatory field, should accept multiple emails with comma separation and should accept max length of 250
	And CC is an optional field, should accept multiple emails with comma separation and should accept max length of 250
	And Reply To is an optional field, should accept only one email and should accept max length of 75
	And Report format selection is a mandatory field, and should be defaulted to excel selection
	And Subject name defaulted to Report name was processed on Datetime
	And Subject is a mandatory field and should accept alpha numeric of max length 250	
	And Comment is an optional field and should accept alpha numeric of max length 500

@GUI @Acceptance
Scenario: 39165_Verify Cancel button functionality on Schedule Report modal
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on the Create Custom Report section for the selected custom Report
	When I click on Cancel button on Schedule Report modal
	Then I will arrive on the Customer Invoice list

	