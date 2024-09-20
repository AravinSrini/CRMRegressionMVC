@49366  @Functional @PrioritySprint

Feature: 49366_Customer Invoice-Custom Report_Saved Report_GridColumnChanges
	
Scenario: 49366_Verify that the Days Past Due column doesn't display in the grid when the user selects a Custom Report which was created with Invoice Type as Closed
Given I am any user with access to the CRM Customer Invoice Page
And I am on the Customer Invoices list page
When I Select an existing custom report from Select Existing Custom Report which was created with Invoice Type as Closed
Then I will no longer see the Days Past Due column in my grid results

Scenario: 49366_Verify that a new column labeled Payment Date displays to the right of Due Date column in the grid when the user selects a Custom Report which was created with Invoice Type as Closed
Given I am any user with access to the CRM Customer Invoice Page
And I am on the Customer Invoices list page
When I Select an existing custom report from Select Existing Custom Report which was created with Invoice Type as Closed
Then I will see a new column labeled Payment Date to the right of column Due Date
And the value for this column will be the Cleared Date(Last Payment Date from Table) from SAP

Scenario: 49366_Verify that the Days Past Due column should display in the grid when the user selects a Custom Report which was created with Invoice Type as opened
Given I am any user with access to the CRM Customer Invoice Page
And I am on the Customer Invoices list page
When I Select an existing custom report from Select Existing Custom Report which was created with Invoice Type as Open
Then I will see the Days Past Due column in my grid results

Scenario: 49366_Verify that a new column labeled Payment Date shouldn't displays when the user selects a Custom Report which was created with Invoice Type as opened
Given I am any user with access to the CRM Customer Invoice Page
And I am on the Customer Invoices list page
When I Select an existing custom report from Select Existing Custom Report which was created with Invoice Type as Open
Then I will not see a new column labeled Payment Date to the right of column Due Date
