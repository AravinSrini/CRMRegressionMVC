@Sprint74 @29263
Feature: Customer Details-Activate Customer Account
	
@Functionality @GUI
Scenario Outline: Verify the User associated to Active Customer Account able to Login in to the CRM Application -External Users
Given I am ShpEntry, ShpEntryNoRates, ShpInquiry, ShpInquiryNoRates User associated to Active Customer Account<CustomerAccount>
When  I Try to logging in to the CRM Application <Username>,<Password>
Then  I should be able to login successfully in to the CRM Application

Examples: 
| Scenario | Username | Password | CustomerAccount          |
| s1       | zzzext   | Te$t1234 | ZZZ - Czar Customer Test |