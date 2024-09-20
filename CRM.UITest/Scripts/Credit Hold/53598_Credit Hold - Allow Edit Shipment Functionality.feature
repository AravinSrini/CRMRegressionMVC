@Sprint87 @53598 @Ignore
Feature: 53598_Credit Hold - Allow Edit Shipment Functionality

Scenario: 53598 : Verify Shipment edit functionality when user selects a Credit hold customer from the dropdown on Shipment list page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And I filtered the Shipment List to a customer that is on Credit Hold
	When I click on the <Edit Shipment> button of any displayed LTL shipment
	Then I will arrive on the Add Shipment (LTL) page
	And I will not receive a message indicating that the customer is on Credit Hold