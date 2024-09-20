@36867 @sprint76  
Feature: GetQuotePage - TabbingToItemfield

@Regression 
Scenario Outline: 36867_Verify the blinking cursor in selected field after selecting the item by pressing Tab key
Given I am a shp.entry, shp.inquiry, operations, sales, sales management, or station owner user <Username>,<Password>
When  I m on Get Quote page <UserType>,<CustomerName>
And I am highlighting a class or saved item from the Select or search for a class or saved item field
When I click on the tab button
Then the blinking cursor will be displayed at the end of the description displayed in the search field for a class or saved item

Examples:
| Scenario | Username      | Password | CustomerName             |  UserType | 
| s1       | crmOperation  | Te$t1234 | ZZZ - Czar Customer Test | Internal  |


@Regression 
Scenario Outline: 36867_Verify the blinking cursor in selected field after selecting the item by clicking
Given I am a shp.entry, shp.inquiry, operations, sales, sales management, or station owner user <Username>,<Password>
When  I m on Get Quote page <UserType>,<CustomerName>
And I am highlighting a class or saved item from the Select or search for a class or saved item field
When I am entering the item value
Then the blinking cursor will be displayed at the end of the description displayed in the search field for a class or saved item

Examples:
| Scenario | Username     | Password | CustomerName             | UserType |
| s1       | crmOperation | Te$t1234 | ZZZ - Czar Customer Test | Internal |
| S1       | stationown   | Te$t1234 | ZZZ - Czar Customer Test | Internal |

