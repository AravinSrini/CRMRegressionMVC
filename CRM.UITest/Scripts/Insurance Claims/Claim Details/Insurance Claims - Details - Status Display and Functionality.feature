@Sprint84 @40370 

Feature: Insurance Claims - Details - Status Display and Functionality
	
@GUI
Scenario: 40370 - Verify the status of the claim from claim details page
	Given I am a sales, sales management, operations, station owner, claims specialist user
	And I am on the Claims List page
	And I am clicking on the hyperlink of any displayed claim
	When I arrive on the Claim Details page
	Then I will see the status of the claim

@GUI
Scenario: 40370 - Verify the pop up message after hover over the displayed status
	Given I am a sales, sales management, operations, station owner, claims specialist user
	And I am on the Claims List page
	And I am clicking on the hyperlink of any displayed claim
	And I am on the Claim Details page
	When I hover over the displayed claim status
	Then I will see a pop up message with a description of the current status

@Functional
Scenario: 40370 - Verify if the status list is configurable
	Given I am a claim specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim from Claim List page
	When I arrive on the Claim Details page
	Then I have the option to change the claim status
	And the status list is configurable

@GUI 
Scenario: 40370 - Verify the list of status type
	Given I am a claim specialist user
	And I am on the Claims List page
	And I am clicking on the hyperlink of any displayed claim
	And I am on the Claim Details page
	When I click in the Claim Status drop down list
	Then I will see a list of status + code to choose
	And the list will contain the following status types: Open, Denied, Cancelled
	And beneath each status types will be a list of selectable status + code
	And the status + code list will be displayed in hierarchy format beneath the status type
	And I am unable to select a status type
	And I am unable to select more than one status + code

@Functional
Scenario: 40370 - Verify the selected status record from database
	Given I am a claim specialist user
	And I am on the Claims List page
	And I am clicking on the hyperlink of any displayed claim
	And I am on the Claim Details page
	And I selected a claim status from the drop down list
	When I click on Save Claim Details button
	Then the status of the claim will be updated with following details : Date/Time Status Updated,User first name and last name that changed status,New Status Code,Previous Status Code	
	
	

