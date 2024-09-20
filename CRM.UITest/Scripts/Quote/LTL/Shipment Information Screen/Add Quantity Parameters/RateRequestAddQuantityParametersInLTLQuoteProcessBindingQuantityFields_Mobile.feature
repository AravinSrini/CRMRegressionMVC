@RateRequestAddQuantityParametersInLTLQuoteProcessBindingQuantityFieldsforMobile @18409 @Sprint60

Feature: RateRequestAddQuantityParametersInLTLQuoteProcessBindingQuantityFieldsforMobile

@Regression
Scenario Outline: Verify the Additional Quantity and Qunatity Unit Fields gets populated upon click on Add Additional Item link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
	Then another set of Quantity and Quantity Unit Fields should be populated
Examples: 
| Scenario | Username            | Password | WindowWidth | WindowHeight | Service |
| S1       | shipentry@gmail.com | Te$t1234 | 320         | 568          | LTL     |

@Regression
Scenario Outline: Verify the Additional Quantity and Qunatity Unit Fields disapears upon click on Remove Item link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
	And click on remove item 
	Then another set of Quantity and Quantity Unit Fields should disappear
Examples: 
| Scenario | Username            | Password | WindowWidth | WindowHeight | Service |
| S1       | shipentry@gmail.com | Te$t1234 | 320         | 568          | LTL     |

@Regression
Scenario Outline: Verify the Additional Quantity text appears 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
	Then Additional Quantity text appears above the Quantity textbox <QuantityLabel>
Examples: 
| Scenario | Username            | Password | WindowWidth | WindowHeight | Service | QuantityLabel |
| S1       | shipentry@gmail.com | Te$t1234 | 320         | 568          | LTL     | QUANTITY      |

@Regression
Scenario Outline: Verify the Maximum character for Quantity textbox appears 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link
Then I should be able to verify the maximum character limits Quantity textbox
Examples: 
| Scenario | Username            | Password | WindowWidth | WindowHeight | Service |
| S1       | shipentry@gmail.com | Te$t1234 | 320         | 568          | LTL     |

@Regression
Scenario Outline: Verify the Default Quantity Unit Field  
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link
Then I should be able to see default Quantity field <DefaultQuantityUnit>
Examples: 
| Scenario | Username            | Password | WindowWidth | WindowHeight | Service |DefaultQuantityUnit |
| S1       | shipentry@gmail.com | Te$t1234 | 320         | 568          | LTL     |Skids				|
