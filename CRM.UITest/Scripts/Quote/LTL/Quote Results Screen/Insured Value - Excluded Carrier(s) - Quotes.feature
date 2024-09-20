@35686 @Sprint76
Feature: Insured Value - Excluded Carrier(s) - Quotes

@Regression
Scenario Outline: Verify the insured value for excluded carriers on quote rate results page_nonguaranteed
Given I am a DLS user and login into application with valid <Username> and <Password>
When I am on the quotes results page<CustomerName>,<Service>,<OriginZip>,<DestinationZip>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<insuredvalue>
Then insured Quote Cost, Save Insured Rate option,Create Insured Shipment option  will not be displayed for carriers which excluded from Insurance All Risk pricing 
And I will be displayed with<text> in insured rate column for excluded carriers


Examples:
| Scenario | Username | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | text                                 | insuredvalue |
| s1       | zzzext   | Te$t1234 | ZZZ - Czar Customer Test | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 3      | No insured pricing for this carrier. | 100          |


@Regression
Scenario Outline: Verify the insured value for excluded carriers on quote rate results page_guaranteed
Given I am a DLS user and login into application with valid <Username> and <Password>
When I am on the quotes results page<CustomerName>,<Service>,<OriginZip>,<DestinationZip>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<insuredvalue>
Then insured Quote Cost, Save Insured Rate option,Create Insured Shipment option  will not be displayed for carriers which excluded from Insurance All Risk pricing in guaranteed grid
And I will be displayed with<text> in insured rate column for excluded carriers in guaranteed grid


Examples:
| Scenario | Username | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | text                                 | insuredvalue |
| s1       | zzzext   | Te$t1234 | ZZZ - Czar Customer Test | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 3      | No insured pricing for this carrier. | 100          |


@Regression
Scenario Outline: Verify the insured value for excluded carriers on quote rate results page_insuredvalenteredinresultspage_nonguaranteed
Given I am a DLS user and login into application with valid <Username> and <Password>
When am on quotes results page<CustomerName>,<Service>,<OriginZip>,<DestinationZip>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<insuredvalue>
And I entered <insuredvalue> on results page
Then insured Quote Cost, Save Insured Rate option,Create Insured Shipment option  will not be displayed for carriers which excluded from Insurance All Risk pricing 
And I will be displayed with<text> in insured rate column for excluded carriers


Examples:
| Scenario | Username | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | text                                 | insuredvalue |
| s1       | zzzext   | Te$t1234 | ZZZ - Czar Customer Test | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 3      | No insured pricing for this carrier. |100           |


@Regression
Scenario Outline: Verify the insured value for excluded carriers on quote rate results page_insuredvalenteredinresultspage_guaranteed
Given I am a DLS user and login into application with valid <Username> and <Password>
When I am on the quotes results page<CustomerName>,<Service>,<OriginZip>,<DestinationZip>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<insuredvalue>
Then insured Quote Cost, Save Insured Rate option,Create Insured Shipment option  will not be displayed for carriers which excluded from Insurance All Risk pricing in guaranteed grid
And I will be displayed with<text> in insured rate column for excluded carriers


Examples:
| Scenario | Username | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | text                                 | insuredvalue |
| s1       | zzzext   | Te$t1234 | ZZZ - Czar Customer Test | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 3      | No insured pricing for this carrier. |100           |

