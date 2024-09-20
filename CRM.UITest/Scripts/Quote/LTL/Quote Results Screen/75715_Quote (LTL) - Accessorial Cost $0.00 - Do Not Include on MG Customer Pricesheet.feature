@75715 @NinjaSprint31 @Regression
Feature: 75715_Quote (LTL) - Accessorial Cost $0

Scenario: 75715_Verify_That_Accessorial_With_Cost_Zero_Not_Included_On_MG_Customer_Pricesheet_Save_Rate_As_Quote
	Given I am a ship inquiry or ship entry user with a valid "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
	And I am on Get Quote LTL page
	And I have selected "Appointment" as an accessorial that has a calculated cost of zero
	And I have input the following information for Shipping From "60446"
	And I have input the following information for Shipping To "60606"
	And I enter the following values in the length width and height fields "5", "7", "9"
	And Overlength is not selected as a accessorial in either of the following sections: Shipping From, Shipping To
	And I have clicked on View Quote Results
	When the Save Rate as Quote button is clicked
	Then the appointment accessorial will not be included in the Customer Price Sheet in MG.

Scenario: 75715_Verify_That_Accessorial_With_Cost_Greater_Than_Zero_Included_On_MG_Customer_Pricesheet_Save_Rate_As_Quote
	Given I am a ship inquiry or ship entry user with a valid "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
	And I am on Get Quote (LTL) page
	And I have selected "Limited Access Pickup" as an accessorial that has a calculated cost greater than zero
	And I have input the following information for Shipping From "60446"
	And I have input the following information for Shipping To "60606"
	And I enter the following values in the length width and height fields "5", "7", "9"
	And Overlength is not selected as a accessorial in either of the following sections: Shipping From, Shipping To
	And I have clicked on View Quote Results
	When the Save Rate as Quote button is clicked
	Then the Limited Access Pickup accesorial will be included in the Customer Price Sheet in MG.

Scenario: 75715_Verify_That_Accessorial_With_Cost_Zero_Not_Included_On_MG_Customer_Pricesheet_Save_Insured_Rate_As_Quote
	Given I am a ship inquiry or ship entry user with a valid "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
	And I am on Get Quote (LTL) page
	And I have selected "Appointment" as an accessorial that has a calculated cost of zero
	And I have input the following information for Shipping From "60446"
	And I have input the following information for Shipping To "60606"
	And I enter the following values in the length width and height fields "5", "7", "9"
	And Overlength is not selected as a accessorial in either of the following sections: Shipping From, Shipping To
	And I have clicked on View Quote Results
	And I have entered an insured value of "100"
	When the Save Insured Rate as Quote button is clicked
	Then the appointment accessorial will not be included in the Customer Price Sheet in MG.

Scenario: 75715_Verify_That_Accessorial_With_Cost_Greater_Than_Zero_Included_On_MG_Customer_Pricesheet_Save_Insured_Rate_As_Quote
	Given I am a ship inquiry or ship entry user with a valid "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
	And I am on Get Quote (LTL) page
	And I have selected "Limited Access Pickup" as an accessorial that has a calculated cost greater than zero
	And I have input the following information for Shipping From "60446"
	And I have input the following information for Shipping To "60606"
	And I enter the following values in the length width and height fields "5", "7", "9"
	And Overlength is not selected as a accessorial in either of the following sections: Shipping From, Shipping To
	And I have clicked on View Quote Results
	And I have entered an insured value of "100"
	When the Save Insured Rate as Quote button is clicked
	Then the Limited Access Pickup accesorial will be included in the Customer Price Sheet in MG.

Scenario: 75715_Verify_That_Accessorial_With_Cost_Zero_Not_Included_And_Accessorial_With_Cost_Greater_Than_Zero_Included_On_MG_Customer_Pricesheet_Save_Rate_As_Quote
	Given I am a ship inquiry or ship entry user with a valid "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
	And I am on Get Quote (LTL) page
	And I have selected "Appointment" as an accessorial that has a calculated cost of zero
	And I have selected "Limited Access Pickup" as an accessorial that has a calculated cost greater than zero
	And I have input the following information for Shipping From "60446"
	And I have input the following information for Shipping To "60606"
	And I enter the following values in the length width and height fields "5", "7", "9"
	And Overlength is not selected as a accessorial in either of the following sections: Shipping From, Shipping To
	And I have clicked on View Quote Results
	When the Save Rate as Quote button is clicked
	Then the appointment accessorial will not be included in the Customer Price Sheet in MG.
	And the Limited Access Pickup accesorial will be included in the Customer Price Sheet in MG.

Scenario: 75715_Verify_That_Accessorial_With_Cost_Zero_Not_Included_And_Accessorial_With_Cost_Greater_Than_Zero_Included_On_MG_Customer_Pricesheet_Save_Insured_Rate_As_Quote
	Given I am a ship inquiry or ship entry user with a valid "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
	And I am on Get Quote (LTL) page
	And I have selected "Appointment" as an accessorial that has a calculated cost of zero
	And I have selected "Limited Access Pickup" as an accessorial that has a calculated cost greater than zero
	And I have input the following information for Shipping From "60446"
	And I have input the following information for Shipping To "60606"
	And I enter the following values in the length width and height fields "5", "7", "9"
	And Overlength is not selected as a accessorial in either of the following sections: Shipping From, Shipping To
	And I have clicked on View Quote Results
	And I have entered an insured value of "100"
	When the Save Insured Rate as Quote button is clicked
	Then the appointment accessorial will not be included in the Customer Price Sheet in MG.
	And the Limited Access Pickup accesorial will be included in the Customer Price Sheet in MG.