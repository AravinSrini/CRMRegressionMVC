@CRM Rating Logic - Guaranteed Rate Calculation - Shipment Results @Sprint77 @38535

Feature: CRM Rating Logic - Guaranteed Rate Calculation - Shipment Results

Scenario Outline:Verify the Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount -Guaranteed CRM ratig logic rate
Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
When  am on the Shipment results page<Customer_Name>,<OriginZip>,<DestinationZip>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<oName>,<oAdd1>,<dName>,<dAdd1>,<nmfc>,<desc>
And   I arrive on the Shipment Results (LTL) page,
Then the Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<Username>,<UserType>,<OAccessorial>,<DAccessorial>

Examples:
| Scenario | Username               | Password | Customer_Name          | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | WeightUnit | Mode | UserType | CalculationType | oName | oAdd1 | dName | dAdd1 | nmfc | desc |
| S1       | testentry@test.com     | Te$t1234 | ZZZ - GS Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 1      | lbs        |      | External |                 | ona   | oadd  | dname |dadd1  | 2222 | tes  |



Scenario Outline:Verify the Rate (customer charge) will be determined by applying the CRM Rating calculation to the Insured guaranteed rate amount -Insured guaranteed CRM ratig logic rate
Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
When  am on the Shipment results page<Customer_Name>,<OriginZip>,<DestinationZip>,<DAccessorial>,<Classification>,<Quantity>,<Weight>,<UserType>,<oName>,<oAdd1>,<dName>,<dAdd1>,<nmfc>,<desc>
And   I arrive on the Shipment Results (LTL) page and enter Insured Value <InsuredValue>
Then the Rate (customer charge) will be determined by applying the CRM Rating calculation to the Insured guaranteed rate amount<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<Username>,<UserType>,<OAccessorial>,<DAccessorial>,<InsuredValue>

Examples:
| Scenario | Username           | Password | Customer_Name          | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | WeightUnit | Mode | UserType | CalculationType | oName | oAdd1 | dName | dAdd1 | nmfc | desc | InsuredValue |
| S1       | testentry@test.com | Te$t1234 | ZZZ - GS Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              | COD          | 50             | 1        | SKD          | 1      | lbs        |      | External |                 | ona   | oadd  | dname | dadd1 | 2222 | tes  | 10           |