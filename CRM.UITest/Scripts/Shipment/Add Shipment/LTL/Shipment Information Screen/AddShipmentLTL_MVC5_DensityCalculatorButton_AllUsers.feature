@28011 @Sprint69
Feature: AddShipmentLTL_MVC5_DensityCalculatorButton_AllUsers

@GUI
Scenario Outline: Verify the message when user hover Density Calculator icon for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name>
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
Then on mouse hover on the Density Calculator icon I should be able to see the message as '<Estimate_Class>'

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             | Estimate_Class |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             | Estimate Class |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  | Estimate Class |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    | Estimate Class |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide | Estimate Class |

@Functional
Scenario Outline: Verify the fields in Estimated class lookup modal for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then Estimated Class Lookup modal will be displayed
And I will see the fields <Length>, <Width>, <Height>, <Weight> and <Quantity> with in the Estimated class lookup modal

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             | Length      | Width      | Height      | Weight       | Quantity |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             | LENGTH (IN) | WIDTH (IN) | HEIGHT (IN) | WEIGHT (LBS) | QUANTITY |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  | LENGTH (IN) | WIDTH (IN) | HEIGHT (IN) | WEIGHT (LBS) | QUANTITY |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    | LENGTH (IN) | WIDTH (IN) | HEIGHT (IN) | WEIGHT (LBS) | QUANTITY |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide | LENGTH (IN) | WIDTH (IN) | HEIGHT (IN) | WEIGHT (LBS) | QUANTITY |

@Functional
Scenario Outline: Verify 'Show Density Class Table' link functionality for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
And I click on SHOW DENSITY CLASS TABLE link
Then show predefined denisity table should be displayed and link should be changed to HIDE DENSITY CLASS TABLE

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide |

@Functional
Scenario Outline: Verify 'Hide Density Class Table' link functionality for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
And I click on SHOW DENSITY CLASS TABLE link
And I click on HIDE DENSITY CLASS TABLE
Then show predefined denisity table should not be displayed and link should be changed to SHOW DENSITY CLASS 

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide |

@Functional
Scenario Outline: Verify Apply class button functionality when user passed valid data in estimated class popup for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
And I enter values in <Length>, <Width>, <Height>, <Weight> and <Quantity> 
And I click on Apply class
Then Modal popup should be closed and passed data should be populated into respective fields <Length>, <Width>, <Height>, <Weight>, <Quantity> and <Class> 

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             | Length | Width | Height | Weight | Quantity | Class | 
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             | 10     | 10    | 10     | 100    | 5        | 60    | 
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  | 10     | 10    | 10     | 100    | 5        | 60    | 
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    | 10     | 10    | 10     | 100    | 5        | 60    | 
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide | 10     | 10    | 10     | 100    | 5        | 60    | 

@Functional
Scenario Outline: Verify Apply class button functionality when user not passed data in estimated class popup for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then Apply class button should be disabled till the data passed in all the required fields

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide |

@Functional
Scenario Outline: Verify Close button functionality in estimated class popup for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
And I clicked on close button in esitmate class popup
Then pop-up model should be closed

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide |

@Functional
Scenario Outline: Verify the maximum limit for all fields in Density calculator modal for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then I should be able to verify the maximum character limits for all the fields

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide |

@Functional
Scenario Outline: Verify the error message when not entered data in any of the fields in estimated lookup modal for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then Verify the error message '<Error_Message>' is displayed

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             | Error_Message           |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             | PLEASE ENTER ALL VALUES |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  | PLEASE ENTER ALL VALUES |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    | PLEASE ENTER ALL VALUES |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide | PLEASE ENTER ALL VALUES |

@Functional
Scenario Outline: Verify the warning message when user entered more than threshold value in Quanity field in estimated lookup modal for all internal non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then Verify the warning message '<Quantity_Warning_Message>' is displayed when quanity exceeds the LTL threshold value

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             | Quantity_Warning_Message                                                                                                                                                                                       |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |

@Functional
Scenario Outline: Verify the warning message when I enter more than threshold value in Weight field in estimated lookup modal for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected Customer from the dropdown <Customer_Name> 
And I clicked on Add Shipment button for internalusers
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon	
Then Verify the warning message '<Weight_Warning_Message>' is displayed when weight exceeds the LTL threshold value

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customer_Name             | Weight_Warning_Message                                                                                                                                                                      |
| s1       | crmOperation | Te$t1234 | Shipment List       | Dunkin Donuts             | The entered weight exceeds the LTL threshold of 10,000 lbs. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZZ - Czar Customer Test  | The entered weight exceeds the LTL threshold of 10,000 lbs. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZZ - GS Customer Test    | The entered weight exceeds the LTL threshold of 10,000 lbs. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZZ Sandbox DLS Worldwide | The entered weight exceeds the LTL threshold of 10,000 lbs. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |

@GUI
Scenario Outline: Verify the message when user hover Density Calculator icon for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
Then on mouse hover on the Density Calculator icon I should be able to see the message as '<Estimate_Class>'

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | Estimate_Class |
| s1       | shpent      | Te$t1234 | Shipment List       | Estimate Class |
| s2       | shpentnorts | Te$t1234 | Shipment List       | Estimate Class |

