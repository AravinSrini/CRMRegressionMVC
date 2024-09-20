@53598 @NinjaSprint28 @Regression
Feature: 53598 Credit Hold - Allow Edit Shipment Functionality

Scenario: 53598_Verify the Credit Hold Modal is not Displayed When a Customer on Credit Hold Edits a Shipment
Given I am a sales sales management operations or station owner user "username-CurrentsprintOperations" "password-CurrentsprintOperations"
And I navigate to the Shipment List page
And I search for a shipment using a reference number "ENT0041295719"
When I click on the edit shipment button of a shipment
Then I will be taken to the Add Shipment page
And I will not receive a message indicating that the customer is on Credit Hold
