@30286 @Sprint69
Feature: AddShipmentLTL_MVC5_SelectClass_SavedItem_AllUsers
	
@Functional @DBVerification
Scenario Outline: Verify the dropdown values in saved items dropdown in DB for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name>
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I click on the Select Class field under Freight Description
Then number of items displaying for the <Customer_Name> in the saveditem dropdown should be matching with database

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts |

@Functional @GUI
Scenario Outline: Verify the dropdown values in saved items dropdown for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name>
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I click on the Select Class field under Freight Description
Then The saved items must be listed after the classes in numeric followed by alphabetical order with Class and Item Description
And I can able to search value from the class or saved item from dropdown

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts |

@Functional
Scenario Outline: Verify the autopopulated functionality when i select value in saved item dropdown for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name>
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I select value <SaveItem> from the Select class dropdown
Then Saved item of '<Class>', '<NMFC>', '<Quantity>', '<QuantityType>', '<Weight>', '<WeightType>', '<Length>', '<Width>', '<Height>', '<DimensionType>', '<ItemDescription>', '<UNNumber>', '<CCN>', '<HazPackagegrp>', '<HazClass>', '<EContactName>' and '<EPhoneNumber>' should be autopopulated in Freight Description section
And all the autopopulated fields will remain editable in Freight description section


Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name | SaveItem | Class   | Weight | WeightType | Quantity | QuantityType | NMFC | Length | Width | Height | DimensionType | ItemDescription | UNNumber | CCN  | HazPackagegrp | HazClass | EContactName | EPhoneNumber   |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts | 60 TEST  | 60 TEST | 22     | LBS        | 23       | Skids        | 2311 | 1      | 1     | 1      | IN            | TEST            | 2342     | CCN# | III           | 8(6.1)   | Test123      | (879) 827-8472 |

@Functional @DBVerification
Scenario Outline: Verify the dropdown values in saved items dropdown in DB for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I click on the Select Class field under Freight Description
Then number of items displaying for the <Customer_Name> in the saveditem dropdown should be matching with database

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name |
| s1       | shpentry     | Te$t1234 | Shipment List       | Dunkin Donuts |
| s2       | Entyrnorates | Te$t1234 | Shipment List       | Dunkin Donuts |

@Functional @GUI
Scenario Outline: Verify the dropdown values in saved items dropdown for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I click on the Select Class field under Freight Description
Then The saved items must be listed after the classes in numeric followed by alphabetical order with Class and Item Description
And I can able to search value from the class or saved item from dropdown

Examples: 
| Scenario | Username     | Password | ShipmentList_Header |
| s1       | shpentry     | Te$t1234 | Shipment List       |
| s2       | Entyrnorates | Te$t1234 | Shipment List       |

@Functional
Scenario Outline: Verify the autopopulated functionality when i select value in saved item dropdown for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I select value <SaveItem> from the Select class dropdown
Then Saved item of '<Class>', '<NMFC>', '<Quantity>', '<QuantityType>', '<Weight>', '<WeightType>', '<Length>', '<Width>', '<Height>', '<DimensionType>', '<ItemDescription>', '<UNNumber>', '<CCN>', '<HazPackagegrp>', '<HazClass>', '<EContactName>' and '<EPhoneNumber>' should be autopopulated in Freight Description section
And all the autopopulated fields will remain editable in Freight description section

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | SaveItem | Class   | Weight | WeightType | Quantity | QuantityType | NMFC | Length | Width | Height | DimensionType | ItemDescription | UNNumber | CCN  | HazPackagegrp | HazClass | EContactName | EPhoneNumber   |
| s1       | shpentry     | Te$t1234 | Shipment List       | 60 TEST  | 60 TEST | 22     | LBS        | 23       | Skids        | 2311 | 1      | 1     | 1      | IN            | TEST            | 2342     | CCN# | III           | 8(6.1)   | Test123      | (879) 827-8472 |
| s2       | Entyrnorates | Te$t1234 | Shipment List       | 60 TEST  | 60 TEST | 22     | LBS        | 23       | Skids        | 2311 | 1      | 1     | 1      | IN            | TEST            | 2342     | CCN# | III           | 8(6.1)   | Test123      | (879) 827-8472 |

