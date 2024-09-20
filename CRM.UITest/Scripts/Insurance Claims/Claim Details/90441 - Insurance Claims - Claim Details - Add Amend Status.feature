@Sprint91 @90441
Feature: 90441 - Insurance Claims - Claim Details - Add Amend Status

@Regression
Scenario: 90441 - Verify the new option Amend in status drop down list on the claim details page for Claim Specialist user
	Given I am a claim specialist user	
	And I clicked on any dlsw claim reference hyper link on the Claims List page
	And I am on the Claim Details page
	When I clicked on the Status drop down list on the Claim Details page
	Then I should see the option as Amend listed first in the list
	
@Regression
Scenario: 90441 - Verify Amend status update and updated entry in the Status/History tab for Claim Specialist user
Given I am a claim specialist user
And I clicked on any dlsw claim reference hyper link on the Claims List page
And I am on the Claim Details page
And I selected the option Amend from the status drop down list
When I clicked on the Save Claim Details button
Then the status of the claim will be updated to Amend
And a status update entry will be made on the Status/History tab
And the details of the Amend status will include Date/Time : date/time that <Amend> status was saved
And the details of the Amend status will include Updated By: Name of user that updated the claim status
And the details of the Amend status will include Category: <Status Update>
And the details of the Amend status will include Comment: Amend updated from <previous status>
And the Claim updated is listed in Amend status

@Regression
Scenario Outline: 90441 - Verify the Amend status update entry is displayed in Status/History tab
Given I am a sales, sales management, operations, station owner, or claim specialist user <UserType>
And I am on the Claim Details page of a claim in Amend status
When I arrive on the Status/History tab
Then I will see the Amend status update entry displayed
And the Amend status update entry is not editable
Examples: 
| UserType |
| Internal |
| Claim Specialist |