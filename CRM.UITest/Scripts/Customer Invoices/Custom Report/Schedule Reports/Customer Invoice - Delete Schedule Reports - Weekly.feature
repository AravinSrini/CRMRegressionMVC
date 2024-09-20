@39727 @Sprint80 

Feature: Customer Invoice - Delete Schedule Reports - Weekly
	
@GUI
Scenario: 39727-Verify the confirmation message and options for the Delete schedule Report button
         Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
         And I arrived on the Customer Invoice page
         And I selected a weekly Custom report with an active schedule associated from the drop down list
         And I arrived on the associated Time Period tab of the Schedule Report page when I click on the Schedule Report button
         When I click on the Delete Schedule button
         Then I should see a confirming message that I want to delete the schedule as 'Are you sure you want to delete this schedule?'
         And I have option to confirm and cancel the deletion of the schedule
		

@GUI @Functional
Scenario: 39727-Verify the click functionality of cancel option for Delete Schedule button
        Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
        And I arrived on the Customer Invoice page
		And I selected a weekly Custom report with an active schedule associated from the drop down list
        And I arrived on the associated Time Period tab of the Schedule Report page when I click on the Schedule Report button
        And I clicked on the Delete Schedule button weekly tab
		And I received a message confirming that I want to delete the schedule - 'Are you sure you want to delete this schedule?'
        When I click on cancel the deletion request option
        Then The Delete Confirmation message will be removed  


@GUI @Functional
Scenario: 39727-Verify the click functionality of confirm option for Delete Schedule button
       Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
       And I arrived on the Customer Invoice page
	   And I selected a weekly Custom report with an active schedule associated from the drop down list
       And I arrived on the associated Time Period tab of the Schedule Report page when I click on the Schedule Report button
       And I clicked on the Delete Schedule button weekly tab
       When I choose to delete the schedule
       Then The Delete Confirmation message will be removed 
       And The fields of the Weekly Time Period tab will be reset to the default values
       And The Cancel and Schedule Report button will be active
       And The Custom Report still exists in the drop down after deleting the schedule without scheduled

@GUI @Functional
Scenario: 39727-Verify the scheduled and date label is not displayed next to report name if schedule report deleted for the customer 
      Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
      And I arrived on the Customer Invoice page
      And a weekly scheduled report for a listed Customer report has been deleted
      When I click on the Select Existing Custom Report drop down list in customer invoice page
      Then I will no longer see the scheduled and next run date label displayed next to the weekly report name

@GUI
Scenario: 39727-Verify the delete schedule button when I select the existing custom report which is not scheduled
       Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
       And I arrived on the Customer Invoice page
       And I click on the existing custom report drop down to select a custom report which is not scheduled
	   When I click on the Schedule Report button on Customer Invoices page
	   Then the Delete schedule button should be Inactive
