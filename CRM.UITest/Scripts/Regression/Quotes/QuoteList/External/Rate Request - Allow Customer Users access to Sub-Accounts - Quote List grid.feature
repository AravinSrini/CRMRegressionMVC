@Regression @Quote @29509 @Sprint79 
Feature:Rate Request - Allow Customer Users access to Sub-Accounts - Quote List grid
@Acceptance @GUI @Functional
Scenario: 29509_Test to verify Quote List page when user select the All customers 
        Given I am a shp.entry or shp.inquiry user associated to a primary account that has sub-accounts
        And I am on the Quote List page
        When I myself select All Customers from the customer drop down list
        Then Submit Rate Request button will be hidden
        #And Quote List grid will refresh to display all quotes associated to the primary account and sub-accounts for the past 30 days

@Acceptance @GUI @Functional
Scenario:29509_Test to verify quote details when user selects all customers
       Given I am a shp.entry or shp.inquiry user associated to a primary account that has sub-accounts
       And I am on the Quote List page
       And I select All Customers from the customer drop down list
       When I expand the quote details of any displayed quote
       Then the Re-Quote button will be hidden
       And the Create Shipment button will be hidden

@Acceptance @GUI @Functional
Scenario Outline: 29509_Test to verify quote list page when user select to primary customer
        Given I am a shp.entry or shp.inquiry user associated to a primary account that has sub-accounts
        And I am on the Quote List page
        When I myself select primary customer of MG or both  from the customer drop down <Customer>,<tmsType> list 
        Then Rate Request button will be active
        Then Quote List grid will refresh to display all quotes associated to the primary account for the past thirtydays<Customer>,<tmsType>

Examples: 
| Customer                 | tmsType |
|ZZZ - Czar Customer Test  | MG      |


@Acceptance @GUI @Functional
Scenario Outline: 29509_Test to verify Quote List page when user select the sub-customer
        Given I am a shp.entry or shp.inquiry user associated to a primary account that has sub-accounts
        And I am on the Quote List page
        When I myself select Sub-customer of MG or both  from the customer drop down list <Customer>,<TmsType>
        Then Rate Request button will be active
        And Quote List grid will refresh to display all quotes associated to the selected sub-account for the past thirtydays<Customer>,<tmsType>

Examples: 
| Customer               | tmsType |
|36691 scenario1 subacc  | both    |


@Acceptance @GUI @Functional
Scenario Outline:29509_Test to verify quote details when user selects sub- customers
       Given I am a shp.entry or shp.inquiry user associated to a primary account that has sub-accounts with zzzcsastage
       And I am on the Quote List page
       When I myself select Sub-customer of MG or both  from the customer drop down list <Customer>,<TmsType>
       When I expand the quote details of any displayed Non LTL quote
       Then Create Shipment button will not be displayed

Examples: 
| Customer               | tmsType |
|DG                      | both     |
