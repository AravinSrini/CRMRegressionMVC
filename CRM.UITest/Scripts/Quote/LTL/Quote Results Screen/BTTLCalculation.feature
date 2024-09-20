@Sprint78 @Ignore
Feature: BTTLCalculation

@Regression
Scenario: 30570 - Verify the bump total charge calculations in quote results page when Bump value is greater than Zero
	Given I am an DLS user who have access to the application
	And I pass values to all the required fields in the quotes information page
	When I Click on view rates and arrive on quotes results page
	Then BTTL will be calculated
	And The displayed carrier total value in UI of quote result page should match with calculated BTTL value
