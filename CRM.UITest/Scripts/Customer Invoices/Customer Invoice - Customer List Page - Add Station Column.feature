@Sprint80 @38852 
Feature: Customer Invoice - Customer List Page - Add Station Column
Scenario:38852_Test to verify CRM user_customer invoice list
         Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
         When I arrive on Customer Invoice List page
         Then Grid will display StationName column after the Account Number column and prior to the Customer Number/Name column