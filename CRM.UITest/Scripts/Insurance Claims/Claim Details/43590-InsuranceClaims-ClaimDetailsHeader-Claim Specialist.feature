@Sprint82 @43590
Feature: 43590-InsuranceClaims-ClaimDetailsHeader-Claim Specialist

@GUI	
Scenario: 43590-Verify the editable fields in Claim Details Header
	Given I am Claims Specialist User
	When I am on the Details Tab of the Claim Details
	Then DLS Claim Rep drop down list will be editable
	And Station drop down list will be editable
	And DLSW Ref # field will be editable
	And Claimant field will be editable
	And Claim Reason drop down list will be editable
	And Carrier Name drop down list will be editable
	And Carrier PRO field will be editable
	And Insured field will be editable

@GUI	
Scenario: 43590-Verify the Non editable fields in Claim Details Header
	Given I am Claims Specialist User
	When I am on the Details Tab of the Claim Details
	Then DLSW Claim # field will not be editable
	And Carrier SCAC field will not be editable
	And Date Requested field will not be editable
	And Claim Age field will not be editable


@GUI		
Scenario: 43590-Verify the Claim Details Header Fields validation
	Given I am Claims Specialist User
	When I am on the Details Tab of the Claim Details
	Then DLSW Ref # field has following validation- free form text, alpha-numeric, special characters, max length 25
	And Claimant field has following validation- free form text, alpha-numeric, special characters, max length 50
	And Carrier PRO field has following validation- Free form text, alpha-numeric, special characters, max length 50
	And Insured is a drop down -Y or N are only accepted option, system will display as upper case.

@GUI	
Scenario: DB43590-Verify stations drop down default sorting- displayed numerically then alphabetically
	Given I am Claims Specialist User
	And I am on the Details Tab of the Claim Details
	When I click in the Station drop down field
    Then the stations will be displayed numerically then alphabetically

@Functional
Scenario: 43590-Verify SCAC field when carrier has associated SCAC code
	Given I am Claims Specialist User
	And I clicked on the hyperlink of any Claim number which has valid Carrier has SCAC code from the Claim List page
	When I am on the Claim Details page
    Then the Carrier SCAC field will update to display the SCAC of the selected carrier
    And I am unable to edit the SCAC field
  
@Functional	
Scenario: 43590-Verify SCAC field when carrier does not has associated SCAC code
	Given I am Claims Specialist User
	And I clicked on the hyperlink of any Claim number which has Invalid Carrier has SCAC code from the Claim List page
	When I am on the Claim Details page
    Then the SCAC field should be left blank

@Functional
Scenario: 43590-Verify DLSW Claim Rep drop down list is configurable
	Given I am Claims Specialist User
	And I am on the Details Tab of the Claim Details
	When the drop down list selections of the DLSW Claim Rep
    Then the DLSW Claim Rep drop down list will be configurable

@Functional	
Scenario: 43590-Verify Carrier Name drop down list is configurable
	Given I am Claims Specialist User
	And I am on the Details Tab of the Claim Details
	When the drop down list selections of the Carrier Name
    Then the Carrier Name drop down list will be configurable

@Functional	
Scenario: 43590-Verify Claim Reason drop down list is configurable
	Given I am Claims Specialist User
	And I am on the Details Tab of the Claim Details
	When the drop down list selections of the Claim Reason
    Then the Claim Reason drop down list will be configurable


Scenario: 43590-Verify the Claim Details Header Fields are editable -Non Claim specilist user
	Given I am Non Claims Specialist User
	When I am on the Details Tab of the Claim Details
	Then DLS Claim Rep drop down list will not be editable
	And Station drop down list will not be editable
	And DLSW Ref # field will not be editable
	And Claimant field will not be editable
	And Claim Reason drop down list will not be editable
	And Carrier Name drop down list will not be editable
	And Carrier PRO field will not be editable
	And Insured field will not be editable