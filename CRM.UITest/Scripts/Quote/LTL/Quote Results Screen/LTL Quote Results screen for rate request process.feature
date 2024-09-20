@LTLQuoteResults @17390 @Sprint59
Feature: LTL Quote Results screen for rate request process

#------------Sprint 64 Insured Value and Insured Type---------------

@Regression
Scenario Outline: Verify that all the required buttons are visible in  the LTL Quote Results Page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
And I will be navigated Quote results page
Then I must be displayed with Back to Quote List button
And I must be displayed with label Enter Insured Value
And I must be displayed with Terms and Conditions hyper link 
And I must be displayed with Quickest Service radio button
And I must be displayed with Least cost radio button 
And I must be displayed with DISCLAIMER information at the bottom of the page 

Examples: 
| Username | Password     | Service | SFZiporpostal | STZiporPostal | classification | weight |
| zzz      | Password@123 | LTL     | 90001         | 60606         | 100            | 1000   | 
    
@Regression
Scenario Outline: Verify Insured type 'New' when user entered insured value on Rate Results page 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
And I will be navigated Quote results page
Then I Enter valid data in <EnterInsuredValue> field
And I must be able to see the options New or Used in the Insured Type drop down
And the default value must be New 

Examples: 
| scenario | Username | Password     | Service | EnterInsuredValue | SFZiporpostal | STZiporPostal | classification | weight |
| s1       | zzz      | Password@123 | LTL     | 1000              | 90001         | 60606         | 50             | 120    |

@Regression
Scenario Outline: Verify Insured type 'Used' when user entered insured value on Rate Results page 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
And I will be navigated Quote results page
Then I Enter valid data in <EnterInsuredValue> field
And I must be displayed with <InsuredType> dropdown
And I click on Show Insured Rate button
And selected <InsuredType> must be displayed on Rate Results Page

Examples: 
| scenario | Username | Password | Service | EnterInsuredValue | SFZiporpostal | STZiporPostal | classification | weight | InsuredType |
| s1       | zzz      | Te$t1234 | LTL     | 1000              | 90001         | 60606         | 50             | 120    | Used        |

@Regression
Scenario Outline: Verify Insured type dropdown when user not entered insured value on Rate Results page 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
And I will be navigated Quote results page
Then I have not Entered valid data in <EnterInsuredValue> field
And I will not be able to select any insured type from dropdown

Examples: 
| scenario | Username | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | EnterInsuredValue |
| s1       | zzz      | Te$t1234 | LTL     | 90001         | 60606         | 50             | 250    |                   |

@Regression
Scenario Outline: Verify Insured type 'New' when user entered insured value on Insured Rate pop of Rate Results page 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
And I will be navigated Quote results page
And I click on Create shipment for selected carrier
Then I will be displayed with pop up modal
And I Enter valid data in <EnterInsuredVal> field of insured modal pop up
And I must be able to see the options New or Used in the Insured Type drop down on modal
And the default value must be New on modal

Examples: 
| scenario | Username          | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | EnterInsuredVal |
| s1       | awg@shipentry.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 1000            | 

@Regression
Scenario Outline: Verify Insured type 'Used' when user entered insured value on Insured Rate pop of Rate Results page 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
And I will be navigated Quote results page
And I click on Create shipment for selected carrier
Then I will be displayed with pop up modal
And I Enter valid data in <EnterInsuredVal> field of insured modal pop up
And I must be displayed with <InsuredType> dropdown on modal
And I click on Show Insured Rates button in the modal pop up
And selected <InsuredType> must be displayed on Rate Results Page

Examples: 
| scenario | Username          | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | EnterInsuredVal | InsuredType |
| s1       | awg@shipentry.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 1000            | Used        |

@Regression
Scenario Outline: Verify Insured type dropdown when user not entered insured value on Insured Rate pop of Rate Results page 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
And I will be navigated Quote results page
And I click on Create shipment for selected carrier
Then I will be displayed with pop up modal
And I have not Entered valid data in <EnterInsuredValue> field of modal pop up
And I will not be able to select any insured type from dropdown of modal pop up

