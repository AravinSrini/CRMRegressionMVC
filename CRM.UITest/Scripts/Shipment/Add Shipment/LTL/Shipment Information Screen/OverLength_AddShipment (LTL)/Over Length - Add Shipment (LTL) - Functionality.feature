@Sprint81 @40773

Feature: Over Length - Add Shipment (LTL) - Functionality

@GUI
Scenario: 40773_Verify the dimension type selection drop down values
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When I select the Dimension Type drop down
Then dimension type selection drop down values should be IN and FT

@GUI
Scenario: 40773_Verify the dimension type selection drop down values for the additional item
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
When I navigate to the Add Shipment (LTL) page
Then dimension type selection drop down values should be IN and FT for additional items

@GUI
Scenario: 40773_Verify the Length, Width and Height are required fields when I select the Services and accessorials as Overlength in Shipping From section
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When I select Overlength as Services and accessorials from Shipping From Section
Then the Dimension fields Length, Width and Height should be the required fields

@GUI
Scenario: 40773_Verify the Length, Width and Height are required fields when I select the Services and accessorials as Overlength in Shipping To section
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When I select Overlength as Services and accessorials from Shipping To Section
Then the Dimension fields Length, Width and Height should be the required fields

@GUI 
Scenario: 40773_Verify the Length, Width and Height are not required fields when I select the Services and accessorials other than Overlength in Shipping From section
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When I select any Services and accessorials other than Overlength from Shipping From Section
Then the Dimension fields Length, Width and Height should not be the required fields

@GUI
Scenario: 40773_Verify the Length, Width and Height are not required fields when I select the Services and accessorials other than Overlength in Shipping To Section
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When I select any Services and accessorials other than Overlength from Shipping To Section
Then the Dimension fields Length, Width and Height should not be the required fields


@GUI
Scenario Outline: 40773_Verify the auto selection, removal of Overlength and adding other accessorials in Shipping From section when Lenght is equal to or greater than 96 Inches
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When the entered value of length field is equal to or greater than 96 inches <Inches>
Then the Overlength should be auto populated in the services and accessorials of Shipping From section
And I have the option to remove the Overlength accessorial from Shipping From Section
And I have the option to add any other accessorial in Shipping From Section
Examples: 
| Inches |
| 96     |
| 102    |

@GUI
Scenario: 40773_Verify the Overlength is not auto selected in services and accessorial section of Shipping From Section when Length is less than 96 Inches
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When the entered value of length field is less than 96 inches <80>
Then the Overlength accessorial is not auto selected in the services and accessorial section of Shipping From Section 


@GUI
Scenario Outline: 40773_Verify the auto selection, removal of Overlength and adding other accessorials in Shipping From section when Length is equal to or greater than 8 Feet
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When the entered value of length field is equal to or greater than 8 feet <Feet>
Then the Overlength should be auto populated in the services and accessorials of Shipping From section
And I have the option to remove the Overlength accessorial from Shipping From Section
And I have the option to add any other accessorial in Shipping From Section	
Examples: 
| Feet |
| 8    |
| 12   |

@GUI
Scenario: 40773_Verify the Overlength is not auto selected in services and accessorial section of Shipping From Section when Length is less than 8 Feet
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When the entered value of length field is less than 8 feet <6>
Then the Overlength accessorial is not auto selected in the services and accessorial section of Shipping From Section 



@GUI
Scenario Outline: 40773_Verify the presence of warning popup with Verbiage and option to remove the warning popup when the length is equal to or greater than 96 inches
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When the entered value of length field is equal to or greater than 96 inches <Inches>
Then I can see the warning popup with verbiage <The entered Length exceeds the standard LTL threshold of 8 feet. Additional carrier fees may apply.>
And I also have option to remove the warning popup
Examples: 
| Inches |
| 96     |
| 109    |


@GUI
Scenario Outline: 40773_Verify the presence of warning popup with Verbiage and option to remove the warning popup when the length is equal to or greater than 8 feet
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When the entered value of length field is equal to or greater than 8 feet <Feet>
Then I can see the warning popup with verbiage 'The entered Length exceeds the standard LTL threshold of 8 feet. Additional carrier fees may apply.'
And I also have option to remove the warning popup
Examples: 
| Feet |
| 8    |
| 11   |


@GUI
Scenario: 40773_Verify the presence and removal of warning popup message when overlength is selected and length value is entered in Shipping From Section
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
And I select Overlength as Services and accessorials from Shipping From Section
When I enter a value in the length field
Then I can see the warning popup message with verbiage 'Additional carrier fees may apply due to the selection of the Overlength accessorial'
And I also have option to remove the warning popup


@GUI
Scenario: 40773_Verify the presence and removal of warning popup message when overlength is selected and length value is entered in Shipping To Section
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
And I select Overlength as Services and accessorials from Shipping To Section
When I enter a value in the length field
Then I can see the warning popup message with verbiage 'Additional carrier fees may apply due to the selection of the Overlength accessorial'
And I also have option to remove the warning popup


@GUI
Scenario:40773_Verify the validation of the dimesion fields on frieght description section
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
When I navigate to the Add Shipment (LTL) page
Then I am not allowed to enter negative value in Length, Width and Height fields <-7>
And the Minimum value accepted in Length, Width and Height fields is 1
And I am not allowed to enter decimal values in Length, Width and Height fields <0.9>
And the maximum length of Length, Width and Height fields is restricted to three digit <999>


@GUI
Scenario:40773_Verify the validation of the dimesion fields on frieght description section for additional items
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user
And I navigate to the Add Shipment (LTL) page
When I click on the add additional item button on the Add Shipment LTL page
Then I am not allowed to enter negative value in the added additional item fields for Length, Width and Height fields <-7>
And the Minimum value accepted in the added additional item fields for Length, Width and Height fields is 1
And I am not allowed to enter decimal values in the added additional item fields for Length, Width and Height fields <0.9>
And the maximum length of Length, Width and Height fields in the added additional item fields is restricted to three digit <999>
