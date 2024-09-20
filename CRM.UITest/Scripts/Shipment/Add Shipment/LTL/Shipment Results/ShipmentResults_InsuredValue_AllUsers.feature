@ShipmentResults_InsuredValue_AllUsers @28078 @Sprint70 
Feature: ShipmentResults_InsuredValue_AllUsers


@GUI
Scenario Outline: Verify the auto populated value in insured value field for All user
	  Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  And I enter the <insuredValue>,<insuredtype> on add shipment LTL page
	  When I click on View rates button in add shipment ltl page	
	  Then Verify the value is auto populated value for <insuredValue> and <insuredtype> 
	  And Verify both field are editable
	  And Verify the View Terms and Conditions button is active 

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insuredValue | insuredtype |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000.00      | New         |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000.00      | New         |


@GUI
Scenario Outline: Verify the insured value field for All user
		Given I am a shpentry, operations, sales, sales management or station user <Username>,<Password>
		And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
		When I click on View rates button in add shipment ltl page	
	    Then Verify i have option to enter the insured value for <insured_value>  
	    And Insured value field allows <numerical_digit> and <decimal_digit>

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insured_value | numerical_digit | decimal_digit |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 10,000        | 12,345          | 10,000.00     |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 10,000        | 12,345          | 10,000.00     |



@GUI
Scenario Outline: Verify the insured value type field for All user
	    Given I am a shpentry, operations, sales, sales management or station user <Username>,<Password>
		And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
		When I click on View rates button in add shipment ltl page	
	    Then Verify i have option to enter the insured value for <insured_value> 
	    And Verify the dropdown have the <isuredvaluetype> 

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insured_value | isuredvaluetype |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | New             |
| S2       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | Used            |
| S3       | zzzext                | Te$t1234 |          | Test                   | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | New             |
| S4       | zzzext                | Te$t1234 |          | Test                   | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | Used            |




@GUI
Scenario Outline: Verify the Insured value type for auto login user for Ship Entry user
	  Given I am a shp.entry user <Username> <Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  When I click on View rates button in add shipment ltl page
	  And I arrive on shipment Results LTL page and entered <insured_value>
	  Then Verify the Insured value type defaulted to used
	  And I have the option to change the insured value type to New 

Examples: 
| Scenario | Username  | Password | Usertype | CustomerName | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | insured_value |
| S1       | shp.entry | Te$t1234 | StationOwner | ZZZ - GS Customer Test | Oname      | Oname1      | 30013         | Dname           | Dname2           | 30013              | 55 CLEANING WIPES | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          |

  


@GUI
Scenario Outline: Verify the View terms and condition button for All user
	  Given I am a shpentry, operations, sales, sales management or station user <Username>,<Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  When I click on View rates button in add shipment ltl page
	  And I arrive on shipment Results LTL page and entered <insured_value>
	  Then I should see the View <terms_and_condition> button

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insured_value | terms_and_condition  |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | Terms and Conditions |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | Terms and Conditions |



@GUI
Scenario Outline: Verify the click functionality of terms and condition button for All user
	  Given I am a shpentry, operations, sales, sales management or station user <Username>,<Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  When I click on View rates button in add shipment ltl page
	  And I arrive on shipment Results LTL page and entered <insured_value>
	  And Click on Terms and conditon on Shipment result page 
	  Then Verify the presented model with the <shipmentModelheading>

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insured_value | shipmentModelheading             |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | Terms And Conditions Of Coverage |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | Terms And Conditions Of Coverage |

 
	
@GUI @Functional
Scenario Outline: Verify the click functionality of Download DLSW Claim for All user
	  Given I am a shpentry, operations, sales, sales management or station user <Username>,<Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  When I click on View rates button in add shipment ltl page
	  And I arrive on shipment Results LTL page and entered <insured_value>
	  And Click on Terms and conditon on Shipment result page
	  And I click on Download DLSW Claim form in model from Shipment result page
	  Then Verify that DLSW claim form will be downloaded

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insured_value |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          |


	
@GUI
Scenario Outline: Verify the click functionality of Close button for All users 
	  Given I am a shpentry, operations, sales, sales management or station user <Username>,<Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  When I click on View rates button in add shipment ltl page
	  And I arrive on shipment Results LTL page and entered <insured_value>
	  And Click on Terms and conditon on Shipment result page
	  And Click on close button from model in shipment result page
	  Then Verify i should be navigated to the Shipment Results LTL page

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insured_value |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          |


@GUI
Scenario Outline: Verify the click functionality of Show Insured Rate button for All users 
	  Given I am a shpentry, operations, sales, sales management or station user <Username>,<Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  When I click on View rates button in add shipment ltl page
	  And I arrive on shipment Results LTL page and entered <insured_value>
	  And I Select the <insuredValue_type> from dropdown in shipment result page
	  And I click on Show Insured Rate button in shipment result page
	  Then Verify that results grid will update to display the Insured Rate column <Usertype>
	  And Verify each carrier displayed on the results page will have an option to Create an Insured Shipment <Usertype>

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insured_value | insuredValue_type |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | Used              |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000          | Used              |



@GUI
Scenario Outline: Verify the result grid on shipment result page for for All users 
	  Given I am a shpentry, operations, sales, sales management or station user <Username>,<Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  And I enter the <insuredValue>,<insuredtype> on add shipment LTL page
	  When I click on View rates button in add shipment ltl page
	  And I click on Show Insured Rate button in shipment result page
	  Then Verify that results grid will update to display the Insured Rate column <Usertype>
	  And Verify each carrier displayed on the results page will have an option to Create an Insured Shipment <Usertype>

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insuredValue | insuredtype |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000         | Used        |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000         | Used        |



	


