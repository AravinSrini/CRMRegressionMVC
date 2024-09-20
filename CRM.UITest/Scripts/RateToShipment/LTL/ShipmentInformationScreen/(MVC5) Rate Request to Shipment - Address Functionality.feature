@30500 @Sprint71 @(MVC5)RateRequesttoShipment-AddressFunctionality
Feature: (MVC5) Rate Request to Shipment - Address Functionality
	

@Functional
Scenario Outline: 30500 - Verify Shipping From & To dropdown Preselected in the Add Shipment(LTL) page 
	Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
	When I have selected any Origin and Destination address on the Quote Results (LTL) page<Usertype>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>
	And I clicked on Create Shipment button in Quote Results(LTL) page<Usertype>
	Then the saved address will be preselected on the Shipping From and To address dropdown in the Add Shipment(LTL) page 


	Examples: 
| Scenario | Username                  | Password | CustomerName           | oname | dname  | Item				| weight | Quantity | Insuredvalue | Usertype |
| s1       | salesmanager@stage.com	   | Te$t1234 | ZZZ - GS Customer Test | Day   | Amazon | Item12			| 1000   | 1        | 21           | Internal |
| s2       | zzzext@user.com           | Te$t1234 |ZZZ - Czar Customer Test| psa   | psa    | TEST-HAZARDOUS	| 2      | 2        | 21           | External |

@Functional
Scenario Outline: 30500 - Verify Shipping From & To dropdown Preselected for Insured Shipment in the Add Shipment(LTL) page
	Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
	When I have selected any Origin and Destination address on the Quote Results (LTL) page<Usertype>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>
	And I Clicked on create Insured Shipment button in Quote Results(LTL) page<Usertype>
		Then the saved address will be preselected on the Shipping From and To address dropdown in the Add Shipment(LTL) page 
	Examples: 
| Scenario | Username                  | Password | CustomerName           | oname | dname  | Item				| weight | Quantity | Insuredvalue | Usertype |
| s1       | salesmanager@stage.com	   | Te$t1234 | ZZZ - GS Customer Test | Day   | Amazon | Item12			| 1000   | 1        | 21           | Internal |
| s2       | zzzext@user.com           | Te$t1234 |ZZZ - Czar Customer Test| psa   | psa    | TEST-HAZARDOUS	| 2      | 2        | 21           | External |

@Functional
Scenario Outline: 30500 - Verify Shipping From & To Contact Info is autopopulated in the Add Shipment(LTL) page
Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
	When I have selected any Org and Dest.address with Contact Info on the Quote Results (LTL) page<Usertype>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>
	And I clicked on Create Shipment button in Quote Results(LTL) page<Usertype>
	Then the Shipping From and To contact Info will be autopopulated in the Add Shipment(LTL) page<oname>,<dname>,<CustomerName>
		
		Examples: 
| Scenario | Username                  | Password | CustomerName            | oname | dname  | Item				    | weight | Quantity | Insuredvalue | Usertype |
| s1       | salesmanager@stage.com	   | Te$t1234 | ZZZ - GS Customer Test  | Day   | Amazon | Item12				| 1000   | 1        | 21           | Internal |
| s2       | zzzext@user.com           | Te$t1234 | ZZZ - Czar Customer Test| psa   | psa    | TEST-HAZARDOUS		| 2      | 2        | 21           | External |

	@Functional
Scenario Outline: 30500 - Verify Shipping From & To Contact Info is autopopulated for Insured Shipment in the Add Shipment(LTL) page
Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
	When I have selected any Org and Dest.address with Contact Info on the Quote Results (LTL) page<Usertype>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>
	And I Clicked on create Insured Shipment button in Quote Results(LTL) page<Usertype>
	Then the Shipping From and To contact Info will be autopopulated in the Add Shipment(LTL) page<oname>,<dname>,<CustomerName>

		Examples: 
| Scenario | Username                  | Password | CustomerName            | oname | dname  | Item				    | weight | Quantity | Insuredvalue | Usertype |
| s1       | salesmanager@stage.com	   | Te$t1234 | ZZZ - GS Customer Test  | Day   | Amazon | Item12				| 1000   | 1        | 21           | Internal |
| s2       | zzzext@user.com           | Te$t1234 | ZZZ - Czar Customer Test| psa   | psa    | TEST-HAZARDOUS		| 2      | 2        | 21           | External |

