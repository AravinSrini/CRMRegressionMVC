@Sprint78 @Ignore
Feature: BFSC Calculation
	
@Regression
Scenario: 30568 - Verify Bump fuel surcharge calculations in quote results page
	Given I am an DLS user who have access to the application
	And I pass values to all the required fields in the quotes information page
	When I Click on view rates and arrive on quotes results page
	Then BFSC will be calculated
	And The displayed carrier fuel surcharge value in UI of quote result page should match with calculated BFSC value

	