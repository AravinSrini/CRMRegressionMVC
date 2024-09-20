@Sprint67 @26657
Feature: QuoteList_PageFilters

@GUI
Scenario Outline: Verify the default selected filter option for the logged in user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	Then all filter radio button should be selected by default in quote list page

Examples: 
| Scenario | Username | Password |
| S1       | zzzext   | Te$t1234 |


@GUI @Functional
Scenario Outline: Verify the filtered records when New filter radio button is selected
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select New filter radio button in quote list page
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then only new quote records should be filtered and displaying results should match with API results for the new records for <Account>

Examples: 
| Scenario | Username | Password | Option | Account                  |
| S1       | zzzext   | Te$t1234 | ALL    | ZZZ - Czar Customer Test |

@GUI @Functional
Scenario Outline: Verify the filtered records when expired filter radio button is selected
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select Expired filter radio button in quote list page
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then only expired quote records should be filtered and displaying results should match with API results for the expired records <Account>

Examples: 
| Scenario | Username | Password | Option | Account                  |
| S1       | zzzext   | Te$t1234 | ALL    | ZZZ - Czar Customer Test |  

@GUI @Functional
Scenario Outline: Verify the filtered records when past 24 houts filter radio button is selected
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select past 24 hours filter radio button in quote list page
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then only past 24 hours quote records should be filtered and displaying results should match with API results for the past 24 hours records <Account>

Examples:
| Scenario | Username | Password | Option | Account                  |
| S1       | zzzext   | Te$t1234 | ALL    | ZZZ - Czar Customer Test |

@GUI @Functional
Scenario Outline: Verify the grid when no records exists for selecting New filter radio button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select any customeraccount <Account> from the dropdown
	And I select New filter radio button in quote list page
	Then no records message should be displayed in the grid

Examples: 
| Scenario | Username   | Password | Account            |
| S1       | stationown | Te$t1234 | The Clorox Company |

@GUI @Functional
Scenario Outline: Verify the grid when no records exists for selecting expired filter radio button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select any customeraccount <Account> from the dropdown
	And I select Expired filter radio button in quote list page
	Then no records message should be displayed in the grid

Examples: 
| Scenario | Username   | Password | Account            |
| S1       | stationown | Te$t1234 | The Clorox Company |

@GUI @Functional
Scenario Outline: Verify the grid when no records exists for selecting past 24 hours filter radio button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select any customeraccount <Account> from the dropdown
	And I select past 24 hours filter radio button in quote list page
	Then no records message should be displayed in the grid

Examples: 
| Scenario | Username   | Password | Account            |
| S1       | stationown | Te$t1234 | The Clorox Company |

@53692 @Sprint88
Scenario Outline: Verify the filtered records when past 24 hours filter radio button is selected for CSA and MG	
	Given I am a user with access to Quote List Page <Usertype>
	When I click on the Quote Icon
	And I now select any customeraccount <Account> from the dropdown
	And I now Select past 24 hours filter radio button in quote list page
	And I now select any <Option> from view dropdown present in top grid of quote list page
	Then only past 24 hours of CSA and MG quote records should be filtered and the displayed results should match with API results for the past 24 hours records <Account>
Examples:
| Scenario | Option | Account                  | Usertype |
| S1       | ALL    | ZZZ - GS Customer Test   | External |
| S2       | ALL    | ZZZ - GS Customer Test   | Internal |
| S3       | ALL    | ZZZ - GS Customer Test   | Sales    |
| S4       | ALL    | TestAutoLogin            | External |

