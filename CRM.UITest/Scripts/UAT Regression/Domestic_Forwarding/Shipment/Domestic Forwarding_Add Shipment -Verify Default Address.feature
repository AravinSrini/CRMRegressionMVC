@32066 @Sprint71 @Regression
Feature: Domestic Forwarding_Add Shipment -Verify Default Address

@Functional	@Acceptance
Scenario Outline:32066-Verify default address in Origin Information section for ShipEntry Rates user
	Given I am shp entry Rate user
	When I am on the Add Shipment page for Domestic Forwarding and the customer has default origin address 
	Then The default address must be populated in the origin information section and it should match with the default address in DB - '<CustomerName>'

Examples: 
| CustomerName           |
| ZZZ - GS Customer Test |


@Functional	@Acceptance
Scenario Outline:32066-Verify default address in Origin Information section for ShipEntryNoRates user
	Given I am shp.entryNorates
	When I am on the Add Shipment page for Domestic Forwarding and the customer has default origin address 
	Then The default address must be populated in the origin information section and it should match with the default address in DB - '<CustomerName>'

Examples: 
 | CustomerName |
| Dunkin Donuts|

@Functional @Acceptance
Scenario Outline:32066-Verify default address in Destination Information section for ShipEntryNoRates User
	Given I am shp.entryNorates
	When I am on the Add Shipment page for Domestic Forwarding and the customer has default destination address 
	Then The default address must be populated in the destination information section and it should match with the default address in DB - <CustomerName>

Examples: 
| CustomerName           |
| Dunkin Donuts          |

@Functional @Acceptance
Scenario Outline:32066-Verify default address in Destination Information section
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	When I am on the Add Shipment page for Domestic Forwarding and the customer has default destination address 
	Then The default address must be populated in the destination information section and it should match with the default address in DB - <CustomerName>

Examples: 
| Username              | Password | CustomerName           |
| Both@test.com         | Te$t1234 | ZZZ - GS Customer Test |
