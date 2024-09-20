@OverLenght_AddShipment_LTL_SavedItemWithDimensions @40831 @Sprint81 

Feature: Over Length - Add Shipment (LTL) - Saved Item with Dimensions


@GUI @Functional 
Scenario Outline: 40831_Verify the dimensions and dimension type values for selected saved item containing CM or Meter
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When I have selected a saved item of dimension type with values of following <dimension> : CM or Meter
Then The following dimension fields will be blank: Length, width, Height
And The dimension type will be defaulted to - IN

Examples: 
| dimension |
| CM        |
| METER     |



@GUI @Functional 
Scenario Outline: 40831_Verify the dimensions and dimension type values when customer is having default item containing CM or Meter
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When The customer has a default item of dimensions type with values of following <dimension> : CM or Meter
Then The following dimension fields will be blank: Length, width, Height
And The dimension type will be defaulted to - IN

Examples: 
| dimension |
| CM        |
| METER     |

Scenario:40831_Verify the Length, Width, Height dimension fields when saved item included dimension type is IN
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When I have selected a saved item of dimension type of <IN> values
Then Length, Width, Height dimension fields will get bind and dimension type should be <IN> type

Scenario:40831_Verify the Length, Width, Height dimension fields when saved item included dimension type is FT
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When I have selected a saved item of dimension type of <FT> values
Then Length, Width, Height dimension fields will get bind and dimension type should be <FT> type

Scenario:40831_Verify the Length, Width, Height dimension fields when default saved item included dimension type is IN
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When the customer has a default item of dimensions type of <IN> values
Then Length, Width, Height dimension fields will get bind and dimension type should be <IN> type

Scenario:40831_Verify the Length, Width, Height dimension fields when default saved item included dimension type is FT
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When the customer has a default item of dimensions type of <FT> values
Then Length, Width, Height dimension fields will get bind and dimension type should be <FT> type