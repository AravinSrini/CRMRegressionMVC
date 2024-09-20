@Sprint88 @53599 @Regression
Feature: Insurance Claims - Claims List Pro Display
	
Scenario: 53599_Verify there is a space between the semi colon and the first character of carrier PRO number in Claim List page
	Given I am a shp.inquiry, shpinquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, station owner, or claim specialist user
	And I am on the Claims List page
	When a Pro number is available for any displayed carrier in the Carrier column
	Then I should be displayed with a space between the colon and the first character of the carrier pro
