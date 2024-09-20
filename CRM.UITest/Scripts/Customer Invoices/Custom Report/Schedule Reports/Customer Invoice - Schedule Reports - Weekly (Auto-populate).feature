@Sprint80 @39711
Feature: Customer Invoice - Schedule Reports - Weekly (Auto-populate)
	
@Functional @Acceptance
Scenario: 39711_Verify the schedule Report weekly tab auto populate for active scheduled
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected an existing custom report from dropdown list which is active weekly scheduled
	When I click on weekly scheduled report
	Then I arrive on Scheduled Report weekly tab
	And Week Day, Time, Morning or Evening designation, To, CC, Reply To, Report Format, Subject, Comment fields will display with previously selected data and editable
	And Cancel, Delete Schedule, Schedule Report buttons are active

@Functional @DBVerification
Scenario: 39711_Verify schedule report weekly tab auto populate
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected an existing weekly custom report from dropdown list
	When I click on weekly scheduled report 
	Then I arrive on Scheduled Report weekly tab
	And Default values will be binded in weekly report tab

@Functional @DBVerification
Scenario: 39711_Verify schedule report monthly tab binding for the scheduled weekly report
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected an existing custom report from dropdown list which is active weekly scheduled
	And I arrive on Scheduled Report weekly tab
	When I click on monthly tab of the scheduled report
	Then Default values will be binded in monthly report tab