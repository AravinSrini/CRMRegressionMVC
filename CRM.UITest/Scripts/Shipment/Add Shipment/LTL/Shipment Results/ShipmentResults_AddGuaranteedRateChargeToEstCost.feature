@NinjaSprint11 @ShipmentResults_AddGuaranteedRateChargeToEstCost @37593  
Feature: ShipmentResults_AddGuaranteedRateChargeToEstCost

@GUI @Functional 
Scenario Outline: 37593_Verify the GuaranteedRate is added to Estimated Cost as accessorial in Guaranteed Carriers Section for Internal Non admin users
	Given I am a operations, sales, sales management or station user <Username> <Password>
	And I enter data in add LTL Shipment Information page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc> and Click on View rates button
	When I arrive on the Shipment Results page and scroll the page for Guaranteed Rates Section
	Then I will see the guaranteed rate charge applied to the Est Cost total for any carrier displaying a guaranteed rate in Guaranteed carriers section
	And The guaranteed charge will be applied to the rate details as an accessorial.

Examples: 
| Scenario | Username               | Password | Usertype | CustomerName           | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com  | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | Conyers    | GA          | 30013         | Dname           | Dname2           | Conyers         | GA               | 30013              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |
| S2       | SalesManager@stage.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |
| S3       | stationown             | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname       | MIAMI      | FL          | 33126         | Dname           | Dname2           | TEMPE           | AZ               | 85282              | 60             | 2345-03 | 2        | 23     | CLEANING WIPES |

@GUI
Scenario Outline: 37593_Verify the guaranteed rate charge is applied EstCost total in Shipment Review and submit page
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add LTL Shipment Information page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc> and Click on View rates button
	And I arrive on the Shipment Results page and scroll the page for Guaranteed Rates Section
	And I select a guaranteed carrier rate on the Shipment Results page
	When I arrive on Review and Submit Shipment LTL page
	Then I will see the guaranteed rate charge applied to the Est Cost total in Review and submit page
	
Examples: 
| Scenario | Username               | Password | Usertype | CustomerName           | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com  | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | Conyers    | GA          | 30013         | Dname           | Dname2           | Conyers         | GA               | 30013              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |
| S2       | SalesManager@stage.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |
| S3       | stationown             | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname       | MIAMI      | FL          | 33126         | Dname           | Dname2           | TEMPE           | AZ               | 85282              | 60             | 2345-03 | 2        | 23     | CLEANING WIPES |
