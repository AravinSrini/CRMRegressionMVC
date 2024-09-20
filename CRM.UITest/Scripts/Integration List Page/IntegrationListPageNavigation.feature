@34270 @Sprint 75
Feature: IntegrationListPageNavigation
	

@Functional @UI
Scenario Outline: IntegrationListNavigation ->Verify the user is able to navigate to the Integrationg List Page successfully
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on Integration Menu
	Then I should be navigated to the Integration Request List Page with title <IntegrationPageTitle>

	Examples: 
| Username         | Password | DashboardTitle | IntegrationPageTitle     |
| stationown@stage.com | Te$t1234 | Dashboard      | Integration Request List |