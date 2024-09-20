@QuoteDetailsRequoteButton @26526 @Sprint67 
Feature: QuoteDetails_RequoteButton

@GUI 
Scenario Outline: Verify the Re-quote button is present by expanding quote details section of any expired quote for non admin users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I click on Expired quote radio button
	And I click on expand button of any expired quote from quote list
	Then I must be able to see the <Re_quote> button in quote detail section

	Examples: 
	| Scenario | Username              | Password | DashboardTitle | QuoteList_Header | Re_quote |
	| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | Quote List       | Re-quote |

@GUI 
Scenario Outline: Verify the click functionality of the Re-quote button for non admin users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I click on Expired quote radio button
	And I click on expand button of any expired quote from quote list
	And I click on Re-Quote button from quote details section
	Then I must be navigated to the <GetQuoteService> page

	Examples: 
	| Scenario | Username              | Password | DashboardTitle | QuoteList_Header | GetQuoteService |
	| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | Quote List       | Get Quote (LTL) |

@GUI 
Scenario Outline: Verify the station and customer name is displayed on Get Quote (LTL) page and field is not editable for non admin users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I click on Expired quote radio button
	And I click on expand button of any expired quote from quote list
	And I click on Re-Quote button from quote details section
	And I must able to see the <GetQuoteService> page
	Then I must be able to see the Stationname CustomerName Label on page and field are non editable

	Examples: 
	| Scenario | Username              | Password | DashboardTitle | QuoteList_Header | GetQuoteService |
	| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | Quote List       | Get Quote (LTL) |

@GUI 
Scenario Outline: Verify the station and customer name is displayed on Quote Results(LTL) page and field is not editable for non admin users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I click on Expired quote radio button
	And I click on expand button of any expired quote from quote list
	And I click on Re-Quote button from quote details section
	And I must able to see the <GetQuoteService> page
	And I click on View Quote Results button
	Then Page should be navigated the <QuoteResultsService> page
	And I should see the Stationname CustomerName Label on page and field are non editable
    
	Examples: 
	| Scenario | Username              | Password | DashboardTitle | QuoteList_Header | GetQuoteService | QuoteResultsService |
	| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | Quote List       | Get Quote (LTL) | Quote Results (LTL) |

@GUI @Functional
Scenario Outline: Verify the selected station and customer name is matching on the Get Quote(LTL) page for non admin users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I click on Expired quote radio button
	And I click on expand button of any expired quote from quote list
	And I click on Re-Quote button from quote details section
	And I must able to see the <GetQuoteService> page
	Then The Selected Station and Customer Name should  match with Station and Customer Label on Get Quote(LTL) page

	Examples: 
	| Scenario | Username              | Password | DashboardTitle | QuoteList_Header | GetQuoteService |
	| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | Quote List       | Get Quote (LTL) |

@GUI @Functional
Scenario Outline: Verify the selected station and customer name is matching on the Quote Results(LTL) page for non admin users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page 
	And I click on Expired quote radio button
	And I click on expand button of any expired quote from quote list
	And I click on Re-Quote button from quote details section
	And I must able to see the <GetQuoteService> page
	And I click on View Quote Results button
    Then Page should be navigated the <QuoteResultsService> page	
	And The Selected Station and Customer Name should  match with Station and Customer Label on Quote Results(LTL) page

	Examples: 
	| Scenario | Username              | Password | DashboardTitle | QuoteList_Header | GetQuoteService | QuoteResultsService |
	| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | Quote List       | Get Quote (LTL) | Quote Results (LTL) |














	





