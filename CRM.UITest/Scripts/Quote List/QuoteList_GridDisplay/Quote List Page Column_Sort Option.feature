@26658 @Sprint67
Feature: Quote List Page Column_Sort Option

@GUI @Functional
Scenario Outline: Verify sort functionality for Date Submitted coloumn in the grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I select display type from the '<dropdown>'
	Then I should be able to view and sort Date submitted column values in ascending and descending order 

Examples: 
| Username              | Password | dropdown |
| crmOperation@user.com | Te$t1234 | ALL      |

@GUI @Functional
Scenario Outline: Verify sort functionality for Station/Customer name coloumn in the grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I select display type from the '<dropdown>'
	Then I should be able to view and sort Station/Customer name values in ascending and descending order

Examples: 
| Username              | Password | dropdown |
| crmOperation@user.com | Te$t1234 | ALL      |

@GUI @Functional
Scenario Outline: Verify sort functionality for Request Number coloumn in the grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I select display type from the '<dropdown>'
	Then I should be able to view and sort Request Number column values in ascending and descending order

Examples: 
| Username              | Password | dropdown |
| crmOperation@user.com | Te$t1234 | ALL      |

@GUI @Functional
Scenario Outline: Verify sort functionality for Status coloumn in the grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I select display type from the '<dropdown>'
	Then I should be able to view and sort Status column values in ascending and descending order

Examples: 
| Username              | Password | dropdown |
| crmOperation@user.com | Te$t1234 | ALL      |

@GUI @Functional
Scenario Outline: Verify sort functionality for Service coloumn in the grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I select display type from the '<dropdown>'
	Then I should be able to view and sort Service column values in ascending and descending order

Examples: 
| Username              | Password | dropdown |
| crmOperation@user.com | Te$t1234 | ALL      |

@GUI @Functional
Scenario Outline: Verify sort functionality for Carrier Name coloumn in the grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I select display type from the '<dropdown>'
	Then I should be able to view and sort Carrier Name column values in ascending and descending order

Examples: 
| Username              | Password | dropdown |
| crmOperation@user.com | Te$t1234 | ALL      |

@GUI @Functional
Scenario Outline: Verify sort functionality for Rates coloumn in the grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I select display type from the '<dropdown>'
	Then I should be able to view and sort Rates column values in ascending and descending order

Examples: 
| Username              | Password | dropdown |
| crmOperation@user.com | Te$t1234 | ALL      |