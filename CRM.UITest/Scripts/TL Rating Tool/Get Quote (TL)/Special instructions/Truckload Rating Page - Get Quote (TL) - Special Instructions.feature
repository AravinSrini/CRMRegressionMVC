@24148 @Sprint65 
Feature: Truckload Rating Page - Get Quote (TL) - Special Instructions

@Functional
Scenario Outline:Verify the functionality of Special Instructions free form text field by passing different values
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on Rating Tool icon
And I have entered required fields '<OriginZipCode>','<DestinationZipCode>','<PickupDate>','<Weight>' in TL Rating Tool Projected amount page
And  I have Clicked on Get Rate button in TL Rating Tool Projected amount page
And  I have clicked on Get Quote New button in rating tool page
When I have arrived on Get Quote (TL) '<GetQuoteTitle>' page
Then I must be able to pass <Data> to the Special Instructions free form text field 

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | GetQuoteTitle         | Data                                                      | PickupDate |
| S1       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | 3000   | Get Quote (Truckload) | verifying Special Instructions free text field123 @34$%.< | 0          |
| S2       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | 4000   | Get Quote (Truckload) | !@#$;:,.[]0                                               | 0          |