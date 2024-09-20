@Sprint80 @39163 
Feature: Customer Invoice - Schedule Reports

@GUI
Scenario: 39163_Test to verify the scheduled report label from the custom reports dropdown
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I am on the Customer Invoice page
When I Click Custom Report drop down list
Then I will see that the report is a scheduled report with the label <Scheduled - next scheduled run date in MM/DD/YYYY>


@GUI @Functional
Scenario: 39163_Test to verify the scheduled report option
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I am on the Customer Invoice page
And I select on the Select Existing Custom Report drop down list which is active schedule
When I expand the Create Custom Report section
Then I have the option to Schedule Report


