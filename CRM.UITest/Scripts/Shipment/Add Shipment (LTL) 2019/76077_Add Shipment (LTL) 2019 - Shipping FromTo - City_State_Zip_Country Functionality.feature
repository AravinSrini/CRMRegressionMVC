@76077 @Sprint90
Feature: 76077_Add Shipment (LTL) 2019 - Shipping FromTo - City_State_Zip_Country Functionality

@Regression
Scenario: 76077-Verify the default Country selection In Shipping From Section of Add Shipment LTL page for External User
Given I am a shpentry, shpentrynorates user
When I arrive on the Add Shipment - (LTL) page for External user
Then the Country field should be defaulted to United States in the Shipping From Section
And I have option to select Canada from the drop down list in the Shipping From Section

@Regression
Scenario: 76077-Verify the default Country selection In Shipping From Section of Add Shipment LTL page for Internal User
Given I am a operations, sales management or station owner user
When I arrive on the <Customer> Add Shipment - (LTL) page for Internal user
Then the Country field should be defaulted to United States in the Shipping From Section
And I have option to select Canada from the drop down list in the Shipping From Section

@Regression
Scenario: 76077-Verify the default Country selection In Shipping From Section of Add Shipment LTL page for Sales User
Given I am a sales user
When I arrive on the <Customer> Add Shipment - (LTL) page for Sales user
Then the Country field should be defaulted to United States in the Shipping From Section
And I have option to select Canada from the drop down list in the Shipping From Section

@Regression
Scenario: 76077-Verify the default Country selection In Shipping To Section of Add Shipment LTL page for External User
Given I am a shpentry, shpentrynorates user
When I arrive on the Add Shipment - (LTL) page for External user
Then the Country field should be defaulted to United States in the Shipping To Section
And I have option to select Canada from the drop down list in the Shipping To Section

@Regression
Scenario: 76077-Verify the default Country selection In Shipping To Section of Add Shipment LTL page for Internal User
Given I am a operations, sales management or station owner user
When I arrive on the <Customer> Add Shipment - (LTL) page for Internal user
Then the Country field should be defaulted to United States in the Shipping To Section
And I have option to select Canada from the drop down list in the Shipping To Section

@Regression
Scenario: 76077-Verify the default Country selection In Shipping To Section of Add Shipment LTL page for Sales User
Given I am a sales user
When I arrive on the <Customer> Add Shipment - (LTL) page for Sales user
Then the Country field should be defaulted to United States in the Shipping To Section
And I have option to select Canada from the drop down list in the Shipping To Section

@Regression
Scenario: 76077-Verify the drop down list of states in Shipping From section when Country field selected is United States for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
When Country field selected is United States in the Shipping From Section
Then I should have a drop down list of states to select in the Select state/province field in the Shipping From Section

@Regression
Scenario: 76077-Verify the drop down list of states in Shipping From section when Country field selected is United States for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
When Country field selected is United States in the Shipping From Section
Then I should have a drop down list of states to select in the Select state/province field in the Shipping From Section

@Regression
Scenario: 76077-Verify the drop down list of states in Shipping From section when Country field selected is United States for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
When Country field selected is United States in the Shipping From Section
Then I should have a drop down list of states to select in the Select state/province field in the Shipping From Section

@Regression
Scenario: 76077-Verify the drop down list of states in Shipping To section when Country field selected is United States for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
When Country field selected is United States in the Shipping To Section
Then I should have a drop down list of states to select in the Select state/province field in the Shipping To Section

@Regression
Scenario: 76077-Verify the drop down list of states in Shipping To section when Country field selected is United States for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
When Country field selected is United States in the Shipping To Section
Then I should have a drop down list of states to select in the Select state/province field in the Shipping To Section

@Regression
Scenario: 76077-Verify the drop down list of states in Shipping To section when Country field selected is United States for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
When Country field selected is United States in the Shipping To Section
Then I should have a drop down list of states to select in the Select state/province field in the Shipping To Section

