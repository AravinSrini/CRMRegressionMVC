@QuoteListSubmitRateRequest @26359 @Sprint67 
Feature: QuoteList_SubmitRateRequest


@GUI
Scenario Outline: Verify the customer type is MG or Both then Submit Rate Request button must be visible
    Given I am a Operations, Sales, Sales Management, or Station Owner user
	When I am navigated to the dashboard page <DashboardTitle> 
	And I see the Quote module in the left navigation bar
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I choose any customeraccount <Account> from the dropdown
	Then I must be able to see the <SubmitRateRequest> Button is Visible

	Examples: 
	| Scenario | DashboardTitle | QuoteList_Header | Account       | SubmitRateRequest   |
	| S1       | Dashboard      | Quote List       | Dunkin Donuts | Submit Rate Request |

@GUI @Ignore  	
Scenario Outline: Verify the Submit Rate Request button when by default All customer account is selected
    Given I am a Operations, Sales, Sales Management, or Station Owner user
	When I am navigated to the dashboard page <DashboardTitle> 
	And I see the Quote module in the left navigation bar
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
    And All Customers option is selected by default	
	Then I should not be able to see the <SubmitRateRequest> Button 

	Examples: 
	| Scenario | DashboardTitle | QuoteList_Header | SubmitRateRequest   |
	| S1       | Dashboard      | Quote List       | Submit Rate Request |
 


@GUI 
Scenario Outline: Verify the customer type is CSA then Submit Rate Request button should not be visible
    Given I am a Operations, Sales, Sales Management, or Station Owner user
	When I am navigated to the dashboard page <DashboardTitle> 
	And I see the Quote module in the left navigation bar
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I choose any customeraccount <Account> from the dropdown
	Then I should not be able to see the <SubmitRateRequest> Button 

    Examples: 
	| Scenario | DashboardTitle | QuoteList_Header | Account             | SubmitRateRequest   |
	| S1       | Dashboard      | Quote List       | CustomerAccount_CSA | Submit Rate Request |

@GUI 
Scenario Outline: Verify the by clicking on Submit Rate Request button must be naviagted on Get Quote Landing Page 
    Given I am a Operations, Sales, Sales Management, or Station Owner user
	When I am navigated to the dashboard page <DashboardTitle> 
	And I see the Quote module in the left navigation bar
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I choose any customeraccount <Account> from the dropdown
	And I click Submit Rate Request button
	Then I must be navagated to the <GetQuote> Landing Page

    Examples: 
	| Scenario | DashboardTitle | QuoteList_Header | Account       | GetQuote  |
	| S1       | Dashboard      | Quote List       | Dunkin Donuts | Get Quote |

@GUI 
Scenario Outline: Verify the Get Quote landing page have service type as LTL tile option
    Given I am a Operations, Sales, Sales Management, or Station Owner user
	When I am navigated to the dashboard page <DashboardTitle> 
	And I see the Quote module in the left navigation bar
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I choose any customeraccount <Account> from the dropdown
	And I click Submit Rate Request button
	Then I must be navagated to the <GetQuote> Landing Page
	And I must be able to see the <ServiceType> tiles on Get Quote Landing Page  
    
    Examples: 
	| Scenario | DashboardTitle | QuoteList_Header | Account       | GetQuote  | ServiceType |
	| S1       | Dashboard      | Quote List       | Dunkin Donuts | Get Quote | LTL         |

@GUI 
Scenario Outline: Verify by clicking on LTL tiles page should be Landing on Get Quote LTL page
    Given I am a Operations, Sales, Sales Management, or Station Owner user
	When I am navigated to the dashboard page <DashboardTitle> 
	And I see the Quote module in the left navigation bar
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I choose any customeraccount <Account> from the dropdown
	And I click Submit Rate Request button
	And I click on LTL tile on Get Quote landing page
	Then I must be navigated to the <GetQuote_LTL> page
	
	Examples: 
	| Scenario | DashboardTitle | QuoteList_Header | Account       | GetQuote_LTL    |
	| S1       | Dashboard      | Quote List       | Dunkin Donuts | Get Quote (LTL) |

@GUI @Functional 
Scenario Outline: Verify the selected Station Name and Customer name must be displaed on Get Quote LTL page
    Given I am a Operations, Sales, Sales Management, or Station Owner user
	When I am navigated to the dashboard page <DashboardTitle> 
	And I see the Quote module in the left navigation bar
	And I click on the Quote Icon
	And  I should be navigated to the Quote List<QuoteList_Header>page
	And I choose any customeraccount <Account> from the dropdown
	And I click Submit Rate Request button
	And I click on LTL tile on Get Quote landing page
	Then Verify the associated Station and Customer name label should be displayed on Get Quote LTL page

    Examples: 
	| Scenario | DashboardTitle | QuoteList_Header | Account       |
	| S1       | Dashboard      | Quote List       | Dunkin Donuts |




	













	 
	
