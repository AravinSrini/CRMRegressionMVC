@39149 @NinjaSprint19
Feature: Customer Invoice - Make Payment Button

@GUI @Functional
Scenario Outline: 39149_Verify auto login & launch the PNC website from the Make Payment Button
Given I am a shp.entry or shp.inquiry user with access to Payment <userName> and <password>
And I am on the Customer Invoice page
When I click on the Make Payment button
Then I will be auto login & launch the PNC website in a new browser tab

Examples: 
| scenario | userName | password | 
| s1       | both     | Te$t1234 | 
