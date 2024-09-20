@21566 @Sprint63 @DashboardDisplayStationSummary 
Feature: Dashboard-DisplayStationSummary_Desktop

@GUI @Functional @Regression @fixed
Scenario: Verify that user can able to navigate to the Dashboard landing page once user successfully logged into CRM
	Given I am a shp.entry, operations, sales, sales management or station user  
	When I am landing on DLS Worldwide homepage with RRD logo
	Then I should arrive on the Dashboard landing page

@GUI
Scenario Outline: Verify the Dashboard landing page is displaying correctly for Station Owner
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I should see the PendingCSR '<PendingCSR>' section
	And I should see the StationSummery '<StationSummery>' section
	And The Station Summary section should contain the '<StationMonthlyBreakdown>' report
	And I should see a '<ViewAccountMetrics>' button above the CSR section

	Examples: 
	| Scenario | Username    | Password | PendingCSR   | StationSummery  | StationMonthlyBreakdown   | ViewAccountMetrics   |
	| S1       | teststation | Te$t1234 | PENDING CSRs | STATION SUMMARY | Station Monthly Breakdown | View Account Metrics |

@GUI @Acceptance
Scenario Outline: Verify the Dashboard landing page except Station Owner user for all Internal users logged into CRM application
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I should see the PendingCSR '<PendingCSR>' section
	And I should not see a '<ViewAccountMetrics>' button above the CSR section
	And I should not see StationSummery '<StationSummery>' section

	Examples: 
	| Scenario | Username           | Password | PendingCSR   | ViewAccountMetrics   | StationSummery  |
	| S1       | sales              | Te$t1234 | PENDING CSRs | View Account Metrics | STATION SUMMARY |
	| s2       | Oper               | Te$t1234 | PENDING CSRs | View Account Metrics | STATION SUMMARY |
	| s3       | swathibalaiah      | Te$t1234 | PENDING CSRs | View Account Metrics | STATION SUMMARY |
	| s4       | vpricingconfig1234 | Te$t1234 | PENDING CSRs | View Account Metrics | STATION SUMMARY |
	| s5       | vsysconfig1234     | Te$t1234 | PENDING CSRs | View Account Metrics | STATION SUMMARY |
	| s6       | crmSystemAdmin     | Te$t1234 | PENDING CSRs | View Account Metrics | STATION SUMMARY |

@GUI @Functional
Scenario Outline: Verify user navigates to the Account Metrics page of the Reports module by clicking on the View Account Metrics
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	And I Click on the View Account Metrics button
	Then I will be navigated to the Account Metrics page<AccountMetrics_text>

	Examples: 
	| Scenario | Username    | Password | AccountMetrics_text |
	| S1       | teststation | Te$t1234 | Account Metrics     |

@GUI @Acceptance
Scenario Outline: Verify that Dashboard landing page when station owner user don’t have Tabular URL claim
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I should see the PendingCSR '<PendingCSR>' section
	And I should see a '<ViewAccountMetrics>' button above the CSR section
	And User '<Username>' should not see the StationSummery '<StationSummery>' section

	Examples: 
	| Scenario | Username    | Password | PendingCSR   | ViewAccountMetrics   | StationSummery  |
	| S1       | stat        | Te$t1234 | PENDING CSRs | View Account Metrics | STATION SUMMARY |
	| S2       | teststation | Te$t1234 | PENDING CSRs | View Account Metrics | STATION SUMMARY |


