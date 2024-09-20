@NinjaSprint21 @46192
Feature: Customer Invoice - Print Invoices

@Functional @GUI
Scenario: 46192_Verify the print invoices button hidden when no invoices are shown
	Given I am a user with access to Customer Invoices
	And I am on the Customer Invoices page
	When the grid is not populated with invoices
	Then I will not see the print invoices button

@Functional @GUI
Scenario: 46192_Verify the existence and behaviour of Print Invoices button when invoices exists in the Customer Invoice grid
	Given I am a user with access to Customer Invoices
	And I am on the Customer Invoices page
	When the grid is populated with invoices
	Then I will have the option to select any displayed invoice
	And I will have the option to select all of the displayed invoices,
	And I will see a Print Invoices button
	And the Print Invoices button is inactive

@Functional @Acceptance @GUI
Scenario: 46192_Verify that the print invoices button is inactive while no invoices are selected
	Given I am a user with access to Customer Invoices
	And I am on the Customer Invoices page
	And the grid is populated with invoices
	When There are no invoices selected in the grid
	Then the Print Invoices button is inactive

@Functional @Acceptance @GUI
Scenario: 46192_Verify that the print invoices button becomes active when one or more invoices are selected
	Given I am a user with access to Customer Invoices
	And I am on the Customer Invoices page
	And the grid is populated with invoices
	When I have selected invoices from the customer invoice grid
	Then the Print Invoices button is active

@Functional @Acceptance
Scenario Outline: 46192_Verify when the print invoices button is pressed a new tab is opened and the file is downloaded
	Given I am a user with access to Customer Invoices
	And I am on the Customer Invoices page
	And I selected <Selected Amount> displayed invoices
	When I click on the button print invoices
	Then a new tab will open
	And the selected invoice(s) will download into a zip folder in the new tab
	Examples: 
		| Selected Amount |
		| 1               |
		| 2               |
		| 3               |		