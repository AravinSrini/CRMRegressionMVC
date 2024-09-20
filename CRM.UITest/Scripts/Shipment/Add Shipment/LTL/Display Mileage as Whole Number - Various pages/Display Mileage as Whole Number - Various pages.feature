@31873 @Sprint79
Feature: Display Mileage as Whole Number - Various pages

@Acceptance @GUI
Scenario: 31873_Verify the mileage as whole number with comma separated on Shipment Results Page 
Given I am a shp.entry, operations, sales, sales management, or station owner user
When I arrive on the LTL Shipment Results page
Then the mileage will be rounded as whole numbers on Results Page
And the mileage will be displayed with comma separated for greater than 999 miles on Results Page

@Acceptance @GUI
Scenario: 31873_Verify the mileage whole number with comma separated on R&S Page of shipment 
Given I am a shp.inquiry, shp.entry, operations, sales, sales management, or station owner user
When I arrive on the Review and Submit page of LTL
Then the mileage will be rounded as whole numbers on Review and Submit Page
And the mileage will be displayed with comma separated for greater than 999 miles on Review and Submit Page

@Acceptance @GUI
Scenario: 31873_Verify the mileage as whole number with comma separated on Shipment details page of any shipment from Shipment List
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
And I clicked on the View Shipment Details button of any displayed shipment on Shipment List Page
When I arrive on the Shipment Details page
Then the mileage will be rounded as whole numbers on Shipment Details Page
And the mileage will be displayed with comma separated for greater than 999 miles on Shipment Details Page

@Acceptance @GUI
Scenario: 31873_Verify the mileage as whole number with comma separated on Quote Results Page
Given I am a shp.inquiry, shp.entry, operations, sales, sales management, or station owner user
When I arrive on the LTL Quote Results page
Then the mileage will be rounded as whole numbers on Quote Results page
And the mileage will be displayed with comma separated for greater than 999 miles on Quote Results page

