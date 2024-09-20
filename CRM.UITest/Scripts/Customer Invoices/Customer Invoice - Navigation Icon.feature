@41892 @Sprint78
Feature: Customer Invoice - Navigation Icon
	
@GUI @Acceptance
Scenario: 41892_Verify the Customer Invoices icon with claim
	Given that I am any user
	And I have been given access to view the Customer Invoice feature
	When I log into CRM
	Then I can view the Customer Invoice Icon in the left navigation pane


@GUI @Acceptance
Scenario: 41892_Verify the Customer Invoices icon_without claim
	Given that I am any user without claim
	And I have been not given access to view the Customer Invoice feature
	When I log into CRM
	Then I should not view the Customer Invoice Icon in the left navigation pane
