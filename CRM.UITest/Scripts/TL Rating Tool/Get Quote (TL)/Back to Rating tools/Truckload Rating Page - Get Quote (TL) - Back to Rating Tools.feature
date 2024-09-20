@24234 @Sprint65
Feature: Truckload Rating Page - Get Quote (TL) - Back to Rating Tools

@Functional
Scenario Outline: Verify the functionality of Back to Rating Tools button in Get Quote (TL) page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on Rating Tool icon
	And I have entered required fields '<OriginZipCode>','<DestinationZipCode>','<PickupDate>','<Weight>' in TL Rating Tool Projected amount page
	And  I have Clicked on Get Rate button in TL Rating Tool Projected amount page
	And  I have clicked on Get Quote New button in rating tool page
	When I have arrived on Get Quote (TL) '<GetQuoteTitle>' page
	And  I click on Back to Rating Tools button
	Then I must be naviagted back to '<RatingTools>' page

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | GetQuoteTitle         | RatingTools      | PickupDate |
| 1        | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | 3000   | Get Quote (Truckload) | Projected Amount | 0          |