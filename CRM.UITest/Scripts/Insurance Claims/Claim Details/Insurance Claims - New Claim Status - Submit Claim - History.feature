@Sprint91 @95590 @Regression
Feature: Insurance Claims - New Claim Status - Submit Claim - History
	
Scenario Outline: Verify the Claim placed in Submitted Status, Status and History Tab Record updated with Comment as Claim submitted to DLSW
Given I'm shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user<UserType>
And I am on the Submit a Claim page
And all required fields have been completed 
When I Click on Submit Claim button 
Then the claim will be place in "Submitted" status
And a record will be added to the Status/History tab
And the Comment of the record will display the verbiage "Claim submitted to DLSW"

Examples: 
		| UserType        |
		| Internal        |
		| Sales           |
		| Claimspecialist |
		| External        |