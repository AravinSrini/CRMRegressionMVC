@47063 @Sprint86 @Regression
Feature: ShipmentList_CreditHoldShipment_LTL _Station.	


Scenario: 47063_Verify Credit Hold indicator in select drop down list for the the customer(for both Parent and sub Account) which is on credit hold
	Given that I am a sales, sales management, operation, or station owner user
    And I am on the shipment List page
	And I clicked in the Select drop down list
	When any associated customer has been placed on credit Hold
	Then I will see an indicator that the customer is on credit Hold
	

Scenario: 47063_Verify the message "The selected customer is on Credit Hold" when clicking on Add shipment button for the Credit hold customer
	Given that I am a sales, sales management, operation, or station owner user
	And I am on the Shipment List page
	And I clicked in the Select drop down list
	And I Selected a customer that is on Credit Hold
	When I clicked on the Add Shipment button
	Then I will receive a Message As The selected customer is on Credit Hold


Scenario Outline: 47063_Verify the message "The selected customer is on Credit Hold" when clicking on copy shipment or Return shipment in shipment for the credit hold customer
	Given that I am a sales, sales management, operation, or station owner user
	And I am on the Shipment List page
	And I clicked in the Select drop down list
	And I Selected a customer that is on Credit Hold
	And the Shipment List refreshed to display at least one shipment
	When I Click on the <button> of a displayed shipment
	Then I will receive a Message As The selected customer is on Credit Hold

	Examples: 
	 | button          |
	 | Copy Shipment   |
	 | Return Shipment |