@Quote Results (LTL) - Export Results - Station Users @Sprint67 @26521 
Feature: Quote Results (LTL) - Export Results - Station Users
	

@Regression 
Scenario Outline:Verify the export button when rates are available on quote results page

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When  I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And   I enter valid data in Item information section<Classification>, <Weight> for internal users
And   I click on view quote results button
Then I should display with the export button

Examples: 
| Scenario | QuoteConfirmationpageText | Username              | Password | Service | ShipmentInformationPageHeaderName | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService | quantityUnit | weightUnit | Customer_Name          | Station_Customer_Name                          | 
| S1       | Quote Confirmation        | crmOperation@user.com | Te$t1234 | LTL     | Get Quote (LTL)                   | 60606     | Chicago    | IL          | 60606          | Chicago         | IL               | 50             | 1      | 12345         |                   | 3            | LBS        | ZZZ - GS Customer Test |  ZZZ - Web Services Test-ZZZ - GS Customer Test| 






@Regression 
Scenario Outline:Verify the functionality of export button on quote results page

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When  I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And   I enter valid data in Item information section<Classification>, <Weight> for internal users
And   I click on view quote results button
Then I click on export button and excel file should be downloaded

Examples: 
| Scenario | QuoteConfirmationpageText | Username              | Password | Service | ShipmentInformationPageHeaderName | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService | quantityUnit | weightUnit | Customer_Name                        | Station_Customer_Name                          |
| S1       | Quote Confirmation        | crmOperation@user.com | Te$t1234 | LTL     | Get Quote (LTL)                   | 60606     | Chicago    | IL          | 60606          | Chicago         | IL               | 50             | 1      | 12345         |                   | 3            | LBS        |ZZZ - GS Customer Test                |  ZZZ - Web Services Test-ZZZ - GS Customer Test| 


@Regression 
Scenario Outline:Verify all headers present in RatesandCarrier Excel sheet

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When  I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And   I enter valid data in Item information section<Classification>, <Weight> for internal users
And   I click on view quote results button
Then I click on export button and excel file should be downloaded
And   I will be able to see the columns header
Examples: 
| Scenario | QuoteConfirmationpageText | Username              | Password | Service | ShipmentInformationPageHeaderName | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService | quantityUnit | weightUnit | Customer_Name         | Station_Customer_Name                          | 
| S1       | Quote Confirmation        | crmOperation@user.com | Te$t1234 | LTL     | Get Quote (LTL)                   | 60606     | Chicago    | IL          | 60606          | Chicago         | IL               | 50             | 1      | 12345         |                   | 3            | LPS        | ZZZ - GS Customer Test|  ZZZ - Web Services Test-ZZZ - GS Customer Test|


@Regression 
Scenario Outline:Verify RatesandCarrier Excel file with UI on quote results page

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When  I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And   I enter valid data in Item information section<Classification>, <Weight> for internal users
And   I click on view quote results button
Then  I click on export button and excel file should be downloaded
And   excel details should be match with UI
Examples: 
| Scenario | QuoteConfirmationpageText | Username              | Password | Service | ShipmentInformationPageHeaderName | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService | quantityUnit | weightUnit | Customer_Name                       | Station_Customer_Name                          | 
| S1       | Quote Confirmation        | crmOperation@user.com | Te$t1234 | LTL     | Get Quote (LTL)                   | 60606     | Chicago    | IL          | 60606          | Chicago         | IL               | 50             | 1      | 12345         |                   | 3            | LPS        | ZZZ - GS Customer Test              |  ZZZ - Web Services Test-ZZZ - GS Customer Test| 

