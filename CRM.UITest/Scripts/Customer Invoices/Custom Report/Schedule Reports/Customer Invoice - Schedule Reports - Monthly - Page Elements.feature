@Sprint80 @39168 @Functional @GUI

Feature: Customer Invoice - Schedule Reports - Monthly - Page Elements
	

Scenario: 39168:Verify the presence of page elements within Monthly tab
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I have selected a Custom report from the Select Existing Custom Report list
And  I arrived on the default Weekly tab of the Schedule Report page,
When I click on the Monthly tab
Then I will have the option to select one or more months
And I am required to select at least one month
And I will see a Select Day section
And I am required to select a day
And I will see a Select Time section
And I am required to select the time
And I have the option to select the Weekly Time Period tab


Scenario: 39168:Verify the List of months check boxes and expected functionality within monthly tab
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I have selected a Custom report from the Select Existing Custom Report list
And  I arrived on the default Weekly tab of the Schedule Report page,
When I click on the Monthly tab
Then I will see a chronological list of months
And by default all of the months are selected
And I have the option to deselect months
And I have the option to select months
And I am required to select at least one month


Scenario: 39168:Verify SELECT DAY section and default values in drop downs within monthly tab
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I have selected a Custom report from the Select Existing Custom Report list
And  I arrived on the default Weekly tab of the Schedule Report page,
When I click on the Monthly tab
Then I have option to select the week of the month or specific day of the month
And I have the option to select week option from the drop down list 1st will be defaulted<1st,2nd,3rd,4th>
And I have the option to select a day with options Sunday will be defaulted <Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday>
And I have the option to select the day beginning with <1> and ending with <30> and <1> will be defaulted


Scenario: 39168:Verify Hours and Minutes section and options within monthly tab
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I have selected a Custom report from the Select Existing Custom Report list
And  I arrived on the default Weekly tab of the Schedule Report page,
When I click on the Monthly tab
Then I have the option to Select Time section with Hours<01,02,03,04,05,06,07,08,09,10,11,12>
And  I have the option to see a Minutes <00,15,30,45>
And  I have the option to see AM/PM radio button with AM as default selected value


Scenario: 39168:Verify validation message if user has not entered all required information
Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
And I have selected a Custom report from the Select Existing Custom Report list
And I am on the  Monthly tab of the Schedule Report page
When I click on the Schedule Report button
Then I will receive a error message <Please enter all required information>
#And the page will focus to the first field that is missing required information