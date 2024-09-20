@Sprint88 @72717
Feature: RequiredShippingReference_AddShipment(LTL)page
	
	Scenario Outline:   A 72717 Verify Reference Number section expanded and the Reference designated for this customer will be a required field(s) in Add Shipment(LTL) page
	Given that I am a shp.entry or shp.entrynorates user<UserType>
	And I am associated to a <customer> with one or more required references
	And the required reference(s) was one or more of the primary references
	When I arrive <customer>to the Add Shipment (LTL) page<UserType> of <ShipmentType>
	Then the Reference Number section will be expanded
	And the reference(s) designated as required for this customer will be a required field(s)
	Examples: 
	| scenario | UserType | customer					| ShipmentType      |
	| s1       | External | ZZZ - CZAR Test Customer 2  | Direct Shipment   |
	| s2       | External |ZZZ - CZAR Test Customer 2	| Rate To Shipment  |
	| s3       | External |ZZZ - CZAR Test Customer 2	| Quote To Shipment |

	Scenario Outline: B 72717 Verify the presence of additional reference(s) for this customer and it's required in Add Shipment(LTL) page
	Given that I am a shp.entry or shp.entrynorates user<UserType>
	And I am associated to a <customer> with one or more required additional references
	When I arrive <customer>to the Add Shipment (LTL) page<UserType> of <ShipmentType>
	Then the Reference Number section will be expanded
	And the required additional reference(s) for this customer will be displayed in the section
	And the additional reference(s) designated as required for this customer will be a required field(s)
	And I'm unable to change the displayed required reference
	And I will not See the Remove button
	Examples: 
	| scenario | UserType	| 			customer				   | ShipmentType     |
	| s1       | External   |		ZZZ - CZAR Test Customer 2     | Direct Shipment  |
	| s2       | External   |	    ZZZ - CZAR Test Customer 2	   | Rate To Shipment |
	| s3       | External   |		ZZZ - CZAR Test Customer 2     |Quote To Shipment |

	Scenario Outline: C 72717 Verify the additional reference(s) designated for the customer will be a required field(s)
	Given I'm a sales, sales management, operations, or station owner user<UserType>
    And I selected a <customer> with one or more required references on the<UserType> Shipment List page<ShipmentType>
    And the required reference(s) was one or more of the primary references "PO Number,Order Number,GL Code,BOL Number,PRO Number,Pickup Number,Delivery Appt Number"
	When I arrive on the Add Shipment (LTL) page of <ShipmentType>
	Then the Reference Number section will be expanded
	And the reference(s) designated as required for this customer will be displayed in the section
	And the reference(s) designated as required for this customer will be a required field(s)
	Examples: 
	| scenario | UserType | 		customer				   |  ShipmentType      |
	| s1       | Internal |  ZZZ - CZAR Test Customer 2        | Direct Shipment    |
	| s2       | Internal | ZZZ - CZAR Test Customer 2         | Rate To Shipment   |
	| s3       | Internal | ZZZ - CZAR Test Customer 2         | Quote To Shipment  |
	| s4       | Internal | ZZZ - CZAR Test Customer 2         |  Edit Shipment	    |
	| s5       | Internal | ZZZ - CZAR Test Customer 2         | Copy Shipment      |
	| s6       | Internal |  ZZZ - CZAR Test Customer 2        | Return Shipment    |
	| s7       | Sales    | ZZZ - CZAR Test Customer 2         | Direct Shipment    |
	| s8       | Sales    | ZZZ - CZAR Test Customer 2         | Rate To Shipment   |
	| s9       | Sales    | ZZZ - CZAR Test Customer 2         | Quote To Shipment  |
	| s10      | Sales    | ZZZ - CZAR Test Customer 2         |  Edit Shipment	    |
	| s11      | Sales    |  ZZZ - CZAR Test Customer 2        | Copy Shipment      |
	| s12      | Sales    |  ZZZ - CZAR Test Customer 2        | Return Shipment    |

	Scenario Outline: D 72717 Verify the additional reference(s) designated for the customer will be a required field(s) and I will not see the Remove button for them in the Add Shipment (LTL) page
	Given I'm a sales, sales management, operations, or station owner user<UserType>
	And I selected a <customer> with one or more required references on the<UserType> Shipment List page<ShipmentType>
	And I am associated to a <customer> with one or more required additional references
	When I arrive on the Add Shipment (LTL) page of <ShipmentType>
	Then the Reference Number section will be expanded
	And the required additional reference(s) for the customer will be displayed in the section
	And the additional reference(s) designated as required for the customer will be a required field(s)
	And I'm unable to change the displayed required reference
	And I'm not able to see the <Remove> button
	Examples: 
	| scenario | UserType | 		customer				   |  ShipmentType      |
	| s1       | Internal |  ZZZ - CZAR Test Customer 2        | Direct Shipment    |
	| s2       | Internal |  ZZZ - CZAR Test Customer 2        | Rate To Shipment   |
	| s3       | Internal |  ZZZ - CZAR Test Customer 2        | Quote To Shipment  |
	| s4       | Internal |  ZZZ - CZAR Test Customer 2        |  Edit Shipment	    |
	| s5       | Internal |  ZZZ - CZAR Test Customer 2        | Copy Shipment      |
	| s6       | Internal |  ZZZ - CZAR Test Customer 2        | Return Shipment    |
	| s7       | Sales    |  ZZZ - CZAR Test Customer 2        | Direct Shipment    |
	| s8       | Sales    |  ZZZ - CZAR Test Customer 2        | Rate To Shipment   |
	| s9       | Sales    |  ZZZ - CZAR Test Customer 2        | Quote To Shipment  |
	| s10      | Sales    |  ZZZ - CZAR Test Customer 2        |  Edit Shipment	    |
	| s11      | Sales    |  ZZZ - CZAR Test Customer 2        | Copy Shipment      |
	| s12      | Sales    |  ZZZ - CZAR Test Customer 2        | Return Shipment    |

	Scenario Outline: E 72717 Verify User unable to navigate to Next Page upon not entering required reference Fields
	Given that I am a shp.entry shp.entrynorates, sales, sales management, operations, or station owner user<UserType>
	And I selected a <customer> with one or more required references on the<UserType> Shipment List page<ShipmentType> 
	And one or more references are required<customer>
	And I have not completed one or more required reference fields
	When I click the View Rates button
	Then the required reference field(s) will be highlighted
	And I'am unable to continue to the next page
	Examples: 
	| scenario | UserType | 	customer					   |  ShipmentType      |
	| s1       | External | ZZZ - CZAR Test Customer 2         | Direct Shipment    |
	| s2       | External | ZZZ - CZAR Test Customer 2         | Rate To Shipment   |
	| s3       | External | ZZZ - CZAR Test Customer 2         | Quote To Shipment  |
	| s4       | Internal | ZZZ - CZAR Test Customer 2         | Direct Shipment    |
	| s5       | Internal | ZZZ - CZAR Test Customer 2         | Rate To Shipment   |
	| s6       | Internal | ZZZ - CZAR Test Customer 2         | Quote To Shipment  |
	| s7       | Internal | ZZZ - CZAR Test Customer 2         |  Edit Shipment	    |
	| s8       | Internal | ZZZ - CZAR Test Customer 2         | Copy Shipment      |
	| s9       | Internal | ZZZ - CZAR Test Customer 2         | Return Shipment    |
	| s10      | Sales    | ZZZ - CZAR Test Customer 2         | Direct Shipment    |
	| s11      | Sales    | ZZZ - CZAR Test Customer 2         | Rate To Shipment   |
	| s12      | Sales    | ZZZ - CZAR Test Customer 2         | Quote To Shipment  |
	| s13      | Sales    | ZZZ - CZAR Test Customer 2         |  Edit Shipment	    |
	| s14      | Sales    | ZZZ - CZAR Test Customer 2         | Copy Shipment      |
	| s15      | Sales    | ZZZ - CZAR Test Customer 2         | Return Shipment    |


