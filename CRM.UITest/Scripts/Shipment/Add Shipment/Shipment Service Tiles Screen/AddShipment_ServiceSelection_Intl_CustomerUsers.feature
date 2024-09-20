@AddShipment_ServiceSelection_Intl_CustomerUsers @Sprint69 @29395 
Feature: AddShipment_ServiceSelection_Intl_CustomerUsers
	
@GUI
Scenario Outline: Verify the presence of select a service type dropdown, Continue and Close button
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
And I Click on the International Tiles
And I will be able to see International Type PopUp Modal
Then I will be able to see service type dropdown Continue and Close button

Examples: 
| Scenario | Username                | Password |
| s1       | Both@test.com			 | Te$t1234 |

@GUI
Scenario Outline: Verify the International Type PopUp Modal closes upon click on the Close button
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
And I Click on the International Tiles
And I will be able to see International Type PopUp Modal
And I click on the Close button
Then International Type PopUp Modal will be closed
Examples: 
| Scenario | Username               | Password | 
| s1       | Both@test.com			| Te$t1234 |

@GUI
Scenario Outline: Verify for the Message Please Enter All Required Information with Service Type Redhighlighted upon without selecting Service Type and Click on Continue button
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
And I Click on the International Tiles
And I will be able to see International Type PopUp Modal
And I Click on Continue button
Then the Message Please Enter All Required Information appears<_Message> with Service Type Redhighlighted
Examples: 
| Scenario | Username				 | Password   | _Message                              |
|   s1     | Both@test.com			 | Te$t1234   | PLEASE ENTER ALL REQUIRED INFORMATION |

@GUI
Scenario Outline: Verify User able to select Corresponding Service Type and Service Level Combinations
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
And I Click on the International Tiles
And I will be able to see International Type PopUp Modal
Then I will be able to select Service Type <_ServiceType>and Service Level<_ServiceLevel> Combinations
Examples: 
| Scenario | Username                | Password | _ServiceType   | _ServiceLevel     |
| s1       | Both@test.com | Te$t1234 | Air - Import   | Air Consolidation |
| s2       | Both@test.com | Te$t1234 | Air - Import   | Air Direct        |
| s3       | Both@test.com | Te$t1234 | Air - Export   | Air Consolidation |
| s4       | Both@test.com | Te$t1234 | Air - Export   | Air Direct        |
| s5       | Both@test.com | Te$t1234 | Ocean - Import | Ocean LCL         |
| s6       | Both@test.com | Te$t1234 | Ocean - Import | Ocean FCL         |
| s7       | Both@test.com | Te$t1234 | Ocean - Export | Ocean LCL         |
| s8       | Both@test.com | Te$t1234 | Ocean - Export | Ocean FCL         |

@GUI
Scenario Outline: Verify User able to Navigate to Locations and Dates Page and able to see Service Type and Service Level at Top of the page
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
And I Click on the International Tiles
And I will be able to see International Type PopUp Modal
Then I will be able to select Service Type <_ServiceType>and Service Level<_ServiceLevel> Combinations
And I Click on Continue button
And I Navigated to the International Locations and Dates Page<service>,<_IntLocaAndDates_Header>
And I able to see Service Type and Service Level at Top of the page<_ServiceType>and<_ServiceLevel>
Examples: 
| Scenario | Username                | Password | _ServiceType   | _ServiceLevel     | service       | _IntLocaAndDates_Header      |
| s1       | Both@test.com			 | Te$t1234 | Air - Import   | Air Consolidation | International | Shipment Locations and Dates |
| s2       | Both@test.com			 | Te$t1234 | Ocean - Import | Ocean LCL         | International | Shipment Locations and Dates |
