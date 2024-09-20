@36757 @Sprint75
Feature: Integration List Page - Sales Management Details

@GUI
Scenario Outline: 36757_Test to Verify the Integration List Page - Sales Management Details_Pendingapproval
	Given I am a DLS user and login into application with valid <userName> and <password>
	When I am on Integration Request List Page with title
	And I click select pendingapproval requests
	And I expanded the Integration Request
  	Then I should be display with Status Bar with current status highlighted for Pendingapproval
	And i should be displayed with Pendingapproval includes the pending RM approval
	And i should be displayed with Company Contact Name, Company Contact Phone and Company Contact Email 
	And i should be displayed with IT/developer contact name,IT/developer Contact phone and IT/developer email 
	And i should be displayed with Type of Integration, Year to Date shipments and Year to Date Revenue  
	And i should be displayed with Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status 
	And I be displaying with integration notes of Comment, Commenter, Date/Time and Public/Private

Examples: 
| scenario | userName                | password | DashboardTitle | integrationPageTitle     |
| s1       | salesmanager@stage.com  | Te$t1234 | Dashboard      | Integration Request List |

@GUI
Scenario Outline: 36757_Test to Verify the Integration List Page - Sales Management Details_Inprogress
	Given I am a DLS user and login into application with valid <userName> and <password>
	When I am on Integration Request List Page with title
	And I expanded the Integration Request
	Then I should be display with Status Bar with current status highlighted for inprogress
	And i should be displayed with In Progress includes the respective stages
	And i should be displayed with Company Contact Name, Company Contact Phone and Company Contact Email 
	And i should be displayed with IT/developer contact name,IT/developer Contact phone and IT/developer email 
	And i should be displayed with Type of Integration, Year to Date shipments and Year to Date Revenue  
	And i should be displayed with Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status 
	And I be displaying with integration notes of Comment, Commenter, Date/Time and Public/Private

Examples: 
| scenario | userName                | password | DashboardTitle | integrationPageTitle     |
| s1       | salesmanager@stage.com  | Te$t1234 | Dashboard      | Integration Request List |

@GUI
Scenario Outline: 36757_Test to Verify the Integration List Page - Sales Management Details_completed
	Given I am a DLS user and login into application with valid <userName> and <password>
	When I am on Integration Request List Page with title
	And I click select completed requests
	And I expanded the Integration Request
	Then I should be display with Status Bar with current status highlighted for completed status
	And i should be displayed with Completed includes the respective stages
	And i should be displayed with Company Contact Name, Company Contact Phone and Company Contact Email 
	And i should be displayed with IT/developer contact name,IT/developer Contact phone and IT/developer email 
	And i should be displayed with Type of Integration, Year to Date shipments and Year to Date Revenue  
	And i should be displayed with Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status 
	And I be displaying with integration notes of Comment, Commenter, Date/Time and Public/Private

Examples: 
| scenario | userName                | password | DashboardTitle | integrationPageTitle     |
| s1       | salesmanager@stage.com  | Te$t1234 | Dashboard      | Integration Request List |