@Regression
Scenario: 76077-Verify the drop down list of provinces in Shipping From section when Country field selected is Canada for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
When Country field selected is Canada in the Shipping From Section
Then I should have a drop down list of provinces to select in the Select state/province field in the Shipping From Section

@Regression
Scenario: 76077-Verify the drop down list of provinces in Shipping From section when Country field selected is Canada for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
When Country field selected is Canada in the Shipping From Section
Then I should have a drop down list of provinces to select in the Select state/province field in the Shipping From Section

@Regression
Scenario: 76077-Verify the drop down list of provinces in Shipping From section when Country field selected is Canada for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
When Country field selected is Canada in the Shipping From Section
Then I should have a drop down list of provinces to select in the Select state/province field in the Shipping From Section

@Regression
Scenario: 76077-Verify the drop down list of provinces in Shipping To section when Country field selected is Canada for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
When Country field selected is Canada in the Shipping To Section
Then I should have a drop down list of provinces to select in the Select state/province field in the Shipping To Section

@Regression
Scenario: 76077-Verify the drop down list of provinces in Shipping To section when Country field selected is Canada for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
When Country field selected is Canada in the Shipping To Section
Then I should have a drop down list of provinces to select in the Select state/province field in the Shipping To Section

@Regression
Scenario: 76077-Verify the drop down list of provinces in Shipping To section when Country field selected is Canada for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
When Country field selected is Canada in the Shipping To Section
Then I should have a drop down list of provinces to select in the Select state/province field in the Shipping To Section

@Regression
Scenario Outline: 76077-Verify and Validate the postal code field when Country field selected is Canada in Shipping From Section for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
When Country field selected is Canada in the Shipping From Section
Then I should be able to enter alpha numeric value including spaces in the <PostalCode> postal code field in the Shipping From Section
And the minimum field length is one in the Shipping From Section
And the maximum field length is seven in the Shipping From Section
Examples: 
| PostalCode |
| T1R1E1     |
| LJ7 0A1    |



@Regression
Scenario Outline: 76077-Verify and Validate the postal code field when Country field selected is Canada in Shipping From Section for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
When Country field selected is Canada in the Shipping From Section
Then I should be able to enter alpha numeric value including spaces in the <PostalCode> postal code field in the Shipping From Section
And the minimum field length is one in the Shipping From Section
And the maximum field length is seven in the Shipping From Section
Examples: 
| PostalCode |
| T7V1B9     |
| L7E 1K5    |
 

@Regression
Scenario Outline: 76077-Verify and Validate the postal code field when Country field selected is Canada in Shipping From Section for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
When Country field selected is Canada in the Shipping From Section
Then I should be able to enter alpha numeric value including spaces in the <PostalCode> postal code field in the Shipping From Section
And the minimum field length is one in the Shipping From Section
And the maximum field length is seven in the Shipping From Section
Examples: 
| PostalCode |
| N4B1T9     |
| N4B 2P8    |

@Regression
Scenario Outline: 76077-Verify and Validate the postal code field when Country field selected is Canada in Shipping To Section for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
When Country field selected is Canada in the Shipping To Section
Then I should be able to enter alpha numeric value including spaces in the <PostalCode> postal code field in the Shipping To Section
And the minimum field length is one in the Shipping To Section
And the maximum field length is seven in the Shipping To Section
Examples: 
| PostalCode |
| T1R1E1     |
| LJ7 0A1    |


@Regression
Scenario Outline: 76077-Verify and Validate the postal code field when Country field selected is Canada in Shipping To Section for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
When Country field selected is Canada in the Shipping To Section
Then I should be able to enter alpha numeric value including spaces in the <PostalCode> postal code field in the Shipping To Section
And the minimum field length is one in the Shipping To Section
And the maximum field length is seven in the Shipping To Section
Examples: 
| PostalCode |
| T7V1B9     |
| L7E 1K5    |

