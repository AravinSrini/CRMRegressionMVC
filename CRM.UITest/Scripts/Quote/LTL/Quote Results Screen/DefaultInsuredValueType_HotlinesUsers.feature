@Sprint1_Ninja @29152 
Feature: DefaultInsuredValueType_HotlinesUsers
   
@Regression
Scenario Outline: Verify default selected insured type in the quote results page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Item information section<Classification>, <Weight> for internal users
And I click on view quote results button
Then Insured Value type should be default to used type in ltl quote results page

Examples: 
| Scenario | Username | Password | Service | SFZiporpostal | STZiporPostal | Classification | Weight |
| S1       | nat      | Te$t1234 | LTL     | 33126         | 85282         | 70             | 100    |
| S2       | cusgs    | Te$t1234 | LTL     | 33126         | 85282         | 70             | 100    |


@Regression
Scenario Outline: Try to change the selected insured type in the quote results page and verify
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Item information section<Classification>, <Weight> for internal users
And I click on view quote results button
Then I Enter valid data in <EnterInsuredValue> field
And I must be displayed with <InsuredType> dropdown
Then selected <InsuredType> should be displayed in the insured type dropdown in quote results screen

Examples: 
| Scenario | Username | Password | Service | SFZiporpostal | STZiporPostal | Classification | Weight | EnterInsuredValue | InsuredType |
| S1       | nat      | Te$t1234 | LTL     | 33126         | 85282         | 70             | 100    | 100               | New         |
| S2       | cusgs    | Te$t1234 | LTL     | 33126         | 85282         | 70             | 100    | 100               | New         |
