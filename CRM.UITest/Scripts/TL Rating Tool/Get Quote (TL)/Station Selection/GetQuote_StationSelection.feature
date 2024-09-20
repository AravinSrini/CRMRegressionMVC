 @24141 @Sprint65 @Functional 
Feature: GetQuote_StationSelection

Scenario Outline: Verify default selected station in get quote TL page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then the Station I am associated to will be displayed in the station dropdown <Username>
	
Examples: 
| Scenario | Username     | Password | OriginZipCode | DestinationZipCode | Weight | PickupDate |
| S1       | nationalcart | Te$t1234 | 33126         | 85282              | 100    | 0          |

Scenario Outline: Verify station dropdown in get quote TL page when user is mapped to multiple stations
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then the Stations I am associated to will be displayed in the station dropdown <Username>
	
Examples: 
| Scenario | Username    | Password | OriginZipCode | DestinationZipCode | Weight | PickupDate |
| S1       | stationtest | Te$t1234 | 33126         | 85282              | 100    | 0          |

@Regression
Scenario Outline: Try to select the station from the dropdown
	Given I  login into application as StationOwner
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then I should be able to select only one station from the dropdown <Station1>, <Station2>
	
Examples: 
| Username    | Password | OriginZipCode | DestinationZipCode | Weight | Station1        | Station2        | PickupDate |
| StationOwner|  | 33126         | 85282              | 100    | 03 - Memphis TN | Indianapolis IN | 0          |
