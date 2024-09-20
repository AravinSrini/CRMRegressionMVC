@Sprint78 @Ignore
Feature: BLH Calculation

@Regression
Scenario: 30567-Verify Bump Linehaul when Bump has a value greater than Zero in the quotes results page
	Given I am an DLS user who have access to the application
	And I pass values to all the required fields in the quotes information page
	When I Click on view rates and arrive on quotes results page
	Then BLH value will be calculated
	And Calculated BLH value should match with the displayed Linehaul value in the quotes results page 
	