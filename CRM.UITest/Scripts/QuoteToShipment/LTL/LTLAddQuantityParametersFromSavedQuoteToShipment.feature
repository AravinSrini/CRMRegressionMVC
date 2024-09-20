@LTLQuoteToShipment @18402 @Sprint60 @NotAutomated @Ignore
Feature: LTLAddQuantityParametersFromSavedQuoteToShipment

@EndtoEnd @Functional 
Scenario Outline: Verify quantity and quantity UOM fields in shipment item information page when values are entered during rate request
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in shipment information page <OriginZip>, <OriginCity>, <OriginState>, <DestinationZip>, <DestinationCity>, <DestinationState>, <Classification>, <Weight>, <Quantity> and <QuantityUnit>
	And I click on view quote results button
	And I click on save rate as quote link  for selected carrier in rate result page <URL>
	And I will be navigated to quote confirmation page and created quote number should be displayed
	And I click on the Back to Quote List button
	And I pass created quotenumber in quote list page
	And I expand the quote details 
	And I click on create shipment button present in quote details
	And I enter data in remaining required fields present in shipment location page <OriginName>, <OriginAddress>, <DestinationName> and <DestinationLocation>
	And I click on save and continue button from shipment location and dates page
    Then Quantity <Quantity> and Quantity unit <QuantityUnit> fields should display values entered before and should be non editable

Examples: 
| Scenario | Username        | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | Quantity | QuantityUnit | OriginName | OriginAddress | DestinationName | DestinationLocation | URL                        |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 33216     | Miami      | FL          | 85282          | Tempe           | AZ               | 70             | 100    | 5        | Pallets      | Test       | Address       | D Test          | D Address           | http://dlscrm-dev.rrd.com/ |

@EndtoEnd @Functional 
Scenario Outline: Verify quantity and quantity UOM fields in shipment item information page when values are not entered during rate request
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in shipment information page without quantity and unit <OriginZip>, <OriginCity>, <OriginState>, <DestinationZip>, <DestinationCity>, <DestinationState>, <Classification> and <Weight>
	And I click on view quote results button
	And I click on save rate as quote link  for selected carrier in rate result page <URL>
	And I will be navigated to quote confirmation page and created quote number should be displayed
	And I click on the Back to Quote List button
	And I pass created quotenumber in quote list page
	And I expand the quote details 
	And I click on create shipment button present in quote details
	And I enter data in remaining required fields present in shipment location page <OriginName>, <OriginAddress>, <DestinationName> and <DestinationLocation>
	And I click on save and continue button from shipment location and dates page
    Then Quantity and Quantity unit fields should be empty and editable

Examples: 
| Scenario | Username        | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | OriginName | OriginAddress | DestinationName | DestinationLocation | URL                        |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 33216     | Miami      | FL          | 85282          | Tempe           | AZ               | 70             | 100    | Test       | Address       | D Test          | D Address           | http://dlscrm-dev.rrd.com/ |

@EndtoEnd @Functional 
Scenario Outline: Verify additional quantity and quantity UOM fields in shipment item information page when values are entered during rate request
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in shipment information page <OriginZip>, <OriginCity>, <OriginState>, <DestinationZip>, <DestinationCity>, <DestinationState>, <Classification>, <Weight>, <Quantity> and <QuantityUnit>
	And I click on add additional item link
	And I pass valid data in additional item section  <AdditionalClassification>, <AdditionalWeight>, <AdditionalQuantity> and <AdditionalQuantityUnit>
	And I click on view quote results button
	And I click on save rate as quote link  for selected carrier in rate result page <URL>
	And I will be navigated to quote confirmation page and created quote number should be displayed
	And I click on the Back to Quote List button
	And I pass created quotenumber in quote list page
	And I expand the quote details 
	And I click on create shipment button present in quote details
	And I enter data in remaining required fields present in shipment location page <OriginName>, <OriginAddress>, <DestinationName> and <DestinationLocation>
	And I click on save and continue button from shipment location and dates page
    Then passed additional Quantity <Quantity> and Quantity unit <QuantityUnit> fields should display values entered before and should be non editable

Examples: 
| Scenario | Username        | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | Quantity | QuantityUnit | OriginName | OriginAddress | DestinationName | DestinationLocation | AdditionalClassification | AdditionalWeight | AdditionalQuantity | AdditionalQuantityUnit | URL                        |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 33216     | Miami      | FL          | 85282          | Tempe           | AZ               | 70             | 100    | 5        | Skids        | Test       | Address       | D Test          | D Address           | 60                       | 200              | 3                  | Pallets                | http://dlscrm-dev.rrd.com/ |

