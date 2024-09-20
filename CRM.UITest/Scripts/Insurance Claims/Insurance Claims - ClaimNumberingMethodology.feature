@Sprint 79 
Feature: Insurance Claims - ClaimNumberingMethodology
	
@Functional
Scenario: Verify the claim number after submitting the claim form 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist 
	And I am on the Submit a Claim page
	And All the required data has been passed in Submit Claim page
	When I click on the Submit Claim button
	Then CRM will create a unique 10 digit claim number


@Functional
Scenario: Verify the first four digit of the claim number 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist 
	And I am on the Submit a Claim page 
	And All the required data has been passed in Submit Claim page
	When I click on the Submit Claim button
	Then the first four digits of claim number will contain the year in which the claim was submitted


@Functional
Scenario: Verify the last 6 digit of the claim number 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist 
	And I am on the Submit a Claim page 
	And All the required data has been passed in Submit Claim page
	When I click on the Submit Claim button
	Then the last 6 digits of the claim number will contain a value which will be assigned incrementally and it will be beginning with 000001


@FUnctional
Scenario: Verify if the last 6 digit of claim number is reset in every year 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist 
	And I am on the Submit a Claim page 
	And All the required data has been passed in Submit Claim page
	When I click on the Submit Claim button
	Then the last 6 digits will reset to 000001 beginning on January 1st every year


