@28302 @Sprint70 @Ignore
Feature: Print Shipping Labels button – All Users
	

Scenario Outline: Verify different available label under the drop down arrow of print shipping labels button on the Shipment Confirmation (LTL) page- Customer Users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I Click on LTL Tile page
#And I have entered required fields and Navigate till confirmation page
And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
And I click on View rates button in add shipment ltl page
And I select standard rates and click on create a shipment button
And I click on submit button
And I click on the drop down arrow of the Print Shipping Labels button
Then I will see all available option under drop down
Examples: 
| Scenario | Username     | Password | OZip |OName| OAddress1 |DZip| DName|DAddress1|Classification|NMFC|Quantity|Description|Weight|UserType | Customer_Name  |


Scenario Outline: Verify different available label under the drop down arrow of print shipping labels button on the Shipment Confirmation (LTL) page- Station Users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I Click on LTL Tile page
#And I have entered required fields and Navigate till confirmation page
And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
And I click on View rates button in add shipment ltl page
And I select standard rates and click on create a shipment button
And I click on submit button
And I click on the drop down arrow of the Print Shipping Labels button
Then I will see all available option under drop down
Examples: 
| Scenario | Username     | Password | OZip |OName| OAddress1 |DZip| DName|DAddress1|Classification|NMFC|Quantity|Description|Weight|UserType | Customer_Name  |

Scenario Outline: Verify New tab will open in CRM on selection any option from the drop down list on the Shipment Confirmation (LTL) page- Station Users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I Click on LTL Tile page
#And I have entered required fields and Navigate till confirmation page
And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
And I click on View rates button in add shipment ltl page
And I select standard rates and click on create a shipment button
And I click on submit button
And I click on any option from the drop down list <DropdownValue>
Then a new tab will open in CRM

Examples: 
| Scenario | Username     | Password | OZip |OName| OAddress1 |DZip| DName|DAddress1|Classification|NMFC|Quantity|Description|Weight|UserType | Customer_Name  |DropdownValue|


Scenario Outline: Verify New tab will open in CRM on selection any option from the drop down list on the Shipment Confirmation (LTL) page- Customer Users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I Click on LTL Tile page
#And I have entered required fields and Navigate till confirmation page
And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
And I click on View rates button in add shipment ltl page
And I select standard rates and click on create a shipment button
And I click on submit button
And I click on any option from the drop down list <DropdownValue>
Then a new tab will open in CRM
Examples: 
| Scenario | Username     | Password | OZip |OName| OAddress1 |DZip| DName|DAddress1|Classification|NMFC|Quantity|Description|Weight|UserType | Customer_Name  |DropdownValue|