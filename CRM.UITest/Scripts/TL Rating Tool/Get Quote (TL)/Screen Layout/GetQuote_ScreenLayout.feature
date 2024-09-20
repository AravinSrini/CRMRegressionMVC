@24133 @Sprint65

Feature: GetQuote_ScreenLayout

@Functional 
Scenario Outline: Verify navigation page functionality when user clicks on the Get Quote Now button in Rating Tool page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then I should be navigated to the Get Quote TL page with text as <GetQuoteText>
	And I should be able to see the '<BackToRatingTools_Button>'
	And I should be able to see the '<RequiredField_Text>' for required fields 

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | PickupDate | GetQuoteText          | BackToRatingTools_Button | RequiredField_Text                     |
| S1       | stationtest@rrd.com | Te$t1234 | 33126         | 85282              | 45000  | 0          | Get Quote (Truckload) | Back to Rating Tools     | Fields outlined in orange are required |

@GUI 
Scenario Outline: Verify the page elements on the Get Quote Truckload screen layout
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>	
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then I should be able to see the StationName, EquipmentType and <SpecialInstructions> fields 	
	And I should be able to see the <ShippingFrom_Zipcode_Postal>, <ShippingFrom_Country>, <ShippingFrom_City>, <ShippingFrom_SelectState_Province> in the Shipping From Section with <ShippingFromLable>
	And I should be able to see the <ShippingTo_Zipcode_Postal>, <ShippingTo_Country>, <ShippingTo_City>, <ShippingTo_SelectState_Province> in the Shipping To Section with <ShippingToLable>
	And I should be able to see the Pick_upDate, PickUp_FromTime, PickUp_ToTime with <PickUpDate_Lable>  in Pick up Date Picker section
	And I should be able to see the DropOffDate, DropOff_FromTime , DropOff_ToTime with <DropOffDate_Lable> in DropOff Date Picker section
	And I should be able to <FreightDescription_Lable>,<FreightDescription>, <HazardousMaterial_Yes_RadioButton>, <HazardousMaterial_No_RadioButton>, <Quanity>, <Quanity_Type>, <Freight_Weight>, <Weight_Type>, <InsuredValue>, with Add_Additional_Item and Get Live Quote Button
	And I should be able to see the Question Mark with tool tip as <QuestionMark_Information>


Examples: 
  | Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | PickupDate | SpecialInstructions                           | ShippingFrom_Zipcode_Postal | ShippingFrom_Country | ShippingFrom_City | ShippingFrom_SelectState_Province | ShippingFromLable | ShippingToLable | ShippingTo_Zipcode_Postal | ShippingTo_Country | ShippingTo_City | ShippingTo_SelectState_Province | PickUpDate_Lable | DropOffDate_Lable | FreightDescription_Lable | FreightDescription     | HazardousMaterial_Yes_RadioButton | HazardousMaterial_No_RadioButton | Quanity           | Quanity_Type | Freight_Weight  | Weight_Type | InsuredValue           | QuestionMark_Information                                                                                                    |
  | S1       | stationtest@rrd.com | Te$t1234 | 33126         | 85282              | 45000  | 0          | Enter any special instructions or comments... | Enter zip/postal code...    | United States        | Enter city...     | Select state/province...          | Shipping From     | Shipping To     | Enter zip/postal code...  | United States      | Enter city...   | Select state/province...        | Pickup Date      | Dropoff Date      | Freight Description      | Enter a description... | Yes                               | No                               | Enter quantity... | Skids        | Enter weight... | LBS         | Enter insured value... | Normal method to determine insured value: Invoice Cost, Plus Insurance Cost, Plus Any Prepaid Freight Charges, All Plus 10% |


@GUI 
Scenario Outline: Verify the required fields are outlined in orange color in Get Quote TL page
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then I should be navigated to the Get Quote TL page with text as <GetQuoteText> 
	Then all the required fields must be highlighted

Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | GetQuoteText          | PickupDate |
| S1       | stationtest@rrd.com | Te$t1234 | 33126         | 85282              | 45000  | Get Quote (Truckload) | 0          |


@GUI 
Scenario Outline: Verify the functionality of the Back To Rating Tools in Get Quote TL page
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page	
	And  I click on Back to Rating Tools button
	Then I must be naviagted back to '<RatingTools>' page

Examples: 
| Scenario | Username           | Password | OriginZipCode | DestinationZipCode | Weight | PickupDate | RatingTools      |
| S1       | stationtest@rrd.com| Te$t1234 | 33126         | 85282              | 45000  |    0       | Projected Amount |     