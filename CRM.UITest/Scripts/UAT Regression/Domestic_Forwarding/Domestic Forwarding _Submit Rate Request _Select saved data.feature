@30015 @Regression @Sprint70
Feature: Domestic Forwarding _Submit Rate Request _Select saved data

Scenario Outline: Verify the functionality of saved address dropdown for Origin Section
Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
And I am on the Rate Request page for Domestic Forwarding
When I select a saved address from the Origin section <AddressName>
Then The following fields LocationName, Address, Country, Zip, State and City must be populated in the Origin section <AddressName>, <AccountName>

Examples: 
| Username         | Password | AddressName         | AccountName       |
|  |  | Test Origin Address | Kim Manufacturing |

Scenario Outline: Verify the functionality of saved address dropdown for Destination Section
Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
And I am on the Rate Request page for Domestic Forwarding
When I select a saved address from the Destination section <AddressName>
Then The following fields LocationName, Address, Country, Zip, State and City must be populated in the Destination section <AddressName>, <AccountName>

Examples: 
| Username         | Password | AddressName          | AccountName       |
|  |  | Test Destination Add | Kim Manufacturing |

Scenario Outline: Verify the functonality of saved Item dropdown on Shipment Location and Dates page
Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
And I am on the Rate Request page for Domestic Forwarding
When I select a saved Item <ItemDesc>
Then The following fields Pieces, Weight, Dimensions and Description must be populated <ItemDesc>, <AccountName>

Examples: 
 | Username | Password | ItemDesc | AccountName |
||  | Test Item | Kim Manufacturing |

Scenario Outline: Verify the functionality of save and continue button in Location and Dates page
Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
And I am on the Rate Request page for Domestic Forwarding
And I have selected saved address and saved item <OAddressName>, <DAddressName> and <ItemDesc>
When I click on Save and Continue
Then I must land on the Review and Submit page
And The following fields must match the data entered while creating the rate request <OAddressName>, <DAddressName>, <ItemDesc> and <AccountName>

Examples: 
| Username         | Password | OAddressName        | DAddressName         | ItemDesc  | AccountName       |
| | Te$t1234 | Test Origin Address | Test Destination Add | Test Item | Kim Manufacturing |