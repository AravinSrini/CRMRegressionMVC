@51424 @Sprint86

Feature: Credit Hold - Accessing Quote and Shipment Pages- LTL Services

Scenario: 51424 - Verify the modal message and close modal option on Credit Hold modal from Get Quote page for external user
	Given I am a Credit Hold customer
	When I am on Get Quote LTL page
	Then I will see a Credit Hold modal
	And I will see a message in the modal
	And I have the option to close the modal

@ignore
Scenario: 51424 - Verify by clicking on OK button on Credit Hold modal from Get Quote page as a external user
	Given I am a Credit Hold customer
	And I am on the GetQuote LTL page
	And I received the Credit Hold modal
	When I click on OK button in the Credit Hold modal
	Then I arrive on the QuoteList page

@ignore
Scenario: 51424 - Verify the modal message and close modal option on Credit Hold modal from Add Shipment page for external user
	Given I am a Credit Hold customer
	When arrive on the Add Shipment LTL page
	Then I will see a Credit Hold modal in Add Shipment page
	And I will see a message in credit hold modal
	And I have the option to close the credit hold modal

@ignore
Scenario: 51424 - Verify by clicking on OK button on Credit Hold modal from Add Shipment page as a external user
	Given I am a Credit Hold customer
	And I am on the Add Shipment LTL page
	And I received the Credit Hold modal in Add Shipment page
	When I click on the OK button in the Credit Hold modal from Add Shipment page
	Then I will arrive on the Shipment List page

@ignore
Scenario: 51424 - Verify the modal message and close modal option on Credit Hold modal from Get Quote page for internal user
	Given I am a sales management, operations, or station owner user
	And I am sending a credit hold customer name along with page url
	When I arrive on the Get Quote LTL page
	Then I will see a Credit Hold modal
	And I will see a message in the modal
	And I have the option to close the modal

@ignore
Scenario: 51424 - Verify by clicking on OK button on Credit Hold modal from Get Quote page as a internal user
	Given I am a sales management, operations, or station owner user
	And I am sending a credit hold customer name along with page url
	And I arrive on the Get Quote LTL page
	And I received the Credit Hold modal in Get Quote page
	When I click on OK button in the Credit Hold modal
	Then I will arrive on the Quote List page

@ignore
Scenario: 51424 - Verify the modal message and close modal option on Credit Hold modal from Add Shipment page for internal user
	Given I am a sales management, operations, or station owner user
	When I am sending a credit hold customer name along with the page url
	Then I will see a Credit Hold modal in Add Shipment page
	And I will see a message in the modal from Add Shipment page
	And I have the option to close the modal

@ignore
Scenario: 51424 - Verify by clicking on OK button on Credit Hold modal from Add Shipment page as a internal user
	Given I am a sales management, operations, or station owner user
	And I am sending a credit hold customer name along with the page url
	And I received the Credit Hold modal in Add Shipment page
	When I click on the OK button in Credit Hold modal
	Then I will arrive on Shipment List page
	