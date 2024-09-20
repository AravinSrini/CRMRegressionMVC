@30565 @Sprint72 @CalculateBreakoutTotal(BOTTL)_Shipment
Feature: CalculateBreakoutTotal(BOTTL)_Shipment
	
@Functional
Scenario Outline: Verify BOTTL calculation for LTL Shipment Request
Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
When  am on the Shipment results page<CustomerName>,<OriginZip>,<DestinationZip>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<oName>,<oAdd1>,<dName>,<dAdd1>,<nmfc>,<desc>
Then BOTTL can be calculated and Verified in the Shipment Results page<CustomerName>,<Username>,<OriginCity>,<OriginZip>,<OriginState>,<OriginCountry>,<DestinationCity>,<DestinationZip>,<DestinationState>,<DestinationCountry>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<QuantityUNIT>,<Weight>,<Mode>,<UserType>,<CalculationType>

Examples:
| Scenario | Username               | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | Mode     | UserType | CalculationType | oName		 | oAdd1	  | dName	   | dAdd1		 | nmfc     | desc |
| s1       | zzzext					| Te$t1234 | ZZZ - CZar Customer Test | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 3      | Shipment | External | BOTTL           |  otest     |oadd1       |dtest       |daadd1       | 1234     | dtss     |

