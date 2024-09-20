@Sprint68 @28252
Feature: ShipmentList_GridDisplay_InternalUsers

@Functional @Regression @DBVerification
Scenario Outline: Compare and verify the displaying shipment list with API for stationowner
Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then displaying last 30days shipments should match with API results <StationData>

Examples: 
| Username   | Password | StationData | Option |
| stationown |  | ZZZ,ZZX     | ALL    |


@Functional @Regression @DBVerification
Scenario Outline: Compare and verify the displaying shipment list with API for OpStage user
	Given I Log in as Opstage user
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then displaying last 30days shipments should match with API results <StationData>

Examples: 
| Username   | Password | StationData | Option |
 | Opstage    | Te$t1234 | ATW         | ALL    |
