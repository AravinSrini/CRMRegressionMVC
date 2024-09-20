
Feature: ShipmentResultsLTLPage_ImproveResultsDisplay

#Scenarios : For External Users
@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_Carrier legal liability verbiage is changed to Carrier's legal liability per lb if uninsured for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier legal liability verbiage is Carrier's legal liability per lb if uninsured

Examples: 
| Scenario | UserType  | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier max liability verbiage is changed to Carrier's max liability if uninsured for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier max liability verbiage is Carrier's max liability if uninsured

Examples: 
| Scenario | UserType | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname       | Oname1     | LOS ANGELS  | CA            | 90001           | Dname            | Dname2          | LOS ANGELS       | CA                 | 90001          | 55      | 6789-01  | 5      | 100            | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier legal liability Currency value for New is formatted to xxx.xx for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier legal liability Currency value for New is formatted to xxx.xx

Examples: 
| Scenario | UserType | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname       | Oname1     | LOS ANGELS  | CA            | 90001           | Dname            | Dname2          | LOS ANGELS       | CA                 | 90001          | 55      | 6789-01  | 5      | 100            | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier legal liability Currency value for Used is formatted to xxx.xx for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier legal liability Currency value for Used is formatted to xxx.xx

Examples: 
| Scenario | UserType | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname       | Oname1     | LOS ANGELS  | CA            | 90001           | Dname            | Dname2          | LOS ANGELS       | CA                 | 90001          | 55      | 6789-01  | 5      | 100            | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier max liability Currency value for New is formatted to xxx.xx for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier max liability Currency value for New is formatted to xxx.xx

Examples: 
| Scenario | UserType | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname       | Oname1     | LOS ANGELS  | CA            | 90001           | Dname            | Dname2          | LOS ANGELS       | CA                 | 90001          | 55      | 6789-01  | 5      | 100            | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier max liability Currency value for Used is formatted to xxx.xx for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier max liability Currency value for Used is formatted to xxx.xx

Examples: 
| Scenario | UserType | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname       | Oname1     | LOS ANGELS  | CA            | 90001           | Dname            | Dname2          | LOS ANGELS       | CA                 | 90001          | 55      | 6789-01  | 5      | 100            | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The text color of the carrier liability information is in dark gray for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the text color of the carrier liability information is in dark gray

Examples: 
| Scenario | UserType | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname       | Oname1     | LOS ANGELS  | CA            | 90001           | Dname            | Dname2          | LOS ANGELS       | CA                 | 90001          | 55      | 6789-01  | 5      | 100            | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The service days is displayed with "days" to the right of the number of service days for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the service days is displayed with days to the right of the number of service days 
	
Examples: 
| Scenario | UserType  | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The verbiage "Direct to Destination" is displayed as "Direct" and "Indirect to Destination" is displayed as "Indirect" for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the verbiage Direct to Destination is displayed as Direct and Indirect to Destination is displayed as Indirect
	
Examples: 
| Scenario | UserType  | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Rate total is displayed in bold type for external user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Rate total is displayed in bold type
	
Examples: 
| Scenario | UserType  | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Insured Rate total is displayed in bold type for external user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Insured Rate total is displayed in bold type
	
Examples: 
| Scenario | UserType  | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Terms and Conditions link and verbiage "*Creating an insured shipment means you agree to the Terms and Conditions." is available at the bottom of the page
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Terms and Conditions link and verbiage Creating an insured shipment means you agree to the Terms and Conditions. is available at the bottom of the page
	
Examples: 
| Scenario | UserType  | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Quote Disclaimer text is removed in the bottom of the Page
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Quote Disclaimer text is removed in the bottom of the Page
	
Examples: 
| Scenario | UserType  | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Quite Expatriation text is removed in the bottom of the Page
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Quote Expatriation text is removed in the bottom of the Page
	
Examples: 
| Scenario | UserType  | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |


@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Terms and Conditions applicable to Default insurance all risk settings is displayed for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I arrive on the Shipment Results LTL page
	When I click on TermsAndConditions link at the bottom of the page
	Then the Terms and Conditions applicable to default or customer specific insurance all risk settings is displayed
	
Examples: 
| Scenario | UserType | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | both| Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @Ignore @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Terms and Conditions applicable to PPP insurance all risk settings is displayed for External user
	Given I am a shp.entry User <UserType>
	And I arrive on the External user AddShipments Page
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I arrive on the Shipment Results LTL page
	When I click on TermsAndConditions link at the bottom of the page
	Then the Terms and Conditions applicable to PPP insurance all risk settings is displayed

