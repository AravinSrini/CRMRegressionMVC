@29135 @Sprint71 @API
Feature: Shipment List_Copy LTL OptionCopy Shipment Button_StationAndEntry Users

@Functional @Acceptance
Scenario Outline:29135-Verify data on Add Shipment (LTL) page on click of Copy Shipment button
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	And I am on the Shipment List page
	When I click on Copy Shipment button - <UserType>,<CustomerName>
	And I click on Copy Shipment confirmation button
    Then I will arrive on the Add Shipment (LTL) page
	And I will see the following fields auto-populated in ShipFrom section - Location name,Location address,Location address line 2,Zip/postal code,Country,City,State/province
	And I will see the following fields auto-populated in ShipTo section - Destination name,Destination address,Destination address line 2,Zip/postal code,Country,City,State/province
	And I will see PickUp date section auto-populated to default date and default time - PickUpDate,ReadyTime,CloseTime
	And I will see the following fields auto-populated in the Freight description section - Class,NMFC,Quantity,QuantityType,ItemDescription,Weight,WeightType,HMaterials,DLength,DWidth,DHeight,DType
	And I will see the following fields auto-populated in the Reference Number Section - DefaultSpecialInstruction,InsuredValue,InsuredValueType - '<CustomerName>'

Examples: 
| Scenario | Username      | Password | UserType | CustomerName           |
| S1       | Both@test.com | Te$t1234 |          | ZZZ - GS Customer Test |
| S2       | stationown    | Te$t1234 | Internal | ZZZ - GS Customer Test |

@Functional @Acceptance
Scenario Outline:29135-Verify freight description section of Add Shipment (LTL) page on click of Copy Shipment button when original shipment contains additional items
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	And I am on the Shipment List page
	When I click on Copy Shipment button - <UserType>,<CustomerName>
	And I click on Copy Shipment confirmation button
    Then I will arrive on the Add Shipment (LTL) page
	And I will see the following fields auto-populated for the Additional Items section - Class,NMFC,Quantity,QuantityType,ItemDescription,Weight,WeightType,HMaterials,DLength,DWidth,DHeight,DType

Examples: 
| Scenario | Username      | Password | UserType | CustomerName           |
| S1       | Both@test.com | Te$t1234 |          | ZZZ - GS Customer Test |
| S2       | stationown    | Te$t1234 | Internal | ZZZ - GS Customer Test |

@Functional @Acceptance
Scenario Outline:29135-Verify Station Name or Customer name associated to the original shipment is displayed on Copy Add Shipment (LTL) page
	Given I am a operations, sales, sales management, or station owner user - <Username>,<Password>
	And I am on the Shipment List page
	When I click on the Copy Shipment button - <StationCustomerName>
	And I arrive on the Add Shipment (LTL) page
	Then The station name - customer name associated to shipment selected will be displayed - <StationCustomerName>

Examples: 
| Scenario | Username              | Password | StationCustomerName      |
| S1       | crmOperation@user.com | Te$t1234 | ZZZ - Czar Customer Test |
| S2       | RefSales@crm.com      | Te$t1234 | All States Ag Parts - WI |
| S3       | stationown            | Te$t1234 | ZZZ - GS Customer Test   |

