@Sprint92 @91189
Feature: Insurance Claims - Claim Acknowledgement Letter to Customer Functionality

Scenario: 91189_Verify the hover over message on mouse hovering Ack link on Claims List page
	Given I am a claim specialist user
	And I am on the Claims List page
	And the Date Ack To Claimant information from the Details tab of the Claim Details page has been saved to the claim
	When I hover over the Ack date in the Dates column
	Then I will see a rollover message "Open Claim Acknowledgement Letter PDF"

Scenario: 91189_Verify the copy of the Acknowledgement letter to the customer displayed in new tab on click of Ack link
	Given I am a claim specialist user
	And I am on the Claims List page
	And the Date Ack To Claimant information from the Details tab of the Claim Details page has been saved to the claim
	When I click on the link in the Ack field of Dates Column
	Then I will see a copy of the Acknowledgement Letter to the customer in a new tab

Scenario: 91189_Verify the updated Date Ack To Claimant saved in the Ack field of Dates column on Claims List page
	Given I am a claim specialist user
	And I am on the Claims List page
	And I Click on Claim number which already have Ack value
	And I update Date Ack To Claimant to another date in Claim Details page 
	When the Date Ack To Claimant from the Details tab of the Claim Details page has been saved to the claim
	Then I will see the updated date that was saved in the Ack field of the Dates column

Scenario Outline: 91189_Verify Claim Acknowledgement letter icon displayed next to the Customer Name in Customer column
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or station owner <UserType>
	And I am on the Claims List page
	When the Date Ack To Claimant has been saved to the claim
	Then I will see the Claim Acknowledgement icon displayed next to the customer name in the Customer column

Examples: 
	| UserType |
	| External |
	| Internal |
	| Sales    |

Scenario Outline: 91189_Verify Claim Acknowledgement letter icon not displayed next to the Customer Name in Customer column
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or station owner <UserType>
	And I am on the Claims List page
	When the Date Ack To Claimant has not been saved to the claim
	Then I will not see the Claim Acknowledgement icon displayed next to the customer name in the Customer column

Examples: 
	| UserType |
	| External |
	| Internal |
	| Sales    |

Scenario Outline: 91189_Verify the hover over message on mouse hovering Claim Acknowledgement icon on Claims List page
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or station owner <UserType>
	And I am on the Claims List page
	And I have a claim with Date Ack To Claimant
	When I hover over the Claim Acknowledgement icon
	Then I will see a rollover message for non ClaimSpecialist User as "Open Claim Acknowledgement PDF"
Examples: 
	| UserType |
	| External |
	| Internal |
	| Sales    |

Scenario Outline: 91189_Verify the copy of the Acknowledgement letter to the customer displayed in new tab on click of Claim Acknowledgement icon
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or station owner <UserType>
	And I am on the Claims List page
	And I have a claim with Date Ack To Claimant	
	When I clicked on the Claim Acknowledgement icon in the Customer column
	Then I will see a copy of the Acknowledgement Letter to the customer in a new tab

	
Examples: 
	| UserType |
	| External |
	| Internal |
	| Sales    |