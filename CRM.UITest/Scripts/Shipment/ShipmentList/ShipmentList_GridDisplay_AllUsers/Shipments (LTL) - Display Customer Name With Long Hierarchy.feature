@Sprint85 @47169
Feature: Shipments (LTL) - Display Customer Name With Long Hierarchy

@Functional
#Done
Scenario: 47169 - Verify customer dropdown after selecting customer from shipment list page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	When customer name, hierarchies, and station is more than one level
	Then customer label will display <Station ID - Primary Account...Final Customer Name> from shipment list page

@Functional
#Done
Scenario: 47169 - Verify the hover over message from customer dropdown from shipment list page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
    And selected a customer from the <Select account to display...> drop down list from shipment list page
	When I hover over the customer name from shipment list page
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message

@Functional
#Done
Scenario: 47169 - Verify customer label display from Add Shipment page of service type selection
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	When I am on the Add Shipment page of service type selection
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> Add Shipment page of service type selection

@Functional
#Done
Scenario: 47169 - Verify the hover over message of customer label from Add Shipment of service type selection
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	And I am on the Add Shipment page of service type selection
	When I hover over the customer name from Add Shipment page of service type selection
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Add Shipment page of service type selection

@Functional
#Done
Scenario: 47169 - Verify customer label display from Add Shipment (LTL) page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	When I am on Add Shipment (LTL) page
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> from Add Shipment (LTL) page

@Functional
#Done
Scenario: 47169 - Verify the hover over message of customer label from Add Shipment (LTL) page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	And I am on LTL Add Shipment page
	When I hover over the customer name from Add Shipment (LTL) page
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Add Shipment (LTL) page

@Functional
#Done
Scenario: 47169 - Verify customer label display from Shipment Results page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	When I am on Shipment Results (LTL) page
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> from Shipment Results page

@Functional
#Done
Scenario: 47169 - Verify the hover over message of customer label from Shipment Results page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	And I am on the Shipment Results (LTL) page
	When I hover over the customer name from Shipment Results page
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment Results page

@Functional
#Done
Scenario: 47169 - Verify customer label display from Review and Submit Shipment page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	When I am on the Review and Submit Shipment (LTL) page
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> from Review and Submit Shipment page

@Functional
#Done
Scenario: 47169 - Verify hover over message of customer label from Review and Submit Shipment page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	And I am on the Review and Submit Shipment (LTL) page
	When I hover over the customer name from Review and Submit Shipment page
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Review and Submit Shipment page

@Functional
#Done
Scenario: 47169 - Verify customer label display from Shipment confirmation (LTL) page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	When I am on the Shipment confirmation (LTL) page
	Then customer label will now display <Station ID - Primary Account...Final Customer Name>  from Shipment confirmation (LTL) page

@Functional
#Done
Scenario: 47169 - Verify hover over message of customer label from Shipment confirmation (LTL) page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And selected a customer from the <Select account to display...> drop down list from shipment list page
	And I am on the Shipment confirmation (LTL) page
	When I hover over the customer name from Shipment confirmation (LTL) page
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message  from Shipment confirmation (LTL) page

@Functional
#Done
Scenario: 47169 - Verify customer label from shipment List page when user who is associated to a primary account that has sub-accounts 
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	When the customer name, hierarchies, and station is more than one level from shipment list page as a external user
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> from shipment List page

@Functional
#Done
Scenario: 47169 - Verify the customer label hover over message from Shipment List page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	When I hover over the customer name from Shipment List as a external user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment List as a external user

@Functional
#Done
Scenario: 47169 - Verify customer label from Add Shipment page of service type selection when user who is associated to a primary account that has sub-accounts 
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	When I am on the Add Shipment page of service type selection as a external user
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> from Add Shipment page of service type selection for external user

@Functional
Scenario: 47169 - Verify the customer label hover over message from Add Shipment page of service type selection for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	And I am on the Add Shipment page of service type selection as a external user
	When I hover over the customer name from Add Shipment page of service type selection
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Add Shipment page of service type selection for external user

@Functional
Scenario: 47169 - Verify customer label from Add Shipment page for user who is associated to a primary account that has sub-accounts 
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	When I am on the Add Shipment page as a external user
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> from Add Shipment page for external user

@Functional
Scenario: 47169 - Verify the customer label hover over message from Add Shipment page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	And I am on the Add Shipment page as a external user
	When I hover over the customer name from Add Shipment page as a external user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Add Shipment page

@Functional
Scenario: 47169 - Verify customer label from Review and Submit Shipment page for user who is associated to a primary account that has sub-accounts 
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	When I am on the Review and Submit Shipment page as a external user
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> from Review and Submit Shipment page for external user

@Functional
Scenario: 47169 - Verify the customer label hover over message from Review and Submit Shipment page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	And I am on the Review and Submit Shipment page as a external user
	When I hover over the customer name from Review and Submit Shipment page as a external user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Review and Submit Shipment page for external user

@Functional
Scenario: 47169 - Verify customer label from Shipment confirmation page for user who is associated to a primary account that has sub-accounts 
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	When I am on the Shipment confirmation page as a external user
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> from Shipment confirmation page for external user

@Functional
Scenario: 47169 - Verify the customer label hover over message from Shipment confirmation page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	And I am on the Shipment confirmation page as a external user
	When I hover over the customer name from Shipment confirmation page as a external user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment confirmation page for external user
	

@Functional
Scenario: 47169 - Verify customer label from Shipment Results page for user who is associated to a primary account that has sub-accounts 
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	When I am on the Shipment Results page as a external user
	Then customer label will now display <Station ID - Primary Account...Final Customer Name> from Shipment Results page for external user

@Functional
Scenario: 47169 - Verify the customer label hover over message from Shipment Results page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Shipment List page
	And selected a customer from the Select account to display... drop down list as a external user from shipment list page
	And I am on the Shipment Results page as a external user
	When I hover over the customer name from Shipment Results page as a external user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment Results page for external user