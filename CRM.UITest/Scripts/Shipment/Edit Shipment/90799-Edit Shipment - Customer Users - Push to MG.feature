@Sprint91 @Sprint92 @90799 @108326 @Regression
Feature: 90799-Edit Shipment - Customer Users - Push to MG

Scenario: 90799-Edit Shipment - Customer Users - Push to MG
Given I am a shp.entry or shp.entrynorates user
And I am on the Shipment List page
And I am Editing an LTL shipment for external user
And I click on the Submit Updated Shipment button on the Review and Submit Shipment (LTL) page
Then the shipment data will be pushed to MG
And the BOL number will be added as a reference number to the shipment import xml with is primary =  true
And the carrier pricesheet in MG will be selected

