@Sprint76 @37940 @Ignore
Feature: CRM Rating Logic - Guaranteed Rate Calculation - Quote Results
	
	@Functional @API
	Scenario Outline: Verify CRM Rating Logic for the Guaranteed Rates in Quote Results page
	Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
	When Iam on the quote results page<CustomerName>,<UserType>,<OriginCity>,<OriginZip>,<OriginState>,<OriginCountry>,<DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>,<Weight>
	Then the Rate will be determined by applying the CRM Rating calculation to the guaranteed rate amount<CustomerName>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>,<Username> <UserType>

	Examples: 
	| Scenario | Username | Password | CustomerName			  | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | WeightUnit | Mode | UserType | CalculationType | oName | oAdd1 | dName | dAdd1 | nmfc | desc |
    | S1       | both     | Te$t1234 | ZZZ - GS Customer Test | LTL     | Miami      | 33126     | FL          | USA           |       Tempe     | 85282          | AZ               | USA                |              |              | 50             | 1        | SKD          | 1      |   lbs      |      | External |                 |       |       |       |       |      |      |


@Functional @API
Scenario Outline: Verify CRM Rating Logic for the Insured Guaranteed Rates in Quote Results page
	Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
	When Iam on the quote results page<CustomerName>,<UserType>,<OriginCity>,<OriginZip>,<OriginState>,<OriginCountry>,<DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>,<Weight>
	And I Enter the Insured value in Quote results page<InsuredValue>
	Then the Rate will be determined by applying the CRM Rating calculation to the Insured guaranteed rate amount<CustomerName>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>,<Username> <UserType>
	

	Examples: 
	| Scenario | Username | Password | CustomerName          | Service    | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | OAccessorial | DAccessorial | Classification | Quantity | QuantityUNIT | Weight | WeightUnit | Mode | UserType | CalculationType | oName | oAdd1 | dName | dAdd1 | nmfc | desc | InsuredValue |
   | s1       | both    | Te$t1234 | ZZZ - GS Customer Test | LTL        | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |              |              | 50             | 1        | SKD          | 1      | lbs        |      | External |                 |       |       |       |       |      |      | 12           |


   
