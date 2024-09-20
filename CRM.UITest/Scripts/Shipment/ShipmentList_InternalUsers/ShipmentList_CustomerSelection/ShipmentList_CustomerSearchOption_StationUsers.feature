@Sprint71 @29467
Feature: ShipmentList_CustomerSearchOption_StationUsers

@GUI
Scenario Outline: 29467 - Verify the search functionality for customer in customer dropdown list
Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
When I am on the Shipment List page,
Then I have the option to search for customers <SearchOption> in which I am associated from the customer drop down list

Examples: 
| Scenario | Username         | Password | SearchOption        |
| S1       | stationown       | Te$t1234 | ZZZTestArnold       |
| S2       | Opstage@user.com | Te$t1234 | Test Sales Other 01 |
| S3       | salesm@test.com  | Te$t1234 | 85SP03-Jim Davis    |
| S4       | kavyarao.ms      | Te$t1234 | Dunkin Donuts       |

@GUI
Scenario Outline: 29467 - Verify the search functionality for station in customer dropdown list
Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
When I am on the Shipment List page,
Then I have the option to search for station <SearchOption> in which I am associated from the customer drop down list

Examples: 
| Scenario | Username         | Password | SearchOption            |
| S1       | stationown       | Te$t1234 | ZZZ - Web Services Test |
| S2       | Opstage@user.com | Te$t1234 | 32-Appleton WI          |
| S3       | salesm@test.com  | Te$t1234 | 85-Birmingham AL        |
| S4       | kavyarao.ms      | Te$t1234 | ENT - Bolingbrook IL    |

@GUI
Scenario Outline: 29467 - Verify the search box when number of customers is less than 10
Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
When I am on the Shipment List page,
Then I will not see search box when number of customers is less than 10

Examples: 
| Scenario | Username         | Password |
| S1       | stationown       | Te$t1234 |
| S2       | Opstage@user.com | Te$t1234 |
| S3       | salesm@test.com  | Te$t1234 |
| S4       | kavyarao.ms      | Te$t1234 |
