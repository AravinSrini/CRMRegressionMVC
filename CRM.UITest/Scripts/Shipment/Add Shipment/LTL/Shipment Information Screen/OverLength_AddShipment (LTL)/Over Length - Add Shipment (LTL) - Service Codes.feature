@OverLength_AddShipment_LTL_ServiceCodes @40776 @Sprint81 @Ignore

Feature: Over Length - Add Shipment (LTL) - Service Codes

@GUI @Functional @API
Scenario Outline: 40776_Verify rates on shipment results page when values entered in the Length field of an item is equal to or greater than 96 IN
Given I am a shp.entry, sales, sales management, operations and station owner user
And I am on the Add Shipment (LTL) page
And Over Length is selected in the <Click to add services & accessorials...> field on the Add shipment LTL page 
And The values entered in the Length field of an any item is equal to or greater than <Value> IN
When I click on the View Rates button
Then The CRM will send the associated Over Length Service Code to MG for Shipment <Value>,<IN> 
And  Total cost should be matched with API on Shipment Results page

Examples: 
| Value |
| 96    |
| 132   |
| 999   |


@GUI @Functional @API
Scenario Outline:40776- Verify rates on shipment results page when values entered in the Length field of an item is equal to or greater than 8 FT
Given I am a shp.entry, sales, sales management, operations and station owner user
And I am on the Add Shipment (LTL) page
And Over Length is selected in the <Click to add services & accessorials...> field on the Add shipment LTL page 
And The values entered in the Length field of an any item is equal to or greater than <Value> FT
When I click on the View Rates button
Then CRM will send the associated Over Length Service Code to MG for Shipment <Value>,<FT> 
And  Total cost should be matched with API on Shipment Results page

Examples: 
| Value |
| 8     |
| 9     |
| 31    |


@GUI @Functional @API
Scenario Outline:40776- Verify rates on shipment results page when Over Length accessorial removed from drop down and values entered in the Length field of an item is equal to or greater 96 IN
Given I am a shp.entry, sales, sales management, operations and station owner user
And I am on the Add Shipment (LTL) page
And Over Length is selected in the <Click to add services & accessorials...> field on the Add shipment LTL page 
And The values entered in the Length field of an any item is equal to or greater than <Value> IN
And I removed the Over Length accessorial from the <Click to add services & accessorials...> field on the Add shipment LTL page 
When I click on the View Rates button
Then CRM will send the associated Over Length Service Code to MG for Shipment <Value>,<IN> 
And  Total cost should be matched with API on Shipment Results page

Examples: 
| Value |
| 96    |
| 132   |
| 999   |

@GUI @Functional @API
Scenario Outline:40776- Verify rates on shipment results page when Over Length accessorial removed from drop down and values entered in the Length field of an item is equal to or greater 8 FT
Given I am a shp.entry, sales, sales management, operations and station owner user
And I am on the Add Shipment (LTL) page
And Over Length is selected in the <Click to add services & accessorials...> field on the Add shipment LTL page 
And The values entered in the Length field of an any item is equal to or greater than <Value> FT
And I removed the Over Length accessorial from the <Click to add services & accessorials...> field on the Add shipment LTL page 
When I click on the View Rates button
Then CRM will send the associated Over Length Service Code to MG for Shipment <Value>,<FT> 
And  Total cost should be matched with API on Shipment Results page

Examples: 
| Value |
| 8     |
| 9     |
| 31    |

@GUI @Functional @API
Scenario:40776- Verify rates on shipment results page when values entered in the Length field is LESS than the 96 IN
Given I am a shp.entry, sales, sales management, operations and station owner user
And I am on the Add Shipment (LTL) page
And Over Length is selected in the <Click to add services & accessorials...> field on the Add shipment LTL page 
And The values entered in the Length field of an any item is LESS than the ninety six <96> IN
When I click on the View Rates button
Then CRM will not send any Over Length Service Code to MG for Shipment <Value>,<IN>
And  Total cost should be matched with API on Shipment Results page


@GUI @Functional @API
Scenario:40776- Verify rates on shipment results page when values entered in the Length field is LESS than the 8 FT
Given I am a shp.entry, sales, sales management, operations and station owner user
And I am on the Add Shipment (LTL) page
And Over Length is selected in the <Click to add services & accessorials...> field on the Add shipment LTL page 
And The values entered in the Length field of an any item is LESS than the eight <8> FT
When I click on the View Rates button
Then CRM will not send any Over Length Service Code to MG for Shipment <Value>,<FT>
And  Total cost should be matched with API on Shipment Results page
