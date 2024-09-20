@60031 @NinjaSprint37
Feature: 60031 - Terminal Information Modal Data that is Null, NaN, or Empty should be shown as an empty string

Scenario: 60031 - Terminal Information that is None will be shown as an empty string

Given I'm a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user Sales,username-CurrentSprintOperations,password-CurrentSprintOperations
And I navigate to the Shipment List page
And I search for the shipment shipref using the shipment reference lookup ZZX002017040
And I have clicked on the View Shipment Details button of any displayed shipment on Shipment List Page
When I click on the option to display terminal Information
Then the value for Origin Address2 will be an empty string

Scenario: 60031 - Terminal Information that is Empty will be shown as an empty string

Given I'm a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user Sales,username-CurrentSprintOperations,password-CurrentSprintOperations
And I navigate to the Shipment List page
And I search for the shipment shipref using the shipment reference lookup ZZX002017040
And I have clicked on the View Shipment Details button of any displayed shipment on Shipment List Page
When I click on the option to display terminal Information
Then the value for Origin Email will be an empty string