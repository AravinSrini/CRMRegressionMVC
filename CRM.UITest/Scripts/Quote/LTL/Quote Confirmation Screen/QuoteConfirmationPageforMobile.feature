@17391 @LTLQuoteconfirmationpageformobile @Sprint59
Feature: LTL Quote Confirmation for Mobile

@Regression
Scenario Outline: Verify Back to Quote List button in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And   I clicked on <Service> button on the select type screen of rate request process from mobile device
	When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data origin zip in Origin section <OriginZip>
	And   I enter valid data destination zip in Destination section <DestinationZip>
	And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	And   I click on save rate as quote link  for selected carrier '<App_Url>' in mobile device
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  the '<BacktoQuoteList>' List button will be hidden
 Examples: 
| Scenario | BacktoQuoteList    | QuoteConfirmationpageText | Username            | Password | Service | Country | OriginZip | DestinationZip |  Classification | Weight | ShipmentValue | AdditionalService | WindowWidth | WindowHeight | App_Url                    |
| S1       | Back To Quote List | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | USA     | 99501     |  90087         |  50             | 4      | 123           |                   | 412         | 732          | http://dlscrm-dev.rrd.com/ |


@Regression
Scenario Outline: Verify shipping documents text in mobile device
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And   I clicked on <Service> button on the select type screen of rate request process from mobile device
	When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data origin zip in Origin section <OriginZip>
	And   I enter valid data destination zip in Destination section <DestinationZip>
	And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	And   I click on save rate as quote link  for selected carrier '<App_Url>' in mobile device
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  Uploadshippingdocuments '<Uploadshippingdocuments>' text will be hidden
Examples: 
| Scenario | Uploadshippingdocuments   | QuoteConfirmationpageText | Username            | Password | Service | Country | OriginZip | DestinationZip |  Classification | Weight | ShipmentValue | AdditionalService | WindowWidth | WindowHeight |App_Url                     |
| S1       | Upload shipping documents | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     |  USA    |90001      |     90087      |     50          |  3     | 12            |                   | 400         | 575          | http://dlscrm-dev.rrd.com/ |


@Regression
Scenario Outline: Verify  dropzone in mobile device
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And   I clicked on <Service> button on the select type screen of rate request process from mobile device
	When  I am taken to the new responsive LTL Shipment Information screen
     And   I enter valid data origin zip in Origin section <OriginZip>
	And   I enter valid data destination zip in Destination section <DestinationZip>
	And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	And   I click on save rate as quote link  for selected carrier '<App_Url>' in mobile device
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  dropzone will be hidden
Examples:
| Scenario | dropzone | Username            | QuoteConfirmationpageText | Password | Service | Country | OriginZip |  DestinationZip | Classification | Weight | ShipmentValue | AdditionalService | WindowWidth | WindowHeight | App_Url                    |
| S1       | dropzone | shipentry@gmail.com | Quote Confirmation        | Te$t1234 | LTL     | USA     | 90001     | 90087           | 50             | 7      | 13213         |                   | 400         | 575          | http://dlscrm-dev.rrd.com/ |


@Regression
Scenario Outline: Verify scroll down functionality in mobile device
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And   I clicked on <Service> button on the select type screen of rate request process from mobile device
	When  I am taken to the new responsive LTL Shipment Information screen
     And   I enter valid data origin zip in Origin section <OriginZip>
	And   I enter valid data destination zip in Destination section <DestinationZip>
	And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
	And   I click on save rate as quote link  for selected carrier '<App_Url>' in mobile device
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then   I expand the Show Quote Details link '<ShowQuoteDetails_link>'
    Then   I will be able to scroll the details

Examples: 
| Scenario | Uploadshippingdocuments   | ShowQuoteDetails_link | QuoteConfirmationpageText | Username            | Password | Service | Country | OriginZip | DestinationZip |  Classification | Weight | ShipmentValue | AdditionalService | WindowWidth | WindowHeight | App_Url                    |
| S1       | Upload shipping documents | Show Quote Details    | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | USA     | 90001     | 90087          |  50             | 2      | 456           |                   | 400         | 575          | http://dlscrm-dev.rrd.com/ |


