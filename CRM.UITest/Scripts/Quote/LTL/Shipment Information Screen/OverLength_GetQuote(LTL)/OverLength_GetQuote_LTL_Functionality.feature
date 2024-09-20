
Feature: OverLength_GetQuote_LTL_Functionality
	
@Regression @Sprint81 @40778
Scenario: 40778 Verify Length, Width, Height are required fields for Overlength Shipping From Accessorials
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When I selected services and accessorials as Overlength in Shipping From section
Then Length, Width, Height will becomes required fields for each item


@Regression @Sprint81 @40778
Scenario: 40778 Verify Length, Width, Height are required fields for Overlength Shipping To Accessorials
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When I selected services and accessorials as Overlength in Shipping To section
Then Length, Width, Height will becomes required fields for each item


@Regression @Sprint81 @40778
Scenario: 40778 Verify Length, Width, Height are not required fields for other than Overlength Accessorial Shipping From section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When I selected services and accessorials as other than Overlength in Shipping From section
Then Length, Width, Height will not be required fields for each item


@Regression @Sprint81 @40778
Scenario: 40778 Verify Length, Width, Height are not required fields for other than Overlength Accessorial Shipping To section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When I selected services and accessorials as other than Overlength in Shipping To section
Then Length, Width, Height will not be required fields for each item

@Regression @Sprint81 @40778
Scenario: 40778 Verify auto-selection,removal of Overlength,adding other accessorials for length greater than 96 IN in the Shipping From section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered Length value is greater than 96 Inches
Then the Overlength will be auto selected in the Shipping From section services and accessorials field
And I have option to remove the Overlength accessorial
And I have option to add any other accessorials

@Regression @Sprint81 @40778
Scenario: 40778 Verify auto-selection,removal of Overlength,adding other accessorials for equal to 96 IN in the Shipping From section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered Length value is equal to 96 Inches
Then the Overlength will be auto selected in the Shipping From section services and accessorials field
And I have option to remove the Overlength accessorial
And I have option to add any other accessorials

@Regression @Sprint81 @40778
Scenario: 40778 Verify auto-selections for less than 96 IN in the Shipping From section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered Length value is less than 96 Inches
Then the Overlength will be not be auto selected in the Shipping From section services and accessorials field

@Regression @Sprint81 @40778
Scenario: 40778 Verify auto-selection,removal of Overlength,adding other accessorials for length greater than 8 FT in the Shipping From section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered Length value is greater than 8 Feet
Then the Overlength will be auto selected in the Shipping From section services and accessorials field
And I have option to remove the Overlength accessorial
And I have option to add any other accessorials

@Regression @Sprint81 @40778
Scenario: 40778 Verify auto-selection,removal of Overlength,adding other accessorials for equal to 8 FT in the Shipping From section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered Length value is equal to 8 Feet
Then the Overlength will be auto selected in the Shipping From section services and accessorials field
And I have option to remove the Overlength accessorial
And I have option to add any other accessorials

@Regression @Sprint81 @40778
Scenario: 40778 Verify auto-selection for less than 8 FT in the Shipping From section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered Length value is less than 8 Feet
Then the Overlength will be not be auto selected in the Shipping From section services and accessorials field


@Regression @Sprint81 @40778
Scenario: 40778 Verify the presence of Warning PopUp with the Verbiage when the Length is greater than 96 Inches
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered value of Length is greater than 96 Inches
Then I will see a Warning PopUp with Verbiage for the length greater than 96 Inches <The entered Length exceeds the standard LTL threshold of 8 feet. Additional carrier fees may apply.>
And I have options to remove the Warning PopUp of this entered length greater than 96 Inches

@Regression @Sprint81 @40778
Scenario: 40778 Verify the presence of Warning PopUp with the Verbiage when the Length is equal to 96 Inches
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered value of Length is equal to 96 Inches
Then I will see a Warning PopUp with Verbiage for the length equal to 96 Inches <The entered Length exceeds the standard LTL threshold of 8 feet. Additional carrier fees may apply.>
And I have options to remove the Warning PopUp of this entered length equal to 96 Inches

@Regression @Sprint81 @40778
Scenario: 40778 Verify the absence of Warning PopUp when the Length is less than 96 Inches
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered value of Length is less than 96 Inches
Then I will not see a Warning PopUp for the entered length less than 96 Inches


@Regression @Sprint81 @40778
Scenario: 40778 Verify the presence of Warning PopUp with the Verbiage when the Length is greater than 8 Feet
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered value of Length is greater than 8 Feet
Then I will see Warning PopUp with the Verbiage for the entered length greater than 8 Feet<The entered Length exceeds the standard LTL threshold of 8 feet. Additional carrier fees may apply.>
And I have options to remove the Warning PopUp of this entered length greater than 8 Feet