Examples: 
| Scenario | UserType | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | shipentry     | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

# Scenarios : For Internal Users
@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_Carrier legal liability verbiage is changed to Carrier's legal liability per lb if uninsured for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier legal liability verbiage is Carrier's legal liability per lb if uninsured
	
Examples: 
| Scenario | UserType | CustomerName           | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier max liability verbiage is changed to Carrier's max liability if uninsured for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier max liability verbiage is Carrier's max liability if uninsured

Examples: 
| Scenario | UserType | CustomerName           | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier legal liability Currency value for New is formatted to xxx.xx for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier legal liability Currency value for New is formatted to xxx.xx

Examples: 
| Scenario | UserType | CustomerName           | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | Conyers | GA          | 30013         | Dname           | Dname2           | Conyers      | GA               | 30013              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier legal liability Currency value for Used is formatted to xxx.xx for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier legal liability Currency value for Used is formatted to xxx.xx

Examples: 
| Scenario | UserType | CustomerName           | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier max liability Currency value for New is formatted to xxx.xx for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier max liability Currency value for New is formatted to xxx.xx

Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The carrier max liability Currency value for Used is formatted to xxx.xx for Internal user
	Given I am a shp.entry User <UserType>	
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the carrier max liability Currency value for Used is formatted to xxx.xx

Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The text color of the carrier liability information is in dark gray for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the text color of the carrier liability information is in dark gray

Examples: 
| Scenario | UserType | CustomerName           | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| s1       | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The service days is displayed with "days" to the right of the number of service days for Internal user 
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the service days is displayed with days to the right of the number of service days 

Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The verbiage "Direct to Destination" is displayed as "Direct" and "Indirect to Destination" is displayed as "Indirect" for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the verbiage Direct to Destination is displayed as Direct and Indirect to Destination is displayed as Indirect
	
Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Estimated Margin total is displayed in bold type for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Estimated Margin total is displayed in bold type
	And the Estimated Margin total is formatted to xxx.xx

Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Estimated Rate total is displayed in bold type for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Estimated Rate total is displayed in bold type

Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Rate total is displayed in bold type for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Rate total is displayed in bold type
	
Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Insured Rate total is displayed in bold type for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Insured Rate total is displayed in bold type
	
Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Terms and Conditions link and verbiage "*Creating an insured shipment means you agree to the Terms and Conditions." is available at the bottom of the page for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Terms and Conditions link and verbiage Creating an insured shipment means you agree to the Terms and Conditions. is available at the bottom of the page

Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Quote Disclaimer text is removed in the bottom of the Page for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Quote Disclaimer text is removed in the bottom of the Page
	
Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Quite Expatriation text is removed in the bottom of the Page for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I arrive on the Shipment Results LTL page
	Then the Quote Expatriation text is removed in the bottom of the Page

Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Terms and Conditions applicable to Default insurance all risk settings is displayed for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I arrive on the Shipment Results LTL page
	When I click on TermsAndConditions link at the bottom of the page
	Then the Terms and Conditions applicable to default or customer specific insurance all risk settings is displayed
	
Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - GS Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@GUI @Ignore @NinjaSprint13 @34554
Scenario Outline: 34554_Verify_The Terms and Conditions applicable to PPP insurance all risk settings is displayed for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I arrive on the Internal user AddShipments Page <CustomerName>
	And I enter data in add LTL Shipment Information page <originName>,<originAddr1>,<originCity>,<originState>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationCity>,<destinationState>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I arrive on the Shipment Results LTL page
	When I click on TermsAndConditions link at the bottom of the page
	Then the Terms and Conditions applicable to PPP insurance all risk settings is displayed

Examples: 
| Scenario | UserType | CustomerName | originName | originAddr1 | originCity | originState | originZipcode | destinationName | destinationAddr1 | destinationCity | destinationState | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc |
| s1       | stationowner | ZZZ - Czar Customer Test    | Oname      | Oname1      | LOS ANGELS | CA          | 90001         | Dname           | Dname2           | LOS ANGELS      | CA               | 90001              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |

