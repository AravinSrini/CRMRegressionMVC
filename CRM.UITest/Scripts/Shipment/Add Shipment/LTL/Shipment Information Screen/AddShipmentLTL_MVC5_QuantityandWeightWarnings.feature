@30506 @Sprint70
Feature: AddShipmentLTL_MVC5_QuantityandWeightWarnings
	
@Functional
Scenario Outline: Verify the Quantity field warning message of Quantity type as skids when user entered more than threshold value
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
And I am on the Add Shipment (LTL) page <Usertype>, <CustomerName>
And the Quantity type is skids
When the Quantity is greater than threshold value
Then I will display with <Quantity_WarningMessage> in Add Shipment (LTL) page

Examples: 
| Scenario | Username     | Password | Usertype | CustomerName   | Quantity_WarningMessage                                                                                                                                                                                          |
| s1       | crmOperation | Te$t1234 | Internal | testing_uat123 | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids.  An additional carrier fee may apply.  Please contact your local operations representative for more accurate pricing information. |
| s2       | shpent       | Te$t1234 | External |                | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids.  An additional carrier fee may apply.  Please contact your local operations representative for more accurate pricing information. |

@Functional
Scenario Outline: Verify the Quantity field warning message of Quantity type as pallets when user entered more than threshold value
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
And I am on the Add Shipment (LTL) page <Usertype>, <CustomerName>
And the Quantity type is pallets
When the Quantity is greater than threshold value
Then I will display with <Quantity_WarningMessage> in Add Shipment (LTL) page

Examples: 
| Scenario | Username     | Password | Usertype | CustomerName   | Quantity_WarningMessage                                                                                                                                                                                          |
| s1       | crmOperation | Te$t1234 | Internal | testing_uat123 | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids.  An additional carrier fee may apply.  Please contact your local operations representative for more accurate pricing information. |
| s2       | shpent       | Te$t1234 | External |                | The entered quantity exceeds the LTL threshold of 6 standard pallets or skids.  An additional carrier fee may apply.  Please contact your local operations representative for more accurate pricing information. |

@Functional
Scenario Outline: Verify the Weight field warning message of Weight type as LBS when user entered more than threshold value
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
And I am on the Add Shipment (LTL) page <Usertype>, <CustomerName>
And the Weight type is LBS
When the Weight is greater than <Threshold_value>
Then I will displayed with lbs <Weight_WarningMessage> in Add Shipment (LTL) page

Examples: 
| Scenario | Username     | Password | Usertype | CustomerName   | Threshold_value | Weight_WarningMessage                                                                                                                                                                       |
| s1       | crmOperation | Te$t1234 | Internal | testing_uat123 | 10,001          | The entered weight exceeds the LTL threshold of 10,000 lbs.  An additional carrier fee may apply.  Please contact your local operations representative for more accurate pricing information. |
| s2       | shpent       | Te$t1234 | External |                | 10,002          | The entered weight exceeds the LTL threshold of 10,000 lbs.  An additional carrier fee may apply.  Please contact your local operations representative for more accurate pricing information. |

@Functional
Scenario Outline: Verify the Weight field warning message of Weight type as KILOS when user entered more than threshold value
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
And I am on the Add Shipment (LTL) page <Usertype>, <CustomerName>
And the Weight type is KILOS
When the Weight is greater than <Threshold_value>
Then I will displayed with Kilos <Weight_WarningMessage> in Add Shipment (LTL) page

Examples: 
| Scenario | Username     | Password | Usertype | CustomerName   | Threshold_value | Weight_WarningMessage                                                                                                                                                                        |
| s1       | crmOperation | Te$t1234 | Internal | testing_uat123 | 4,537           | The entered weight exceeds the LTL threshold of 4,536 kgs.  An additional carrier fee may apply.  Please contact your local operations representative for more accurate pricing information. |
| s2       | Shpent       | Te$t1234 | External |                | 5,000           | The entered weight exceeds the LTL threshold of 4,536 kgs.  An additional carrier fee may apply.  Please contact your local operations representative for more accurate pricing information. |