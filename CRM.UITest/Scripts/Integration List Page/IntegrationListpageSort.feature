@Sprint75 @34276 

Feature: IntegrationListpageSort
	

@GUI @Functionality
Scenario Outline: Verify the column sort functionality of Station column
 Given I am an system admin, operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 And I select display type from the '<dropdown>' in the Integration List page
 Then I should be able to view and sort Station values in ascending and descending order
 
Examples: 
| Scenario | Username    | Password | dropdown |
| S1       | stationown  | Te$t1234 | ALL      |
| S2       | systemadmin | Te$t1234 | ALL      |


 @GUI @Functionality
Scenario Outline: Verify the column sort functionality of Company Name column
 Given I am an system admin, operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 And I select display type from the '<dropdown>' in the Integration List page
 Then I should be able to view and sort Company name values in ascending and descending order

 Examples: 
| Scenario | Username     | Password | dropdown |
| S1       | SalesManager | Te$t1234 | ALL      |
| S2       | systemadmin  | Te$t1234 | ALL      |

@GUI @Functionality
Scenario Outline: Verify the column sort functionality of Current Status column
 Given I am an system admin, operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 And I select display type from the '<dropdown>' in the Integration List page
 Then I should be able to view and sort Current Status values in ascending and descending order
 Examples: 
| Scenario | Username     | Password | dropdown |
| S1       | SalesManager | Te$t1234 | ALL      |
| S2       | systemadmin  | Te$t1234 | ALL      |


@GUI @Functionality
Scenario Outline: Verify the column sort functionality of Submit Date column
 Given I am an system admin, operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 And I select display type from the '<dropdown>' in the Integration List page
 Then I should be able to view and sort Submit Date values in ascending and descending order
 Examples: 
| Scenario | Username    | Password | dropdown |
| S1       | stationown  | Te$t1234 | ALL      |
| S2       | systemadmin | Te$t1234 | ALL      |

@GUI @Functionality
Scenario Outline: Verify the column sort functionality of Last Date column
 Given I am an system admin, operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
  And I select display type from the '<dropdown>' in the Integration List page
 Then I should be able to view and sort Last Date values in ascending and descending order
 Examples: 
| Scenario | Username    | Password | dropdown |
| S1       | stationown  | Te$t1234 | ALL      |
| S2       | systemadmin | Te$t1234 | ALL      |