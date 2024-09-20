@39901 @Sprint77
Feature: PNC Launch - Allow Multiple Users
	
@Functional
Scenario Outline: 39901_Test to verify Multiple users login to PNC url with claim
	Given I am any user access to PNC Icon
	When I Launch PNC portal
	Then I should able to login to PNC portal with my CRM Email <userName> as PNC user

	Examples: 
	| userName |
	|   both   |

@Functional	
Scenario Outline: 39901_Test to verify Multiple users login to PNC url without claim
	Given I am any user access to PNC Icon without claim
	When I Launch PNC portal
	Then I should able to login to PNC portal with my CRM Email <userName> as PNC user
	
	Examples: 
	| userName |
	|zzzext    |