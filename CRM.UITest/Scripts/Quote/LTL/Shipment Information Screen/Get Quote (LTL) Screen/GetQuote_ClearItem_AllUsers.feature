@Sprint2_Ninja @28145
Feature: GetQuote_ClearItem_AllUsers

@Regression
Scenario Outline: Verify the clear item button functionality for customer users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data in mandatory Item section <Classification>, <Weight>
    And I enter value in <Quantity> and select <Quantity_unit> from dropdown in Freight Description section
	And I click on Clear Item link
	Then item fields Classification ,Weight,Quantity and Quantity_unit should be cleared

Examples: 
| Scenario | Username | Password | Service | Classification | Weight | Quantity | Quantity_unit |
| S1       | zzzext   | Te$t1234 | LTL     | 70             | 100    | 1        | Pallets       |

@Regression
Scenario Outline: Verify the clear item button functionality for station users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on the Quote Icon
	And I have select the <Customer_Name> from customer dropdown list
	And I have clicked on Submit Rate Request button
    And I have clicked on LTL Tile of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data in mandatory Item section <Classification>, <Weight>
    And I enter value in <Quantity> and select <Quantity_unit> from dropdown in Freight Description section
	And I click on Clear Item link
	Then item fields Classification ,Weight,Quantity and Quantity_unit should be cleared

Examples: 
| Scenario | Username             | Password | Customer_Name             | Classification | Weight | Quantity | Quantity_unit |
| S1       | crmsalesusr@user.com | Te$t1234 | ZZZ Sandbox DLS Worldwide | 70             | 100    | 1        | Pallets       |

