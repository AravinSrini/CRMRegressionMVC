@AddShipment_InsuredValue_AllUsers @28051 @Sprint69 
Feature: AddShipment_InsuredValue_AllUsers

@GUI
Scenario Outline: Verify the mouse hover functionality on Insured value tool tip for All Internal users 
    Given I am an operations, sales, sales management, or station owner user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I mouser hover on Insure Value tool tip 
	Then Verify the mouse hover over will display the message <InsuredValueToolTip_Text>
	
Examples: 
| user     | customername | service | InsuredValueToolTip_Text                                                                                                    |
| station  | Prakash MG   | LTL     | NORMAL METHOD TO DETERMINE INSURED VALUE: INVOICE COST, PLUS INSURANCE COST, PLUS ANY PREPAID FREIGHT CHARGES, ALL PLUS 10% |
  
@GUI
Scenario Outline: Verify the mouse hover functionality on Insured value tool tip for External All users 
    Given I am a shp.entry,shp.entrynorates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I mouser hover on Insure Value tool tip 
	Then Verify the mouse hover over will display the message <InsuredValueToolTip_Text> 
	
Examples:
| user     | customername | service | InsuredValueToolTip_Text                                                                                                    |
| customer |              | LTL     | NORMAL METHOD TO DETERMINE INSURED VALUE: INVOICE COST, PLUS INSURANCE COST, PLUS ANY PREPAID FREIGHT CHARGES, ALL PLUS 10% |
           
@Functional
Scenario Outline: Verify the Insured Value field  for All Internal users 
    Given I am an operations, sales, sales management, or station owner user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	When I select the tiles <service> 
	Then I have <EnterValueoption> in Insured value field 
	And  Verify the Insured Value field is present and field allows only <numericaldigit> and <decimaldigit> 

Examples: 
| user     | customername | service | EnterValueoption       | numericaldigit | decimaldigit |
| station  | Prakash MG   | LTL     | Enter insured value... | 10,000         | 100.00       |

@Functional
Scenario Outline: Verify the Insured Value field  for All External users 
	Given I am a shp.entry,shp.entrynorates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	When I select the tiles <service> 
	Then I have <EnterValueoption> in Insured value field 
	And  Verify the Insured Value field is present and field allows only <numericaldigit> and <decimaldigit> 

Examples: 
| user     | customername | service | EnterValueoption       | numericaldigit | decimaldigit |
| customer |              | LTL     | Enter insured value... | 10,000         | 100.00       |
           
@GUI
Scenario Outline: Verify the Insured Value Type for All Internal users 
    Given I am an operations, sales, sales management, or station owner user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I entered the <value> in Insured value field 
	Then Verify the Dropdown have the <InsuredValueType>

Examples: 
| user    | customername | service | value  | InsuredValueType |
| station | Prakash MG   | LTL     | 1000   | New              |
| station | Prakash MG   | LTL     | 100.01 | Used             |

@GUI
Scenario Outline: Verify the Insured Value Type for All External users 
	Given I am a shp.entry,shp.entrynorates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I entered the <value> in Insured value field 
	Then Verify the Dropdown have the <InsuredValueType>

Examples: 
| user     | customername | service | value | InsuredValueType |
| customer |              | LTL     | 1000  | New              |
| customer |              | LTL     | 100   | Used             |
         
@Functional
Scenario Outline: Verify the Insured Value type option for autologin users is default value used to New for ship entry and ship entry no rates users 
    Given I am a Ship Entry No Rates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>           
	And I select the tiles <service> 
	When I entered the <value> in Insured value field 
	Then Verify the dropdown is by default selected as Used
	And I have the option to change Insured Value type as New 

Examples: 
| user     | service | value |
| customer | LTL     | 1000  | 

@GUI
Scenario Outline: Verify the View Term and Conditions button for All Internal users 
    Given I am an operations, sales, sales management, or station owner user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I entered the <value> in Insured value field 
	Then I will seethe View Term and condition button

Examples: 
| user     | customername | service | value |
| station  | Prakash MG   | LTL     | 1000  |

@GUI 
Scenario Outline: Verify the View Term and Conditions button for All External users 
	Given I am a shp.entry,shp.entrynorates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I entered the <value> in Insured value field 
	Then I will seethe View Term and condition button

Examples: 
| user     | customername | service | value |
| customer |              | LTL     | 1000  |

@GUI 
Scenario Outline: Verify the error message of exceeds value for All Internal users 
	Given I am an operations, sales, sales management, or station owner user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I entered the <value> in Insured value field 
	Then Verified the <error_message> for exceeds insured value

Examples: 
| user    | customername | service | value  | error_message                                                                        |
| station | Prakash MG   | LTL     | 100009 | The entered shipment value exceeds $100,000. Please contact your DLS representative. |

@GUI 
Scenario Outline: Verify the error message of exceeds value for All External users 
    Given I am a shp.entry,shp.entrynorates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I entered the <value> in Insured value field 
	Then Verified the <error_message> for exceeds insured value

Examples: 
| user     | customername | service | value   | error_message                                                                        |
| customer |              | LTL     | 1000000 | The entered shipment value exceeds $100,000. Please contact your DLS representative. |

@Functional 
Scenario Outline: Verify the click functionality of Terms and Condition for All Internal users 
	Given I am an operations, sales, sales management, or station owner user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	And I entered the <value> in Insured value field 
	When I click on Terms and Conditions button
	Then Verify the model with the <heading>

Examples: 
| user    | customername | service | value | heading                          |
| station | Prakash MG   | LTL     | 1000  | Terms And Conditions Of Coverage |

@Functional 
Scenario Outline: Verify the click functionality of Terms and Condition for All External users 
    Given I am a shp.entry,shp.entrynorates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	And I entered the <value> in Insured value field 
	When I click on Terms and Conditions button
	Then Verify the model with the <heading>

Examples: 
| user     | customername | service | value | heading                          |
| customer |              | LTL     | 1000  | Terms And Conditions Of Coverage |

@Functional 
Scenario Outline: Verify the click functionality of Download DLSW Claim Form for All Internal users 
	Given I am an operations, sales, sales management, or station owner user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	And I entered the <value> in Insured value field 
	And I click on Terms and Conditions button
	When I click on Download DLSW Claim Form
	Then Verified the DLSW Claim Form will be downloaded 

Examples: 
| user     | customername | service | value |
| station  | Prakash MG   | LTL     | 1000  |   

@Functional 
Scenario Outline: Verify the click functionality of Download DLSW Claim Form for All External users 
	Given I am a shp.entry,shp.entrynorates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	And I entered the <value> in Insured value field 
	And I click on Terms and Conditions button
	When I click on Download DLSW Claim Form
	Then Verified the DLSW Claim Form will be downloaded 

Examples: 
| user     | customername | service | value |
| customer |              | LTL     | 1000  |
          
@Functional
Scenario Outline: Verify the click functionality of Close button for All Internal users 
	Given I am an operations, sales, sales management, or station owner user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	And I entered the <value> in Insured value field 
	And I click on Terms and Conditions button
	When I click on close button from model
	Then I should navigated to the Add Shipment LTL page

Examples: 
| user     | customername | service | value |
| station  | Prakash MG   | LTL     | 10000 |

@Functional
Scenario Outline: Verify the click functionality of Close button for All External users 
	Given I am a shp.entry,shp.entrynorates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	And I entered the <value> in Insured value field 
	And I click on Terms and Conditions button
	When I click on close button from model
	Then I should navigated to the Add Shipment LTL page

Examples: 
| user     | customername | service | value |
| customer |              | LTL     | 10000 |