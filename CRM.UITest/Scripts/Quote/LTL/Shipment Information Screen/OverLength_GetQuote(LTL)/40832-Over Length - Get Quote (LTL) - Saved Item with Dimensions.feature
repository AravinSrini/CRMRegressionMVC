@Sprint81 @40832 @Functional

Feature: 40832-Over Length - Get Quote (LTL) - Saved Item with Dimensions

@Regression 
Scenario:40832-Verify Length,Width,Height dimension fields when saved item included dimension type is CM
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I have selected a saved item included dimension and dimension type<CM> values
When the dimension type of the saved item is <CM>
Then the Length,Width,Height dimension fields will be blank
And the dimension type will be defaulted to <IN>

@Regression 
Scenario:40832-Verify Length,Width,Height dimension fields when saved item included dimension type is METER
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I have selected a saved item included dimension and dimension type<METER> values
When the dimension type of the saved item is <METER>
Then the Length,Width,Height dimension fields will be blank
And the dimension type will be defaulted to <IN>

@Regression 
Scenario:Default40832-Verify Length,Width,Height dimension fields when default saved item included dimension type is CM
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And the customer has a default item included dimensions and dimension type<CM> values
When the dimension type of the saved item is <CM>
Then the Length,Width,Height dimension fields will be blank
And the dimension type will be defaulted to <IN>

@Regression 
Scenario:40832-Verify Length,Width,Height dimension fields when default saved item included dimension type is METER
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And the customer has a default item included dimensions and dimension type<METER> values
When the dimension type of the saved item is <METER>
Then the Length,Width,Height dimension fields will be blank
And the dimension type will be defaulted to <IN>

@Regression 
Scenario:40832-Verify Length,Width,Height dimension fields when saved item included dimension type is IN
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I have selected a saved item included dimension and dimension type<IN> values
When the dimension type of the saved item is <IN>
Then the Length,Width,Height,Dimension type dimension fields will get bind <IN>

@Regression 
Scenario:40832-Verify Length,Width,Height dimension fields when saved item included dimension type is FT
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I have selected a saved item included dimension and dimension type<FT> values
When the dimension type of the saved item is <FT>
Then the Length,Width,Height,Dimension type dimension fields will get bind <FT>

@Regression 
Scenario:40832-Verify Length,Width,Height dimension fields when default saved item included dimension type is IN
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And the customer has a default item included dimensions and dimension type values
When the dimension type of the saved item is <IN>
Then the Length,Width,Height,Dimension type dimension fields will get bind <IN>

@Regression 
Scenario:40832-Verify Length,Width,Height dimension fields when default saved item included dimension type is FT
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And the customer has a default item included dimensions and dimension type values
When the dimension type of the saved item is <FT>
Then the Length,Width,Height,Dimension type dimension fields will get bind <FT>