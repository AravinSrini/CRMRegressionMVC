@QuoteDetails_PrintQuote @26527 @Sprint67 

Feature: QuoteDetails _All_Users_PrintQuote


@GUI @Functional
Scenario Outline: Verify the Print button functionality in the Quote Details section for the Station Users Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 	
	And I click on the Quote Icon	
	And I expand any Quote in the Quote list page
	And I click on the Print button
	Then I must see the pdf is downloaded with quote details
	And I must see the associated Station_CustomerName in the printed Quote details page

Examples: 
| Scenario | Username              | Password | DashboardTitle |
| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | 


@GUI @Functional @DBVerification
Scenario Outline: Verify the Print button functionality in the Quote Details section for theShipEntry and ShipInquiry Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 	
	And I click on the Quote Icon	
	And I expand any Quote in the Quote list page
	And I click on the Print button
	Then I must see the pdf is downloaded with quote details
	And I should see associated Station_CustomerName for <Username> in the printed Quote details page

Examples: 
| Scenario | Username           | Password | DashboardTitle | 
| S1       | prakashshipinquiry | Te$t1234 | Dashboard      | 


@GUI @Functional @30419 @Sprint2_Ninja
Scenario Outline: Verify the est cost and est margin fields in quote details print docoument
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 	
	And I click on the Quote Icon	
	And I expand any Quote in the Quote list page
	And I click on the Print button
	Then I must see the pdf is downloaded with quote details
	And I should not see est cost and est margin fields in print document

Examples: 
| Scenario | Username              | Password | DashboardTitle |
| S1       | crmOperation@user.com | Te$t1234 | Dashboard      | 
