@Sprint67 @27948 @Ignore
Feature: QuoteDetails_CreateShipmentButton_ExternalUsers

@GUI
Scenario Outline: Verify the display of create shipment button for external users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button for external users
	When I arrive on quotes list page
	And I expand any new Quote in the Quote list page
	Then I should see create shipment button in quote details section

Examples: 
| Scenario | Username         | Password | 
| S1       | zzzcsa@stage.com | Te$t1234 | 

@GUI
Scenario Outline: Verify the functionality cancel button in CSA shipment confirmation popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button for external users
	When I arrive on quotes list page	
	And I expand any new Quote in the Quote list page
	And I click on create shipment button 
	Then Confirmation popup should be displayed
	And I click on Cancel button 
	And User should remain in quote list page

Examples: 
| Scenario | Username         | Password | 
| S1       | zzzcsa@stage.com | Te$t1234 | 


@Functional
Scenario Outline: Verify the functionality yes button in CSA shipment confirmation popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button for external users
	When I arrive on quotes list page
	And I expand any new Quote in the Quote list page
	And I click on create shipment button 
	Then Confirmation popup should be displayed
	And I click on Yes button 
	Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'

Examples: 
| Scenario | Username         | Password | QuoteConfirmationpageText |
| S1       | zzzcsa@stage.com | Te$t1234 | Quote Confirmation        |

@Functional
Scenario Outline: Verify the Create shipment functionality for MG shipments
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I expand any new Quote in the Quote list page
	And I click on create shipment button 
	Then User should be taken to the shipment location and dates page

Examples: 
| Scenario | Username        | Password |
| S1       | zzzext@user.com | Te$t1234 | 