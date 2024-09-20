@PrioritySprint2 @50345 @GUI
Feature: ShipmentList _ShowLoadingIconWhenSearchingReferenceNumber

Scenario: 50345_Verify the appearance of Loading icon when i search for any Shipment of Customer with SubAccount i am Associated
Given I am a User with access to Shipment List page
And I am on the Shipment List page
When I search for any shipment of a customer with a sub-account that I am associated to on the reference number input
Then I will see the loading icon

Scenario: 50345_Verify the Loading icon disappears when the CRM receives the results from that search
Given I am a User with access to Shipment List page
And I am on the Shipment List page
And I searched for any shipment of a customer with a sub-account that I am associated to on the reference number input
When CRM receives the results from that search
Then I will see the loading icon will be hidden
And the results will show in the table

@Sprint93 @111076 @Ignore
Scenario Outline:111076_Verify the loading overlay in shiplist screen while page is loading
Given I am a user and login into application with valid <Username> and <Password>,
When I click the Shipment List Icon on the navigation menu
Then I will see a loading overlay while the page is loading

Examples: 
| Username                         | Password                         |
| username-CurrentSprintOperations | password-CurrentSprintOperations |
| username-CurrentSprintSales      | password-CurrentSprintSales      |
| username-CurrentSprintshpentry   | password-CurrentSprintshpentry   | 

@Sprint93 @111076 @Ignore
Scenario Outline:111076_Verify the loading overlay in shiplist screen when page is loaded
Given I am a user and login into application with valid <Username> and <Password>,
When I click the Shipment List Icon on the navigation menu
And the page is loaded
Then I will no longer see the loading overlay

Examples: 
| Username                         | Password                         |
| username-CurrentSprintOperations | password-CurrentSprintOperations |
| username-CurrentSprintSales      | password-CurrentSprintSales      |
| username-CurrentSprintshpentry   | password-CurrentSprintshpentry   | 