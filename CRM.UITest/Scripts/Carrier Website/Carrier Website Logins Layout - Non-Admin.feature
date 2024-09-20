@CarrierWebsiteLoginLayout_Non_Admin @30605 @Sprint72 

Feature: Carrier Website Logins Layout - Non-Admin
	

@GUI
Scenario Outline: Verify the Carrier Website Login page Layout for Non Admin user
	Given I am a Operations, Station Owner or System Configuration user - <Username>, <Password>
	When I am on the Carrier Website Logins page for the non admin user
	Then I see the RRD DLS Worldwide logo
	And I see the my credentials on the Carrier Website Login page <Username>
	And I should see the column names as SCAC, Carrier Name, Account Number, Website , Login, Password and Notes Column
	And I should see all columns SCAC, Carrier Name, Account Number, Website with option Copy to Clipboard icon, Login with Copy to Clipboard icon, Password with Copy to Clipboard icon and Notes Column 
	And I should see the Search Text Box
	And I should be able to view <Options> under dropdown in top grid of Carrier Website Login page
	

Examples: 
| Scenario | Username     | Password | Options          |
| S1       | stationown   | Te$t1234 | 10,20,60,100,ALL |
| S2       | admin        | Te$t1234 | 10,20,60,100,ALL |
| S3       | crmOperation | Te$t1234 | 10,20,60,100,ALL |

@GUI
Scenario Outline: Verify the Carrier Website Login page data with DB for Non Admin user
	Given I am a Operations, Station Owner or System Configuration user - <Username>, <Password>
	When I am on the Carrier Website Logins page for the non admin user
	Then the data displayed in the grid should match with the DB
	Examples: 
| Scenario | Username     | Password | 
| S1       | stationown   | Te$t1234 | 
| S2       | admin        | Te$t1234 | 
| S3       | crmOperation | Te$t1234 | 