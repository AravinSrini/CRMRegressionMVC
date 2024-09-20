@AddShipments_PageElements @Sprint69 @27401  

Feature: AddShipment_LTL_PageElements
	

@GUI
Scenario Outline:  Verify the all fields on the Add Shipment LTL address section for Operations, Sales, Sales management, Station Owner, ShipEntry and ShipEntryNoRates users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I Arrive on Add Shipment Ltl page
	Then I can see the Message for the Required fields <RequiredFieldsMsg>
	Then I can see the Shipping From section <ShipFrom_SectionText> with all fields below
	And I can see the Shipping From Select or search saved origin address drop down
	And I can see the Shipping From Clear Address option
	And I can see the Shipping From Location name, 
	And I can see Shipping From Address Firstline
	And I can see Shipping From Address Secondline
	And I can see Shipping From Zipcode
	And I can see Shipping From Country drop down and defaulted to United States
	And I can see the Shipping From City text box
	And I can see Shipping From State/Province drop down
	And I can see Shipping From Sevices and Accessorials drop down
	And I can see Shipping From Comments text box
	And I can see the Shipping From Save Origin Information Checkbox
	And I can see the Shipping From View Origin Location on Map link
	And I can see the Shipping To section <ShipTo_SectionText> with all fields below
	And I can see the Shipping To Select or search saved origin address drop down
	And I can see the Shipping To Clear Address option
	And I can see the Shipping To Location name, 
	And I can see Shipping To Address Firstline
	And I can see Shipping To Address Secondline 
	And I can see Shipping To Zipcode
	And I can see Shipping To Country drop down and defaulted to United States
	And I can see the Shipping To City text box
	And I can see Shipping To State/Province drop down
	And I can see Shipping To Sevices and Accessorials drop down
	And I can see Shipping To Comments text box
	And I can see the Shipping To Save Dest Information Checkbox
	And I can see the Shipping To View Dest Location on Map link	

Examples: 
	| Scenario | Username  | Password | RequiredFieldsMsg                      | ShipFrom_SectionText | ShipTo_SectionText | UserType  | CustomerAccName |
	| S1       | shp.entry | Te$t1234 | Fields outlined in orange are required | Shipping From        | Shipping To        | ShipEntry |                 |
	



@GUI
Scenario Outline:  Verify all the fields on Add Shipment LTL Contact Info section and PickUp Date for Operations, Sales, Sales management, Station Owner, ShipEntry and ShipEntryNoRates users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I Arrive on Add Shipment Ltl page
	And I Expand the Shiping From Contact Info section <ShippingFromContactInfo>
	Then I can see the Shipping From Contact name
	And I can see the Shipping From Contact Email
	And I can see the Shipping From Contact Phone
	And I can see the Shipping From Contact Fax 
	And I Expand the Shiping To Contact Info section <ShippingToContactInfo>
	And I can see the Shipping To Contact name
	And I can see the Shipping To Contact Email
	And I can see the Shipping To Contact Phone
	And I can see the Shipping To Contact Fax 
	And I can see the Pick Up date with Caleder Icon
	And I can see the PickUp Date Ready Time default value
	And I can see the Pick Up Date Close Time default value
Examples: 
	| Scenario | Username  | Password  | ShippingFromContactInfo    | ShippingToContactInfo      | UserType                 | CustomerAccName |
	| S1       | shp.entry | Te$t1234  | Shipping From Contact Info | Shipping To Contact Info   | ShipEntry                |                 |
	

@GUI
Scenario Outline:  Verify all the fields on Add Shipment LTL Freight Description for  Operations, Sales, Sales management, Station Owner, ShipEntry and ShipEntryNoRates users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I Arrived on Add Shipment Ltl page	
	Then I can see the Freight Description Section with header <FreightDescriptionHeaderText>
	And I can see the Select or search saved items or class drop down
	And I can see the NMFC text box
	And I can see the Item Description	
	And I can see the Quantity text box with Quantity type defaulted to <DefaultQtyType>
	And I can see the Weight text box with Weight type defaulted to <DefaultWeightType>
	And I can see the Dimension values with Dimention type
	And I can see the Estimate Class button
	And I can see the Clear Item link
	And I can see the Hazardous material section depending on Hazardous selection <Haz_Value>
	And I can see the Add Additional Item button	
