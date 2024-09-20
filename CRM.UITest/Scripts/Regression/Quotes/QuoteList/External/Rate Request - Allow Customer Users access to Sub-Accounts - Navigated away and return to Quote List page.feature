@Regression @Quote @29508 @Sprint79
Feature:Feature: Rate Request - Allow Customer Users access to Sub-Accounts - Navigated away and return to Quote List page
@Acceptance @GUI @Functional
Scenario: 29508_Test to verify Quote List page when user navigated away from quotelist page and navigated back to the quotelist page 
        Given I am a shp.entry or shp.inquiry user associated to a primary account that has sub-accounts
        And I am on the Quote List page
        And I select primary-Customer from the customer drop down list
        And I have navigated away from the Quote List page
        When I return to the Quote List Page
        Then previously selected customer will be selected in the customer drop down list
        And Quote List grid will refresh to display all quotes associated to previously selected customer for the past 30 days

@Acceptance @GUI @Functional
Scenario: 29508_Test to verify shipment List page when Navigated away from Quote List page
      Given I am a shp.entry or shp.inquiry user associated to a primary account that has sub-accounts
       And I am on the Quote List page
       And I select Customer from the customer drop down list
       When I navigate to the shipment List page
       Then customer previously selected will be selected in the customer drop down list of shipment list page
       And shipment List grid will refresh to display all shipments associated to previously selected customer for the past 30 days
