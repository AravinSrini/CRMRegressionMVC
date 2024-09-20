@Quote Results (LTL) - Page Elements - Station Users @Sprint67 @25620 Sprint69 @29161
Feature: Quote Results_LTL_ Page Elements_StationUsers
	
@Regression 
Scenario Outline: Verify Absence of Create Shipment button and Create Insured Shipment button
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And  I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And  I enter valid data in Item information section <Classification>, <Weight>
And I enter data in <Insuredvalue> field 
And I click on view quote results button
Then I will be navigated to Rate Results page and I will not see Create shipment and Create Insured Shipment button

Examples: 
| Scenario | Username               | Password | QuoteList_Header | Customer_Name          | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | Insuredvalue |
| S1       | SalesManager@stage.com | Te$t1234 | Quote List       | ZZZ - GS Customer Test | LTL     | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | 31           |

@Regression 
Scenario Outline: Verify the Presence of Est Cost and Est Margin label
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And  I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And  I enter valid data in Item information section <Classification>, <Weight>
And I enter data in <Insuredvalue> field 
And I click on view quote results button
Then I will see Est Cost and Est Margin label

Examples: 
| Scenario | Username               | Password | QuoteList_Header | Customer_Name          | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | Insuredvalue |
| S1       | SalesManager@stage.com | Te$t1234 | Quote List       | ZZZ - GS Customer Test | LTL     | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | 31           |

@Regression 
Scenario Outline: Verify the Presence of Fuel,Line haul,Accessorials label
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I should be navigated to the Quote List <QuoteList_Header>page
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When I am taken to the new responsive LTL Shipment Information screen
When I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And  I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And  I enter valid data in Item information section <Classification>, <Weight>
And I enter data in <Insuredvalue> field 
And I click on view quote results button
Then I will see Fuel Linehaul and Accessorials labels

Examples: 
| Scenario | Username               | Password | QuoteList_Header | Customer_Name          | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | Insuredvalue |
| S1       | SalesManager@stage.com | Te$t1234 | Quote List       | ZZZ - GS Customer Test | LTL     | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | 31           |

@Regression 
Scenario Outline: Verify the API Response of Est cost and Est Margin with UI

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
And  I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
And  I enter valid data in Item information section <Classification>, <Weight>
And  I click on view quote results button
Then API Response of the Est Margin should match with UI<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>,<Username>

Examples: 
| Scenario | Username              | Password | Customer_Name             | Service | OriginZip | OriginCity | OriginState | OriginCountry | DestinationZip | DestinationCity | DestinationState | DestinationCountry | Classification | Weight | WeightUnit | Quantity | QuantityUNIT | 
| S1       | crmOperation          | Te$t1234 | ZZZ - GS Customer Test    | LTL     | 60606     | Chicago    | IL          | USA           | 60606          | Chicago         | IL               | USA                |50              | 1      |   lbs      |    1     | SKD          |  

@Regression 
Scenario Outline:  Verify the API response Get Quote LTL when City and State are not entered for Station users, ShipEntry and ShipEntryNoRates users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
When I enter valid data in zipcode <OriginZip> in Origin Section
And  I enter valid data in zipcode <DestinationZip> in Destination section
And  I click on view quote results button
Then API Response of the Est Margin should match with UI<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>,<Username>

Examples: 
| Scenario | Username              | Password | Customer_Name             | Service | OriginZip | OriginCity | OriginState | OriginCountry | DestinationZip | DestinationCity | DestinationState | DestinationCountry | Classification | Weight | WeightUnit | Quantity | QuantityUNIT | 
| S1       | crmOperation          | Te$t1234 | ZZZ - GS Customer Test    | LTL     | 60606     | Chicago    | IL          | USA           | 60606          | Chicago         | IL               | USA                |50              | 1      |   lbs      |    1     | SKD          |  

