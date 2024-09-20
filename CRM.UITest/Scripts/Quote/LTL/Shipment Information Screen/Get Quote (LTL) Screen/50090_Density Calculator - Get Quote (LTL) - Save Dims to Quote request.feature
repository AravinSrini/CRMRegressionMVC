@50090 @NinjaSprint29 @Regression
Feature: 50090_Density Calculator - Get Quote (LTL) - Save Dims to Quote request
	
Scenario: 50090_Verify_Values_For_Length_Width_And_Height_In_Estimated_Class_Lookup_Modal_Are_Applied_To_Respective_Fields_On_Get_Quote_LTL_Page
Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-CurrentsprintOperations" "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) Page for "ZZZ - GS Customer Test"
And I have opened the Estimated Class Lookup modal
And I have entered the required information for Length, Width, Height, Weight, and Quantity "30", "20", "10", "100", "1"
When I click on the Apply Class Button
Then the Length value "30" will be applied to the Length field on the Get Quote (LTL) page
And the Width value "20" will be applied to the Width field on the Get Quote (LTL) page
And the Height value "10" will be applied to the Height field on the Get Quote (LTL) page.

Scenario: 50090_Verify_Overlength_Service_Is_Selected_In_Get_Quote_Page_When_Length_In_Estimated_Class_Modal_Exceeds_95
Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-CurrentsprintOperations" "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) Page for "ZZZ - GS Customer Test"
And I have opened the Estimated Class Lookup modal
And I have entered the required information for Length, Width, Height, Weight, and Quantity "96", "20", "10", "100", "1"
When I click on the Apply Class Button
Then Overlength service is added to the Click to add services & accessorials field on Get Quote (LTL) page

Scenario: 50090_Verify_Values_For_Length_Width_And_Height_In_Estimated_Class_Lookup_Modal_Are_Applied_To_Respective_Fields_On_Get_Quote_LTL_Page_Add_Additional_Item_Selected
Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-CurrentsprintOperations" "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) Page for "ZZZ - GS Customer Test"
And I click on the Add Additional Item Button
And I have opened the Estimated Class Lookup modal for the additional item
And I have entered the required information for Length, Width, Height, Weight, and Quantity "30", "20", "10", "100", "1"
When I click on the Apply Class Button
Then the Length value "30" will be applied to the Length field on the Get Quote (LTL) page
And the Width value "20" will be applied to the Width field on the Get Quote (LTL) page
And the Height value "10" will be applied to the Height field on the Get Quote (LTL) page.

Scenario: 50090_Verify_Overlength_Service_Is_Selected_In_Get_Quote_Page_When_Length_In_Estimated_Class_Modal_Exceeds_95_Add_Additional_Item_Selected
Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-CurrentsprintOperations" "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) Page for "ZZZ - GS Customer Test"
And I click on the Add Additional Item Button
And I have opened the Estimated Class Lookup modal for the additional item
And I have entered the required information for Length, Width, Height, Weight, and Quantity "96", "20", "10", "100", "1"
When I click on the Apply Class Button
Then Overlength service is added to the Click to add services & accessorials field on Get Quote (LTL) page