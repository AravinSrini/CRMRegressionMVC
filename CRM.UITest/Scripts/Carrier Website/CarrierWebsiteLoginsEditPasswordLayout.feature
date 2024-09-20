@Sprint72 @30608
Feature: CarrierWebsiteLoginsEditPasswordLayout

@GUI
Scenario Outline: 30608 - Verify the edit password popup 
	Given I am a System Admin or Pricing Configuration user - <Username>, <Passoword>
	When I am on the Carrier Website Logins Edit Password page
	Then I will see the "Edit Password" title
	And I will see an input field with the current password value 
	And I will see an option to Cancel
	And I will see an option to Save

Examples: 
| Scenario | Username    | Passoword |
| S1       | systemadmin | Te$t1234  |
| S2       | pricuser    | Te$t1234  |