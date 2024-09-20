@Sprint75 @34284
Feature: IntegrationListPage_AcceptOrDeny
	

@mytag
Scenario Outline:IntergrationApprove1->Verify the Approve button available after expanding the details of an Integration request list page
	Given I am a Sales Management or a System Admin user logged in with <Username> and <Password>
    When  I arrive on the Dashboard page
    And I click on Integration Menu
	And I select the status as Pending approval radio button
	And I expand the station details section
	Then I should see the approve button available
	Examples:
| Scenario | Username                   | Password | DashboardTitle |
| s1       |Systemadmin                 | Te$t1234 | Dashboard      |
| s2       |  SalesManager@stage.com    | Te$t1234 | Dashboard      |

Scenario Outline:IntegrationDeny2->Verify the Deny button available after expanding the details of an Integration request list page
	Given I am a Sales Management or a System Admin user logged in with <Username> and <Password>
    When  I arrive on the Dashboard page
    And I click on Integration Menu
	And I select the status as Pending approval radio button
	And I expand the station details section
	Then I should see the deny button available
		Examples:
| Scenario | Username                   | Password | DashboardTitle |
| s1       |Systemadmin                 | Te$t1234 | Dashboard      |
| s2       |  SalesManager@stage.com    | Te$t1234 | Dashboard      |




Scenario Outline:IntergrationApprove3-> Verify the Approve button functionality for admin and sales management users in details of an integration request Section
    Given I am a Sales Management or a System Admin user logged in with <Username> and <Password>
    When  I arrive on the Dashboard page
    And I click on Integration Menu
	And I select the status as Pending approval radio button
	And I expand the station details section
	And I click on Approve Button 
	Then Verify the status of the request will change from -Pending Regional Manager Approval to In Progress<WaitingStatus>

		Examples:

| Scenario | Username               | Password       | DashboardTitle| WaitingStatus |
| s1       | Systemadmin            | Te$t1234       | Dashboard     | In Progress: Waiting On Integration Team |


Scenario Outline:IntergrationApprove4-> Verify the Deny button functionality for admin and sales management users in details of an integration request Section
    Given I am a Sales Management or a System Admin user logged in with <Username> and <Password>
    When  I arrive on the Dashboard page
    And I click on Integration Menu
	And I select the status as Pending approval radio button
	And I expand the station details section
	And I click on Deny Button 
	Then the status of the request in the Integration List Page will change from Pending Regional Manager Approval to Completed status<CompletedStatus>


		Examples:

	| Scenario | Username    | Password | DashboardTitle | CompletedStatus         |
	| s1       | Systemadmin | Te$t1234 | Dashboard      | Completed: Denied       |




