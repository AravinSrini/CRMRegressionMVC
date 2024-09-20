@Sprint80 @Functional @39726

Feature: Customer Invoice - Edit Schedule Reports Monthly
	
Scenario Outline: 39726-Verify edit functionality when selected monthly custom shared report from drop and edited only month details in montly tab
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user,
And I selected a Custom report with an active schedule associated as monthly from drop downlist
And I arrived on the Monthly tab of the Schedule Report page
And I edited month <Month>
When I click on the Schedule Report button on scheduled monthly page
Then the scheduled report with the previous criteria will be deleted
And a new report will be scheduled with the updated criteria.
Examples:
| Month    |
| February |
| July     |
| November |


Scenario Outline: 39726-Verify edit functionality when selected monthly custom shared report from drop and edited week and week day or specific day details in montly tab
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user,
And I selected a Custom report with an active schedule associated as monthly from drop downlist
And I arrived on the Monthly tab of the Schedule Report page
And I edited week and weekDay or specificDay <Month>,<Week>,<WeekDay>,<SpecificDayOfMonth>
When I click on the Schedule Report button on scheduled monthly page
Then the scheduled report with the previous criteria will be deleted
And a new report will be scheduled with the updated criteria.
Examples: 
| Month    | Week | WeekDay   | SpecificDayOfMonth |
| October  | 1st  | Sunday    | 1                  |
| January  | 2nd  | Wednesday | 15                 |
| February | 3rd  | Friday    | 28                 |
| November | 4th  | Saturday  | 30                 |


Scenario: 39726-Verify edit functionality when selected monthly custom shared report from drop and edited Report Details Options in montly tab
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user,
And I selected a Custom report with an active schedule associated as monthly from drop downlist
And I arrived on the Monthly tab of the Schedule Report page
And I edited week Report Details Options <test@test.com>,<test123@test.com>,<testabc@test.com>,<Excel>,<TestingScheduledMonthly>,<Test>
When I click on the Schedule Report button on scheduled monthly page
Then the scheduled report with the previous criteria will be updated 


Scenario:39726-Verify edit functionality when selected monthly custom shared report from drop and edited reports details in weekly tab
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user,
And I selected a Custom report with an active schedule associated as monthly from drop downlist
And I arrived on the Weekly tab of the Schedule Report page
And I edited any of the fields <Monday>,<08>,<30>,<AM>,<test@test.com>,<test123@test.com>,<testabc@test.com>,<Excel>,<TestingScheduledMonthly>,<Test>
When I click on the Schedule Report button
Then Monthly schedule report will be updated to weekly report
