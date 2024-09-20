@44609 @Sprint83
Feature: Insurance Claims - Claim Details - Save Header
	
@DBVerification
Scenario: 44609_Verify the edits saved for the Claim Header when user clicked on Save Claim Details
	Given I am a Claims Specialist user
	And I am on ClaimDetails page
	And I made changes in any of the fields Claim status,DLSW Claim Rep,Station,DLSW Ref # in Claim Header section
	And I made changes in any of the fields Claimant,Claim Reason,Carrier Name,Carrier PRO #,Insured in Claim Header section
	When I click on Save Claim Details button
	Then updated Claim Header values should be saved

@DBVerification
Scenario Outline: 44609_Verify the edits saved for any of the Claim Header fields when user clicked on Save Claim Details
	Given I am a Claims Specialist user
	And I am on ClaimDetails page
	And I have edited any one of the fields <ClaimHeader> section of Details page
	When I click on Save Claim Details button
	Then The updated claim header <ClaimHeader> section values should be saved

Examples:  
| ClaimHeader    |
#| Claim Status   |
| DLSW Claim Rep |
#| Station        |
| DLSW Ref #     |
| Claimant       |
| Claim Reason   |
| Carrier Name   |
| Carrier PRO #  |
| Insured        | 