@39555 @Sprint82

Feature: Insurance Claims - Submit a Claim Page - Validate User to Ref Number
	

Scenario: 39555_Verify the error message when I enter a DLSW Ref number which is not associated to the logged in User profile
          Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, or Station Owner user
          And I am on the Insurance Claim - Submit a Claim page
		  When I enter the DLSW Refnumber not associated to logged in User profile and click on the Populate Form button
		  Then I should see the error message 'Please enter a DLSW Ref # associated to your customer profile or manually enter your claim information.'
		  And Submit a Claim page should not be auto populated

Scenario: 39555_Verify the error message when I enter a DLSW Ref number which is associated to the logged in User profile
          Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, or Station Owner user
          And I am on the Insurance Claim - Submit a Claim page
		  When I enter the DLSW Refnumber associated to logged in User profile and click on the Populate Form button
		  Then I should not see the error message 'Please enter a DLSW Ref # associated to your customer profile or manually enter your claim information.'
		  