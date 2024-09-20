@40782 @Sprint81 @Functional

Feature: 40782-Over Length - Get Quote (LTL) - Service Codes

@Regression 
Scenario Outline:A-40782- Verify rates on rate results page when values entered in the Length field of an item is equal to or greater 96 IN
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user,
And I am on the Get Quote (LTL) page rate request process
And Over Length is selected in the <Click to add services & accessorials...> field
And the values entered in the Length field of an item is equal to or greater <Value> IN
When I click on the View Quote Results button on Get Quote (LTL) page
Then CRM will send the associated Over Length Service Code to MG <Value>,<IN>
And  Total cost should be matched with API
Examples: 
| Value |
| 96    |
| 110   |


@Regression 
Scenario Outline:B-40782- Verify rates on rate results page when values entered in the Length field of an item is equal to or greater 8 FT
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user,
And I am on the Get Quote (LTL) page rate request process
And Over Length is selected in the <Click to add services & accessorials...> field
And the values entered in the Length field of an item is equal to or greater <Value> FT
When I click on the View Quote Results button on Get Quote (LTL) page
Then CRM will send the associated Over Length Service Code to MG <Value>,<FT>
And  Total cost should be matched with API
Examples: 
| Value |
| 8     |
| 9     |

@Regression 
Scenario Outline:40782- Verify rates on rate results page when Over Length accessorial removed from drop down and values entered in the Length field of an item is equal to or greater 96 IN
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user,
And I am on the Get Quote (LTL) page rate request process
And Over Length is selected in the <Click to add services & accessorials...> field
And the values entered in the Length field of an item is equal to or greater <Value> IN
And I removed the Over Length accessorial from the <Click to add services & accessorials...> field
When I click on the View Quote Results button on Get Quote (LTL) page
Then CRM will send the associated Over Length Service Code to MG <Value>,<IN>
And  Total cost should be matched with API
Examples: 
| Value |
| 96    |
| 132   |
#| 999   |

@Regression 
Scenario Outline:40782- Verify rates on rate results page when Over Length accessorial removed from drop down and values entered in the Length field of an item is equal to or greater 8 FT
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user,
And I am on the Get Quote (LTL) page rate request process
And Over Length is selected in the <Click to add services & accessorials...> field
And the values entered in the Length field of an item is equal to or greater <Value> FT
And I removed the Over Length accessorial from the <Click to add services & accessorials...> field
When I click on the View Quote Results button on Get Quote (LTL) page
Then CRM will send the associated Over Length Service Code to MG <Value>,<FT>
And  Total cost should be matched with API
Examples: 
| Value |
| 8     |
| 9     |
#| 31    |

@Regression 
Scenario:40782- Verify rates on rate results page when values entered in the Length field value is LESS  than the 96 IN
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user,
And I am on the Get Quote (LTL) page rate request process
And Over Length is selected in the <Click to add services & accessorials...> field
And the values entered in the Length field of an item is LESS than the ninety six <95> IN
When I click on the View Quote Results button on Get Quote (LTL) page
Then CRM will not send any Over Length Service Code to MG <95>,<IN>
And  Total cost should be matched with API

@Regression 
Scenario:40782- Verify rates on rate results page when values entered in the Length field value is LESS  than the 8 FT
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user,
And I am on the Get Quote (LTL) page rate request process
And Over Length is selected in the <Click to add services & accessorials...> field
And the values entered in the Length field of an item is LESS than the eight <7> FT
When I click on the View Quote Results button on Get Quote (LTL) page
Then CRM will not send any Over Length Service Code to MG <7>,<FT>
And  Total cost should be matched with API