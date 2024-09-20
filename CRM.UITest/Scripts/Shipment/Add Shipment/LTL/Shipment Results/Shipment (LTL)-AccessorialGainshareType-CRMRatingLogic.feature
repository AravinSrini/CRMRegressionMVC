@48838 @NinjaSprint24

Feature: Shipment (LTL)-AccessorialGainshareType-CRMRatingLogic

Scenario Outline: 48838_Verify that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer has a Set Individual Accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL Shipment,
And my customer has a Set Individual Accessorial,
And CRM Rating Logic = Yes
And CRM receives a rate request response from MG that includes the Set Individual Accessorial <Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
When the Accessorial Gainshare Type is <GainShareType>
Then CRM will calculate the accessorial cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + (MG accessorial cost * (% over cost / 100))
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 50    | External | % over cost |

Scenario Outline: 48838_Verify that the CRM will apply accessorial cost as per flat over cost calculation when the gain share type is flat over cost and customer has a Set Individual Accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL Shipment,
And my customer has a Set Individual Accessorial,
And CRM Rating Logic = Yes
And CRM receives a rate request response from MG that includes the Set Individual Accessorial <Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
When the Accessorial Gainshare Type is <GainShareType>
Then CRM will calculate the accessorial cost using the formula <GainShareType>
 #CRM accessorial cost = MG accessorial cost + flat over cost
 Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | Flat over cost |

 Scenario Outline: 48838_Verify that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer has a Set Individual Accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL Shipment,
And my customer has a Set Individual Accessorial,
And the Accessorial Gainshare Type is <GainShareType>,
And CRM Rating Logic = Yes
And the rate request from CRM included the Set Individual Accessorial,
When CRM receives a rate response from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorial cost using the formula <GainShareType>
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | Set flat amount |


Scenario Outline: 48838_Verify that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer has carrier-specific set individual accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL Shipment,
And my customer has a Carrier-Specific Set Individual Accessorial,
And CRM Rating Logic = Yes
And CRM receives a rate request response from MG for the carrier with specific pricing that includes the Set Individual Accessorial<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
When the Accessorial Gainshare Type is <GainShareType>,
Then CRM will calculate the accessorial cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + (MG accessorial cost * % over cost)
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | % over cost |

Scenario Outline: 48838_Verify that the CRM will apply accessorial cost as per Flat over cost calculation when the gain share type is Flat over cost and customer has carrier-specific set individual accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL Shipment,
And my customer has a Carrier-Specific Set Individual Accessorial,
And CRM Rating Logic = Yes
And CRM receives a rate request response from MG for the carrier with specific pricing that includes the Set Individual Accessorial<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
When the Accessorial Gainshare Type is <GainShareType>,
Then CRM will calculate the accessorial cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + flat over cost
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | Flat over cost |


Scenario Outline: 48838_Verify that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer has carrier-specific set individual accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am creating an LTL Shipment,
And my customer has a Carrier-Specific Set Individual Accessorial,
And the Accessorial Gainshare Type is <GainShareType>,
And CRM Rating Logic = Yes
And the rate request from CRM included the Set Individual Accessorial,
When CRM receives a rate response from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorial cost using the formula <GainShareType>
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | Flat over cost |


Scenario Outline: 48838_Verify copy ltl shipment that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer has a Set Individual Accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am copying an LTL shipment <UserType>,
And my customer has a Set Individual Accessorial,
And CRM Rating Logic = Yes
And CRM receives a rate request response from MG that includes the Set Individual Accessorial <Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
When the Accessorial Gainshare Type is <GainShareType>
Then CRM will calculate the accessorial cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + (MG accessorial cost * (% over cost / 100))
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | External | % over cost |

Scenario Outline: 48838_Verify copy ltl shipment that the CRM will apply accessorial cost as per flat over cost calculation when the gain share type is flat over cost and customer has a Set Individual Accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am copying an LTL shipment <UserType>,
And my customer has a Set Individual Accessorial,
And CRM Rating Logic = Yes
And CRM receives a rate request response from MG that includes the Set Individual Accessorial <Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
When the Accessorial Gainshare Type is <GainShareType>
Then CRM will calculate the accessorial cost using the formula <GainShareType>
 #CRM accessorial cost = MG accessorial cost + flat over cost
 Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | Flat over cost |

 Scenario Outline: 48838_Verify copy ltl shipment that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer has a Set Individual Accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am copying an LTL shipment <UserType>,
And my customer has a Set Individual Accessorial,
And the Accessorial Gainshare Type is <GainShareType>,
And CRM Rating Logic = Yes
And the rate request from CRM included the Set Individual Accessorial,
When CRM receives a rate response from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorial cost using the formula <GainShareType>
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | Set flat amount |


Scenario Outline: 48838_Verify copy ltl shipment that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer has carrier-specific set individual accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am copying an LTL shipment <UserType>,
And my customer has a Carrier-Specific Set Individual Accessorial,
And CRM Rating Logic = Yes
And CRM receives a rate request response from MG for the carrier with specific pricing that includes the Set Individual Accessorial<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
When the Accessorial Gainshare Type is <GainShareType>,
Then CRM will calculate the accessorial cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + (MG accessorial cost * % over cost)
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | % over cost |

Scenario Outline: 48838_Verify copy ltl shipment that the CRM will apply accessorial cost as per Flat over cost calculation when the gain share type is Flat over cost and customer has carrier-specific set individual accessorial 
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am copying an LTL shipment <UserType>,
And my customer has a Carrier-Specific Set Individual Accessorial,
And CRM Rating Logic = Yes
And CRM receives a rate request response from MG for the carrier with specific pricing that includes the Set Individual Accessorial<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
When the Accessorial Gainshare Type is <GainShareType>,
Then CRM will calculate the accessorial cost using the formula <GainShareType>
#CRM accessorial cost = MG accessorial cost + flat over cost
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | Flat over cost |


Scenario Outline: 48838_Verify copy ltl shipment that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer has carrier-specific set individual accessorial
Given I am a  shp.entry, sales, sales management, operations, or station owner user
And I am copying an LTL shipment <UserType>,
And my customer has a Carrier-Specific Set Individual Accessorial,
And the Accessorial Gainshare Type is <GainShareType>,
And CRM Rating Logic = Yes
And the rate request from CRM included the Set Individual Accessorial,
When CRM receives a rate response from MG<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<UserType>
Then CRM will calculate the accessorial cost using the formula <GainShareType>
Examples:
| Customer_Name             | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | Classification | Quantity | Weight | UserType | GainShareType |
| ZZZ - Czar Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                | 70             | 1        | 100    | Internal | Flat over cost |



