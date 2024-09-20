@29166 @Sprint1_Ninja
Feature: Quote Results (LTL) - Liabililty Coverage Verbiage

@Regression 
Scenario Outline: Verify the Liabililty Coverage Verbiage in the quote results page for internal users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And   I enter valid data in Item information section<Classification>, <Weight> for internal users
And   I click on view quote results button
Then the verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier
And the verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for guaranteed carrier

Examples: 
| Scenario | Username   | Password | Service | ShipmentInformationPageHeaderName | SFZiporpostal | STZiporPostal | Classification | Weight | Customer_Name          |
| S1       | stationown | Te$t1234 | LTL     | Get Quote (LTL)                   | 60606         | 33126         | 50             | 100    | ZZZ - GS Customer Test |
| S2       | opstage    | Te$t1234 | LTL     | Get Quote (LTL)                   | 60606         | 33126         | 50             | 100    | 32SP01-Steve Andrastek |