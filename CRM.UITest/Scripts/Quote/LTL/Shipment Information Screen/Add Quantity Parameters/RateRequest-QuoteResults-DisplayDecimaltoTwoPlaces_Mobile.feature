@LTLQuoteResultspageDisplayDecimaltoTwoPlaces_Mobile @19221 @Sprint62
Feature: RateRequest-QuoteResults-DisplayDecimaltoTwoPlaces_Mobile

@Regression
Scenario Outline: Test to verify the Standard Rate and Insured Rate amount should be displayed with two decimal places
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid data in mandatory Item section <Classification>, <Weight>
And I enter decimal values in <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates
Then I must be displayed with two decimal places of Rate and Insured Rate

Examples: 
| Scenario | Username | Password | WindowWidth | WindowHeight | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue |
| s1       | zzz      | Te$t1234 | 768         | 640          | LTL     | 33126     | 60606          | 250            | 1300   | 90.98         |
