@38915 @NinjaSprint16
Feature: Customer Invoice - Custom Report - Days Past Due Field

@GUI @Functional
Scenario: 38915_Verify that the Days Past Due field is a numeric control with increments of + or - one and allows whole numbers with values of zero or greater
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I arrived on Customer Invoice List page
	When I expanded the Create Custom Report section
	Then I have the option to enter the Days Past Due using a numeric control with increments of + or - one
	And I can only enter whole numbers with values of zero or greater

@GUI @Functional
Scenario: 38915_Verify that the Invoice value field is formatted as US currency like $x,xxx.xx
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I arrived on Customer Invoice List page
	When I expanded the Create Custom Report section
	Then I will have the option to enter a numeric Invoice Value formatted as US currency like $x,xxx.xx
	
@GUI @Functional
Scenario: 38915_Verify that the Invoice value Range selector dropdown has 2 values > and < and is defaulted to >
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I arrived on Customer Invoice List page
	When I expanded the Create Custom Report section
	Then The Invoice Value will have a range selector with the following selectors GreaterThan > and LessThan < 
	And Greater than symbol > is selected by default

#---------------------52650 -- Sprint87 -------------------------------
@52650 @Sprint87
Scenario: 52650-Verify the Days Past Due data is equal to or greater than the entered value in the Days Past Due field while Create Customer Report Section
    Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
    And I am on the Customer Invoices page
	And I am on the Create Customer Report Section
	And I selected Invoice type is Open
	And I entered a value in the DaysPastDue field along with all required fields
	When I Click on the button Preview/Run 
	Then the grid should display invoices with the DaysPastDue equal to or greater than the value entered in the DaysPastDue field in Create Custom Report Section

@52650 @Sprint87
Scenario: 52650-Verify the Days Past Due data is equal to or greater than the Days Past Due field When I select the Existing Custom Report
    Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
    And I am on the Customer Invoices page
	And I have Custom Report that includes <DayPastDueReportTesting> criteria
    When I Select the Custome Report <DayPastDueReportTesting> from the existing list
	Then the grid should display invoices with the DaysPastDue equal to or greater than the value entered in the DaysPastDue field in the existing Report Criteria
