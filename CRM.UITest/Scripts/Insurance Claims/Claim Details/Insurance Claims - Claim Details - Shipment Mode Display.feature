@Sprint82 @43095 
Feature: Insurance Claims - Claim Details - Shipment Mode Display

@Functional @DB
Scenario: 43095 : Test to verify mode of Claim in DB when required field values of submit a Claim page is completed manually and submitted
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
	And I am on the Submit a Claim page
	And I have manually completed all required fields
	When I click on the Submit Claim button 
	Then The mode of the claim should be defaulted to LTL in DB

@Functional @DB @Ignore
Scenario: 43095 : Test to verify mode of Claim in DB when submit a Claim page is populated using DLSW REF and submitted for carrier mode TL, PTL, IL
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
	And I am on the Submit a Claim page
	And I have populated form using DLSW REF 
	When I click on the Submit Claim button 
	Then The mode of the claim should be updated with FTL in DB for carrier mode TL, PTL, IL

@Functional @DB @Ignore
Scenario: 43095 : Test to verify mode of Claim in DB when submit a Claim page is populated using DLSW REF and submitted for carrier modes other than TL, PTL, IL
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
	And I am on the Submit a Claim page
	And I have populated form using DLSW REF number
	When I click on the Submit Claim button 
	Then The mode of the claim will updated with LTL in DB, if carrier mode is not TL, PTL, IL

@GUI
Scenario: 43095 : Verify display and behaviour of Mode of Claim field of Claim details page
	Given I am a sales, sales management, operations, or station owner user
	And Hyperlink of any displayed claim on Claims List page is clicked
	When I arrive on the Claim Details page
	Then The mode of claim should be displayed
	And The mode of the claim is non-editable.

@Functional @GUI
Scenario: 43095 : Verify display and behaviour of Mode of Claim field of Claim details page for claim specialist user
	Given I am a claim specialist user
	And Hyperlink of any displayed claim on Claims List page is clicked
	When I arrive on the Claim Details page
	Then The mode of claim should be displayed
	And I have the option to select a different claim mode
	And The options are: LTL, FTL, Forwarding


