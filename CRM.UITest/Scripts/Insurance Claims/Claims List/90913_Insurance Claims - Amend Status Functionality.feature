@90913 @Sprint91 
Feature: 90913_Insurance Claims - Amend Status Functionality
	
Scenario Outline: 90913_Verifyt the Amend status color code and edit icon
Given that I am a shp.entry, shp.entrynorates, shp.inquiry, shp.inquirynorates, sales, sales management, operations, station owner, or claims specialist <UserType> user,
And I am on the Claims List page
And a claim has been updated to the status Amend
When I arrive on Claims List page
Then I will see Amend displayed as the status in the Status column
And the Amend status will have a unique status color code #980000
And I will see an Edit icon next to the claim number in the DLSW Claim # column

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| ClaimSpecialist |

Scenario Outline: 90913_Verify edit icon for other than amend status
Given that I am a shp.entry, shp.entrynorates, shp.inquiry, shp.inquirynorates, sales, sales management, operations, station owner, or claims specialist <UserType> user,
And I am on the Claims List page
And a claim has been updated to the status other than Amend
When I arrive on Claims List page
And I should not see an Edit icon next to the claim number in the DLSW Claim # column

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| ClaimSpecialist  |

Scenario Outline: 90913_Verifyt the Submit Claim button will be renamed to Resubmit Claim
Given that I am a shp.entry, shp.entrynorates, shp.inquiry, shp.inquirynorates, sales, sales management, operations, station owner, or claims specialist <UserType> user,
And I am on the Claims List page
And I clicked on the edit icon of a claim in Amend Claim status
When I arrive on the Submit a Claim page
Then the Submit Claim button will be renamed Resubmit Claim

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| ClaimSpecialist  |