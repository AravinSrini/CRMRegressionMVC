@Sprint82 @39493
Feature: Insurance Claims - Details Tab - Elements
	
@GUI
Scenario: 39493_Verify the claim details page elements
	Given I am a sales, sales management, operations, station owner, or claims specialist user
	And I am on the Claims List page
	When I clicked on the hyperlink of any displayed claim
	Then I will see the page label <Claim Details> in Claim Details page
	And I will see the verbiage <The details for this claims are displayed below.> located beneath the page label
	And I will see a Back to Claims List button
	And I will see the following tabs: Details, Payments, Documents, Status/History
	And By default I will be on the Details tab

@GUI
Scenario: 39493_Verify the Details tab sections
	Given I am a sales, sales management, operations, station owner, or claims specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim
	When Details tab is selected
	Then I will see the sections in details tab 

@Functional
Scenario: 39493_Verify the Back to Claim List Page button 
	Given that I am a sales, sales management, operations, station owner, or claims specialist user
	And I am on the Claim Details page
	When I click on the Back to Claims List button
	Then I will arrive on the Claims List page