@90802 @Sprint91
Scenario Outline: A 90802 Verify the updated Terms and Conditions associated to PPP Customers with insurance-all risk setting in Add Shipment(LTL) page
Given I'm shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
And I am associated to a customer with PPP/Non-Default insurance all risk setting<customer>
And I'm on the Add Shipment (LTL) page<ShipmentType>,<UserType>
And I entered value in the Enter insured value field
And "Terms and Conditions" link was displayed
When I have click Terms and Conditions link
Then the updated Terms and Conditions associated to customers with the PPP insurance-all risk setting will be displayed in the <Terms And Conditions Of Coverage> modal
Examples: 
		| UserType | 		customer				  | ShipmentType       |
		| External | ZZZ - Czar Customer Test         | Rate To Shipment   |
		| External | ZZZ - Czar Customer Test         | Quote To Shipment  |
		| Internal | ZZZ - Czar Customer Test         | Direct Shipment    |
		| Internal | ZZZ - Czar Customer Test         | Copy Shipment	   |
		| Sales    | ZZZ - Czar Customer Test         | Return Shipment    |
		| Sales    | ZZZ - Czar Customer Test         | Edit Shipment      |
	    
@90802 @Sprint91
Scenario Outline: B 90802 Verify the updated Terms and Conditions for the PPP Customers in the Shipment Results(LTL) page for the Shipment value entered in Add Shipment(LTL) page
Given I'm shp.entry, sales, sales management, operations, or stationowner <UserType> user
And I am associated to a customer with PPP/Non-Default insurance all risk setting<customer>
And I'm on the Add Shipment (LTL) page<ShipmentType>,<UserType>
And I entered value in the Enter insured value field
And I Clicked the View Rates button
And I'm on the Shipment Results (LTL) page
When I click the Terms and Conditions link displayed next to the Show Insured Rate button
Then the updated Terms and Conditions associated to customers with the PPP insurance-all risk setting will be displayed in the <Terms And Conditions Of Coverage> modal
Examples: 
		| UserType | 		customer				  | ShipmentType       |
		| External | ZZZ - Czar Customer Test         | Rate To Shipment   |
		| External | ZZZ - Czar Customer Test         | Quote To Shipment  |
		| Internal | ZZZ - Czar Customer Test         | Direct Shipment    |
		| Internal | ZZZ - Czar Customer Test         | Copy Shipment	   |
		| Sales    | ZZZ - Czar Customer Test         | Return Shipment    |
		| Sales    | ZZZ - Czar Customer Test         | Edit Shipment      |

@90802 @Sprint91
Scenario Outline: C 90802 Verify the updated Terms and Conditions for the PPP Customers in the Shipment Results(LTL) page for the Shipment value entered in Shipment Results(LTL) page
Given I'm shp.entry, sales, sales management, operations, or stationowner <UserType> user
And I am associated to a customer with PPP/Non-Default insurance all risk setting<customer>
And I am on the Shipment Results (LTL) page<ShipmentType>,<UserType>
And I entered a value in the Enter insured value field of Shipment Results LTL page
And "Terms and Conditions" link was displayed next to the Show Insured Rate button
When I Click the Terms and Conditions link in the Shipment Results (LTL) page
Then the updated Terms and Conditions associated to customers with the PPP insurance-all risk setting will be displayed in the <Terms And Conditions Of Coverage> modal
Examples: 
		| UserType | 		customer				  | ShipmentType       |
		| External | ZZZ - Czar Customer Test         | Rate To Shipment   |
		| External | ZZZ - Czar Customer Test         | Quote To Shipment  |
		| Internal | ZZZ - Czar Customer Test         | Direct Shipment    |
		| Internal | ZZZ - Czar Customer Test         | Copy Shipment	   |
		| Sales    | ZZZ - Czar Customer Test         | Return Shipment    |
		| Sales    | ZZZ - Czar Customer Test         | Edit Shipment      |

@90802 @Sprint91
Scenario Outline: D 90802 Verify the updated Terms and Conditions for the PPP Customers upon clicking terms and conditions link embedded in the comment Statement from Shipment Results(LTL) page
Given I'm shp.entry, sales, sales management, operations, or stationowner <UserType> user
And I am associated to a customer with PPP/Non-Default insurance all risk setting<customer>
And I am on the Shipment Results (LTL) page<ShipmentType>,<UserType>
When I click terms and conditions link embedded in the comment Creating an insured shipment means you agree to the terms and conditions> displayed at the bottom of the page
Then the updated Terms and Conditions associated to customers with the PPP insurance-all risk setting will be displayed in the <Terms And Conditions Of Coverage> modal
Examples: 
		| UserType | 		customer				  | ShipmentType       |
		| External | ZZZ - Czar Customer Test         | Rate To Shipment   |
		| External | ZZZ - Czar Customer Test         | Quote To Shipment  |
		| Internal | ZZZ - Czar Customer Test         | Direct Shipment    |
		| Internal | ZZZ - Czar Customer Test         | Copy Shipment	   |
		| Sales    | ZZZ - Czar Customer Test         | Return Shipment    |
		| Sales    | ZZZ - Czar Customer Test         | Edit Shipment      |
