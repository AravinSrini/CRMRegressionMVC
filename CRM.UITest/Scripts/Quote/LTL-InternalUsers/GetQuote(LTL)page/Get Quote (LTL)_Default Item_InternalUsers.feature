@26401 @Sprint67
Feature: Get Quote (LTL)_Default Item_InternalUsers
	
@Regression 
Scenario Outline: 26401_Verify the Freight description section when saved item has been designated as default item
Given I am a DLS user and login into an application with valid Username and Password
And I click on the Quote Icon
And I should be navigated to the Quote List <QuoteList_Header>page
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
Then Class, Weight, Quantity and QuantityUnit should be autopopulated if the customer has the default items in DB <Customer_Name>

Examples: 
| QuoteList_Header | Customer_Name |
| Quote List       | Dunkin Donuts |

@Regression 
Scenario Outline: 26401_Verify all of the fields in the Freight description section will remain editable 
Given I am a DLS user and login into an application with valid Username and Password
And I click on the Quote Icon
And I should be navigated to the Quote List <QuoteList_Header>page
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
Then All of the fields which are auto populated should remain editable in Freight description section

Examples: 
| QuoteList_Header | Customer_Name |
| Quote List       | Dunkin Donuts |