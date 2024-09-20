@Sprint69 @28075
Feature: ShipmentResults_PageElements_StationUsers

@GUI
Scenario Outline: Verify the display of station and customer name in results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
	And I enter <DZip> <DName> <DAddress1> in shipping to location info section present in add shipment page
	And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
	And I click on View rates button in add shipment ltl page
	Then the station name- customer name will be displayed in the Customer field <CustomerAccName>
	And station name - customer is not editable in results page <CustomerAccName>

Examples: 
| Scenario | Username   | Password | UserType     | CustomerAccName          | OZip  | OName | OAddress1 | DZip  | DName | DAddress1 | Classification | NMFC | Quantity | Description | Weight |
| S1       | stationown | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | 33126 | test  | address   | 85282 | Dname | add       | 50             | 1234 | 1        | item 1      | 100    |

@GUI
Scenario Outline: Verify insured section, grid and columns name in results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName> 
	And I Select the LTL tile
	And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
	And I enter <DZip> <DName> <DAddress1> in shipping to location info section present in add shipment page
	And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
	And I click on View rates button in add shipment ltl page
	Then I should see <InsuredNote> insured note, rate and value Type field
	And I should see filter carriers by options - Quickest Service and Least cost
	And Carrier, Service Days, Distance,Est Cost and Rate columns

Examples: 
| Scenario | Username   | Password | UserType     | CustomerAccName          | OZip  | OName | OAddress1 | DZip  | DName | DAddress1 | Classification | NMFC | Quantity | Description | Weight | InsuredNote                                                                    |
| S1       | stationown | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | 33126 | test  | address   | 85282 | Dname | add       | 50             | 1234 | 1        | item 1      | 100    | Note: To receive Insured Rate options, you must provide a insured value below: |


@GUI @Functional @Ignore
Scenario Outline: Verify insured column when insured value entered and its column in results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
	And I enter <DZip> <DName> <DAddress1> in shipping to location info section present in add shipment page
	And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
	And I enter data in <InsuredRate> text box in add shipment page
	And I click on View rates button in add shipment ltl page
	And I click on show insured rate button
	Then I should see insured rate column in shipment results page
	And I should see Total, Fuel, Line Haul and Accessorials fields under rate columns
	And estimate margin field under rate columns

Examples: 
| Scenario | Username   | Password | UserType     | CustomerAccName          | OZip  | OName | OAddress1 | DZip  | DName | DAddress1 | Classification | NMFC | Quantity | Description | Weight | InsuredRate |
| S1       | stationown | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | 33126 | test  | address   | 85282 | Dname | add       | 50             | 1234 | 1        | item 1      | 100    | 100         |

@GUI
Scenario Outline: Verify buttons displaying in results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
	And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
	And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
	And I pass <InsuredRate> in shipment results page
	And I click on View rates button in add shipment ltl page
	Then I should see Show Insured Rate, Terms and Conditions, Create Shipment,Create Insured Shipment, Export, Guaranteed Rate Available and Back to Shipment List buttons in shipment results page

Examples: 
| Scenario | Username   | Password | UserType     | CustomerAccName          | OZip  | OName | OAddress1 | DZip  | DName | DAddress1 | Classification | NMFC | Quantity | Description | Weight | InsuredRate |
| S1       | stationown | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | 33126 | test  | address   | 85282 | Dname | add       | 50             | 1234 | 1        | item 1      | 100    | 100         |

@GUI @Functional
Scenario Outline: Verify insured column when insured value is passed from add shipment page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
	And I enter <DZip> <DName> <DAddress1> in shipping from location info section present in add shipment page
	And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
	And I pass <InsuredRate> in shipment results page
	And I click on View rates button in add shipment ltl page
	Then I should see insured rate column in shipment results page

Examples: 
| Scenario | Username   | Password | UserType     | CustomerAccName          | OZip  | OName | OAddress1 | DZip  | DName | DAddress1 | Classification | NMFC | Quantity | Description | Weight | InsuredRate |
| S1       | stationown | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | 33126 | test  | address   | 85282 | Dname | add       | 50             | 1234 | 1        | item 1      | 100    | 100         |

@GUI @Functional
Scenario Outline: Verify sort functionality for all the columns present in shipment results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
	And I enter <DZip> <DName> <DAddress1> in shipping to location info section present in add shipment page
	And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
	And I click on View rates button in add shipment ltl page
	Then I should be able to sort Carrier column in ascending and descending order
	And I should be able to sort service days column in ascending and descending order
	And I should be able to sort distance column in ascending and descending order
	And I should be able to sort Est Cost column in ascending and descending order
	And I should be able to sort rate columns in ascending and descending order

Examples: 
| Scenario | Username   | Password | UserType     | CustomerAccName        | OZip  | OName | OAddress1 | DZip  | DName | DAddress1 | Classification | NMFC | Quantity | Description | Weight | InsuredRate |
| S1       | stationown | Te$t1234 | StationOwner | ZZZ - GS Customer Test | 33126 | test  | address   | 85282 | Dname | add       | 50             | 1234 | 1        | item 1      | 100    | 100         |

