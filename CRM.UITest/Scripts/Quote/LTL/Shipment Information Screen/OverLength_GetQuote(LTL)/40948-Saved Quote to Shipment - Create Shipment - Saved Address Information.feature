@Sprint81 @40948
Feature: 40948-Saved Quote to Shipment - Create Shipment - Saved Address Information
	
@Regression 
Scenario: 1)40948-Verify the Shp.From Address Prepopulated and the Shp.From fields are not editable for saved Shp.From address Quote
	Given I am a shp.entry, operations, sales, sales management or a station user
	And the Saved Quote contained a Saved Address in the Shipping From section
	When I arrive on the Add Shipment(LTL) page,
	Then I will see Saved Address will be PrePopulated in the Shipping from section
	And I will see Shipping From section fields are Non Editable
	And I will see Comment field of Shipping from section is Editable
	And I will see Shipping From Contact section fields are Editable

@Regression 
Scenario: 2)40948-Verify the Shp.To Address Prepopulated,Shp.From fields are not editable for saved Shp.To address Quote
	Given I am a shp.entry, operations, sales, sales management or a station user
	And the Saved Quote contained a Saved Address in the Shipping To section
	When I arrive on the Add Shipment(LTL) page,
	Then I will see Saved Address will be PrePopulated in the Shipping To section
	And I will see Shipping To section fields are Non Editable
	And I will see Comment field of Shipping To section is Editable
	And I will see Shipping To Contact section fields are Editable

@Regression 
Scenario: 3)40948-Verify the Shp.From Address Prepopulated,Shipping From fields are not editable for saved Default Shp.From address Quote
	Given I am a shp.entry, operations, sales, sales management or a station user
	And the Saved Quote contained a Saved Default Shipper Address in the Shipping From section
	When I arrive on the Add Shipment(LTL) page for Default Shipper Address,
	Then I will see Default Shipper Address will be PrePopulated in the Shipping from section
	And I will see Default Shipper Address Shipping From section fields are Non Editable
	And I will see Default Shipper Address Comment field of Shipping from section is Editable
	And I will see Default Shipper Address of Shipping From Contact section fields are Editable

@Regression 
Scenario: 4)40948-Verify the Shp.To Address Prepopulated,Shipping To fields are not Editable for the Saved Default Shp.To address Quote
	Given I am a shp.entry, operations, sales, sales management or a station user
	And the Saved Quote contained a Saved Default Consignee Address in the Shipping To section
	When I arrive on the Add Shipment(LTL) page for Default Consignee Address,
	Then I will see Default Consignee Address will be PrePopulated in the Shipping To section
	And I will see Default Consignee Address in Shipping To section fields are Non Editable
	And I will see Default Consignee Address in Comment field of Shipping To section is Editable
	And I will see Default Consignee Address in Shipping To Contact section fields are Editable

