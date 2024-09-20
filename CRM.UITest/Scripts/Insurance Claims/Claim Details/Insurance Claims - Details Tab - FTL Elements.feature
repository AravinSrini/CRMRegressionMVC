@Sprint82 @39494
Feature: Insurance Claims - Details Tab - FTL Elements

@GUI	
Scenario:  39494_Verify FTL-Specific fields in details tab
	Given I am sales, sales management, operations, station owner, or claims specialist user
	And I am on the Claims List page
	When I clicked on the hyperlink of any displayed claim having shipment mode as FTL
	Then the FTL shipment mode will be pre-selected
	And the Details tab will display the given FTL-Specific fields: Carrier MC,Seal,Seal Intact,Vehicle

@GUI @Functional
Scenario:  39494_Verify by changing the shipment mode from LTL to FTL
	Given I am a claim specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim having shipment as LTL
	And I am on the Details tab of the Claim Details page
	When I change the shipment mode to FTL
	Then the Details tab will update to display FTL-Specific fields

@GUI @Functional
Scenario:  39494_Verify by changing the shipment mode from Forwarding to FTL
	Given I am a claim specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim having shipment mode as Forwarding
	And I am on the Details tab of the Claim Details page
	When I change the shipment mode to FTL
	Then the Details tab will update to display FTL-Specific fields

@GUI
Scenario:  39494_Verify by editing the FTL-Specific fields in details tab
   Given I am a claim specialist user
   And I am on the Claims List page
   When I clicked on the hyperlink of any displayed claim having shipment mode as FTL for claim specialist user
   Then I can edit the fields: Carrier MC,Seal,Seal Intact,Vehicle from details tab
   And It will allow max 10 character to enter in Carrier MC number field
   And It will allow 30 character to enter in Seal number and vehicle number field field





	