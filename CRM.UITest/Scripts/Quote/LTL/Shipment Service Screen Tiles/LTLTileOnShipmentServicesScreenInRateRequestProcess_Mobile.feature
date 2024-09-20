@Sprint59 @LTLTileOnShipmentServiceScreenMobile @17432 
Feature: LTLTileOnShipmentServicesScreenInRateRequestProcess_Mobile
	
@Regression 
Scenario Outline: Verify LTL tile view on the Shipment Services screen in rate request process
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
And I Click on Quotes icon from the navigation bar
When I click on Submit a rate request
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And I must be able to see <LTL> service option in a tile view of the Shipment Services screen

Examples:
| Username | Password | ShipmentServices | LTL | WindowWidth | WindowHeight |
| zzz      | Te$t1234 | Get Quote        | LTL | 360         | 640          |

@Regression 
Scenario Outline: Verify Click functionality of LTL tile and page header of new LTL Shipment information screen with Back to Quote list button
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
And I Click on Quotes icon from the navigation bar
And I click on Submit a rate request
And I am on the <ShipmentServices> page of the rate request process
When I click on the LTL Tile
Then I must be navigated to the new responsive LTL Shipment information screen and header should display <GetQuote> without back to <QuoteListButton>

Examples: 
| Username | Password | ShipmentServices | GetQuote        | QuoteListButton    | WindowWidth | WindowHeight |
| zzz      | Te$t1234 | Get Quote        | Get Quote (LTL) | Back to Quote List | 360         | 640          |