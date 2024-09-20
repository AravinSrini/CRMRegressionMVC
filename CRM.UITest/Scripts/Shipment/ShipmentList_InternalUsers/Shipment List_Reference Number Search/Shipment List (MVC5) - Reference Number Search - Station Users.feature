@29342 @Sprint70
Feature: Shipment List (MVC5) - Reference Number Search - Station Users
	
@Functional
Scenario Outline: Verify the results of reference number search when user selected all customers
Given I am an operations, sales, sales management, or station owner user <Username>, <Password>
And I am on the Shipment List page 
And All Customers is selected
And I enter the '<Ref>' in Reference Number lookup field
When I click on search arrow of Reference Number lookup
Then I should be displayed with the results for the entered valid reference numbers '<Ref>'

Examples: 
| Scenario | Username     | Password | Ref                                                            |
| s1       | crmOperation | Te$t1234 | PIT01217982,ZZS10564,890890890,9989098789,5432109876,789076780 |
