Feature: InsuranceClaims_Amend Validation_95532
	To verify whether "required field(s) missing information will be highlighted in red" when mandatory fields are not entered.
	To verify whether error message "Leaving this page will not update the claim.  Are you sure you want to leave this page?" on clicking button "Back to Claims List" without submitting.
	To verify whether on clicking "yes" user navigated to claim list page, when clicking button "Back to Claims List" without submitting.
	To verify whether on clicking "No" the modal closes, when clicking button "Back to Claims List" without submitting.

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
