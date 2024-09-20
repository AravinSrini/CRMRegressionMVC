@Sprint81 @40777
Feature: OverLength_GetQuote_LTL_ NewFields
	
@Regression 
Scenario: 40777-Verify the presence of optional Dimension fields in the Freight Description section-Length,Height,Width
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
When I am on the Get Quote (LTL) page
Then I will see new optional Dimension fields in the Freight Description section Length,Height,Width

@Regression 
Scenario: 40777-Verify the validation of Dimension fields in the Freight Description section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
When I am on the Get Quote (LTL) page
Then I am not allowed to enter Negative value in Length, Width, Height field<-7>
And the Minimum value accepted in Length, Width, Height field is 1
And I am not allowed to enter decimal values in Length, Width, Height field<0.9>
And the maximum length of Length, Width, Height field is restricted to three digit<999>
And I will see a new Dimension Type drop down list,
And the default Dimension Type selection is <IN>,
And I have the option to select <FT> as a Dimension Type.


@Regression 
Scenario: 40777-Verify the Clear button functionality for the newly added Dimension fields 
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I have changed dimemsion type defalut to Feet <FT>
When I click Clear Item Link
And the Dimension Type will be bind with the default  dimension type <IN>


#----------------------------------Additional Item-----------------------------#
@Regression 
Scenario: 40777-Verify the presence of optional Dimension fields for the Additional Items in the Freight Description section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When I click on the Add Additional Item button
Then I will see new optional Dimension fields for added additional Items in the Freight Description section

@Regression 
Scenario: 40777-Verify the validation of Dimension fields for the Additional Items in the Freight Description section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When I click on the Add Additional Item button
Then I am not allowed to enter Negative value in the added additional Items for Length, Width, Height for <-7>
And the Minimum value accepted in the added additional Items for Length, Width, Height field should accept 1
And I am not allowed to enter decimal values in the added additional Items for Length, Width, Height field<0.9> 
And the maximum length of Length, Width, Height field in the added additional Items is restricted to three digit<999>
And I will see a new Dimension Type drop down list in the added additional items
And the default Dimension Type selection is <IN> in the added additional items
And I have the option to select <FT> as a Dimension Type in the added additional items





