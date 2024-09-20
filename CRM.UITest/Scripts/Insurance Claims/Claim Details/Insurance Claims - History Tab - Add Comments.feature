@46423 @Sprint84
Feature: Insurance Claims - History Tab - Add Comments
	
@GUI
Scenario: 46423_Verify Add comment modal fields
	Given I am a claims specialist user
	And I am on ClaimDetails page
	And I click on the History Tab
	When I clicked on the Add Comment button
	Then Add Comment modal will be opened
	And the Category field will displayed
	And the Comments field will displayed
	And Cancel button will displayed
	And Add buttons will displayed

	@GUI
Scenario: 46423_Verify the Validations of Add comment fields
	Given I am a claims specialist user
	And I am on ClaimDetails page
	And I click on the History Tab
	When I clicked on the Add Comment button
	Then Add Comment modal will be opened
	And the Category will be required field
	And the Category will be a dropdown field
	And the Comments will be required field
	And the Comments field should accept alpha numeric
	And the Comments field should accept max length of 5000 characters

@GUI
Scenario: 46423_Verify Category dropdown options
	Given I am a claims specialist user
	And I am on ClaimDetails page
	And I click on the History Tab
	And I click on the Add Comment button
	When I click in the category drop down field on the Add Comment Modal
	Then I will see the list of category options
	And the Category list isconfigurable

@GUI
Scenario: 46423_Verify the close button functionality in the Add Comment modal
	Given I am a claims specialist user
	And I am on ClaimDetails page
	And I click on the History Tab
	And I click on the Add Comment button
	When I click on Cancel button on the Add comment modal
	Then the Add Comment modal will be closed
	And no comment will be added

@GUI
Scenario Outline: 46423_Verify the error message when user clicks on Add button without passing values to all required fields 
	Given I am a claims specialist user
	And I am on Claim Details page
	And I click on the History Tab
	And I click on the Add Comment button
	And I have not completed all the required <fields> on add comment modal
	When I click on Add button
	Then I will display with message <Please complete all required fields>
	And the missing fields will be highlighted in red

	Examples: 
	| fields   |
	| Category |
	
@GUI
Scenario: 46423_Verify the Add button functionality of Add Comment modal
	Given I am a claims specialist user
	And I am on ClaimDetails page
	And I click on the History Tab
	And I click on the Add Comment button
	And I have completed all the required fields on add comment modal
	When I click on Add button
	Then the Add Comment modal will be closed
	And the comment will be added to the History tab
	And the Time of the Date/Time field will be Central Time Zone
	And CRM will record the first name and last name of the user that added the comment

@GUI
Scenario: 46423_Verify Add Comment button by login with internal users
	Given I am a sales, sales management, operations, or station owner user
	And I am on ClaimDetailspage
	When I click on History Tab
	Then I should not be displayed with Add comment button
	