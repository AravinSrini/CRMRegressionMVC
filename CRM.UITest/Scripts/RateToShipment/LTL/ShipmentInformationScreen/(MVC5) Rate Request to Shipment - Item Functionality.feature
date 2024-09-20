@30501 @Sprint71 @(MVC5)RateRequesttoShipment-ItemFunctionality
Feature: (MVC5) Rate Request to Shipment - Item Functionality

@Functional 
Scenario Outline: 30501 - Verify for the Hazmat values are auto populated in the Add Shipment(LTL) page
	Given I am a shp.entry, operations, sales, sales management, or station owner user
	When I have selected Saved Item with Hazmat on the Get Quote (LTL) page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<Date>
	And I clicked on Create Shipment button in Quote Results(LTL) page<Usertype>
	Then the Hazmat value will be autopopulated in the Add Shipment(LTL) page<CustomerName>,<Item>
	
		Examples: 
| CustomerName             | Accessorial | oname | dname | Item           | weight | Quantity | Insuredvalue | Usertype | Date |
| ZZZ - Czar Customer Test |             | Psa   | Psa   | TEST-HAZARDOUS |        |          | 21           | External | 1    |

@Functional 
Scenario Outline: 30501 - Verify for the Hazardous section are expanded in the Add Shipment(LTL) page
Given I am a shp.entry, operations, sales, sales management, or station owner user
	When I added service and accessorial as Hazmat on the Get Quote (LTL) page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<Date>
	And I clicked on Create Shipment button in Quote Results(LTL) page<Usertype>
	Then the Hazmat section will be expanded in the Add Shipment(LTL) page
		Examples: 
| CustomerName             | Accessorial        | oname | dname | Item  | weight | Quantity | Insuredvalue | Usertype | Date |
| ZZZ - Czar Customer Test | Hazardous Material | Psa   | Psa   | NoHaz |        |          | 21           | External | 1    |


@Functional 
Scenario Outline: 30501 - Verify for the Hazmat values for Insured Shipments are auto populated in the Add Shipment(LTL) page
Given I am a shp.entry, operations, sales, sales management, or station owner user
	When I have selected Saved Item with Hazmat on the Get Quote (LTL) page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<Date>
	And I Clicked on create Insured Shipment button in Quote Results(LTL) page<Usertype>
	Then the Hazmat value will be autopopulated in the Add Shipment(LTL) page<CustomerName>,<Item>
		Examples: 
| CustomerName             | Accessorial | oname | dname | Item           | weight | Quantity | Insuredvalue | Usertype | Date |
| ZZZ - Czar Customer Test |             | Psa   | Psa   | TEST-HAZARDOUS |        |          | 21           | External | 1    |

@Functional
Scenario Outline: 30501 - Verify for the Hazardous section are expanded for the Insure Shipment in the Add Shipment(LTL) page
Given I am a shp.entry, operations, sales, sales management, or station owner user
	When I added service and accessorial as Hazmat on the Get Quote (LTL) page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<Date>
	And I Clicked on create Insured Shipment button in Quote Results(LTL) page<Usertype>
	Then the Hazmat section will be expanded in the Add Shipment(LTL) page
		Examples: 
| CustomerName             | Accessorial        | oname | dname | Item  | weight | Quantity | Insuredvalue | Usertype | Date |
| ZZZ - Czar Customer Test | Hazardous Material | Psa   | Psa   | NoHaz |        |          | 21           | External | 1    |


@Functional	
Scenario Outline: 30501 - Verify the Additional Item with Hazmat values populated in Add Shipment(LTL) page
	Given I am a shp.entry, operations, sales, sales management, or station owner user
	When I have added additional Item with Hazmat on the Get Quote (LTL) page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<Item1>,<Date>
	And I clicked on Create Shipment button in Quote Results(LTL) page<Usertype>
	Then the Additional Item with Hazmat values are populated in the Additional Item section in Add Shipment(LTL) page<CustomerName>,<Item1>

	Examples: 
| CustomerName             | Accessorial | oname | dname | Item  | weight | Quantity | Insuredvalue | Usertype | Date | Item1          |
| ZZZ - Czar Customer Test |             | Psa   | Psa   | NoHaz |        |          | 21           | External | 1    | TEST-HAZARDOUS |


@Functional	
Scenario Outline: 30501 - Verify the Additional Item with Hazmat values populated in Add Shipment(LTL) page for Ins.Shipment
	Given I am a shp.entry, operations, sales, sales management, or station owner user
	When I have added additional Item with Hazmat on the Get Quote (LTL) page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<Item1>,<Date>
	And I Clicked on create Insured Shipment button in Quote Results(LTL) page<Usertype>
	Then the Additional Item with Hazmat values are populated in the Additional Item section in Add Shipment(LTL) page<CustomerName>,<Item1>

	Examples: 
| CustomerName             | Accessorial | oname | dname | Item  | weight | Quantity | Insuredvalue | Usertype | Date | Item1          |
| ZZZ - Czar Customer Test |             | Psa   | Psa   | NoHaz |        |          | 21           | External | 1    | TEST-HAZARDOUS |
