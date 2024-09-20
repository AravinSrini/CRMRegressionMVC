@39278 @Sprint82
Feature: Insurance Claims - Claim Form - Station and Customer Info
	

@GUI
Scenario: 39278_Verify the Station and Customer are the required fields on the Claim form page
   Given I am a Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
   When I arrive on the Insurance Claim - Submit a Claim page
   Then I should see Station and Customer drop down fields beneath the Enter DLSW Ref# to Start Process
   And Station and Customer drop down fields should be the required fields


@GUI @Functional   
Scenario Outline: 39278_Verify the editable and auto population functionality of the station and Customer fields after click on the Populate Form button
  Given I am a Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
  And I am on the Insurance Claim - Submit a Claim page
  And I entered valid DLSW Ref Number <DLSWBOLNumber>
  And Click on the Populate Form button on the Submit a Claim page
  When I receive the data for the submitted DLSW reference number from MG <DLSWBOLNumber>
  Then the Station and Customer field should be auto populated with the Station and Customer associated with the DLSW Ref#
  And I should not be able to edit the Station and Customer fields
Examples:
| DLSWBOLNumber |
| ZZX00208760   |


@GUI
Scenario: 39278_Verify the list of stations associated to logged in user on the Submit a Claim page
    Given I am a Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
	And I am on the Insurance Claim - Submit a Claim page
	When I Click on the Station drop down field
	Then I should see only list of Stations to which user is associated to
	And the stations should be listed first in numerical then in alphabetical order 


@GUI
Scenario: 39278_Verify the list of Customers associated to logged in user on the Submit a Claim page
    Given I am a Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
	And I am on the Insurance Claim - Submit a Claim page
	And I Click on the Station drop down field 
	When I Click on the Customer drop down field
	Then I should see only list of Customer to which user is associated to
	And the Customer names should be listed first in numerical then in alphabetical order


@GUI
Scenario: 39278_Verify the Order and hierarchy for of Customer field drop down list on the Submit a Claim page for Sales User
    Given I am a crm Sales user 
	And I am on the Insurance Claim - Submit a Claim page
	And I Click on the Station drop down field 
	When I Click on the Customer drop down field
	Then the Customer names should be listed in hierarchy format
	And the Customer names should be listed first in numerical then in alphabetical order

@EndtoEnd
Scenario: 39278_Verify the Submit a Claim functionality when all data is passed and displayed in Claim List page
    Given I am a Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
	And I am on the Insurance Claim - Submit a Claim page
	And I select Station and Customer to which I am associated
	And I pass data to all the fields on SUbmit a Claim page
	When I click on Submit Claim button
	Then All the passed data should get saved in DB along with the username of the user that submitted the claim, First name  and last name of the submitted user, date and time
	And Submitted Claim will be placed in Pending Status.
