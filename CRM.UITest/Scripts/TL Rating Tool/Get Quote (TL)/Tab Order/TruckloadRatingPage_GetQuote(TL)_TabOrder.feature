@TruckloadRatingPage_GetQuote(TL)_TabOrder @Sprint65 @24140 @GUI 
Feature: TruckloadRatingPage_GetQuote(TL)_TabOrder

Scenario Outline: Verify the TabOrder for GetQuote(TL) screen
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then I must be able to verify the tab order for the mandatory fields for the GetQuote Truckload screen

	Examples: 
	| Scenario | Username					| Password | OriginZipCode | DestinationZipCode | PickupDate|Weight |
	| 1        | stationtest@rrd.com		| Te$t1234 | 90001         | 90001              | 0			|3000   |

