@26058 @Sprint67 
Feature: Quote List Page (Layout)
	
@GUI
Scenario Outline: Verify the existence of page elements in Quote List page for Operations, Sales, Sales Management, or Station Owner user
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Quotes button
When I arrive on quotes list page
Then I must be able to view Customer selection drop down list
And I must be able to view Quotes label with the message - Submitted rate requests within the past thirty days are below.
And I must be able to view Export button
And I must be able to view a search field with dropdown and <Textsearch> options
And I must be able to view Filters with options <All>,<New>,<Expired> and <Past24Hours>

Examples: 
| Username              | Password | Textsearch | All | New | Expired | Past24Hours   |
| crmOperation@user.com | Te$t1234 | qwe        | ALL | NEW | EXPIRED | PAST 24 HOURS |

@GUI
Scenario Outline: Verify that Submit Rate Request button is not present for Internal Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Quotes button
When I arrive on quotes list page
Then I should not be able to see Submit Rate Request Button

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |

@GUI
Scenario Outline: Verify existence of Submit Rate Request button for External Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Quotes button for external users
When I arrive on quotes list page
Then I should be able to view Submit Rate Request Button

Examples: 
| Username              | Password |
| robert.j.brus@rrd.com | Te$t1234 |

@GUI
Scenario Outline: Verify the existence of Grid elements in Quote List page for Operations, Sales, Sales Management, or Station Owner user
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Quotes button
When I arrive on quotes list page
Then I must be able to view quote list Grid with display list View option
And I must have an option to select display type from the <dropdown>
And I must be able to view Display list view forward and backward page options
And The Quote List page grid should display expected header values
And The Rate field in the grid should display - <QuoteValue>,<EstCostValue>,<EstMarginValue>
And I should be able to view Quote details icon button for each row

Examples: 
| Username              | Password | QuoteValue | EstCostValue | EstMarginValue | dropdown |
| crmOperation@user.com | Te$t1234 | Quote:     | Est Cost:    | Est Margin %:  | 20       |

@GUI
Scenario Outline: Verify that Customer selection drop down list is not present in the quote list page for shp.inquiry or shp.entry user
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Quotes button for external users
When I arrive on quotes list page
Then I should not be able to view Customer selection drop down list in the quote list page

Examples: 
| Username              | Password |
| robert.j.brus@rrd.com | Te$t1234 |