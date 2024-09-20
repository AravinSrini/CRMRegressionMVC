@44478 @Sprint83 
Feature: Rate Request (LTL) to Add Shipment (LTL) - New Accessorial - Notification

Background:Navigation to Get Quote page
Given that I am a shp.entry, sales, sales management, operations, or station owner user
And I am on Get Quote (LTL) page

@Functional 
Scenario:44478_Test to verify autopopulate functionality and edit of accessorials on shipment information page_standard Rate to Shipment _shipfrom_nofication
Given I have passed all mandatory fields by selecting Notification in shipfrom section
When I click on create shipment on Quote Results (LTL) page
Then Notification accessorials should be autopoulated on Add Shipment (LTL) page
And Notification accessorials in shipfrom section should be editable

@Functional 
Scenario:44478_Test to verify autopopulate functionality and edit of accessorials on shipment information page_standard Rate to Shipment _shipto_nofication
Given I have passed all mandatory fields by selecting Notification in shipto section
When I click on create shipment on Quote Results (LTL) page
Then Notification accessorials in shipto should be autopoulated on Add Shipment (LTL) page
And Notification accessorials in shipto section should be editable


@Functional 
Scenario:44478_Test to verify autopopulate functionality and edit of accessorials on shipment information page_insuredRate to Shipment _shipfrom_nofication
Given I have passed all mandatory fields by selecting Notification in shipfrom section
When I click on create Insured shipment on Quote Results (LTL) page
Then Notification accessorials should be autopoulated on Add Shipment (LTL) page
And Notification accessorials in shipfrom section should be editable

@Functional 
Scenario:44478_Test to verify autopopulate functionality and edit of accessorials on shipment information page_insuredRate to Shipment _shipto_nofication
Given I have passed all mandatory fields by selecting Notification in shipto section
When I click on create Insured shipment on Quote Results (LTL) page
Then Notification accessorials in shipto should be autopoulated on Add Shipment (LTL) page
And Notification accessorials in shipto section should be editable

@Functional 
Scenario:44478_Test to verify autopopulate functionality and edit of accessorials on shipment information page_Rate to Shipment_gauranteed 
Given I have passed all mandatory fields by selecting Notification in shipto section
When I click on create shipment for selected carrier which has gaurenteed rate
Then Notification accessorials in shipto should be autopoulated on Add Shipment (LTL) page
And Notification accessorials in shipto section should be editable



