@CalculateBreakoutLinehaul(BOLH)_Quote @30324 @Sprint72 
Feature: CalculateBreakoutLinehaul(BOLH)_Quote
	

@Regression
Scenario Outline: Verify the BOLH calculations for Quote
Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
When  am on the quotes results page<CustomerName>,<Service>,<OriginZip>,<DestinationZip>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>
Then BOLH can be calculated and Verified in the Rate Results page<CustomerName>,<Username>,<OriginCity>,<OriginZip>,<OriginState>,<OriginCountry>,<DestinationCity>,<DestinationZip>,<DestinationState>,<DestinationCountry>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<QuantityUNIT>,<Weight>,<Mode>,<UserType>,<CalculationType>
Examples:
| Scenario | Username               | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | Mode		   | UserType | CalculationType |
| s1       | zzzext                 | Te$t1234 | ZZZ - Czar Customer Test | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD         | 50             | 1        | SKD          | 3       | Quote        | External | BOLH 	   	  |
