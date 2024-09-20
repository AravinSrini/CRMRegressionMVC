@35769 @NinjaSprint16
Feature: Customer Invoice - Custom Report - Station/Account Section Functionality

@GUI
Scenario: 35769_Verify Station field is not editable for shp.entry, shp.entrynortes, shp.inquiry, or shp.inquirynorates user
		Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
		And I arrived on Customer Invoice List page
		When I expanded the Create Custom Report section
		Then The station that I am associated to will be default selected in the Stations field
		And I am unable to select another station

@GUI
Scenario Outline: 35769_Verify Account field is not editable for shp.entry, shp.entrynortes, shp.inquiry, or shp.inquirynorates user
		Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user <UserEmail> <Password>
		And I arrived on Customer Invoice List page
		When I expanded the Create Custom Report section
		Then The customer that I am associated to with no sub accounts will be default selected in the Accounts field
		And I am unable to select another account

Examples:
| Scenario | UserEmail            | Password |
| S1       | Extcustomer@test.com | New@pass |

@GUI
Scenario: 35769_Verify Station field will have default station displayed for shp.entry, shp.entrynortes, shp.inquiry, or shp.inquirynorates user
		Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
		And I arrived on Customer Invoice List page
		And I am associated to a primary account that has sub-accounts
		When I expanded the Create Custom Report section
		Then The station that I am associated to will be default selected in the Stations field
		And I am unable to select another station

@GUI
Scenario: 35769_Verify Account field will not have default account displayed for shp.entry, shp.entrynortes, shp.inquiry, or shp.inquirynorates user
		Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
		And I arrived on Customer Invoice List page
		And I am associated to a primary account that has sub-accounts
		When I expanded the Create Custom Report section
		Then The Accounts field will not have an account default displayed


@GUI @Functional
Scenario: 35769_Verify Primary and Sub Accounts are available to select for shp.entry, shp.entrynortes, shp.inquiry, or shp.inquirynorates user
		Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
		And I arrived on Customer Invoice List page
		And I am associated to a primary account that has sub-accounts
		And I expanded the Create Custom Report section
		When I click in the Accounts field
		Then I will have the option to select the primary account in which I am associated
		And I have the option to select any of the sub-accounts associated to the primary account

@GUI @Functional
Scenario: 35769_Verify Accounts are displayed in hierarchy for shp.entry, shp.entrynortes, shp.inquiry, or shp.inquirynorates user
		Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
		And I arrived on Customer Invoice List page
		And I am associated to a primary account that has sub-accounts
		And I expanded the Create Custom Report section
		When I click in the Accounts field
		Then I will see the account list will be displayed in hierarchical format
		
@GUI @Functional
Scenario: 35769_Verify Sub-Accounts are displayed in alphabetical order for shp.entry, shp.entrynortes, shp.inquiry, or shp.inquirynorates user
		Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
		And I arrived on Customer Invoice List page
		And I am associated to a primary account that has sub-accounts
		And I expanded the Create Custom Report section
		When I click in the Accounts field
		Then I will see the sub-accounts will be listed in alphabetical order

@GUI @Functional
Scenario: 35769_Verify multiple select option available for Primary and Sub Accounts for shp.entry, shp.entrynortes, shp.inquiry, or shp.inquirynorates user
		Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
		And I arrived on Customer Invoice List page
		And I am associated to a primary account that has sub-accounts
		And I expanded the Create Custom Report section
		When I click in the Accounts field
		Then I have the option to select multiple accounts


@GUI @Functional
Scenario: 35769_Verify Station fields for Stations for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		When I click in the Stations field
		Then I will see a list of stations in which I am associated
		And I have the option to select multiple stations
		

@GUI @Functional
Scenario: 35769_Verify Search option is available for Stations for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		When I click in the Stations field
		Then I have the option to search for a station

@GUI @Functional
Scenario: 35769_Verify Accounts are available for selected stations for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		And I have selected one or more stations from the Stations list
		When I click in the Accounts field
		Then I will see a list of accounts associated to the station(s) selected

@GUI @Functional
Scenario: 35769_Verify Accounts are displayed in hierarchy for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		And I have selected one or more stations from the Stations list
		When I click in the Accounts field
		Then The accounts will be displayed in hierarchical format

@GUI @Functional
Scenario: 35769_Verify Accounts are displayed in alphabetical order for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		And I have selected one or more stations from the Stations list
		When I click in the Accounts field
		Then The accounts will be displayed in alphabetical order within the hierarchy format

@GUI @Functional
Scenario: 35769_Verify multiple select option available for Accounts for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		And I have selected one or more stations from the Stations list
		When I click in the Accounts field
		Then I have the option to select multiple accounts

@GUI @Functional
Scenario: 35769_Verify Search option is available for Accounts for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		And I have selected one or more stations from the Stations list
		When I click in the Accounts field
		Then I have the option to search for accounts

@GUI @Functional
Scenario: 35769_Verify Accounts field when multiple station selected  for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		And I have selected more than one station from the Stations list
		When I click in the Accounts field
		Then I will see the station names displayed in ascending order in account field
		And I have the option to select multiple accounts

@GUI @Functional
Scenario: 35769_Verify Accounts field in hierarchical format when multiple station selected  for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		And I have selected more than one station from the Stations list
		When I click in the Accounts field
		Then the accounts for each station will be displayed in hierarchical format in alphabetical order

@GUI @Functional
Scenario: 35769_Verify Stations are not selected in Accounts field for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		And I have selected more than one station from the Stations list
		When I click in the Accounts field
		Then I am unable to select a station displayed in the Account list

@GUI @Functional
Scenario: 35769_Verify multiple select option in Accounts field when multiple station selected  for sales, sales management, operations, station owner, or access rrd user
		Given I am a sales, sales management, operations, station owner, or access rrd user
		And I arrived on Customer Invoice List page
		And I expanded the Create Custom Report section
		And I have selected more than one station from the Stations list
		When I click in the Accounts field
		Then I have the option to select multiple accounts