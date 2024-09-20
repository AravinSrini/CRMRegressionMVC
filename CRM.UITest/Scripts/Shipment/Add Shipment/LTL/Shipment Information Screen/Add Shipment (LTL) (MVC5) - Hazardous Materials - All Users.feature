@Sprint68 @27970

Feature: Add Shipment (LTL) (MVC5) - Hazardous Materials - All Users

@GUI @Hazmat
Scenario Outline: Test to verify the Hazardous fields _internalusers
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type MG/Both customer '<Account>' from the customer dropdown in shipment list
	And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	And I navigate to Add Shipment (LTL) page  
	And I click on yes button for Hazardous Materials in the Freight Description section
	Then I should display with UN Number and CCN number
	And I should display with hazmat packing group with dropdown values '<groups>'
	And I should be displayed with hazmat class dropdownvalues '<classvalues>'
	And I should be display with hazmat class,emergency response name,emergency response phone
	
 Examples: 
| Scenario | Username              | Password | groups                                        | Account                  | classvalues                                                                                                                                                                                          |
| 1        | stationowner@test.com | Te$t1234 | Select hazmat packaging group...,I,II,III,N/A |ZZZ - GS Customer Test    |Select hazmat class...,1,1.1,1.2,1.3,1.4,1.4G,1.4S,1.5,1.6,2,2.1,2.2,2.3,3,3(6.1),3(6.1)(8),3(8),4,4.1,4.2,4.3,5,5.1,5.1(8),5.1(8)(6.1),5.2,5.2(8),6,6.1,6.1(3)(8),6.1(8),6.2,7,8,8(3),8(5.1),8(6.1),9 |
| 2        | crmOperation@user.com | Te$t1234 | Select hazmat packaging group...,I,II,III,N/A |Dunkin Donuts             |Select hazmat class...,1,1.1,1.2,1.3,1.4,1.4G,1.4S,1.5,1.6,2,2.1,2.2,2.3,3,3(6.1),3(6.1)(8),3(8),4,4.1,4.2,4.3,5,5.1,5.1(8),5.1(8)(6.1),5.2,5.2(8),6,6.1,6.1(3)(8),6.1(8),6.2,7,8,8(3),8(5.1),8(6.1),9|                                                                                                                                                                         
| 3        | saleTest              | Te$t1234 | Select hazmat packaging group...,I,II,III,N/A |GMS Company               |Select hazmat class...,1,1.1,1.2,1.3,1.4,1.4G,1.4S,1.5,1.6,2,2.1,2.2,2.3,3,3(6.1),3(6.1)(8),3(8),4,4.1,4.2,4.3,5,5.1,5.1(8),5.1(8)(6.1),5.2,5.2(8),6,6.1,6.1(3)(8),6.1(8),6.2,7,8,8(3),8(5.1),8(6.1),9|
| 4        | crmsalesusr           | Te$t1234 | Select hazmat packaging group...,I,II,III,N/A  |ZZZ Sandbox DLS Worldwide |Select hazmat class...,1,1.1,1.2,1.3,1.4,1.4G,1.4S,1.5,1.6,2,2.1,2.2,2.3,3,3(6.1),3(6.1)(8),3(8),4,4.1,4.2,4.3,5,5.1,5.1(8),5.1(8)(6.1),5.2,5.2(8),6,6.1,6.1(3)(8),6.1(8),6.2,7,8,8(3),8(5.1),8(6.1),9|



@GUI @Hazmat
Scenario Outline: Test to verify the Hazardous fields validations _internalusers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type MG/Both customer '<Account>' from the customer dropdown in shipment list
	And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	And I navigate to Add Shipment (LTL) page
	And I click on yes button for Hazardous Materials in the Freight Description section
	Then I can able to enter only numeric, min and max length four in  UN Number '<UNNumber>'
	And I can able to enter only numerics in CCN number '<CCNnumber>' 
	And I can able to enter only text in emergency response name '<emergencyresponsename>' 
	And I can able to enter only phonenumberformat <phonenumber>

 Examples: 
| Scenario | Username              | Password | UNNumber | CCNnumber | emergencyresponsename | phonenumber | Account                 |
| 1        | stationowner@test.com | Te$t1234 | 12345    | 1234A     | vassu1                | 12345678901 |ZZZ - GS Customer Test   |
| 2        | crmOperation@user.com | Te$t1234 | 12345    | 1234A     | vassu1                | 12345678901 |Dunkin Donuts            |
| 3        | saleTest              | Te$t1234 | 12345    | 1234A     | vassu1                | 12345678901 |GMS Company              |
| 4        | crmsalesusr           | Te$t1234 | 12345    | 1234A     | vassu1                | 12345678901 |ZZZ Sandbox DLS Worldwide|