Scenario Outline: F 72717 Verify Reference field(s) section in Add Shipment(LTL) page for the Customer not mapped to Shipping Reference
	Given I'm shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
	And I am associated to a <customer> with no Shipping Reference
	When I arrive on <customer>Add Shipment (LTL) page<UserType> of Shipment <ShipmentType>
	Then the Primary reference(s) for this customer will not be a required field(s)
	And I will able to navigate to next page upon click on View Rates button
	Examples: 
	| scenario | UserType | 		customer				 | ShipmentType       |
	| s1       | External | ZZZ - Czar Customer Test         | Direct Shipment    |
	| s2       | External | ZZZ - Czar Customer Test         | Rate To Shipment   |
	| s3       | External | ZZZ - Czar Customer Test         | Quote To Shipment  |
	| s4       | Internal | ZZZ - Czar Customer Test         | Direct Shipment    |
	| s5       | Internal | ZZZ - Czar Customer Test         | Rate To Shipment   |
	| s6       | Internal | ZZZ - Czar Customer Test         | Quote To Shipment  |
	| s7       | Internal | ZZZ - Czar Customer Test         |  Edit Shipment	  |
	| s8       | Internal | ZZZ - Czar Customer Test         | Copy Shipment      |
	| s9       | Internal | ZZZ - Czar Customer Test         | Return Shipment    |
	| s10      | Sales    | ZZZ - Czar Customer Test         | Direct Shipment    |
	| s11      | Sales    | ZZZ - Czar Customer Test         | Rate To Shipment   |
	| s12      | Sales    | ZZZ - Czar Customer Test         | Quote To Shipment  |
	| s13      | Sales    | ZZZ - Czar Customer Test         |  Edit Shipment	  |
	| s14      | Sales    | ZZZ - Czar Customer Test         | Copy Shipment      |
	| s15      | Sales    | ZZZ - Czar Customer Test         | Return Shipment    |