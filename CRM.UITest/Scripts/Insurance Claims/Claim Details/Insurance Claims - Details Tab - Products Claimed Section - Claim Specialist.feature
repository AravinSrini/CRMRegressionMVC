@Sprint82 @43147
Feature: Insurance Claims - Details Tab - Products Claimed Section - Claim Specialist

@GUI
Scenario: 43147 - Verify the edit functionality in the Claim Details Page
	Given I am a Claims Specialist user
	When I am on the Claim Details Page
	Then I can edit Claim Type,Articles Type,Item/Model,Unit Value,Quantity,Weight,Description of Claimed Articles,Total Shipment Weight
	And I will see the Add Another Item hyper link

@GUI 
Scenario: 43147 - Verify the validations for editable fields in the Claim Details Page
	Given I am a Claims Specialist user
	When I am on the Claim Details Page
	Then Claim Type is required, select either Shortage or Damage
	And Articles Type is required, select either Used or New
    And Item/Model is required, alpha-numeric, text, special characters, max length 50
	And Unit Value is required, currency,allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2 decimal places
    And Quantity is required, numeric only,max length 4,format with comma when greater than 3 digits
    And Weight is required, numeric only,max length 6,format with comma when greater than 3 digits
    And Description of Claimed Articles is required, alpha-numeric, text, special characters, max length 250
    And Total Shipment Weight is required, numeric only, max length 6,format with comma when greater than 3 digits

@GUI @Functional 
Scenario: 43147 - Verify the add Another Item hyper link functionality in the Claim Details Page
	Given I am a Claims Specialist user
	When I am on the Claim Details Page
	When I click on the Add Another Item hyper link in the Products Claimed section
	Then I will be displayed the Claim Type,Articles Type,Item/Model,Unit Value,Quantity,Weight,Description of Claimed Articles,Total Shipment Weight
	And I should be displayed with remove button
	And Articles Type is required, select either Used or New
    And Item/Model is required, alpha-numeric, text, special characters, max length 50
	And Unit Value is required, currency,allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2 decimal places
    And Quantity is required, numeric only,max length 4,format with comma when greater than 3 digits
    And Weight is required, numeric only,max length 6,format with comma when greater than 3 digits
    And Description of Claimed Articles is required, alpha-numeric, text, special characters, max length 250
   And Total Shipment Weight is required, numeric only, max length 6,format with comma when greater than 3 digits

@GUI @Functional 
Scenario: 43147 - Verify the remove button functionality in the Claim Details Page
	Given I am a Claims Specialist user
	And I am on the Claim Details Page
	And I have Another additional Item details
	When I click on the remove button
	Then additional Products Claimed section will be removed

@GUI @Functional 
Scenario: 43147 - Verify the updated Ttl Pcs,Ttl Wt,Ttl Val functionlity for the edited item values in the Claim Details Page
	Given I am a Claims Specialist user
	And I am on the Claim Details Page
	When I have Another additional Item details
    Then Ttl Pcs field will update to display the sum of the Qty of all of the displayed products
    And Ttl Wt field will update to display the sum of the Ext Wt of all of the displayed products
    And Ttl Val field will update to display the sum of the Ext Val of all of the displayed products

