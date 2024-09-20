@Regression @Quote @Sprint75 @29466

Feature: QuoteListCustomerSearchFeature_StationUsers
	
@GUI
Scenario Outline: 29466 - Verify the search functionality for customer in customer dropdown list
Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
When I click on the Quote Icon
And I click on customer drop down list
Then Customer search option should be visible

Examples: 
| Scenario | Username         | Password | 
| S1       | stationown       | Te$t1234 | 
| S2       | Opstage@user.com | Te$t1234 | 
| S3       | salesm@test.com  | Te$t1234 | 
| S4       | CrmalpsalesUser  | Te$t4545 | 



@GUI @Functional
Scenario Outline: 29466 - Verify the customers are listed alphabetically within each station
Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
When I am on the Quote List page
Then associated customers should be listed alphabetically for station

Examples: 
| Scenario | Username         | Password | SearchOption         |
| S1       | stationown       | Te$t1234 | ENT - Bolingbrook IL |
| S2       | Opstage@user.com | Te$t1234 | 32-Appleton WI       |
| S3       | salesm@test.com  | Te$t1234 |                      |
| S4       | CrmalpsalesUser  | Te$t4545 |                      |


@GUI
Scenario Outline: 29466 - Verify the search box when number of customers is less than 10
Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
When I am on the Quote List page
Then I should not see search box when number of customers is less than ten

Examples: 
| Scenario | Username         | Password |
| S1       | SpoperationTest  | Te$t1234 |