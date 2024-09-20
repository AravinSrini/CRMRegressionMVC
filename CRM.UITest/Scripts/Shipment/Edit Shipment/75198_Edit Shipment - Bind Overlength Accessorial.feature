@75198 @Sprint91

Feature: 75198_Edit Shipment - Bind Overlength Accessorial


Scenario Outline: 75198- Verify Overlength accessorial is binding on Edit Shipment
	Given I am a shp.entry , usersales, sales management, operations, or stationowner <UserType> user
	And I am on the <Customer> shipment List page for <UserType> user
	And I clicked on the <UserType> Edit button of any displayed LTL shipment,which had an (Overlength) accessorial,
	When I arrive on the Add Shipment (LTL) page,
	Then the (Overlength) accessorial will be displayed in the (Click to add services & accessorials...) field of the (Shipping From) section.
Examples: 
| UserType | Customer                 |
| External | ZZZ - Czar Customer Test |
| Internal | ZZZ - Czar Customer Test   |
| Sales    | ZZZ - Czar Customer Test   |


