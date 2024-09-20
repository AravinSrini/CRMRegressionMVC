@90440 @Sprint94 @Functional
Feature: Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission

Scenario Outline: 90440_Verify Export dropdown options of a non amended claim for Claim Specialist user
	Given I am a claim specialist user
	And I am on Claim Details page of a claim that was not previously amended <claimNumber>
	When I clicked on the Export button
	Then I will see Claim Packet new option
	And I will see the options listed in following order Claim Submitted By Customer, History Tab, Claim Packet and Payment Tab

	Examples: 
	| claimNumber |
	| 2019000712  |

Scenario Outline: 90440_Verify Export dropdown options of an amended claim for Claim Specialist user
	Given I am a claim specialist user
	And I am on the Claim Details page of a claim that was previously amended <claimNumber>	
	When I clicked on the Export button
	Then I will see Claim Packet new option
	And I will see the options listed in following order Claim Submitted By Customer, Claim Amended By Customer, History Tab, Claim Packet and Payment Tab

	Examples: 
	| claimNumber |
	| 2019000695  |

Scenario: 90440_Verify the Select Document for Export modal for Claim Specialist user
	Given I am a claim specialist user
	And I am on Claim Details page
	And I clicked on the Export button
	When I selected Claim Packet
	Then I will see a Select Documents for Export modal

Scenario Outline: 90440_Verify the Details of Select Document for Export modal for Claim Specialist user
	Given I am a claim specialist user
	And I am on the Claim Details page of a claim that was previously amended <claimNumber>	
	And I clicked on the Export button
	When I selected Claim Packet
	Then I will see the list of documents that have been saved to the claim include the Document type and Document Name.extension in the modal	
	And Each document will have a check box, its selectable
	And by default displayed documents will be auto-selected
	And I will see the verbiage- Note: Claim form PDF will be automatically included
	And I will see a Cancel, Download buttons

	Examples: 
	| claimNumber |
	| 2019000695  |

Scenario: 90440_Verify the Cancel button functionality of Select Document for Export modal for Claim Specialist user
	Given I am a claim specialist user
	And I am on Claim Details page
	And I clicked on the Export button
	And I selected Claim Packet	
	When I click on the Cancel button of Select Documents for Export modal
	Then the modal will close

Scenario: 90440_Verify Select Documents for Export modal not closing on clicking outside the modal
	Given I am a claim specialist user
	And I am on Claim Details page
	And I clicked on the Export button
	And I selected Claim Packet
	And I will see a Select Documents for Export modal
	When I click anywhere outside the modal
	Then the modal should not close

Scenario Outline: 90440_Verify the claim packet option in non amended claim for the users other than claim specialist
	Given I am an operations, sales, sales management or station owner user <UserName>,<Password>
	And I am on the Claim List page
	And I am on the Claim Details page of a claim that was not previously amended
	When I clicked on the Export button
	Then I will not see a new option Claim Packet

Examples:
| UserName                         | Password                         |
| username-CurrentSprintOperations | password-CurrentSprintOperations |
| username-CurrentSprintSales      | password-CurrentSprintSales      |

Scenario Outline: 90440_Verify the claim packet option in amended claim for the users other than claim specialist
	Given I am an operations, sales, sales management or station owner user <UserName>,<Password>
	And I am on the Claim List page
	And I am on Claim Details page of a claim that was previously amended
	When I clicked on the Export button
	Then I will not see a new option Claim Packet

Examples:
| UserName                         | Password                         |
| username-CurrentSprintOperations | password-CurrentSprintOperations |
| username-CurrentSprintSales      | password-CurrentSprintSales      |