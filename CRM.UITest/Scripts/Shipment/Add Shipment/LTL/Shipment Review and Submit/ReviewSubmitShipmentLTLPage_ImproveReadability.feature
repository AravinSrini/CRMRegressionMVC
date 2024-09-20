@NinjaSprint13 @40718
Feature: ReviewSubmitShipmentLTLPage_ImproveReadability

#Scenarios : For External Users
@GUI
Scenario Outline: 40718_Verify_Labels_And_Values_In_Black_for_External_Users
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then I verify the labels and values will be black.

Examples: 
| Scenario | UserType  | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

# Scenarios : For Internal Users
@GUI
Scenario Outline: 40718_Verify_Labels_And_Values_In_Black_for_Internal_Users
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then I verify the labels and values will be black for Internal User.
	
Examples: 
| Scenario | UserType     | CustomerName           | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | stationowner | ZZZ - GS Customer Test | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

