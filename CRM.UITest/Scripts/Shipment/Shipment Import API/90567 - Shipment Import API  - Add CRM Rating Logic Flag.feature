@90567 @Regression @Sprint90
Feature: Shipment Import API  - Add CRM Rating Logic Flag

Scenario: 90567 - Verify the reference value of the created shipment is true when the shipment import method is called
	Given I am a third party integration customer: "GS - Ninja Customer"
	When I make a webservice call to the shipment "Import" method
	Then the shipment will be created in mercurygate with a reference type of CRMRL
	And the reference value will be true

Scenario: 90567 - Verify the reference value of the created shipment is true when the shipment importwithextract method is called
	Given I am a third party integration customer: "GS - Ninja Customer"
	When I make a webservice call to the shipment "ImportWithExtract" method
	Then the shipment will be created in mercurygate with a reference type of CRMRL
	And the reference value will be true
	
Scenario: 90567 - Verify the reference value of CRMRL is not added when using v2 when calling import
	Given I am a third party integration customer: "NinjaCustomer"
	When I make a webservice call to the shipment "Import" method
	Then the shipment will not be created in mercurygate with a reference type of CRMRL

Scenario: 90567 - Verify the reference value of CRMRL is not added when using v2 when calling import with extract
	Given I am a third party integration customer: "NinjaCustomer"
	When I make a webservice call to the shipment "ImportWithExtract" method
	Then the shipment will not be created in mercurygate with a reference type of CRMRL

Scenario Outline: 90567 - Verify no CRM rating logic reference is added to any calls to v1
	Given I am a third party integration customer <CustomerName>
	When I make a webservice call to the v1 shipment <MGMethod> method
	Then the shipment will not be created in mercurygate with a reference type of CRMRL
	Examples:
	| CustomerName        | MGMethod          |
	| NinjaCustomer       | Import            |
	| NinjaCustomer       | ImportWithExtract |
	| GS - Ninja Customer | Import            |
	| GS - Ninja Customer | ImportWithExtract |