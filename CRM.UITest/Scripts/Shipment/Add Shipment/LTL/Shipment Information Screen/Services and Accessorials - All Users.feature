@ServicesAndAccessorials @Sprint 69 @27961

Feature: Services and Accessorials - All Users


#============Services & Accessorials Shipping From section==============================


@GUI
Scenario Outline:Verify existence of Services & Accessorials multi select field in Shipping From Section of Shipment Information page -All users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
   And I will be navigated to Add Shipment LTL page
	Then I must be able to view Services & Accessorials multi select field in the Shipping From section

Examples: 
| Scenario | Username   | Password | Service | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     |External  |                          |
| s2       | stationown | Te$t1234 | LTL     | Internal | ZZZ - Czar Customer Test |
@Functional
Scenario Outline: Verify the functionality of Services & Accessorials multi select field by selecting multiple values from the drop down in Shipping From Section -All users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
   And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	And I click services and accessorials drop down on Shipping From section
	Then I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Shipping From Section
Examples: 
| Scenario | Username   | Password | Service | Accessorials1 | Accessorials2     | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | Appointment   | Construction Site |External  |                          |
| s2       | stationown | Te$t1234 | LTL     | Appointment   | Construction Site | Internal | ZZZ - Czar Customer Test |

@Functional
Scenario Outline: Try to delete services selected from the Services & Accessorials multi select Drop down in Shipping From Section -All users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	And I click services and accessorials drop down on Shipping From section
	And I select a service <Accessorials> from the Shipping From section dropdown
	Then I must have an option to delete the service selected from the Shipping From drop down

Examples: 
| Scenario | Username   | Password | Service | Accessorials | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | Appointment  | External |                          |
| s2       | stationown | Te$t1234 | LTL     | Appointment  | Internal | ZZZ - Czar Customer Test |

@Acceptance
Scenario Outline: Verify the drop down values for Services & Accessorials under Shipping From Section -All users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	And I click services and accessorials drop down on Shipping From section
	Then I should be able to view specified Shipping From services in the drop down

Examples: 
| Scenario | Username   | Password | Service | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | External |                          |
| s2       | stationown | Te$t1234 | LTL     | Internal | ZZZ - Czar Customer Test |


#============Services & Accessorials Shipping to section==============================

@GUI
Scenario Outline:Verify existence of Services & Accessorials multi select field in Shipping To Section of Shipment Information page -All users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	Then I must be able to view Services & Accessorials multi select field in the Shipping To section

Examples: 
| Scenario | Username   | Password | Service | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     |External  |                          |
| s2       | stationown | Te$t1234 | LTL     | Internal | ZZZ - Czar Customer Test |

@Functional
Scenario Outline: Verify the functionality of Services & Accessorials multi select field by selecting multiple values from the drop down in Shipping To Section -All users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	And I click services and accessorials drop down on Shipping To section
	Then I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Shipping To Section
Examples: 
| Scenario | Username   | Password | Service | Accessorials1 | Accessorials2     | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | Appointment   | Construction Site |External  |                          |
| s2       | stationown | Te$t1234 | LTL     | Appointment   | Construction Site | Internal | ZZZ - Czar Customer Test |


@Functional
Scenario Outline: Try to delete services selected from the Services & Accessorials multi select Drop down in Shipping To Section -All users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	And I click services and accessorials drop down on Shipping To section
	And I select a service <Accessorials> from the Shipping To section dropdown
	Then I must have an option to delete the service selected from the Shipping To drop down

Examples: 
| Scenario | Username   | Password | Service | Accessorials | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | Appointment  | External |                          |
| s2       | stationown | Te$t1234 | LTL     | Appointment  | Internal | ZZZ - Czar Customer Test |

@Acceptance
Scenario Outline: Verify the drop down values for Services & Accessorials under Shipping To Section -All users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	And I click services and accessorials drop down on Shipping To section
	Then I should be able to view specified Shipping To services in the drop down

Examples: 
| Scenario | Username   | Password | Service | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | External |                          |
| s2       | stationown | Te$t1234 | LTL     | Internal | ZZZ - Czar Customer Test |

