@40457 @Sprint84
Feature: Insurance Claims - History Tab - Status and System Comments

@Functional
Scenario:40457_Test to verify the History Tab_comments creation for new submitted Calim
Given I am a sales, sales management, operations, station owner, or claims specialist user
When a new claim is submitted
Then a comment will be created
And the Date/Time field will display the Date and Time that the claim was submitted to DLSW -US Central
Then the Updated By field will display 'First Name_Last Name' of the user that submitted the claim to DLSW
And the Category will display <Status Update>
And the Comment will display <Claim submitted to DLSW>
And the comment will be visible on the history tab
And the comment will not be editable

@Functional
Scenario Outline:40457_Test to verify the History Tab_comments creation when Carrier Ack field of the Claim Details tab is edited
Given I am a claims specialist user
And I am on Claim Detailspage of new submitted claim
When the Carrier Ack <CurrentValue> field of the Claim Details tab is edited
Then  a comment will be created
And the Date/Time field will display the Date and Time that the Carrier Ack field was updated-US Central
And the Updated By field will display the First Name and Last Name of the user that edited the Carrier Ack field
And the Category in History Tab will display 'Carrier Ack'
And the Comment in History Tab will display <CurrentValue>
And the comment will be visible on the history tab
And the comment will not be editable

Examples: 
| CurrentValue |
| Yes          |
| No           |