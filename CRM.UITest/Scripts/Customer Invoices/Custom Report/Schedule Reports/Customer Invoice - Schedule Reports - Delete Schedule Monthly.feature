@CustomerInvoice_ScheduleReports_DeleteSchedule_Monthly @39198 @Sprint80 
Feature: Customer Invoice - Schedule Reports - Delete Schedule Monthly


@GUI @Functional @DBVerification
Scenario: 39198_Verify the confirmation message and options for the Delete schedule Report button 
         Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and access rrd user
         And I arrived on the Customer Invoice page
		 And I selected a monthly Custom report with an active schedule associated from the drop down list
         And I expanded the Create Custom Report section
         And I clicked on the Schedule Report button
         And I arrived on the associated Time Period tab of the Schedule Report page
         When I click on the Delete Schedule button
         Then I have receive a message confirming that I want to delete the schedule
         And The message will be - Are you sure you want to delete this schedule?
         And I have the option to confirm the deletion of the schedule
         And I have the option to cancel the deletion request

@GUI @Functional @DBVerification
Scenario: 39198_Verify the click functionality of cancel option for Delete Schedule button
        Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and access rrd user
        And I arrived on the Customer Invoice page
		And I selected a monthly Custom report with an active schedule associated from the drop down list
        And I expanded the Create Custom Report section
        And I clicked on the Schedule Report button
        And I arrived on the associated Time Period tab of the Schedule Report page
        And I clicked on the Delete Schedule button
        And I received a message confirming that I want to delete the schedule
        When I click on cancel the deletion request option
        Then The message will be removed

@GUI @Functional
Scenario: 39198_Verify the click functionality of confirm option for Delete Schedule button
       Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and access rrd user
       And I arrived on the Customer Invoice page
	   And I selected a monthly Custom report with an active schedule associated from the drop down list
       And I expanded the Create Custom Report section
       And I clicked on the Schedule Report button
       And I arrived on the associated Time Period tab of the Schedule Report page
       And I clicked on the Delete Schedule button
       And I received a message confirming that I want to delete the schedule
       When I choose to delete the schedule
       Then The message will be removed
       And The fields of the Time Period tab will be reset to the default values
       And The Cancel button will be active
       And The Schedule Report button will be active
       And The Custom Report will no longer be scheduled

@GUI @Functional
Scenario: 39198_Verify the scheduled and date label is not displayed next to report name if schedule report deleted for the customer 
      Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and access rrd user
      And I arrived on the Customer Invoice page
	  And a scheduled report for a listed Customer report has been deleted
      When I click on the Select Existing Custom Report drop down list
      Then I will no longer see the scheduled and next run date label displayed next to the report name


@GUI
Scenario: 39198_Verify the Delete Schedule button when I select the custom report which is not scheduled
      Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
      And I arrived on the Customer Invoice page
      And I select a custom report from drop down which is not scheduled
      When I click on the Schedule Report button from custom report section
      Then The Delete schedule button should be Inactive


	
	