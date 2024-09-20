@104654 @Regression @NinjaSprint34
Feature: 104654 - New CSR - Carrier Specific Delete Individual Accessorials link not clickable
	
Scenario: Verify delete individual accessorials modal is displayed when deleting carrier individual accessorial with three carriers
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I add a carrier "3" with the individual accessorials "APPOINTMENT" and the SCAC "BBFG"
And I click on delete individual accessorials for carrier "3"
Then the delete individual accessorials modal is displayed

Scenario: Verify delete individual accessorials modal is displayed when deleting carrier individual accessorial with two carriers
Given I am an admin user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I add a customer specific gainshare with accessorial "INS-ALL RISK"
And I add a carrier "1" with the individual accessorials "COD:GUARANTEED LTL SERVICE AM" and the SCAC "ABFL"
And I add a carrier "2" with the individual accessorials "" and the SCAC "AACT"
And I click on delete individual accessorials for carrier "1"
Then the delete individual accessorials modal is displayed