@Sprint77 @37940
Feature: CRMRatingLogic - Guaranteed Rate Calculation - Quote Results

@Regression
	Scenario Outline:Verify the Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount -Guaranteed CRM ratig logic rate
Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
When I am on quote results page for Calculating Gauranteed Total Cost<Customer_Name>, <UserType>, <OriginZip>, <DestinationZip>, <Classification>, <Quantity>, <Weight>, <destinationAccessorials>
Then Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount for the Quote<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<Username>,<UserType>,<originAccessorials>,<destinationAccessorials>

Examples:
| Username				| Password | Customer_Name			| Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | originAccessorials | destinationAccessorials | Classification | Quantity |  Weight |  UserType | CalculationType | 
|testentry@test.com     | Te$t1234 | ZZZ - GS Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |                    | COD                     | 50             | 1        | 1       | External  |                 | 

@Regression
Scenario Outline:Verify the Rate (customer charge) will be determined by applying the CRM Rating calculation to Insured the guaranteed rate amount -Guaranteed CRM ratig logic rate
Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
When I am on quote results page for Calculating Gauranteed Total Cost<Customer_Name>, <UserType>, <OriginZip>, <DestinationZip>, <Classification>, <Quantity>, <Weight>, <destinationAccessorials>
And I Entered Insured value in quote results page<InsuredValue>
Then Rate (customer charge) will be determined by applying the CRM Rating calculation to the Insured guaranteed rate amount for Quote<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <Weight>,<Username>,<UserType>,<originAccessorials>,<destinationAccessorials>,<InsuredValue>

Examples:
| Username           | Password | Customer_Name          | Service | OriginCity | OriginZip | OriginState | OriginCountry | DestinationCity | DestinationZip | DestinationState | DestinationCountry | originAccessorials | destinationAccessorials | Classification | Quantity | Weight | UserType | CalculationType | InsuredValue   |
| testentry@test.com | Te$t1234 | ZZZ - GS Customer Test | LTL     | Miami      | 33126     | FL          | USA           | Tempe           | 85282          | AZ               | USA                |                    | COD                     | 50             | 1        | 1      | External |                 |    10          |
