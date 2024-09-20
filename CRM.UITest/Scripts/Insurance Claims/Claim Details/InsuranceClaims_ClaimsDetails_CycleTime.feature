@Sprint84 @39577 @GUI
Feature: InsuranceClaims_ClaimsDetails_CycleTime

	
Scenario:39577 Verify the Cycle Time Calculation
Given I am a sales, sales management, operations, station owner, or claims specialist user
And I clicked on the hyperlink of a displayed claim on the Claims List page
And a comment with the category of <DLSW Submitted Claim> has been saved on the History Tab
When I arrive on the Claim Details of the selected claim
Then the Cycle Time will be calculated as the difference between Current date and the date of history Tab comment with the category of <DLSW Submitted Claim>
And the Cycle Time will be displayed in days


Scenario:39577 Verify Cycle Time when the claim does not have a History Tab comment with the category of DLSW Submitted Claim
Given I am a sales, sales management, operations, station owner, or claims specialist user
And I clicked on the hyperlink of a displayed claim on the Claims List page
And the claim does not have a History Tab comment with the category of <DLSW Submitted Claim>
When I arrive on the Claim Details of the selected claim
Then the Cycle Time field will be blank


Scenario:39577 Verify Cycle Time calculation when the claim contained more than one comment with the category of DLSW Submitted Claim saved on the History Tab
Given I am a sales, sales management, operations, station owner, or claims specialist user
And I clicked on the hyperlink of a displayed claim on the Claims List page
And the claim contained more than one comment with the category of <DLSW Submitted Claim> saved on the History Tab
When I arrive on the Claim Details of the selected claim
Then the Cycle Time will be calculated using the most recent <DLSW Submitted Claim> History Tab comment