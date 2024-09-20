@Sprint88 @73206
Feature: 73206 - Credit Hold Modal closes when clicking outside the modal (Station Users)

Scenario: 73206_Verify that the Credit Hold pop up doesn't close on clicking outside the pop up - Direct Quote
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Quote list page
	And I click on Submit Rate Request button for the Credit Hold Customer
	When I click out side the Credit Hold modal pop up
	Then Credit Hold modal pop up should not close

Scenario: 73206_Verify that the Credit Hold pop up doesn't close on clicking outside the pop up - Direct Shipment
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And I click on Add Shipment button for the Credit Hold Customer
	When I click out side the Credit Hold modal pop up
	Then Credit Hold modal pop up should not close

Scenario: 73206_Verify that the Credit Hold pop up doesn't close on clicking outside the pop up - Copy Shipment
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And I click on Copy Shipment button for the Credit Hold Customer
	When I click out side the Credit Hold modal pop up
	Then Credit Hold modal pop up should not close

Scenario: 73206_Verify that the Credit Hold pop up doesn't close on clicking outside the pop up - Return Shipment
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And I click on Return Shipment button for the Credit Hold Customer
	When I click out side the Credit Hold modal pop up
	Then Credit Hold modal pop up should not close

Scenario: 73206_Verify that the Credit Hold pop up doesn't close on clicking outside the pop up - Re-Quote
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Quote List page
	And I click on Re-Quote button for the Credit Hold Customer
	When I click out side the Credit Hold modal pop up
	Then Credit Hold modal pop up should not close

Scenario: 73206_Verify that the Credit Hold pop up doesn't close on clicking outside the pop up - Saved Quote to Shipment
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Quote List page
	And I click on the Create Shipment button for the Credit Hold Customer
	When I click out side the Credit Hold modal pop up
	Then Credit Hold modal pop up should not close

Scenario: 73206_Verify that the Credit Hold pop up doesn't close on clicking outside the pop up for customer user
	Given I am a shp.inquiry, shp.entrynorates or shp.entry user associated to a customer that is on Credit Hold
	And I successfully logged in to CRM
	When I click out side the Credit Hold modal pop up on Dashboard
	Then Credit Hold modal pop up should not close on Dashboard