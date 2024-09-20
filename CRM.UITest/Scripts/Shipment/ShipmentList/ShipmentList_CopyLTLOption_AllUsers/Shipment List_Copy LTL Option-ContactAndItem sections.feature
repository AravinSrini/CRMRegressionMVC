@31086 @Sprint71  @API
Feature: Shipment List_Copy LTL Option-ContactAndItem sections

@GUI
Scenario Outline:31086- Verify Contact information section on Copy Add Shipment (LTL) page when the original shipment does not have contact information
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	And I am on the Shipment List page
	And I click on Copy Shipment button - <Usertype>,<CustName>
	And I click on Copy Shipment confirmation button
	When I arrive on the Add Shipment (LTL) page
	Then The Shipping From Contact Info section will be collapsed, if shipment did not contain any Shipping From Contact Info
	And The Shipping To Contact Info section will be collapsed , if shipment did not contain any Shipping From Contact Info

Examples: 
| Scenario | Username      | Password | Usertype | CustName               |
| S1       | Both@test.com | Te$t1234 |          | ZZZ - GS Customer Test |
| S2       | stationown    | Te$t1234 | Internal | ZZZ - GS Customer Test |

@GUI @Functional @Acceptance
Scenario Outline:31086- Verify Contact information section on Copy Add Shipment (LTL) page when original shipment contains ShipFrom Contact information
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	And I am on the Shipment List page
	And I click on Copy Shipment button - <Usertype>,<CustName>	
	And I click on Copy Shipment confirmation button
	When I arrive on the Add Shipment (LTL) page
	Then The Shipping From Contact Info section will be expanded
	And All fields are auto populated with values from original shipment in ShipFrom Contact section 
	And All of the fields are editable - <FName>,<FPhoneNum>,<FEmail>,<FFax>

Examples: 
| Scenario | Username   | Password | Usertype | CustName                 | FName | FPhoneNum | FEmail         | FFax  |
| S1       | zzzext     | Te$t1234 |          | ZZZ - Czar Customer Test | dsa   | 6324868   | fhds@gmail.com | 65328 |
| S2       | stationown | Te$t1234 | Internal |  ZZZ - GS Customer Test  | dsa   | 6324868   | fhds@gmail.com | 65328 |


@GUI @Functional @Acceptance
Scenario Outline:31086- Verify Contact information section on Copy Add Shipment (LTL) page when original shipment contains ShipTo Contact information
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	And I am on the Shipment List page
	And I click on Copy Shipment button - <Usertype>,<CustName>
	And I click on Copy Shipment confirmation button
	When I arrive on the Add Shipment (LTL) page
	Then The Shipping To Contact Info section will be expanded
	And All fields are auto populated with values from original shipment in ShipTo contact section
	And All of the ShipTo contact Information fields are editable - <TName>,<TPhoneNum>,<TEmail>,<TFax>

Examples: 
| Scenario | Username      | Password | TName | TPhoneNum | TEmail         | TFax   | Usertype | CustName               |
| S1       | Both@test.com | Te$t1234 | FJD   | 73268     | FDSJ@gmail.com | 473223 |          | ZZZ - GS Customer Test |
| S2       | stationown    | Te$t1234 | FJD   | 73268     | FDSJ@gmail.com | 473223 | Internal | ZZZ - GS Customer Test |


@GUI @Functional @Acceptance
Scenario Outline:31086- Verify Hazardous materials section on Copy Add Shipment (LTL) page when original shipment contains Hazardous materials
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	And I am on the Shipment List page
	And I click on Copy Shipment button - <Usertype>,<CustName>
	And I click on Copy Shipment confirmation button
	When I arrive on the Add Shipment (LTL) page
	Then The Hazardous Materials section will be expanded, when original shipment contains Hazardous materials
	And All fields are auto populated with values from original shipment
	And The Hazardous Materials fields will be editable - <UNNum>,<CCN>,<HGroup>,<HClass>,<EName>,<EPhoneNum>

