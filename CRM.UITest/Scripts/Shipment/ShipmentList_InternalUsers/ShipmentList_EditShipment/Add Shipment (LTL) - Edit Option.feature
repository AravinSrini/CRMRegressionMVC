@Sprint74 @35284

Feature: Add Shipment (LTL) - Edit Option

@Functionality @GUI
Scenario Outline: 35284-Verify Add Shipment (LTL) page on click on Edit Shipment button -Edit Shipment
Given I am operations, sales, sales management, or station owner user associated to Active Customer Account<Username>,<Password>
And I am on the Shipment List page
When  I click on the Edit button for any eligible LTL shipment <UserType>,<CustomerName>
Then  I will arrive on the Add Shipment (LTL) page

Examples: 
| Scenario | Username      | Password | UserType | CustomerName           |
| S1       | stationown    | Te$t1234 | Internal | ZZZ - GS Customer Test |


@Functionality	
Scenario Outline: 35284-Verify data on Add Shipment (LTL) page on click of Edit Shipment button -Edit Shipment
Given I am operations, sales, sales management, or station owner user associated to Active Customer Account<Username>,<Password>
And I am on the Shipment List page
When  I click on the Edit button for any eligible LTL shipment <UserType>,<CustomerName>
Then  I will arrive on the Add Shipment (LTL) page
And I will see the following fields auto-populated in ShipFrom section - Location name,Location address,Location address line 2,Zip/postal code,Country,City,State/province
And I will see the following fields auto-populated in ShipTo section - Destination name,Destination address,Destination address line 2,Zip/postal code,Country,City,State/province
And I will see the following fields auto-populated in the Freight description section - Class,NMFC,Quantity,QuantityType,ItemDescription,Weight,WeightType,HMaterials,DLength,DWidth,DHeight,DType
And I will see the following fields auto-populated in the Reference Number Section - DefaultSpecialInstruction,InsuredValue,InsuredValueType - '<CustomerName>'
Examples: 
| Scenario | Username      | Password | UserType | CustomerName           |
| S1       | stationown    | Te$t1234 | Internal | ZZZ - GS Customer Test |


@Functionality
Scenario Outline: 35284-Verify freight description section of Add Shipment (LTL) page on click of EEdit Shipment button when original shipment contains additional items -Edit Shipment
Given I am operations, sales, sales management, or station owner user associated to Active Customer Account<Username>,<Password>
And I am on the Shipment List page
When  I click on the Edit button for any eligible LTL shipment <UserType>,<CustomerName>
Then I will arrive on the Add Shipment (LTL) page
And I will see the following fields auto-populated for the Additional Items section - Class,NMFC,Quantity,QuantityType,ItemDescription,Weight,WeightType,HMaterials,DLength,DWidth,DHeight,DType
Examples: 
| Scenario | Username      | Password | UserType | CustomerName           |
| S1       | stationown    | Te$t1234 | Internal | ZZZ - GS Customer Test |


@GUI
Scenario Outline: 35284-Verify Station Name or Customer name associated to the original shipment is displayed on Edit Add Shipment (LTL) page -Edit Shipment
Given I am operations, sales, sales management, or station owner user associated to Active Customer Account<Username>,<Password>
And I am on the Shipment List page
When Click on the Edit button for any eligible LTL shipment <StationCustomerName>
Then  I will arrive on the Add Shipment (LTL) page
Then The station name - customer name associated to shipment selected will be displayed - <StationCustomerName>
Examples: 
| Scenario | Username              | Password | StationCustomerName      |
| S1       | stationown            | Te$t1234 | ZZZ - GS Customer Test   |



@GUI
Scenario Outline:35284- Verify Contact information section on Edit Add Shipment (LTL) page when the original shipment does not have contact information -Edit Shipment
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	And I am on the Shipment List page
	When  I click on the Edit button for any eligible LTL shipment <UserType>,<CustomerName>
	Then  I will arrive on the Add Shipment (LTL) page
	Then  Shipping From Contact Info section will be collapsed, if shipment did not contain any Shipping From Contact Info
	And   Shipping To Contact Info section will be collapsed , if shipment did not contain any Shipping From Contact Info
	
Examples: 
| Scenario | Username      | Password | UserType | CustomerName           |
| S1       | stationown    | Te$t1234 | Internal | ZZZ - GS Customer Test |


@GUI @Functional @Acceptance
Scenario Outline:35284- Verify Contact information section on Edit Add Shipment (LTL) page when original shipment contains ShipFrom Contact information -Edit Shipment
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or station user- '<Username>','<Password>'
	And I am on the Shipment List page
	When  I click on the Edit button for any eligible LTL shipment <UserType>,<CustomerName>
	And I arrive on the Add Shipment (LTL) page
	Then Shipping From Contact Info section will be expanded
	And fields are auto populated with values from original shipment in ShipFrom Contact section 
	

Examples: 
| Scenario | Username   | Password | UserType | CustomerName             | FName | FPhoneNum | FEmail         | FFax       |
| S1       | stationown | Te$t1234 | Internal |  ZZZ - GS Customer Test  | dsa   | 6324868   | fhds@gmail.com | 6532845454 |



@GUI @Functional
Scenario Outline: 35284-Verify all the fields on the Add Shipment (LTL) page are editable -Edit Shipment
Given I am operations, sales, sales management, or station owner user associated to Active Customer Account<Username>,<Password>
And I am on the Shipment List page
When  I click on the Edit button for any eligible LTL shipment <UserType>,<CustomerName>
Then  I will arrive on the Add Shipment (LTL) page
And all of the fields are editable

Examples: 
| Scenario | Username     | Password | CustomerName             | UserType |
| s1       | stationown | Te$t1234   | ZZZ - GS Customer Test   | Internal |

@GUI @Functional
Scenario Outline: 35284-Verify the Shipment Results (LTL) page and Create Shipment option on Shipment results (LTL) page - Edit Shipment
Given I am operations, sales, sales management, or station owner user associated to Active Customer Account<Username>,<Password>
And I am on the Shipment List page
When  I click on the Edit button for any eligible LTL shipment <UserType>,<CustomerName>
And I clicked on the View Rates button on the Add Shipment (LTL) page
Then I arrive on the Shipment Results (LTL) page
And I have the option to select a displayed carrier<UserType>
Examples: 
| Scenario | Username     | Password | CustomerName             | UserType |
| s1       | stationown | Te$t1234   | ZZZ - GS Customer Test   | Internal |




@GUI @Functional
Scenario Outline: 35284-Verify the Create Shipment functionality -Edit Shipment
Given I am operations, sales, sales management, or station owner user associated to Active Customer Account<Username>,<Password>
And I am on the Shipment List page
When I click on the Edit button for any eligible LTL shipment <UserType>,<CustomerName>
And I clicked on the View Rates button on the Add Shipment (LTL) page
Then I have the option to select a displayed carrier<UserType>
And I arrive on review and submit page and click on submit button<UserType>
And I arrive on Shipment Confirmation page 
Examples: 
| Scenario | Username     | Password | CustomerName             | UserType |
| s1       | stationown | Te$t1234   | ZZZ - GS Customer Test   | Internal |
