@LiabilityCoverage_AllUsers @28164 @Sprint70 
Feature: LiabilityCoverage_AllUsers
	

@GUI 
Scenario Outline: Verify the Cost per Pound New and Used fields in the Shipment Results for the standard rates
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	Then I should be displayed with Cost per Pound New and Cost per Pound Used fields above Max Liability field in non guaranteed grid
	And Cost per Pound New and Cost per Pound Used fields should be prefixed with dollar symbol in non guaranteed grid 

Examples: 
| Scenario | Username         | Password    | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry        | Te$t1234    |          |                          | test       | address     | 33126         | testing         | djj              | 85282              | 50             | 1234 | 1        | 1234   | item1    |
| S2       | Station.allstate | Connect@123 | Internal | All States Ag Parts - WI | test       | address     | 33126         | testing         | djj              | 85282              | 55             | 9900 | 5        | 1999   | item2    |

@Functional @DBVerification
Scenario Outline: Verify the Cost per Pound New and Used fields in the Shipment Results matches with the DB for the standard rates
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	Then Cost per Pound New and Cost per Pound Used fields values should match with DB values in non guaranteed grid
Examples: 
| Scenario | Username         | Password    | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry        | Te$t1234    |          |                          | test       | address     | 33126         | testing         | djj              | 85282              | 50             | 1234 | 1        | 1234   | item1    |
| S2       | Station.allstate | Connect@123 | Internal | All States Ag Parts - WI | test       | address     | 33126         | testing         | djj              | 85282              | 55             | 9900 | 5        | 1999   | item2    |

@GUI @Functional
Scenario Outline: Verify the Maximum Liability calculation for both New and Used values when Insured Value is not entered
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then Verify the Maximum Liability Calculation for both New and Used values <weight>
Examples: 
| Scenario | Username         | Password    | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| S1       | shp.entry        | Te$t1234    |          |                          | tesjj      | address     | 33126         | testing         | djj              | 85282              | 50             | 1234 | 1        | 1000   | item1    |
| S2       | Station.allstate | Connect@123 | Internal | All States Ag Parts - WI | test       | address     | 33126         | testing         | djj              | 85282              | 55             | 9900 | 5        | 1999   | item2    |

@GUI @Functional
Scenario Outline: Verify the Maximum Liability calculation for New when Insured Value is entered 
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down
	When I click on View rates button in add shipment ltl page		
	Then I will see only the New Maximum Liability Calculation amount is displayed <weight>


Examples: 
| Scenario | Username         | Password    | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | InsuredValue | InsuredType |
| S1       | Entry.allstate   | Connect@123 |          |                          | tes        | address     | 33126         | testing         | djj              | 85282              | 50             | 1234 | 1        | 1000   | Item1    | 456          | New         |
| S2       | Station.allstate | Connect@123 | Internal | All States Ag Parts - WI | test       | address     | 33126         | testing         | djj              | 85282              | 55             | 9900 | 5        | 1999   | item2    | 111          | New         |

@GUI @Functional
Scenario Outline: Verify the Maximum Liability calculation for Used when Insured Value is entered 
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down
	When I click on View rates button in add shipment ltl page		
	When LTL carrier has Cost per Pound New Insured rate assiciated in Carrier Rate Settings 
	Then I will see only the Used Maximum Liability Calculation amount is displayed <weight>
	
Examples: 
| Scenario | Username         | Password    | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | InsuredValue | InsuredType |
| S1       | Entry.allstate   | Connect@123 |          |                          | tes        | address     | 33126         | testing         | djj              | 85282              | 50             | 1234 | 1        | 1000   | item1    | 456          | Used        |
| S2       | Station.allstate | Connect@123 | Internal | All States Ag Parts - WI | test       | address     | 33126         | testing         | djj              | 85282              | 55             | 9900 | 5        | 1999   | item2    | 111          | Used        |

@GUI @Functional
Scenario Outline: Verify the Maximum Liability calculation for New when Insured Value is entered and Weight entered is in Kilos
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter required data in add shipment ltl page <Usertype>, <CustomerName>,<oName>,<oAddr1>,<oZipcode>,<dName>,<dAddr1>,<dZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<weightType>,<itemdesc>,<Country>,<Postal>, <city>, <state>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down	
	When I click on View rates button in add shipment ltl page	
	Then Entered weight in kilos is converted to Pound to calculate the Maximum Liability and I will see only the New Maximum Liability Calculation amount is displayed <weight>
Examples: 
| Scenario | Username       | Password    | Usertype | CustomerName | oName | oAddr1           | oZipcode | dName | dAddr1   | dZipcode | Classification | nmfc | quantity | weight | weightType | itemdesc | Country       | Postal  | city  | state | InsuredValue | InsuredType |
| S1       | Entry.allstate | Connect@123 |          |              | Ajji  | CustAddressLine1 | 33126    | John  | JohnAddr | 85282    | 50             | 777  | 5        | 1000    | KILOS      | package  | United States | Lj7 0A1 | Acton | ON    | 567          | New         |
| S2       | Station.allstate | Connect@123 | Internal |All States Ag Parts - WI| Ajji  | CustAddressLine1 | 33126    | John  | JohnAddr | 85282    | 50             | 777  | 5        | 1000    | KILOS      | package  | United States | Lj7 0A1 | Acton | ON    | 567          | New         |


@GUI @Functional
Scenario Outline: Verify the Maximum Liability calculation for Used when Insured Value is entered and Weight entered is in Kilos
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter required data in add shipment ltl page <Usertype>, <CustomerName>,<oName>,<oAddr1>,<oZipcode>,<dName>,<dAddr1>,<dZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<weightType>,<itemdesc>,<Country>,<Postal>, <city>, <state>
	And I enter value in Insured Value <InsuredValue>
	And I select the Insured Type from  <InsuredType> drop down	
	When I click on View rates button in add shipment ltl page 
	Then Entered weight in kilos is converted to Pound to calculate the Maximum Liability and I will see only the Used Maximum Liability Calculation amount is displayed <weight>
Examples: 
| Scenario | Username       | Password    | Usertype | CustomerName | oName | oAddr1           | oZipcode | dName | dAddr1   | dZipcode | Classification | nmfc | quantity | weight | weightType | itemdesc | Country       | Postal  | city  | state | InsuredValue | InsuredType |
| S1       | Entry.allstate | Connect@123 |          |              | Ajji  | CustAddressLine1 | 33126    | John  | JohnAddr | 85282    | 50             | 777  | 5        | 1234   | KILOS      | package  | United States | Lj7 0A1 | Acton | ON    | 567          | Used        |
| S2       | Station.allstate | Connect@123 |Internal | All States Ag Parts - WI| Ajji  | CustAddressLine1 | 33126    | John  | JohnAddr | 85282    | 50             | 777  | 5        | 1234   | KILOS      | package  | United States | Lj7 0A1 | Acton | ON    | 567          | Used        |


