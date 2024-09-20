@Sprint91 @82932

Feature: Insurance Claims - Claims List - Update Status Color Codes

Scenario: Verify the Open status color code in Claim List page
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, station owner, or claim specialist user
	When I am on the Claims List page
	Then the Open status color code will changed to a lighter blue



