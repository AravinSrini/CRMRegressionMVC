@Sprint92 @91183 
Feature: 91183_Insurance Claims (B) - Payment Tab - Outstanding Amount Field Functionality
	
Scenario Outline: 91183 - Verify Outstanding amount value when user adds Payment with type - Carrier Direct Pay To Claimant or Carrier Payment To DLSW or Credit or Subrogation 
	Given I am a claim specialist user
	And I am on the Payments tab of Claim Details
	And I clicked the Add Payment button
	And I selected Payment Type as <PaymentType> in the Add Payment modal
	And I entered all other required information in the Add Payment modal
	When I click on Add Button
	Then The value in the Outstanding Amount field of the Payments tab will be reduced by the amount entered in the Payment Amount field of the Add Payment modal

Examples: 
| PaymentType                |
| CarrierDirectPayToClaimant |
| CarrierPaymentToDLSW       |
| Credit                     |
| Subrogation                |

Scenario: 91183 - Verify the amount value in the Claim List page grid
	Given I am a claim specialist user
	When I am on the Claims List page
	Then The Amount value of each displayed claim will equal the value of the Total Claimed Freight field of the Claim Details page

Scenario: 91183 - Verify if Total Claimed Freight value is getting added to Outstanding Amount field of the Payments tab_InternalUser
	Given I am a user with access to submit a claim 'username-CurrentSprintOperations' 'password-CurrentSprintOperations'
	When the claim has been submitted
	Then The value of the Total Claimed Freight field on the Claim Details page will be added to the Outstanding Amount field of the Payments tab

Scenario: 91183 - Verify if Total Claimed Freight value is getting added to Outstanding Amount field on Payments tab_ClaimspecialistUser
	Given I am a user with access to submit a claim 'username-CurrentsprintClaimspecialist' 'password-CurrentsprintClaimspecialist'
	When the claim has been submitted
	Then The value of the Total Claimed Freight field on the Claim Details page will be added to the Outstanding Amount field of the Payments tab

Scenario: 91183 - Verify outstanding amount value when user edits FreightCalculations section and clicks on Save Claim Details button 
	Given I am a claim specialist user
	And I am on Claim Details Page
	And I have made Edits to  FreightCalculations of Claim details page
	And The value of the Total Claimed Freight field changed
	When I click on Save Claim Details button of Claim Details page
	Then The Outstanding Amount equals (Updated Value of Total Claimed Freight) - (Previous Value of Total Claimed Freight) + (Current Value of Outstanding Amount)

@Sprint94 @91024 @92206
Scenario: 91183 - Verify list of payment Type 
	Given I am a claim specialist user
	And I am on the Payments tab of Claim Details
	And I clicked the Add Payment button
	When I click on Add Payment Model
	Then I should see All PaymentType in Paymenttype dropdwon list

@Sprint94 @109227

Scenario: 109227 - Verify Total Claimed Freight value when user add and edits Products Claimed section  
	Given I am a claim specialist user
	And I am on Claim Details Page
	When I made Edits to Products Claimed section of Claim details page
	Then The value of the Total Claimed Freight equals (TTL VAL) + (Original Claimed Freight) + (Return Claimed Freight) + (Replacement Claimed Freight)
	
Scenario: 109227 - Verify Total Claimed Freight value when user edits existing Products Claimed section  
	Given I am a claim specialist user
	And I am on Claim Details Page
	When I made Edits to existing Products Claimed section of Claim details page
	Then The value of the Total Claimed Freight equals (TTL VAL) + (Original Claimed Freight) + (Return Claimed Freight) + (Replacement Claimed Freight)
	
Scenario: 109227 - Verify Outstanding Amount value when user edits Products Claimed section and clicks on Save Claim Details 
	Given I am a claim specialist user
	And I am on Claim Details Page
	And I made Edits to Products Claimed section of Claim details page
	And The value of the Total Claimed Freight changed 
	When I click on Save Claim Details button of Claim Details page
	Then Outstanding Amount equals (Updated Value of Total Claimed Freight) - (Previous Value of Total Claimed Freight) + (Current Value of Outstanding Amount)








