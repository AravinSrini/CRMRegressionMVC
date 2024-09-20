@Sprint84 @39679

Feature: 39769_InsuranceClaims-ClaimDetails-Exportbutton	

@90440 @Sprint92
Scenario:39679- Verify the drop down list of exportable report options Tab,History Tab,Claim Submitted by Customer
Given I am a sales, sales management, operations, station owner, or claim specialist user
And I am on the claim details page for any claim Type LTL,FTL,Forwording
When I click on the Export button from claim details page
Then I will see a drop down list of exportable report options Payment Tab,History Tab,Claim Submitted by Customer

Scenario Outline:39679- Verify excel report is downloaded with the details displayed of the selected tab
Given I am a sales, sales management, operations, station owner, or claim specialist user
And I am on the claim details page for any claim Type LTL,FTL,Forwording
And I clicked on the Export button
When I select<ExportOption> the History Tab or Payment Tab option
Then An excel report will be downloaded with the details displayed of corresponding tab <ExportOption>
Examples:
| ExportOption |
| History Tab  |
| Payement Tab |


Scenario:39679- Verify pdf of the claim submitted to DLSW is displayed on selection the Claim Submitted by Customer option
Given I am a sales, sales management, operations, station owner, or claim specialist user
And I am on the claim details page for any claim Type LTL,FTL,Forwording
And I clicked on the Export button
When I Select The Claim Submitted by Customer option
Then  A PDF of the claim submitted to DLSW will be displayed in next tab

################################################################################
# Deleted scenarios for 90440 as it's covered in Feature: Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission


@Sprint92 @94471
Scenario: 94471 - Verify display of Claim Amended By Customer option in the export dropdown on Claim details page for a claim that was previously amended and resubmitted_ClaimSpecialistUser
	Given I am user who have access to Claim Details page 'username-CurrentsprintClaimspecialist' 'password-CurrentsprintClaimspecialist'
	And I am on the claim details page of a claim that was previously amended and resubmitted
	When I click on Export dropdown arrow of Claim details page
	Then I will see a new option 'Claim Amended By Customer' on the export dropdown of Claim details page

@Sprint92 @94471
Scenario: 94471 - Verify display of Claim Amended By Customer option in the export dropdown on Claim details page for a claim that was previously amended and resubmitted_InternalUser
	Given I am user who have access to Claim Details page 'username-CurrentSprintOperations' 'password-CurrentSprintOperations'
	And I am on the claim details page of a claim that was previously amended and resubmitted for an internal user
	When I click on Export dropdown arrow of Claim details page
	Then I will see a new option 'Claim Amended By Customer' on the export dropdown of Claim details page

@Sprint92 @94471
Scenario: 94471 - Verify display of Claim Amended By Customer option in the export dropdown on Claim details page for a claim that was not previously amended and resubmitted_ClaimSpecialistUser
	Given I am user who have access to Claim Details page 'username-CurrentsprintClaimspecialist' 'password-CurrentsprintClaimspecialist'
	And I am on the claim details page of a claim that was not previously amended and resubmitted
	When I click on Export dropdown arrow of Claim details page
	Then I will not see a new option 'Claim Amended By Customer' on the export dropdown of Claim details page

@Sprint92 @94471
Scenario: 94471 - Verify display of Claim Amended By Customer option in the export dropdown on Claim details page for a claim that was not previously amended and resubmitted_InternalUser
	Given I am user who have access to Claim Details page 'username-CurrentSprintOperations' 'password-CurrentSprintOperations'
	And I am on the claim details page of a claim that was not previously amended and resubmitted for internal user
	When I click on Export dropdown arrow of Claim details page
	Then I will not see a new option 'Claim Amended By Customer' on the export dropdown of Claim details page

@Sprint92 @94471
Scenario: 94471 - Verify if PDF of amended claim form is opened when user clicks on Claim Amended By Customer export option_ClaimSpecialistUser
	Given I am user who have access to Claim Details page 'username-CurrentsprintClaimspecialist' 'password-CurrentsprintClaimspecialist'
	And I am on the claim details page of a claim that was previously amended and resubmitted
	When I click on Claim Amended By Customer option from the export dropdown of Claim details page
	Then I will see a pdf of the amended claim form with the most recent data updates

@Sprint92 @94471
Scenario: 94471 - Verify if PDF of amended claim form is opened when user clicks on Claim Amended By Customer export option_InternalUser
	Given I am user who have access to Claim Details page 'username-CurrentSprintOperations' 'password-CurrentSprintOperations'
	And I am on the claim details page of a claim that was previously amended and resubmitted for an internal user
	When I click on Claim Amended By Customer option from the export dropdown of Claim details page
	Then I will see a pdf of the amended claim form with the most recent data updates


