@24151 @Sprint65

Feature: GetQuote_Hazmat

@GUI
Scenario Outline: Verify the fields when I click on the Hazardous material Yes radion button in Get Quote TL page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	And I click on the hazardous material Yes radio button
	Then I must be able to see <UN_Number>, <CCN_Number>, <HazmatPackageGroup_DropDown>, <HazmatClass_DropDown>, <ResponseContactName>, and <EmergencyResponsePhone_Number>

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | UN_Number          | CCN_Number          | HazmatPackageGroup_DropDown      | HazmatClass_DropDown   | ResponseContactName            | EmergencyResponsePhone_Number            | PickupDate |
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 87004              | 40000  | Enter UN number... | Enter CCN number... | Select hazmat packaging group... | Select hazmat class... | Enter response contact name... | Enter emergency response phone number... | 0          |

@GUI 
Scenario Outline: Verify the all the hazardous material fields are outlined in orange color as required in Get Quote TL page
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	And I click on the hazardous material Yes radio button
	Then I should be navigated to the Get Quote TL page with text as <GetQuoteText> 
    And  I must be able to see all required field border Color in orange
Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | GetQuoteText          | PickupDate |
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 87004              | 40000  | Get Quote (Truckload) | 0          |

@GUI
Scenario Outline: Verify the fields are removed when I click on the Hazardous material No radion button after clicking Yes button in Get Quote TL page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	And I click on the hazardous material Yes radio button
	And I click on the hazardous material No radio button
	Then I should not be able to see <UN_Number>, <CCN_Number>, <HazmatPackageGroup_DropDown>, <HazmatClass_DropDown>, <ResponseContactName>, and <EmergencyResponsePhone_Number>
Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | UN_Number          | CCN_Number          | HazmatPackageGroup_DropDown      | HazmatClass_DropDown   | ResponseContactName            | EmergencyResponsePhone_Number            | PickupDate |
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 87004              | 40000  | Enter UN number... | Enter CCN number... | Select hazmat packaging group... | Select hazmat class... | Enter response contact name... | Enter emergency response phone number... | 0          |

 
@GUI
Scenario Outline: Verify the all required hazardous material fields are showing in red color when not entering any data in field and clicking on Get live Quote button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	And  I enter Zipcode <ShippingFrom_ValidZip> and leave focus from the origin section in GetQuote(TL) page
	And  I enter Zipcode <ShippingTo_ValidZip> and leave focus from the destination section in GetQuote(TL) page
	And I should be able to enter '<descriptiontext>' in the Description text field
	And I should be able to enter '<quantity>' in the Quantity text field
	And I should be able to enter '<Freight_Weight>' in the Weight text field
	And I click on the hazardous material Yes radio button
	And I click on the Get Live Quote button in Get Quote TL page
	Then I should be able to see the all fields background color as red

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | ShippingFrom_ValidZip | ShippingTo_ValidZip | descriptiontext | quantity | Freight_Weight | PickupDate |
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 87004              | 40000  | 33126                 | 85282               | Enter text      | 5        | 100            | 0          |