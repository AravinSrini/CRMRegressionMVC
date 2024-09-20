@CRMCustomerSpecficBranding @20242 @Sprint62 
Feature: CRMCustomerSpecificBranding_Desktop 

@Functional 
Scenario Outline: Verify that the customer logo is uploaded for the customer specific account
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	And I click on the station drop down and select the '<station>' from the drop down list
	And I click on the customer drop down and select the '<customeraccount>' from the drop down list
	And I delete the customer account if present in the customer specific logos grid
	And I upload a file with '<Filename_path>' through file explorer
	And I click on the save button	
	Then Verify the logo name '<Filename>' updated in the Customer Specific Logos list and Custom logo flag set to On by default

	Examples: 
	| Scenario | Username       | Password | UserDropdown | Filename_path                                                                  | station | customeraccount  | Filename         |
	| S1       | crmSystemAdmin | Te$t1234 | system Admin | ../../Scripts/TestData/Testfiles_MaintenanceUpload/ValidFiles/BrandingLogo.jpg | James   | 010-test account | BrandingLogo.jpg |


@GUI @Acceptance
Scenario Outline: Verify the customer account is updated with the Customer Specific Logo
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I land on the Dashboard
	Then Verify the customer account is updated with the customer specific logo

	Examples: 
	| Scenario | Username | Password |
	| S1       | zzz      | Te$t1234 |



#---------------------------Sprint 66 CRMCustomerSpecificBranding : Logo Placement---------------------
@GUI @Functional @DBVerification @Sprint66 @25239 

Scenario Outline: Verify the customer account is having Customer Specific Logo in by default left aligned 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I land on the Dashboard
	Then Verify that the UI displays the logo as left aligned 

    Examples: 
	| Scenario | Username  | Password  |
	| S1       | logoleft1 | Passw0rd! |



@GUI @Functional @DBVerification @Sprint66 @25239 

Scenario Outline: Verify the customer account is having Customer Specific Logo in center aligned  
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I land on the Dashboard
	Then Verify that the UI displays the logo as center aligned for the logged in customer with header logo changed to center

    Examples: 
	| Scenario | Username   | Password  |
	| S1       | centerlogo | Passw0rd! |


# ----------------------------End of sprint 66 ---------------------
