Feature: LTLQuoteConfiramtionPage   

@Regression
Scenario Outline: Verify quote confirmation page
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When  I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
Examples: 
| Scenario | QuoteConfirmationpageText | Username            | Password | Service | ShipmentInformationPageHeaderName | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService | quantityUnit | weightUnit |
| S1       | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | Get Quote (LTL)                   | 90001     | LOS ANGELS | CA          | 90087          |  LOS ANGELS     | CA               | 60             | 23     | 12345         |                   | 3            | LPS        |


@Regression
Scenario Outline: Verify the fields on the quotes confirmation page
   Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
    When   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I will be able to see '<servicefieldText>' and name on Quote Confimation page '<Service>'
	And   I will be able to see Pickup field and date page header Quote confirmation page <Pickup_Date_Text>
    And   I will be able to see '<request_number_Text>' on Quote confirmation page
	And   I will be able to see status '<status_Text>' on Quote confirmation page
	And   I will be able to see '<UploadShippingDocumentstext>' field page header Quote confirmation page
	And   I will be able to see '<ShowQuoteDetails_link>' expand/collapse link on Quote confirmation page
	And   I will be able to see Dropzone on Quote confirmation page
	And   I will be able to see GetAnotherQuotebutton '<GetAnotherQuotebutton>' on Quote confirmation page
Examples: 
| Scenario | QuoteConfirmationpage | QuoteConfirmationpageText | Username            | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService | servicefieldText | Pickup_Date_Text | request_number_Text | status_Text | UploadShippingDocumentstext | ShowQuoteDetails_link | GetAnotherQuotebutton |
| S1       | Get Quote (LTL)       | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001     | LOS ANGELES | CA          | 90087          | LOS ANGELES     | CA               | 50             | 2      | 123           | Appointment       | SERVICE :        | PICKUP :         | REQUEST NUMBER :    | STATUS :    | Upload Shipping Documents   | Show Quote Details    | Get Another Quote     |


@Regression
Scenario Outline: Verify the drop zone section confirmation page
   Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
    When   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I will be able to see Dropzone on Quote confirmation page
	Then  I will be able see email confirmation page on quote confirmation page
Examples: 
| Scenario | QuoteConfirmationpage | QuoteConfirmationpageText | Username            | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService | servicefieldText | Pickup_Date_Text | request_number_Text | status_Text | UploadShippingDocumentstext | ShowQuoteDetails_link | GetAnotherQuotebutton |
| S1       | Get Quote (LTL)       | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001     | LOS ANGELES | CA          | 90087          | LOS ANGELES     | CA               | 50             | 2      | 123           | Appointment       | SERVICE :        | PICKUP :         | REQUEST NUMBER :    | STATUS :    | Upload Shipping Documents   | Show Quote Details    | Get Another Quote     |



#======================================================================

@Regression
Scenario Outline: Verify Show Quote Details link functionality 
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	When   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
    And   Show Quote Details link should be expandedShipment information '<ShipmentInfromationHeader>'
Examples: 
| Scenario | GetAnotherQuotebutton    | QuoteConfirmationpageText | Username            | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService | ShipmentInfromationHeader |
| S1       | Get Another Quote button | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001     | LOS ANGELES | CA          | 90087          | CA               |LOS ANGELES      |  50            |  3     |  123          |                   | SHIPMENT INFORMATION      |
    

@Regression
Scenario Outline: Verify Carrier Name field
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
   	When   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
    And   I will see Carrier name'<CarrierName>' field
    And   I will see Carrier name next to Carrier Name field '<carrierNameText>'
Examples: 
| Scenario | CarrierName  | QuoteConfirmationpageText | Username            | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService | carrierNameText |
| S1       | CARRIER NAME | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001     | LOS ANGELES | CA          | 90087          | CA               | LOS ANGELES     | 50             | 5      | 123           |                   | Name            |


@Regression
Scenario Outline: Verify Carrier Name field when no carrier available 
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	When   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
    And   I will see Carrier name'<CarrierName>' field
    And   I will see N/A Carrier name next to Carrier Name field
Examples: 
| Scenario | CarrierName  | QuoteConfirmationpageText | Username            | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | CARRIER NAME | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 99501     | LOS ANGELES | CA          | 90087          | CA               | LOS ANGELES     | 50             | 3      | 12            |                   |


