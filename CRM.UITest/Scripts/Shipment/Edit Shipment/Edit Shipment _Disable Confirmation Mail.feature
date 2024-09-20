@73982 @Sprint88
Feature: Edit Shipment - Disable Confirmation Mail

Scenario: 73982_Verify the message related to Email confirmation on Shipment Confirmation (LTL) page when edited shipment is submitted_InternalUser
	Given I am a DLS Internal user with access to Shipments
	And I Am on the ShipmentList page 
	And I click on the Edit button of any available LTL shipments
	And I click on the Submit Updated Shipment button on the Review and Submit Shipment (LTL) page
	When I arrive on the Shipment Confirmation (LTL) page
	Then I should not see the verbiage "You will receive a confirmation email shortly with the Bill of Lading attached"

Scenario: 73982_Verify the message related to Email confirmation on Shipment Confirmation (LTL) page when edited shipment is submitted_SalesUser
	Given I am a DLS Salesuser with access to Shipments
	And I Am on the ShipmentList page 
	And I click on the Edit button of any available LTL shipments
	And I click on the Submit Updated Shipment button on the Review and Submit Shipment (LTL) page
	When I arrive on the Shipment Confirmation (LTL) page
	Then I should not see the verbiage "You will receive a confirmation email shortly with the Bill of Lading attached"
