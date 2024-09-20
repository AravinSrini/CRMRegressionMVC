@35601 @Sprint87
Feature: CSR Dashboard  and csrlist for Sales Users - Associated Customer Accounts
	

Scenario: Verify the Pie chart count for pending CSR
	Given I am a Sales user
	When I am on the CSR Dashboard page
	Then I will see the pending CSRs count for the customer account to which I am associated to on pie chart
	And  I will see the inProgress CSRs count for the customer account to which I am associated to on pie chart
	And I will see the denied CSRs count for the customer account to which I am associated to on pie chart
