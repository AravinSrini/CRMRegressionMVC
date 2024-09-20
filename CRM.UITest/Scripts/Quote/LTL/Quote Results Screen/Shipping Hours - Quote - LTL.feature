@53753 @Sprint88 @Regression 
Feature: Shipping Hours - Quote - LTL
	
Scenario Outline: 53753_Verify if Open and Closed Time of the Customer is pushed to MG while submitting a Quote without selecting saved address
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations or station owner user
	And I am on the Get Quote LTL page
	And I did not select a saved address in the Shipping From section	
	And I am on the Quote Results(LTL) page
	When I click on the <button>
	Then CRM will send the Open Time of the customer to the MG Pickup Date Range - Early field
	And CRM will send the Close Time of the customer to the MG Pickup Date Range - Late field

	Examples: 
	| button                                |
	| Save Rate as Quote                    |
	| Save Insured Rate as Quote            |
	| Guaranteed Save Rate as Quote         |
	| Guaranteed Save Insured Rate as Quote |

Scenario Outline: 53753_Verify if Open and Closed Time of the Customer is pushed to MG while submitting a Quote by selecting saved address
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations or station owner user
	And I am on the Get Quote LTL page
	And I have selected saved address in the Shipping From section	
	And I am on the Quote Results(LTL) page
	When I click on the <button>
	Then CRM will send the Open Time of the selected saved address to the MG Pickup Date Range - Early field
	And CRM will send the Close Time of the selected saved address to the MG Pickup Date Range - Late field

	Examples: 
	| button                                |
	| Save Rate as Quote                    |
	| Save Insured Rate as Quote            |
	| Guaranteed Save Rate as Quote         |
	| Guaranteed Save Insured Rate as Quote |

Scenario Outline: 53753_Verify if Open and Closed Time of the Customer is pushed to MG while submitting a Quote with default shipper address
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations or station owner user
	And I am on the Get Quote LTL page
	And the Shipping From address was populated with a Default Shipper
	And I am on the Quote Results(LTL) page
	When I click on the <button>
	Then CRM will send the Open Time of the Default Shipper address to the MG Pickup Date Range - Early field
	And CRM will send the Close Time of the Default Shipper address to the MG Pickup Date Range - Late field

	Examples: 
	| button                                |
	| Save Rate as Quote                    |
	| Save Insured Rate as Quote            |
	| Guaranteed Save Rate as Quote         |
	| Guaranteed Save Insured Rate as Quote |
