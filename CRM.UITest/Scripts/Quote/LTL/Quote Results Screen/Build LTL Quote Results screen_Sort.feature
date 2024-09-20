@17773 @Sprint59
Feature: BuildLTLQuoteResultsscreen_Sorting_Searching_TermsandCondition_GuaranteedRatesGrid

@Regression
Scenario Outline: Verify the functionality of result filter based on Least cost
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button 
And I will be navigated results page with rates <url>
Then grid should be re-sorted by service with the Lowest price first on select leastcost button

Examples: 
| Username | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | LosAngeles | CA          | 90087          | LosAngeles      | CA               | 50             | 10     | 1000          | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline: Verify the functionality of result filter based on quickest service
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then grid should be re-sorted by service with the quickest service first on select quickest service

Examples: 
| Username | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | LosAngeles | CA          | 90087          | LosAngeles      | CA               | 50             | 10     | 1000          | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline: Verify the export button on rate results page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I should display with the export button

Examples: 
| Username | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | LosAngeles | CA          | 90087          | LosAngeles      | CA               | 50             | 10     | 1000          | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline: Verify the functionality of export button 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I click on export button on rate results page and results should be exported in excel


Examples: 
| Username | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | LosAngeles | CA          | 90087          | LosAngeles      | CA               | 50             | 10     | 1000          | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline: Verify the Terms and Conditions Popup
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I clicks on the Terms and Conditions link
Then I should be displayed with the Terms and Conditions Modal
And I should be displayed with Download DLSW Claim Form
And I should be displayed with Close button
And I click on the Close button Modal should close

Examples: 
| Username | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | LosAngeles | CA          | 90087          | LosAngeles      | CA               | 50             | 10     | 1000          | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline: Verify the Guaranteed Rate for the carriers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I should be displayed with a grid for Guaranteed Rate carriers
And I will be displayed with the GUARANTEED RATE under the carrier name

Examples: 
| Username | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | LosAngeles | CA          | 90087          | LosAngeles      | CA               | 50             | 10     | 1000          | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline: Verify the Guaranteed Rate hyperlink Available for the carriers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I will be displayed with the GUARANTEED RATE under the carrier name
And I click on the Guaranteed Rate carriers hyperlink
And I should be navigated to Guaranteed Rate carriers grid

Examples: 
| Username | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | LosAngeles | CA          | 90087          | LosAngeles      | CA               | 50             | 10     | 1000          | http://dlscrm-dev.rrd.com/ |
