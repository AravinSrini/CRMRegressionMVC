@76032 @Sprint90 

Feature: 76032_Add Shipment (LTL) 2019 - Page Elements

@Regression
Scenario: 76032-Verify the Add Shipment (LTL) 2019 - Page Elements for External Users
Given I am a shpentry, shpentrynorates user
When I arrive on the Add Shipment - (LTL) page for External user
Then I will see the Add Shipment (LTL) label
And the verbiage beneath the Add Shipment (LTL) label as <Fields outlined in orange are required>
And Back to Shipment List button
And Shipment From Section
And Shipment To Section
And Pickup Date Section
And Special Instructions Section
And Insured Value Section
And Reference Numbers Section
And Freight Description Section
And View Rates button

@Regression
Scenario: 76032-Verify the Add Shipment (LTL) 2019 - Page Elements for Internal Users
Given I am a operations, sales management or station owner user
When I arrive on the <Customer> Add Shipment - (LTL) page for Internal user
Then I will see the Add Shipment (LTL) label
And the verbiage beneath the Add Shipment (LTL) label as <Fields outlined in orange are required>
And Back to Shipment List button
And Shipment From Section
And Shipment To Section
And Pickup Date Section
And Special Instructions Section
And Insured Value Section
And Reference Numbers Section
And Freight Description Section
And View Rates button

@Regression
Scenario: 76032-Verify the Add Shipment (LTL) 2019 - Page Elements for Sales User
Given I am a sales user
When I arrive on the <Customer> Add Shipment - (LTL) page for Sales user
Then I will see the Add Shipment (LTL) label
And the verbiage beneath the Add Shipment (LTL) label as <Fields outlined in orange are required>
And Back to Shipment List button
And Shipment From Section
And Shipment To Section
And Pickup Date Section
And Special Instructions Section
And Insured Value Section
And Reference Numbers Section
And Freight Description Section
And View Rates button

@Regression
Scenario: 76032-Verify the existance of selected Station and Customer name displayed on the Add Shipment (LTL) page for Internal Users
Given I am a operations, sales management or station owner user
When I arrive on the <Customer> Add Shipment - (LTL) page for Internal user
Then I should see the selected Station and Customer name displayed on the Add Shipment (LTL) page
And I should not be able to edit the displayed Station and Customer name

@Regression
Scenario: 76032-Verify the existance of selected Station and Customer name displayed on the Add Shipment (LTL) page for Sales User
Given I am a sales user
When I arrive on the <Customer> Add Shipment - (LTL) page for Sales user
Then I should see the selected Station and Customer name displayed on the Add Shipment (LTL) page
And I should not be able to edit the displayed Station and Customer name

@Regression
Scenario: 76032-Verify the behaviour of the Back to Shipment List button for External User
Given I am a shpentry, shpentrynorates user
And I arrive on the Add Shipment - (LTL) page for External user
When I clicked on the Back to Shipment List button
Then I should be navigated to the Shipment List page

@Regression
Scenario: 76032-Verify the behaviour of the Back to Shipment List button for Internal User
Given I am a operations, sales management or station owner user
And I arrive on the <Customer> Add Shipment (LTL) page for Internal user
When I clicked on the Back to Shipment List button
Then I should be navigated to the Shipment List page

@Regression
Scenario: 76032-Verify the behaviour of the Back to Shipment List button for Sales User
Given I am a sales user
And I arrive on the <Customer> Add Shipment (LTL) page for Sales user
When I clicked on the Back to Shipment List button
Then I should be navigated to the Shipment List page


	