Examples: 
| Scenario | Username      | Password | UNNum | CCN  | HGroup | HClass | EName | EPhoneNum | Usertype | CustName               |
| S1       | Both@test.com | Te$t1234 | 1111  | 4673 | II     | 1.1    | fdsf  | 4327457   |          | ZZZ - GS Customer Test |
| S2       | stationown    | Te$t1234 | 1111  | 4673 | II     | 1.1    | fdsf  | 4327457   | Internal | ZZZ - GS Customer Test |


@GUI @Functional @Acceptance
Scenario Outline:31086- Verify Add Additional Item secion on Copy Add Shipment (LTL) page when original shipment contains Add Additional items
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	And I am on the Shipment List page
	And I click on Copy Shipment button - <Usertype>,<CustName>
	And I click on Copy Shipment confirmation button
	When I arrive on the Add Shipment (LTL) page
	Then The Additional Item section will be expanded in the Freight Description section, if the shipment contained additional items
	And I will see the Remove Item button
	And I am able to edit any information in Additional Item section - <Class>,<NMFC>,<Quantity>,<QuantityType>,<ItemDescription>,<Weight>,<WeightType>,<HMaterials>,<DLength>,<DWidth>,<DHeight>,<DType>

Examples: 
| Scenario | Username      | Password | Class | NMFC | Quantity | QuantityType | ItemDescription | Weight | WeightType | DLength | DWidth | DHeight | Type | Usertype | CustName               |
| S1       | Both@test.com | Te$t1234 | 50    | 4634 | 3        | Skids        | fsjdf           | 2      | LBS        | 2       | 2      | 1       | IN   |          | ZZZ - GS Customer Test |
| S2       | stationown    | Te$t1234 | 50    | 4634 | 3        | Skids        | fsjdf           | 2      | LBS        | 2       | 2      | 1       | IN   | Internal | ZZZ - GS Customer Test |


@GUI @Functional @Acceptance
Scenario Outline:31086- Verify Add Additional Item and Hazardous materials section on Copy Add Shipment (LTL) page when original shipment contains both sections
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	And I am on the Shipment List page
	And I click on Copy Shipment button - <Usertype>,<CustName>
	And I click on Copy Shipment confirmation button
	When I arrive on the Add Shipment (LTL) page
	Then The Additional Item section will be expanded in the Freight Description section, if the shipment contained additional items
	And The Hazardous Materials section of the additional item will be expanded, if the shipment contained additional hazmat 
	And The additional Hazardous Materials fields will be editable- <unNumb>, <ccnNumb>, <hazGroup>, <hazClass>, <hazName> and <hazPhone> 

Examples: 
| Scenario | Username   | Password | unNumb | ccnNumb | hazGroup | hazClass | hazName | hazPhone       | Usertype | CustName                 |
| S1       | zzzext     | Te$t1234 | 1111   | 1234567 | II       | 1.1      | C Name  | (111) 111-1111 |          | ZZZ - Czar Customer Test |
| S2       | stationown | Te$t1234 | 1111   | 1234567 | II       | 1.1      | C Name  | (111) 111-1111 | Internal | ZZZ - GS Customer Test   |


@GUI @Functional @Acceptance
Scenario Outline:31086- Verify Reference Number section on Copy Add Shipment (LTL) page when original shipment contains Reference numbers
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	And I am on the Shipment List page
	And I click on Copy Shipment button - <Usertype>,<CustName>
	And I click on Copy Shipment confirmation button
	When I arrive on the Add Shipment (LTL) page
	Then The Reference Numbers section will be expanded, if shipment contained reference numbers
	And The reference numbers from the previous shipment will be auto-populated in the corresponding reference number fields of the return shipment,
	And I must be able to Edit any of the Reference numbers- <Ref1>, <Ref2> 
	And I must be able to add additional reference numbers.


Examples: 
| Scenario | Username | Password | CustName                 | Usertype | Ref1   | Ref2   |
| S1       | zzzext   | Te$t1234 | ZZZ - Czar Customer Test |          | PO 123 | Gl 111 |