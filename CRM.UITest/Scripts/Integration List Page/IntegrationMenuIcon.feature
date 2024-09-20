@34269 @Sprint75 
Feature: IntegrationMenuIcon

Scenario Outline: IntegrationMenu1-> Verify the Integration Menu icon is visible in the dashboard Menu 

    Given I am a System admin, operations, sales, sales management or station owner user - <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	Then I should see the Integration Menu Icon available for the user<Username>

	Examples: 
| Scenario | Username | Password | DashboardTitle |
| s1       |Systemadmin | Te$t1234 | Dashboard      |
| s2       |  sales@test.com    | Te$t1234 | Dashboard      |
| s3      |stationowner@test.com | Te$t1234 | Dashboard      |
| s4      |crmOperation@user.com | Te$t1234 | Dashboard      |


Scenario Outline:IntegrationMenu2-> Verify the Integration Menu icon is not visible in the dashboard Menu 
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	Then I should not see the Integration Menu Icon available for the user

	Examples: 
| Scenario | Username | Password | DashboardTitle |
| s1       |shpentry@test.com | Te$t1234 | Dashboard      |

Scenario Outline: IntegrationMenu3->Verify the user can view the text Customer Integration when mouse hover on Intergation Menu icon
    Given I am a System admin, operations, sales, sales management or station owner user - <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle>
	And I Mouse hover the Integration Menu Icon available for the user
	Then I should see the text<Text> Customer Integration

	Examples: 
| Scenario | Username | Password | DashboardTitle | Text |
| s1       |Systemadmin | Te$t1234 | Dashboard      |Customer Integration |
| s2       |  sales@test.com    | Te$t1234 | Dashboard      |Customer Integration |
| s3      |stationowner@test.com | Te$t1234 | Dashboard      |Customer Integration |
| s4      |crmOperation@user.com | Te$t1234 | Dashboard      |Customer Integration |