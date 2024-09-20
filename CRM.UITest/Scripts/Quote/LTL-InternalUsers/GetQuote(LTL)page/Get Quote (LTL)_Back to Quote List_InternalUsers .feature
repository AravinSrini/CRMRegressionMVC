@26392 @Sprint67
Feature: Get Quote (LTL)_Back to Quote List_InternalUsers 
	
@Regression 
Scenario Outline: 26392_Verify Back to Quote list button on Get Quote(LTL) page
Given I am a DLS user and login into an application with valid Username and Password
And I click on the Quote Icon
And I should be navigated to the Quote List <QuoteList_Header>page
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
Then I should be displayed with Back to Quote List button

Examples: 
| QuoteList_Header | Customer_Name  |
| Quote List       | testing_uat123 |

@Regression 
Scenario Outline: 26392_Verify the Back to Quote list button functionality on Get Quote(LTL) page
Given I am a DLS user and login into an application with valid Username and Password
And I click on the Quote Icon
And I should be navigated to the Quote List <QuoteList_Header>page
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on Back to Quote List button
Then I should be navigated back to quote list page

Examples: 
| QuoteList_Header | Customer_Name  |
| Quote List       | testing_uat123 |
