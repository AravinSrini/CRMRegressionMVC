@59886 @Sprint94 
Feature: 59886_Terminal_Information_ShipmentList

Scenario Outline: 59886_Verify Terminal Info link in Shipmentlist page
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the shipment list page <user>
When the shipment list grid is displaying records,
Then each LTL shipment will have an option to display Terminal Information

Examples: 
	| user     | Username                         | Password                         |
	| Sales    | username-CurrentSprintSales      | password-CurrentSprintSales      |
	| External | username-CurrentSprintshpentry   | password-CurrentSprintshpentry   |
	| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations |


Scenario Outline: 59886_Verify Tool Tip of terminal information in shipmentlist page
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the shipment list page <user> 
When the shipment list grid is displaying records,
Then the newly added terminal information icon should have a tooltip “Terminal Information”
Examples: 
	| user     | Username                         | Password                         |
	| Sales    | username-CurrentSprintSales      | password-CurrentSprintSales      |
	| External | username-CurrentSprintshpentry   | password-CurrentSprintshpentry   |
	| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations |


Scenario Outline: 59886_Verify the Terminal Information
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the shipment list page <user> 
And the shipment list grid is displaying records,
When I click on the option to display terminal Information for a specific LTL record
Then a popup modal is launched to display the terminal information for selected record for shipment
And I will see a Close button in the Terminal info modal popup
Examples: 
	| user     | Username                         | Password                         |
	| Sales    | username-CurrentSprintSales      | password-CurrentSprintSales      |
	| External | username-CurrentSprintshpentry   | password-CurrentSprintshpentry   |
	| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations |


Scenario Outline: 59886_Verify the Close Button
Given I am a user and login into application with valid <Username> and <Password>,
And I am on the shipment list page <user> 
And the shipment list grid is displaying records,
And I click on the option to display terminal Information for a specific LTL record
And I will see a Close button in the Terminal info modal popup
When I click the button Close in the modal popup
Then the modal should be closed

Examples: 
	| user     | Username                         | Password                         |
	| Sales    | username-CurrentSprintSales      | password-CurrentSprintSales      |
	| External | username-CurrentSprintshpentry   | password-CurrentSprintshpentry   |
	| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations |
