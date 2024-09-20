@Sprint84 @40288 
Feature: Insurance Claims - History Tab - Elements

@GUI @Acceptance
Scenario:40288_Test to verify the History tab elements_claim details
Given I am a Sales, Sales Management,Operations, Station Owner, or Claims Specialist user
And I am on the Claim Detailspage of new submitted claim
When History Tab is clicked
And I will add data to the grid 
Then I will see a grid displaying the Date/Time in mm/dd/yyyy hh:mm format
And the grid will display Updated By with CRM first name and last name of user that added,updated status,history entry
And the grid will display Category
And the grid will display Comment with scroll bar when comments too large for field
And the grid will display status and comment updates
And the status and comment updates will display in chronlogical order and the most recent as the first entry at the top of the page

@GUI @Acceptance
Scenario:40288_Test to verify the View More hyperlink when comment is greater than 75 characters_History tab elements_claim details
Given I am a Sales, Sales Management,Operations, Station Owner, or Claims Specialist user
And I am on Claim Details page
And I clicked on the History tab
When The Comment of any displayed status/history entry is greater than 75 characters
Then I  will see a'...View More' hyperlink

@GUI @Acceptance @Functional
Scenario:40288_Test to verify the click functionality of View More hyperlink 
Given I am a Sales, Sales Management,Operations, Station Owner, or Claims Specialist user
And I am on the Claim Detailspage of new submitted claim
When History Tab is clicked
And I will add data to the grid 
And I click <...View More> hyperlink of any displayed Comment that is greater than 75 characters
Then I will see the entire comment including original 75 characters

