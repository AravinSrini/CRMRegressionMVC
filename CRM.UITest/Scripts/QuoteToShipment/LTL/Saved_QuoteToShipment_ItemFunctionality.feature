@SavedQuoteToShipment_ItemFunctionality @30528 @Sprint71 @API
Feature: Saved_QuoteToShipment_ItemFunctionality
	
@Functional @Regression
Scenario Outline:30528- Verify the hazardous material section is expanded when quote contained a Hardous material services and accessorials
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
    And I am in the Quote Details Section of a non expired LTL quote - '<UserType>','<CusName>'
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then The harzardous material section should be expanded when quote contained a Hardous material services and accessorials

Examples: 
| Username| Password | Usertype | CustName               |
| |  |          | ZZZ - GS Customer Test |

@Functional @Regression
Scenario Outline:30528- Verify the hazardous material section data is auto populated when quote contained a saved item
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
    And I am in the Quote Details Section of a non expired LTL quote - '<UserType>','<CusName>'
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then the Hazardous Materials section will be expanded when quote contained a saved item

Examples: 
| Username      | Password | UserType | CusName                |
|  |  |          | ZZZ - GS Customer Test |


@Functional @Regression
Scenario Outline:30528- Verify the additional item data is auto populated when quote contained a additional item
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
    And I am in the Quote Details Section of a non expired LTL quote which contains an additional item - <UserType>,<CustomerName>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then And the following fields in the additional item section will be auto-populated with the item info - Class,Quantity,QuantityType,Weight,HMaterials
	And The fields are not editable - <Class>,<Quantity>,<QuantityType>,<Weight>
	And I will not see the Remove button for the additional item
Examples: 
| Username | Password | UserType | CustomerName | NMFC | Description | WeightType | Length | Width | Height | DType |
|          |          |         | ZZZ - GS Customer Test | 3454 | CSDJ        | KILOS      | 3      | 3     | 2      | IN    |

@Functional @Regression
Scenario Outline:30528- Verify the hazardous material section data is auto populated in additional item information section when quote contained Hazardous Materials Services & Accessorial
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
    And I am in the Quote Details Section of a non expired LTL quote - '<UserType>','<CusName>'
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then The additional item section should be expanded 
	And Hazardous Material Yes Radio button will be checked with Hazardous material section auto populated 
Examples: 
| Username | Password | UserType | CusName |
|  |  |          | ZZZ - GS Customer Test |
