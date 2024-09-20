@Sprint69 @28008 

Feature: Add Shipment (LTL) (MVC5) - Add Additional Item - All Users
@GUI 
Scenario Outline: Test to verify the another set of all additional item fields_internalusers
	Given I am an operations, sales, sales management, or station owner user
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I choose any tms type MG/Both customer '<Account>' from the customer dropdown in shipment list
	And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	And I navigate to Add Shipment (LTL) page 
	And I clicked on add additional item button
	Then I should displayed with class or saved item field in additional item section 
	And I should be displayed with NMFC field in additional item section 
	And I should be displayed with Item Description field in additional item section 
	And I should be displayed with quantity field in additional item section 
	And I should be Quantity type drop down selector in additional item section 
	Then I should displayed with Enter a weight field in additional item section 
	And I should be displayed with Weight type drop down selector in additional item section  
	And I should be displayed with Estimate Class button in additional item section 
	And I should be displayed with Hazardous Materials radio buttons in additional item section 
	And I should be displayed with Length field in additional item section 
	And I should be displayed with Width field in additional item section 
	And I should be displayed with Height field in additional item section 
	And I should be displayed with Dimension type drop down selector in additional item section 
	And I should be displayed with Add Additional Item button in additional item section 
	And I should be displayed with Remove Item button in additional item section 
	And I should be displayed with Clear Item button in additional item section 
Examples: 
| Scenario | Username              | Password | Account                   |
| 1        | stationowner@test.com | Te$t1234 |ZZZ - GS Customer Test     |
| 2        | crmOperation@user.com | Te$t1234 |Dunkin Donuts              |
| 3        | saleTest              | Te$t1234 |GMS Company                |
| 4        | crmsalesusr           | Te$t1234 |ZZZ Sandbox DLS Worldwide  |  

@GUI 
Scenario Outline: Test to verify the default selected fields_additionalitemsection_internalusers
	Given I am an operations, sales, sales management, or station owner user
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I choose any tms type MG/Both customer '<Account>' from the customer dropdown in shipment list
	And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	And I navigate to Add Shipment (LTL) page 
	And I clicked on add additional item button
	Then Weight type should be defaulted to LBS
	And Quantity type defaulted to Skids
	And Weight type dropdown have '<WTvalues>'
	And Weight type should be defaulted to LBS in additional section
	And Hazardous Materials selection defaulted No in additional section
	And Dimension type drop down defaulted to IN in additional section
	And Dimension type dropdown '<dimvalues>' 

Examples: 
| Scenario | Username              | Password | Account                   |WTvalues         | dimvalues     |
| 1        | stationowner@test.com | Te$t1234 |ZZZ - GS Customer Test     |LBS,KILOS        |IN,FT |
| 2        | crmOperation@user.com | Te$t1234 |Dunkin Donuts              |LBS,KILOS        |IN,FT |
| 3        | saleTest              | Te$t1234 |GMS Company                |LBS,KILOS        |IN,FT |
| 4        | crmsalesusr           | Te$t1234 |ZZZ Sandbox DLS Worldwide  |LBS,KILOS        |IN,FT |  

@GUI 
Scenario Outline: Test to verify the mandatory field functionality_additionalitemsection_internalusers
	Given I am an operations, sales, sales management, or station owner user
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I choose any tms type MG/Both customer '<Account>' from the customer dropdown in shipment list
	And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	And I navigate to Add Shipment (LTL) page 
	And I clicked on add additional item button
	And I Clicked on view rates Button 
	Then saved item, Item Description, quantity field, Quantity type drop down selector, Enter a weight fields should highlight
	
Examples: 
| Scenario | Username              | Password | Account                   |
| 1        | stationowner@test.com | Te$t1234 |ZZZ - GS Customer Test     |
| 2        | crmOperation@user.com | Te$t1234 |Dunkin Donuts              |
| 3        | saleTest              | Te$t1234 |GMS Company                |
| 4        | crmsalesusr           | Te$t1234 | ZZZ Sandbox DLS Worldwide |  
	
	@GUI 
Scenario Outline: Test to verify the another set of all additional item fields_externalusers
	Given I am a external user and login with <Username> and <Password>
    And I have access to Shipment button for external users
    And I click on Add Shipment button
    And I have clicked on LTL tile of shipment process
    When I am taken to Add Shipment LTL page
	And I clicked on add additional item button
	Then I should displayed with class or saved item field in additional item section 
	And I should be displayed with NMFC field in additional item section 
	And I should be displayed with Item Description field in additional item section 
	And I should be displayed with quantity field in additional item section 
	And I should be Quantity type drop down selector in additional item section 
	Then I should displayed with Enter a weight field in additional item section 
	And I should be displayed with Weight type drop down selector in additional item section  
	And I should be displayed with Estimate Class button in additional item section 
	And I should be displayed with Hazardous Materials radio buttons in additional item section 
	And I should be displayed with Length field in additional item section 
	And I should be displayed with Width field in additional item section
	And I should be displayed with Height field in additional item section  
	And I should be displayed with Dimension type drop down selector in additional item section 
	And I should be displayed with Add Additional Item button in additional item section 
	And I should be displayed with Remove Item button in additional item section 
	And I should be displayed with Clear Item button in additional item section
	
Examples:
| Scenario | Username       | Password |
| 1        | shpentry       | Te$t1234 |
| 2        | Entyrnorates   | Te$t1234 |


@GUI 
Scenario Outline: Test to verify the default selected fields_additionalitemsection_externalusers
	Given I am a external user and login with <Username> and <Password>
    And I have access to Shipment button for external users
    And I click on Add Shipment button
    And I have clicked on LTL tile of shipment process
    When I clicked on add additional item button
	Then Weight type should be defaulted to LBS
	And Quantity type defaulted to Skids
	And Weight type dropdown have '<WTvalues>'
	And Weight type should be defaulted to LBS in additional section
	And Hazardous Materials selection defaulted No in additional section
	And Dimension type drop down defaulted to IN in additional section
	And Dimension type dropdown '<dimvalues>' 

Examples:
| Scenario | Username     | Password | WTvalues        | dimvalues            |
| 1        | shpentry     | Te$t1234 |LBS,KILOS        |IN,FT |
| 2        | Entyrnorates | Te$t1234 |LBS,KILOS        |IN,FT |


@GUI 
Scenario Outline: Test to verify the mandatory field functionality_additionalitemsection_externalusers
	Given I am a external user and login with <Username> and <Password>
    And I have access to Shipment button for external users
    And I click on Add Shipment button
    And I have clicked on LTL tile of shipment process
    When I am taken to Add Shipment LTL page  
    And I clicked on add additional item button
	And I Clicked on view rates Button 
	Then saved item, Item Description, quantity field, Quantity type drop down selector, Enter a weight fields should highlight 
	
Examples:
| Scenario | Username       | Password |
| 1        | shpentry       | Te$t1234 |
| 2        | Entyrnorates   | Te$t1234 |

