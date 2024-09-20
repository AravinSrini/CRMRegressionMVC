@DomesticForwardingAddShipmentNavigation @32064 @Sprint77 @Regression
Feature: DomesticForwarding_AddShipment_Navigation


@GUI 
Scenario: 32064_Verify the navigation of Domestic forwarding from dashboard for Ship Entry user
Given I am Ship Entry user
When I Selected Domestic Forwarding and click on Create shipment from Dashboard 
Then I must land on the Add Shipment Location and Dates Page for Domestic forwarding 
And The Type selected must be displayed


@GUI 
Scenario: 32064_Verify the navigation of Domestic forwarding from dashboard for Ship Entry No rates user
Given I am Ship Entry No Rate user
When I Selected Domestic Forwarding and click on Create shipment from Dashboard 
Then I must land on the Add Shipment Location and Dates Page for Domestic forwarding 
And The Type selected must be displayed


@GUI 
Scenario: 32064_Verify the navigation of Domestic forwarding from shipment list page for Ship Entry User
Given I am Ship Entry user
When I selected Domestic Forwarding Tiles & Type and click on Continue Button from Add Shipment Tiles page 
Then I must land on the Add Shipment Location and Dates Page for Domestic forwarding 
And The Type selected must be displayed


@GUI 
Scenario: 32064_Verify the navigation of Domestic forwarding from shipment list page for Ship Entry No rates user
Given I am Ship Entry No Rate user
When I selected Domestic Forwarding Tiles & Type and click on Continue Button from Add Shipment Tiles page 
Then I must land on the Add Shipment Location and Dates Page for Domestic forwarding 
And The Type selected must be displayed