@Regression
Scenario Outline: 76077-Verify and Validate the postal code field when Country field selected is Canada in Shipping To Section for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
When Country field selected is Canada in the Shipping To Section
Then I should be able to enter alpha numeric value including spaces in the <PostalCode> postal code field in the Shipping To Section
And the minimum field length is one in the Shipping To Section
And the maximum field length is seven in the Shipping To Section
Examples: 
| PostalCode |
| N4B1T9     |
| N4B 2P8    |

@Regression
Scenario: 76077-Verify and Validate the zip code field when Country field selected is United States in Shipping From Section for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
When Country field selected is United States in the Shipping From Section
Then I should be able to enter only numeric values in the Shipping From Section
And I should be able to enter a numeric value with leading zero(s) in the Shipping From Section
And the minimum field length is five in the Shipping From Section
And the maximum field length is five in the Shipping From Section

@Regression
Scenario: 76077-Verify and Validate the zip code field when Country field selected is United States in Shipping From Section for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
When Country field selected is United States in the Shipping From Section
Then I should be able to enter only numeric values in the Shipping From Section
And I should be able to enter a numeric value with leading zero(s) in the Shipping From Section
And the minimum field length is five in the Shipping From Section
And the maximum field length is five in the Shipping From Section

@Regression
Scenario: 76077-Verify and Validate the zip code field when Country field selected is United States in Shipping From Section for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
When Country field selected is United States in the Shipping From Section
Then I should be able to enter only numeric values in the Shipping From Section
And I should be able to enter a numeric value with leading zero(s) in the Shipping From Section
And the minimum field length is five in the Shipping From Section
And the maximum field length is five in the Shipping From Section


@Regression
Scenario: 76077-Verify and Validate the zip code field when Country field selected is United States in Shipping To Section for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
When Country field selected is United States in the Shipping To Section
Then I should be able to enter only numeric values in the Shipping To Section
And I should be able to enter a numeric value with leading zero(s) in the Shipping To Section
And the minimum field length is five in the Shipping To Section
And the maximum field length is five in the Shipping To Section

@Regression
Scenario: 76077-Verify and Validate the zip code field when Country field selected is United States in Shipping To Section for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
When Country field selected is United States in the Shipping To Section
Then I should be able to enter only numeric values in the Shipping To Section
And I should be able to enter a numeric value with leading zero(s) in the Shipping To Section
And the minimum field length is five in the Shipping To Section
And the maximum field length is five in the Shipping To Section