@GUI @Hazmat
Scenario Outline: Test to verify the mandatory functionality_Hazardous fields_internalusers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any tms type MG/Both customer '<Account>' from the customer dropdown in shipment list
	And I click on the add Shipment Button
	And I click on LTL tile on the Add Shipment landing page
	And I navigate to Add Shipment (LTL) page
	And I click on Clear All button in Freight Description section
	And I click on yes button for Hazardous Materials in the Freight Description section
	And I click on view rates button
	Then UN Number and CCN number,hazmat packing group,hazmat class,emergencyresponsename, emergencyresponsephone fields should highlight 

Examples: 
| Scenario | Username              | Password | Account                  |
| 1        | stationowner@test.com | Te$t1234 |ZZZ - GS Customer Test    |
| 2        | crmOperation@user.com | Te$t1234 |Dunkin Donuts             |
| 3        | saleTest              | Te$t1234 |GMS Company               |
| 4        | crmsalesusr           | Te$t1234 |ZZZ Sandbox DLS Worldwide |  

	@GUI @Hazmat
Scenario Outline: Test to verify the Hazardous fields _externalusers
	Given I am a DLS user and login into application with valid <Username> and <Password>
    And I have access to Shipment button for external users
    And I clicked on Add Shipment button
    And I have clicked on LTL tile of shipment process
    When I am taken to Add Shipment LTL page 
	And I click on yes button for Hazardous Materials in the Freight Description section
	Then I should display with UN Number and CCN number
	And I should display with hazmat packing group with dropdown values '<groups>'
	And I should be display with hazmat class,emergency response name,emergency response phone
	And I should be displayed with hazmat class dropdownvalues '<classvalues>'


Examples:
| Scenario | Username     | Password | groups                                        | classvalues                                                                                                                                                                                      |
| 1        | shpentry     | Te$t1234 |Select hazmat packaging group...,I,II,III,N/A  |Select hazmat class...,1,1.1,1.2,1.3,1.4,1.4G,1.4S,1.5,1.6,2,2.1,2.2,2.3,3,3(6.1),3(6.1)(8),3(8),4,4.1,4.2,4.3,5,5.1,5.1(8),5.1(8)(6.1),5.2,5.2(8),6,6.1,6.1(3)(8),6.1(8),6.2,7,8,8(3),8(5.1),8(6.1),9   |
| 2        | Entyrnorates | Te$t1234 | Select hazmat packaging group...,I,II,III,N/A |Select hazmat class...,1,1.1,1.2,1.3,1.4,1.4G,1.4S,1.5,1.6,2,2.1,2.2,2.3,3,3(6.1),3(6.1)(8),3(8),4,4.1,4.2,4.3,5,5.1,5.1(8),5.1(8)(6.1),5.2,5.2(8),6,6.1,6.1(3)(8),6.1(8),6.2,7,8,8(3),8(5.1),8(6.1),9  |





@GUI @Hazmat
Scenario Outline: Test to verify the Hazardous fields validations _externalusers
	Given I am a DLS user and login into application with valid <Username> and <Password>
    And I have access to Shipment button for external users
    And I clicked on Add Shipment button
    And I have clicked on LTL tile of shipment process
    When I am taken to Add Shipment LTL page  
	And I click on yes button for Hazardous Materials in the Freight Description section
	Then I can able to enter only numeric, min and max length four in  UN Number '<UNNumber>'
	And I can able to enter only numerics in CCN number '<CCNnumber>' 
	And I can able to enter only text in emergency response name '<emergencyresponsename>' 
	And I can able to enter only phonenumberformat <phonenumber>

 Examples: 
| Scenario | Username              | Password | UNNumber | CCNnumber | emergencyresponsename | phonenumber |
| 1        | shpentry              | Te$t1234 | 12345    | 1234A     | vassu1                | 12345678901 |
| 2        | Entyrnorates          | Te$t1234 | 12345    | 1234A     | vassu1                | 12345678901 |


@GUI @Hazmat
Scenario Outline: Test to verify the mandatory functionality_Hazardous fields_externalusers
	Given I am a DLS user and login into application with valid <Username> and <Password>
    And I have access to Shipment button for external users
    And I clicked on Add Shipment button
    And I have clicked on LTL tile of shipment process
    When I am taken to Add Shipment LTL page 
	And I click on Clear All button in Freight Description section
	And I click on yes button for Hazardous Materials in the Freight Description section
	And I click on view rates button
	Then UN Number and CCN number,hazmat packing group,hazmat class,emergencyresponsename, emergencyresponsephone fields should highlight 

Examples:
| Scenario | Username       | Password |
| 1        | shpentry       | Te$t1234 |
| 2        | Entyrnorates   | Te$t1234 |


