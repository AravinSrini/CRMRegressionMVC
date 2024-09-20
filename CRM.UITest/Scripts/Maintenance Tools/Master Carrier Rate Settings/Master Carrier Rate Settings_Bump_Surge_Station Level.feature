@35277 @Sprint74 @Ignore
Feature: Master Carrier Rate Settings_Bump_Surge_Station Level

@GUI
Scenario Outline: Verify display of Bump and Surge values at all station level on Master Carrier Rate Settings page when both values exists 
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected all Stations
	And I have selected one or more carriers
	Then Surge and Bump values will be displayed on the Master Carrier Rate Settings page.

Examples: 
|Scenario|Username|Password|MasterCarrierPageTitle|

@GUI
Scenario Outline: Verify display of Bump and Surge values at all station level on Master Carrier Rate Settings page when both values does not exists
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected all Stations
	And I have selected one or more carriers
	Then Surge and Bump values will be displayed as None if values does not exists for the carriers

Examples: 
|Scenario|Username|Password|MasterCarrierPageTitle|

@Functional @GUI
Scenario Outline: Update Bump or Surge values for a carrier by selecting all stations and verify the values entered are saved in db and displayed on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected all Stations
	And I have selected one carriers
	And I update Surge or Bump fields <Surge>,<Bump>
	Then the values will be saved to the database for all stations <Bump>,<Surge>
	And the values will be saved to the database for all customers, and their sub-customers <Bump>,<Surge>

Examples: 
|Scenario|Username|Password|MasterCarrierPageTitle|Surge|Bump|

@Functional @GUI
Scenario Outline: Update Bump or Surge values for a carrier by selecting a station and verify the values entered are saved in db and displayed on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected one Station <StationName>
	And I have selected one carriers
	And I update Surge or Bump fields <Surge>,<Bump>
	Then the values will be saved to the database for the station selected <StationName>,<Bump>,<Surge>
	And the values will be saved to the database for all customers, and their sub-customers, associated to the station <StationName>,<Bump>,<Surge>

Examples: 
|Scenario|Username|Password|MasterCarrierPageTitle|StationName|Surge|Bump|

@GUI
Scenario Outline: Verify display of Bump and Surge values on Master Carrier Rate Settings page by selecting one station
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected one Station <StationName>
	And I have selected one or more carriers
	Then Surge and Bump values will be displayed on the Master Carrier Rate Settings page <StationName>

Examples: 
|Scenario|Username|Password|MasterCarrierPageTitle|StationName|

Scenario Outline: Update Bump or Surge values for more than one carrier by selecting all stations and verify the values entered are saved in db and displayed on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected all Stations
	And I selected two carriers
	And I update Surge or Bump fields <Surge>,<Bump>
	Then the values for the selected carriers will be saved to the database for all stations <Bump>,<Surge>
	And the values for the selected carriers will be saved to the database for all customers, and their sub-customers <Bump>,<Surge>

Examples: 
|Scenario|Username|Password|MasterCarrierPageTitle|StationName|

Scenario Outline: Update Bump or Surge values for all carriers by selecting all stations and verify the values entered are saved in db and displayed on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected all Stations
	And I have selected all carriers
	And I update Surge or Bump fields <Surge>,<Bump>
	Then the values for all carriers will be saved to the database for all stations <Bump>,<Surge>
	And the values for all carriers will be saved to the database for all customers, and their sub-customers <Bump>,<Surge>

Examples: 
|Scenario|Username|Password|MasterCarrierPageTitle|StationName|

Scenario Outline: Update Bump or Surge values for more than one carrier by selecting a station and verify the values entered are saved in db and displayed on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected one Station <StationName>
	And I selected two carriers
	And I update Surge or Bump fields <Surge>,<Bump>
	Then the values for the selected carriers will be saved to the database of the station selected <StationName>,<Bump>,<Surge>
	And the values for the selected carriers will be saved to the database of all customers, and their sub-customers <StationName>,<Bump>,<Surge>

Examples: 
|Scenario|Username|Password|MasterCarrierPageTitle|StationName|

Scenario Outline: Update Bump or Surge values for all carriers by selecting a station and verify the values entered are saved in db and displayed on Master Carrier Rate Settings page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Master Carrier Rate Settings page <MasterCarrierPageTitle>
	When I have selected one Station <StationName>
	And I have selected all carriers
	And I update Surge or Bump fields <Surge>,<Bump>
	Then the values for all carriers will be saved to the database of the station selected <StationName>,<Bump>,<Surge>
	And the values for all carriers will be saved to the database of all customers, and their sub-customers <StationName>,<Bump>,<Surge>

Examples: 
|Scenario|Username|Password|MasterCarrierPageTitle|StationName|
