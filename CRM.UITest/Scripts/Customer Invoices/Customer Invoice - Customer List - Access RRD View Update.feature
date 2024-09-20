@38850 @Sprint79
Feature: Customer Invoice - Customer List - Access RRD View Update

@Acceptance @GUI @Functional
Scenario:38850_Test to verify RRD Access user_customer invoice list
         Given I am an RRD Access user logged into CRM
         When I arrive on Customer Invoice List page of rrd access user
         Then Default display filter will be by Open invoices
         And  Default sort will be by Invoice earliest date to latest date
         And Grid will display StationName column after the Account Number column and prior to the Customer Number/Name column


