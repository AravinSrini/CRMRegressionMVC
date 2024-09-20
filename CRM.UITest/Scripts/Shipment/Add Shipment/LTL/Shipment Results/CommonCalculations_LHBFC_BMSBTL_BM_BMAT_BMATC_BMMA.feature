@30318 @Sprint72
Feature: CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMA
	

@Functional
Scenario Outline: Verify the LHBFSC_BMSBTL_BM_BMAT_BMATC_BMAA calculations
    Given I am an DLS user and login into application with valid <Username> and <Password>	
	When I enter all valid required data on the Get Quote LTL page <userType> , <CustomerName>, <OriginZip>, <originAccessorials>,<DestinationZip>,<destinationAccessorials>, <Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>
	And I click on view quote results button on the Get Quote LTL page
	Then BMAA should be calculated <userType>, <CustomerName>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>,<Username>,<originAccessorials>,<destinationAccessorials>
	


Examples: 
| Scenario | Username | Password | userType | CustomerName           | Service | OlocationName  | OLocationAddress      | OriginZip | OriginCity | OriginState | OriginCountry | DDestinationName    | DDestinationAddress        | DestinationZip | DestinationCity | DestinationState | DestinationCountry | Classification | NMFC | Quantity | QuantityUNIT | ItemDescription  | Weight | WeightUnit | originAccessorials | destinationAccessorials |
| S1       | zzzext | Te$t1234 | Quote    | ZZZ - Czar Customer Test | LTL     | OriginTestView | OriginTestViewAddress | 33126     | Miami      | FL          | USA           | DestinationTestView | DestinationTestViewAddress | 85282          | Tempe           | AZ               | USA                | 50             | 6778 | 6        | Skids        | ItemInformation1 | 1000   | LBS        | Appointment        | COD                     |


