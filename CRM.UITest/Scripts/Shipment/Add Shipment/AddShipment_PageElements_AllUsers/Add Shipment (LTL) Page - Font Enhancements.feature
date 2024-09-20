@40121 @NinjaSprint13

Feature: Add Shipment (LTL) Page - Font Enhancements

@GUI
Scenario Outline: 40121_Verify font size of elements will be increased to size 20 for external users
Given  I am a DLS user of type <UserType> and login into application
When I click on the Shipment Icon
And I click on add shipment depending on the UserType <UserType>
And I Select the LTL tile
And I arrive on the Add Shipment Ltl page
Then I Verify font-size will be increased to Twenty and font-color will be black for all fields


Examples: 
| Scenario | UserType |
|   s1     | external |


@GUI
Scenario Outline: 40121_Verify font size of elements will be increased to size 20 for internal users
Given  I am a DLS user of type <UserType> and login into application
When I click on the Shipment Icon
And I select <CustomerAccName> from the dropdown and click on add shipment button
And I Select the LTL tile
And I arrive on the Add Shipment Ltl page
Then I Verify font-size will be increased to Twenty and font-color will be black for all fields

Examples: 
| Scenario | UserType | CustomerAccName        |
| s1       | internal | ZZZ - GS Customer Test |
