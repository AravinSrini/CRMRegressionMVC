@48394
Feature: Saved Quote to Create Shipment - Default Pickup Date Change
	
@Functional
Scenario: 48394 - Verify the pickup date from add shipment page
	Given I am a shp.entry, operations, sales, sales management, or station owner user
	And I have created a quote 
	And I am in the Quote Details section of a non-expired LTL quote
	And I clicked on the Create Shipment button from quote list page
	When I arrive on the Add Shipment (LTL) page
	Then the Pickup Date will be defaulted to the Pickup Date entered during the Get Quote (LTL) process