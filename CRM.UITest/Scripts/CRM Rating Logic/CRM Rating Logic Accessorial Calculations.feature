@NinjaSprint34 @Regression @108081
Feature: CRM Rating Logic Accessorial Calculations
	When calculating rates for customers with crm rating logic on
	Get default accessorial charges based on which are available

Scenario: 108081 Customer with customer level accessorials add default accessorial costing to calculation
	Given I have the customer "GS - Ninja Customer" which has the accessorials set up at the customer level
	| AccessorialCode | AccessorialValue | GainshareType   | Scac |
	| IPU             | 20               | Set flat amount |      |
	| IDL             | 30               | Set flat amount |      |
	| APPT            | 50               | Set flat amount | FXFE |
	When I send a rate request for "GS - Ninja Customer" with the following values "LTL", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "50", "1", "1", "testentry@test.com", "External", "Inside Pickup,Inside Delivery,Appointment", ""
	Then the following accessorials will have the values
	| AccessorialName | AccessorialCode | AccessorialValue | Scac |
	| Inside Pickup   | IPU             | 20.00            |      |
	| Inside Delivery | IDL             | 30.00            |      |
	| Appointment     | APPT            | 50.00            | FXFE |
Scenario: 108081 Sub Customer with primary customer level accessorials add default accessorial costing to calculation
	Given I have a sub customer "GS - Ninja Customer" which has the accessorials set up at the primary customer "108081 Ninja Primary Customer" level
	| AccessorialCode | AccessorialValue | GainshareType   | Scac |
	| IPU             | 50               | Set flat amount |      |
	| IDL             | 60               | Set flat amount |      |
	| APPT            | 50               | Set flat amount | FXFE |
	When I send a rate request for "GS - Ninja Customer" with the following values "LTL", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "50", "1", "1", "testentry@test.com", "External", "Inside Pickup,Inside Delivery,Appointment", ""
	Then the following accessorials will have the values
	| AccessorialName | AccessorialCode | AccessorialValue | Scac |
	| Inside Pickup   | IPU             | 50.00            |      |
	| Inside Delivery | IDL             | 60.00            |      |
	| Appointment     | APPT            | 50.00            | FXFE |

Scenario: 108081 Customer with station level accessorials add default accessorial costing to calculation
	Given I have the customer "GS - Ninja Customer" which has the accessorials set up at the station level
	| AccessorialName | AccessorialCode | AccessorialValue | GainshareType   | Scac |
	| Inside Pickup   | IPU             | 100              | Set flat amount |      |
	| Inside Delivery | IDL             | 300              | Set flat amount |      |
	| Appointment     | APPT            | 50               | Set flat amount | FXFE | 
	When I send a rate request for "GS - Ninja Customer" with the following values "LTL", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "50", "1", "1", "testentry@test.com", "External", "Inside Pickup,Inside Delivery,Appointment", ""
	Then the following accessorials will have the values
	| AccessorialName | AccessorialCode | AccessorialValue | Scac |
	| Inside Pickup   | IPU             | 100.00           |      |
	| Inside Delivery | IDL             | 300.00           |      |
	| Appointment     | APPT            | 50.00            | FXFE |

Scenario: 108081 Customer with corporate level accessorials add default accessorial costing to calculation
	Given I have the customer "GS - Ninja Customer" which has the accessorials set up at the corporate level
	| AccessorialName | AccessorialCode | AccessorialValue | GainshareType   | Scac |
	| Inside Pickup   | IPU             | 70               | Set flat amount |      |
	| Inside Delivery | IDL             | 75               | Set flat amount |      | 
	| Appointment     | APPT            | 50               | Set flat amount | FXFE | 
	When I send a rate request for "GS - Ninja Customer" with the following values "LTL", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "50", "1", "1", "testentry@test.com", "External", "Inside Pickup,Inside Delivery,Appointment", ""
	Then the following accessorials will have the values
	| AccessorialName | AccessorialCode | AccessorialValue | Scac |
	| Inside Pickup   | IPU             | 70.00            |      |
	| Inside Delivery | IDL             | 75.00            |      |
	| Appointment     | APPT            | 50.00            | FXFE |

Scenario: 108081 sub Customer with station level accessorials add default accessorial costing to calculation
	Given I have the sub customer "GS - Ninja Customer" for primary customer "108081 Ninja Primary Customer" which has the accessorials set up at the station level
	| AccessorialName | AccessorialCode | AccessorialValue | GainshareType   | Scac |
	| Inside Pickup   | IPU             | 100              | Set flat amount |      |
	| Inside Delivery | IDL             | 300              | Set flat amount |      |
	| Appointment     | APPT            | 50               | Set flat amount | FXFE | 
	When I send a rate request for "GS - Ninja Customer" with the following values "LTL", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "50", "1", "1", "testentry@test.com", "External", "Inside Pickup,Inside Delivery,Appointment", ""
	Then the following accessorials will have the values
	| AccessorialName | AccessorialCode | AccessorialValue | Scac |
	| Inside Pickup   | IPU             | 100.00           |      |
	| Inside Delivery | IDL             | 300.00           |      |
	| Appointment     | APPT            | 50.00            | FXFE |

Scenario: 108081 sub Customer with corporate level accessorials add default accessorial costing to calculation
	Given I have the sub customer "GS - Ninja Customer" for primary customer "108081 Ninja Primary Customer" which has the accessorials set up at the corporate level
	| AccessorialName | AccessorialCode | AccessorialValue | GainshareType   | Scac |
	| Inside Pickup   | IPU             | 70               | Set flat amount |      |
	| Inside Delivery | IDL             | 75               | Set flat amount |      | 
	| Appointment     | APPT            | 50               | Set flat amount | FXFE | 
	When I send a rate request for "GS - Ninja Customer" with the following values "LTL", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "50", "1", "1", "testentry@test.com", "External", "Inside Pickup,Inside Delivery,Appointment", ""
	Then the following accessorials will have the values
	| AccessorialName | AccessorialCode | AccessorialValue | Scac |
	| Inside Pickup   | IPU             | 70.00            |      |
	| Inside Delivery | IDL             | 75.00            |      |
	| Appointment     | APPT            | 50.00            | FXFE |