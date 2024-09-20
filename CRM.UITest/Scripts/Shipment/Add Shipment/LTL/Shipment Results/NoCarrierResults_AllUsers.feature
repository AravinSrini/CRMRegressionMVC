@NoCarrierResultsFound_AllUsers @29469 @Sprint70
Feature: NoCarrierResults_AllUsers
	

@GUI
Scenario Outline: Verify the shipment results page when no carrier rates are found
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter required data in add shipment ltl page <Usertype>, <CustomerName>,<oName>,<oAddr1>,<oZipcode>,<dName>,<dAddr1>,<dZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<weightType>,<itemdesc>,<Country>,<Postal>, <city>, <state>
	When I click on View rates button in add shipment ltl page
	Then I will see the message as There are no rates available for this shipment
	And I have option to Create the shipment without rates
Examples: 
| Scenario | Username   | Password | Usertype | CustomerName           | oName | oAddr1           | oZipcode | dName | dAddr1   | dZipcode | Classification | nmfc | quantity | weight | weightType | itemdesc | Country | Postal  | city  | state |
| S1       | shp.entry  | Te$t1234 |          |                        | Ajji  | CustAddressLine1 | 33126    | John  | JohnAddr | 85282    | 50             | 777  | 5        | 123    | LBS        | package  | Canada  | Lj7 0A1 | Acton | ON    |
| S2       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | Ajji  | CustAddressLine1 | 33126    | John  | JohnAddr | 85282    | 50             | 707  | 3        | 456    | LBS        | package  | Canada  | Lj7 0A1 | Acton | ON    |

@GUI @Functional
Scenario Outline: Verify the Create Shipment without Carrier Rate functionality 
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter required data in add shipment ltl page <Usertype>, <CustomerName>,<oName>,<oAddr1>,<oZipcode>,<dName>,<dAddr1>,<dZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<weightType>,<itemdesc>,<Country>,<Postal>, <city>, <state>
	When I click on View rates button in add shipment ltl page
	And I click on the Create Shipment without Carrier Rate 
	Then I will arrive on the Review and Submit LTL page
	And there will be no Carrier Information section
Examples: 
| Scenario | Username   | Password | Usertype | CustomerName           | oName | oAddr1           | oZipcode | dName | dAddr1   | dZipcode | Classification | nmfc | quantity | weight | weightType | itemdesc | Country | Postal  | city  | state |
| S1       | shp.entry  | Te$t1234 |          |                        | Ajji  | CustAddressLine1 | 33126    | John  | JohnAddr | 85282    | 50             | 777  | 5        | 123    | LBS        | package  | Canada  | Lj7 0A1 | Acton | ON    |
| S2       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | Ajji  | CustAddressLine1 | 33126    | John  | JohnAddr | 85282    | 50             | 707  | 3        | 456    | LBS        | package  | Canada  | Lj7 0A1 | Acton | ON    |



@GUI @Functional
Scenario Outline: Verify the shipment results page when no carrier rates are found for the user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<OriginName>,<OriginAddr>,<OriginZip>,<DestinationName>,<DestinationAddr>,<DestinationZip>,<Classification>,<nmfc>,<Quantity>,<Weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	Then I will see the message as There are no rates available for this shipment <CustomerName>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>,<Username>
	And I have option to Create the shipment without rates <CustomerName>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>,<Username>
Examples: 
| Scenario | Username   | Password | Usertype | CustomerName             | Service | OriginName | OriginAddr | OriginZip | DestinationName | DestinationAddr | DestinationZip | Classification | nmfc | Quantity | Weight | itemdesc | OriginCity | OriginState | OriginCountry | DestinationCity | DestinationState | DestinationCountry | QuantityUNIT | WeightUnit |
| S1       | shp.entry  | Te$t1234 |          | ZZZ - GS Customer Test   | LTL     | Test       | Addr       | 33126     | Testing         | Addresss        | 85282          | 50             | 67   | 6        | 1000   | item1    | Miami      | FL          | USA           | Tempe           | AZ               | USA                | Skids        | LBS        |
| S2       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test   | LTL     | MyTest     | Addr1      | 33126     | Mysting         | Addresss        | 85282          | 50             | 612  | 3        | 187    | item2    | Miami      | FL          | USA           | Tempe           | AZ               | USA                | Skids        | LBS        |


@GUI @Functional
Scenario Outline: Verify the Create Shipment without Carrier Rate functionality when no carrier rates are found for the user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<OriginName>,<OriginAddr>,<OriginZip>,<DestinationName>,<DestinationAddr>,<DestinationZip>,<Classification>,<nmfc>,<Quantity>,<Weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	Then I click on the Create Shipment without Carrier Rate  when no rates for the shipment <CustomerName>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>,<Username>
	
Examples: 
| Scenario | Username   | Password | Usertype  | CustomerName             | Service | OriginName | OriginAddr | OriginZip | DestinationName | DestinationAddr | DestinationZip | Classification | nmfc | Quantity | Weight | itemdesc | OriginCity | OriginState | OriginCountry | DestinationCity | DestinationState | DestinationCountry | QuantityUNIT | WeightUnit |
| S1       | shp.entry  | Te$t1234 |           | ZZZ - GS Customer Test   | LTL     | Test       | Addr       | 33126     | Testing         | Addresss        | 85282          | 50             | 67   | 6        | 1000   | item1    | Miami      | FL          | USA           | Tempe           | AZ               | USA                | Skids        | LBS        |
| S2       | stationown | Te$t1234 | Internal  | ZZZ - Czar Customer Test | LTL     | Test       | Addr       | 33126     | Testing         | Addresss        | 85282          | 50             | 67   | 6        | 1000   | item1    | Miami      | FL          | USA           | Tempe           | AZ               | USA                | Skids        | LBS        |
