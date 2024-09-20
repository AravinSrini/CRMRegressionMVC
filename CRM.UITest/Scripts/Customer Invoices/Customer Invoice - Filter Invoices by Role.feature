@41888 @Sprint78 
Feature: Customer Invoice - Filter Invoices by Role
	

@Functional
Scenario: Verify the Customer Invoices filtering for Sales user
	Given I am a Sales user
	When I arrive on the Customer Invoices list page
	Then I should see invoices for the customer account that I am associated to and I can also see invoices for all the sub accounts

@Functional
Scenario: Verify the customer Invoices filtering for ShipEntry , ShipEntryNoRates, ShipInquiry or ShipInquiryNoRates user
    Given I am a Sales, ShipEntry, ShipEntryNoRates, ShipInquiry or ShipInquiryNoRates user
	When I arrive on the Customer Invoices list page
	Then I should see invoices for the customer account that I am associated to and I can also see invoices for all the sub accounts for ShipEntry, ShipEntryNoRates, ShipInquiry or ShipInquiryNoRates user




@Functional 
Scenario: Verify the Customer Invoices filtering for Sales Management, Operations or Station Owner user
    Given I am a Sales Management, Operations or Station Owner user
	When I arrive on the Customer Invoices list page
	Then I should see only the Invoices for the customers of the stations that I am associated to