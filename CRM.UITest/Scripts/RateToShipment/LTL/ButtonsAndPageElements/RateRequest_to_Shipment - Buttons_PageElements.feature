@28056 @Sprint71 @RateRequest_to_Shipment-Buttons_PageElements
Feature: RateRequest_to_Shipment - Buttons_PageElements

@GUI
Scenario Outline: 28056 - Verify the presence of Create Shipment button
Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
	When I am on the Quote Results (LTL)page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<InsuredType>,<Date>
	Then I must be able to see Create Shipment button <Usertype>

	Examples: 
| Scenarios | Username               | Password | CustomerName             | Accessorial | oname | dname  | Item           | Weight | Quantity | Insuredvalue | Usertype | Date | InsuredType |
| s1        | salesmanager@stage.com | Te$t1234 | ZZZ - GS Customer Test   | Appointment | Day   | Amazon | Item12         |        |          | 21           | Internal | 1    | New         |
| s2        | ZZZext@user.com        | Te$t1234 | ZZZ - Czar Customer Test | Appointment | Psa   | Psa    | TEST-HAZARDOUS |        |          | 21           | External | 1    | New         |

@GUI
Scenario Outline: 28056 - Verify the presence of Create Insured Shipment button
Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
	When I am on the Quote Results (LTL)page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<InsuredType>,<Date>
	Then I must be able to see Create Insured Shipment button <Usertype>

	Examples: 
| Scenarios | Username               | Password | CustomerName             | Accessorial | oname | dname  | Item           | Weight | Quantity | Insuredvalue | Usertype | Date | InsuredType |
| s1        | salesmanager@stage.com | Te$t1234 | ZZZ - GS Customer Test   | Appointment | Day   | Amazon | Item12         |        |          | 21           | Internal | 1    | New         |
| s2        | ZZZext@user.com        | Te$t1234 | ZZZ - Czar Customer Test | Appointment | Psa   | Psa    | TEST-HAZARDOUS |        |          | 21           | External | 1    | New         |

@Functional
Scenario Outline: 28056 - Verify the Address,PickUp date,Item,Reference number data Auto-populated in Rate to Shipment(LTL)
   Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
    When I am on the Quote Results (LTL)page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<InsuredType>,<Date>
	And I clicked on Create Shipment button in Quote Results(LTL) page<Usertype>
	Then the Shipping From and To Address will be populated in the Add Shipment(LTL) page<oname>,<dname>,<CustomerName>
	And the PickUp date selected from the Quote will be populated
	And the Item Information selected from the Quote will be populated<CustomerName>,<Item>
	And the Insured value from the Quote will be populated<Insuredvalue>,<InsuredType>
	And the Station and Customer Name selected from the Quote will be populated for Internal User<Usertype>

	Examples: 
| Scenarios | Username               | Password | CustomerName             | Accessorial | oname | dname  | Item           | Weight | Quantity | Insuredvalue | Usertype | Date | InsuredType |
| s1        | salesmanager@stage.com | Te$t1234 | ZZZ - GS Customer Test   | Appointment | Day   | Amazon | Item12         |        |          | 21           | Internal | 1    | New         |
| s2        | ZZZext@user.com        | Te$t1234 | ZZZ - Czar Customer Test | Appointment | Psa   | Psa    | TEST-HAZARDOUS |        |          | 21           | External | 1    | New         |


@Functional
Scenario Outline: 28056 - Verify the Address,PickUp date,Item,Reference number data Auto-populated in Rate to Ins.Shipment(LTL)
   Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
    When I am on the Quote Results (LTL)page<Usertype>,<Accessorial>,<CustomerName>,<oname>,<dname>,<Item>,<weight>,<Quantity>,<Insuredvalue>,<InsuredType>,<Date>
	And I Clicked on create Insured Shipment button in Quote Results(LTL) page<Usertype>
	Then the Shipping From and To Address will be populated in the Add Shipment(LTL) page<oname>,<dname>,<CustomerName>
	And the PickUp date selected from the Quote will be populated
	And the Item Information selected from the Quote will be populated<CustomerName>,<Item>
	And the Insured value from the Quote will be populated<Insuredvalue>,<InsuredType>
	And the Station and Customer Name selected from the Quote will be populated for Internal User<Usertype>

	Examples: 
| Scenarios | Username               | Password | CustomerName             | Accessorial | oname | dname  | Item           | Weight | Quantity | Insuredvalue | Usertype | Date | InsuredType |
| s1        | salesmanager@stage.com | Te$t1234 | ZZZ - GS Customer Test   | Appointment | Day   | Amazon | Item12         |        |          | 21           | Internal | 1    | New         |
| s2        | ZZZext@user.com        | Te$t1234 | ZZZ - Czar Customer Test | Appointment | Psa   | Psa    | TEST-HAZARDOUS |        |          | 21           | External | 1    | New         |



