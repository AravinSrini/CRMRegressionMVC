@Sprint63 @21568 @DashboardCSRChart 
Feature: Dashboard_DisplayPendingCSRsUI_NavigateToCSRListOnChartClick

@Functional @DBVerification @Regression @fixed
Scenario: Verify the display a chart of the CSR statuses for Station Owner, Operations, Sales and Sales Management User
	Given I am sales user
	When I arrive on the Dashboard landing page
	Then I will see a Pending CSR section
	And Pending CSR section will display a chart of the CSR statuses of all open CSR’s for which <Username> Station Owner, Operations, Sales and Sales Management Users is assosiated
	And Total assosiated CSR's count will be displayed in the center of the chart

@Functional @DBVerification @Regression
Scenario Outline: Verify the display a chart of the CSR statuses for system configuration user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I will see a Pending CSR section
	And Pending CSR section will display a chart of the CSR statuses of all open CSR’s for which system configuration user is assosiated
	And Total assosiated CSR's count will be displayed in the center of the chart

Examples: 
| Scenario | Username          | Password     |
| S1       | Arunmanikumar1234 | Password@123 |

@Functional @DBVerification
Scenario Outline: Verify the display a chart of the CSR statuses for pricing configuration user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I will see a Pending CSR section
	And Pending CSR section will display a chart of the CSR statuses of all open CSR’s for which pricing configuration user is assosiated
	And Total assosiated CSR's count will be displayed in the center of the chart

Examples: 
| Scenario | Username | Password |
| S1       | pricuser | Te$t1234 |

@Functional @DBVerification
Scenario Outline: Verify the display a chart of the CSR statuses for system admin user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I will see a Pending CSR section
	And Pending CSR section will display a chart of the CSR statuses of all open CSR’s for which system admin user is assosiated
	And Total assosiated CSR's count will be displayed in the center of the chart

Examples: 
| Scenario | Username               | Password               |
| S1       | kavya.suryanarayanarao | kavya.suryanarayanarao |

@Functional @DBVerification
Scenario Outline: Verify the hover over functionality on status chart
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then I will see a Pending CSR section
	And I hover over a CSR status on the chart for the <Status>
	And the corresponding portion of data within the chart will be enlarged slightly to illustrate the connection and the data displayed in the center will reflect the number of CSR's for the corresponding CSR status

Examples: 
| Scenario | Username               | Password               | Status                            |
| S1       | kavya.suryanarayanarao | kavya.suryanarayanarao | In Progress                       |
| S2       | kavya.suryanarayanarao | kavya.suryanarayanarao | Pending Regional Manager Approval |
| S3       | kavya.suryanarayanarao | kavya.suryanarayanarao | Pending System Configuration      |
| S4       | kavya.suryanarayanarao | kavya.suryanarayanarao | Pending Pricing Configuration     |
| S5       | kavya.suryanarayanarao | kavya.suryanarayanarao | Denied                            |

@Functional @GUI
Scenario Outline: Verify the CSR list when Pending regional manager status is selected from dashboard
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	And I click on Pending regional manager status from the chart 
	Then I will navigate to CSR list 
	And CSR’s of the selected status <Status> will be displayed and count should match from dashboard

Examples: 
| Scenario | Username               | Password               | Status                            |
| S1       | kavya.suryanarayanarao | kavya.suryanarayanarao | Pending Regional Manager Approval |

@Functional @GUI
Scenario Outline: Verify the CSR list when In Progress status is selected from dashboard
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	And I click on In Progress status from the chart 
	Then I will navigate to CSR list 
	And CSR’s of the selected status <Status> will be displayed and count should match from dashboard

Examples: 
| Scenario | Username               | Password               | Status      |
| S1       | kavya.suryanarayanarao | kavya.suryanarayanarao | In Progress |

@Functional @GUI
Scenario Outline: Verify the CSR list when Denied status is selected from dashboard
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	And I click on Denied status from the chart 
	Then I will navigate to CSR list 
	And CSR’s of the selected status <Status> will be displayed and count should match from dashboard

Examples: 
| Scenario | Username               | Password               | Status |
| S1       | kavya.suryanarayanarao | kavya.suryanarayanarao | Denied |

@Functional @GUI 
Scenario Outline: Verify the CSR list when Waiting to Process status is selected from dashboard
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	And I click on Waiting to Process status from the chart 
	Then I will navigate to CSR list 
	And CSR’s of the selected status <Status> will be displayed and count should match from dashboard

Examples: 
| Scenario | Username               | Password               | Status             |
| S1       | kavya.suryanarayanarao | kavya.suryanarayanarao | Waiting to Process |

@Functional @GUI
Scenario Outline: Verify the CSR list when Pending System Configuration status is selected from dashboard
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	And I click on Pending System Configuration status from the chart 
	Then I will navigate to CSR list 
	And CSR’s of the selected status <Status> will be displayed and count should match from dashboard

Examples: 
| Scenario | Username               | Password               | Status                       |
| S1       | kavya.suryanarayanarao | kavya.suryanarayanarao | Pending System Configuration |

@Functional @GUI
Scenario Outline: Verify the CSR list when Pending Pricing Configuration status is selected from dashboard
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	And I click on Pending Pricing Configuration status from the chart 
	Then I will navigate to CSR list 
	And CSR’s of the selected status <Status> will be displayed and count should match from dashboard

Examples: 
| Scenario | Username               | Password               | Status                        |
| S1       | kavya.suryanarayanarao | kavya.suryanarayanarao | Pending Pricing Configuration |

@Functional @GUI
Scenario Outline: Verify the CSR chart when no CSR exists for the user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I arrive on the Dashboard landing page
	Then zero will be displayed in the center of the chart
	And pie circle will display in gray color

Examples: 
| Scenario | Username | Password |
| S1       | noacc123 | Te$t1234 |





