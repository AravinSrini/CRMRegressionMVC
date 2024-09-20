@24147 @Sprint65 

Feature: GetQuote_AddAdditional_Item
	
 
@GUI @Functional 
Scenario Outline: Verify another set of item fields are displayed when I click on the Add Additional Item Button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	And  I have click on Add Additional item button in get quote TL page 
	And  I should be able to see additional fields <FreightDescription>,<HazardousMaterial_No_RadioButton>, <HazardousMaterial_Yes_RadioButton>,<Quantity>,<Quantity_Type>,<Freight_Weight>,<Weight_Type>
	Then I should be able to see the <RemoveButton> and <ADDAdditionalItem>
	Examples: 
	| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | FreightDescription     | HazardousMaterial_No_RadioButton | HazardousMaterial_Yes_RadioButton | Quantity          | Quantity_Type | Freight_Weight  | Weight_Type | RemoveButton | ADDAdditionalItem   | PickupDate |
	| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 87004              | 40000  | Enter a description... | No                               | Yes                               | Enter quantity... | Skids         | Enter weight... | LBS         | Remove       | Add Additional Item | 0          |


@GUI 
Scenario Outline: Verify by default Hazardous Material No radio button is selected in Freight Description section of Get Quote TL page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
    When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Date> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	And  I have click on Add Additional item button in get quote TL page 
	Then I should be able to see <HazardousMaterial_No_RadioButton> is selected by default

	Examples: 
	| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | HazardousMaterial_No_RadioButton | PickupDate |
	| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 87004              | 40000  | No                               | 0          |

@GUI 
Scenario Outline: Verify another set of item fields are removed when I click on the Remove button
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	And  I have click on Add Additional item button in get quote TL page
	And I click on the Remove button in get quote TL page
	Then I should not be able to see additional fields <FreightDescription>,<HazardousMaterial_No_RadioButton>, <HazardousMaterial_Yes_RadioButton>,<Quantity>,<Quantity_Type>,<Freight_Weight>,<Weight_Type> and <RemoveButton>
Examples: 
	| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | FreightDescription     | HazardousMaterial_No_RadioButton | HazardousMaterial_Yes_RadioButton | Quantity          | Quantity_Type | Freight_Weight  | Weight_Type | RemoveButton | PickupDate |
	| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 87004              | 40000  | Enter a description... | No                               | Yes                               | Enter quantity... | Skids         | Enter weight... | LBS         | Remove       | 0          |


@GUI 
Scenario Outline: Verify Hazardous Fields are displayed when I click on the Yes radion button in the Add Additional Item functionality of the Get Quote TL page
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	And  I have click on Add Additional item button in get quote TL page
	And I have selected the HazardousMaterial Yes RadioButton radion button
	Then I should be able to see <Add_UN_Number>, <Add_CCN_Number>, <Add_HazmatPackageGroup_DropDown>, <Add_HazmatClass_DropDown>, <Add_ResponseContactName>, and <Add_EmergencyResponsePhone_Number>

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | Add_UN_Number      | Add_CCN_Number      | Add_HazmatPackageGroup_DropDown  | Add_HazmatClass_DropDown | Add_ResponseContactName        | Add_EmergencyResponsePhone_Number        | PickupDate |
| s1       | stationtest@rrd.com | Te$t1234 | 90001         | 87004              | 40000  | Enter UN number... | Enter CCN number... | Select hazmat packaging group... | Select hazmat class...   | Enter response contact name... | Enter emergency response phone number... | 0          |