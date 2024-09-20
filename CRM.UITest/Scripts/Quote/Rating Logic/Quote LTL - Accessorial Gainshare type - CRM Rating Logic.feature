@48837 @NinjaSprint24
Feature: Quote (LTL) - Accessorial Gainshare Type - CRM Rating Logic

Scenario Outline: 48837_Verify that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer has a Set Individual Accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL rate request,
And my customer has a Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + (MG accessorial cost * (% over cost / 100))
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 50    | External | % over cost |

Scenario Outline: 48837_Verify that the CRM will apply accessorial cost as per flat over cost calculation when the gain share type is flat over cost and customer has a Set Individual Accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL rate request,
And my customer has a Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
 #CRM accessorial cost = MG accessorial cost + flat over cost
 Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | Flat over cost |

 Scenario Outline: 48837_Verify that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer has a Set Individual Accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL rate request,
And my customer has a Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | Set flat amount |


Scenario Outline: 48837_Verify that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer has carrier-specific set individual accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL rate request,
And my customer has a Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + (MG accessorial cost * % over cost)
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | % over cost |

Scenario Outline: 48837_Verify that the CRM will apply accessorial cost as per Flat over cost calculation when the gain share type is Flat over cost and customer has carrier-specific set individual accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL rate request,
And my customer has a Carrier-Specific Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + flat over cost
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | Flat over cost |


Scenario Outline: 48837_Verify that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer has carrier-specific set individual accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL rate request,
And my customer has a Carrier-Specific Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | Flat over cost |


Scenario Outline: 48837_Verify ltl requote that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer has a Set Individual Accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am re-quoting an expired LTL quote,
And my customer has a Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + (MG accessorial cost * (% over cost / 100))
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | % over cost |

Scenario Outline: 48837_Verify ltl requote that the CRM will apply accessorial cost as per flat over cost calculation when the gain share type is flat over cost and customer has a Set Individual Accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am re-quoting an expired LTL quote,
And my customer has a Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
 #CRM accessorial cost = MG accessorial cost + flat over cost
 Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | Flat over cost |

 Scenario Outline: 48837_Verify ltl requote that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer has a Set Individual Accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am re-quoting an expired LTL quote,
And my customer has a Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | Set flat amount |


Scenario Outline: 48837_Verify ltl requote that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer has carrier-specific set individual accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am re-quoting an expired LTL quote,
And my customer has a Carrier-Specific Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + (MG accessorial cost * % over cost)
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | % over cost |

Scenario Outline: 48837_Verify ltl requote that the CRM will apply accessorial cost as per Flat over cost calculation when the gain share type is Flat over cost and customer has carrier-specific set individual accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am re-quoting an expired LTL quote,
And my customer has a Carrier-Specific Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + flat over cost
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | Flat over cost |


Scenario Outline: 48837_Verify ltl requote that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer has carrier-specific set individual accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am re-quoting an expired LTL quote,
And my customer has a Carrier-Specific Set Individual Accessorials,
And the Accessorial GainshareType is <GainShareType>,
And CRM Rating Logic = Yes,
And the rate request from CRM included the Set Individual Accessorials,
When CRM receives a rate responses from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorials cost using the formula <GainShareType>
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | Flat over cost |



