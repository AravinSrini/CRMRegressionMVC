@24951 @Sprint65 @Functional @DBVerification 
Feature: RateRequest_DefaultShipper

@Regression 
Scenario Outline: Verify Shipping from section when user mapped account has deault shipper address
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then the address information of default shipper address should auto-populate in the Shipping From section <Username>

Examples: 
| Scenario | Username | Password | Service |
| S1       | awg      | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify Shipping from section when user mapped account does not have deault shipper address
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen 
	Then the address information section should be empty <Username>

Examples: 
| Scenario | Username | Password | Service |
| S1       | nat      | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Try to edit the populated default shipper address and verify
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then the address information of default shipper address should auto-populate in the Shipping From section <Username>
	And User should be able to edit address information <City>, <State> and <Zip>

Examples: 
| Scenario | Username | Password | Service | City  | State | Zip     |
| S1       | awg      | Te$t1234 | LTL     | Acton | ON    | L7J 0A1 |

@Regression 
Scenario Outline: Verify the clear all functionality for the default shipper populated address
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then the address information of default shipper address should auto-populate in the Shipping From section <Username>
	And clicking on Clear Address link must clear the address in the origin saved address field
	And All populated fields will cleared/reset in the Shipping From section

Examples: 
| Scenario | Username | Password | Service |
| S1       | awg      | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify shipping from dropdown when default shipper address exists
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then shipping from saved address dropdown should be binded to default shipper address <Username>

Examples: 
| Scenario | Username | Password | Service |
| S1       | awg      | Te$t1234 | LTL     |

