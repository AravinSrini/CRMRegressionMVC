@Sprint59 @BuildShipmentServiceScreenMobile @17387 
Feature: BuildShipmentServiceScreenForRateRequest_Mobile
	
@Regression @ignore
Scenario Outline: Verify hidden functionality of Back to Quote list button for mobile device
Given I am a DLS user and login into application with valid <Username> and <Password> 
And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
And I Click on Quotes icon from the navigation bar
When I click on the Submit Rate Request button
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And The <BackToQuote> list button should be hidden for the mobile view on Shipment service screen

Examples:
| Username | Password | ShipmentServices | BackToQuote          | WindowWidth | WindowHeight |
| zzz      | Te$t1234 | Get Quote        | Back to Quote Button | 320         | 528          |

@Regression 
Scenario Outline: Verify Shipment service screen tiles for Users with TMS type MG
Given I am a DLS user and login into application with valid <Username> and <Password> 
And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
And I Click on Quotes icon from the navigation bar
When I click on the Submit Rate Request button
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And I must be able to view <LTL>, <Truckload>, <PartialTruckload> and <Intermodal> tile on the Shipment service screen

Examples:
| Username        | Password | ShipmentServices | LTL | Truckload | PartialTruckload  | Intermodal | WindowWidth | WindowHeight |
| nat@extuser.com | Te$t1234 | Get Quote        | LTL | Truckload | Partial Truckload | Intermodal | 360         | 640          |


@Regression 
Scenario Outline:Verify Shipment service screen tiles for Users with TMS type CSA

Given I am a DLS user and login into application with valid <Username> and <Password> 
And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
And I Click on Quotes icon from the navigation bar
When I click on the Submit Rate Request button
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And I must be able to view <International> and <DomesticForwarding> tiles on the Shipment service screen


Examples:
| Username     | Password | ShipmentServices | International | DomesticForwarding | WindowWidth | WindowHeight |
| cook@inq.com | Te$t1234 | Get Quote        | International | Domestic Forwarding | 360         | 640          |

@Regression 
Scenario Outline:Verify Shipment service screen tiles for Users with TMS type Both

Given I am a DLS user and login into application with valid <Username> and <Password> 
And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
And I Click on Quotes icon from the navigation bar
When I click on the Submit Rate Request button
Then I must be navigated to the <ShipmentServices> Screen in the rate request process
And I must be able to see <LTL>, <Truckload>, <PartialTruckload>, <Intermodal>, <International> and <DomesticForwarding> tiles on the Shipment service screen

Examples:
| Username          | Password | ShipmentServices | LTL | Truckload | PartialTruckload  | Intermodal | International | DomesticForwarding  | WindowWidth | WindowHeight |
| awg@shipentry.com | Te$t1234 | Get Quote        | LTL | Truckload | Partial Truckload | Intermodal | International | Domestic Forwarding | 320         | 528          |





