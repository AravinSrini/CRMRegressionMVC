@Sprint91 @91148
Feature: 91148 - Insurance Claims - Submit a Claim page - Calculate Claim Costs

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters Unit Value and Quantity on the Claims section of Submit a Claim page_ExternalUser
	Given I am a external user who can submit a claim
	And I am on Submit a Claim page
	When I enter values on Unit Value and Quantity fields of Claim Details section
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Unit Value*Quantity)+(Current Value of Subtotal All Claim Value field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters Unit Value and Quantity on the Claims section of Submit a Claim page_InternalUser
	Given I am an internal user who can submit a claim
	And I am on Submit a Claim page
	When I enter values on Unit Value and Quantity fields of Claim Details section
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Unit Value*Quantity)+(Current Value of Subtotal All Claim Value field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters Unit Value and Quantity on the Claims section of Submit a Claim page_ClaimSpecialistUser
	Given I am a Claim Specialist user who can submit a claim
	And I am on Submit a Claim page
	When I enter values on Unit Value and Quantity fields of Claim Details section
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Unit Value*Quantity)+(Current Value of Subtotal All Claim Value field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters Unit Value and Quantity for additional item on the Claims section of Submit a Claim _ExternalUser
	Given I am a external user who can submit a claim
	And I am on the Submit a Claim page
	And I clicked on the Add Another Item button in the Claim Details section
	When I enter values on Unit Value and Quantity fields of the additional item section of Claim Details section
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Item1 Unit Value*Quantity)+(Item2 Unit Value*Quantity)...+(Current Value of Subtotal All Claim Value field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters Unit Value and Quantity for additional item on the Claims section of Submit a Claim page_InternalUser
	Given I am an internal user who can submit a claim
	And I am on the Submit a Claim page
	And I clicked on the Add Another Item button in the Claim Details section
	When I enter values on Unit Value and Quantity fields of the additional item section of Claim Details section
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Item1 Unit Value*Quantity)+(Item2 Unit Value*Quantity)...+(Current Value of Subtotal All Claim Value field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters Unit Value and Quantity for additional item on the Claims section of Submit a Claim page_ClaimSpecialistUser
	Given I am a Claim Specialist user who can submit a claim
	And I am on the Submit a Claim page
	And I clicked on the Add Another Item button in the Claim Details section
	When I enter values on Unit Value and Quantity fields of the additional item section of Claim Details section
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Item1 Unit Value*Quantity)+(Item2 Unit Value*Quantity)...+(Current Value of Subtotal All Claim Value field)


Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters a value in the "Value" field of Original Freight Charges option_ExternalUser
	Given I am a external user who can submit a claim
	And I am on the Submit a Claim page
	And I selected Yes for Do you wish to add freight charges? option in the Claim Details section
	When I enter a value in the Value field of the Original Freight Charges option
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Current Value of Subtotal All Claim Value field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters a value in the "Value" field of Original Freight Charges option_InternalUser
	Given I am an internal user who can submit a claim
	And I am on the Submit a Claim page
	And I selected Yes for Do you wish to add freight charges? option in the Claim Details section
	When I enter a value in the Value field of the Original Freight Charges option
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Current Value of Subtotal All Claim Value field)

	Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters a value in the "Value" field of Original Freight Charges option_ClaimSpecialistUser
	Given I am a Claim Specialist user who can submit a claim
	And I am on the Submit a Claim page
	And I selected Yes for Do you wish to add freight charges? option in the Claim Details section
	When I enter a value in the Value field of the Original Freight Charges option
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Current Value of Subtotal All Claim Value field)


Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters a value in the "Value" field of Return Freight Charges option_ExternalUser
	Given I am a external user who can submit a claim
	And I am on the Submit a Claim page
	And I selected Yes for Do you wish to add freight charges? option in the Claim Details section
	And I selected the Return Freight Charges option
	When I enter a value in the Value field of the Return Freight Charges option
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Current Value of Subtotal All Claim Value field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters a value in the "Value" field of Return Freight Charges option_InternalUser
	Given I am an internal user who can submit a claim
	And I am on the Submit a Claim page
	And I selected Yes for Do you wish to add freight charges? option in the Claim Details section
	And I selected the Return Freight Charges option
	When I enter a value in the Value field of the Return Freight Charges option
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Current Value of Subtotal All Claim Value field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters a value in the "Value" field of Return Freight Charges option_ClaimSpecialistUser
	Given I am a Claim Specialist user who can submit a claim
	And I am on the Submit a Claim page
	And I selected Yes for Do you wish to add freight charges? option in the Claim Details section
	And I selected the Return Freight Charges option
	When I enter a value in the Value field of the Return Freight Charges option
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Current Value of Subtotal All Claim Value field)


Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters a value in the "Value" field of Replacement Freight Charges option_ExternalUser
	Given I am a external user who can submit a claim
	And I am on the Submit a Claim page
	And I selected Yes for Do you wish to add freight charges? option in the Claim Details section
	And I selected the Replacement Freight Charges option
	When I enter a value in the Value field of the Replacement Freight Charges option
	Then Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Value of Replacement Freight Charges)+(Current Value of <Subtotal All Claim Value> field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters a value in the "Value" field of Replacement Freight Charges option_InternalUser
	Given I am an internal user who can submit a claim
	And I am on the Submit a Claim page
	And I selected Yes for Do you wish to add freight charges? option in the Claim Details section
	And I selected the Replacement Freight Charges option
	When I enter a value in the Value field of the Replacement Freight Charges option
	Then Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Value of Replacement Freight Charges)+(Current Value of <Subtotal All Claim Value> field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters a value in the "Value" field of Replacement Freight Charges option_ClaimSpecialistUser
	Given I am a Claim Specialist user who can submit a claim
	And I am on the Submit a Claim page
	And I selected Yes for Do you wish to add freight charges? option in the Claim Details section
	And I selected the Replacement Freight Charges option
	When I enter a value in the Value field of the Replacement Freight Charges option
	Then Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Value of Replacement Freight Charges)+(Current Value of <Subtotal All Claim Value> field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters Unit Value and Quantity for additional item and Freight Charges on the Claims section of Submit a Claim page_ExternalUser
	Given I am a external user who can submit a claim
	And I am on the Submit a Claim page
	And I clicked on the Add Another Item button in the Claim Details section
	And I enter values on Unit Value and Quantity fields of the additional item section of Claim Details section
	When I enter values on Original Freight Charges, Return Freight Charges, Replacement Freight Charges fields
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Value of Replacement Freight Charges)+(Current Value of <Subtotal All Claim Value> field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters Unit Value and Quantity for additional item and Freight Charges on the Claims section of Submit a Claim page_InternalUser
	Given I am an internal user who can submit a claim
	And I am on the Submit a Claim page
	And I clicked on the Add Another Item button in the Claim Details section
	And I enter values on Unit Value and Quantity fields of the additional item section of Claim Details section
	When I enter values on Original Freight Charges, Return Freight Charges, Replacement Freight Charges fields
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Value of Replacement Freight Charges)+(Current Value of <Subtotal All Claim Value> field)

