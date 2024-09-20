@PrioritySprint2 @49647
Feature: ShipmentList_SearchResultsforSubAccountShipments


	 @Functional
	 Scenario Outline: 49647_Verify Search Results for the Sub-Account Shipments
	 Given I'm a CRM User with access to Shipment List<Usertype>
	 And I am on the Shipment List page
	 When I search for any sub account shipment with  that I am associated to <referencenumber>
	 Then I will see the Shipment List related to that Sub-Customer<Usertype>
	 Examples: 
	 | Usertype  | referencenumber                                                         |
	 | External  | ZZX00209993,ZZX00209939,ZZX00209941,ZZX00209947,ZZX00209948,ZZX00209949 |
	 | Internal  | ZZX00209993,ZZX00209939,ZZX00209941,ZZX00209947,ZZX00209948,ZZX00209949  |
	 | Sales     | ZZX00209993,ZZX00209939,ZZX00209941,ZZX00209947,ZZX00209948,ZZX00209949 |
