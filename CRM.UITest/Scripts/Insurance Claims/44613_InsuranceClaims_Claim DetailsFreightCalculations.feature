@Sprint83 @44613 @Functional
Feature: 44613_InsuranceClaims_Claim DetailsFreightCalculations


Scenario Outline: 44613-Verify any edited field in Freight Calculations Type will be saved
   Given I am a Claims Specialist user
   And   I am on the Claim Details page for any claim
   And   I have  made an edit to any of the Freight Calculations Type - Claimable?, Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #,Total Claimed Freight,Comments <FrieghtType>
   When  I click on the button on Claim Details page
   Then  The edits will be saved <FrieghtType>

   Examples: 
   | FrieghtType |
   | Original    |
   | Return      |
   | Replacement |


Scenario: 44613-Verify all edited field in Freight Calculations section will be saved
   Given I am a Claims Specialist user
   And   I am on the Claim Details page for any claim
   And   I have  made edit in Freight Calculations section
   When  I click on the Save Claim Details button on Claim Details page
   Then  The edits will be saved