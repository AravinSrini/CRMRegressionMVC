@Sprint59 @LTLTileOnShipmentServiceScreen @17432 
Feature: LTLTileOnShipmentServicesScreenInRateRequestProcess_Desktop

@Regression 
Scenario Outline: Verify LTL tile view on the Shipment Services screen in rate request process
Given I am a DLS user and login into application with valid <Username> and <Password>
When I Click on Quotes icon from the navigation bar
And I click on Submit a rate request
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And I must be able to see <LTL> service option in a tile view of the Shipment Services screen

Examples:
| Username | Password | ShipmentServices | LTL |
| zzz      | Te$t1234 | Get Quote        | LTL |


@Regression 
Scenario Outline: Verify Click functionality of LTL tile and page header of new LTL Shipment information screen with Back to Quote list button
Given I am a DLS user and login into application with valid <Username> and <Password> 
And I have access to Quotes
And I am on the <ShipmentServices> page of the rate request process
When I click on the LTL Tile
Then I must be navigated to the new responsive LTL Shipment information screen and header should display <GetQuote> with back to <QuoteListButton>

Examples: 
| Username | Password | ShipmentServices | GetQuote        | QuoteListButton    |
| zzz      | Te$t1234 | Get Quote        | Get Quote (LTL) | Back to Quote List |