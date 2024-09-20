@50760 @Regression @Sprint86 
Feature: RateResultsPage-InsuranceAllRisk-AddrecalculationIndicator.

Scenario: 50760_Verify that user see an indicator that CRM is updating the results in Quote Results(LTL) page.
	Given that I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
    And I am on the quote results (LTL) page
    And I have a value in the insured Value field
    When I clicked on the show Insured rate button
    Then I will see an Indicator that CRM is updating the results.