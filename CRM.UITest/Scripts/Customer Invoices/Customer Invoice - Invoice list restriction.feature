@45358 @Sprint83 
Feature: Customer Invoice - Invoice list restriction
	

@GUI 
Scenario: 45358_Verify user able to see only Open and Closed Option on Customer Invoice List Screen
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, and access rrd user
    When I arrived on Customer Invoice List page
	Then I should see an Open filter Option
	And I should see an Closed filter option




@GUI @Functional
Scenario: 45358_Verify Invoice list should display last two years Invoices based on the Closed Date for the Closed Status
    Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and  access rrd user
    And I arrived on Customer Invoice List page
	When I select Closed status on the Customer Invoice List
	Then I should get last two years invoice list based on the Closed Date

@GUI
Scenario: 45358_Verify user able to see only Open and Closed Option on Create Custom Report Section
    Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and  access rrd user
    And I arrived on Customer Invoice List page
	When I expand the Create Custom Report section
	Then I should have Open Status option
	And I should have Closed Status option
	
@GUI
Scenario: 45358_Verify user is able to clear date range in Create Custom Report Section
    Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and  access rrd user
    And I arrived on Customer Invoice List page
	When I expand the Create Custom Report section
	And Enter date in the Date Range
	Then I should have option to clear the Date Range
	
@GUI
Scenario: 45358_Verify the loading icon on the Customer Invoice list grid when I click on the Display Invoices button
    Given I am an Access RRD user logged in to CRM Application
	And I am on the Customer Invoices list page
	And I select one or more Stations from the station drop down list <ZZZ - Web Services Test>
	And I select <All Accounts> for the selected Stations in Customer drop down down list
	When I click on the Display Invoices button
	Then I will see loading icon on the grid till Invoice list is loaded

@GUI
Scenario: 45358_Verify the loading icon on the Customer Invoice list grid when I click on the Preview/Run Now button
    Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
    And I arrived on Customer Invoice List page
    And I expanded the Create Custom Report section
    And I entered all required information for a custom report
    When I click on the Preview/Run Now button
	Then I will see loading icon on the grid till Invoice list is loaded

@GUI
Scenario: 45358_Verify the loading icon when I land on the Customer Invoice List page and default Open is selected
    Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
    And I arrived on Customer Invoice List page
	And I select Closed Status on the Customer Invoice List
	When I select Open Status on the Customer Invoice List
	Then I will see loading icon on the grid till Invoice list is loaded

@GUI
Scenario: 45358_Verify the loading icon when I select the Closed Status on the Customer Invoice List
       Given I am shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
       And I arrived on Customer Invoice List page
	   When I select Closed status on the Customer Invoice List
	   Then I will see loading icon on the grid till Invoice list is loaded

