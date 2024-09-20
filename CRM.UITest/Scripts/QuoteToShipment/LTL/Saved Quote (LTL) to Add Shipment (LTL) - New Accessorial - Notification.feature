@Sprint83 @44482 
Feature: Saved Quote (LTL) to Add Shipment (LTL) - New Accessorial - Notification

Background: Login to CRM application
Given I am a shp.entry, sales, sales management, operations, or station owner user

@GUI
Scenario: 44482_Verify the Notification accessorial auto populated while converting saved quote shipment-with Notification_shipfromsection
Given I am expanded non expired Quote with Notification accessorial
When I click on Create shipment button
Then I will see the Notification accessorial auto populated in  add services & accessorials field of the Shipping From section
And I should not able to remove the Notification accessorial

@GUI
Scenario: 44482_Verify the Notification accessorial auto populated while converting saved quote shipment--with Notification_shipTosection
Given I am expanded non expired Quote with Notification accessorial
When I click on Create shipment button
Then I will see the Notification accessorial auto populated in  add services & accessorials field of the Shipping To section
And I should not able to remove the Notification accessorial

