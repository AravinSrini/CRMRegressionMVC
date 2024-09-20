@Sprint75 @34271 @Ignore
Feature: Integration_IntegrationListPage
	

@GUI
Scenario Outline: Verify user is able to see the companies under stations that are assigned to the user 
 Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 Then User should see only requests of companies under Station(s) that are assigned to me

Examples: 
| Scenario | Username | Password |
| S1       |          |          |

@GUI
Scenario Outline: Verify page elements on the Integration List page 
 Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 Then Submit Integration Request Button
 And I should be see the Export button
 And I should see the search field with search text box
 And I should see the filter radio buttons All, Pending Approval, In Progress , Completed

 Examples: 
| Scenario | Username     | Password |
| S1       | SalesManager | Te$t1234 |


@GUI
Scenario Outline: Verify Grid display view forward navigation functionality on top grid of the Integration List page 
 Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 Then only ten records should be displayed by default in Integration List page 
 And verify the options <Options> when I click on the view list top grid 
 And Verify the forward navigation functionality on the top grid
 
 Examples: 
| Scenario | Username     | Password | Options          |
| S1       | SalesManager | Te$t1234 | 10,20,60,100,ALL |

@GUI
Scenario Outline: Verify Grid display view backward navigation functionality on top grid of the Integration List page 
 Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 Then only ten records should be displayed by default in Integration List page 
 And verify the options <Options> when I click on the view list top grid 
 And I click on the forword navigation icon in the top grid of the Integration List page
 And I click on the backword navigation icon in the top grid of the Integration List page
 
 Examples: 
| Scenario | Username     | Password | Options          |
| S1       | SalesManager | Te$t1234 | 10,20,60,100,ALL |


@GUI
Scenario Outline: Verify column names on the Integration List page 
 Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 Then Verify the Column names on the Integration list page
 Examples: 
| Scenario | Username | Password |
| S1       |          |          |


@GUI
Scenario Outline: Verify the color code of the status on the Integration List page 
 Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 Then Verify the color code of the status on the Integration list page
 Examples: 
| Scenario | Username | Password |
| S1       |          |          |

@GUI
Scenario Outline: Verify the sort , detail icon and default selection on the Integration List page 
 Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 Then Verify each column has sort
 And Verify each row has the details icon
 And page display is defaulted to show all records in In Progress status
 Examples: 
| Scenario | Username | Password |
| S1       |          |          |


@GUI
Scenario Outline: Verify elements on the detail icon click functionality on the Integration List page 
 Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 And I click on the details Icon
 Then I should see status bar
 And I should see Company Contact name
 And I should see Company Contact Phone
 And I should see Company Contact Email
 And I should see the It/developer Contact Name
 And I should see the IT/developer Phone 
 And I should see the IT/developer Email 
 And I should see the Type of Integration
 And I should see the Year to Date shipments 
 And I should see the Year to Date Revenue 
 And I should see the Potential Revenue
 And I should see the Additional Comments
 And I should see the Comment
 And I should see the Commenter First name last name
 And I should see the Date/Time
 

Examples: 
| Scenario | Username | Password |
| S1       |          |          |

@GUI
Scenario Outline: Verify search functionality on the Integration List page 
 Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
 When I am on the Integration List page
 And I enter any value and click on search field
 Then Grid should filter the show only the rows which contains the entered value and should be highlighted

 Examples: 
| Scenario | Username | Password |
| S1       |          |          |