@Sprint79 @Regression
Feature: Insurance Claims - Submit a Claim Page - Save Info

@DBVerification
Scenario: 32064 - Verify if all the passed data on Submit a claim page is saved in DB 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page
     And Data has been passed to all the fields on Submit a claim page
	 When I click on Submit Claim Button
	 Then All the data should get saved in DB along with the username of the user that submitted the claim, First name  and last name of the submitted user, date and time
	 And Claim will be placed in Pending status.
	 
@Sprint94 @107648
Scenario Outline: 107648 Verify the save functionality of Customer Claim Ref from Submit a Claim page and also verifying the same is pushed to Claims List page
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
And I am on Submit a Claim page
When Data has been passed to all the fields on Submit a claim page <UserType>
Then the "value" of Customer Claim Ref field will be saved
And the value of the Customer Claim Ref will be pushed to the Customer Ref column of the Claims List page <UserType>

Examples: 
		| UserType        | UserName                              | Password                              |
		| Internal        | username-CurrentSprintOperations      | password-CurrentSprintOperations      |
		| Sales           | username-CurrentSprintSales           | password-CurrentSprintSales           |
		| Claimspecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist |
		| External        | username-CurrentSprintshpentry        | password-CurrentSprintshpentry        |  

