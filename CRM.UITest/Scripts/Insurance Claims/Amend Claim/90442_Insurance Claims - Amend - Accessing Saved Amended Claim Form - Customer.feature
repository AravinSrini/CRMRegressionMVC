@90442 @Sprint94
Feature: 90442_Insurance Claims - Amend - Accessing Saved Amended Claim Form - Customer
	
Scenario: 90442_Verify the existence, format and behaviour of amended saved form link on Claim list page
	Given I am a user who have access to Claims module 'username-CurrentSprintshpentry' 'password-CurrentSprintshpentry'
	And I am on the Claims List page
	When A claim was amended and resubmitted
	Then I will see a link to the amended saved form in the DLSW Claim number column
	And The formatting of the amended saved form link is DLSW Claim number + (A)
	And I will See a popover message 'View amended claim' on mouser hover on amended saved form link

Scenario: 90442_Verify the hover over message on Original saved form link for an amended claim on the claim list page
	Given I am a user who have access to Claims module 'username-CurrentSprintshpentry' 'password-CurrentSprintshpentry'
	And I am on the Claims List page
	And A claim was amended and resubmitted
	And The new amended saved form link is present
	When I hover over the original saved form link
	Then I will see a popover message on the claim list page: 'View original claim'

Scenario: 90442_Verify the functionality of Amended saved form link
	Given I am a user who have access to Claims module 'username-CurrentSprintshpentry' 'password-CurrentSprintshpentry'
	And I am on the Claims List page
	And A claim was amended and resubmitted
	And The new amended saved form link is present
	When I click on amended saved form link on claim list page
	Then a pdf of the claim form will be displayed with the most recent saved updates