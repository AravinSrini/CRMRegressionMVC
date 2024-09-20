@Sprint79 @31892
Feature: InsuranceClaims_ClaimDetailsPage
	
	@GUI
Scenario: 31892 - Verify the Claim Details Page header
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will see the page header as Claim Details

	@GUI
Scenario: 31892 - Verify the Verbiage associated to the Claim Details Page header
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will see Verbiage associated to the page header

	@GUI
Scenario: 31892 - Verify the presence of Back to Claims List button in the Claim Details Page
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will see Back to Claims List button

	@GUI
Scenario: 31892 - Verify the presence of Print button in the Claim Details Page
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will see Print button

	@Functional
Scenario: 31892 - Verify DLSW Claim #, Carrier Name, Claim Rep, Insured, Claimant, Claim Age field values
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will see DLSW Claim #, Carrier Name, Claim Rep, Insured, Claimant, Claim Age field values

	@GUI
Scenario: 31892 - Verify the absence of Edit button in the Claim Details Page
	Given I am Sales, Sales Management, Operations, Station Owner User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will not see Edit button
	
	@GUI
Scenario: 31892 - Verify the presence of Edit button in the Claim Details Page
	Given I am Claim Specialist User
	And I clicked dlsw claim reference hyper link on the Claims List page
	When I arrive on the Claim Details page
	Then I will see Edit button

	@GUI
Scenario: 31892 - Verify User navigated back to Claims List Page up on clicking on Back to Claims List button
	Given I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User
	And I clicked any dlsw claim reference hyper link on the Claims List page
	And I am on the Claim Details page
	When I clicked on the Back to Claims List button
	Then I will navigated back to Claims List page