@47061 @Sprint86

Feature: 47061 - Credit Hold - Shipment (LTL) - Customer
	
Scenario: 47061 - Verify the Create Shipment button when user is associated to a customer that is on Credit Hold
Given I am a shp.entry or shp.entrynorates user associated to a customer that is on Credit Hold
When I arrive on Dashboard page
Then the Create Shipment button should be Inactive

Scenario: 47061 - Verify the Add Shipment, Copy Shipment and Return Shipment button when user is associated to a customer that is on Credit Hold
Given I am a shp.entry or shp.entrynorates user associated to a customer that is on Credit Hold
When I am on the Shipment List page
Then the Add Shipment button should be Inactive
And I will not see the Copy Shipment button for any displayed LTL shipment
And I will not see the Return Shipment button for any displayed LTL shipment

Scenario: 47061 - Verify the message when I hover over Inactive Create Shipment button on the Dashboard page
Given I am a shp.entry or shp.entrynorates user associated to a customer that is on Credit Hold
And I am on the Dashboard page
When I hover over the inactive Create Shipment button
Then I will see a hover over message as 'Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.' on Dashboard Page

Scenario: 47061 - Verify the message when I hover over Inactive Create Shipment button on the Shipment List page
Given I am a shp.entry or shp.entrynorates user associated to a customer that is on Credit Hold
And I am on the Shipment List page
When I hover over the inactive Add Shipment button
Then I will see a hover over message as 'Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.' on Shipment List page

Scenario: 47061 - Verify user should not see the message when I hover over Active Create Shipment button on the Dashboard page
Given I am a ship.entry or ship.entrynorates user associated to a customer that is not on Credit Hold
And I am on the Dashboard page
When I hover over the active Create Shipment button
Then I should not see a hover over message as 'Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.' on Dashboard Page

Scenario: 47061 - Verify user should not see the message when I hover over Active Add Shipment button on the Shipment List page
Given I am a ship.entry or ship.entrynorates user associated to a customer that is not on Credit Hold
And I am on the Shipment List page
When I hover over the active Add Shipment button
Then I should not see a hover over message as 'Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.' on Shipment List page


