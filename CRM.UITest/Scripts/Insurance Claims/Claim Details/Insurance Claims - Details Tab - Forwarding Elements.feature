@39495 @Sprint82
Feature: Insurance Claims - Details Tab - Forwarding Elements
	
@GUI @Acceptance
Scenario: 39495_Verify the Forwarding Specific fields When the claim mode is forwarding
Given I am a sales, sales management, operations, station owner, or claims specialist user
And I have clicked on a Claim reference number of ShipmentMode Forwarding in Claim List page
When I arrive on Claim Details page
Then Forwarding Shipment mode will be pre selected in Claim Details Page
And AirLine, Pickup Carrier, Delivery Carrier, Steamship Line, Freight Forwarder and White Glove Agent will be displayed under Forwarding-Specific fields

@GUI @Acceptance
Scenario Outline: 39495_Verify the Forwarding Specific fields for Claim specialist user when the shipment mode is changed to Forwarding
Given I am a claim specialist user
And I am on the Details tab of Claim Details page of <shipmentMode>
When I change the Shipment mode to Forwarding
Then AirLine, Pickup Carrier, Delivery Carrier, Steamship Line, Freight Forwarder and White Glove Agent will be displayed under Forwarding-Specific fields

Examples: 
| shipmentMode |
| LTL          |
| FTL          |

@GUI @Acceptance
Scenario: 39495_Verify the Forwarding Specific fields edit functionality for Claim Specialist user
Given I am a claim specialist user
And I have clicked on a Claim ref number of ShipmentMode Forwarding in ClaimList page 
When I arrive on the Claim Details page
Then I should be able edit Airline, Delivery Carrier, Freight Forwarder, Pickup Carrier, Steamship Line and White Glove Agent 

@GUI
Scenario: 39495_Verify the Forwarding Specific fields non edit functionality for Internal Users
Given I am a sales, sales management, operations, station owner user
And I have clicked on a Claim reference number of ShipmentMode Forwarding in Claim List page
When I arrive on the Claim Details page
Then I should not be able edit Airline, Delivery Carrier, Freight Forwarder, Pickup Carrier, Steamship Line and White Glove Agent
