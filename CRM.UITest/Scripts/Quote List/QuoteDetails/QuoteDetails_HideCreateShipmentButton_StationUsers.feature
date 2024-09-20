@QuoteDetails_HideCreateShipmentButton @26528 @Sprint67 

Feature: QuoteDetails_HideCreateShipmentButton_StationUsers

@GUI
Scenario Outline: Verify the Create Shipment button is not displayed for the Station Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I expand any Quote in the Quote list page
	Then I should not be able to see the CreateShipment button in the Quote Details Section

Examples: 
| Scenario | Username              | Password | DashboardTitle | QuoteList_Header |
| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | Quote List       |

