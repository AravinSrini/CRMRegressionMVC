@Sprint59 @BuildShipmentServiceScreen @17387 
Feature: BuildShipmentServiceScreenForRateRequest_Desktop
	

@Regression 
Scenario Outline: Verify existence of Back to Quote list button 
Given I am a DLS user and login into application with valid <Username> and <Password> 
When I Click on Quotes icon from the navigation bar
And I click on the Submit Rate Request button
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And The <BacktoQuote> list button should be present on Shipment service screen

Examples:
| Username | Password | ShipmentServices | BacktoQuote          |
| zzz      | Te$t1234 | Get Quote        | Back to Quote Button |

@Regression 
Scenario Outline: Verify Shipment service screen tiles for Users with TMS type MG
Given I am a DLS user and login into application with valid <Username> and <Password> 
When I Click on Quotes icon from the navigation bar
And I click on the Submit Rate Request button
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And I must be able to view <LTL>, <Truckload>, <PartialTruckLoad> and <Intermodal> tile on the Shipment service screen

Examples:
| Username        | Password | ShipmentServices | LTL | Truckload | PartialTruckLoad  | Intermodal |
| nat@extuser.com | Te$t1234 | Get Quote        | LTL | Truckload | Partial Truckload | Intermodal |

@Regression 
Scenario Outline:Verify Shipment service screen tiles for Users with TMS type CSA

Given I am a DLS user and login into application with valid <Username> and <Password> 
When I Click on Quotes icon from the navigation bar
And I click on the Submit Rate Request button
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And I must be able to view <International> and <DomesticForwarding> tiles on the Shipment service screen

Examples:
| Username     | Password | ShipmentServices | International | DomesticForwarding  |
| cook@inq.com | Te$t1234 | Get Quote        | International | Domestic Forwarding |


@Regression 
Scenario Outline:Verify Shipment service screen tiles for Users with TMS type Both

Given I am a DLS user and login into application with valid <Username> and <Password> 
When I Click on Quotes icon from the navigation bar
And I click on the Submit Rate Request button
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And I must be able to see <LTL>, <Truckload>, <PartialTruckload>, <Intermodal>, <International> and <DomesticForwarding> tiles on the Shipment service screen

Examples:
| Username          | Password | ShipmentServices | LTL | Truckload | PartialTruckload | Intermodal | International | DomesticForwarding |
| awg@shipentry.com | Te$t1234 | Get Quote        | LTL | Truckload | Partial Truckload | Intermodal | International | Domestic Forwarding |
