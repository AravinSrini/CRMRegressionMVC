@44611 @Sprint83 @Regression
Feature: Insurance Claims - Claim Details - Consignee
	
@DBVerification
Scenario: 44611_Verify the edits saved for the Consignee when user clicked on Save Claim Details
	Given I am a Claims Specialist user
	And I am on Claim Detailspage
	And I have updated the fields - Name, Address, City, State, Zip, Country in Consignee Section
	And I have updated the fields - Carrier Ack, Carrier Ack Date, Carrier Claim # in Carrier OS&D Actions Section
	And I have updated the fields - Carrier PRO Date, BOL/Ship Date, Delivery Date in Key Dates Section
	And I have updated Remarks field
	When I click on SaveClaimDetails button
	Then Consignee values should be saved with the updated values

@DBVerification
Scenario Outline: 44611_Verify the edits saved for any of the Consignee fields when user clicked on Save Claim Details
	Given I am a Claims Specialist user
	And I am on Claim Detailspage
	And I have edited any of the fields of <Consignee> section of Details page
	When I click on SaveClaimDetails button
	Then The Consignee <Consignee> fields should be saved with the updated values

Examples:     
| Consignee        |
| Name             |
| Address          |
| City             |
| State            |
| Zip              |
| Country          |
| Carrier Ack      |
| Carrier Ack Date |
| Carrier Claim #  |
| Carrier PRO Date |
| BOL/Ship Date    |
| Delivery Date    |
| Remarks          |

@Sprint92 @92464
Scenario: 92464 Verify Edit and Save Functionality of Carrier Ack, Carrier Ack Date, Carrier Claim Number 
Given that I am a Claims Specialist user
And I am on the Claim Details page of a claim
And I have edited Carrier Ack, Carrier Ack Date, Carrier Claim Number in the Carrier OS&D Actions section
When I have Click the Save Claim Details button
Then the information will be saved

@Sprint92 @92464
Scenario: 92464 Verify the Carreir Claim Number in the Claim List Page upon edit and Save from the Claim Details page of the Carrier OS&D Actions
Given that I am a Claims Specialist user
And I am on the Claim Details page of a claim
And I edited the Carrier Claim Number field of the Carrier OS&D Actions section
And I have Clicked the Save Claim Details button
When I arrive on the Claim List page
Then I will see the saved values of the Carrier Claim Number field of the Carrier OS&D Actions section displayed in the Carrier field of the Claim Numbers Column