Scenario: 91148 - Verify the calculation on "Subtotal All Claim Value" field when user enters Unit Value and Quantity for additional item and Freight Charges on the Claims section of Submit a Claim page_ClaimSpecialistUser
	Given I am a Claim Specialist user who can submit a claim
	And I am on the Submit a Claim page
	And I clicked on the Add Another Item button in the Claim Details section
	And I enter values on Unit Value and Quantity fields of the additional item section of Claim Details section
	When I enter values on Original Freight Charges, Return Freight Charges, Replacement Freight Charges fields
	Then The Subtotal All Claim Value field will auto-populate using the following calculation : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Value of Replacement Freight Charges)+(Current Value of <Subtotal All Claim Value> field)


Scenario: 91148 - Verify if the calculated value of the Subtotal All Claim Value is saved to the Total Claimed Freight field of the Claim Details page_ExternalUser
	Given I am a external user who can submit a claim
	And I am on the Submit a Claim page
	And I completed all required information for an external user
	When I click on Submit Claim Button
	Then The calculated value of the Subtotal All Claim Value will be saved
	And The calculated value of the Subtotal All Claim Value will be displayed to the Total Claimed Freight field of the Claim Details PDF

Scenario: 91148 - Verify if the calculated value of the Subtotal All Claim Value is saved to the Total Claimed Freight field of the Claim Details page_InternalUser
	Given I am an internal user who can submit a claim
	And I am on the Submit a Claim page
	And I completed all required information for an internal user
	When I click on Submit Claim Button
	Then The calculated value of the Subtotal All Claim Value will be saved
	And The calculated value of the Subtotal All Claim Value will be saved to the Total Claimed Freight field of the Claim Details page

Scenario: 91148 - Verify if the calculated value of the Subtotal All Claim Value is saved to the Total Claimed Freight field of the Claim Details page_ClaimSpecialistUser
	Given I am a Claim Specialist user who can submit a claim
	And I am on the Submit a Claim page
	And I completed all required information for ClaimSpecialist User
	When I click on Submit Claim Button
	Then The calculated value of the Subtotal All Claim Value will be saved
	And Calculated value of the Subtotal All Claim Value will be saved to the Total Claimed Freight field of the Claim Details page



