@Sprint91 @regression
Feature: 82929_Insurance Claims - Claims List - Display Assigned Claims Specialist
	

Scenario Outline: 82929- Verify Created  claim will not have DLSW Claim specialist assigned
	Given that I am a shp.entry, shp.entrynorates, shp.inquiry, shp.inquirynorates, sales, sales management, operations, station owner, or claims specialist <UserType> user,
	And I am on the Submit Claim page,
	And I have completed all required fields for <UserType> user,
	When I click On the Submit Claim button,
	Then the newly created claim will not have a DLSW Claim Specialist assigned.

Examples: 
| UserType        | 
| External        | 
| Internal        | 
| Sales           | 
| ClaimSpecialist |


Scenario: 82929- Verify DLSW Claim Specialist field show claim as blank if no DLSW Claim Specialist has been selected for the claim
	Given I am a claim specialist user,
	And I am on the Claims List page,
	When no DLSW Claim Specialist has been selected for the claim,
	Then the DLSW Claim Specialist Field of the claim will be blank.

Scenario: 82929-Verify  DLSW Claim Rep  displayed  in the DLSW Claim specialist Field
	Given I am a claim specialist user,
	When I arrive on the Claims List page,
	Then I will see the name of the DLSW Claim Rep Displayed in the DLSW Claim Specialist field.
