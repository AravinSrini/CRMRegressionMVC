@30565 @Sprint72 @CalculateBreakoutTotal(BOTTL)_Quote
Feature: CalculateBreakoutTotal(BOTTL)_Quote
	
@Regression
Scenario Outline: Verify BOTTL calculation for LTL Rate Request
Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
When  am on the quotes results page<CustomerName>,<Service>,<OriginZip>,<DestinationZip>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>
Then BOTTL can be calculated and Verified in the Rate Results page<CustomerName>,<Username>,<OriginCity>,<OriginZip>,<OriginState>,<OriginCountry>,<DestinationCity>,<DestinationZip>,<DestinationState>,<DestinationCountry>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<QuantityUNIT>,<Weight>,<Mode>,<UserType>,<CalculationType>
Examples:
| Scenario | Username               | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | Mode		   | UserType | CalculationType |
| s1       | Both@test.com  	    | Te$t1234 | ZZZ - GS Customer Test   | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD         | 50             | 1        | SKD          | 3       | Quote        | External | BOTTL		    |


