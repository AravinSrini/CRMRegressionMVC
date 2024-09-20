@QuoteListNavigation @26522 @Sprint67 @Functional
Feature: QuoteConfirmationPage-InternalUsers 

@Regression 
Scenario Outline: 26522_Verify name of the station and customer on confirmation page when standard rates selected 

Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner 
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid data in Item information section <Classification>, <Weight>
And I Click on view quote results button
And I click on save rate as quote link  for selected carrier in results page for station users
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I will see the name of the <Station_Customer_Name> associated to the quote displayed
Examples: 
| QuoteConfirmationpageText | Service | ShipmentInformationPageHeaderName | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService | quantityUnit | weightUnit | Customer_Name                       | Station_Customer_Name                           |
| Quote Confirmation        | LTL     | Get Quote (LTL)                   | 33126     | Miami      | FL          | 60606          | Chicago         | CA               | 50             | 1      | 12345         |                   | 3            | LPS        | ZZZ - GS Customer Test              |  ZZZ - Web Services Test - ZZZ - GS Customer Test| 


@Regression 
Scenario Outline: 26522_Verify name of the station and customer on confirmation page when insured rates selected 

Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner 
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid data in Item information section <Classification>, <Weight>
And I Click on view quote results button
And I click on save insured rate as quote link  for carrier '<ShipmentValue>' for station users
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I will see the name of the <Station_Customer_Name> associated to the quote displayed
Examples: 
| QuoteConfirmationpageText | Service | ShipmentInformationPageHeaderName | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService | quantityUnit | weightUnit | Customer_Name                       | Station_Customer_Name                          |
| Quote Confirmation        | LTL     | Get Quote (LTL)                   | 33126     | Miami      | FL          | 60606          | Chicago         | CA               | 50             | 1      | 12345         |                   | 3            | LPS        | ZZZ - GS Customer Test              |  ZZZ - Web Services Test - ZZZ - GS Customer Test| 


@Regression 
Scenario Outline: 26522_Verify name of the station and customer on confirmation page when no carrier available 

Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner 
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid data in Item information section <Classification>, <Weight>
And I Click on view quote results button
And I click on save rate as quote link  for selected carrier in results page for station users
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I will see the name of the <Station_Customer_Name> associated to the quote displayed
Examples: 
| QuoteAmount  | AmountText | QuoteConfirmationpageText | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService | Customer_Name | Station_Customer_Name                |
| QUOTE AMOUNT | Amount     | Quote Confirmation        | LTL     | 90001     | LOS ANGELES | CA          | 90001          | CA               | LOS ANGELES     | 50             | 3      | 566           |                   | Dunkin Donuts | ENT - Bolingbrook IL - Dunkin Donuts | 
