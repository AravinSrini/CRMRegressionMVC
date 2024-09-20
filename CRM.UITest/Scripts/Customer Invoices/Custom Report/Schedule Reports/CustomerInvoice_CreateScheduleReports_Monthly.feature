@Sprint80 @39725
Feature: CustomerInvoice_CreateScheduleReports_Monthly
	

@Functional
Scenario Outline: 39725 Verify the Creation of Scheduled Report Monthly by selecting Specific Day Month
	 Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected a Custom report from the Select Existing Custom Report drop down list in Customer Invoice page
	And I clicked on Schedule Report button will be navigated to Weekly Tab
	And I clicked on Monthly Time Period tab
	And I entered all the required information<testDataMonth>,<testDataSpecificDay>,<testDataHours>,<testDataMinutes>,<testDataMeridiem>,<testDataTo>,<testDataCC>,<testDataReplyTo>,<testDataFormat>,<testDataSubject>,<testDataComment>
	When I click Schedule Report button
	Then the Custom Report will be Scheduled for the selected Specific Month

	Examples: 
	| testDataMonth | testDataSpecificDay | testDataHours    | testDataMinutes  | testDataMeridiem | testDataTo					   | testDataCC                    | testDataReplyTo            | testDataFormat          | testDataSubject					   | testDataComment      |
	| August        | 15                  |  08               | 00               | AM			   | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com    | vasanth.gajaraj@rrd.com    |   Excel                 | TestMonthlyScheduledReportCreation | TestingMonthlyReport |
	| May           | 17                  |  08               | 00               | AM			   | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com    | vasanth.gajaraj@rrd.com    |   Excel                 | TestMonthlyScheduledReportCreation | TestingMonthlyReport |
	| June          | 13                  |  02               | 00               | PM			   | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com    | vasanth.gajaraj@rrd.com    |  Excel                  |TestMonthlyScheduledReportCreation  |TestingMonthlyReport  |

	@Functional 
	Scenario: 39725 Verify the Creation of Scheduled Report Monthly by selecting all the Months
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected a Custom report from the Select Existing Custom Report drop down list in Customer Invoice page
	And I clicked on Schedule Report button will be navigated to Weekly Tab
	And I clicked on Monthly Time Period tab
	And I entered all the required information by selecting all the Months<15>,<08>,<30>,<AM>,<test@test.com>,<test123@test.com>,<testabc@test.com>,<Excel>,<TestingScheduledMonthly>,<Test>
	When I click Schedule Report button
	Then the Custom Report will be Scheduled for all the Months

	@Functional 
	Scenario Outline: 39725 Verify the Creation of Scheduled Report Monthly by selecting Week and Week day
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected a Custom report from the Select Existing Custom Report drop down list in Customer Invoice page
	And I clicked on Schedule Report button will be navigated to Weekly Tab
	And I clicked on Monthly Time Period tab
	And I entered the required information by Week and Weed day<testDataMonth>,<testDataWeek>,<testDataWeekDay>,<testDataHours>,<testDataMinutes>,<testDataMeridiem>,<testDataTo>,<testDataCC>,<testDataReplyTo>,<testDataFormat>,<testDataSubject>,<testDataComment>
	When I click Schedule Report button
	Then the Custom Report will be Scheduled for the selected Week and Week day
	
	Examples: 
	| testDataMonth | testDataWeek | testDataWeekDay | testDataHours | testDataMinutes | testDataMeridiem | testDataTo                    | testDataCC                 | testDataReplyTo         | testDataFormat      | testDataSubject                    | testDataComment      |
	| August        | 3rd          | Wednesday       | 08             | 00              | AM               | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com | vasanth.gajaraj@rrd.com |  Excel              | TestMonthlyScheduledReportCreation | TestingMonthlyReport |
	| May           | 3rd          | Friday          | 08             | 00              | AM               | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com | vasanth.gajaraj@rrd.com |  Excel              | TestMonthlyScheduledReportCreation | TestingMonthlyReport |
	| June          | 2nd          | Wednesday       | 02             | 00              | PM               | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com | vasanth.gajaraj@rrd.com |  Excel              |TestMonthlyScheduledReportCreation  |TestingMonthlyReport  |

		@GUI 
	Scenario: 39725 Verify the Cancel and Schedule Report buttons are Active in Monthly time period tab
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected a Custom report from the Select Existing Custom Report drop down list in Customer Invoice page
	And I clicked on Schedule Report button will be navigated to Weekly Tab
	When I click on the Monthly Time Period tab
	Then the Cancel and Schedule Report buttons will be Active

	@Functional 
	Scenario Outline: 39725 Verify the Monthly Scheduled Report creation for Week and Weekday by selecting all Months
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I selected a Custom report from the Select Existing Custom Report drop down list in Customer Invoice page
	And I clicked on Schedule Report button will be navigated to Weekly Tab
	And I clicked on the Monthly Time Period tab
	And I entered the required information by selecting all months Week and Weed day<testDataWeek>,<testDataWeekDay>,<testDataHours>,<testDataMinutes>,<testDataMeridiem>,<testDataTo>,<testDataCC>,<testDataReplyTo>,<testDataFormat>,<testDataSubject>,<testDataComment>
	When I click Schedule Report button
	Then the Custom Report will be scheduled for selected week and Weekday for the current Month

	Examples: 
	| testDataWeek | testDataWeekDay | testDataHours  | testDataMinutes | testDataMeridiem | testDataTo                    | testDataCC                 | testDataReplyTo         | testDataFormat      | testDataSubject                    | testDataComment      |
	| 2nd          | Thursday        | 01             | 30              | AM               | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com | vasanth.gajaraj@rrd.com |  Excel              | TestMonthlyScheduledReportCreation | TestingMonthlyReport |
	| 3rd          | Wednesday       | 08             | 00              | PM               | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com | vasanth.gajaraj@rrd.com |  PDF              | TestMonthlyScheduledReportCreation | TestingMonthlyReport |
	| 4th          | Wednesday       | 08             | 00              | PM               | vasantha.gajaraj@saggezza.com | vasantha.gajaraj@gmail.com | vasanth.gajaraj@rrd.com |  PDF              | TestMonthlyScheduledReportCreation | TestingMonthlyReport |


