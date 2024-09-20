@Sprint80 @39710 
Feature: Customer Invoice - Schedule Reports - Page Elements (Weekly)

@GUI
Scenario: 39170_Test to verify the Weekly Time Period tab fields
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user,
And I am on the Create Custom Report section of scheduled report
And I clicked on the Schedule Report button on Create Custom Report section
When I arrive on the Schedule Report modal
Then I will arrive on the Weekly Time Period tab by Default
And I will see a Select Day drop down list
And I am required to select a day with options 'Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday'
And I will see a Select Time section with Hours'1,2,3,4,5,6,7,8,9,10,11,12'
And I will see a Minutes '00,15,30,45'
And I will see AM/PM radio button with AM as default selected value
And I have the option of selecting the Monthly Time Period tab

@GUI
Scenario: 39170_Test to verify mandatory functionality for required fields
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user,
And I am on the Weekly tab of the Schedule Report page
And I have not entered all required information
When I click on the Schedule Report button on modal
Then I will receive a message 'Please enter all required information'
And the page will focus to the first field that is missing required information.
