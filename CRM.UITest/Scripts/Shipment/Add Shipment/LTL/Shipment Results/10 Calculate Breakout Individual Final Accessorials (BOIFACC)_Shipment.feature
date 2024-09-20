@Sprint72 @30563
Feature: 10 Calculate Breakout Individual Final Accessorials (BOIFACC)_Shipment

@Functional
Scenario Outline: Verify the BOIFACC calculations for Shipment
Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
When  am on the Shipment results page<CustomerName>,<OriginZip>,<DestinationZip>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<oName>,<oAdd1>,<dName>,<dAdd1>,<nmfc>,<desc>
Then BOIFACC can be calculated<CustomerName>,<Username>,<OriginCity>,<OriginZip>,<OriginState>,<OriginCountry>,<DestinationCity>,<DestinationZip>,<DestinationState>,<DestinationCountry>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<QuantityUNIT>,<Weight>,<Mode>,<UserType>,<CalculationType>

Examples:
| Scenario | Username               | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | Mode     | UserType | CalculationType | oName		 | oAdd1	  | dName	   | dAdd1		 | nmfc     | desc |
| s1       | salesmanager@stage.com | Te$t1234 | ZZZ - GS Customer Test   | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 3      | Shipment | Internal | BOIFACC         |  otest     |oadd1       |dtest       |daadd1       | 1234     | dtss     |
