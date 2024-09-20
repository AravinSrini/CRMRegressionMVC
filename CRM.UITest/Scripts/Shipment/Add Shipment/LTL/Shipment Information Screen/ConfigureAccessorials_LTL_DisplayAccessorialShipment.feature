@Sprint88 @48278
Feature: ConfigureAccessorials_LTL_DisplayAccessorialShipment
	
	Scenario Outline: One 48278 Verify accessorial under accessorial drop down list in the Shipping From section on the Add Shipment (LTL) page when designated to be applied in the Shipping From section
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was designated to be applied to "LTL" Service types
	And the accessorial was designated to be applied in "Ship From" section
	And I on the Add Shipment (LTL) page of <ShipmentType>
	When I click the Click to add services & accessorials field in the "Ship From" section
	Then I will see the accessorial displayed  in the "Ship From" drop down list
	Examples: 
	 | Secnario | Usertype | ShipmentType     |
	 | s1       | External | Direct Shipment  |
	 | s2       | External | Rate To Shipment |
	 | s3       | Internal | Direct Shipment  |
	 | s4       | Internal | Rate To Shipment |
	 | s5       | Internal | Edit Shipment    |
	 | s6       | Internal | Copy Shipment    |
	 | s7       | Internal | Return Shipment  |
	 | s8       | Sales    | Direct Shipment  |
	 | s9       | Sales    | Rate To Shipment |
	 | S10      | Sales    | Edit Shipment    |
	 | s11      | Sales    | Copy Shipment    |
	 | s12      | Sales    | Return Shipment  |
	 
	

	Scenario Outline: Two 48278 Verify accessorial under accessorial drop down list in the Shipping To section on the Add Shipment (LTL) page when designated to be applied in the Shipping To section
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was designated to be applied to "LTL" Service types
	And the accessorial was designated to be applied in "Ship To" section
	And I on the Add Shipment (LTL) page of <ShipmentType>
	When I click the Click to add services & accessorials field in the "Ship To" section
	Then I will see the accessorial displayed  in the "Ship To" drop down list
	Examples: 
	| Secnario | Usertype | ShipmentType     |
	| s1       | External | Direct Shipment  |
	| s2       | External | Rate To Shipment |
	| s3       | Internal | Direct Shipment  |
	| s4       | Internal | Rate To Shipment |
	| s5       | Internal | Edit Shipment    |
	| s6       | Internal | Copy Shipment    |
	| s7       | Internal | Return Shipment  |
	| s8       | Sales    | Direct Shipment  |
	| s9       | Sales    | Rate To Shipment |
	| s10      | Sales    | Edit Shipment    |
	| s11      | Sales    | Copy Shipment    |
	| s12      | Sales    | Return Shipment  |
	 
	Scenario Outline: Three 48278 Verify absence of accessorial in the Shipping To section on the Add Shipment (LTL) page when designated to be applied in the Shipping From section
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was designated to be applied to "LTL" Service types
	And the accessorial was designated to be applied in "Ship From" section
	And I on the Add Shipment (LTL) page of <ShipmentType>
	When I click the Click to add services & accessorials field in the "Ship To" section
	Then I will not see the accessorial displayed in the "Ship To" drop down list
	Examples: 
	| Scenario | Usertype | ShipmentType     |
	| s1       | External | Direct Shipment  |
	| s2       | External | Rate To Shipment |
	| s3       | Internal | Direct Shipment  |
	| s4       | Internal | Rate To Shipment |
	| s5       | Internal | Edit Shipment    |
	| s6       | Internal | Copy Shipment    |
	| s7       | Internal | Return Shipment  |
	| s8       | Sales    | Direct Shipment  |
	| s9       | Sales    | Rate To Shipment |
	| s10      | Sales    | Edit Shipment    |
	| s11      | Sales    | Copy Shipment    |
	| s12      | Sales    | Return Shipment  |
	 
	Scenario Outline: Four 48278 Verify absence of accessorial in the Shipping From section on the Add Shipment (LTL) page when designated to be applied in the Shipping To section
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was designated to be applied to "LTL" Service types
	And the accessorial was designated to be applied in "Ship To" section
	And I on the Add Shipment (LTL) page of <ShipmentType>
	When I click the Click to add services & accessorials field in the "Ship From" section
	Then I will not see the accessorial displayed in the "Ship From" drop down list
	Examples: 
	| secanrio | Usertype | ShipmentType     |
	| s1       | External | Direct Shipment  |
	| s2       | External | Rate To Shipment |
	| s3       | Internal | Direct Shipment  |
	| s4       | Internal | Rate To Shipment |
	| s5       | Internal | Edit Shipment    |
	| s6       | Internal | Copy Shipment    |
	| s7       | Internal | Return Shipment  |
	| s8       | Sales    | Direct Shipment  |
	| s9       | Sales    | Rate To Shipment |
	| s10      | Sales    | Edit Shipment    |
	| s11      | Sales    | Copy Shipment    |
	| s12      | Sales    | Return Shipment  |
	 
	Scenario Outline: Five 48278 Verify accessorial under accessorial drop down list on the Add Shipment (LTL) page when accessorial was designated to be applied in Both
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was designated to be applied to "LTL" Service types
	And the accessorial was designated to be applied in "Both" section
	And I on the Add Shipment (LTL) page of <ShipmentType>
	When I click the Click to add services & accessorials field in the "Both" section
	Then I will see the accessorial displayed  in the "Both" drop down list
	Examples: 
	| Scenario | Usertype | ShipmentType     |
	| s1       | External | Direct Shipment  |
	| s2       | External | Rate To Shipment |
	| s3       | Internal | Direct Shipment  |
	| s4       | Internal | Rate To Shipment |
	| s5       | Internal | Edit Shipment    |
	| s6       | Internal | Copy Shipment    |
	| s7       | Internal | Return Shipment  |
	| s8       | Sales    | Direct Shipment  |
	| s9       | Sales    | Rate To Shipment |
	| s10      | Sales    | Edit Shipment    |
	| s11      | Sales    | Copy Shipment    |
	| s12      | Sales    | Return Shipment  |
	 
	 Scenario Outline: Six  Verify accessorial under accessorial drop down list on the Add Shipment (LTL) page when accessorial was designated to be applied as None
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was designated to be applied to "LTL" Service types
	And the accessorial was designated to be applied in "None" section
	And I on the Add Shipment (LTL) page of <ShipmentType>
	When I click the Click to add services & accessorials field in the "Both" section
	Then I will not see the accessorial in the "Both" drop down list
	Examples: 
	
	| Secnario | Usertype | ShipmentType     |
	| s1       | External | Direct Shipment  |
	| s2       | External | Rate To Shipment |
	| s3       | Internal | Direct Shipment  |
	| s4       | Internal | Rate To Shipment |
	| s5       | Internal | Edit Shipment    |
	| s6       | Internal | Copy Shipment    |
	| s7       | Internal | Return Shipment  |
	| s8       | Sales    | Direct Shipment  |
	| s9       | Sales    | Rate To Shipment |
	| s10      | Sales    | Edit Shipment    |
	| s11      | Sales    | Copy Shipment    |
	| s12      | Sales    | Return Shipment  |
	 


	Scenario Outline: Seven 48278 Verify CRM will send new Service Code to MG when I selected the accessorial which created on the Configure Accessorial Page
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was designated to be applied to "LTL" Service types
	And I on Add Shipment (LTL) page of <ShipmentType>
	When I click on the View Rates button on the Add Shipment (LTL) page
	Then CRM will send the New Service Code
	Examples: 
	| scenario | Usertype | ShipmentType      |
	| s1       | External | Direct Shipment   |
	| s2       | External | Rate To Shipment  |
	| s3       | External | Quote To Shipment |
	| s4       | Internal | Direct Shipment   |
	| s5       | Internal | Rate To Shipment  |
	| s6       | Internal | Quote To Shipment |
	| s7       | Internal | Edit Shipment     |
	| s8       | Internal | Copy Shipment     |
	| s9       | Internal | Return Shipment   |
	| s10      | Sales    | Direct Shipment   |
	| s11      | Sales    | Rate To Shipment  |
	| s12      | Sales    | Quote To Shipment |
	| s13      | Sales    | Edit Shipment     |
	| s14      | Sales    | Copy Shipment     |
	| s15      | Sales    | Return Shipment   |
	 

	Scenario Outline: Eight 48278 Verify accessorial under accessorial drop down list in the Shipping From section on the Add Shipment (LTL) page when designated not to applied in the LTL Shipping From section
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was not designated LTL Service types
	And the accessorial was designated to Non LTL "Ship From" section
	And I on the Add Shipment (LTL) page of <ShipmentType>
	When I click the Click to add services & accessorials field in the "Ship From" section
	Then I will not see the accessorial in the "Ship From" drop down list
	Examples: 
	 | scenario | Usertype | ShipmentType     |
	 | s1       | External | Direct Shipment  |
	 | s2       | External | Rate To Shipment |
	 | s3       | Internal | Direct Shipment  |
	 | s4       | Internal | Rate To Shipment |
	 | s5       | Internal | Edit Shipment    |
	 | s6       | Internal | Copy Shipment    |
	 | s7       | Internal | Return Shipment  |
	 | s8       | Sales    | Direct Shipment  |
	 | s9       | Sales    | Rate To Shipment |
	 | s10      | Sales    | Edit Shipment    |
	 | s11      | Sales    | Copy Shipment    |
	 |s12	    | Sales	|Return Shipment   |

	
	Scenario Outline: Nine 48278 Verify accessorial under accessorial drop down list in the Shipping To section on the Add Shipment (LTL) page when designated not to applied in LTL Shipping To section
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was not designated LTL Service types
	And the accessorial was designated to Non LTL "Ship To" section
	And I on the Add Shipment (LTL) page of <ShipmentType>
	When I click the Click to add services & accessorials field in the "Ship To" section
	Then I will not see the accessorial in the "Ship To" drop down list
	Examples: 
 | Scenario | Usertype | ShipmentType     |
 | s1       | External | Direct Shipment  |
 | s2       | External | Rate To Shipment |
 | s3       | Internal | Direct Shipment  |
 | s4       | Internal | Rate To Shipment |
 | s5       | Internal | Edit Shipment    |
 | s6       | Internal | Copy Shipment    |
 | s7       | Internal | Return Shipment  |
 | s8       | Sales    | Direct Shipment  |
 | s9       | Sales    | Rate To Shipment |
 | s10      | Sales    | Edit Shipment    |
 | s11      | Sales    | Copy Shipment    |
 | s12      | Sales    | Return Shipment  |
 
	 Scenario Outline: Ten 48278 Verify accessorial under accessorial drop down list on the Add Shipment (LTL) page when designated not to be applied in LTL Both
	Given I am a user with Access to Add Shipment(LTL) page <Usertype>
	And An accessorial was added on the Configure Accessorials page
	And the accessorial was not designated LTL Service types
	And the accessorial was designated to Non LTL "Both" section
	And I on the Add Shipment (LTL) page of <ShipmentType>
	When I click the Click to add services & accessorials field in the "Both" section
	Then I will not see the accessorial in the "Both" drop down list
	Examples: 
	
	 | scenario | Usertype | ShipmentType     |
	 | s1       | External | Direct Shipment  |
	 | s2       | External | Rate To Shipment |
	 | s3       | Internal | Direct Shipment  |
	 | s4       | Internal | Rate To Shipment |
	 | s5       | Internal | Edit Shipment    |
	 | s6       | Internal | Copy Shipment    |
	 | s7       | Internal | Return Shipment  |
	 | s8       | Sales    | Direct Shipment  |
	 | s9       | Sales    | Rate To Shipment |
	 | s10      | Sales    | Edit Shipment    |
	 | s11      | Sales    | Copy Shipment    |
	 | s12      | Sales    | Return Shipment  |
	 
