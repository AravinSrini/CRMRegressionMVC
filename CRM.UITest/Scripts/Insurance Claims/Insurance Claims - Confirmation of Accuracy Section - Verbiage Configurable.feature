@32004 @Sprint79 @Functional @GUI 
Feature: Insurance Claims - Confirmation of Accuracy Section - Verbiage Configurable
	

Scenario: Verify Confirmation of Accuracy Section Verbiage on claim details page
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
    And I am on Claim List page
	When I click on Submit a Claim button
	Then Cofigurable verbiage should be displayed in confirmation of accuracy section


