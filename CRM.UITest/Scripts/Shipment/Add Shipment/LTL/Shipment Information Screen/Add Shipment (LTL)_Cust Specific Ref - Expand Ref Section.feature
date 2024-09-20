@31795 @Sprint71 
Feature: Add Shipment (LTL)_Cust Specific Ref - Expand Ref Section

@GUI
Scenario Outline:31795-Verify Reference number section for customers with customer specific references
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	When I arrive on the Add Shipment (LTL) page - <Usertype> , <CustomerName>
	Then The Reference Numbers section will be expanded.

Examples: 
| Scenario | Username           | Password    | Usertype | CustomerName             |
| S1       | entry.allstate     | Connect@123 |          |                          |
| S2       | station.allstate   | Connect@123 | Internal | All States Ag Parts - WI |
| S3       | NoRatesRef@crm.com | Te$t1234    |          |                          |
| S4       | OperRef@crm.com    | Te$t1234    | Internal | All States Ag Parts - WI |
| S5       | RefSales@crm.com   | Te$t1234    | Internal | All States Ag Parts - WI |

@GUI
Scenario Outline:31795-Verify Reference number section for customers without customer specific references
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	When I arrive on the Add Shipment (LTL) page - <Usertype> , <CustomerName>
	Then The Reference Numbers section will be collapsed.

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName             |
| S1       | shp.entry             | Te$t1234 |          |                          |
| S2       | stationown            | Te$t1234 | Internal | ZZZ - GS Customer Test   |
| S3       | Entyrnorates@test.com | Te$t1234 |          |                          |
| S4       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test |
| S5       | kavyarao.ms           | Te$t1234 | Internal | Dunkin Donuts            |
