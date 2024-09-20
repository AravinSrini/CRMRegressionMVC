@36572 @NotAutomated @Regression @Sprint75 @Ignore
Feature: International_Add Shipment_Shipment_On_ShipmentList
	

@Functional
Scenario Outline: 36572 - Verify Created Shipment in Shipment list page
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	And I selected International service for shipment creation<Type>,<level>
	And I created the International Shipment<OName>,<OAddress>,<OCountry>,<OCity>,<OState>,<OZip>,<DName>,<DAddress>,<DCountry>,<DCity>,<DState>,<DZip>,<Pieces>,<Weight>,<Length>,<Width>,<Height>,<Description>,<CommercialInvoiceValue>
	When I am on the Shipment list page
	Then I will be able to see this created new Shipment

	Examples: 
| userName | password | Type         | level      | OName | OAddress  | OCountry      | OCity | OState | OZip  | DName | DAddress  | DCountry      | DCity | DState | DZip  | Pieces | Weight | Length | Width | Height | Description | CommercialInvoiceValue |
  | Both     |  | Air - Import | Air Direct | otest | oaddress1 | United States | Miami | FL     | 33126 | dtest | daddress1 | United States | Tempe | AZ     | 85282 | 2      | 4      | 6      | 8     | 10     | itemabcd    | 21                     |