Examples: 
	| Scenario | Username     | Password | FreightDescriptionHeaderText | DefaultQtyType | DefaultWeightType | Haz_Value | UserType  | CustomerAccName |
	| S1       | shp.entry    | Te$t1234 | Freight Description          | Skids          | LBS               | Yes       | ShipEntry |                 |
	| S2       | crmOperation | Te$t1234 | Freight Description          | Skids          | LBS               | No        | Operation | Dunkin Donuts   |

	
@GUI
Scenario Outline:  Verify all the fields on Add Shipment LTL Reference Numbers section for  Operations, Sales, Sales management, Station Owner, ShipEntry and ShipEntryNoRates users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I Arrive on Add Shipment Ltl page	
	Then I can see the Reference Numbers Section with header <ReferenceNumbers>
	And I expand the Reference Numbers Section
	And I can see the PO_Number, OrderNumber, GL_Code, BOL_Number, PRO_Number, PickUpNumber, DeliveryApptNumber
	And I can see the AddAdditionalReferenceButton

Examples: 
	| Scenario | Username  | Password | UserType  | ReferenceNumbers  | CustomerAccName |
	| S1       | shp.entry | Te$t1234 | ShipEntry | Reference Numbers |                 |
	
	

@GUI
Scenario Outline:  Verify all the fields on Add Shipment LTL Default Special Instructions and Insured Value section for  Operations, Sales, Sales management, Station Owner, ShipEntry and ShipEntryNoRates users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I Arrive on Add Shipment Ltl page	
	Then I can see the Default Special Instructions <DefaultSpecilaIntsructionsText>
	And I can see the Default Special Instruction Comments text box
	And I can Insured Value Text <InsuredValue_Text>, InsuredValue_TextBox , InsuredValue_Type default value, Insured Value ToolTip <InsuredValue_ToolTip>
	And I can see View Rates Button in Add Shipment LTL page
	And I can see Back To Shipment List Button
	

Examples: 
	| Scenario | Username  | Password | UserType  | DefaultSpecilaIntsructionsText | InsuredValue_Text | InsuredValue_ToolTip                                                                                                        | CustomerAccName |
	| S1       | shp.entry | Te$t1234 | ShipEntry | Special Instructions           | Insured Value     | Normal method to determine insured value: Invoice Cost, Plus Insurance Cost, Plus Any Prepaid Freight Charges, All Plus 10% |                 |
	

@GUI @Functional
Scenario Outline:  Verify the required fields functionality on the Add Shipment LTL page for Operations, Sales, Sales management, Station Owner, ShipEntry and ShipEntryNoRates users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I Arrive on Add Shipment Ltl page	
	Then all the Required fields should be highlighted in Orange Colour

	Examples: 
	| Scenario | Username  | Password | UserType  | CustomerAccName |
	#| S1       | shp.entry | Te$t1234 | ShipEntry |                 |
	| S2       | crmOperation | Te$t1234 | Operation | Dunkin Donuts|

@GUI @Sprint71 @32860 @Sprint75 @33969
Scenario Outline:  Verify the tab order functionality on the Add Shipment LTL page for for Operations, Sales, Sales management, Station Owner, ShipEntry and ShipEntryNoRates users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I click on the Shipment Module
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerName>	
	And I Select the LTL tile
	And I Arrived on Add Shipment Ltl page
	Then verify the tab Order for the mandatory fields for the Add Shipment LTL page

	Examples: 
	| Scenario | Username   | Password | UserType		| CustomerName           |
	| S1       | shp.entry  | Te$t1234 | ShipEntry		| ZZZ - GS Customer Test |
	| S2       | stationown | Te$t1234 | StationOwner	| ZZZ - GS Customer Test |










