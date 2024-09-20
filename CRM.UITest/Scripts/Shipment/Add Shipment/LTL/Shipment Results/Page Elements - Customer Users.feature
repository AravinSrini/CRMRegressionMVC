@PageElementCustomerFeature @Sprint69 @28074 @GUI
Feature: Page Elements - Customer Users
	

Scenario Outline: Verify the presence of Insured value Note,Insured rate,Insured Type field
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
And I click on View rates button in add shipment ltl page
Then I will be able to see Insured value Note<_note> and Insured rate and Insured Type field

Examples: 
| Scenario | Username | Password | OName | OAddress1 | OZip  | DName | DAddress1 | DZip  | NMFC | Description | Quantity | Weight | _note                                                                          | Classification |
| S1       | zzzext   | Te$t1234 | Oname | Oadd1     | 60606 | Dname | Dadd1     | 60606 | 1234 | des         | 1        | 3      | Note: To receive Insured Rate options, you must provide a insured value below: | 50             |


Scenario Outline: Verify the presence of Filter Carriers By label, Quickest Service and Least Cost Radio button
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
And I click on View rates button in add shipment ltl page
Then I will be able to see Filter Carriers By label<_filterCarriersBy_Text> Quickest Service and Least Cost Radio button

Examples: 
| Scenario | Username | Password | OName | OAddress1 | OZip  | DName | DAddress1 | DZip  | NMFC | Description | Quantity | Weight | Classification | _filterCarriersBy_Text |
| S1       | zzzext   | Te$t1234 | Oname | Oadd1     | 60606 | Dname | Dadd1     | 60606 | 1234 | des         | 1        | 3      | 50             | Filter Carriers By:    |



Scenario Outline: Verify the presence of Grid Column with Sort button
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
And I click on View rates button in add shipment ltl page
Then I will be able to see Carrier, Service Days, Distance, Rate columns and insured rate

Examples: 
| Scenario | Username | Password | OName | OAddress1 | OZip  | DName | DAddress1 | DZip  | NMFC | Description | Quantity | Weight | Classification | 
| S1       | zzzext   | Te$t1234 | Oname | Oadd1     | 60606 | Dname | Dadd1     | 60606 | 1234 | des         | 1        | 3      | 50             | 

Scenario Outline: Verify the presence of Show Insured Rate, Terms and Conditions, Create Shipment,Create Insured Shipment, Export and Back to Shipment List buttons
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
And I pass <InsuredRate> in shipment information page
And I click on View rates button in add shipment ltl page
Then I will see Show Insured Rate, Terms and Conditions, Create Shipment,Create Insured Shipment, Export and Back to Shipment List buttons

Examples: 
| Scenario | Username | Password | OName | OAddress1 | OZip  | DName | DAddress1 | DZip  | NMFC | Description | Quantity | Weight | Classification | InsuredRate |
| S1       | zzzext   | Te$t1234 | Oname | Oadd1     | 60606 | Dname | Dadd1     | 60606 | 1234 | des         | 1        | 3      | 50             | 1           |