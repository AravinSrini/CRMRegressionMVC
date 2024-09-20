@Sprint86 @47062 
Feature: Credit Hold - Quote (LTL) - Station

Scenario: 47062 - Verify the indicator getting displayed for Credit hold Customers on Quote list page dropdown list
	Given I am a sales, sales management, operation, or station owner user
	And I am on Quote List page
	And I clicked on All Customers drop down list
	When any associated customer has been placed on Credit Hold
	Then I will see an indicator that the customer is on Credit Hold

Scenario: 47062 - Verify the message displayed when user clicks on Submit Rate Request button by selecting Credit hold customer
	Given I am a sales, sales management, operation, or station owner user
	And I am on Quote List page
	And I have selected a customer that is on Credit Hold
	When I click on Submit Rate Request Button
	Then I will receive a Message: 'The selected customer is on Credit Hold.'

Scenario: 47062 - Verify the message displayed when user clicks on Create Shipment button of an active quote on Quote details section for Credit hold customer
	Given I am a sales, sales management, operation, or station owner user
	And I am on Quote List page
	And I have selected a customer that is on Credit Hold
	And I expanded the Quote Details of any displayed active LTL quote
	When I click on Create Shipment Button
	Then I will receive a Message: 'The selected customer is on Credit Hold.'

Scenario: 47062 - Verify the message displayed when user clicks on Requote button of an inactive quote on Quote details section for Credit hold customer
	Given I am a sales, sales management, operation, or station owner user
	And I am on Quote List page
	And I have selected a customer that is on Credit Hold
	And I expanded the Quote Details of any displayed inactive LTL quote
	When I click on Re-quote Button
	Then I will receive a Message: 'The selected customer is on Credit Hold.'