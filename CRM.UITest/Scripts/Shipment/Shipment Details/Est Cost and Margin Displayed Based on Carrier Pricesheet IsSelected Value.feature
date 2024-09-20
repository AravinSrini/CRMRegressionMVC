@60342 @NinjaSprint28 @Regression
Feature: 60342 - Est Cost & Est Margin - Carrier price sheet - is Selected

Scenario: 60342_Verify Est Cost And Margin is displayed based on carrier pricesheet with isSelected as false on the shipment details page
Given I am an internal CRM user "username-CurrentsprintOperations" "password-CurrentsprintOperations"
And I navigate to the Shipment List page
And I search for a shipment by reference number "ZZX002011739"
When I navigate to the shipment details page for the searched shipment
And I read the estimated cost and margin values of a shipment from the shipment details
Then the Est cost And Est Margin that are displayed in the shipment details are based on isSelected

Scenario: 60342_Verify Est Cost And Margin is displayed based on carrier pricesheet with isSelected as true on the shipment details page
Given I am an internal CRM user "username-CurrentsprintOperations" "password-CurrentsprintOperations"
And I navigate to the Shipment List page
And I search for a shipment by reference number "ZZX002011741"
When I navigate to the shipment details page for the searched shipment
And I read the estimated cost and margin values of a shipment from the shipment details
Then the Est cost And Est Margin that are displayed in the shipment details are based on isSelected