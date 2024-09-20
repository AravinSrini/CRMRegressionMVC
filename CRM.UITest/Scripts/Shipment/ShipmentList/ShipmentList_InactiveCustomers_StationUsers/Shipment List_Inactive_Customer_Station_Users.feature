@34502 @Sprint74 
Feature: Shipment List_Inactive_Customer_Station_Users

@GUI
Scenario Outline:34502_Verify display of inactive customers in the Customer list dropdown for Station Users in Shipment list page
	Given I am a sales, sales management, operations, or stationowner user - <Username> and <Password>
	And I click on the Shipment Icon
	And I arrive on shipment list page
	When I click on Customer List dropdown 
	Then Inactive customers should be grayed out <StationData>

Examples: 
| Scenario | Username   | Password | StationData |
| S1       | stationown | Te$t1234 | BHM         |

@Functional
Scenario Outline:34502_Verify the functionality of Add shipment button for inactive Customer
	Given I am a sales, sales management, operations, or stationowner user - <Username> and <Password>
	And I click on the Shipment Icon
	And I arrive on shipment list page
	When I click on Customer List dropdown 
	And I select an inactive Customer from the dropdown list <Account>
	Then For a selected inactive customer the Add shipment button should be inactive 

Examples: 
| Scenario | Username   | Password | Account              |
| S1       | stationown | Te$t1234 | Test other option 02 |       

@Functional
Scenario Outline:34502_Verify the functionality of Copy and Return Shipment icon for inactive Customer
	Given I am a sales, sales management, operations, or stationowner user - <Username> and <Password>
	And I click on the Shipment Icon
	And I arrive on shipment list page
	When I click on Customer List dropdown 
	And I select an inactive Customer from the dropdown list <Account>
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then Shipment list grid will get loaded with shipments from past 30 days for the customer selected <Account>
	And Copy Shipment icon for any displayed LTL shipment will be disabled
	And Create Return Shipment icon for any displayed LTL shipment will be disabled.
	And Edit Shipment icon for any displayed LTL shipment will be disabled

Examples: 
| Scenario | Username   | Password | Account              | Option |
| S1       | stationown | Te$t1234 | Test other option 02 | ALL    |

