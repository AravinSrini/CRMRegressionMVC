@Dashboard_AddbuttonsinDashboard_GoToCsrs_ViewAccountMetrics_CreateCSR @21567 @Sprint63 
Feature: Dashboard_AddbuttonsinDashboard_GoToCsrs_ViewAccountMetrics_CreateCSR

@GUI @Acceptance
Scenario Outline: Verify the presence of View Account Metrics button
Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
Then I will be see View Account Metrics button<ViewAccountMetrics>based on User types<UserType>
Examples: 
	| Scenario | Username                  | Password | ViewAccountMetrics   | UserType       |
	| s1       | Stationtest@rrd.com       | Te$t1234 | View Account Metrics | StationUser    |
	| s2       | tst0011.sysadmn@gmail.com | Te$t1234 | View Account Metrics | NonStationUser |
	

	@GUI @Acceptance
Scenario Outline: Verify the presence of Create CSR button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I will be able to see Create CSR button<CreateCSR_text>

	Examples: 
	| Scenario | Username						   | Password		  | CreateCSR_text |
	| s1       |  tst0011.sysadmn@gmail.com        |    Te$t1234      | Create CSR     |

	@GUI @Acceptance
Scenario Outline: Verify the presence of select a CSR text in the dropdown field
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I will be able to see select a CSR text in the dropdown field <SelectAcsr_text>

	Examples: 
	| Scenario | Username                  | Password | SelectAcsr_text |
	| s1       | tst0011.sysadmn@gmail.com | Te$t1234 |Select a CSR...  |

@GUI @Acceptance
Scenario Outline: Verify the presence of Go to a CSR Text
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I will be able to see Go to a CSR Text<GoToACsr_text>

	Examples: 
	| Scenario	 | Username							 | Password			| GoToACsr_text |
	|      s1    |     tst0011.sysadmn@gmail.com     |      Te$t1234    | Go to a CSR:  |

	@Functional @Acceptance @DBVerification
Scenario Outline: Verify the Customer Name from the dropdown matches with the Database Customer name
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then the Customer Names from the dropdown matches with Database Customer Names<Username>based on the<UserType>
	
	Examples: 
	| Scenario | Username					   | Password | UserType				| 
	| s1       | OP							   | Te$t1234 | NonAdmins				|
	| s2       | tst0011.sysadmn			   | Te$t1234 | SYSAdmins				|
	#| s3       | pricuser					   | Te$t1234 | PricingConfiguration	|
	#| s4       | Arunmanikumar1234			   | Te$t1234 | SystemConfiguration		|

	@Functional @Acceptance
Scenario Outline: Verify the count of CSR from the dropdown equals the PieChart total count
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then the count of CSR from the dropdown matches with total PieChart count

	Examples: 
	| Scenario | Username				| Password | 
	| s1       | tst0011.sysadmn@gmail.com | Te$t1234 |

	@Functional @Acceptance
Scenario Outline: Verify the on click functionality of create CSR button will be navigated to Account Information page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	And I click on the create CSr button
	Then I will be navigated to the Account Information page<AccountInformation_text>

	Examples: 
	| Scenario | Username                  | Password | AccountInformation_text |
	| s1       | tst0011.sysadmn@gmail.com | Te$t1234 |Account Information		|


@Functional @Acceptance
Scenario Outline: Verify the Customer Name displayed for the search criteria applied under a CSR dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I able to search the CSR from the dropdown<Search_text>and<UserType> 
	Examples: 
	| Scenario | Username					  | Password |Search_text	   |UserType	   |
	| s1       | stationtest				  | Te$t1234 | g			   | NonAdmins	   |
	| s2       | tst0011.sysadmn@gmail.com	  | Te$t1234 | vasa            | Admins		   |


	@Functional @Acceptance
Scenario Outline: Verify the on click functionality of View Account Metrics button will be navigated to Account Metrics page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	And I Click on the View Account Metrics button
	Then I will be navigated to the Account Metrics page<AccountMetrics_text>

	Examples: 
	| Scenario | Username    | Password | AccountMetrics_text |
	| s1       | stationtest | Te$t1234 | Account Metrics     |

	@Functional @Acceptance
Scenario Outline: Verify the selection CSR from the dropdown will be navigated to the corresponding CSR Details page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then selecting of any CSR from the dropdown will be navigated to the corresponding CSR Details page

	Examples: 
	| Scenario | Username						   | Password         |
	| s1       |  tst0011.sysadmn@gmail.com        |    Te$t1234      |
