@35471 @Regression @Sprint77
Feature: Regression - International - Rate Request Navigation

@UI@Functional @Regression

Scenario: 35471_Verify Navigation to shipment information page_from Dashboard
        Given I am ashp.inquiry user
        When I select International service type, level and Click on Get Quote button from Dashboard page
        Then I must land on the Rate Request: Shipment Information page for International
		
                                                                                                                                                                                                               

@UI@Functional @Regression
Scenario: 35471_Verify Navigation to shipment information page_from quote module
        Given I am ashp.inquiry user
        When I select International service type, level from Get Quote page
        Then I must land on the Rate Request: Shipment Information page for International 
		




