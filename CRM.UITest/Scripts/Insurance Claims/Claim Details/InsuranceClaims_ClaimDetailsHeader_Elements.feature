@Sprint82 @22092 @Regression
Feature: InsuranceClaims_ClaimDetailsHeader_Elements
	
	@GUI 
Scenario: 22092 - Verify the Claim Details Header Fields
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked on the hyperlink of any Claim number from the Claim List page
	When I am on the Details tab of the Claim in Claim Details page
	Then I will see Claim Header Informations

	@Functional
Scenario: 22092 - Verify the Header field values are Auto-populated from the Claim Form
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked on the hyperlink of any Claim number from the Claim List page
	When I am on the Details tab of the Claim in Claim Details page
	Then I will see Header Field values are Auto-populated from the Claim Form

	@GUI
Scenario: 22092 - Verify the presence of Claim Form button
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked on the hyperlink of any Claim number from the Claim List page
	When I am on the Details tab of the Claim in Claim Details page
	Then I will see Claim Form button

	@GUI
Scenario: 22092 - Verify the Claim Age binded in the Claim Details Page Header section
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked on the hyperlink of any Claim number from the Claim List page
	When I am on the Details tab of the Claim in Claim Details page
	Then the Claim Age will be difference in Current Date and Claim Date Submitted

		@GUI
Scenario: 22092 - Verify the Carrier Name binding when entered Carrier name is found in CRM
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked on the hyperlink of any Claim number which has valid Carrier from the Claim List page
	When I am on the Claim Details page
	Then Carrier Name will be binded in the Claim Details Header section

	@GUI
Scenario: 22092 - Verify the Carrier Name field will display Select when entered Carrier name is not found in CRM
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked on the hyperlink of any Claim number which has invalid Carrier from the Claim List page
	When I am on the Claim Details page
	Then Carrier Name field will display Select verbiage in the Claim Details Header section

	@GUI
Scenario: 22092 - Verify the associated Carrier SCAC Code binded in the SCAC field when the Carrier field has a valid Carrier
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked on the hyperlink of any Claim number which has valid Carrier from the Claim List page
	When I am on the Claim Details page
	Then associated SCAC code of that Carrier will be binded in SCAC field

	@GUI
Scenario: 22092 - Verify the SCAC field is blank when the Carrier field has invalid Carrier
	Given I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User
	And I clicked on the hyperlink of any Claim number which has invalid Carrier from the Claim List page
	When I am on the Claim Details page
	Then the SCAC field will be left blank


	@GUI @Functional @Sprint94 @107653
Scenario Outline: 107653-Verify Customer Claim Ref # Field Is Binding For Internal User
	Given I am a sales, sales management, operations, station owner user <UserType>,<UserName>,<Password>
	And I am on the Claims List page
	And I clicked on the link of any displayed claim <UserType>,<ClaimNumber>
	When I arrive on the Claim Details page
	Then I will see the field Customer Claim Ref #
	And the field is not editable
	And the value of the Customer Claim Ref # field of the Submit A Claim page will be pushed to the Customer Claim Ref # field of the Claim Details page <ClaimNumber>
	 Examples: 
		| UserType | UserName                         | Password                         | ClaimNumber |
		| Sales    | username-CurrentSprintSales      | password-CurrentSprintSales      | 2019000637  |
		| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations | 2019000637  |
		

@GUI @Functional @Sprint94 @107653
Scenario Outline: 107653-Verify Customer Claim Ref # Field Is Binding For Claim Specialist User
	Given I am a claim specialist user <UserType>,<UserName>,<Password>
	And I am on the Claims List page
	And I clicked on the link of any displayed claim <UserType>,<ClaimNumber>
	When I arrive on the Claim Details page
	Then I will see the optional field Customer Claim Ref #
	And the field is editable (alpha-numeric, text, special characters, max length 20)
	And the value of the Customer Claim Ref # field of the Submit A Claim page will be pushed to the Customer Claim Ref # field of the Claim Details page <ClaimNumber>
Examples: 
	| UserType        | UserName                              | Password                              | ClaimNumber |
	| ClaimSpecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | 2019000637  |

@Functional @Sprint94 @107653
Scenario Outline: 107653-Verify Customer Claim Ref # Field is getting saved for Claim Specialist User
	Given I am a claim specialist user <UserType>,<UserName>,<Password>
	And I am on the Claims List page
	And I clicked on the link of any displayed claim <UserType>,<ClaimNumber>
	When I arrive on the Claim Details page
	And I edit Customer Claim Ref # <ClaimNumber>,<InitialValueForCustomerClaimReferenceNumber>,<EditedValueForCustomerClaimReferenceNumber>
	When I click on Save Claim Details
	Then Customer Claim Ref # will be saved to Claim <ClaimNumber>,<EditedValueForCustomerClaimReferenceNumber>
Examples: 
	| UserType        | UserName                              | Password                              | ClaimNumber | InitialValueForCustomerClaimReferenceNumber | EditedValueForCustomerClaimReferenceNumber |
	| ClaimSpecialist | username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | 2019000637  | InitialRefNo                                | EditedRefNo                                |
