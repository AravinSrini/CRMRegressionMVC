@Sprint70 @30504

Feature: Add Shipment (LTL) (MVC5) - Field Validations

@GUI 
Scenario Outline: Test to verify Field Validations_Add Shipment
    Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station user <Username> <Password>
	When I am on  Add Shipment (LTL) page in shipment process '<UserType>','<CustomerName>'
	Then NMFC field will accept min character one character max characters twenty characters
	And Quantity field should accept numeric_whole number_max length of_seven 
	And Weight field should accept numeric_max length of_ten
	And DimensionsL fields should accept  numeric_whole number_max length of_three
	And DimensionsW fields should accept  numeric_whole number_max length of_three 
	And DimensionsH fields should accept  numeric_whole number_max length of_three
	And Item descriptionfield should accept max of_onehundredandfiftyfifty characters 
	And Default Special Instructions should accept max of_twohundredandfifty characters 
	And Reference Numbers should accept max of twentyfive_characters 
	And Reference Numbers should accept max of twentyfive_characters in additional reference number field 
	And I should display'<errormessage>' when insval morethanLakh '<ins>'
	 
	
	
Examples: 
| Scenario | Username              | Password | UserType | CustomerName  | ins     | errormessage                                                                        |
| 1        | crmOperation@user.com | Te$t1234 | Internal | Dunkin Donuts | 1000000 |The entered shipment value exceeds $100,000. Please contact your DLS representative. |  
| 2        | shpentry              | Te$t1234 | External |               |1000000  |The entered shipment value exceeds $100,000. Please contact your DLS representative. |

	


@GUI 
Scenario Outline: Test to verify Field Validations_Add Shipment_additionalitem
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station user <Username> <Password>
	When I am on  Add Shipment (LTL) page in shipment process '<UserType>','<CustomerName>'
	And I clicked on add additional item button
	Then NMFC field will accept min character one character max characters twenty characters of additional item
	And Quantity field should accept numeric_whole number_max length of_seven of additional item 
	And Weight field should accept numeric_max length of_ten of additional item
	And DimensionsL fields should accept  numeric_whole number_max length of_three of additional item
	And DimensionsW fields should accept  numeric_whole number_max length of_three of additional item
	And DimensionsH fields should accept  numeric_whole number_max length of_three of additional item
	And Item descriptionfield should accept max of_onehundredandfiftyfifty characters of additional item

		
Examples: 
| Scenario | Username              | Password | UserType | CustomerName              | 
| 1        | crmOperation@user.com | Te$t1234 | Internal | Dunkin Donuts             |
| 2        | shpentry              | Te$t1234 | External |                           |




