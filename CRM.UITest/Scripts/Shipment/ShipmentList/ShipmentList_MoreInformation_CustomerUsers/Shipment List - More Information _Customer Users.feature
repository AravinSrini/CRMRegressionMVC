@Sprint68 @26806 
Feature: Shipment List - More Information _Customer Users

@GUI @Functional
Scenario Outline: Verify displayed fields under More Information icon for MG Shipments
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	And I click on More Information Icon for MG Shipment 
	Then I must be able to view the following fields - Quantity, Weight, Shipment Charge, Carrier

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

@GUI @Functional @Ignore
Scenario Outline: Verify displayed fields under More Information icon for CSA Shipments
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment button for external users
	When I arrive on Shipment list page
	And I click on More Information Icon for CSA Shipment	
	Then I must be able to view the following fields - Quantity, Weight, Service Type, Service Level, Shipment Charge

Examples: 
| Username         | Password |
| zzzcsa@stage.com | Te$t1234 | 


@Functioanl @Regression
Scenario Outline: Compare and verify the displayed values under More Information icon for MG Shipments with API
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	And I click on More Information Icon for MG Shipment
	Then The displayed Quantity, Weight, Shipment Charge and Carrier values should match with the API <Account>

Examples: 
| Username        | Password | Account                  | 
| zzzext@user.com | Te$t1234 | ZZZ - Czar Customer Test | 

@Functioanl @Regression @Ignore
Scenario Outline: Compare and verify the displayed values under More Information icon for CSA Shipments with API
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment button for external users
	When I arrive on Shipment list page
	And I click on More Information Icon for CSA Shipment
	Then The displayed Quantity, Weight, Service Type, Service Level and Est Cost values should match with the API <Account>

Examples: 
| Username         | Password | Account           | 
| zzzcsa@stage.com | Te$t1234 | Kim Manufacturing | 

	