@Regression
Scenario Outline: Verify the fields on the quotes confirmation page in mobile devie
   Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And   I clicked on <Service> button on the select type screen of rate request process from mobile device
	When  I am taken to the new responsive LTL Shipment Information screen
     And   I enter valid data origin zip in Origin section <OriginZip>
	And   I enter valid data destination zip in Destination section <DestinationZip>
	And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier '<App_Url>' in mobile device
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I will be able to see '<servicefieldText>' and name on Quote Confimation page '<Service>'
	And   I will be able to see Pickup field and date page header Quote confirmation page <Pickup_Date_Text>
    And   I will be able to see '<request_number_Text>' on Quote confirmation page
	And   I will be able to see status '<status_Text>' on Quote confirmation page
	And   I will be able to see '<ShowQuoteDetails_link>' expand/collapse link on Quote confirmation page
	And   I will be able to see GetAnotherQuotebutton '<GetAnotherQuotebutton>' on Quote confirmation page
Examples: 
| Scenario | QuoteConfirmationpage | QuoteConfirmationpageText | Username            | Password | Service | OriginZip | DestinationZip |  Classification | Weight | ShipmentValue | WindowWidth | WindowHeight | AdditionalService | servicefieldText | Pickup_Date_Text | request_number_Text | status_Text | ShowQuoteDetails_link | GetAnotherQuotebutton | App_Url |
| S1       | Get Quote (LTL)       | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001     | 90087          |  50             | 2      | 123           | 400         | 575          |Appointment        | SERVICE :        | PICKUP :         | REQUEST NUMBER :    | STATUS :    | Show Quote Details    | Get Another Quote     | http://dlscrm-dev.rrd.com/ |


@Regression
Scenario Outline: Verify Show Quote Details link functionality in mobile
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And   I clicked on <Service> button on the select type screen of rate request process from mobile device
	When  I am taken to the new responsive LTL Shipment Information screen
     And   I enter valid data origin zip in Origin section <OriginZip>
	And   I enter valid data destination zip in Destination section <DestinationZip>
	And   I enter valid data in Item information section <Classification>, <Weight>
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier '<App_Url>' in mobile device
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
    And   Show Quote Details link should be expandedShipment information '<ShipmentInfromationHeader>'
Examples: 
| Scenario | ShipmentInfromationHeader | QuoteConfirmationpageText | Username            | Password | Service | OriginZip | DestinationZip |  Classification | Weight | ShipmentValue | WindowWidth | WindowHeight | AdditionalService | servicefieldText | Pickup_Date_Text | request_number_Text | status_Text | ShowQuoteDetails_link | GetAnotherQuotebutton | App_Url |
| S1       | SHIPMENT INFORMATION      | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001     | 90087          |  50             | 2      | 123           | 400         | 575          |Appointment        | SERVICE :        | PICKUP :         | REQUEST NUMBER :    | STATUS :    | Show Quote Details    | Get Another Quote     | http://dlscrm-dev.rrd.com/ |

#------------Sprint 64 Insured value type in mobile device---------------

@Regression
Scenario Outline: Test to verify the label Insured type in Freight information section on Quote Confirmation Page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select any of the type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will see Freight Information details <WeightColumnText>, <ClassColumnText>, <InsuredValueColumnText>, <InsuredTypeColumnText>, <HazmatColumnText>, <classification>, <weight>, <Insuredvalue>, <InsuredvalueType>

