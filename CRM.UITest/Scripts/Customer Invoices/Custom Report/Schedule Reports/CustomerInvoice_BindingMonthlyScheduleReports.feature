@Sprint80 @40027
Feature: CustomerInvoice_BindingMonthlyScheduleReports
	
@GUI
Scenario Outline: 40027 Verify Monthly Scheduled Report bindings and Cancel, Delete Schedule button are in Active State for SpecificDay Logic
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected a Custom report from the Select Existing Custom Report drop down list in Customer Invoice page
	And I clicked on Schedule Report button will be navigated to Weekly Tab
	And I clicked on the Monthly Time Period tab
	And I entered all the required information<testDataMonth>,<testDataSpecificDay>,<testDataHours>,<testDataMinutes>,<testDataMeridiem>,<testDataTo>,<testDataCC>,<testDataReplyTo>,<testDataFormat>,<testDataSubject>,<testDataComment>
	And I clicked on the Scheduled Report button
	And I will land on Customer Invoice list page and the scheduled Monthly Reports will be created
	When I select this created Monthly Schedule Report from the Select Existing Custom Report from the dropdown
	Then I will see all the information while creating the Report is now binded in the Monthly tab
	And I will see Cancel, Delete Schedule, Schedule Report button are in active state

	Examples: 
	| testDataMonth | testDataSpecificDay | testDataHours    | testDataMinutes  | testDataMeridiem | testDataTo					   | testDataCC                    | testDataReplyTo            | testDataFormat          | testDataSubject					   | testDataComment      |
	| August        | 15                  |  08               | 00               | AM			   | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com    | vasanth.gajaraj@rrd.com    |   Excel                 | TestMonthlyScheduledReportCreation | TestingMonthlyReport |
	| May           | 17                  |  08               | 00               | AM			   | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com    | vasanth.gajaraj@rrd.com    |   Excel                 | TestMonthlyScheduledReportCreation | TestingMonthlyReport |
	


	@GUI
	Scenario Outline: 40027 Verify Monthly Scheduled Report bindings and Cancel, Delete Schedule button are in Active State for week and weekday logic
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected a Custom report from the Select Existing Custom Report drop down list in Customer Invoice page
	And I clicked on Schedule Report button will be navigated to Weekly Tab
	And I clicked on the Monthly Time Period tab
	And I entered the required information by selecting all months Week and Weed day<testDataWeek>,<testDataWeekDay>,<testDataHours>,<testDataMinutes>,<testDataMeridiem>,<testDataTo>,<testDataCC>,<testDataReplyTo>,<testDataFormat>,<testDataSubject>,<testDataComment>
	And I clicked on the Scheduled Report button
	And I will land on Customer Invoice list page and the scheduled Monthly Reports will be created
	When I select this created Monthly Schedule Report from the Select Existing Custom Report from the dropdown
	Then I will see all the information for all months Week and Weed day is autopopulated in the Monthly tab
	And I will see Cancel, Delete Schedule, Schedule Report button are in active state
	

	Examples: 
	| testDataWeek | testDataWeekDay | testDataHours | testDataMinutes | testDataMeridiem | testDataTo                    | testDataCC                 | testDataReplyTo         | testDataFormat      | testDataSubject                    | testDataComment      |
	| 3rd          | Wednesday       | 08             | 00              | AM               | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com | vasanth.gajaraj@rrd.com |  Excel              | TestMonthlyScheduledReportCreation | TestingMonthlyReport |
	| 3rd          | Wednesday       | 08             | 00              | PM               | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com | vasanth.gajaraj@rrd.com |  PDF              | TestMonthlyScheduledReportCreation | TestingMonthlyReport |