Examples: 
| scenario | Username          | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | EnterInsuredVal |
| s1       | awg@shipentry.com |Te$t1234  | LTL     | 90001         | 60606         | 50             | 150    |	               |

@Regression
Scenario Outline: Verify when user entered Insured value and insured type on Get Quote Page is binding in Rate Results Page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I select any of the type from '<InsuredvalueType>' dropdown
And I click on view quote results button
And I will be navigated Quote results page
Then <Insuredvalue> and <InsuredvalueType> must be displayed in Rate Results Page

Examples: 
| scenario | Username | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType |
| s1       | zzz      | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | Used             |
| s1       | zzz      | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | New              |


@Regression
Scenario Outline: Verify when user logging for first time and creating shipment by not entering Insured Value and click on Do not show button in Insured pop up
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
And I click on Create shipment for selected carrier
And I will be displayed with pop up modal
And I select the continue without insured option on modal 
Then I will navigated to Create shipment screen

Examples: 
| scenario | Username          | Password  | Service | SFZiporpostal | STZiporPostal | classification | weight |
| s1       | awg@shipentry.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    |

#------------End of Sprint 64 Insured Value and Insured Type---------------

@Regression
Scenario Outline: Verify that First_Top row in the grid
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I must be displayed with Carrier Name and Carrier Logo under Carriers column
And I must be displayed with Number of Days and Direct/Indirect under Service Days column
And I must be displayed with Distance in miles under Distance column
And I must be displayed with Rate prefaced with rate value,Fuel, Line Haul, Accessorials, Create Shipment button and Save rate as quote link under Rate column
And I must be displayed with Insured Rate prefaced rate value,Fuel, Line Haul, Accessorials, Create Insured Shipment button and Save insured rate as quote link under Insured Rate column

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                         |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/  |     

@Regression
Scenario Outline: Test to verify the save your quote hyperlink and and update your shipping information link in the Quote Results when there is No Quote Results for the given combination 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I will be displayed with Save your quote hyperlink and update your shipping information link

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 99501     | Los Angeles | CA          | 99501          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline: Test to verify the navigation back to information page when user don't display rates 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I will be displayed with Save your quote hyperlink and update your shipping information link
And I click on update your shipping information link
Then i should navigate back to information page

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                       |
| zzz      | Te$t1234 | LTL     | 99501     | Los Angeles | CA          | 99501          | Los Angeles     | CA               | 70             | 100    | 1000          |http://dlscrm-dev.rrd.com/ |       
@Regression
Scenario Outline: Test to verify saving the quote by modifying the information 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I will be displayed with Save your quote hyperlink and update your shipping information link
And I click on update your shipping information link
And I update valid data in Origin section <uOriginZip>
And I update valid data in Destination section <uDestinationZip>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on save rate as quote link  for selected carrier
Then quote will  navigated to LTL confirmation screen and displayed with saved quoteID

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |uOriginZip     | uDestinationZip |
| zzz      | Te$t1234 | LTL     | 99501     | Los Angeles | CA          | 99501          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ |   90001       |     90087       |   



@Regression
Scenario Outline: Test to verify the save your quote hyperlink and update your shipping information link in the Quote Results when there is Quote Results 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I should not be displayed with Save your quote hyperlink and update your shipping information link

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                       |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          |http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline: Test to verify the Insured Rate column in the grid when user enters insured rate value
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I enters the value in <Insured Rate> Textbox
And I clicks on Show Insured Rate button
Then I should be displayed with updated Insured rate column in the grid

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | Insured Rate      |url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               |         60     | 50     |               |      1000         |http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline: Test to verify the Insured Rate column in the grid when user not pass the shipment value
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I should not be displayed with updated Insured rate column in the grid

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 60             | 50     |               | http://dlscrm-dev.rrd.com/ |                   

@Regression
Scenario Outline: Test to verify the Insured Rate column in the grid when user not enters insured rate value
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I clicks on Show Insured Rate button
Then I should be displayed with warning message in red color below the Shipment Value text box

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    |               | http://dlscrm-dev.rrd.com/ |


@Regression
Scenario Outline:To verify the insured modal on saving the standard rate when user not enters shipment value
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on Create shipment for selected carrier
Then I will be displayed with pop up modal with options do not show check box,shipment value button,Show Insured Rates and continue without insured rates button