@Regression
Scenario Outline: Verify Quote Amount field for statndard rates
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	When   I click on save rate as quote link  for selected carrier in results page
	Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'  
	And   I click on Show Quote Details link
    Then  I will see Quote Amount header'<QuoteAmountHeader>' field
    And   I will see Quote Amount next to Quote Amount field '<AmountText>'
Examples: 
| Scenario | QuoteAmountHeader | QuoteConfirmationpageText | AmountText | Username            | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | QUOTE AMOUNT      | Quote Confirmation        | Amount     | shipentry@gmail.com | Te$t1234 | LTL     | 90001     | LOS ANGELES | CA          | 90087          | CA               | LOS ANGELES     |  50            |  3     |               |                   |



@Regression
Scenario Outline: Verify Quote Amount field for insured rates
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	And   I click on save insured rate as quote link  for carrier '<ShipmentValue>'
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
    Then  I will see Quote Amount '<QuoteAmount>' field
    And   I will see Insred Quote Amount next to Quote Amount field '<AmountText>'
Examples: 
| Scenario | QuoteAmount  | AmountText | QuoteConfirmationpageText | Username            | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | QUOTE AMOUNT | Amount     | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001     | LOS ANGELES | CA          | 90087          | CA               | LOS ANGELES     |  50            |3       | 566           |                   |
 

@Regression
Scenario Outline: Verify Quote Amount field when no carrier available 
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When     I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    When   I click on view quote results button
	
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
    And   I will see Quote Amount '<QuoteAmount>' field
    And   I will see N/A Carrier name next to Carrier Name field
	And   I will see Insred Quote Amount next to Quote Amount field '<AmountText>'
Examples: 
| Scenario | QuoteAmount  | AmountText | QuoteConfirmationpageText | Username            | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | QUOTE AMOUNT | Amount     | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 99501     | LOS ANGELES| CA          |90087           | CA               | LOS ANGELES     |  50            |  7     | 456           |                   |


@Regression
Scenario Outline: Verify Origin Location details field details
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	
    And   I click on save rate as quote link  for selected carrier in results page
    Then   I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And    I click on Show Quote Details link
    And   I will see Origin location '<OriginLocation>' field within Quote details
	And    I will see Origin Location details next to  Origin Location field '<Country>','<OriginCity>','<OriginState>','<OriginZip>'
Examples: 
| Scenario | OriginLocation  | QuoteConfirmationpageText | Username            | Password | Service | Country | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | ORIGIN LOCATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | USA     | 90001     | LOS ANGELES | CA          | 90087          | CA               | LOS ANGELES     | 50             | 6      |               |                   |

@Regression
Scenario Outline: Verify Destination Location field details
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
    And   I will see destination'<Destination>'Location field within Quote details
	And   I will see destination Location details next to  Destination Location field '<Country>','<DestinationCity>','<DestinationState>','<DestinationZip>'
Examples: 
| Scenario | Destination          | QuoteConfirmationpageText | Username            | Password | Service | Country | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | DESTINATION LOCATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | USA     | 90001     | LOS ANGELES | CA          | 90001          | CA               | LOS ANGELES     |  50            |   9    |               |                   |

@Regression
Scenario Outline: Verify Pickup Date field within Quote details
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
 	And   I click on view quote results button
	And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
	Then  I will see Date header'<PickupDateHeader>' field within Quote details
    And   I will see Pickup Date'<PickupDate>' field within Quote details
Examples: 
| Scenario | PickupDateHeader | PickupDate  | Username            | Password | QuoteConfirmationpageText | Service | Country | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService | PickupDate_Value |
| S1       | DATES            | Pickup      | shipentry@gmail.com | Te$t1234 | Quote Confirmation        | LTL     | USA     | 90001     | LOS ANGELES | CA          | 90001          | CA               | LOS ANGELES     | 50             | 3      |               |                   |                  |

#------------Sprint 64 Insured value type---------------

@Regression
Scenario Outline: Verify Freight Information field details
Given  I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select any of the type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save rate as quote link  for selected carrier in results page
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will see Freight Information details <WeightColumnText>, <ClassColumnText>, <InsuredValueColumnText>, <InsuredTypeColumnText>, <HazmatColumnText>, <classification>, <weight>, <Insuredvalue>, <InsuredvalueType>


