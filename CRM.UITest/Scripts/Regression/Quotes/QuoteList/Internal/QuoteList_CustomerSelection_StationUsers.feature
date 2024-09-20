@Regression @Quote @26352 @Sprint67
Feature: QuoteList_CustomerSelection_StationUsers

@Functional
Scenario Outline: Compare and verify the displaying customer accounts with API
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on customer drop down list
	Then list of customers in which I am associated will be displayed and should match with API <Username>

Examples: 
| Scenario | Username   | Password |
| S1       | stationown | Te$t1234 |

@GUI
Scenario: Verify default selected option in the customer dropdown list
	Given I  login into application as StationOwner
	When I click on the Quote Icon
	Then All Customers option should be selected by default



@Functional @Regression
Scenario Outline: Compare and Verify displaying quotes in quote list page with API
	Given I  login into application as StationOwner
	When I click on the Quote Icon
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then all the associated customers past 30 days quotes should be displayed and should match with API <StationData>
Examples: 
 | Option | StationData |
| ALL    | ZZZ,ZZX     |

@Functional @Regression
Scenario Outline: Select any MG account from customer station dropdown and verify quote list with API
	Given I  login into application as StationOwner
	When I click on the Quote Icon
	And I select any customeraccount <Account> from the dropdown
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then all the associated MG quotes for the selected customer past 30 days should be displayed and should match with API <Account> 

Examples: 
| Option | Account |
 |ALL    | ZZZ - Czar Customer Test |

@Functional @Regression
Scenario Outline: Select any CSA account from customer station dropdown and verify quote list with API
	Given I  login into application as StationOwner
	When I click on the Quote Icon
	And I select any customeraccount <Account> from the dropdown
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then all the associated CSA quotes for the selected customer past 30 days should be displayed and should match with API  <Account>

Examples: 
 | Option | Account           |
| ALL    | Kim Manufacturing |

@Functional @Regression
Scenario Outline: Select any account of TMS type Both from customer station dropdown and verify quote list with API
	Given I  login into application as StationOwner
	When I click on the Quote Icon
	And I select any customeraccount <Account> from the dropdown
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then all the associated Both TMS quotes for the selected customer past 30 days should be displayed and should match with API  <Account>

Examples: 
| Option | Account                |
| ALL    | ZZZ - GS Customer Test |


@GUI
Scenario Outline: Try to select multiple accounts from customer station dropdown and verify quote list with API
	Given I  login into application as StationOwner
	When I click on the Quote Icon
	And I select any customeraccount <Account> from the dropdown
	And I select All customers from the dropdown
	And I select any customeraccount <Account1> from the dropdown
	Then recently selected <Account1> only should be binded

Examples: 
| Account           | Account1           |
| Kim Manufacturing | The Clorox Company |

@GUI @Functional
Scenario Outline: Verify the grid when user does not have any mapped accounts
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	Then quote list grid should be empty

Examples: 
| Scenario | Username        | Password |
| S1       | nostat@user.com | Te$t1234 |

@GUI @Functional
Scenario Outline: Verify the grid when user does not have past 30 days quote
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select any customeraccount <Account> from the dropdown
	Then message will be displayed in grid section along with <Account> name

Examples: 
| Scenario | Username   | Password | Account            |
| S1       | stationown | Te$t1234 | The Clorox Company |


@Functional
Scenario Outline: Compare and verify the displaying quotes with API for external users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then list of quotes displaying and should match with API <Username>

Examples: 
| Scenario | Username | Password | Option |
| S1       | zzzext   | Te$t1234 | ALL    |