@Regression
Scenario: 76077-Verify and Validate the zip code field when Country field selected is United States in Shipping To Section for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
When Country field selected is United States in the Shipping To Section
Then I should be able to enter only numeric values in the Shipping To Section
And I should be able to enter a numeric value with leading zero(s) in the Shipping To Section
And the minimum field length is five in the Shipping To Section
And the maximum field length is five in the Shipping To Section

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping From Section when the entered zipcode exists in the zip lookup for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
And Country selected is United States in the Shipping From section
When I enter a zipcode in the Enter zip/postal code field in the Shipping From section that is found in zip lookup
Then the city and state fields in the Shipping From section should be auto filled with the corresponding city and state associated with the zip code
And I should be able to edit the city field in the Shipping From section
And I should be able to select the state from the drop down list in the Shipping From section

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping From Section when the entered zipcode exists in the zip lookup for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
And Country selected is United States in the Shipping From section
When I enter a zipcode in the Enter zip/postal code field in the Shipping From section that is found in zip lookup
Then the city and state fields in the Shipping From section should be auto filled with the corresponding city and state associated with the zip code
And I should be able to edit the city field in the Shipping From section
And I should be able to select the state from the drop down list in the Shipping From section

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping From Section when the entered zipcode exists in the zip lookup for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
And Country selected is United States in the Shipping From section
When I enter a zipcode in the Enter zip/postal code field in the Shipping From section that is found in zip lookup
Then the city and state fields in the Shipping From section should be auto filled with the corresponding city and state associated with the zip code
And I should be able to edit the city field in the Shipping From section
And I should be able to select the state from the drop down list in the Shipping From section

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping To Section when the entered zipcode exists in the zip lookup for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
And Country selected is United States in the Shipping To section
When I enter a zipcode in the Enter zip/postal code field in the Shipping To section that is found in zip lookup
Then the city and state fields in the Shipping To section should be auto filled with the corresponding city and state associated with the zip code
And I should be able to edit the city field in the Shipping To section
And I should be able to select the state from the drop down list in the Shipping To section

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping To Section when the entered zipcode exists in the zip lookup for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
And Country selected is United States in the Shipping To section
When I enter a zipcode in the Enter zip/postal code field in the Shipping To section that is found in zip lookup
Then the city and state fields in the Shipping To section should be auto filled with the corresponding city and state associated with the zip code
And I should be able to edit the city field in the Shipping To section
And I should be able to select the state from the drop down list in the Shipping To section

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping To Section when the entered zipcode exists in the zip lookup for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
And Country selected is United States in the Shipping To section
When I enter a zipcode in the Enter zip/postal code field in the Shipping To section that is found in zip lookup
Then the city and state fields in the Shipping To section should be auto filled with the corresponding city and state associated with the zip code
And I should be able to edit the city field in the Shipping To section
And I should be able to select the state from the drop down list in the Shipping To section

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping From Section when the entered zipcode not exists in the zip lookup for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
And Country selected is United States in the Shipping From section
When I enter a zipcode in the Enter zip/postal code field in the Shipping From section that is not found in zip lookup
Then the zipcode field in the Shipping From section should be highlighted in red

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping From Section when the entered zipcode not exists in the zip lookup for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
And Country selected is United States in the Shipping From section
When I enter a zipcode in the Enter zip/postal code field in the Shipping From section that is not found in zip lookup
Then the zipcode field in the Shipping From section should be highlighted in red

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping From Section when the entered zipcode not exists in the zip lookup for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
And Country selected is United States in the Shipping From section
When I enter a zipcode in the Enter zip/postal code field in the Shipping From section that is not found in zip lookup
Then the zipcode field in the Shipping From section should be highlighted in red

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping To Section when the entered zipcode not exists in the zip lookup for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
And Country selected is United States in the Shipping To section
When I enter a zipcode in the Enter zip/postal code field in the Shipping To section that is not found in zip lookup
Then the zipcode field in the Shipping To section should be highlighted in red

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping To Section when the entered zipcode not exists in the zip lookup for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
And Country selected is United States in the Shipping To section
When I enter a zipcode in the Enter zip/postal code field in the Shipping To section that is not found in zip lookup
Then the zipcode field in the Shipping To section should be highlighted in red

@Regression
Scenario: 76077_Verify the auto population of the City and State field in Shipping To Section when the entered zipcode not exists in the zip lookup for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
And Country selected is United States in the Shipping To section
When I enter a zipcode in the Enter zip/postal code field in the Shipping To section that is not found in zip lookup
Then the zipcode field in the Shipping To section should be highlighted in red

@Regression
Scenario Outline: 76077-Verify zip code not accepts the alpha numeric values when Country Selected is United States in Shipping From Section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrive on the <Customer> Add Shipment LTL page for <UserType> user
And Country selected is United States in the Shipping From section
When I enter alpha numeric value in zip code field of Shipping From section
Then Zip code field should not accept the alphabets in the Shipping From section
Examples: 
| UserType | Customer                 |
| External | ZZZ - GS Customer Test   |
| Internal | ZZZ - Czar Customer Test |
| Sales    | ZZZ - GS Demo            |

@Regression
Scenario Outline: 76077-Verify zip code not accepts more then 5 maximum length of numeric values when Country Selected is United States in Shipping From Section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrive on the <Customer> Add Shipment LTL page for <UserType> user
And Country selected is United States in the Shipping From section
When I enter more than five digits in zip code field of Shipping From section
Then zip code should accepts only five digits in the Shipping From section
Examples: 
| UserType | Customer                 |
| External | ZZZ - GS Customer Test   |
| Internal | ZZZ - Czar Customer Test |
| Sales    | ZZZ - GS Demo            |
