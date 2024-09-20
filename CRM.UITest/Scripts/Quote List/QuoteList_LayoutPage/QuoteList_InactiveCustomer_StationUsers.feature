@QuoteList_InactiveCustomer_StationUsers @34501 @Sprint74 
Feature: QuoteList_InactiveCustomer_StationUsers


@GUI @DBVerification
Scenario Outline: Verify the Associated Customer in Inactive Status have an indicator that Account is Inactive 
	Given I am an sales, sales management, operations, or station owner user <Username>,<Password>
	And I am on the Quote List Page 
	When  I am associated to a CRM customer <Customername> in Inactive Status
	And  I see a <Customername> from the drop down list that is inactive
	Then Verify that <Customername> will have an indicator that the account is inactive

Examples: 
   | Scenario | Username              | Password | Customername |
   | S1       | crmOperation@user.com | Te$t1234 | Prakash MG   |        


@Ignore @GUI @DBVerification
Scenario Outline: Verify the Submit Rate Request button will be Inactive for Inacitve Customer
	Given I am an sales, sales management, operations, or station owner user <Username>,<Password>
	And I am on the Quote List Page
	When  I am associated to a CRM customer <Customername> in Inactive Status
	And  I select the Inactive <Customername> from the customer list
	Then Verify that SubmitRateRequest Button will be inactive

	Examples: 
   | Scenario | Username              | Password | Customername |
   | S1       | crmOperation@user.com | Te$t1234 | Prakash MG   |              


@Ignore @GUI @DBVerification 
Scenario Outline: Verify the Create Shipment Button will be Disabled for Inactive Customer
	Given I am an sales, sales management, operations, or station owner user <Username>,<Password>
	And I am on the Quote List Page
	When  I am associated to a CRM customer <Customername> in Inactive Status
	And I select the Inactive <Customername> from the customer list	
	And I click on the New quotes radio button within the past thirty days
	#And  The <Customername> has non expired quotes within the past Thirty days
	#And  I expand the details of any Non Expired LTL Quote	
	Then Verify the Create_Shipment Button will be disabled

	Examples: 
   | Scenario | Username              | Password | Customername |
   | S1       | crmOperation@user.com | Te$t1234 | Prakash MG   |      


@Ignore @GUI @DBVerification 
Scenario Outline: Verify the Re - Quote Button will be Disabled for Inactive customer
	Given I am an sales, sales management, operations, or station owner user <Username>,<Password>
	And I am on the Quote List Page
	When  I am associated to a CRM customer <Customername> in Inactive Status
	And I select the Inactive <Customername> from the customer list
	And I click on the Expired quotes radio button within the past thirty days
	#And  The <Customername> has non expired quotes within the past Thirty days
	#And  I expand the details of any Expired LTL Quote
	Then Verify the Re_Quote Button will be disabled

	
	Examples: 
   | Scenario | Username              | Password | Customername |
   | S1       | crmOperation@user.com | Te$t1234 | Prakash MG   |








