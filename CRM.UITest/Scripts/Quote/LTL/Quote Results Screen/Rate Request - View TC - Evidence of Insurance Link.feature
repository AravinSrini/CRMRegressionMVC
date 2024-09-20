@34397 @Sprint76
Feature: Rate Request - View TC - Evidence of Insurance Link

@Regression
Scenario Outline: Verify the Evidence of Insurance Link_TermsAndConditions of Coverage_Get Quote (LTL) page
Given I am a DLS user and login into application with valid <userName> and <password>
When I am on Get Quote (LTL) page <Service>,<UserType>,<CustomerName>
And  I have entered an <Insuredvalue> on the Get Quote (LTL) page
And I am on Terms & Conditions of Coverage
Then I will be presented with an option to download the 'Evidence of Insurance' form

Examples: 
| Scenario | userName | password | Service | UserType | CustomerName            | Insuredvalue |
| s1       | zzzext   | Te$t1234 |  LTL    | External | ZZZ - Czar Customer Test| 100          |

@Regression
Scenario Outline: Verify the Evidence of Insurance Link_TermsAndConditions of Coverage_Quote results page
Given I am a DLS user and login into application with valid <userName> and <Password>
When I am on the quotes results page<CustomerName>,<Service>,<OriginZip>,<DestinationZip>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<insuredvalue>
And I entered <EnterInsuredValue> on results page
And I am on Terms & Conditions of Coverage modal 
Then I will be presented with an option to download the 'Evidence of Insurance' form

Examples:
| Scenario | userName | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | text                                 | EnterInsuredValue |
| s1       | zzzext   | Te$t1234 | ZZZ - Czar Customer Test | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 3      | No insured pricing for this carrier. | 1000              |



@Regression
Scenario Outline: Verify the Evidence of Insurance Link_TermsAndConditions of Coverage_Quote results page_have Insuredvalue on information page
Given I am a DLS user and login into application with valid <userName> and <Password>
When I am on the quotes results page<CustomerName>,<Service>,<OriginZip>,<DestinationZip>,<OAccessorial>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<insuredvalue>
And I am on Terms & Conditions of Coverage modal 
Then I will be presented with an option to download the 'Evidence of Insurance' form

Examples:
| Scenario | userName | Password | CustomerName             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | text                                 | insuredvalue |
| s1       | zzzext   | Te$t1234 | ZZZ - Czar Customer Test | COD     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 3      | No insured pricing for this carrier. | 100           |

