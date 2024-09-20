@Sprint69 @28010 
Feature: Add Shipment (LTL) (MVC5) - Clear Item button - All Users

@GUI 
Scenario Outline: Test to verify the clear button_internalusers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type MG/Both customer '<Account>' from the customer dropdown in shipment list
	And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	And I navigate to Add Shipment (LTL) page 
	And I have values in Freight Description section <Classification>,<Weight>,<length>,<height>,<width>,<NMFC>,<itemdesc>,<quantitytype>,<weightype>,<UNnumber>,<CCN>,<hazgroup>,<hazclass>,<contact>,<phone>
	And I click on Clear All button in Freight Description section
	Then Select or search for a class or saved items,Enter an NMFC,Enter a description,Enter a quantity,Enter a weight,Dimension fields should be cleared
	And Weight type should be defaulted to LBS
	And Hazardous Materials selection defaulted No
	And Dimension type drop down defaulted to IN

 Examples: 
| Scenario | Username              | Password | Account                   | Classification | Weight | length | height | width  |NMFC       |itemdesc   |quantitytype|weightype|UNnumber|CCN  |hazgroup|hazclass|contact|phone     |
| 1        | stationowner@test.com | Te$t1234 | ZZZ - GS Customer Test    |  50            | 1      | 1      | 1      | 1      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|
| 2        | crmOperation@user.com | Te$t1234 | Dunkin Donuts             |  50            | 2      | 2      | 2      | 2      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|
| 3        | saleTest              | Te$t1234 | GMS Company               |  50            | 3      | 3      | 3      | 3      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|
| 4        | crmsalesusr           | Te$t1234 | ZZZ Sandbox DLS Worldwide |  50            | 4      | 4      | 4      | 4      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|




@GUI @Functional
Scenario Outline: Test to verify the clear button_externalusers
	Given I am a DLS user and login into application with valid <Username> and <Password>
    And I have access to Shipment button for external users
    And I clicked on Add Shipment button
    And I have clicked on LTL tile of shipment process
    When I am taken to Add Shipment LTL page  
	And I have values in Freight Description section <Classification>,<Weight>,<length>,<height>,<width>,<NMFC>,<itemdesc>,<quantitytype>,<weightype>,<UNnumber>,<CCN>,<hazgroup>,<hazclass>,<contact>,<phone>
	And I click on Clear All button in Freight Description section
	Then Select or search for a class or saved items,Enter an NMFC,Enter a description,Enter a quantity,Enter a weight,Dimension fields should be cleared
	And Weight type should be defaulted to LBS
	And Hazardous Materials selection defaulted No
	And Dimension type drop down defaulted to IN

Examples:
| Scenario | Username     | Password |Classification | Weight | length | height | width  |NMFC       |itemdesc   |quantitytype|weightype|UNnumber|CCN  |hazgroup|hazclass|contact|phone     |
| 1        | shpentry     | Te$t1234 |  50           | 1      | 1      | 1      | 1      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|
| 2        | Entyrnorates | Te$t1234 |  50           | 1      | 1      | 1      | 1      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|            



	@GUI 
Scenario Outline: Test to verify the clear button_additionalitem_internalusers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type MG/Both customer '<Account>' from the customer dropdown in shipment list
	And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	And I navigate to Add Shipment (LTL) page 
	And I clicked on add additional item button
	And I passed values in additional item fields <Classification>,<Weight>,<length>,<height>,<width>,<NMFC>,<itemdesc>,<quantitytype>,<weightype>,<UNnumber>,<CCN>,<hazgroup>,<hazclass>,<contact>,<phone>
	And I click on Clear All button in Freight Description section in addition section
	Then Select or search for a class or saved items,Enter an NMFC,Enter a description,Enter a quantity,Enter a weight,Dimension fields should be cleared in additional section 
	And Weight type should be defaulted to LBS in additional section
	And Hazardous Materials selection defaulted No in additional section
	And Dimension type drop down defaulted to IN in additional section

 Examples: 
| Scenario | Username              | Password | Account                   | Classification | Weight | length | height | width  |NMFC       |itemdesc   |quantitytype|weightype|UNnumber|CCN  |hazgroup|hazclass|contact|phone     |
| 1        | stationowner@test.com | Te$t1234 | ZZZ - GS Customer Test    |  50            | 1      | 1      | 1      | 1      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|
| 2        | crmOperation@user.com | Te$t1234 | Dunkin Donuts             |  50            | 2      | 2      | 2      | 2      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|
| 3        | saleTest              | Te$t1234 | GMS Company               |  50            | 3      | 3      | 3      | 3      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|
| 4        | crmsalesusr           | Te$t1234 | ZZZ Sandbox DLS Worldwide |  50            | 4      | 4      | 4      | 4      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|


@GUI 
Scenario Outline: Test to verify the clear button_additionalitem_externalusers
   Given I am a DLS user and login into application with valid <Username> and <Password>
    And I have access to Shipment button for external users
    And I clicked on Add Shipment button
    And I have clicked on LTL tile of shipment process
    When I am taken to Add Shipment LTL page  
    And I click on Add additional item button
	And I passed values in additional item fields <Classification>,<Weight>,<length>,<height>,<width>,<NMFC>,<itemdesc>,<quantitytype>,<weightype>,<UNnumber>,<CCN>,<hazgroup>,<hazclass>,<contact>,<phone>
	And I click on Clear All button in Freight Description section in addition section
	Then Select or search for a class or saved items,Enter an NMFC,Enter a description,Enter a quantity,Enter a weight,Dimension fields should be cleared in additional section
	And Weight type should be defaulted to LBS in additional section
	And Hazardous Materials selection defaulted No in additional section
	And Dimension type drop down defaulted to IN in additional section

Examples:
| Scenario | Username     | Password |Classification | Weight | length | height | width  |NMFC       |itemdesc   |quantitytype|weightype|UNnumber|CCN  |hazgroup|hazclass|contact|phone     |
| 1        | shpentry     | Te$t1234 |  50           | 1      | 1      | 1      | 1      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|
| 2        | Entyrnorates | Te$t1234 |  50           | 1      | 1      | 1      | 1      |1111111    |testitems  |Drums       |KILOS    |1111    |1111 | II     | 1      |vasu   |1234567890|
