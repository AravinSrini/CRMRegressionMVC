@Sprint88 @53757
Feature: Shipping Hours_Add Shipment_LTL
	
Scenario: 53757_Verify the "Ready" field and "Close" field in the Shipping From section when no address is selected in Shipping From section

	Given I am a DLS user with access to Shipments
	When I Am on the Add Shipment LTL page
	Then the Ready field of the Pickup Date section should be auto-populated with the Open Time of the Customer 
	And the Close field of the Pickup Date section should be auto-populated with the Close Time of the Customer	

Scenario Outline: 53757_Verify the "Ready" field and "Close" field in the "Shipping From" section when a "Saved Address" is selected in Shipping From section

	Given I am a DLS user with access to Shipments
	And I Am on the Add Shipment LTL page 
	When I Select a Saved Address in the Shipping From section <Saved Address> 
	Then the Ready field of the Pickup Date section should be auto-populated with the Open Time of the selected Saved address
	And the Close field of the Pickup Date section should be auto-populated with the Close Time of the selected Saved address

	Examples:
	| Saved Address       |
	| AIRGAS REFRIGERANTS |  

Scenario: 53757_Verify the "Ready" field and "Close" field in the "Shipping From" section when "Default Shipper Address" is selected in Shipping From section

	Given I am a DLS user with access to Shipments module
	And I Am on the Add Shipment LTL page
	When the Shipping From address is a Default Shipper address
	Then the Ready field of the Pickup Date section should be auto-populated with the Open Time of the Default Shipper address
	And the Close field of the Pickup Date section should be auto-populated with the Close Time of the Default Shipper address

Scenario: 53757_Verify the "Ready" field and "Close" field in the Shipping From section when a Shipment is returned

	Given I am a DLS user with access to Shipments module
	And I Am on the Shipment List page
	And I click on Return Shipment button for any shipment
	When I am on the Add Shipment LTL page of the shipment to be returned
	Then the Ready date field of the Pickup Date section should be auto-populated with the Open Time of the Customer
	And the Close date field of the Pickup Date section should be auto-populated with the Close Time of the Customer