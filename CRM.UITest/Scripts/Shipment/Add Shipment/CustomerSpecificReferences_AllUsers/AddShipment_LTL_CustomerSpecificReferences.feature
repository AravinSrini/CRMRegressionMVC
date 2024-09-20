@CustomerSpecificReferences @Sprint69 @28049 @27401 
Feature: AddShipment_LTL_CustomerSpecificReferences

@GUI 
Scenario: Verify the customer specific references fields in Add Shipment page for Operations, Sales, Sales management, Station Owner, ShipEntry and ShipEntryNoRates users when Customer associated with customer speific references
	Given I am a shp.entry,shp.entrynorates user
	When I click on the Shipment Icon
	And I click on addshipment button
	And I Select the LTL tile
	And I arrive on the Add Shipment Ltl page
	And I expand the Reference Numbers Section
	Then I can see the Customer Specific References Move Type and Inventory Location Type drop downs
 
@GUI
Scenario: Verify the customer specific references are the required fields in Add Shipment page 
	Given I am a shp.entry,shp.entrynorates user
	When I click on the Shipment Icon
	And I click on addshipment button
	And I Select the LTL tile
	And I arrive on the Add Shipment Ltl page
	And I expand the Reference Numbers Section	
	Then Customer specific references Move Type and Inventory Location Types are the required fields


@GUI 
Scenario: Verify the Move Type and Inventory references drop down options in Add Shipment page 
	Given I am a shp.entry,shp.entrynorates user
	When I click on the Shipment Icon
	And I click on addshipment button
	And I Select the LTL tile
	And I arrive on the Add Shipment Ltl page
	And I expand the Reference Numbers Section
	And I click on the Move Type drop down
	Then I can the see the drop down options of Move Type 
	And I click on the Inventory Type drop down
	And I can see the drop down options of Inventory Location Type 

@GUI 
Scenario: Verify the customer specific references fields in Add Shipment page when user is not associated to any customer with customer specific references
	Given I am a shp.entry,shp.entrynorates user
	When I click on the Shipment Icon
	And I click on addshipment button
	And I Select the LTL tile
	And I arrive on the Add Shipment Ltl page
	And I expand the Reference Numbers Section
	Then I can see not the Customer Specific References Move Type and Inventory Location Type drop downs


