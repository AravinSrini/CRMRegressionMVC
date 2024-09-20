@RateRequest-DefaultItem_Desktop @22691 @Sprint64
Feature: RateRequest-DefaultItem_Desktop
	
@Regression
Scenario Outline: Verify that Freight Description section in LTL Rate Request Shipping Info Page when saved item has been designated as a Default item
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And  I click on the LTL tile
	Then The saved item information of '<Class>', '<Weight>', '<Quantity>', '<QuantityType>' should be auto-filled in the Freight Description section 

	Examples: 
	| Scenario | Username | Password | Class                  | Weight | Quantity | QuantityType |
	| S1       | zzzz     | Te$t1234 | 77.5 DEFAULT ITEM ZZZZ | 50     | 100      | Skids        |

@Regression
Scenario Outline: Verify that all of the fields in the Freight Description section should remain editable
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And  I click on the LTL tile
	Then All of the auto-filled fields in the Freight Description section should remain editable

	Examples: 
	| Scenario | Username | Password |
	| S1       | zzzz     | Te$t1234 |
