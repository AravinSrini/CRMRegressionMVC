@50559 @PrioritySprint2
Feature: CRM Rating logic - Multiple item scenario

@Functional
Scenario:50559 - Test to verify if Customer charge in MG matches with the Customer charge in CRM rate results when user submits a shipment with multiple items
	Given I am user with access to create shipment
	And The customer I am associated to has CRM rating login on
	And I am creating a shipment that contains multiple items
	When Shipment is created
	Then Customer charge in MG should match customer charge displayed in CRM rate results