@Regression @Sprint81 @40778
Scenario: 40778 Verify the presence of Warning PopUp with the Verbiage when the Length is equal to 8 Feet
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered value of Length is equal to 8 Feet
Then I will see Warning PopUp with the Verbiage for the entered length equal to 8 Feet<The entered Length exceeds the standard LTL threshold of 8 feet. Additional carrier fees may apply.>
And I have options to remove the Warning PopUp of this entered length equal to 8 Feet

@Regression @Sprint81 @40778
Scenario: 40778 verify the absence of Warning PopUp when the Length is less than 8 Feet
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
When the entered value of Length is less than 8 Feet
Then I will not see a Warning PopUp for the entered length less than 8 Feet

@Regression @Sprint81 @40778
Scenario: 40778 Verify the presence and removal of Warning PopUp for Overlength Shipping From section Accessorial and then I entered value in Length field
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I selected Services and Accessorials as Overlength in Shipping From section
When I entered any value in Length field
Then I will see a Warning PopUp with the Verbiage<Additional carrier fees may apply due to the selection of the Overlength accessorial.>
And I have options to remove a Additional carrier fees may apply due to the selection of the Overlength accessorial Warning PopUp

@Regression @Sprint81 @40778
Scenario: 40778 Verify the absence of Warning PopUp when Overlength is not selected in Shipping From and Shipping To section and then I entered value in Length field
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I did not selected Services and Accessorials as Overlength in Shipping From and Shipping To section
When I entered any value in Length field
Then I will not see Length field Warning PopUp

@Regression @Sprint81 @40778
Scenario: 40778 Verify the presence and removal of Warning PopUp when Overlength is selected in Shipping To section and then I entered value in Length field
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I selected Services and Accessorials as Overlength in Shipping To section
When I entered any value in Length field
Then I will see a Warning PopUp with the Verbiage<Additional carrier fees may apply due to the selection of the Overlength accessorial.>
And I have options to remove a Additional carrier fees may apply due to the selection of the Overlength accessorial Warning PopUp

@Regression @Sprint81 @40778
Scenario: 40778 Verify removal of Warning PopUp in Length field upon click on Clear Item link when Overlength is selected in Shipping From section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I selected Services and Accessorials as Overlength in Shipping From section
And I entered any value in Length field
When I clicked on the Clear Item link
Then the Length field Warning PopUp will be removed

@Regression @Sprint81 @40778
Scenario: 40778 Verify removal of Warning PopUp in Length field upon click on Clear Item link when Overlength is selected in Shipping To section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I selected Services and Accessorials as Overlength in Shipping To section
And I entered any value in Length field
When I clicked on the Clear Item link
Then the Length field Warning PopUp will be removed

@Regression @Sprint81 @40778
Scenario: 40778 Verify Removal of Warning PopUp for Length equal or greater than 96 Inches upon click on Clear Item link
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I entered value of Length is greater equal to greater than 96 Inches
When I clicked on the Clear Item link
Then the Length field Warning PopUp will be removed for the length greater than 96 Inches

@Regression @Sprint81 @40778
Scenario: 40778 Verify Removal of Warning PopUp for Length equal or greater than 8 FT upon click on Clear Item link
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I entered value of Length is greater equal to greater than 8 Feet
When I clicked on the Clear Item link
Then the Length field Warning PopUp will be removed for the length greater than 8 Feet

@Regression @Sprint92 @104992
Scenario: 104992 Verify Warning Popup by onchanging Dimension Type from Inches to Feet when the entered length greater than 8 Feet 
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I entered Length greater than 8
When I change Dimension type from Inches to Feet
Then I will see Warning PopUp with the Verbiage for the entered length greater than 8 Feet<The entered Length exceeds the standard LTL threshold of 8 feet. Additional carrier fees may apply.>
And I have options to remove the Warning PopUp of this entered length greater than 8 Feet 

@Regression @Sprint92 @104992
Scenario: 104992 Verify Warning Popup by onchanging Dimension Type from Inches to Feet when the entered length equal to 8 Feet 
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I entered Length equal to 8
When I change Dimension type from Inches to Feet
Then I will see Warning PopUp with the Verbiage for the entered length greater than 8 Feet<The entered Length exceeds the standard LTL threshold of 8 feet. Additional carrier fees may apply.>
And I have options to remove the Warning PopUp of this entered length greater than 8 Feet 

@Regression @Sprint92 @104992
Scenario: 104992 Verify absence of Warning Popup by onchanging Dimension Type from Inches to Feet when the entered length less than to 8 Feet 
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And I am on the Get Quote (LTL) page
And I entered Length less than 8
When I change Dimension type from Inches to Feet
Then I will not see Warning PopUp for the entered length less than 8 Feet 