@CRM_TMSLaunch_MG_WT @28166 @Sprint68 
Feature: CRM_TMSLaunch_MG_WT

@GUI
Scenario Outline: Verify the TMS launch icon and have the options MG and World Track for internal users 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	Then I must see the TMS Launch icon in left navigation bar
	And I see the MG and World Track options when mouse hover on TMS icon

    Examples: 
	| Scenario | Username          | Password | DashboardTitle |
	| S1       | crmOperation      | Te$t1234 | Dashboard      |
	| S2       | saleTest          | Te$t1234 | Dashboard      |
	| S3       | stationowner      | Te$t1234 | Dashboard      |
	| S4       | crmsalesusr       | Te$t1234 | Dashboard      |
	| S5       | systemadmin       | Te$t1234 | Dashboard      |
	| S6       | jtest@pricing.com | Te$t1234 | Dashboard      |
	| S7       | jtest@config.com  | Te$t1234 |Dashboard       |


@GUI @Ignore
Scenario Outline: Verify the MG TMS option click functionality for internal users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And  I mouser hover on TMS launch and click on MG option
	Then I must navigated to the Mercury Gate page

	Examples: 
	| Scenario | Username          | Password | DashboardTitle |
	| S1       | crmOperation      | Te$t1234 | Dashboard      |
	| S2       | saleTest          | Te$t1234 | Dashboard      |
	| S3       | stationowner      | Te$t1234 | Dashboard      |
	| S4       | crmsalesusr       | Te$t1234 | Dashboard      |
	| S5       | systemadmin       | Te$t1234 | Dashboard      |
	| S6       | jtest@pricing.com | Te$t1234 | Dashboard      |
	| S7       | jtest@config.com  | Te$t1234 |Dashboard       |

@GUI 
Scenario Outline: Verify the World Track option click functionality for internal users 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And  I mouser hover on TMS launch and click on World Track option
	Then I must navigated to the World Track page

	Examples: 
	| Scenario | Username          | Password | DashboardTitle |
	| S1       | crmOperation      | Te$t1234 | Dashboard      |
	| S2       | saleTest          | Te$t1234 | Dashboard      |
	| S3       | stationowner      | Te$t1234 | Dashboard      |
	| S4       | crmsalesusr       | Te$t1234 | Dashboard      |
	| S5       | systemadmin       | Te$t1234 | Dashboard      |
	| S6       | jtest@pricing.com | Te$t1234 | Dashboard      |
	| S7       | jtest@config.com  | Te$t1234 |Dashboard       |


