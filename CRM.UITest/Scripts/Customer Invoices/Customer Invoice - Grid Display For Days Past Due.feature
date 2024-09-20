@49848 @PrioritySprint2
Feature: Customer Invoice - Grid Display For Days Past Due

@Functional
Scenario: 49848 - Verify the days past due from Customer Invoice grid for RRDAccess user
Given I am a RRDAccess user 
And I am on Customer Invoice page
When I Select Station <ENT - Bolingbrook IL>
And I Select Customer<All Accounts>
Then the Days Past Due value will be Current Date - Due Date for all invoices

@Functional
Scenario: 49848 - Verify the days past due from Customer Invoice by Preview/Run the Report
Given I'm a user with access to Customer Invoice Page
And I've selected a Station<ENT - Bolingbrook IL> in Create Custom Report section
And I've selected a Customer<All Accounts> in Create Custom Report section
When I Select Preview/Run button
Then the Days Past Due value will be Current Date - Due Date for all invoices


@Functional 
Scenario: 49848 - Verify the days past due from Customer Invoice grid by selecting Existing Custom Report
Given I'm a user with access to Customer Invoice Page
And I have an existing Custom Report<DayPastDueReport>
When I Select that Custom Report<DayPastDueReport>
Then the Days Past Due value will be Current Date - Due Date for all invoices