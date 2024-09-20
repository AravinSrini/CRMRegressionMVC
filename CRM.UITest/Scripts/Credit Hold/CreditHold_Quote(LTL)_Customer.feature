@47060 @Sprint86
Feature: CreditHold_Quote(LTL)_Customer
	
	@Regression
	Scenario: 47060-Verify Get Quote button is inactive for the external User associated Customer is on Credit hold
	Given I'm a shp.inquiry or shp.entry user who associated to the Credit hold Customer<Credit Hold Testing Customer>
	When I am on my Dashboard page
	Then the <Get Quote> button will be inactive

	Scenario: 47060-Verify the hover over message of Get Quote button for the external User associated Customer is on Credit hold
	Given I'm a shp.inquiry or shp.entry user who associated to the Credit hold Customer<Credit Hold Testing Customer>
	And I am on my Dashboard page
	When I hover Over inactive <Get Quote> button
	Then I will see a hover over message: <Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.>

	@Regression
	Scenario: 47060-Verify the Submit Rate Request button is inactive for the external User associated Custome is on Credit hold
	Given I'm a shp.inquiry or shp.entry user who associated to the Credit hold Customer<Credit Hold Testing Customer>
	When I arrive on the Quote List Page
	Then the <Submit Rate Request> button will be inactive

	Scenario: 47060-Verify the hover over message of Submit Rate Request button for the external User associated Customer is on Credit hold
	Given I'm a shp.inquiry or shp.entry user who associated to the Credit hold Customer<Credit Hold Testing Customer>
	And I am on Quote List Page
	When I hover Over inactive <Submit Rate Request> button
	Then I will see hover over message <Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.>

	@Regression
	Scenario: 47060-Verify the absence of Re-quote button to the Expired LTL Quote for the external User associated Customer is on Credit hold
	Given I'm a shp.inquiry or shp.entry user who associated to the Credit hold Customer<Credit Hold Testing Customer>
	And I am on Quote List Page
	When I expand the Quote Details of an expired LTL quote
	Then I will not see the <Re-quote> button
	
	@Regression
	Scenario: 47060-Verify the absence of Create Shipment button to the active Quote for the external User associated Customer is on Credit hold
	Given I'm a shp.inquiry or shp.entry user who associated to the Credit hold Customer<Credit Hold Testing Customer>
	And I am on Quote List Page
	When I expand the Quote Details of any active quote
	Then I will not see the <Create Shipment> button

	@Regression
	Scenario: 47060-Verify the Get Quote button is active for the external User associated to the Credit hold Customer
	Given I'm a Ship.entry or Ship.inquiry for a customer who is not on credit hold<ZZZ - Czar Customer Test>
	When I am on my Dashboard page
	Then the <Get Quote> button will be active

	Scenario: 47060-Verify the absence of hover over message of Get Quote button for the external User not associated to the Credit hold Customer
	Given I'm a Ship.entry or Ship.inquiry for a customer who is not on credit hold<ZZZ - Czar Customer Test>
	And I am on my Dashboard page
	When I hover Over active <Get Quote> button
	Then I will not see a hover over message: <Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.>

	@Regression
	Scenario: 47060-Verify the Submit Rate Request button is active for the external User not associated to the Credit hold Customer
	Given I'm a Ship.entry or Ship.inquiry for a customer who is not on credit hold<ZZZ - Czar Customer Test>
	When I arrive on the Quote List Page
	Then the <Submit Rate Request> button will be active

	Scenario: 47060-Verify the absence of hover over message of Submit Rate Request button for the external User not associated to the Credit hold Customer
	Given I'm a Ship.entry or Ship.inquiry for a customer who is not on credit hold<ZZZ - Czar Customer Test>
	And I am on Quote List Page
	When I hover Over active <Submit Rate Request> button
	Then I will not see a hover over message: <Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.>

	@Regression
	Scenario: 47060-Verify the presence of Re-quote button to the Expired LTL Quote for the external User not associated to the Credit hold Customer
	Given I'm a Ship.entry or Ship.inquiry for a customer who is not on credit hold<ZZZ - Czar Customer Test>
	And I am on Quote List Page
	When I expand the Quote Details of an expired LTL quote
	Then I will see the <Re-quote> button

	@Regression
	Scenario: 47060-Verify the presence of Create Shipment button to the active Quote for the external User not associated to the Credit hold Customer
	Given I'm a Ship.entry or Ship.inquiry for a customer who is not on credit hold<ZZZ - Czar Customer Test>
	And I am on Quote List Page
	When I expand the Quote Details of any active quote
	Then I will see the <Create Shipment> button