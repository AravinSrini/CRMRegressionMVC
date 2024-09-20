@39963 @Sprint77 

Feature: International Quote_Air_Default Service Level to Air Direct
	

@Regression 
Scenario: 39963 - Verify service level is defaulted to Air Direct when I select the Air Import for International Service type for Shipment Entry User
	Given I am a Ship.entry user - <UserName> and <Password>
	When I arrive on the Get Quote Tiles page
	And I select the International tile type
	Then service level should be defaulted to Air Direct when I select Air Import type
	And there will not be an option of Select Level


@Regression 
Scenario: 39963 - Verify service level is defaulted to Air Direct when I select the Air Export for International Service type for Shipment Entry User
	Given I am a Ship.entry user - <UserName> and <Password>
	When I arrive on the Get Quote Tiles page
	And I select the International tile type
	Then service level should be defaulted to Air Direct when I select Air Export type 
	And there will not be an option of Select Level

@Regression 
Scenario: 39963 - Verify service level is defaulted to Air Direct when I select the Air Import for International Service type for Shipment Inquiry User
    Given I am a Ship.Inquiry user <UserName> and <Password> 
    When I arrive on the Get Quote Tiles page
	And I select the International tile type
	Then service level should be defaulted to Air Direct when I select Air Import type
	And there will not be an option of Select Level

@Regression 
Scenario: 39963 - Verify service level is defaulted to Air Direct when I select the Air Export for International Service type for Shipment Inquiry User
    Given I am a Ship.Inquiry user <UserName> and <Password> 
	When I arrive on the Get Quote Tiles page
	And I select the International tile type
	Then service level should be defaulted to Air Direct when I select Air Export type 
	And there will not be an option of Select Level