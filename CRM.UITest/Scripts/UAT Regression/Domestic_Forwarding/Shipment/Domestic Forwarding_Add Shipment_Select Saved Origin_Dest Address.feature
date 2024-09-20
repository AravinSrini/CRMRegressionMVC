@32067 @Regression @Sprint71 

Feature: Domestic Forwarding_Add Shipment_Select Saved Origin_Dest Address
	
Scenario Outline: 32067 - Verify the functionality of saved address dropdown for Origin Section
Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
And I am on the Add Shipment page for Domestic Forwarding
When I select a saved address from the Origin section <AddressName>
Then The following fields LocationName, Address, Country, Zip, State and City must be populated in the Origin section <AddressName>, <AccountName>

Examples: 
| Username | Password | AddressName         | AccountName       |
| zzzcsa   | Te$t1234 | Test Origin Address | Kim Manufacturing |

Scenario Outline: 32067 - Verify the functionality of saved address dropdown for Destination Section
Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
And I am on the Add Shipment page for Domestic Forwarding
When I select a saved address from the Destination section <AddressName>
Then The following fields LocationName, Address, Country, Zip, State and City must be populated in the Destination section <AddressName>, <AccountName>

Examples: 
| Username | Password | AddressName          | AccountName       |
| zzzcsa   | Te$t1234 | Test Destination Add | Kim Manufacturing |
