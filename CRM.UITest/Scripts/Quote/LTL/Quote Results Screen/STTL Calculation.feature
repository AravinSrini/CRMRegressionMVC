@Sprint78 @Ignore
Feature: STTL Calculation

@Regression
Scenario: 30574 - Verify Surge total when Surge value is greater than 0 in quote results page
    Given I am an DLS user who have access to the application
	And I pass values to all the required fields in the quotes information page
	When I Click on view rates and arrive on quotes results page
	Then STTL Value will be calculated
	And The displayed carrier STTL value in UI of quote result page should match with calculated STTL value
