@Sprint81 @40784
Feature: Over Length - Saved Quote (LTL) to Shipment

Background: Login to CRM application
Given I am a shp.entry, sales, sales management, operations, or station owner user

@GUI
Scenario: 40784_Verify the dimension fields and dimension type auto populated while converting saved quote shipment-with dimensions
Given I am on QuoteList page
And I have a non expired Quote with Dimensions
When I click on Create shipment button
Then Length, Width, Height fields and dimension type will be auto populated and those are not editable

@GUI
Scenario: 40784_Verify the dimension fields and dimension type auto populated while converting saved quote shipment-without dimensions
Given I am on the Quote Listpage
And I have a non expired Quote without Dimensions
When I click on Create shipment button
Then Length, Width and Height fields will be blank and non editable
