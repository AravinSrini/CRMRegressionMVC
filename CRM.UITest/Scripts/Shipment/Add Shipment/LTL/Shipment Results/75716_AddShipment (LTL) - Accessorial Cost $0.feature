@75716 @NinjaSprint31 @Regression
Feature: 75716_Quote (LTL) - Accessorial Cost $0

Scenario: 75716_Verify_That_Accessorial_With_Cost_Zero_Not_Included_On_MG_Customer_Pricesheet_Save_Shipment
	Given I am a ship inquiry or ship entry user with a valid "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
	And I Am on the Add Shipment LTL page
	And I have selected "Appointment" as an accessorial that has a calculated cost of zero on the Add Shipment page
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	And I have entered the following dimensions "5", "7", "9"
	And I add the following reference numbers "12345"
	When I click the submit shipment button
	And I click on the button Create Shipment
	And I click on the Continue Without Insured Rates Button
	And I click the Submit Shipment button on the Review and Submit shipment page
	Then the appointment accessorial will not be included in the Customer Price Sheet in MG from Add Shipment

Scenario: 75716_Verify_That_Accessorial_With_Cost_Greater_Than_Zero_Included_On_MG_Customer_Pricesheet_Save_Rate_As_Quote
	Given I am a ship inquiry or ship entry user with a valid "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
	And I Am on the Add Shipment LTL page
	And I have selected "Limited Access Pickup" as an accessorial that has a calculated cost greater than zero on the Add Shipment page
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	And I have entered the following dimensions "5", "7", "9"
	And I add the following reference numbers "12345"
	When I click the submit shipment button
	And I click on the button Create Shipment
	And I click on the Continue Without Insured Rates Button
	And I click the Submit Shipment button on the Review and Submit shipment page
	Then the Limited Access Pickup accessorial will be included in the Customer Price Sheet in MG from Add Shipment

Scenario: 75716_Verify_That_Accessorial_With_Cost_Zero_Not_Included_And_Accessorial_With_Cost_Greater_Than_Zero_Included_On_MG_Customer_Pricesheet_Save_Rate_As_Quote
	Given I am a ship inquiry or ship entry user with a valid "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
	And I Am on the Add Shipment LTL page
	And I have selected "Appointment" as an accessorial that has a calculated cost of zero on the Add Shipment page
	And I have selected "Limited Access Pickup" as an accessorial that has a calculated cost greater than zero on the Add Shipment page
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	And I have entered the following dimensions "5", "7", "9"
	And I add the following reference numbers "12345"
	When I click the submit shipment button
	And I click on the button Create Shipment
	And I click on the Continue Without Insured Rates Button
	And I click the Submit Shipment button on the Review and Submit shipment page
	Then the appointment accessorial will not be included in the Customer Price Sheet in MG from Add Shipment
	Then the Limited Access Pickup accessorial will be included in the Customer Price Sheet in MG from Add Shipment