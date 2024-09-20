@Sprint78 @Ignore
Feature: SFSC Calculation
	
@Regression
Scenario: Verify Surge Fuel Surcharge as a station owner
	Given I am an DLS user who have access to the application
	And I pass values to all the required fields in the quotes information page
	When I Click on view rates and arrive on quotes results page
	Then SFSC value should be calculated
	And The displayed carrier total value in UI of quote result page should match with calculated SFSC value

