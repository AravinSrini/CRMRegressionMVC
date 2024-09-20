@Sprint78 @Ignore
Feature: SLH Calculation

@Regression
Scenario: 30571 - Verify surge line haul calculations on quote results page
	Given I am an DLS user who have access to the application
	And I pass values to all the required fields in the quotes information page
	When I Click on view rates and arrive on quotes results page
	Then SLH will be calculated
	And The displayed carrier SLH value in UI of quote result page should match with calculated SLH value

	
