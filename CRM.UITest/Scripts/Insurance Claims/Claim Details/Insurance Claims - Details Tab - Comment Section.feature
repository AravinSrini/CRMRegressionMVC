@InsuranceClaim_DetailsTab_CommentSection @Sprint82 @40067
Feature: Insurance Claims - Details Tab - Comment Section


@GUI
Scenario: Verify the user is unable to edit the Comments on Details Tab of Insurance Claim
	Given I am a sales, sales management, operations or station owner use
	And I clicked on the hyperlink of any displayed claim on Claims List page
    When I arrive on the Details tab of the Claims Details page
	Then I will see a Comment Section
	And I am unable to edit the comments



@GUI @Functional
Scenario: Validate and Verify the user is able to edit the Comments on Details Tab of Insurance Claim
	Given I am a claims specialist user
	And I clicked on the hyperlink of any displayed claim on Claims List page
    When I arrive on the Details tab of the Claims Details page
	Then I have the option to edit the Comments field
	And The Comments field will allow the following: alpha-numeric,text,special character,max length 5000


