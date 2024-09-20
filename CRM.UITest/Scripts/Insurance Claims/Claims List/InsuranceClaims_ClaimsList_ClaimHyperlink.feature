@Sprint79 @31921
Feature: InsuranceClaims_ClaimsList_ClaimHyperlink
	
@GUI
Scenario: Verify the DLSW claim number is displayed as a hyperlink
	Given I am ShpEntry, ShpEntryNoRates, ShpInquiry, ShpInquiryNoRates User
	When I am on the Claims List page
	Then I will see DLSW claim number is displayed as a hyperlink

@GUI
Scenario: Verify the pdf file Name with url
	Given I am ShpEntry, ShpEntryNoRates, ShpInquiry, ShpInquiryNoRates User
	And I am on the Claims List page
	When I clicked any of the DLSW Claim hyperlink
	Then the pdf will be opened in new tab and the file name will be the DLSW Claim number pdf