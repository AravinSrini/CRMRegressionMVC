@Sprint72 @34067
Feature: CarrierWebsiteLogins_BackButton

@GUI
Scenario Outline: 34067 - Verify the display of back to maintenance tools button for admin users
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Admin Carrier Website Logins page
	And the back to maintenance tools button is visible 
	When I click the back to maintenance tools button
	Then I will return to the maintenance tools page.

Examples: 
| Scenario | Username    | Password |
| S1       | systemadmin | Te$t1234 |
| S2       | pricuser    | Te$t1234 |

@GUI
Scenario Outline: 34067 - Verify the display of back to maintenance tools button for non admin users
	Given I am a Operations, Station Owner or System Configuration user - <Username>, <Password>
	When I am on the non admin Carrier Website Logins page
	Then I will not see back to maintenance tools button.

Examples: 
| Scenario | Username         | Password |
| S1       | Stationown       | Te$t1234 |
| S2       | Opstage@user.com | Te$t1234 |
| S3       | admin            | Te$t1234 |