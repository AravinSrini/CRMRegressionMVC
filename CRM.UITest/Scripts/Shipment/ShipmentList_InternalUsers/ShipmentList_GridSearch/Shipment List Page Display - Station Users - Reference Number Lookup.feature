@40578 @Sprint77 
Feature: Shipment List Page Display - Station Users - Reference Number Lookup

@Functional
Scenario Outline: Verify search shipment field dropdown options for Station users
Given I am an operations, sales, sales management, or station owner user
When I have searched <referencenumbers> in the Reference Number Lookup field on shipmentlist page
Then I should displayed with shipments<referencenumbers> mapped to the user 
And customer dropdown selection will be set to Select


Examples: 
| referencenumbers |
|zzx00208740       |


@Functional
Scenario Outline: Verify search shipment field dropdown options for Station users for inactive customers
Given I am an operations, sales, sales management, or station owner user
When I searched <referencenumbers> of Inactivecustomer in the Reference Number Lookup field on shipmentlist page
Then I should displayed with shipments<referencenumbers> mapped to the user
And Copy Shipment icon,Create Return Shipment icon,Edit Shipment icon will be disabled


Examples: 
| referencenumbers       |
|ZZX00208390,ZZX00208412 |



