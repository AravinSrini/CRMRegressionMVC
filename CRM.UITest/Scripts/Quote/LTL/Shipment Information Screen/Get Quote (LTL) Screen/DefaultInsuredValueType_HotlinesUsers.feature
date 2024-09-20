@Sprint1_Ninja @28142 
Feature: DefaultInsuredValueType_HotlinesUsers

@Regression @109060 @24869
Scenario Outline: Verify the default selected insured value type in get quote LTL screen 
   Given I am a DLS auto-login user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   And I am taken to the new responsive Get Quote LTL screen
   When I enter a value in the Enter Insured Value field <Insuredvalue>
   Then Insured Value type should be default to used type in Get Quote ltl screen

Examples: 
| Username   | Password | Service | Insuredvalue |
| deltashpen | Te$t1234 | LTL     | 100          |

   
@Regression
Scenario Outline: Try to change the insured value type dropdown and verify
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter data in <Insuredvalue> field 
   And I select any of the type from '<InsuredvalueType>' dropdown
   Then passed '<InsuredvalueType>' valud should be selected in the dropdown

Examples: 
| Scenario | Username | Password | Service | InsuredvalueType | Insuredvalue |
| S1       | nat      | Te$t1234 | LTL     | New              | 100          |
| S2       | cusgs    | Te$t1234 | LTL     | New              | 100          |
