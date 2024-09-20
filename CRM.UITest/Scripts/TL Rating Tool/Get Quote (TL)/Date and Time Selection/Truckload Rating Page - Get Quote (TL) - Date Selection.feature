@24235 @Sprint65
Feature: Truckload Rating Page - Get Quote (TL) - Date Selection
	
@GUI @Acceptance
Scenario Outline: Verify the Pickup Date Calender present in Shipping From section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I must see the pickup date calendar in Shipping From section

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode |
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 60606              |

@GUI @Acceptance
Scenario Outline: Verify the Dropoff Date Calender present in Shipping To section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I must see the dropoff date calendar in Shipping To section

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | 
| s1       | stationtest@rrd.com | Te$t1234 | 60606         | 33130              | 

@Functional @Acceptance
Scenario Outline: Verify the Pickup Date Calender functionality
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I must see the pickup date calendar in Shipping From section
	And I click on Pickup calendar
	And I should be displayed with popup of calendar in month format from pickup

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | 
| s1       | stationtest@rrd.com | Te$t1234 | 10013         | 10012              | 

@Functional @Acceptance
Scenario Outline: Verify the Dropoff Date Calender Functionality
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I must see the dropoff date calendar in Shipping To section
	And I click on Dropoff calendar
	And I should be displayed with popup of calendar in month format from dropoff

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | 
| s1       | stationtest@rrd.com | Te$t1234 | 15370         | 51301              | 

@Functional @Acceptance
Scenario Outline: Verify the Pickup Date Calender displaying default as current date
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then Pick up date should be displayed by default as current date

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | 
| s1       | stationtest@rrd.com | Te$t1234 | 33126         | 60606              | 

@Functional @Acceptance
Scenario Outline: Verify the Dropoff Date Calender displaying default as current date
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then Dropoff date should be displayed by default as current date

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | 
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 60606              | 

@Functional @Acceptance
Scenario Outline: Verify the user able to select new date Pickup Date Calender 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 	
	Then I click on Pickup calendar
	And I should be displayed with popup of calendar in month format from pickup
	And I should be able to select new date 

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | 
| s1       | stationtest@rrd.com | Te$t1234 | 33130         | 33126              | 

@Functional @Acceptance
Scenario Outline: Verify the user able to select new date Dropoff Date Calender 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I click on Dropoff calendar
	And I should be displayed with popup of calendar in month format from dropoff
	And I should be able to select new date

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | 
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 60606              | 

@Functional @Acceptance
Scenario Outline: Verify the user not able to select dates in past from Pickup Date Calender 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I click on Pickup calendar
	And I should be displayed with popup of calendar in month format from pickup
	And I should not be able to select the dates in past

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | 
| s1       | stationtest@rrd.com | Te$t1234 | 51301         | 60490              | 

@Functional @Acceptance
Scenario Outline: Verify the user not able to select dates in past from Dropoff Date Calender 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I click on Dropoff calendar
	And I should be displayed with popup of calendar in month format from dropoff
	And I should not be able to select the dates in past

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode |
| s1       | stationtest@rrd.com | Te$t1234 | 51301         | 15370              |

@Functional @Negative
Scenario Outline: Verify the when user selects pick up date greater than dropoff date
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	When I click on Dropoff calendar
	And I should be displayed with popup of calendar in month format from dropoff
	And I select new date
	And I click on Pickup calendar
	And I should be displayed with popup of calendar in month format from pickup
	And I select pick up date greater than dropoff date
	And I click on the Get Live Quote button
	Then I should be displayed with the ErrorMessage 
	
Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | 
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 60606              | 