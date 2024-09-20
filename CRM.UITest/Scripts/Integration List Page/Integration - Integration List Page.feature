@Sprint75 @34271
Feature: Integration - Integration List Page
 

@GUI
Scenario Outline: 34271_Verify user is able to see the companies under stations that are assigned to the user_S1 
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then User should see only requests of companies under Station(s) that are assigned to me <StationName>

Examples: 
| Scenario | UserName    | Password | StationName             |
| S1       | stationown  | Te$t1234 | ZZZ - Web Services Test |
| S2       | systemadmin | Te$t1234 | ZZZ - Web Services Test |


@GUI
Scenario Outline: 34271_Verify page elements and buttons on the Integration List page_S2
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then I should be see Submit Integration Request Button
 And I should be see the Export button
 And I should see the search field with search text box
 And I should see the filter radio buttons All, Pending Approval, In Progress , Completed

 Examples: 
| Scenario | UserName    | Password |
| S1       | stationown  | Te$t1234 |
| S2       | systemadmin | Te$t1234 |


@GUI
Scenario Outline: 34271_Verify Grid display view forward navigation functionality on top grid of the Integration List page_S3 
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then only ten records should be displayed by default in Integration List page 
 And verify the options <Options> when I click on the view list top grid 
 And Verify the forward navigation functionality on the top grid
 
 Examples: 
| Scenario | UserName    | Password | Options          |
| S1       | stationown  | Te$t1234 | 10,20,60,100,ALL |
| S2       | systemadmin | Te$t1234 | 10,20,60,100,ALL |

@GUI
Scenario Outline: 34271_Verify Grid display view backward navigation functionality on top grid of the Integration List page_S4 
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then only ten records should be displayed by default in Integration List page 
 And verify the options <Options> when I click on the view list top grid  
 And I click on the backword navigation icon in the top grid of the Integration List page
 
 Examples: 
| Scenario | UserName     | Password | Options          |
| S1       | SalesManager | Te$t1234 | 10,20,60,100,ALL |
| S2       | systemadmin  | Te$t1234 | 10,20,60,100,ALL |
| S3       | stationown   | Te$t1234 | 10,20,60,100,ALL |


@GUI
Scenario Outline: 34271_Verify column names on the Integration List page_S5 
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then Verify the Column names on the Integration list page
 Examples: 
| Scenario | UserName    | Password |
| S1       | stationown  | Te$t1234 |
| S2       | systemadmin | Te$t1234 |


@GUI
Scenario Outline: 34271_Verify the color code of the status Pending Approval on the Integration List page_S6
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then Verify the color code of the status on the Integration list page
 Examples: 
| Scenario | UserName    | Password |
| S1       | stationown  | Te$t1234 |
| S2       | systemadmin | Te$t1234 |


@GUI
Scenario Outline: 34271_Verify the color code of the status In Progress on the Integration List page_S7 
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then Verify the color code of the status of the In progress on the Integration list page 
 Examples: 
| Scenario | UserName     | Password |
| S1       | SalesManager | Te$t1234 |
| S2       | systemadmin  | Te$t1234 |


@GUI
Scenario Outline: 34271_Verify the color code of the status Completed on the Integration List page_S8 
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then Verify the color code of the status of the Completed on the Integration list page 
 Examples: 
| Scenario | UserName     | Password |
| S1       | SalesManager | Te$t1234 |
| S2       | systemadmin | Te$t1234 |

@GUI
Scenario Outline: 34271_Verify the detail icon and default selection on the Integration List page_S9
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then Verify each row has the details icon
 
 Examples: 
| Scenario | UserName     | Password |
| S1       | SalesManager | Te$t1234 |
| S2       | systemadmin  | Te$t1234 |





@GUI
Scenario Outline: 34271_Verify details on the Integration List page for Operation, sales and station owner users_S10
    Given I am an operations, sales, or station owner user <Username> and <Password>
    When I am on the Integration List page
    And I click on the filter by status Pending Approval radio button 
	And I expand the first record details
	Then I should be displayed with Status Bar and current status highlighted
	And I can see Pending Approval includes the respective stages
	And I can see Company Contact Name, Company Contact Phone and Company Contact Email 
	And I can see IT/developer contact name,IT/developer Contact phone and IT/developer email 
	And I can see Type of Integration, Year to Date shipments and Year to Date Revenue  
	And I can be Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status 
	And I can see the integration notes of Comment, Commenter, Date/Time and Public/Private
    

Examples: 
| Scenario | Username         | Password |
| S1       | stationown       | Te$t1234 |
| S2       | SalesManager     | Te$t2323 |

@GUI
Scenario Outline: 34271_Verify search functionality on the Integration List page_S11
 Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
 When I am on the Integration List page
 Then Grid should display the entered <EnterData> and should be highlighted

 Examples: 
| Scenario | UserName    | Password | EnterData          |
| S1       | stationown  | Te$t1234 | Jenns Acct         |
| S2       | systemadmin | Te$t1234 | 85 - Birmingham AL |


@GUI
Scenario Outline: 34271_verify the default status selection on Integration List page_12
Given I am a operations, sales, sales management,station owner or systemadmin user <UserName> and <Password>
When I am on the Integration List page
Then Verify the default status selection on the Integration list page
Examples: 
| Scenario | UserName     | Password |
| S1       | SalesManager | Te$t1234 |
| S2       | systemadmin  | Te$t1234 |