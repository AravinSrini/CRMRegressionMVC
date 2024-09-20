@Sprint74 @29262
Feature: CustomerDetails_InactivateCustomerAccount
	
@GUI
Scenario Outline: Verify the User associated to Inactive Customer Account unable to Login in to the CRM Application
Given I am ShpEntry, ShpEntryNoRates, ShpInquiry, ShpInquiryNoRates User associated to Inactive Customer Account<Username>,<Password>,<CustomerName>
When I Try to logging in to the CRM Application
Then I will receive a Notification Message and will not be allowed to logging in to the CRM Application

Examples: 
| Scenario | Username                  | Password | CustomerName      |
| s1       | shpentryinactive@test.com | Te$t1234 | Deltacustomer-Iam |