@24149 @LTLQuoteresultspage @Sprint65
Feature: Truckload Rating PageGet QuoteTLPickupDropoffTimes

@Functional 
Scenario Outline:Test to verify default start time in pickup start time dropdown
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should display with pickup start time dropdown
	And  I should displayed with 8am default time in pickup start time dropdown

Examples: 
| Scenario | Username                     | Password | OriginZipCode | DestinationZipCode | Weight |
| 1        | stationtest@rrd.com          | Te$t1234 | 90001         | 90001              | 50     |

@Functional 
Scenario Outline:Test to verify the default end time in pickup End time dropdown
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should display with pickup end time dropdown
	And  I should displayed with Fivepmdefault time in pickup end time dropdown

Examples: 
| Scenario | Username             | Password | OriginZipCode | DestinationZipCode | Weight | pickstarttime |
| 1        | stationtest@rrd.com  | Te$t1234 | 90001         | 90001              | 50     | 8:00          |

@Functional 
Scenario Outline:Test to verify the selection start time  functionality in pickup dropdown
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should display with pickup start time dropdown
	Then I should be able to select the any <pickstarttime> in pickup start time dropdown

Examples: 
| Scenario | Username             | Password | OriginZipCode | DestinationZipCode | Weight | pickstarttime |
| 1        | stationtest@rrd.com  | Te$t1234 | 90001         | 90001              | 50     | 1:00 AM       |

@Functional 
Scenario Outline:Test to verify the selection end time  functionality in pickup dropdown
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should display with pickup end time dropdown
	And  I should displayed with 5pm default time in pickup start time dropdown
	And I should be able to select the any <pickendtime> in pickup end time dropdown
	
Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | pickstarttime     | pickendtime |
| 1        | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | 50     |4:00 AM            | 6:00 AM     |

@Functional 
Scenario Outline:Test to verify the  functionality of Pickup end time must always be greater than start time
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should be able to select the any <pickstarttime> in pickup start time dropdown
	And I should be able to select the any <pickendtime> in pickup end time dropdown
	And I click on live quote button
	And I should display with error message when Pickup end time lesser than start time 

Examples: 
| Scenario | Username           | Password | OriginZipCode | DestinationZipCode | Weight | pickstarttime   | pickendtime   |
| 1        | stationtest@rrd.com| Te$t1234 | 90001         | 90001              | 50     | 8:00 AM         | 6:00 AM       |

@Functional 
Scenario Outline:Test to verify default start time in Dropoff start time dropdown
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should display with Dropoff start time dropdown
	And  I should displayed with 8am default time in Dropoff start time dropdown

Examples: 
| Scenario | Username                | Password | OriginZipCode | DestinationZipCode | Weight | Dpickstarttime | Dpickendtime |
| 1        |stationtest@rrd.com      | Te$t1234 | 90001         | 90001              | 50     |5:00 AM         | 6:00 AM       |

@Functional 
Scenario Outline:Test to verify the default end time in Dropoff End time dropdown
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should display with Dropoff end time dropdown
	And  I should displayed with five Pm default time in Dropoff end time dropdown

Examples: 
| Scenario | Username              | Password | OriginZipCode | DestinationZipCode | Weight | Dpickstarttime | Dpickendtime   |
| 1        | stationtest@rrd.com   | Te$t1234 | 90001         | 90001              | 50     | 8:00 AM         | 6:00 AM       |

@Functional @Sprint65 @24149
Scenario Outline:Test to verify the selection start time  functionality in Dropoff dropdown
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should display with pickup start time dropdown
	And  I should displayed with Eight AM default time in Dropoff start time dropdown
	And I should be able to select the any <Dpickstarttime> in Dropoff start time dropdown

Examples: 
| Scenario | Username           | Password | OriginZipCode | DestinationZipCode | Weight | Dpickstarttime | Dpickendtime |
| 1        | stationtest@rrd.com| Te$t1234 | 90001         | 90001              | 50     |4:00 AM         | 6:00 AM       |

@Functional @Sprint65 @24149
Scenario Outline:Test to verify the selection end time  functionality in Dropoff dropdown
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should display with pickup end time dropdown
	And  I should displayed with 8am default time in Dropoff start time dropdown
	And I should be able to select the any <Dpickendtime> in Dropoff end time dropdown
	
Examples: 
| Scenario | Username             | Password | OriginZipCode | DestinationZipCode | Weight | Dpickstarttime  | Dpickendtime |
| 1        |stationtest@rrd.com   | Te$t1234 | 90001         | 90001              | 50     | 5:00 AM         | 6:00 AM       |

@Functional 
Scenario Outline:Test to verify the  functionality of Dropoff end time must always be greater than start time 
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
    And I Click on Get Rate button in rating tool page
    And  I click on Get Quote Now button in rating tool page 
	Then I should be able to select the any <Dpickstarttime> in Dropoff start time dropdown
	And I should be able to select the any <Dpickendtime> in Dropoff end time dropdown
	And I click on live quote button
	And I should display with error message when Dropoff end time lesser than start time 

Examples:  
 | Username                | Password      | OriginZipCode | DestinationZipCode | Weight | Dpickstarttime  | Dpickendtime |
 | stationtest@rrd.com     | Te$t1234      | 90001         | 90001              | 50     | 8:00 AM         | 6:00 AM       |