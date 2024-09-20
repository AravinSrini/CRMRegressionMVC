@Sprint84 @40719 
Feature: Insurance Claims - Payment Tab - Outstanding Amount Field
	
@GUI @Acceptance
Scenario: 40719 - Verify the field validation for Outstanding Amount field of Payment tab
Given I am a Claim Specialist user
And I am on the Claim Details page of the selected Claim
And I clicked on the Payments Tab
When I arrive on the Payments Tab
Then I should have an option to edit the Outstanding Amount field,
And The Outstanding Amount field should be optional,
And The Outstanding Amount field format should be currency,
And The Outstanding Amount field should allow upto two decimal places,
And The Outstanding Amount field should auto fill with $ and two decimal places

@Functional @DB
Scenario: 40719 - Verify if the edited Outstanding Amount is saved in DB onclick of Save Claim details button
Given I am a Claim Specialist user
And I am on the Claim Details page of the selected Claim
And I arrived on Payments Tab section by clicking on Payments Tab,
And I have edited Outstanding Amount 
When I Click on Save Claim Details
Then Entered Outstanding amount on payment tab should get updated in database

@GUI
Scenario: 40719 - Verify the behaviour of Claim details page when user tries to navigate away from claim details page without saving edited Outstanding amount
Given I am a Claim Specialist user
And I am on the Claim Details page of the selected Claim
And I arrived on Payments Tab section by clicking on Payments Tab,
And I have made edit to Outstanding amount field,
When I navigate away from the Claim Details page without clicking on Save Claim details button
Then I should be able to view 'Changes Not Saved' modal,
And The modal verbiage should display:'You have not saved your changes to the claim details. Would you like to save your changes before leaving this page?'
And A note should display:'Note: If you leave without saving you cannot get the changes back.'
And I should be able to view 'Leave Page Without Saving' button
And I should be able to view 'Return to Claim Details' button.

@Functional
Scenario: 40719 - Verify the functionality of "Return to Claim Details" button
Given I am a Claim Specialist user
And I am on the Claim Details page of the selected Claim
And The 'Changes Not Saved' modal is displayed,
When I click on Return to Claim Details button,
Then The modal should get closed.

@Functional
Scenario: 40719 - Verify the functionality of "Leave Page Without Saving" button
Given I am a Claim Specialist user
And I am on the Claim Details page of the selected Claim
And The 'Changes Not Saved' modal is displayed,
When I click on the Leave Page Without Saving button,
Then The modal should get closed
And I should be navigated away from the Claim Details page.







