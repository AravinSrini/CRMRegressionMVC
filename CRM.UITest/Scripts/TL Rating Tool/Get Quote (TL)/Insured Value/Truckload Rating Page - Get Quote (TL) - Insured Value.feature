@24150 @Sprint65
Feature: Truckload Rating Page - Get Quote (TL) - Insured Value

@Functional @Acceptance
Scenario Outline: Verify the Insured Value text box taking decimal values on the Get Quote TL page
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I should be able to enter decimal values in <InsuredValue> textbox

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | InsuredValue |
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 60606              | 989.90       |

@Functional @Acceptance
Scenario Outline: Verify the error message on entering maximum insured value
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	When I enter more than maximun value in <InsuredValue> field of Get Quote TL
	Then Error message should be displayed for entering more than the limit of insured value

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | InsuredValue |
| s1       | stationtest@rrd.com | Te$t1234 | 60490         | 60606              | 1000001      |

@Functional
Scenario Outline: Verify the insured value field not allowing user to enter zero 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	And I enter zero in <InsuredValue> field of Get Quote TL	
	Then <InsuredValue> text box zero should not be visible

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | InsuredValue |
| s1       | stationtest@rrd.com | Te$t1234 | 51301         | 15370              | 0            |

@Functional @Acceptance
Scenario Outline: Verify the Insured Value Tooltip text on the Get Quote TL page
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I must be able to see the tool tip <Message> when mouse hover on Question mark of Get Quote TL

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Message                                                                                                                     |
| s1       | stationtest@rrd.com | Te$t1234 | 33130         | 60666              | Normal method to determine insured value: Invoice Cost, Plus Insurance Cost, Plus Any Prepaid Freight Charges, All Plus 10% |