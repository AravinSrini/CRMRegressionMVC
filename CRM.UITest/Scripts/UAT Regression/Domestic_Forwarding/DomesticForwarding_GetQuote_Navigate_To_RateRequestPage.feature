@DomesticForwarding_GetQuote_Navigate_To_RateRequestPage @30012 @Regression @Sprint70
Feature: DomesticForwarding_GetQuote_Navigate_To_RateRequestPage
	
@GUI
Scenario: Verify the Rate Request Shipment Locations and Dates Page Navigation functionality from Dashboard page
	Given I am a shp.entry,shp.inquiry user
	When I select Domestic Forwarding service<Type> and Click on Get Quote button from Dashboard page
	Then I will be Navigated to the Rate Request Shipment Locations and Dates Page for Domestic Forwarding


@GUI
Scenario: Verify the Rate Request Shipment Locations and Dates Page Navigation functionality from Quote List page
	Given I am a shp.entry,shp.inquiry user
    When I select Domestic Forwarding service<Type> from Get Quote page
    Then I will be Navigated to the Rate Request Shipment Locations and Dates Page for Domestic Forwarding
