@39728 @Sprint80
Feature: Customer Invoice - Schedule Reports - Weekly (Updation)

@Functional @DB
Scenario: Test to verify the create of schedule weekly report
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user,
And I am on the Weekly tab page of the custom Report
And I update all of the fields
When I click on the Schedule Report button
Then scheduled report with the given criteria will be created in DB

@Functional @DB 
Scenario: Test to verify the Update of scheduled weekly report
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user,
And I am on the Weekly tab page of the Schedule weekly Report
And I edit the fields
When I click on the Schedule Report button
Then Updated criteria will be updated in DB for weekly report

@Functional @DB 
Scenario: test to verify the Update in the Monthly tab of scheduled weekly report 
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user,
And I am on the Weekly tab page of the Schedule weekly Report for update
And I click on the Monthly tab of the Schedule Report page
And I edit any of the fields
When I click on the Schedule Report button
Then the scheduled report with the previous criteria will be deleted from DB
And Updated criteria will be updated in DB for Monthly report