Examples: 
| Username              | Password  | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
|results@testing.ins.com| Te$t1234  | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    |               | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline:To verify the navigation to shipment screen by selecting continue without insured rates button on insured modal
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on Create shipment for selected carrier
Then I will be displayed with pop up modal with options do not show check box,shipment value button,Show Insured Rates and continue without insured rates button
And i click on continue without insured rates button
And I will navigated to Create shipment screen

Examples: 
| Username                | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| results@testing.ins.com | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    |               | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline:To verify the insured modal on saving the insured rate 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
When I click on Create insured shipment for selected carrier
Then I should not be displayed with insuredrate pop up modal

Examples:
| Username               | Password  | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight   | ShipmentValue   | url                        |
|results@testing.ins.com | Te$t1234  | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100      | 1000            | http://dlscrm-dev.rrd.com/ |


@Regression
Scenario Outline:To verify the functionality in future login when user clicks the 'Do not Show' button
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on Create shipment for selected carrier
And I will be displayed with pop up modal
And I click on Do not Show button on the modal
And I select the continue without insured option on modal
Given i login again to the application with same user
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on Create shipment for selected carrier
Then I should not display with the modal

Examples: 
| Username               | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        | OptionLists |
|results@testing.com     | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    |               | http://dlscrm-dev.rrd.com/ | Sign Out    |

@Regression
Scenario Outline:To verify the Shipment screen on saving the standard rate when user enters shipment value
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
When I click on Create shipment for selected carrier
Then I will navigated to Create shipment screen

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ |

@Regression      
Scenario Outline:To verify the shipment screen on saving the standard rate when user not enters shipment value
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on Create shipment for selected carrier
And I select the continue without insured option on modal 
Then I will navigated to Create shipment screen

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    |               | http://dlscrm-dev.rrd.com/ |

@Regression
Scenario Outline:To verify the shipment screen on saving the Insured rate when user enters shipment value
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url> 
And I click on Create insured shipment button for selected carrier
Then I will navigated to Create shipment screen

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ |

@Regression      
Scenario Outline:To verify the confirmation of saved quote without rates
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And click on save quote anyway
Then quote will  navigated to LTL confirmation screen and displayed with saved quoteID


Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                       |
| zzz      | Te$t1234 | LTL     | 99501     | Los Angeles | CA          | 99501          | Los Angeles     | CA               | 70             | 100    | 1000          |http://dlscrm-dev.rrd.com/ | 
    

@Regression     
Scenario Outline:To verify the confirmation of saved standard quote
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on save rate as quote link  for selected carrier
Then quote will  navigated to LTL confirmation screen and displayed with saved quoteID


Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ |
 
@Regression    
Scenario Outline:To verify the confirmation of saved insured quote
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on save insured rate as quote link  for selected carrier
Then quote will  navigated to LTL confirmation screen and displayed with saved quoteID


Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ |


 @Regression  
Scenario Outline:To verify the confirmation of saved insured quote with additional services
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And   I have entered accessorials '<AdditionalService>'
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on save insured rate as quote link  for selected carrier
Then quote will  navigated to LTL confirmation screen and displayed with saved quoteID


Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        | AdditionalService |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ | COD               |

@Regression  
Scenario Outline:To verify the confirmation of saved standard quote with additional services
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And   I have entered accessorials '<AdditionalService>'
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on save rate as quote link  for selected carrier
Then quote will  navigated to LTL confirmation screen and displayed with saved quoteID


Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        | AdditionalService |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ | COD               |    


@Regression  
Scenario Outline:To verify the confirmation of saved gaurenteed rate 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on save rate as quote link  for selected carrier which has gaurenteed rate
Then quote will  navigated to LTL confirmation screen and displayed with saved quoteID


Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ |            

@Regression
Scenario Outline:To verify the DB check of saved  quote
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
And I click on save rate as quote link  for selected carrier
Then quote will  navigated to LTL confirmation screen and displayed with saved quoteID
And quote number will be saved in database


Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | url                        |
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90087          | Los Angeles     | CA               | 70             | 100    | 1000          | http://dlscrm-dev.rrd.com/ |










