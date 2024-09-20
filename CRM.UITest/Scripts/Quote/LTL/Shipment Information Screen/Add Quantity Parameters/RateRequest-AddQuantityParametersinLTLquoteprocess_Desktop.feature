@Sprint60 @18324
Feature: RateRequest-AddQuantityParametersinLTLquoteprocess_Desktop
	
@Regression 
Scenario Outline: Verify the quantity field present in LTL shipment information page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then I should be able to see quantity field in the  - Shipment Infomation page

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify by default Skids is selected in the Quantity UOM drop down list
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then Verify the skids is selected in the Quantity UOM drop down list

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify user is able to enter only non negative Integer value in Quantity field
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter the '<PositiveValue>' other than positive integer value
	Then Verify that quantity field should not accept any negative integer '<Negativevalue>'

Examples: 
| Scenario | Username | Password | Service | Negativevalue | PositiveValue |
| S1       | nat      | Te$t1234 | LTL     | -1            | 4             |

@Regression 
Scenario Outline: Verify the options present in quantity unit field dropdown list
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I click on  Quantity field dropdown 
    Then all the unit field '<options>' should be displayed in quantity unit field dropdown list


Examples: 
| Scenario | Username        | Password | Service | options                                                                                                                                          |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Skids,Bags,Bundles,Boxes,Cabinets,Cans,Cases,Crates,Cartons,Cylinders,Drums,Pails,Pieces,Pallets,Flat Racks,Reels,Rolls,Slip Sheets,Stacks,Totes |

@Regression 
Scenario Outline: Verify the warning message when user enters greater than six in quantity field
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter greater than six <QuantityValue> in quantity field
	And  I select '<Quantityfield>' from UOM dropdown field
	Then Verify the '<warningmessage>' message for the quantity field 

Examples: 
| Scenario | Username        | Password | Service | Quantityfield | QuantityValue | warningmessage                                                                                                                                                                                                 |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Skids         | 7             | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
| S2       | nat@extuser.com | Te$t1234 | LTL     | Pallets       | 7             | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |


@Regression 
Scenario Outline: Verify the quantity field for the standard rates on confirmation page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
	And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
	And I enter valid data in Item section <Classification>, <Weight>, <ShipmentValue> and <AdditionalService>
	And I have entered qunatity <QunttutyValue> and unit <Unit>
	And I click on view quote results button    
	And  I click on save rate as quote link  for selected carrier
    Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And  I click on Show Quote Details link
	And  Show Quote Details link should be expandedShipment information '<ShipmentInfromationHeader>'
	Then Verify the Quantity field '<QuantityFieldText>','<QunttutyValue>','<Unit>' in the confirmation page matches with entered quantity value


Examples: 
| Scenario | QuoteConfirmationpageText | Username        | Password | QunttutyValue | Unit  | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Quantity | Classification | Weight | ShipmentValue | AdditionalService | ShipmentInfromationHeader | QuantityFieldText |
| S1       | Quote Confirmation        | nat@extuser.com | Te$t1234 | 5             | Skids | LTL     | 33126     | Miami      | FL          | 85282          | Tempe           | AZ               | 6        | 70             | 100    | 10000         | Appointment       | SHIPMENT INFORMATION      | QTY               |


@Regression 
Scenario Outline: Verify the quantity field for the insured rates on confirmation page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
	And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
	And I enter valid data in Item section <Classification>, <Weight>, <ShipmentValue> and <AdditionalService>
	And I have entered qunatity <QunttutyValue> and unit <Unit>
	And I click on view quote results button    
	And  I click on save insured rate as quote link  for carrier '<ShipmentValue>'
    Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And  I click on Show Quote Details link
	And  Show Quote Details link should be expandedShipment information '<ShipmentInfromationHeader>'
	Then Verify the Quantity field '<QuantityFieldText>','<QunttutyValue>','<Unit>' in the confirmation page matches with entered quantity value


Examples: 
| Scenario | Username        | QuoteConfirmationpageText | Password | QunttutyValue | Unit  | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Quantity | Classification | Weight | ShipmentValue | AdditionalService | ShipmentInfromationHeader | QuantityFieldText |
| S1       | nat@extuser.com | Quote Confirmation        | Te$t1234 | 2             | Skids | LTL     | 33126     | Miami      | FL          | 85282          | Tempe           | AZ               | 6        | 70             | 100    | 10000         | Appointment       | SHIPMENT INFORMATION      | QTY               |

@Regression 	
Scenario Outline: Verify the quantity field for the standard rates on confirmation page when no quantity value passed
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
	And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
	And I enter valid data in Item section <Classification>, <Weight>, <ShipmentValue> and <AdditionalService>
	#And I have entered qunatity <QunttutyValue> and unit <Unit> - since you do not pass any quantity remove this step
	And I click on view quote results button    
	And  I click on save rate as quote link  for selected carrier
    Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And  I click on Show Quote Details link
	And  Show Quote Details link should be expandedShipment information '<ShipmentInfromationHeader>'
	Then Verify the Quantity field '<QuantityFieldText>','<QunttutyValue>','<Unit>' in the confirmation page matches with entered quantity value


Examples: 
| Scenario | QuoteConfirmationpageText | Username        | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Quantity | Classification | Weight | ShipmentValue | AdditionalService | ShipmentInfromationHeader | QuantityFieldText | QunttutyValue | Unit  |
| S1       | Quote Confirmation        | nat@extuser.com | Te$t1234 | LTL     | 33126     | Miami      | FL          | 85282          | Tempe           | AZ               | 6        | 70             | 100    | 10000         | Appointment       | SHIPMENT INFORMATION      | QTY               |               | Skids |


@Regression 	
Scenario Outline: Verify the quantity field for the insured rates on confirmation page when no quantity value passed
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
	And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
	And I enter valid data in Item section <Classification>, <Weight>, <ShipmentValue> and <AdditionalService>
	#And I have entered qunatity <QunttutyValue> and unit <Unit> since you do not pass any quantity remove this step
	And I click on view quote results button    
	And  I click on save insured rate as quote link  for carrier '<ShipmentValue>'
    Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
	And  I click on Show Quote Details link
	And  Show Quote Details link should be expandedShipment information '<ShipmentInfromationHeader>'
	Then Verify the Quantity field '<QuantityFieldText>','<QunttutyValue>','<Unit>' in the confirmation page matches with entered quantity value


Examples: 
| Scenario | QuoteConfirmationpageText | Username        | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Quantity | Classification | Weight | ShipmentValue | AdditionalService | ShipmentInfromationHeader | QuantityFieldText | QunttutyValue | Unit  |
| S1       | Quote Confirmation        | nat@extuser.com | Te$t1234 | LTL     | 33126     | Miami      | FL          | 85282          | Tempe           | AZ               | 6        | 70             | 100    | 10000         | Appointment       | SHIPMENT INFORMATION      | QTY               |               | Skids |

