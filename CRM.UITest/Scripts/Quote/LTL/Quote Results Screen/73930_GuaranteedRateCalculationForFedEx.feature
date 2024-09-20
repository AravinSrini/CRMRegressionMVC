@73930 @NinjaSprint29 @Regression
Feature: Guaranteed Rate Calulation for FedEx

Scenario: 73930_Verify_That_FedEx_Guaranteed_Rate_Calculation_Is_Appled_To_Carriers_In_Guaranteed_LTL_Rate_Carriers_Page_With_SCAC_FXFE_FXNL_FXFC
Given I am a DLS user that belongs to Gainshare Customer and login into application with valid "username-CurrentsprintOperations" and "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) page for "AA Auto"
When I am on the quote results page for Calculating Guaranteed Total Cost "AA Auto", "Internal", "60606", "60446", "60", "2", "100", "", ""
Then Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount for the Quote "AA Auto", "LTL" , "Chicago", "60606", "IL", "USA", "Romeoville", "60446", "IL", "USA","60","2", "100","username-CurrentsprintOperations","Internal","",""

Scenario: 73930_Verify_That_FedEx_Guaranteed_Rate_Calculation_Is_Appled_To_Carriers_In_Guaranteed_LTL_Rate_Carriers_Page_With_SCAC_FXFE_FXNL_FXFC_CRMLogic_Off
Given I am a DLS user that belongs to Gainshare Customer and login into application with valid "username-CurrentsprintOperations" and "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) page for "ZZZ - GS Customer Test"
When I am on the quote results page for Calculating Guaranteed Total Cost "ZZZ - GS Customer Test", "Internal", "60606", "60446", "60", "2", "100", "", ""
Then Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount for the Quote "ZZZ - GS Customer Test", "LTL" , "Chicago", "60606", "IL", "USA", "Romeoville", "60446", "IL", "USA","60","2", "100","username-CurrentsprintOperations","Internal","",""

Scenario: 73930_Verify_That_FedEx_Guaranteed_Rate_Calculation_Is_Appled_To_Carriers_In_Guaranteed_LTL_Rate_Carriers_Page_With_SCAC_FXFE_FXNL_FXFC_With_Destination_Accessorial
Given I am a DLS user that belongs to Gainshare Customer and login into application with valid "username-CurrentsprintOperations" and "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) page for "AA Auto"
When I am on the quote results page for Calculating Guaranteed Total Cost "AA Auto", "Internal", "60606", "60446", "60", "2", "100", "", "COD"
Then Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount for the Quote "AA Auto", "LTL" , "Chicago", "60606", "IL", "USA", "Romeoville", "60446", "IL", "USA","60","2", "100","username-CurrentsprintOperations","Internal","","COD"

Scenario: 73930_Verify_That_FedEx_Guaranteed_Rate_Calculation_Is_Appled_To_Carriers_In_Guaranteed_LTL_Rate_Carriers_Page_With_SCAC_FXFE_FXNL_FXFC_CRMLogic_Off_With_Destination_Accessorial
Given I am a DLS user that belongs to Gainshare Customer and login into application with valid "username-CurrentsprintOperations" and "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) page for "ZZZ - GS Customer Test"
When I am on the quote results page for Calculating Guaranteed Total Cost "ZZZ - GS Customer Test", "Internal", "60606", "60446", "60", "2", "100", "", "COD"
Then Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount for the Quote "ZZZ - GS Customer Test", "LTL" , "Chicago", "60606", "IL", "USA", "Romeoville", "60446", "IL", "USA","60","2", "100","username-CurrentsprintOperations","Internal","","COD"

Scenario: 73930_Verify_That_FedEx_Guaranteed_Rate_Calculation_Is_Appled_To_Carriers_In_Guaranteed_LTL_Rate_Carriers_Page_With_SCAC_FXFE_FXNL_FXFC_With_Origin_Accessorial
Given I am a DLS user that belongs to Gainshare Customer and login into application with valid "username-CurrentsprintOperations" and "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) page for "AA Auto"
When I am on the quote results page for Calculating Guaranteed Total Cost "AA Auto", "Internal", "60606", "60446", "60", "2", "100", "Appointment", ""
Then Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount for the Quote "AA Auto", "LTL" , "Chicago", "60606", "IL", "USA", "Romeoville", "60446", "IL", "USA","60","2", "100","username-CurrentsprintOperations","Internal","APPT",""

Scenario: 73930_Verify_That_FedEx_Guaranteed_Rate_Calculation_Is_Appled_To_Carriers_In_Guaranteed_LTL_Rate_Carriers_Page_With_SCAC_FXFE_FXNL_FXFC_CRMLogic_Off_With_Origin_Accessorial
Given I am a DLS user that belongs to Gainshare Customer and login into application with valid "username-CurrentsprintOperations" and "password-CurrentsprintOperations"
And I navigate to the Get Quote (LTL) page for "ZZZ - GS Customer Test"
When I am on the quote results page for Calculating Guaranteed Total Cost "ZZZ - GS Customer Test", "Internal", "60606", "60446", "60", "2", "100", "Appointment", ""
Then Rate (customer charge) will be determined by applying the CRM Rating calculation to the guaranteed rate amount for the Quote "ZZZ - GS Customer Test", "LTL" , "Chicago", "60606", "IL", "USA", "Romeoville", "60446", "IL", "USA","60","2", "100","username-CurrentsprintOperations","Internal","APPT",""