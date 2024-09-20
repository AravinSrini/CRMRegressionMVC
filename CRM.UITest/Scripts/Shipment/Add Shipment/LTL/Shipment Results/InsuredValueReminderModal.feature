@InsuredValueReminderModal @29008 @Sprint70 
Feature: InsuredValueReminderModal
	

@GUI
Scenario Outline: Verify the insured value pop up reminder modal
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	When I click on create shipment button for any of the listed carrier <Usertype>
	Then Verify the insured value reminder modal pop up is displayed
	And the modal will display the message as <InsuredRatesMessage>
	And there will be an Insured value field with Currency formatted
	And there will be insured type selection field defaulted to New
	And there will be Show Insured Rate button
	And there will be Continue without insured rate button
	And there will be a check box Don't Show Me This Again 

Examples:
| Scenario | Username       | Password | Usertype | CustomerName | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | InsuredRatesMessage |
| S1       | Entry.allstate | Connect@123 |          |                        | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     | For your protection, we strongly recommend insuring your shipment. |
| S2       | Station.allstate | Connect@123 | Internal | All States Ag Parts - WI |  Test      |  Add        | 33126         |  tesing         | Addrl            |   85282            |    50          | 45   |   5      |  4     |  item    | For your protection, we strongly recommend insuring your shipment. |

@GUI
Scenario Outline: Verify the insured value pop up reminder modal for auto login user
	Given I am a shp.entry user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	When I click on create shipment button for any of the listed carrier <Usertype>
	Then Verify the insured value reminder modal pop up is displayed
	And insured Type selection field should be defaulted to Used
	And I have option to select New
Examples:
| Scenario | Username               | Password | Usertype | CustomerName | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | EntryCust              | Te$t9999 |          |              |  Test      |  Add        | 33126         |  tesing         | Addrl            |   85282            |    50          | 45   |   5      |  4     |  item    |
	
@GUI @Functional
Scenario Outline: Verify the functionality when user enter Insured Value inside modal pop up and click on the Show Insured rate button
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	When I click on create shipment button for any of the listed carrier <Usertype>
	And I enter the Insured Value	
	And I click on the Show Insured Rate button	
	Then I am returned back to the Shipment Results LTL page
	And I should be displayed the Insured Rate column with Create an Insured Shipment Button
Examples:
| Scenario | Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | Entry.allstate| Connect@123 |          |                        | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     |
| S2       | Station.allstate | Connect@123 | Internal | All States Ag Parts - WI |  Test      |  Add        | 33126         |  tesing         | Addrl            |   85282            |    50          | 45   |   5      |  4     |  item    |

@GUI @Functional
Scenario Outline: Verify the functionality when user not entered Insured Value inside modal pop up click on the Continue Without Insured Rates Button
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	When I click on create shipment button for any of the listed carrier <Usertype>
	And I click on the Continue Without Insured Rates Button
	Then I am taken to the Review and Submit page
	
	
Examples:
| Scenario | Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | Entry.allstate| Connect@123 |          |                        | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     |
| S2       | Station.allstate | Connect@123 | Internal | All States Ag Parts - WI | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     |

@GUI @Functional
Scenario Outline: Verify the functionality when I click on the Dont Show Me This Again check box inside Insured Value Reminder modal pop up
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	When I click on create shipment button for any of the listed carrier <Usertype>
	And I click on the Don't Show Me This Again check box
	Then I am returned back to the Shipment Results LTL page
	
Examples:
| Scenario | Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry  | Te$t1234 |          |                        | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     |
| S2       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     |

@GUI @Functional
Scenario Outline: Verify the functionality when I have already clicked on the Don't Show Me This Again check box inside Insured Value Reminder modal pop up
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	When I Click on Create Shipment button <Usertype>		
	Then Insured value reminder modal pop up should not be displayed
		
Examples:
| Scenario | Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry  | Te$t1234 |          |                        | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     |
| S2       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     |
