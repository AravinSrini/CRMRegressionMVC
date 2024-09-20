@Regression @Quote @29507 @NinjaSprint16 
Feature: Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and Get Quote (LTL) page

@Acceptance @GUI @Functional
Scenario: 29507_Test to verify Get Quote tile navigation when user selects the primary account of MG
        Given I am a shp.entry or shp.inquiry user associated to a primary account of TmsType MG that has sub-accounts
        And I am on the QuoteList page
		And I select primary-Customer ZZZ - Czar Customer Test from the customer drop down list of QuoteList page
        When I click on Submit Rate Request button in Quotes page
        Then I will arrive on the Get Quote tile page
        And I will see the associated service type selections for TmsType Mg
		And I will see the customer name displayed on the Get Quote tile page ZZZ - Czar Customer Test

@Acceptance @GUI @Functional
Scenario: 29507_Test to verify Get Quote tile navigation when user selects the primary account of Tms type Both
        Given I am a shp.entry or shp.inquiry user associated to a primary account of TmsType Both that has sub-accounts
        And I am on the QuoteList page
		And I select primary-Customer ZZZ - GS Customer Test from the customer drop down list of QuoteList page
        When I click on Submit Rate Request button in Quotes page
        Then I will arrive on the Get Quote tile page
        And I will see the associated service type selections for TmsType Both
		And I will see the customer name displayed on the Get Quote tile page ZZZ - GS Customer Test

@Acceptance @GUI @Functional
Scenario: 29507_Test to verify Get Quote tile navigation when user selects the sub account of TmsType MG
        Given I am a shp.entry or shp.inquiry user associated to a primary account of TmsType MG that has sub-accounts
        And I am on the QuoteList page
		And I select sub-Customer SubAccountOfTypeMg from the customer drop down list of QuoteList page
        When I click on Submit Rate Request button in Quotes page
        Then I will arrive on the Get Quote tile page
        And I will see only LTL service type option 
        And I will see the customer name displayed on the Get Quote tile page ZZZ - Czar Customer Test - SubAccountOfTypeMg

@Acceptance @GUI @Functional
Scenario: 29507_Test to verify Get Quote tile navigation when user selects the sub account of TmsType both
        Given I am a shp.entry or shp.inquiry user associated to a primary account of TmsType MG that has sub-accounts
        And I am on the QuoteList page
		And I select sub-Customer SubAccountOfTypeBoth from the customer drop down list of QuoteList page
        When I click on Submit Rate Request button in Quotes page
        Then I will arrive on the Get Quote tile page
        And I will see only LTL service type option 
        And I will see the customer name displayed on the Get Quote tile page ZZZ - Czar Customer Test - SubAccountOfTypeBoth

@Acceptance @GUI @Functional
Scenario: 29507_Test to verify Get Quote (LTL) page navigations when user selects the primary account of MG or both type
        Given I am a shp.entry or shp.inquiry user associated to a primary account that has sub-accounts
        And I am on the Get Quote Tile page for a primary customer ZZZ - Czar Customer Test
        When I will click on LTL tile
        Then I will arrive on the Get Quote (LTL) page
        And  I will see the customer name displayed on the Get Quote (LTL) page ZZZ - Czar Customer Test

@Acceptance @GUI @Functional
Scenario: 29507_Test to verify Get Quote (LTL) page navigations when user selects the sub account of MG or both type
        Given I am a shp.entry or shp.inquiry user associated to a primary account that has sub-accounts
        And I am on the Get Quote Tile page for a sub customer SubAccountOfTypeBoth
        When I will click on LTL tile
        Then I will arrive on the Get Quote (LTL) page
        And  I will see the customer name displayed on the Get Quote (LTL) page ZZZ - Czar Customer Test - SubAccountOfTypeBoth
