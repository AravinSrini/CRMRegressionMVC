@30352 @Sprint71 @API
Feature: ShipmentList_MVC5_DisplayShipmentsbyStation_StationUsers

@GUI
Scenario Outline: 30352_Verify the station selection option in customer list dropdown
Given I am an operations, sales, sales management, or station owner user <Username>, <Password>
And I am on the Shipment List page 
When I click on Customer List dropdown arrow
Then I have the option to select station <station>

Examples: 
| Scenario | Username     | Password | station              |
| s1       | crmoperation | Te$t1234 | ENT - Bolingbrook IL |

@GUI @DBVerification
Scenario Outline: 30352_Verify the Station selection functionality for internal non admin users except sales
Given I am an operations, sales, sales management, or station owner user <Username>, <Password>
And I am on the Shipment List page 
When I click on Customer List dropdown arrow
And I select a station <stationName>
Then shipment list page will be refreshed to display shipments for the past 30days for the customers associated to the selected station <stationName>
And Add shipment button is not visible

Examples: 
| Scenario | Username     | Password | stationName             |
| s1       | crmoperation | Te$t1234 | ENT - Bolingbrook IL    |
#| s2       | crmoperation | Te$t1234 | ZZZ - Web Services Test |

@GUI @DBVerification
Scenario Outline: 30352_Verify the Station selection functionality for sales user
Given I am sales user <Username>, <Password>
And I am on the Shipment List page 
When I click on Customer List dropdown arrow
And I select a station <stationName>
Then shipment list page will refresh to display shipments for the past 30days for the customers associated to <mappedCustomers>
And Add shipment button is not visible

Examples: 
| Scenario | Username    | Password | stationName             | mappedCustomers          |
| s1       | crmsalesusr | Te$t1234 | ZZZ - Web Services Test | ZZZ - Czar Customer Test |