@Sprint74 @34404 
Feature: Saved Quote to Shipment (MVC5) - Remove Density Calculator

@UI
Scenario Outline: 34404_Test to verify the Density Calculator option_remove
#Creating Quote
Given I am a shp.entry user <Username> <Password>
When I am on the Rate Results page <userType>, <customerName>, <oZip>, <dZip>, <classification> and <weight>
And   I click on save rate as quote link  for selected carrier in results page
#creating quote to shipment
Given  I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
And I click on the Create Shipment button
When I arrive on the Add Shipment LTL page
Then I should not be displayed with Estimate Class button

Examples: 
| Scenario | Username | Password | Account                  | UserType | Service | customerName              | oZip  | dZip  | classification | weight |
| S1       | zzzext   | Te$t1234 | ZZZ - Czar Customer Test | External | LTL     | ZZZ - Czar Customer Test  | 33126 | 85282 | 50             | 200    |



