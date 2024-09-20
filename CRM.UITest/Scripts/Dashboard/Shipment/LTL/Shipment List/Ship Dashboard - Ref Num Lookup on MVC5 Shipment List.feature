@38449 @Sprint76
Feature: Ship Dashboard - Ref Num Lookup on MVC5 Shipment List

@Regression 
Scenario Outline:  Test to verify the Ref Num Lookup on Shipment List_MG
Given I am a shp.entry, shp.entrynorates, shp.inquiry, shp.inquirynorates mapped to MG customer
When I am searching <referencenumber> in the Reference Number Lookup field on dashboard
And I will arrive on a shipment list page 
Then Searched reference number will be displayed in the grid <referencenumber>

Examples: 
| referencenumber         |
| ZZX00208226,ZZX00208227 |



@Regression @fixed
Scenario Outline:  Test to verify the Ref Num Lookup on Shipment List_CSAandBoth
Given I am a shp.entry, shp.entrynorates, shp.inquiry, shp.inquirynorates mapped to both customer
When I am searching <referencenumber> in the Reference Number Lookup field on dashboard
And I will arrive on a shipment list page 
Then Searched reference number will be displayed in the grid <referencenumber>

Examples: 
| referencenumber |
| 8125124         |



