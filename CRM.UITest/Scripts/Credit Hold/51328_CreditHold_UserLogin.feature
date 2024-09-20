@51328 @Regression @Sprint86

Feature: 51328_CreditHold_UserLogin

Scenario: 51328 Verify the Credit Hold modal pop up UI elements
Given I am a shp.inquiry, shp.entrynorates or shp.entry user associated to a customer that is on Credit Hold
When I successfully login to CRM
Then I Will Receive A Message In a Modal "Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative."
And I Will See An OK Button


Scenario: 51328 Verify the Credit Hold modal will be closed click on OK button
Given I am a shp.inquiry, shp.entrynorates or shp.entry user associated to a customer that is on Credit Hold
And I successfully logged in to CRM
When I click on the OK button from the Credit Hold modal
Then The Credit Hold modal will close


Scenario: 51328 Verify the Credit Hold modal will not be appeared if logged user associated to a customer which is not in Credit Hold status
Given I am a shp.inquiry, shp.entrynorates or shp.entry user associated to a Non-Credit Hold customer
When I successfully login to CRM
Then I will not be presented with Credit Hold modal
