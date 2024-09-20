@Sprint79 @31990 @Ignore
Feature: Insurance Claims - Claims List View by User
	
#---------External users scenarios
@GUI
Scenario: Verify the default status selection on the Claims List page for external users
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, or shp.entrynorates user
	When I arrive on the Claims List page
	Then I can see Open status is selected by default
	And I have option to change to different status
	And I have option to select more than one status

@Functional 
Scenario: Verify the Open status claims are displayed by the most recent submit date for external users
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, or shp.entrynorates user
	When I arrive on the Claims List page
	Then all the claims in the Open status should be displayed by most recent date


@Functional 
Scenario: Verify the list of claims for the customer to which user is associated for external users
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, or shp.entrynorates user
	When I arrive on the Claims List page
	Then I should see a list of claims for the customer to which user is associated

@GUI
Scenario: Verify the color code of the all the status in the claims list page for external users
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, or shp.entrynorates user
	When I arrive on the Claims List page
	Then Verify the color code of all the status in the claims list page

@Functional
Scenario: Verify the claims List grid display when I unselect all the status options for external users
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, or shp.entrynorates user
  	When I arrive on the Claims List page
	And I uncheck all the display status options
	Then Grid should be updated to display all claims associated to the user

#---------sales user scenarios

@GUI
Scenario: Verify the default status selection on the Claims List page for sales user
	Given I am a sales user
	When I arrive on the Claims List page
	Then I can see Open status is selected by default
	And I have option to change to different status
	And I have option to select more than one status

@Functional 
Scenario: Verify the Open status claims are displayed by the most recent submit date for sales user
    Given I am a sales user
	When I arrive on the Claims List page
	Then all the claims in the Open status should be displayed by most recent date


@Functional 
Scenario: Verify the list of claims for the customer to which user is associated for sales user
    Given I am a sales user
	When I arrive on the Claims List page
	Then I should see a list of claims for the customer to which user is associated

@GUI
Scenario: Verify the color code of the all the status in the claims list page for sales user
    Given I am a sales user
	When I arrive on the Claims List page
	Then Verify the color code of all the status in the claims list page

@Functional
Scenario: Verify the claims List grid display when I unselect all the status options for sales user
    Given I am a sales user
  	When I arrive on the Claims List page
	And I uncheck all the display status options
	Then Grid should be updated to display all claims associated to the user

#--------sales management ,station owner and operation user scenarios

@GUI
Scenario: Verify the default status selection on the Claims List page for sales management, operations or station owner user
	Given I am a sales management, operations or station owner user
	When I arrive on the Claims List page
	Then I can see Open status is selected by default
	And I have option to change to different status
	And I have option to select more than one status

@Functional 
Scenario: Verify the Open status claims are displayed by the most recent submit date for sales management, operations or station owner user
    Given I am a sales management, operations or station owner user
	When I arrive on the Claims List page
	Then all the claims in the Open status should be displayed by most recent date


@Functional 
Scenario: Verify the list of claims for the stations to which user is associated for sales management, operations or station owner user
    Given I am a sales management, operations or station owner user
	When I arrive on the Claims List page
	Then I should see a list of claims for the stations to which user is associated

@GUI
Scenario: Verify the color code of the all the status in the claims list page for sales management, operations or station owner user
    Given I am a sales management, operations or station owner user
	When I arrive on the Claims List page
	Then Verify the color code of all the status in the claims list page

@Functional
Scenario: Verify the claims List grid display when I unselect all the status options for sales management, operations or station owner user
    Given I am a sales management, operations or station owner user
  	When I arrive on the Claims List page
	And I uncheck all the display status options
	Then Grid should be updated to display all claims associated to the user

#----------Claim Specialist user-----------------

@GUI
Scenario: Verify the default status selection on the Claims List page for Claim specialist user
	Given I am a sales management, operations or station owner user
	When I arrive on the Claims List page
	Then I can see Open status is selected by default
	And I have option to change to different status
	And I have option to select more than one status

@Functional 
Scenario: Verify the Open status claims are displayed by the most recent submit date for Claim specialist user
    Given I am a sales management, operations or station owner user
	When I arrive on the Claims List page
	Then all the claims in the Open status should be displayed by most recent date


@Functional 
Scenario: Verify the list of claims for the stations to which user is associated for Claim specialist user
    Given I am a sales management, operations or station owner user
	When I arrive on the Claims List page
	Then I should see a list of claims for the stations to which user is associated

@GUI
Scenario: Verify the color code of the all the status in the claims list page for Claim specialist user
    Given I am a sales management, operations or station owner user
	When I arrive on the Claims List page
	Then Verify the color code of all the status in the claims list page

@Functional
Scenario: Verify the claims List grid display when I unselect all the status options for Claim specialist user
    Given I am a sales management, operations or station owner user
  	When I arrive on the Claims List page
	And I uncheck all the display status options
	Then Grid should be updated to display all claims associated to the user