@RateRequestAddQuantityParametersfromLTLratetoshipment @18403 @Sprint60 @NotAutomated @Ignore
Feature: RateRequestAddQuantityParametersfromLTLratetoshipment

@Regression
Scenario Outline: Test to verify the Quantity Parameter from LTL standard rate to shipment when user enters the Quantity value during rate request process
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid data in mandatory Item section <Classification>, <Weight>
And I enter value in <Quantity> and select <Quantity_unit> from dropdown in Freight Description section
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on create shipment
Then I should navigate to Shipment Locations and Dates of Add Shipment page
And I enter the mandatory fields <OriginName>, <OriginAddress>, <DestinationName> and <DestinationAddress>
And I click on Save and Continue
And <Quantity> and <Quantity_unit> fields should be auto populated

Examples:
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | Quantity | Quantity_unit | url                        | OriginName | OriginAddress     | DestinationName | DestinationAddress |
| zzz      | Te$t1234 | LTL     | 60606     | BOLINGBROOK | IL          | 90001          | LOS ANGELES     | CA               | 50             | 60     | 5        | Cabinets      | http://dlscrm-dev.rrd.com/ | TEST       | 1000 WINDHAM PKWY | XYZ             | 1000 XYZ CT        |

@Regression
Scenario Outline: Test to verify the Quantity Parameter from LTL insured rate to shipment when user enters the Quantity value during rate request process
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>
And I enter value in <Quantity> and select <Quantity_unit> from dropdown in Freight Description section
And I enter <ShipmentValue> under Freight Description section
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on create insured shipment
Then I should navigate to Shipment Locations and Dates of Add Shipment page
And I enter the mandatory fields <OriginName>, <OriginAddress>, <DestinationName> and <DestinationAddress>
And I click on Save and Continue
And <Quantity> and <Quantity_unit> fields should be auto populated

Examples:
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | Quantity | Quantity_unit | url                        | OriginName | OriginAddress     | DestinationName | DestinationAddress | ShipmentValue |
| zzz      | Te$t1234 | LTL     | 60606     | BOLINGBROOK | IL          | 90001          | LOS ANGELES     | CA               | 50             | 60     | 50       | drums         | http://dlscrm-dev.rrd.com/ | TEST       | 1000 WINDHAM PKWY | XYZ             | 1000 XYZ CT        | 1000          |

@Regression
Scenario Outline: Test to verify the Quantity Parameter from LTL standard rate to shipment when user not enters the Quantity value during rate request process
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>
And I have not entered value in <Quantity> and select <Quantity_unit> from dropdown in Freight Description section
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on create shipment
Then I should navigate to Shipment Locations and Dates of Add Shipment page
And I enter the mandatory fields <OriginName>, <OriginAddress>, <DestinationName> and <DestinationAddress>
And I click on Save and Continue
And <Quantity> and <Quantity_unit> fields should not be auto populated

Examples:
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | Quantity | Quantity_unit | url                        | OriginName | OriginAddress     | DestinationName | DestinationAddress |
| zzz      | Te$t1234 | LTL     | 60606     | BOLINGBROOK | IL          | 90001          | LOS ANGELES     | CA               | 50             | 60     |          | Skids         | http://dlscrm-dev.rrd.com/ | TEST       | 1000 WINDHAM PKWY | XYZ             | 1000 XYZ CT        |

@Regression
Scenario Outline: Test to verify the Quantity Parameter from LTL insured rate to shipment when user not enters the Quantity value during rate request process
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>
And I have not entered value in <Quantity> and select <Quantity_unit> from dropdown in Freight Description section
And I enter <ShipmentValue> under Freight Description section
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on create insured shipment
Then I should navigate to Shipment Locations and Dates of Add Shipment page
And I enter the mandatory fields <OriginName>, <OriginAddress>, <DestinationName> and <DestinationAddress>
And I click on Save and Continue
And <Quantity> and <Quantity_unit> fields should not be auto populated

Examples:
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | Quantity | Quantity_unit | url                        | OriginName | OriginAddress     | DestinationName | DestinationAddress | ShipmentValue |
| zzz      | Te$t1234 | LTL     | 60606     | BOLINGBROOK | IL          | 90001          | LOS ANGELES     | CA               | 50             | 60     |          | Skids         | http://dlscrm-dev.rrd.com/ | TEST       | 1000 WINDHAM PKWY | XYZ             | 1000 XYZ CT        |               |

@Regression
Scenario Outline: Test to verify the Quantity Parameter from LTL guaranteed rate to shipment when user enters the Quantity value during rate request process
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>
And I enter value in <Quantity> and select <Quantity_unit> from dropdown in Freight Description section
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on Guaranteed Rate carriers hyperlink
And I should be navigated to Guaranteed Rate carriers grid
And I click on create shipment of guaranteed grid
Then I should navigate to Shipment Locations and Dates of Add Shipment page
And I enter the mandatory fields <OriginName>, <OriginAddress>, <DestinationName> and <DestinationAddress>
And I click on Save and Continue
And <Quantity> and <Quantity_unit> fields should be auto populated

Examples:
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | Quantity | Quantity_unit | url                        | OriginName | OriginAddress     | DestinationName | DestinationAddress |
| zzz      | Te$t1234 | LTL     | 60606     | BOLINGBROOK | IL          | 90001          | LOS ANGELES     | CA               | 50             | 60     | 5        | Cabinets      | http://dlscrm-dev.rrd.com/ | TEST       | 1000 WINDHAM PKWY | XYZ             | 1000 XYZ CT        |


@Regression
Scenario Outline: Test to verify the Quantity Parameter from LTL standard rate to shipment when user enters manually Quantity and Quantity unit value during rate request process
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>
And I enter value manually in <Quantity> and <Quantity_unit> in Freight Description section
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on create shipment
Then I should navigate to Shipment Locations and Dates of Add Shipment page
And I enter the mandatory fields <OriginName>, <OriginAddress>, <DestinationName> and <DestinationAddress>
And I click on Save and Continue
And <Quantity> and <Quantity_unit> fields should be auto populated

Examples:
| Username | Password | Service | OriginZip | OriginCity | OriginState|DestinationZip | DestinationCity|DestinationState|Classification | Weight | Quantity | Quantity_unit | url                        |OriginName	|OriginAddress		|DestinationName|DestinationAddress|
| zzz      | Te$t1234 | LTL     | 60606     | BOLINGBROOK| IL         | 90001         | LOS ANGELES    | CA             | 50            | 60     | 50       | Cabinets      | http://dlscrm-dev.rrd.com/ | TEST			| 1000 WINDHAM PKWY | XYZ           | 1000 XYZ CT      |