@107771 @Sprint92 @Regression
Feature: Insurance Claims - Amend - Binding Carrier_Shipper_Consignee_Claim Payable

Scenario Outline: 107771 Verify the Carrier/Shipper/Consignee/Claim Payable fields binds the data of previously submitted Claim and its Uneditable upon click on Edit button of Amend Status Claim
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
And I am on the Claims List page
And the claim is in Amend status
When I click on the Edit icon of Amend status Claim
Then the Carrier Information Section fields DLSW Ref#, DLSW Ship Date, Carrier Name, Carrier Pro#, Carrier Pro Date will display the data of the previously submitted claim and it is uneditable
And the Shipper Information Section fields Name, Address, Address2, Zip/Postal, City, State/Province, Country will display the data of the previously submitted claim and it is uneditable
And the Consignee Information Section fields Name, Address, Address2, Zip/Postal, City, State/Province, Country will display the data of the previously submitted claim and it is uneditable
And the Claim Payable To Section fields Company Name, Address, Address2, Zip/Postal, City, State/Province, Country, Contact Name, Contact Phone, Contact Email, Contact Website will display the data of the previously submitted claim and it is uneditable
Examples: 
		| UserType        | UserName								 | Password								   |
		| Internal        | username-CurrentSprintOperations         | password-CurrentSprintOperations        |
		| Sales           |	username-CurrentSprintSales			     | password-CurrentSprintSales			   |
		| Claimspecialist | username-CurrentsprintClaimspecialist    | password-CurrentsprintClaimspecialist   |
		| External        | username-CurrentSprintshpentry           | password-CurrentSprintshpentry          |
