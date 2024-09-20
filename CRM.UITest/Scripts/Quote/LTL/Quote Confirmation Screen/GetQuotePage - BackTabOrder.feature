@Sprint77 @38084
Feature: GetQuotePage - BackTabOrder
	
@Regression
Scenario: Verify back tab order for ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am in Get quote page
	When focus on 'View Quote Results button' and I do back tab
	Then the tab order will be from View Quote Results button to Enter zip/postal code

@Regression
Scenario: Verify back tab order for shpInquiry user
	Given I have logged in as a shpInquiry user
	And I am in Get quote page
	When focus on 'View Quote Results button' and I do back tab
	Then the tab order will be from View Quote Results button to Enter zip/postal code

@Regression
Scenario: Verify back tab order for Stationowner 
	Given I have logged in as a station owner
	And I am in Get quote page as a internal user
	When focus on 'View Quote Results button' and I do back tab
	Then the tab order will be from View Quote Results button to Enter zip/postal code

@Regression
Scenario: Verify back tab order for sales management 
	Given I have logged in as a sales management
	And I am in Get quote page as a internal user
	When focus on 'View Quote Results button' and I do back tab
	Then the tab order will be from View Quote Results button to Enter zip/postal code

@Regression
Scenario: Verify back tab order for operations 
	Given I have logged in as a sales operations
	And I am in Get quote page as a internal user
	When focus on 'View Quote Results button' and I do back tab
	Then the tab order will be from View Quote Results button to Enter zip/postal code

