@Sprint2_Ninja @25444
Feature: LTLRateRequest_DefaultQtyof1

@Regression
Scenario Outline: Verify the quantity field when default item does not have quantity value for customer users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then the Quantity field will be set to one <customerAccount> for the default item
	And quantity field is editable <quantity>

Examples: 
| Scenario | Username | Password | Service | customerAccount          | quantity | 
| S1       | zzzext   | Te$t1234 | LTL     | ZZZ - Czar Customer Test | 3        | 

@Regression
Scenario Outline: Verify the quantity field when default item does not have quantity value for stationown users
	Given I am a DLS user and login into crm with valid <Username> and <Password>
	And I click on the Quote Icon
	And I have select the <customerAccount> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I have clicked on LTL Tile of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then the Quantity field will be set to one <customerAccount> for the default item
	And quantity field is editable <quantity>

Examples: 
| Scenario | Username     | Password | Service | customerAccount          | quantity | usertype |
| S1       | crmOperation | Te$t1234 | LTL     | ZZZ - Czar Customer Test | 3        | Internal |

@Regression
Scenario Outline: Verify the quantity field when saved item does not have quantity value for customer users
	Given I am a DLS user and login into crm with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then I select <saveditem> from the Select Class field in quote shipment information page
	And the Quantity field will be set to one <customerAccount> for the default item
	And quantity field is editable <quantity>

Examples: 
| Scenario | Username | Password | Service | saveditem               | customerAccount          | quantity |
| S1       | zzzext   | Te$t1234 | LTL     | 70 Printed Matter 1@500 | ZZZ - Czar Customer Test | 3        |

@Regression
Scenario Outline: Verify the quantity field when saved item does not have quantity value for stationown users
	Given I am a DLS user and login into crm with valid <Username> and <Password>
	And I click on the Quote Icon
	And I have select the <customerAccount> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I have clicked on LTL Tile of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then I select <saveditem> from the Select Class field in quote shipment information page
	And the Quantity field will be set to one <customerAccount> for the default item
	And quantity field is editable <quantity>

Examples: 
| Scenario | Username   | Password | Service | saveditem               | customerAccount          | quantity |
| S1       | crmOperation | Te$t1234 | LTL     | 70 Printed Matter 1@500 | ZZZ - Czar Customer Test | 3        |
