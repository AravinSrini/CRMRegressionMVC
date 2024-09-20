@Sprint71 @31797 
Feature: Add Shipment (LTL) (MVC5) - Freight Description - Display Text Water Mark Fields

@GUI 
Scenario Outline: 31797_Test to verify Display Text Water Mark Fields_default item contains a zero or null_defaultitem
    Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station user <Username> <Password>
	When I am on  Add Shipment (LTL) page in shipment process '<UserType>','<CustomerName>'
	Then item fields should display the text water marks which defaultitem contains nullorzero values

	
Examples: 
| Scenario | Username              | Password | UserType | CustomerName             | searchedval |
| 1        | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test |             |
| 2        | zzzext@user.com       | Te$t1234 | External |                          |             |

@GUI 
Scenario Outline: 31797_Test to verify Display Text Water Mark Fields_default item contains a zero or null_saveditem
    Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station user <Username> <Password>
	When I am on  Add Shipment (LTL) page in shipment process '<UserType>','<CustomerName>'
	And I have selected saved item which contains nullorzero values '<saveditem>'
	Then item fields should display the text water marks which saveditem contains nullorzero values

	
Examples: 
| Scenario | Username              | Password | UserType | CustomerName             | searchedval | saveditem          |
| 1        | crmOperation@user.com | Te$t1234 | Internal |101 Telco Solutions       |             |150 KEYBOARD        |
| 2        | shpent                | Te$t1234 | External |                          |             |150 KEYBOARD        |

@GUI 
Scenario Outline: 31797_Test to verify Display Text Water Mark Fields_default item contains a zero or null_saveditem_additionalitemsection
    Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station user <Username> <Password>
	When I am on  Add Shipment (LTL) page in shipment process '<UserType>','<CustomerName>'
	And I clicked on add additional item button
    And I have selected saved item which contains nullorzero values '<saveditem>' additional item section
	Then item fields should display the text water marks which saveditem contains nullorzero values additional item section
	
Examples: 
| Scenario | Username              | Password | UserType | CustomerName             | searchedval | saveditem         |
| 1        | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test |             |65 PLASTIC BOTTLES |
| 2        | zzzext@user.com       | Te$t1234 | External |                          |             |65 PLASTIC BOTTLES |
