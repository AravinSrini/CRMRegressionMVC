@35476 @Regression @Sprint77
Feature: International_Start New Rate Request button

@Regression
Scenario: 35476_Verify Start New Rate Request button functionality on Confirmation Page_from Dashboard
        Given I am ashp.inquiry user
		And I select International service type, level and Click on Get Quote button from Dashboard page
		And I am on International Shipment Information page of RateRequest 
		And I entered data in Destination section of International RateRequest 
		And I entered data in Shipment Details and Freight Description section 
		And I navigated to Confirmation page
        When I click on Start New Rate Request button
        Then I should be navigating back to Get Quote tiles page

@Regression
Scenario: 35476_Verify Start New Rate Request button functionality on Confirmation Page_from Quote module
        Given I am ashp.inquiry user 
        And I select International service type, level from Get Quote page
        And I am on International Shipment Information page of RateRequest
		And I entered data in Destination section of International RateRequest
		And I entered data in Shipment Details and Freight Description section
		And I navigated to Confirmation page
        When I click on Start New Rate Request button
        Then I should be navigating back to Get Quote tiles page

