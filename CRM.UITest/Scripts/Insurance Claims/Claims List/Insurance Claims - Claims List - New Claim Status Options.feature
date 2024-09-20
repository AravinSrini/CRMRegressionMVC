@82957 @Sprint91 
Feature: Insurance Claims - Claims List - New Claim Status Options
	
Scenario Outline: 82957_Verify the new status Submitted displaying in place of Pending status and color code of Submitted status
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user, <UserType>
When I am on the Claims List page
Then I will see a Show Status option Pending replaced with Submitted
And I will see Color code of Pending for Submitted status

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| Claim Specialist |

Scenario Outline: 82957_Verify the default status selection and new Show status options
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user, <UserType>
When I am on the Claims List page
Then I will not be displayed with Pending status
And I will see a new show status option Submitted
And I will see a new show status option Amend
And I will see a new show status option Select All
And the order of Show status is Amend,Submitted,Open,Paid,Denied,Cancelled and Select All
And the Submitted status claims will be displayed by earlist to most recent Submit Date
And Submitted status is auto selected

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| Claim Specialist |

#To verify this scenario, claims with all the status's should be created/available as test data
Scenario Outline: 82957_Verify the default sort when user selects 'Select All' status
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user, <UserType>
And I am on the Claims List page
When I clicked on Select All status option
Then all status options will be auto selected
And the claims list will be refreshed to display all claims of Amend,Submitted,Open,Paid,Denied,Cancelled
And the default sort of the status Select All will be by Submit Date of earliest date to most recent date

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| Claim Specialist |

#To verify this scenario, claims with all the status's should be created/available as test data
Scenario Outline: 82957_Verify the claims list when user un check any of the Amend,Submitted,Open,Paid,Denied,Cancelled status's
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user, <UserType>
And I am on the Claims List page
And the status Select All was selected
When I uncheck any of the Amend,Submitted,Open,Paid,Denied,Cancelled status's
Then the Select All status will be un selected
And the Claims List will refresh to display all claims associated to the user in the status's that are checked

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| Claim Specialist |

Scenario Outline: 82957_Verify the claims list when user un check 'Select All' status
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user, <UserType>
And I am on the Claims List page
And the status Select All was selected
When I uncheck the Select All status
Then the default status Submitted will be selected
And Amend,Open,Paid,Denied,Cancelled,Select All status's will be unchecked
And the list will refresh to display claims in Submitted status

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| Claim Specialist |

Scenario Outline: 82957_Verify the claims list when checks more than one status
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user, <UserType>
And I am on the Claims List page
When I have selected more than one status
Then the claims list default sort will be by earliest Submit Date to most recent Submit Date

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| Claim Specialist |

@98287 @Ignore
Scenario Outline: 98287_Verify the status 'Select All' auto-selected when user selects all other status's
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user, <UserType>
And I am on the Claims List page
When I check all the Amend,Submitted,Open,Paid,Denied,Cancelled status's
Then Select All status option will be auto selected
And the Claims List will refresh to display all claims associated to the user in the status's that are checked

Examples: 
| UserType         |
| External         |
| Internal         |
| Sales            |
| Claim Specialist |
