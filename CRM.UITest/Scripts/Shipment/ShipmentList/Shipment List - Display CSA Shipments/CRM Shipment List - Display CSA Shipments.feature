@Sprint81 @39200
Feature: CRM Shipment List - Display CSA Shipments
	
@Acceptance
Scenario Outline: 39200_Verify Shipment list results for CSA Shipments when user entered value in Reference number look up
	Given I am a shp.entry, shp.entrynorates, shp.inquiry, shp.inquirynorates, operations, sales, sales management, or station owner user	
	And I am on the ShipmentList page
	And I have entered reference number <refNumber> 
	When I click on arrow
	Then the shipment list will have CSA reference number <refNumber>

	Examples: 
	 | refNumber       |
	 | 9538814,8125124 |

@Acceptance
Scenario Outline: 39200_Verify Shipment list results for CSA shipments when user selects custom report of CSA service types
	Given I am a shp.entry, shp.entrynorates, shp.inquiry, shp.inquirynorates, operations, sales, sales management, or station owner user
	And I am on the ShipmentList page	
	When I Select <customreport> of service types includes<servicetypes>
	Then the shipment list will have the CSA shipments for the <customreport>

	Examples: 
	| customreport        | servicetypes                      |
	| SwaTestCustomReport | Domestic Forwarding,international |
	
@Acceptance
Scenario Outline: 39200_Verify Shipment List results for CSA Shipments when user selects a station from customer dropdown 
	Given I am a sales, sales management, operations, or station owner user
	When I select <station> from customer dropdown of shipment list page
	Then shipment list will have the CSA shipments for the selected <station>

	Examples: 
	| station                 |
	| ZZZ - Web Services Test |


@111277
Scenario Outline: 111277_Verify Shipment list results for CSA shipments when user selects custom report of CSA service types with CSA API Call using Handling Station
	Given I am a sales, sales management, or station owner user
	And I am on the ShipmentList page	
	When I Select <customreport> of service types includes<servicetypes>
	Then the shipment list will have the CSA shipments for the <customreport>
	And  CSA API result should contains the CSA shipment list  showing in Grid  for the follwing values <DateStartTime>,<DateStopTime>,<OriginCity>,<DestinationCity>,<Station>

	Examples: 
	| customreport           | servicetypes                        | DateStartTime | DateStopTime | OriginCity | DestinationCity | Station |
	| AutoReport_DF_111277   | Domestic Forwarding                 | 03/20/2018    | 03/20/2019   |            |                 | ZZZ     |
	| AutoReport_DFIN_111277 | International                       | 09/01/2018    | 03/20/2019   | Chicago    | Chicago         |         |
	| AutoReport_INDF_111277 | Domestics Forwarding, International | 09/01/2018    | 03/20/2019   |            |                 | ZZZ     |  


@111277
Scenario Outline: 111277_Verify Shipment list results for CSA shipments when sales user selects custom report than filter of the shipments should  associated to Sales user customers.
	Given I am a Sales user
	And I am on the ShipmentList page	
	When I Select <customreport> of service types includes<servicetypes>
	Then CSA API result should contains the CSA shipment list  showing in Grid  for the follwing values <DateStartTime>,<DateStopTime>,<OriginCity>,<DestinationCity>,<Station>
	And  the Shipment list will have the CSA shipments for the customreport associated to Sales user <customers>.
	
	
	Examples: 
	| customreport                | servicetypes                        | customers              | DateStartTime | DateStopTime | OriginCity | DestinationCity | Station |
	| AutoReport_IN_111277        | International                       | ZZZ - GS Customer Test | 09/02/2018    | 03/20/2019   |            |                 | ZZZ     |
	| SalesAutoReport_DF_111277   | Domestic Forwarding                 | ZZZ - GS Customer Test | 09/02/2018    | 03/20/2019   | Chicago    | Chicago         | ZZZ     |
	| SalesAutoReport_DFIN_111277 | Domestics Forwarding, International | ZZZ - GS Customer Test | 09/02/2018    | 03/20/2019   |            |                 | ZZZ     |  
	