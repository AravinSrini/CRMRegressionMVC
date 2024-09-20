@GuaranteedRateGetQuoteAddChargeToEstCost @NinjaSprin11 @37437
Feature: Guaranteed Rate- Get Quote - Add Charge To Est Cost

@Regression 
Scenario Outline: Verify Estimated Cost For Guaranteed Carrier
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have selected the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
And I click on view quote results button
Then I will see the guaranteed rate charge applied to the Est Cost total for any carrier displaying a guaranteed rate.
And The guaranteed charge will be applied to the rate details as an accessorial on rates results.

Examples: 
| Scenario | Username               | Password | QuoteList_Header | Customer_Name          | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| S1       | SalesManager@stage.com | Te$t1234 | Quote List       | ZZZ - GS Customer Test | LTL     | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |
| S2       | crmOperation@user.com  | Te$t1234 | Quote List       | ZZZ - GS Customer Test | LTL     | 33126     | MIAMI      | FL          | 85282          | AZ               | TEMPE           | 60             | 23     | USA           | USA                | 2        | SKD          | lbs        |
| S3       | stationown             | Te$t1234 | Quote List       | ZZZ - GS Customer Test | LTL     | 30013     | Conyers    | GA          | 30013          | GA               | Conyers         | 55             | 12     | USA           | USA                | 3        | SKD          | lbs        |