@Functional
Scenario Outline: Verify the fields in Estimated class lookup modal for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then Estimated Class Lookup modal will be displayed
And I will see the fields <Length>, <Width>, <Height>, <Weight> and <Quantity> with in the Estimated class lookup modal

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | Length      | Width      | Height      | Weight       | Quantity |
| s1       | shpent      | Te$t1234 | Shipment List       | LENGTH (IN) | WIDTH (IN) | HEIGHT (IN) | WEIGHT (LBS) | QUANTITY |
| s2       | shpentnorts | Te$t1234 | Shipment List       | LENGTH (IN) | WIDTH (IN) | HEIGHT (IN) | WEIGHT (LBS) | QUANTITY |

@Functional
Scenario Outline: Verify 'Show Density Class Table' link functionality for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
And I click on SHOW DENSITY CLASS TABLE link
Then show predefined denisity table should be displayed and link should be changed to HIDE DENSITY CLASS TABLE

Examples: 
| Scenario | Username    | Password | ShipmentList_Header |
| s1       | shpent      | Te$t1234 | Shipment List       |
| s2       | shpentnorts | Te$t1234 | Shipment List       |

@Functional
Scenario Outline: Verify 'Hide Density Class Table' link functionality for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
And I click on SHOW DENSITY CLASS TABLE link
And I click on HIDE DENSITY CLASS TABLE
Then show predefined denisity table should not be displayed and link should be changed to SHOW DENSITY CLASS 

Examples: 
| Scenario | Username    | Password | ShipmentList_Header |
| s1       | shpent      | Te$t1234 | Shipment List       |
| s2       | shpentnorts | Te$t1234 | Shipment List       |

@Functional
Scenario Outline: Verify Apply class button functionality when user passed valid data in estimated class popup for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
And I enter values in <Length>, <Width>, <Height>, <Weight> and <Quantity>
And I click on Apply class
Then Modal popup should be closed and passed data should be populated into respective fields <Length>, <Width>, <Height>, <Weight>, <Quantity> and <Class> 

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | Length | Width | Height | Weight | Quantity | Class | 
| s1       | shpent      | Te$t1234 | Shipment List       | 10     | 10    | 10     | 100    | 5        | 60    | 
| s2       | shpentnorts | Te$t1234 | Shipment List       | 10     | 10    | 10     | 100    | 5        | 60    |

@Functional
Scenario Outline: Verify Apply class button functionality when user not passed data in estimated class popup for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then Apply class button should be disabled till the data passed in all the required fields

Examples: 
| Scenario | Username    | Password | ShipmentList_Header |
| s1       | shpent      | Te$t1234 | Shipment List       |
| s2       | shpentnorts | Te$t1234 | Shipment List       |

@Functional
Scenario Outline: Verify Close button functionality in estimated class popup for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
And I clicked on close button in esitmate class popup
Then pop-up model should be closed

Examples: 
| Scenario | Username    | Password | ShipmentList_Header |
| s1       | shpent      | Te$t1234 | Shipment List       |
| s2       | shpentnorts | Te$t1234 | Shipment List       |

@Functional
Scenario Outline: Verify the maximum limit for all fields in Density calculator modal for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then I should be able to verify the maximum character limits for all the fields

Examples: 
| Scenario | Username    | Password | ShipmentList_Header |
| s1       | shpent      | Te$t1234 | Shipment List       |
| s2       | shpentnorts | Te$t1234 | Shipment List       |

@Functional
Scenario Outline: Verify the error message when not entered data in any of the fields in estimated lookup modal for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then Verify the error message '<Error_Message>' is displayed

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | Error_Message           |
| s1       | shpent      | Te$t1234 | Shipment List       | PLEASE ENTER ALL VALUES |
| s1       | shpentnorts | Te$t1234 | Shipment List       | PLEASE ENTER ALL VALUES |

@Functional
Scenario Outline: Verify the warning message when user entered more than threshold value in Quanity field in estimated lookup modal for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon
Then Verify the warning message '<Quantity_Warning_Message>' is displayed when quanity exceeds the LTL threshold value

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | Quantity_Warning_Message                                                                                                                                                                                       |
| s1       | shpent      | Te$t1234 | Shipment List       | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
| s1       | shpentnorts | Te$t1234 | Shipment List       | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |

@Functional
Scenario Outline: Verify the warning message when I enter more than threshold value in Weight field in estimated lookup modal for external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I clicked on Add Shipment button
And I have clicked on LTL tile of shipment process
When I am taken to Add Shipment LTL page
And I clicked on the Density calculator Icon	
Then Verify the warning message '<Weight_Warning_Message>' is displayed when weight exceeds the LTL threshold value

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | Weight_Warning_Message                                                                                                                                                                      |
| s1       | shpent      | Te$t1234 | Shipment List       | The entered weight exceeds the LTL threshold of 10,000 lbs. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
| s2       | shpentnorts | Te$t1234 | Shipment List       | The entered weight exceeds the LTL threshold of 10,000 lbs. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information. |
