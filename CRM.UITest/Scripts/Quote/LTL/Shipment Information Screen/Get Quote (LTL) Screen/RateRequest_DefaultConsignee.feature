@24952 @Sprint65 

Feature: RateRequest_DefaultConsignee

@Regression
Scenario Outline: Verify Shipping To section when user mapped account has deault Consignee address
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then the address information of default Consignee address should auto-populate in the Shipping To section <Username>

Examples: 
| Scenario | Username | Password | Service |
| S1       | awg      | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify Shipping To section when user mapped account does not have deault consignee address
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen 
	Then the consignee address information section should be empty <Username> 

Examples: 
|Scenario|Username|Password |Service|
| S1     | nat    |Te$t1234 | LTL   |

@Regression
Scenario Outline: Try to edit the populated default Consignee address and verify
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then the address information of default Consignee address should auto-populate in the Shipping To section <Username>
	And User should be able to edit consignee address information <City>, <State> and <Zip>

Examples: 
| Scenario | Username | Password | Service | City  | State | Zip    |
| S1       | awg      | Te$t1234 | LTL     | Acton | ON    | L7J 0A1|

@Regression 
Scenario Outline: Verify the clear all functionality for the default Consignee populated address
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then the address information of default Consignee address should auto-populate in the Shipping To section <Username>
	And clicking on Clear Address link must clear the address in the destination saved address field
	And All populated fields will cleared/reset in the Shipping To section

Examples: 
| Scenario | Username | Password | Service |
| S1       | awg      | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify shipping To dropdown when default Consignee address exists
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then shipping to saved address dropdown should be binded to default Consignee address <Username>

Examples: 
| Scenario | Username | Password | Service |
| S1       | awg      | Te$t1234 | LTL     |


