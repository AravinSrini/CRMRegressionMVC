@Regression @NinjaSprint34 @108182
Feature: Unable_To_Select_Previously_Selected_Carrier_SCAC

Scenario: Verify second carrier name is an available option after deleting the second carrier and remaking it
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I delete the "2" carrier
And I click Add Carrier-Specific Gainshare Pricing
Then the carrier "AACT" will be an available SCAC option for the "2" carrier

Scenario: Verify first carrier name is an available option after deleting the first carrier and remaking it for 3 carriers
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I add a carrier "3" with the individual accessorials "" and the SCAC "BBFG"
And I delete the "1" carrier
And I click Add Carrier-Specific Gainshare Pricing
Then the carrier "ABFL" will be an available SCAC option for the "3" carrier

Scenario: Verify second carrier name is an available option after deleting the second carrier and remaking it for 3 carriers
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I add a carrier "3" with the individual accessorials "" and the SCAC "BBFG"
And I delete the "2" carrier
And I click Add Carrier-Specific Gainshare Pricing
Then the carrier "AACT" will be an available SCAC option for the "3" carrier

Scenario: Verify third carrier name is an available option after deleting the third carrier and remaking it for 3 carriers
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I add a carrier "3" with the individual accessorials "" and the SCAC "BBFG"
And I delete the "3" carrier
And I click Add Carrier-Specific Gainshare Pricing
Then the carrier "BBFG" will be an available SCAC option for the "3" carrier

Scenario: Verify first carrier name is an available option after deleting the first carrier and remaking it for 4 carriers
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I add a carrier "3" with the individual accessorials "" and the SCAC "BBFG"
And I add a carrier "4" with the individual accessorials "" and the SCAC "CCYQ"
And I delete the "1" carrier
And I click Add Carrier-Specific Gainshare Pricing
Then the carrier "ABFL" will be an available SCAC option for the "4" carrier

Scenario: Verify second carrier name is an available option after deleting the second carrier and remaking it for 4 carriers
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I add a carrier "3" with the individual accessorials "" and the SCAC "BBFG"
And I add a carrier "4" with the individual accessorials "" and the SCAC "CCYQ"
And I delete the "2" carrier
And I click Add Carrier-Specific Gainshare Pricing
Then the carrier "AACT" will be an available SCAC option for the "4" carrier

Scenario: Verify third carrier name is an available option after deleting the third carrier and remaking it for 4 carriers
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I add a carrier "3" with the individual accessorials "" and the SCAC "BBFG"
And I add a carrier "4" with the individual accessorials "" and the SCAC "CCYQ"
And I delete the "3" carrier
And I click Add Carrier-Specific Gainshare Pricing
Then the carrier "BBFG" will be an available SCAC option for the "4" carrier

Scenario: Verify forth carrier name is an available option after deleting the forth carrier and remaking it for 4 carriers
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I add a carrier "3" with the individual accessorials "" and the SCAC "BBFG"
And I add a carrier "4" with the individual accessorials "" and the SCAC "CCYQ"
And I delete the "4" carrier
And I click Add Carrier-Specific Gainshare Pricing
Then the carrier "CCYQ" will be an available SCAC option for the "4" carrier