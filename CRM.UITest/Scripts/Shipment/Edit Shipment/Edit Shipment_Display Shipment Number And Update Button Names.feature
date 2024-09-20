@22023 @Sprint88
Feature: Edit Shipment_Display Shipment Number And Update Button Names
	
Scenario: 22023_Verify the Shipment number and the verbiage that displays on Add Shipment (LTL) page when editing a Shipment_InternalUser
	Given I am a DLS Internal user with access to Shipments
	And I am on the Shipment List Page
	And I click on the Edit button of any available LTL shipment
	When I arrive on the Add Shipment (LTL) page
	Then I should see verbiage below the Add Shipment (LTL) page title indicating the Shipment Number being edited

Scenario: 22023_Verify the Shipment number and the verbiage that displays on Shipment Results (LTL) page when editing a Shipment_InternalUser
	Given I am a DLS Internal user with access to Shipments
	And I am on the Shipment List Page
	And I click on the Edit button of any available LTL shipment
	When I arrive on the Shipment Results (LTL) page
	Then I should see verbiage below the Shipment Results page title indicating the Shipment Number being edited
	And I see Create Shipment button renamed to Update Shipment
	And I see Create Insured Shipment renamed to Update Insured Shipment

Scenario: 22023_Verify the Shipment number and the verbiage that displays on Review And Submit (LTL) page when editing a Shipment_InternalUser
	Given I am a DLS Internal user with access to Shipments
	And I am on the Shipment List Page
	And I click on the Edit button of any available LTL shipment
	When I arrive on the Review and Submit Shipment (LTL) page
	Then I should see verbiage below the Review And Submit page title indicating the Shipment Number being edited
	And I see Submit Shipment button renamed to Submit Updated Shipment

Scenario: 22023_Verify the Shipment number and the verbiage that displays on Add Shipment (LTL) page when editing a Shipment_SalesUser
	Given I am a DLS Sales user with access to Shipments
	And I am on the Shipment List Page
	And I click on the Edit button of any available LTL shipment
	When I arrive on the Add Shipment (LTL) page
	Then I should see verbiage below the Add Shipment (LTL) page title indicating the Shipment Number being edited

Scenario: 22023_Verify the Shipment number and the verbiage that displays on Shipment Results (LTL) page when editing a Shipment_SalesUser
	Given I am a DLS Sales user with access to Shipments
	And I am on the Shipment List Page
	And I click on the Edit button of any available LTL shipment
	When I arrive on the Shipment Results (LTL) page
	Then I should see verbiage below the Shipment Results page title indicating the Shipment Number being edited
	And I see Create Shipment button renamed to Update Shipment
	And I see Create Insured Shipment renamed to Update Insured Shipment

Scenario: 22023_Verify the Shipment number and the verbiage that displays on Review And Submit (LTL) page when editing a Shipment_SalesUser
	Given I am a DLS Sales user with access to Shipments
	And I am on the Shipment List Page
	And I click on the Edit button of any available LTL shipment
	When I arrive on the Review and Submit Shipment (LTL) page
	Then I should see verbiage below the Review And Submit page title indicating the Shipment Number being edited
	And I see Submit Shipment button renamed to Submit Updated Shipment
