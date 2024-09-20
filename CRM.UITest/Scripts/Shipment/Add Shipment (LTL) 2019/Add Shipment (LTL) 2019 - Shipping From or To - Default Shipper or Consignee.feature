
@76045 @Sprint90

Feature: Add Shipment (LTL) 2019 - Shipping From or To - Default Shipper or Consignee
	
Scenario Outline:  76045 - Verify the auto popup address information in Shipping From section
	Given I am a shp.entrynorates, sales, sales management, operations, or station owner user <UserType>
	When I arrive on the Add Shipment page <UserType>, <CustomerName>
	Then the address information will auto-populate in the following fields in the Shipping From section <CustomerName>
	Examples: 
	| UserType | CustomerName             |
	| Internal | ZZZ - Czar Customer Test |
	| External | ZZZ - Gs Customer Test   |
	| Sales    | ZZZ - Czar Customer Test |


Scenario Outline: 76045 - Verify the auto popup address information in Shipping To section
	Given I am a shp.entrynorates, sales, sales management, operations, or station owner user <UserType>
	When I arrive on the Add Shipment page <UserType>, <CustomerName>
	Then the address information will auto-populate in the following fields in the Shipping To section <CustomerName>
	Examples: 
	| UserType | CustomerName             |
	| Internal | ZZZ - Czar Customer Test |
	| External | ZZZ - Gs Customer Test   |
	| Sales    | ZZZ - Czar Customer Test |



