@Sprint74 @35207
Feature: Master Carrier Rate Settings - Add Master Accessorial Charge field
@GUI 
Scenario Outline:35207_Verify Master Accessorial Charge field
Given I am a system admin or pricing user <userName> and <password>
And I am on Master Carrier Rate Settings Page
When I have selected the'<customerName>'
Then I will have an option to enter Master Accessorial Charge with percentage 
And I will be displayed withMaster Accessorial Charge button right of Master Accessorial Charge textbox

Examples: 
| userName       | password | customerName             |
| systemadmin    | Te$t1234 |ZZZ - Czar Customer Test  |

@DBVerification 
Scenario Outline:35207_Verify the Master Accessorial Charge Values in Database for carriers
Given I am a system admin or pricing user <userName> and <password>
And I am on Master Carrier Rate Settings Page
When I have selected the'<customerName>'
And I have selected one or more carriers
And I have entered value in the '<masterAccVal>' Master Accessorial Charge field
When I click on Master Accessorial Charge button
Then Master Accessorial Chargevalue '<masterAccVal>' for the selected carriers '<carrierName>' of '<customerName>' should be saved in Database 

Examples: 
| userName        | password | customerName             | masterAccVal | carrierName            |
| systemadmin     | Te$t1234 |ZZZ - Czar Customer Test  |50.00         |A&B Freight Line Inc    |

@Functional @GUI
Scenario Outline:35207_Verify the grid when user entered Master Accessorial Charge Value for carriers
Given I am a system admin or pricing user <userName> and <password>
And I am on Master Carrier Rate Settings Page
When I have selected the'<customerName>'
And I have selected one or more carriers
And I have entered value in the '<masterAccVal>' Master Accessorial Charge field
When I click on Master Accessorial Charge button
Then the grid will display the '<masterAccVal>' and '<Carrier>' with updated Master Accessorial Charge values for the selected carriers 

Examples: 
| userName       | password | customerName            | masterAccVal | Carrier                     |
| systemadmin    | Te$t1234 |ZZZ - Czar Customer Test | 50.00        |A&B Freight Line Inc         |


@Functional @GUI
Scenario Outline:35207_Verify the grid when user entered Master Accessorial Charge Value for Multiple carriers
Given I am a system admin or pricing user <userName> and <password>
And I am on Master Carrier Rate Settings Page
When I have selected the'<customerName>'
And I have selected multiple carriers 
And I have entered value in the '<masterAccVal>' Master Accessorial Charge field
When I click on Master Accessorial Charge button
Then the grid will display the '<masterAccVal>' with updated Master Accessorial Charge values for the selected multiple carriers 

Examples: 
| userName    | password | customerName             | masterAccVal | Carrier1                  | Carrier2                  | Carrier3              |
| systemadmin | Te$t1234 | ZZZ - Czar Customer Test | 50.00        | A&B Freight Line Inc      | AAA Cooper Transportation | Benjamin Best Freight |