@EndtoEnd @Functional 
Scenario Outline: Verify additional quantity and quantity UOM fields in shipment item information page when values are not entered during rate request
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in shipment information page without quantity and unit <OriginZip>, <OriginCity>, <OriginState>, <DestinationZip>, <DestinationCity>, <DestinationState>, <Classification> and <Weight>
	And I click on add additional item link
	And I pass valid data in additional item section without quantity <AdditionalClassification>, <AdditionalWeight>
	And I click on view quote results button
	And I click on save rate as quote link  for selected carrier in rate result page <URL>
	And I will be navigated to quote confirmation page and created quote number should be displayed
	And I click on the Back to Quote List button
	And I pass created quotenumber in quote list page
	And I expand the quote details 
	And I click on create shipment button present in quote details
	And I enter data in remaining required fields present in shipment location page <OriginName>, <OriginAddress>, <DestinationName> and <DestinationLocation>
	And I click on save and continue button from shipment location and dates page
    Then passed additional Quantity and Quantity unit fields should be empty and editable

Examples: 
| Scenario | Username        | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | QuoteNumber | OriginName | OriginAddress | DestinationName | DestinationLocation | AdditionalClassification | URL                        |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 33216     | Miami      | FL          | 85282          | Tempe           | AZ               | 70             | 100    | Test        | Address    | D Test        | D Address       | 60                  | 200                      | http://dlscrm-dev.rrd.com/ |

@EndtoEnd @Functional 
Scenario Outline: Verify additional quantity and quantity UOM fields on navigating back to shipment item information page when values are entered before
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in shipment information page <OriginZip>, <OriginCity>, <OriginState>, <DestinationZip>, <DestinationCity>, <DestinationState>, <Classification>, <Weight>, <Quantity> and <QuantityUnit>
	And I click on add additional item link
	And I pass valid data in additional item section  <AdditionalClassification>, <AdditionalWeight>, <AdditionalQuantity> and <AdditionalQuantityUnit>
	And I click on view quote results button
	And I click on save rate as quote link  for selected carrier in rate result page <URL>
	And I will be navigated to quote confirmation page and created quote number should be displayed
	And I click on the Back to Quote List button
	And I pass created quotenumber in quote list page
	And I expand the quote details 
	And I click on create shipment button present in quote details
	And I enter data in remaining required fields present in shipment location page <OriginName>, <OriginAddress>, <DestinationName> and <DestinationLocation>
	And I click on save and continue button from shipment location and dates page
	And I enter data in remaining required fields present in shipment item information page <ItemDescription>, <AdditionalItemDescription>
	And I click on save and continue button from shipment item information page
	And I click on back button from shipment rate results page
    Then passed additional Quantity <Quantity> and Quantity unit <QuantityUnit> fields should display values entered before and should be non editable

Examples: 
| Scenario | Username        | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | Quantity | QuantityUnit | OriginName | OriginAddress | DestinationName | DestinationLocation | AdditionalClassification | AdditionalWeight | AdditionalQuantity | AdditionalQuantityUnit | URL                        |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 33216     | Miami      | FL          | 85282          | Tempe           | AZ               | 70             | 100    | 5        | Skids        | Test       | Address       | D Test          | D Address           | 60                       | 200              | 3                  | Pallets                | http://dlscrm-dev.rrd.com/ |

@EndtoEnd @Functional 
Scenario Outline: Verify additional quantity and quantity UOM fields on navigating back to shipment item information page when values are not entered before
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in shipment information page without quantity and unit <OriginZip>, <OriginCity>, <OriginState>, <DestinationZip>, <DestinationCity>, <DestinationState>, <Classification> and <Weight>
	And I click on add additional item link
	And I pass valid data in additional item section without quantity <AdditionalClassification>, <AdditionalWeight>
	And I click on view quote results button
	And I click on save rate as quote link  for selected carrier in rate result page <URL>	
	And I will be navigated to quote confirmation page and created quote number should be displayed
	And I click on the Back to Quote List button
	And I pass created quotenumber in quote list page
	And I expand the quote details 
	And I click on create shipment button present in quote details
	And I enter data in remaining required fields present in shipment location page <OriginName>, <OriginAddress>, <DestinationName> and <DestinationLocation>
	And I click on save and continue button from shipment location and dates page
	And I enter data in remaining required fields for the additional items present in shipment item information page <ItemDescription>, <AdditionalItemDescription>, <Quantity>, <QuantityUnit>, <AdditionalQuantity>, <AdditionalQuantityUOM>
	And I click on save and continue button from shipment item information page
	And I click on back button from shipment rate results page
    Then passed Quantity and additional fields should display the value entered before <Quantity>, <QuantityUnit>, <AdditionalQuantity>, <AdditionalQuantityUOM>  and editable

Examples: 
| Scenario | Username        | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | Quantity | QuantityUnit | OriginName | OriginAddress | DestinationName | DestinationLocation | AdditionalClassification | AdditionalWeight | AdditionalQuantity | AdditionalQuantityUnit | URL                        |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 33216     | Miami      | FL          | 85282          | Tempe           | AZ               | 70             | 100    | 5        | Skids        | Test       | Address       | D Test          | D Address           | 60                       | 200              | 3                  | Pallets                | http://dlscrm-dev.rrd.com/ |