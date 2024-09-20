@Sprint81  @40783
Feature: Over Length - Quote Results (LTL) - Request to Shipment

Background:Navigation to Get Quote page
Given that I am a shp.entry, sales, sales management, operations, or station owner user
And I am on Get Quote (LTL) page

@Functional
Scenario:40783_Test to verify autopopulate functionality of Dimension Type and values on shipment information page_standard Rate to Shipment 
Given I have passed all mandatory fields Length,Width,Height fields by selecting Overlength
When I click on create shipment on Quote Results (LTL) page
Then Length,Width,Height,Dimension Type fields should be autopoulated on Add Shipment (LTL) page


@Functional
Scenario:40783_Test to verify autopopulate functionality of Dimension Type and values on shipment information page_insured Rate to Shipment
Given I have passed all mandatory fields Length,Width,Height fields by selecting Overlength 
When I click on create Insured shipment on Quote Results (LTL) page
Then Length,Width,Height,Dimension Type fields should be autopoulated on Add Shipment (LTL) page


@Functional
Scenario:40783_Test to verify autopopulate functionality of Dimension Type and values on shipment information page_Rate to Shipment 
Given I have passed all mandatory fields,Length,Width,Height fields without selecting Overlength
When I click on create shipment on Quote Results (LTL) page
Then Length,Width,Height,Dimension Type fields should be autopoulated on Add Shipment (LTL) page

@Functional
Scenario:40783_Test to verify autopopulate functionality of Dimension Type and values on shipment information page_Rate to Shipment _no dimensions passed
Given I have passed all mandatory fields without selecting Overlength
When I click on create shipment on Quote Results (LTL) page
Then Length,Width,Height,Dimension Type fields should be blank on Add Shipment (LTL) page


@Functional @Ignore
Scenario:40783_Test to verify autopopulate functionality of Dimension Type and values on shipment information page_Rate to Shipment _for defaultitem
Given I have passed all mandatory fields by selecting  defualt item values
When I click on create shipment on Quote Results (LTL) page
Then Length,Width,Height,Dimension Type fields should be autopopulated on Add Shipment (LTL) page which are default item values from quote


@Functional @Ignore
Scenario:40783_Test to verify autopopulate functionality of Dimension Type and values on shipment information page_Rate to Shipment _for saveditem
Given I have passed all mandatory fields with the saved item
When I click on create shipment on Quote Results (LTL) page
Then Length,Width,Height,Dimension Type fields should be autopopulated on Add Shipment (LTL) page which are saved item values from quote