Examples: 
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText |WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 70             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'N/A' for Standared rates when user not entered the Insured value on GetQuote page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I have not entered data in '<Insuredvalue>' field of Freight Description section
And I have not selected any of the type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with N/A under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 60606         | 90001         | 50             | 120    |              |                  | Quote Confirmation        | FREIGHT INFORMATION | N/A         |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'New' for Standared rates when user selected Insured Value type New on GetQuote page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'Used' for Standared rates when user selected Insured Value type Used on GetQuote page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'New' for Insured rates when user selected Insured Value type New on GetQuote page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save insured rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'Used' for Insured rates when user selected Insured Value type Used on GetQuote page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save insured rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'New' for Guaranteed Insured rates when user selected Insured Value type New on GetQuote page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers on mobile screen
And I click on guaranteed save insured rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 90           | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'Used' for Guaranteed Insured rates when user selected Insured Value type Used on GetQuote page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers on mobile screen
And I click on guaranteed save insured rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 90           | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'N/A' for Guaranteed standard rates when user not entered the Insured value on GetQuote (LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I have not entered data in '<Insuredvalue>' field of Freight Description section
And I have not selected any of the type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers on mobile screen
And I click on guaranteed save rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with N/A under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    |              |                  | Quote Confirmation        | FREIGHT INFORMATION | N/A         |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'New' for Guaranteed Standard rates when user selected Insured Value type New on GetQuote page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers on mobile screen
And I click on guaranteed save rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type field displaying 'Used' for Guaranteed standard rates when user selected Insured Value type Used on GetQuote page of mobile screen
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated to Guaranteed Rate carriers on mobile screen
And I click on guaranteed save rate as quote link  for selected carrier on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type N/A field displaying on Confirmation page when no rate results for mobile view
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I select Canada Country from origin country dropdown
And I enter valid data in Origin section <OriginPostal>, <OriginCity> and <OriginProvince>
And I select Canada Country from destination country dropdown
And I enter valid data in Destination section <DestinationProvince>, <DestinationCity> and <DestinationPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I have not entered data in '<Insuredvalue>' field of Freight Description section
And I have not selected any of the type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save your quote link on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with N/A under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username        | Password | Service | OriginCity | OriginProvince | OriginPostal | DestinationCity | DestinationProvince | DestinationPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType | WindowWidth | WindowHeight |
| s1       | nat@extuser.com | Te$t1234 | LTL     | Acton      | ON             | L7J 0A1      | Acton           | ON                  | L7J 0A1           | 50             | 120    |              |                  | Quote Confirmation        | FREIGHT INFORMATION | N/A         | 320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type New field displaying on Confirmation page when no rate results for mobile view
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I select Canada Country from origin country dropdown
And I enter valid data in Origin section <OriginPostal>, <OriginCity> and <OriginProvince>
And I select Canada Country from destination country dropdown
And I enter valid data in Destination section <DestinationProvince>, <DestinationCity> and <DestinationPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select New insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save your quote link on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with New under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username        | Password | Service | OriginCity | OriginProvince | OriginPostal | DestinationCity | DestinationProvince | DestinationPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType | WindowWidth | WindowHeight |
| s1       | nat@extuser.com | Te$t1234 | LTL     | Acton      | ON             | L7J 0A1      | Acton           | ON                  | L7J 0A1           | 50             | 120    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         | 320         | 568          |

@Regression
Scenario Outline: Test to verify the Insured type Used field displaying on Confirmation page when no rate results for mobile view
Given I am a DLS user and login into application with valid <Username> and <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I select Canada Country from origin country dropdown
And I enter valid data in Origin section <OriginPostal>, <OriginCity> and <OriginProvince>
And I select Canada Country from destination country dropdown
And I enter valid data in Destination section <DestinationProvince>, <DestinationCity> and <DestinationPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select Used insured type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I click on save your quote link on mobile screen
Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
And I click on Show Quote Details link
And I will see FreightInformation '<FreightInformation>' field within Quote details
And I will be displayed with Used under '<InsuredType>' in FreightInformation section

Examples: 
| scenario | Username        | Password | Service | OriginCity | OriginProvince | OriginPostal | DestinationCity | DestinationProvince | DestinationPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Acton      | ON             | L7J 0A1      | Acton           | ON                  | L7J 0A1           | 50             | 120    | 100          | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        | 320         | 568          |

#------------End of Sprint 64 Insured value Type in mobile device---------------
#------------Sprint 64 Services and Accessorials---------------
@Regression
Scenario Outline: Verification of Services and Accessorials section for "Ship From" and "Ship To" fields on confimation page for standard rate
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
  	And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier on mobile screen 
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
    And   I click on Show Quote Details link
    And   I should be displayed with Ship From and Ship To fields under the Services and Accessorials section not Services/Accessorials label

Examples: 
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText |WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |320         | 568          |

#Note:If need to pass multiple sercices,Please pass comma separated additional services 
#added

@Regression
Scenario Outline: Verification for Services and Accessorials values of  "Ship From"  in Services and Accessorials when user multiple selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship From section
	Then I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.From Section
    When  I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
  	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
    When  I click on view quote results button
    And   I click on save rate as quote link  for selected carrier on mobile screen 
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And  I click on Show Quote Details link
    And   I should be displayed with selected '<Accessorials1>' and <Accessorials2> Services
	And   I should display with NA in ship to field in Service and Accessorials section

Examples:
 | Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2      | WindowWidth | WindowHeight |
 | s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   |Construction Site   |320         | 568          |



@Regression
Scenario Outline: Verification for Services and Accessorials values of  "Ship From"  in Services and Accessorials when user selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship From section
	And   I select a service '<Accessorials1>' from the Ship.From section dropdown
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
  	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier on mobile screen 
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with selected '<Accessorials1>' Services
	And   I should display with NA in ship to field in Service and Accessorials section

Examples:
 | Scenario | FreightInformation  | QuoteConfirmationpageText | Username                | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 |WindowWidth | WindowHeight |
 | s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com     | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   |320         | 568          |



@Regression
Scenario Outline: Verification for Services and Accessorials values of  "Ship To:" in Services and Accessorials section when user selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
	When  I am taken to the new responsive LTL Shipment Information screen
	And   I enter valid data in Shipping From Section <SFZiporpostal>
	And   I click services and accessorials dropdown on Ship To section
    And   I select a service '<Accessorials1>' from the Ship.To section dropdown
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
   	And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with selected to '<Accessorials1>' Services
	And   I should display with NA in Ship From field in Services and Accessorials section

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |Appointment    | COD           | 320         | 568          |

@Regression
Scenario Outline: Verification for Services and Accessorials values of  "Ship To:" in Services and Accessorials section when user multiple selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
	When  I am taken to the new responsive LTL Shipment Information screen
	When   I enter valid data in Shipping From Section <SFZiporpostal>
	And   I click services and accessorials dropdown on Ship To section
    Then I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.To Section
    When   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
   	And    I click on view quote results button
	And I navigating to results page
    And   I click on save rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And  I click on Show Quote Details link
    And   I should be displayed with selected to '<Accessorials1>' and '<Accessorials2>' Service
	And   I should display with NA in Ship From field in Services and Accessorials section

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |Appointment    | COD           | 320         | 568          |
@Regression
Scenario Outline: Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship From section
    And   I select a service '<Accessorials1>' from the Ship.From section dropdown 
	And   I enter valid data in Shipping From Section <SFZiporpostal>
	And   I click services and accessorials dropdown on Ship To section
    And   I select a service '<Accessorials2>' from the ShipTo section dropdown
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And  I should be displyed with selected '<Accessorials1>' and '<Accessorials2>' in details
Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 320         | 568          |

@Regression
Scenario Outline: Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user selected multiple Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship From section
    Then I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.From Section
	When   I enter valid data in Shipping From Section <SFZiporpostal>
	And   I click services and accessorials dropdown on Ship To section
    Then I should be able to select services '<Accessorials3>' and '<Accessorials4>' from Ship.To Section
    When   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And  I should be displyed with selected all '<Accessorials1>' and '<Accessorials2>' and '<Accessorials3>' and '<Accessorials4>' in details

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2     | WindowWidth | WindowHeight | Accessorials3 | Accessorials4 |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | Construction Site | 320         | 568          | COD           | Convention-Exhibition Site Delivery |
@Regression
Scenario Outline:Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user not selected Accessorials in get quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I click on view quote results button
    And   I click on save rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with NA in Ship From and  Ship To field  in Services and Accessorials section.

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth  | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 320         | 568          |


@Regression
Scenario Outline: Verification of Services/Accessorials in the Services and Accessorials section  on confirmation page for insured rate
    Given  I am a DLS user and login into application with valid <Username> and <Password>
    And    I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And   I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
  	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
	And   I click on view quote results button
    And   I click on save insured rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'   
    And   I click on Show Quote Details link
    And   I should be displayed with Ship From and Ship To fields under the Services and Accessorials section not Services/Accessorials label

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth  | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 320         | 568          |

@Regression
Scenario Outline: Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user selected Accessorials in get quote for insured quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And   I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship From section
    And   I select a service '<Accessorials1>' from the Ship.From section dropdown 
	And   I enter valid data in Shipping From Section <SFZiporpostal>
	And   I click services and accessorials dropdown on Ship To section
    And   I select a service '<Accessorials2>' from the ShipTo section dropdown
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
    And   I click on view quote results button
    And   I click on save insured rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And   I click on Show Quote Details link
    And  I should be displyed with selected '<Accessorials1>' and '<Accessorials2>' in details

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 320         | 568          |

@Regression
Scenario Outline:Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user not selected Accessorials in get quote for insured quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
	And   I enter data in <Insuredvalue> field 
    And   I select any of the type from '<InsuredvalueType>' dropdown
    And   I click on view quote results button
	 And  I click on save insured rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with NA in Ship From and  Ship To field  in Services and Accessorials section.

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 320         | 568          |


@Regression
Scenario Outline: Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user selected Accessorials in get quote for guaranteed quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And   I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
	And   I click services and accessorials dropdown on Ship From section
    And   I select a service '<Accessorials1>' from the Ship.From section dropdown 
	And   I enter valid data in Shipping From Section <SFZiporpostal>
	And   I click services and accessorials dropdown on Ship To section
    And   I select a service '<Accessorials2>' from the ShipTo section dropdown
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
    And   I click on view quote results button
	And   I will be navigated to Guaranteed Rate carriers on mobile screen
    And   I click on guaranteed save rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And   I click on Show Quote Details link
    And  I should be displyed with selected '<Accessorials1>' and '<Accessorials2>' in details

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 320         | 568          |

@Regression

 Scenario Outline:Verification for Services and Accessorials values of "Ship From" and  "Ship To" in Services and Accessorials section when user not selected Accessorials in get quote for guaranteed quote
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
    And  I clicked on <Service> button on the select type screen of rate request process from mobile device
    When  I am taken to the new responsive LTL Shipment Information screen
    And   I enter valid data in Shipping From Section <SFZiporpostal>
    And   I enter valid data in Shipping To Section <STZiporPostal>
    And   I enter valid data in Freight Description Section <classification>, <weight>
	And   I enter data in <Insuredvalue> field 
    And   I click on view quote results button
    And   I will be navigated to Guaranteed Rate carriers on mobile screen
    And   I click on guaranteed save rate as quote link  for selected carrier on mobile screen
    Then  I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	Then  I click on Show Quote Details link
    And   I should be displayed with NA in Ship From and  Ship To field  in Services and Accessorials section.

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | Accessorials1 | Accessorials2 | WindowWidth | WindowHeight |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | Appointment   | COD           | 320         | 568          |





#------------End of Sprint 64 Services and Accessorials---------------





