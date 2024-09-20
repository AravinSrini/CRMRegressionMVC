@Sprint85 @47168
Feature: Quotes (LTL) - Display Customer Name With Long Hierarchy

@Functional
Scenario: 47168 - Verify customer dropdown after selecting customer 
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Quote List page
	And selected a customer from the <Select account to display...> drop down list
	When the customer name, hierarchies, and station is more than one level
	Then I will see Station ID - Primary Account...Final Customer Name

@Functional
Scenario: 47168 - Verify the hover over message from customer dropdown from quote list page 
	Given I am a sales, sales management, operations, or station owner user
	And I am on Quote List page
	And selected a customer from the <Select account to display...> drop down list
	When I hover over the customer name
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from quote list page

@Functional
Scenario: 47168 - Verify customer label display from Get Quote page of service type selection
	Given I am a sales, sales management, operations, or station owner user
	And I am submitting an LTL rate request
	And selected a customer from the select account to display... drop down list
	When I'm on the Get Quote page
	Then the customer label will now display <Station ID - Primary Account...Final Customer Name from Get Quote page of service type selection as internal

@Functional
Scenario: 47168 - Verify the hover over message of customer label from Get Quote page of service type selection
	Given I am a sales, sales management, operations, or station owner user
	And I am submitting an LTL rate request
	And selected a customer from the <Select account to display...> drop down list
	And I'm on the Get Quote page of service type selection
	When I hover over the customer name from Get Quote page of service type selection as internal user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message  from Get Quote page of service type selection

@Functional
Scenario: 47168 - Verify customer label display from Get Quote page
	Given I am a sales, sales management, operations, or station owner user
	And I am submitting an LTL rate request
	And selected a customer from the select account to display... drop down list
	When I'm on the Get Quote page 
	Then the customer label will now display <Station ID - Primary Account...Final Customer Name from Get Quote page of service type selection as internal

@Functional
Scenario: 47168 - Verify the hover over message of customer label from Get Quote page
	Given I am a sales, sales management, operations, or station owner user
	And I am submitting an LTL rate request
	And selected a customer from the select account to display... drop down list
	And I'm on the Get Quote page
	When I hover over the customer name from Get Quote page of service type selection as internal user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Get Quote page

Scenario: 47168 - Verify the customer label from Quote Result page
    Given I am a sales, sales management, operations, or station owner user
	And I am submitting an LTL rate request
	And selected a customer from the select account to display... drop down list
	When I'm on the Quote Results (LTL) page
	Then the customer label will now display Station ID - Primary Account...Final Customer Name from Quote Result page

@Functional
Scenario: 47168 - Verify the hover over message of customer label from Quote Result page
	Given I am a sales, sales management, operations, or station owner user
	And I am submitting an LTL rate request
	And selected a customer from the <Select account to display...> drop down list
	And I'm on the Quote Results (LTL) page
	When I hover over the customer name from Quote Result page
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Quote Result page 

@Functional
Scenario: 47168 - Verify customer label from Quote Confirmation page
	Given I am a sales, sales management, operations, or station owner user
	And I am submitting an LTL rate request
	And selected a customer from the <Select account to display...> drop down list
	When I'm on the Quote Confirmation (LTL) page as internal
	Then the customer label will now display Station ID - Primary Account...Final Customer Name from Quote Confirmation page as internal

@Functional
Scenario: 47168 - Verify the hover over message of customer label from Quote confirmation page
	Given I am a sales, sales management, operations, or station owner user
	And I am submitting an LTL rate request
	And selected a customer from the <Select account to display...> drop down list
	And I'm on the Quote Confirmation Internal (LTL) page
	When I hover over the customer name from Quote confirmation page
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Quote confirmation page

@Functional
Scenario: 47168 - Verify customer label when external user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	When the customer name, hierarchies, and station is more than one level for external user
	Then I will see Station ID - Primary Account...Final Customer Name from Quote list page as a external user

@Functional
Scenario: 47168 - Verify the customer label hover over message for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	And I select a customer name that is more than one level as a external user
	When I hover over the customer name from quote list page as a external user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from quote list page for external user

@Functional
Scenario: 47168 - Verify the customer label from Get quote page of service type selection for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	When I'm on the Get Quote page of service type selection
	Then the customer label will now display Station ID - Primary Account...Final Customer Name from Get quote page of service type for external user

@Functional
Scenario: 47168 - Verify the hover over message of customer label from Get quote page of service type selection for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	And  I'm on the Get Quote page of service type selection
	When I hover over the customer name from Get Quote page of service type selection as a external
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message  from Get Quote page of service type selection for external user

@Functional
Scenario: 47168 - Verify the customer label from Get quote page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	When I'm on the Get Quote (LTL) page
	Then the customer label will now display Station ID - Primary Account...Final Customer Name from Get quote page for external user
	
@Functional
Scenario: 47168 - Verify the hover over message of customer label from Get quote page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	And  I'm on the Get Quote (LTL) page
	When I hover over the customer name from Get Quote page as a external user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Get Quote page for external user

@Functional
Scenario: 47168 - Verify the customer label from Quote Result page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	When I'm on the Quote Results (LTL) page
	Then the customer label will display Station ID - Primary Account...Final Customer Name from Quote result page for external user

@Functional
Scenario: 47168 - Verify the hover over message of customer label from Quote Result page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	And I'm on the Quote Results (LTL) page
	When I hover over the customer name Extl from Quote Result page
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Quote Result page as a external user

@Functional
Scenario: 47168 - Verify the customer label from Quote Confirmation (LTL) page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	When I'm on the Quote Confirmation (LTL) page
	Then the customer label will now display Station ID - Primary Account...Final Customer Name from Quote confirmation page for external user

@Functional
Scenario: 47168 - Verify the hover over message of customer label from Quote Confirmation (LTL) page for user who is associated to a primary account that has sub-accounts
	Given I am a shp.inquiry or shp.entry user
	And I am on the Quote List page
	And selected a customer from the Select account to display... drop down for external user
	And I'm on the Quote Confirmation (LTL) page as a external user
	When I hover over the customer name from Quote confirmation page as a extl user
	Then the entire station, hierarchies, and customer name will be displayed in the hover over message from Quote confirmation page for external user

