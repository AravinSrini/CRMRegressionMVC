@Sprint84 @40365 

Feature: 40365 - Insurance Claims - Documents Tab - Delete
	

@GUI
Scenario: 40365_Verify the Delete Document pop up modal
Given I am a Claims Specialist User
And I clicked on the hyperlink of any displayed claim on the Claim list
And I arrive on the Claim Details page of the selected claim
And I clicked on the Document Tab
When I click on the Delete Icon of any displayed document
Then I will see a delete document pop up message as <Are you sure you want to delete this file?> 
And I will see a <Cancel> button
And I will see a <Delete> button on the delete document pop up



@GUI
Scenario: 40365_Verify the Cancel button functionality on the Delete document pop up modal
Given I am a Claims Specialist User
And I clicked on the hyperlink of any displayed claim on the Claim list
And I arrive on the Claim Details page of the selected claim
And I clicked on the Document Tab
And I click on the Delete Icon of any displayed document
When I click on the Cancel button on the delete document pop up 
Then the Delete modal should close
And the Document should remain attached to the document tab

@GUI
Scenario: 40365_Verify the Delete button functionality on the Delete document pop up modal
Given I am a Claims Specialist User
And I clicked on the hyperlink of any displayed claim on the Claim list
And I arrive on the Claim Details page of the selected claim
And I clicked on the Document Tab
And I click on the Delete Icon of any displayed document
When I click on the Delete button on the delete document pop up
Then the Delete modal should close
And the Document should be removed from the Document tab list

@GUI
Scenario: 40365_Verify the Delete Icon for Station Users
Given I am a sales, sales management, operations, or station owner
And I clicked on the hyperlink of any displayed claim on the Claim list for station users
And I arrive on the Claim Details page of the selected claim
When I click on the Document tab
Then I should not see the Delete Icon for the document associated with the selected claim
