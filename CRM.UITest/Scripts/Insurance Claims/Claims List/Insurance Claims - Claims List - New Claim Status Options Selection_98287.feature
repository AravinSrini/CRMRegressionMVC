Feature: Insurance Claims - Claims List - New Claim Status Options Selection_98287
	Check box Select All has to be AutoSelected when Check boxes - Amend, Submitted ,Open, Paid, Denied & Cancelled are selected
	And Only Claims associated to the user should be orderered and displayed

@98287 @Sprint92 
Scenario: 98287_Insurance Claims - Claims List - New Claim Status Options Selection-using CurrentSprintOperations user
	Given I am a CurrentSprintOperations user
	And I am on the Claim List page
	When I click the Check boxes Amend, Submitted ,Open, Paid, Denied & Cancelled
	Then Check box Select All has to be AutoSelected
	And Claims associated to the user in Status Amend,Submitted,Open,Paid,Denied,Cancelled should be displayed
	And the order of record display should be earliest date to most recent dates

@98287 @Sprint92
Scenario: 98287_Insurance Claims - Claims List - New Claim Status Options Selection-using CurrentsprintShpentry user
	Given I am a CurrentsprintShpentry user
	And I am on the Claim List page
	When I click the Check boxes Amend, Submitted ,Open, Paid, Denied & Cancelled
	Then Check box Select All has to be AutoSelected
	And Claims associated to the user in Status Amend,Submitted,Open,Paid,Denied,Cancelled should be displayed
	And the order of record display should be earliest date to most recent dates

@98287 @Sprint92
Scenario: 98287_Insurance Claims - Claims List - New Claim Status Options Selection-using CurrentsprintClaimspecialist user
	Given I am a CurrentsprintClaimspecialist user
	And I am on the Claim List page
	When I click the Check boxes Amend, Submitted ,Open, Paid, Denied & Cancelled
	Then Check box Select All has to be AutoSelected
	And Claims associated to the user in Status Amend,Submitted,Open,Paid,Denied,Cancelled should be displayed
	And the order of record display should be earliest date to most recent date

@98287 @Sprint92
Scenario: 98287_Insurance Claims - Claims List - New Claim Status Options Selection-using CurrentsprintSales user
	Given I am a CurrentsprintSales user
	And I am on the Claim List page
	When I click the Check boxes Amend, Submitted ,Open, Paid, Denied & Cancelled
	Then Check box Select All has to be AutoSelected
	And Claims associated to the user in Status Amend,Submitted,Open,Paid,Denied,Cancelled should be displayed
	And the order of record display should be earliest date to most recent dates
