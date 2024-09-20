@Regression @32068  @Sprint71
Feature: Regression_Domestic Forwarding_Add Shipment_Select Saved Item
Scenario Outline:32068_Test to verify autopupulate functionality-Add Shipment -Select Saved Item
Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
And I am on the Add Shipment page for Domestic Forwarding
When I select the saved item '<ItemDesc>' on addshipment page
Then The following fields Pieces, Weight, Dimensions and Description must be populated with correct DB data '<ItemDesc>','<AccountName>' 

Examples: 
 | Username         | Password | ItemDesc  | AccountName       |
 | zzzcsa@stage.com |  | Test Item | Kim Manufacturing |
