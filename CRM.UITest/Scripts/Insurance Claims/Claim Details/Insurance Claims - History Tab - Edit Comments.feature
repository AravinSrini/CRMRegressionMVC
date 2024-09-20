@Sprint84 @46424
Feature: Insurance Claims - History Tab - Edit Comments

@GUI @Functional
Scenario: 46424_Verify the edit comment modal elements
Given I am a Claims Specialist user
And I am on Claim details page
And I clicked on the History Tab
When I click on the Edit icon of any editable comment
Then the Edit Comment modal will open
And I will see the Category field which is required,drop down list
And I will see the Comment which is required,alpha-numeric, spcial characters, max length 5,000 characters
And I will see the Cancel,save buttons

@GUI @Functional
Scenario: 46424_Verify the edit comment modal elements_Category options
Given I am a Claims Specialist user
And I am on Claim details page
And I clicked on the History Tab
And Edit Comment modal will be opened for any editable comment
When I click in the Category drop down field
Then I will see the list of category options
And the Category list isconfigurable

@GUI @Functional
Scenario: 46424_Verify Cancel button functionality_edit claim modal
Given I am a Claims Specialist user
And I am on Claim details page
And I clicked on the History Tab
And Edit Comment modal will be opened for any editable comment
When I click the Cancel button 
Then the modal will close and the comment will not be updated

@GUI @Functional
Scenario: 46424_Verify Error Message recieved for not providing required field_edit claim modal
Given I am a Claims Specialist user
And I am on Claim details page
And I clicked on the History Tab
And Edit Comment modal will be opened for any editable comment
And I have not completed all required fields for Edit Modal
When I click on the Save button in the Edit Modal
Then I will receive an error message <Please complete all required fields>
And the field(s) missing information will be highlighted in red

@GUI @Functional
Scenario: 46424_Verify save button functionality_edit claim modal
Given I am a Claims Specialist user
And I am on Claim details page
And I clicked on the History Tab
And Edit Comment modal will be opened for any editable comment
And I have completed all required fields 
When I click on the Save button in the Edit Modal
Then the modal will close and the comment will be updated with the changes
And the Date/Time will update to the current date and time and will be in Central Time Zone (US)
And CRM will record the  first name and last name of the user that edited the comment

