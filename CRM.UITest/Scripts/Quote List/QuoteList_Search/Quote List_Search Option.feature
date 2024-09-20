@26214 @Sprint67 
Feature: Quote List_Search Option

@GUI @Acceptance
Scenario Outline:Verify search quotes field dropdown options for Operations, Sales, Sales Management, or Station Owner user 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I click on dropdown arrow in the search field
	Then I should be able to view expected header values for internal users in search dropdown
	
Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |

@Functional @GUI
Scenario Outline:Try selecting multiple options from the search quote field dropdown and verify the same in the grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I do select display account type from the '<dropdown>'
	And I click on dropdown arrow in the search field
	Then I must be able to click on select all checkbox and unselect all the selected fields
	And I must be able to select fields such as - DateSubmitted,Requested Number,Status from the dropdown
	And I must be able to search quotes by typing Datesubmitted values in the search quote field and it should get highlighted in the grid- '<Datesubmitted>'
    And I must be able to search quotes by typing RequestedNumber values in the search quote field and it should get highlighted in the grid- '<RequestedNumber>'
	And I must be able to search quotes by typing Status values in the search quote field and it should get highlighted in the grid- '<Status>'

Examples: 
| Username              | Password | dropdown | Datesubmitted | RequestedNumber | Status |
| crmOperation@user.com | Te$t1234 | ALL      | 9             | Q               | Expired |


@GUI
Scenario Outline:Verify the existence of Clear button in the search dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I click on dropdown arrow in the search field
	Then I must be able to view Clear button in the Search dropdown

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |

@Functional
Scenario Outline:Verify the functionality of Clear buttton in the search quote field dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I click on dropdown arrow in the search field
	And I do click on Clear All button
	Then All the selected options must get cleared in the search quote field dropdown

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |


@GUI @Acceptance
Scenario Outline: Verify search quotes field dropdown options for shp.inquiry or shp.entry user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button for external users
	When I arrive on quotes list page
	And I click on dropdown arrow in the search field
	Then I must be able to view expected search dropdown values for External Users

Examples: 
| Username              | Password |
| SurShipEntry@user.com | Te$t1234 |

Scenario Outline:  Verify the note section inside Search Dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Quotes button
	When I arrive on quotes list page
	And I click on dropdown arrow in the search field
	Then I must be able to view note within Search dropdown

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |



