@QuoteListNavigation @26055 @26056 @Sprint67 
Feature: QuoteListNavigationIcon
	
@GUI 
Scenario Outline: Verify the Quote module is displayed for the non admin internal user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	Then I must be able to see the <Icontext> module in icon navbar

    Examples: 
	| Scenario | Username              | Password | DashboardTitle | Icontext |
	| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | Quotes   |

@GUI 
Scenario Outline: Verify the Navigation to the Quote List page for the non admin internal user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on the Quote Icon
	Then I should be navigated to the Quote List <QuoteList_Header>page

	Examples: 
	| Scenario | Username              | Password | DashboardTitle | QuoteList_Header |
	| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | Quote List       |