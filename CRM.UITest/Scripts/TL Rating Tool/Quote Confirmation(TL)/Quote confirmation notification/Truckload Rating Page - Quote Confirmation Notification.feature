@24143 @Sprint65
Feature: Truckload Rating Page - Quote Confirmation Notification

@GUI @Regression
Scenario Outline:Verify existence of confirmation screen on Clicking Get Live Quote button 
Given I  login into application as StationOwner
And I clicked on Rating Tool icon
And I have entered required fields '<OriginZipCode>','<DestinationZipCode>','<PickupDate>','<Weight>' in TL Rating Tool Projected amount page
And  I have Clicked on Get Rate button in TL Rating Tool Projected amount page
And  I have clicked on Get Quote New button in rating tool page
When I have arrived on Get Quote (TL) '<GetQuoteTitle>' page
And I pass data to all the required fields '<ShipFrom>','<ShipTo>','<FrieghtDescription>','<Quantity>','<WeightTL>','<Insuredvalue>'
And I have clicked on Get Live Quote button
Then I must be able to view a <QuoteConfirmation> screen for the quote submitted

Examples: 
| Username            | Password | OriginZipCode | DestinationZipCode | Weight | GetQuoteTitle         | PickupDate | ShipFrom | ShipTo | FrieghtDescription | Quantity | WeightTL | QuoteConfirmation | Insuredvalue |
| StationOwner|  | 90001         | 90001              | 3000   | Get Quote (Truckload) | 0          | 90001    | 90001  | try                | 2        | 3        | Get Live Quote    | 1000         |


@Functional
Scenario Outline: Verify the functionality of OK button on the Quote Confirmation screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on Rating Tool icon
And I have entered required fields '<OriginZipCode>','<DestinationZipCode>','<PickupDate>','<Weight>' in TL Rating Tool Projected amount page
And  I have Clicked on Get Rate button in TL Rating Tool Projected amount page
And  I have clicked on Get Quote New button in rating tool page
When I have arrived on Get Quote (TL) '<GetQuoteTitle>' page
And I pass data to all the required fields '<ShipFrom>','<ShipTo>','<FrieghtDescription>','<Quantity>','<WeightTL>','<Insuredvalue>'
And I have clicked on Get Live Quote button
Then I must be able to view OK button on the Quote Confirmation screen
And when I click on OK button i must be navigated back to TL Rating Tool <ProjectedAmount> page.

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | GetQuoteTitle         | PickupDate | ShipFrom | ShipTo | FrieghtDescription | Quantity | WeightTL | ProjectedAmount  | Insuredvalue |
| S1       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | 3000   | Get Quote (Truckload) | 0          | 90001    | 90001  | TRY                | 2        | 3        | Projected Amount | 1000         |


@Acceptance @DBVerification @Regression
Scenario Outline:Verify Quote Reference number from Quote confirmation screen with database
Given I  login into application as StationOwner
And I clicked on Rating Tool icon
And I have entered required fields '<OriginZipCode>','<DestinationZipCode>','<PickupDate>','<Weight>' in TL Rating Tool Projected amount page
And  I have Clicked on Get Rate button in TL Rating Tool Projected amount page
And  I have clicked on Get Quote New button in rating tool page
When I have arrived on Get Quote (TL) '<GetQuoteTitle>' page
And I pass data to all the required fields '<ShipFrom>','<ShipTo>','<FrieghtDescription>','<Quantity>','<WeightTL>','<Insuredvalue>'
And I have clicked on Get Live Quote button
Then The Quote Reference number in the Quote Confirmation modal must match with the database

Examples: 
| Username            | Password | OriginZipCode | DestinationZipCode | Weight | GetQuoteTitle         | PickupDate | ShipFrom | ShipTo | FrieghtDescription | Quantity | WeightTL | Insuredvalue |
| StationOwner|  | 90001         | 90001              | 3000   | Get Quote (Truckload) | 0          | 90001    | 90001  | try                | 2        | 4        | 1000         |

@GUI @Regression @25765 
Scenario Outline: Verify without entering any data's in Mandatory fields and try to click on GetLiveQuote button
Given I  login into application as StationOwner
And  I clicked on Rating Tool icon
When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
And I click on the calender to select the <PickupDate>
And  Click on Get Rate button in rating tool page
And  I have click on Get Quote Now button in rating tool page
And I have clicked on GetLiveQuote button
Then background color of the origin zip code textbox should turn red and error message should be displayed in GetQuote(TL) page
And background color of the destination zip code textbox should turn red and error message should be displayed in GetQuote(TL) page
And background color of the Item Description textbox should turn red highlighted
And background color of the Quantity textbox should turn red highlighted
And background color of the Weight textbox should turn red highlighted

Examples: 
| Username            | Password | OriginZipCode | DestinationZipCode | Weight | PickupDate |
 |StationOwner| Te$t1234 | 90001         | 90001              | 100    | 0          |