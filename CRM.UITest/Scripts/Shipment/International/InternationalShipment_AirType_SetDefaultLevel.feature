@Sprint77 @40056
Feature: InternationalShipment_AirType_SetDefaultLevel.
	

@GUI
Scenario Outline: 40056 - Verify service level is defaulted to Air Direct for the Air Import International Service type of Shipment Entry User
	Given I am Shipment Entry User
	When I selected International Shipment Service Type as Air Import from Add Shipment Tiles Page<ServiceType>
	Then the Service Level will be defaulted to Air Direct

	Examples: 
	| ServiceType  |
	| Air - Import |

	Scenario Outline: 40056 - Verify service level is defaulted to Air Direct for the Air Import International Service type of Shipment Entry No Rates User
	Given I am Shipment Entry No Rates User
	When I selected International Shipment Service Type as Air Import from Add Shipment Tiles Page<ServiceType>
	Then the Service Level will be defaulted to Air Direct

	Examples: 
	| ServiceType  |
	| Air - Import |

	@GUI
	Scenario Outline: 40056 - Verify service level is defaulted to Air Direct for the Air Export International Service type of Shipment Entry User
	Given I am Shipment Entry User
	When I selected International Shipment Service Type as Air Export from Add Shipment Tiles Page<ServiceType>
	Then the Service Level will be defaulted to Air Direct
	Examples: 
	| ServiceType  |
	| Air - Export |

	Scenario Outline: 40056 - Verify service level is defaulted to Air Direct for the Air Export International Service type of Shipment Entry No Rates User
	Given I am Shipment Entry No Rates User
	When I selected International Shipment Service Type as Air Export from Add Shipment Tiles Page<ServiceType>
	Then the Service Level will be defaulted to Air Direct
	Examples: 
	| ServiceType  |
	| Air - Export |

	@GUI
	Scenario Outline: 40056 - Verify absence of select level option for the Air Import for International Service type of Shipment Entry User
	Given I am Shipment Entry User
	When I selected International Shipment Service Type as Air Import from Add Shipment Tiles Page<ServiceType>
	Then the select level option should not be present
	Examples: 
	| ServiceType  |
	| Air - Import |

	@GUI
	Scenario Outline: 40056 - Verify absence of select level option for the Air Import for International Service type of Shipment Entry No Rates User
	Given I am Shipment Entry No Rates User
	When I selected International Shipment Service Type as Air Import from Add Shipment Tiles Page<ServiceType>
	Then the select level option should not be present
	Examples: 
	| ServiceType  |
	| Air - Import |

	@GUI
	Scenario Outline: 40056 - Verify absence of select level option for the Air Export for International Service type of Shipment Entry User
	Given I am Shipment Entry User
	When I selected International Shipment Service Type as Air Export from Add Shipment Tiles Page<ServiceType>
	Then the select level option should not be present
	Examples: 
	| ServiceType  |
	| Air - Export |

	@GUI
	Scenario Outline: 40056 - Verify absence of select level option for the Air Export for International Service type of Shipment Entry No Rates User
	Given I am Shipment Entry No Rates User
	When I selected International Shipment Service Type as Air Export from Add Shipment Tiles Page<ServiceType>
	Then the select level option should not be present
	Examples: 
	| ServiceType  |
	| Air - Export |