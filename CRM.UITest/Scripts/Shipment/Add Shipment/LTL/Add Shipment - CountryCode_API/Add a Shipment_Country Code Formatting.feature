@49017 PrioritySprint2
Feature: Add a Shipment_Country Code Formatting

@Functional
Scenario: 49017 - Test to verify if Shipment in MG returns country as 'CANADA' when user submits a shipment with Country as Canada from shipper/consignor(From) section
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or Station Owner user
	And I am creating a Shipment for MG Shipment Service Type LTL
	And The Shipping From location country is Canada
	And I am on Review and Submit LTL Shipment page
	When I click "Submit Shipment" from the Review and Submit Shipment (LTL) page
	Then The shipment in MG should return shipper/consignor(From) section country as 'CANADA'

@Functional
Scenario: 49017 - Test to verify if Shipment in MG returns country as 'CANADA' when user submits a shipment with Country as Canada from Consignee (To) section
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or Station Owner user
	And I am creating a Shipment for MG Shipment Service Type LTL
	And The Shipping To location country is Canada
	And I am on Review and Submit LTL Shipment page
	When I click "Submit Shipment" from the Review and Submit Shipment (LTL) page
	Then The shipment in MG should return Consignee (To) section country as 'CANADA'

@Functional
Scenario: 49017 - Test to verify if Shipment in MG returns country as 'CANADA' when user submits a shipment with Country as Canada from shipper/consignor(From) and Consignee (To) section
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or Station Owner user
	And I am creating a Shipment for MG Shipment Service Type LTL
	And The Shipping From, Shipment To location country is Canada
	And I am on the Review and Submit (LTL) shipment page
	When I click "Submit Shipment" from the Review and Submit Shipment (LTL) page
	Then The shipment in MG should return shipper/consignor(From) section country as 'CANADA'
	And The shipment in MG should return Consignee (To) section country as 'CANADA'

@Functional
Scenario: 49017 - Test to verify if Shipment in MG returns country as 'CANADA' when user submits a shipment with Country as Canada from shipper/consignor(From) section via 3rd party
	Given I am a third party Integration customer set up in CRM with new CRM rating logic
	And I am creating a shipment where the ShippingFrom location country is Canada
	When I send the shipment import request
	Then The shipment in MG should return shipper/consignor(From) section country as 'CANADA' for the shipment created by third party

@Functional
Scenario: 49017 - Test to verify if Shipment in MG returns country as 'CANADA' when user submits a shipment with Country as Canada from Consignee (To) section via 3rd party
	Given I am a third party Integration customer set up in CRM with new CRM rating logic
	And I am creating a shipment where the ShippingTo location country is Canada
	When I send the shipment import request
	Then The shipment in MG should return Consignee (To) section country as 'CANADA' for the shipment created by third party

@Functional
Scenario: 49017 - Test to verify if Shipment in MG returns country as 'CANADA' when user submits a shipment with Country as Canada from shipper/consignor(From) and Consignee (To) section via 3rd party
	Given I am a third party Integration customer set up in CRM with new CRM rating logic
	And I am creating a shipment where the ShippingFrom, ShippingTo location country is Canada
	When I send the shipment import request
	Then The shipment in MG should return shipper/consignor(From) section country as 'CANADA' for the shipment created by third party
	And The shipment in MG should return Consignee (To) section country as 'CANADA' for the shipment created by third party

@Functional
Scenario: 49017 - Test to verify if Shipment in MG returns country as 'CANADA' when user submits a shipment with Country as Canada from shipper/consignor(From) section via 3rd party without rating logic
	Given I am a third party Integration customer set up in CRM without CRM rating logic
	And I am creating a shipment where the ShippingFrom location country is Canada
	When I send shipment import request
	Then The shipment in MG should return shipper/consignor(From) section country as 'CANADA' for the shipment created by third party

@Functional
Scenario: 49017 - Test to verify if Shipment in MG returns country as 'CANADA' when user submits a shipment with Country as Canada from Consignee (To) section via 3rd party without rating logic
	Given I am a third party Integration customer set up in CRM without CRM rating logic	
	And I am creating a shipment where the ShippingTo location country is Canada
	When I send shipment import request
	Then The shipment in MG should return Consignee (To) section country as 'CANADA' for the shipment created by third party

@Functional
Scenario: 49017 - Test to verify if Shipment in MG returns country as 'CANADA' when user submits a shipment with Country as Canada from shipper/consignor(From) and Consignee (To) section via 3rd party without rating logic
	Given I am a third party Integration customer set up in CRM without CRM rating logic
	And I am creating a shipment where the ShippingFrom, ShippingTo location country is Canada
	When I send shipment import request
	Then The shipment in MG should return shipper/consignor(From) section country as 'CANADA' for the shipment created by third party
	And The shipment in MG should return Consignee (To) section country as 'CANADA' for the shipment created by third party