Examples: 
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'N/A' for Standared rates when user not entered the Insured value on GetQuote (LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I have not entered data in '<Insuredvalue>' field of Freight Description section
And I have not selected any of the type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save rate as quote link  for selected carrier in results page
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with N/A under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 60606         | 33126         | 50             | 120    |              |                  | Quote Confirmation        | FREIGHT INFORMATION | N/A         |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'New' for Standared rates when user selected Insured Value type New on GetQuote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save rate as quote link  for selected carrier in results page
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 33126         | 60606         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'Used' for Standared rates when user selected Insured Value type Used on GetQuote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save rate as quote link  for selected carrier in results page
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 33126         | 60606         | 50             | 150    | 100          | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |

@Regression
Scenario Outline: Test to verify Insured type in Freight information section on Quote Confirmation Page for standared rates when user entered Insured Value and type on Rate Results Page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
And I enter data in <Insuredvalue> field 
And I select any of the type from '<InsuredvalueType>' dropdown
And I clicks on Show Insured Rate button
And I click on save rate as quote link  for selected carrier in results page
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with the selected insuredtype under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 33126         | 60606         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'New' for Insured rates when user selected Insured Value type New on GetQuote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save insured rate as quote link  for selected carrier
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'Used' for Insured rates when user selected Insured Value type Used on GetQuote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save insured rate as quote link  for selected carrier
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'New' for Guaranteed Insured rates when user selected Insured Value type New on GetQuote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers grid
And I click on guaranteed save insured rate as quote link  for selected carrier
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 90           | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'Used' for Guaranteed Insured rates when user selected Insured Value type Used on GetQuote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers grid
And I click on guaranteed save insured rate as quote link  for selected carrier
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 90           | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'N/A' for Guaranteed standard rates when user not entered the Insured value on GetQuote (LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I have not entered data in '<Insuredvalue>' field of Freight Description section
And I have not selected any of the type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers grid
And I click on guaranteed save rate as quote link  for selected carrier
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with N/A under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    |              |                  | Quote Confirmation        | FREIGHT INFORMATION | N/A         |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'New' for Guaranteed Standard rates when user selected Insured Value type New on GetQuote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers grid
And I click on guaranteed save rate as quote link  for selected carrier
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'Used' for Guaranteed standard rates when user selected Insured Value type Used on GetQuote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers grid
And I click on guaranteed save rate as quote link  for selected carrier
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |

@Regression
Scenario Outline: Test to verify the Insured type N/A field displaying on Confirmation page when no rate results
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I select Canada Country from origin country dropdown
And I enter valid data in Origin section <OriginPostal>, <OriginCity> and <OriginProvince>
And I select Canada Country from destination country dropdown
And I enter valid data in Destination section <DestinationProvince>, <DestinationCity> and <DestinationPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I have not entered data in '<Insuredvalue>' field of Freight Description section
And I have not selected any of the type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save your quote on results page when no rates
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with N/A under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username        | Password | Service | OriginCity | OriginProvince | OriginPostal | DestinationCity | DestinationProvince | DestinationPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | nat@extuser.com | Te$t1234 | LTL     | Acton      | ON             | L7J 0A1      | Acton           | ON                  | L7J 0A1           | 50             | 120    |              |                  | Quote Confirmation        | FREIGHT INFORMATION | N/A         |

@Regression
Scenario Outline: Test to verify the Insured type New field displaying on Confirmation page when no rate results
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I select Canada Country from origin country dropdown
And I enter valid data in Origin section <OriginPostal>, <OriginCity> and <OriginProvince>
And I select Canada Country from destination country dropdown
And I enter valid data in Destination section <DestinationProvince>, <DestinationCity> and <DestinationPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save your quote on results page when no rates
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username        | Password | Service | OriginCity | OriginProvince | OriginPostal | DestinationCity | DestinationProvince | DestinationPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | nat@extuser.com | Te$t1234 | LTL     | Acton      | ON             | L7J 0A1      | Acton           | ON                  | L7J 0A1           | 50             | 120    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline: Test to verify the Insured type Used field displaying on Confirmation page when no rate results
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I select Canada Country from origin country dropdown
And I enter valid data in Origin section <OriginPostal>, <OriginCity> and <OriginProvince>
And I select Canada Country from destination country dropdown
And I enter valid data in Destination section <DestinationProvince>, <DestinationCity> and <DestinationPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save your quote on results page when no rates
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username        | Password | Service | OriginCity | OriginProvince | OriginPostal | DestinationCity | DestinationProvince | DestinationPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Acton      | ON             | L7J 0A1      | Acton           | ON                  | L7J 0A1           | 50             | 120    | 100          | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |

#------------End of Sprint 64 Insured value Type---------------

#------------Sprint 64 Services and Accessorials---------------
@Regression
Scenario Outline: Verification of Services and Accessorials section for "Ship From" and "Ship To" fields on confimation page for standard rate
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
  	And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
    And   I should be displayed with Ship From and Ship To fields under the Services and Accessorials section not Services/Accessorials label

Examples: 
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |

#Note:If need to pass multiple sercices,Please pass comma separated additional services 

@Regression
Scenario Outline: Verification for Services and Accessorials values of  "Ship From"  in Services and Accessorials when user selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
  	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
    And   I click services and accessorials dropdown on Ship From section
    And   I select a service '<Accessorials1>' from the Ship.From section dropdown
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with selected '<Accessorials1>' Services
	And   I should display with NA in ship to field in Service and Accessorials section

Examples:
 | Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1|
 | s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment  |

@Regression
Scenario Outline: Verification for Services and Accessorials values of  "Ship To:" in Services and Accessorials section when user selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
	When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
	And   I click services and accessorials dropdown on Ship To section
    And   I select a service '<Accessorials1>' from the Ship.To section dropdown
   	And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with selected to '<Accessorials1>' Services
	And   I should display with NA in Ship From field in Services and Accessorials section

Examples:
 | Scenario | FreightInformation  | QuoteConfirmationpageText  | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText  | Accessorials1|
 | s1       | FREIGHT INFORMATION | Quote Confirmation         | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?           |Appointment   |

@Regression
Scenario Outline: Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
	And   I click services and accessorials dropdown on Ship From section
    And   I select a service '<Accessorials1>' from the Ship.From section dropdown 
    And   I click services and accessorials dropdown on Ship To section
    And   I select a service '<Accessorials2>' from the ShipTo section dropdown
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
   	And  I should be displyed with selected '<Accessorials1>' and '<Accessorials2>' in details

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | 
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 

@Regression
Scenario Outline:Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user not selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with NA in Ship From and  Ship To field  in Services and Accessorials section.

Examples:
| Scenario | QuoteConfirmationpageText | Username            | Password | Service | ShipmentInformationPageHeaderName | SFZiporpostal | STZiporPostal | OriginState | DestinationZip | DestinationCity | DestinationState | classification | weight | AdditionalService | quantityUnit | weightUnit | Ship From | Ship To | N/A |Accessorials1|Accessorials2|
| S1       | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | Get Quote (LTL)                   | 90001         | 60606         | CA          | 90087          | LOS ANGELS      | CA               | 60             | 23     |                   | 3            | LPS        |           |         |     |Appointment  | Appointment |


@Regression
Scenario Outline: Verification of Services/Accessorials in the Services and Accessorials section  on confirmation page for insured rate
   Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
  	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
	And   I click on view quote results button
    And   I click on save insured rate as quote link  for selected carrier
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'   
    And   I click on Show Quote Details link
    And   I should be displayed with Ship From and Ship To fields under the Services and Accessorials section not Services/Accessorials label

Examples: 
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |

@Regression
Scenario Outline: Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user selected Accessorials in get quote for insured quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
	And   I click services and accessorials dropdown on Ship From section
    And   I select a service '<Accessorials1>' from the Ship.From section dropdown 
    And   I click services and accessorials dropdown on Ship To section
    And   I select a service '<Accessorials2>' from the ShipTo section dropdown
    And   I click on view quote results button
    And   I click on save insured rate as quote link  for selected carrier
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And   I click on Show Quote Details link
    And  I should be displyed with selected '<Accessorials1>' and '<Accessorials2>' in details

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText  | InsuredTypeColumnText | HazmatColumnText  | Accessorials1|Accessorials2|
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                   | INSURED TYPE          | HAZMAT?           |Appointment   | COD         |

@Regression
Scenario Outline:Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user not selected Accessorials in get quote for insured quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
    And   I click on view quote results button
    And   I click on save insured rate as quote link  for selected carrier
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with NA in Ship From and  Ship To field  in Services and Accessorials section.

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText  | Accessorials1|Accessorials2|
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?           |              |             |

@Regression
Scenario Outline: Verification for Services and Accessorials values of  "Ship From"  in Services and Accessorials when user multiple selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship From section
	Then  I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.From Section
    When  I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
  	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
    When  I click on view quote results button
    And   I click on save rate as quote link  for selected carrier
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And  I click on Show Quote Details link
    And   I should be displayed with selected '<Accessorials1>' and <Accessorials2> Services
	And   I should display with NA in ship to field in Service and Accessorials section

Examples:
 | Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | 
 | s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   |Construction Site  |
 
 @Regression
Scenario Outline: Verification for Services and Accessorials values of  "Ship To"  in Services and Accessorials when user multiple selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship To section
	Then  I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.To Section
    When  I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
  	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
    When  I click on view quote results button
    And   I click on save rate as quote link  for selected carrier
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And   I click on Show Quote Details link
    And   I should be displayed with selected to '<Accessorials1>' and '<Accessorials2>' Service
	And   I should display with NA in Ship From field in Services and Accessorials section

Examples:
 | Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2     | 
 | s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   |Construction Site  |
 
 @Regression
Scenario Outline: Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user selected multiple Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship From section
    Then  I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.From Section
	When  I enter valid data in Shipping From Section <SFZiporpostal>
	And   I click services and accessorials dropdown on Ship To section
    Then  I should be able to select services '<Accessorials3>' and '<Accessorials4>' from Ship.To Section
    When  I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displyed with selected all '<Accessorials1>' and '<Accessorials2>' and '<Accessorials3>' and '<Accessorials4>' in details

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2      | Accessorials3 | Accessorials4                       |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | Construction Site  | COD           | Convention-Exhibition Site Delivery |
@Regression
Scenario Outline: Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user selected Accessorials in get quote for guaranteed quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship From section
    And   I select a service '<Accessorials1>' from the Ship.From section dropdown 
	And   I enter valid data in Shipping From Section <SFZiporpostal>
	And   I click services and accessorials dropdown on Ship To section
    And   I select a service '<Accessorials2>' from the ShipTo section dropdown
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I click on view quote results button
    And   I will be navigated to Guaranteed Rate carriers grid
    And   I click on guaranteed save rate as quote link  for selected carrier
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And   I click on Show Quote Details link
    And  I should be displyed with selected '<Accessorials1>' and '<Accessorials2>' in details

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 320         | 568          |

@Regression
 Scenario Outline:Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user not selected Accessorials in get quote for guaranteed quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I click on view quote results button
	And   I navigating to results page
    And   I will be navigated to Guaranteed Rate carriers grid
    And   I click on guaranteed save rate as quote link  for selected carrier
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with NA in Ship From and  Ship To field  in Services and Accessorials section.

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 320         | 568          |


#------------End of Sprint 64 Services and Accessorials---------------
#------------End of Sprint 64 Services and Accessorials---------------


@Regression
Scenario Outline: Verify collapse the Show Quote Details link functionality
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>' 
    When   I cick on Hide Quote Details link
    Then   The shipment information will be hidden
Examples:
| Scenario | Username            | Password | QuoteConfirmationpageText | Service | Country | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | shipentry@gmail.com | Te$t1234 | Quote Confirmation        | LTL     | USA     | 90001     | LOS ANGELES | CA          | 90087          | LOS ANGELES     | CA               | 50             | 8      |               |                   |

#=========================================================================
@Regression
Scenario Outline: Verify Get Another Quote button and its functionality
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
   Then   I will see Get Another Quote'<GetAnotherQuote>' button
    And   I click on the Get Another Quote button
    And   I will return to the Service Tile selection screen in the rate request process '<GetQuoteTilePage>'
Examples: 
| Scenario | GetAnotherQuote   | GetQuoteTilePage | QuoteConfirmationpageText | Username            | Password | Service | Country | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | Get Another Quote | Get Quote        | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | USA     | 90001     | LOS ANGELES | CA          | 90087          | CA               | LOS ANGELES     | 50             | 7      |               |                   |



#==========================================================================

@Regression
Scenario Outline: Verify Back to Quote List button and its functionality
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And   I clicked on <Service> button on the select type screen of rate request process
    When  I am taken to the new responsive LTL Shipment Information screen
    When   I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
    And   I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
    And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	
    And   I click on save rate as quote link  for selected carrier in results page
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
   Then   I will see Back To Quote List button'<BacktoQuoteList>' button
    And   I click on the Back to Quote List button
    And   I will return to the Quote list page of legacy application '<QuoteListHeader>','<App_Url>'
Examples: 
| Scenario | BacktoQuoteList    | Username            | Password | QuoteListHeader | QuoteConfirmationpageText | Service | Country | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | Back To Quote List | shipentry@gmail.com | Te$t1234 | Quotes          | Quote Confirmation        | LTL     | USA     | 90001     | LOS ANGELES | CA          | 90001          | CA               | LOS ANGELES     | 50             |  5     |               |                   |


#==================================================================
