@RateRequestAddQuantityParametersInLTLQuoteProcessBindingQuantityFields @18409 @Sprint60

Feature: RateRequestAddQuantityParametersInLTLQuoteProcessBindingQuantityFields_Desktop
	
@Regression
Scenario Outline: Select any saved item with Quantity and verify the populated data for Quantity and Quantity Unit Field
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on saved items dropdown 
	And I select any item <ItemDescription>
	Then selected item data Quantity and Quantity Unit Field should be populated in the respective fields for the <Username>,<ItemDescription>

Examples: 
| Scenario | Username            | Password | Service | ItemDescription |
| S1       | nat				 | Te$t1234 | LTL	  |Item_Kello1		|

@Regression
Scenario Outline: Select any saved item with no Quantity and Verify the populated data for Quantity and Quantity Unit Field
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on saved items dropdown 
	And I select any item <ItemDescription>
	Then No data populated to the Quantity field also the Quantity Unit Fields to be set to match with Database <Username>,<ItemDescription>
Examples: 
| Scenario | Username            | Password | Service | ItemDescription			|
| S1       | nat				 | Te$t1234 | LTL     |PLASTIC HEADLINER		|


@Regression
Scenario Outline: Verify the Additional Quantity and Qunatity Unit Fields gets populated upon click on Add Additional Item link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
	Then another set of Quantity and Quantity Unit Fields should be populated
Examples: 
| Scenario | Username            | Password | Service |
| S1       | shipentry@gmail.com | Te$t1234 | LTL     |


@Regression
Scenario Outline: Verify the Additional Quantity and Qunatity Unit Fields disapears upon click on Remove Item link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
	And click on remove item 
	Then another set of Quantity and Quantity Unit Fields should disappear
Examples: 
| Scenario | Username            | Password | Service |
| S1       | shipentry@gmail.com | Te$t1234 | LTL     |


@Regression
	Scenario Outline: Verify Quantity passed in Estimated Class Lookup should appear in Quantity field and UOM field should be defaulted to Skids
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on Estimate class lookup link
	And I pass <Length>, <Width>, <Height>, <Weight>, <Quantity>
	And I click on Apply class
	Then pop-up model should be closed and passed data of Quantity and default content of UOM field should populate <Quantity>, <QuantityUnit>

Examples: 
| Scenario | Username            | Service | Password | Length | Width | Height | Weight | Quantity | Classification | QuantityUnit |
| S1       | shipentry@gmail.com | LTL     |Te$t1234  | 10	   | 10    | 10     | 100    | 5        | 60             | Skids		|

@Regression
Scenario Outline: Verify the Additional Quantity text appears 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
	Then Additional Quantity text appears above the Quantity textbox <QuantityLabel>
Examples: 
| Scenario | Username            | Password | Service | QuantityLabel |
| S1       | shipentry@gmail.com | Te$t1234 | LTL     |	QUANTITY	  |


@Regression
Scenario Outline: Verify the Maximum character for Quantity textbox appears 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
Then I should be able to verify the maximum character limits Quantity textbox

Examples: 
| Scenario | Username            | Password | Service | 
| S1       | shipentry@gmail.com | Te$t1234 | LTL     |	


@Regression
Scenario Outline: Verify the Default Quantity Unit Field  
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
Then I should be able to see default Quantity field <DefaultQuantityUnit>

Examples: 
| Scenario | Username            | Password | Service | DefaultQuantityUnit |
| S1       | shipentry@gmail.com | Te$t1234 | LTL     |	Skids				|
