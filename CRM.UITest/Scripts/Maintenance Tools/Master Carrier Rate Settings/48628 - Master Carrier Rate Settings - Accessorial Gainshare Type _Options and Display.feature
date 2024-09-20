@48628 @Sprint87
Feature: 48628 - Master Carrier Rate Settings - Accessorial Gainshare Type _Options and Display
	
Scenario Outline: 48628 - Verify the Set Gainshare Type field 
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	When I arrive on the Set Individual Accessorials modal
	Then I will see a new field Set Gainshare Type
	And the Set Gainshare Type field will be a drop down list with the following options: % over cost,Flat over cost,Set flat amount
	And I will no longer see the field Accessorial Value

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |

Scenario Outline: 48628 - Verify the Set Gainshare Type field while adding another accessorial
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	When I click on Add Another Accessorial button of Set Individual Accessorials modal
	Then I will see a new field named Set Gainshare Type
	And Set Gainshare Type field will be a drop down list with the following options: % over cost,Flat over cost,Set flat amount
	And I will no longer see the field Accessorial Value

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |

Scenario Outline: 48628 - Verify and validate % over cost field
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	When I Select % over cost from the Set Gainshare Type drop down list
	Then I will see a new field called % over cost
	And Over cost field will be required, editable, numeric
	And Over cost field will be % formatted, allow up to 2 decimal places, auto-populate to 2 decimal places
	And Over cost field will take one as min value
	And Over cost field will take hundred as max value

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |

Scenario Outline: 48628 - Verify over cost field while entering a value less than 1 
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	And I selected % over cost from the Set Gainshare Type drop down list
	When Over cost value entered is less than one 
	Then Over cost field will not accept the value less than one 

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |

Scenario Outline: 48628 - Verify over cost field while entering more than 100
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	And I selected % over cost from the Set Gainshare Type drop down list
	When entered Over cost value is more than hundred
	Then Over cost field will not accept more than more than hundred

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |
	

Scenario Outline: 48628 - Verify and validate Flat over cost field
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	When I Select Flat over cost from the Set Gainshare Type drop down list
	Then I will see a new field called Flat over cost
	And Flat over cost field will be required, editable, numeric
	And Flat over cost field will be us currency formatted formatted, allow up to 2 decimal places, auto-populate to 2 decimal places
	And Flat over cost field will take min value as one
	And Flat over cost field will take 999 point 99 as max value 

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |

Scenario Outline: Verify Flat over cost while entering a value less than 1
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	And I selected Flat over cost from the Set Gainshare Type drop down list
	When I have entered Flat over cost value less than one
	Then Flat over cost field will not accept the value less than one

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |

Scenario Outline: Verify Flat over cost while entering a value more than 999.99
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	And I selected Flat over cost from the Set Gainshare Type drop down list
	When I have entered Flat over cost value more than 999.99
	Then Flat over cost field will not accept the value more than 999.99

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |	
	

Scenario Outline: 48628 - Verify and validate Set flat amount fields
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	When I Select Set flat amount from the Set Gainshare Type drop down list
	Then I will see a new field called Set flat amount
	And Set flat amount field will be required, editable, numeric
	And Set flat amount field will be $ formatted, allow up two decimal places, auto-populate two decimal places
	And Set flat amount field will take min value as one
	And Set flat amount field will take 999 point 99 as max value 

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |


Scenario Outline: Verify Set flat amount while entering a value less than 1
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	And I selected Set flat amount from the Set Gainshare Type drop down list
	When I have entered Set flat amount less than one
	Then Set flat amount field will not accept a value less than one

Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |

Scenario Outline: Verify Set flat amount while entering more than 100
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I am on Set Individual Accessorials modal
	And I selected Set flat amount from the Set Gainshare Type drop down list
	When I have entered '999.99' as Set flat amount 
	Then The field will not accept more than '999.99' value


Examples: 
	| carriers		  |
	| SingleCarrier   |
	| MultipleCarrier |

Scenario Outline: 48628 : Verify validation of % over cost field when user selects % over cost from the Set Gainshare Type drop down list
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	When I Select % over cost from the Set Gainshare Type dropdown list
	Then I will see a new required field % over cost
	And % over cost is editable, allows numeric values upto two decimal places
	And % over cost % formatted, displays % after the numeric value
	And The Min value % over cost field takes is 1.00%
	And The max value % over cost field accepts is 100.00%

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Try to pass a value more than 2 decimal places to % over cost field and verify the validation
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	And % over cost has been selected as Set Gainshare Type from the drop down list
	When I enter a value more than two decimal places to % over cost field
	Then % over cost field should not accept a value which is more than two decimal places

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Try to pass a value less than 1.00% to % over cost field and verify the validation 
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	And % over cost has been selected as Set Gainshare Type from the drop down list
	When I enter a value less than one to % over cost field 
	Then % over cost field should not accept a value less than one

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Try to pass a value more than 100.00% to % over cost field and verify the validation 
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	And % over cost has been selected as Set Gainshare Type from the drop down list
	When I enter a value more than hundred to % over cost field 
	Then % over cost field should not accept a value more than hundred

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Verify validation of Flat over cost field when user selects Flat over cost from the Set Gainshare Type drop down list
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	When I Select Flat over cost from the Set Gainshare Type dropdown list
	Then I will see a new required field Flat over cost
	And Flat over cost is editable, allows numeric values upto two decimal places
	And Flat over cost currency formatted, displays $ before the numeric value
	And The Min value Flat over cost field takes is $1.00
	And The max value Flat over cost field accepts is $999.99

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Try to pass a value more than 2 decimal places to Flat over cost field and verify the validation
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	And Flat over cost has been selected as Set Gainshare Type from the drop down list
	When I enter a value more than two decimal places to Flat over cost field
	Then Flat over cost field should not accept a value which is more than two decimal places

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Try to pass a value less than $1.00 to Flat over cost field and verify the validation 
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	And Flat over cost has been selected as Set Gainshare Type from the drop down list
	When I enter a value less than one to Flat over cost field 
	Then Flat over cost field should not accept a value less than one

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Try to pass a value more than $999.99 to Flat over cost field and verify the validation 
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	And Flat over cost has been selected as Set Gainshare Type from the drop down list
	When I enter a value more than $999.99 to Flat over cost field 
	Then Flat over cost field should not accept a value more than $999.99

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Verify validation of Set flat amount field when user selects Set flat amount from the Set Gainshare Type drop down list
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	When I Select Set flat amount from the Set Gainshare Type dropdown list
	Then I will see a new required field Set flat amount
	And Set flat amount is editable, allows numeric values upto two decimal places
	And Set flat amount currency formatted, displays $ before the numeric value
	And The Min value Set flat amount field takes is $1.00
	And The max value Set flat amount field accepts is $999.99

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Try to pass a value more than 2 decimal places to Set flat amount field and verify the validation
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	And Set flat amount has been selected as Set Gainshare Type from the drop down list
	When I enter a value more than two decimal places to Set flat amount field
	Then Set flat amount field should not accept a value which is more than two decimal places

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Try to pass a value less than $1.00 to Set flat amount field and verify the validation 
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	And Set flat amount has been selected as Set Gainshare Type from the drop down list
	When I enter a value less than one to Set flat amount field 
	Then Set flat amount field should not accept a value less than one

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Try to pass a value more than $999.99 to Set flat amount field and verify the validation 
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
	And Set flat amount has been selected as Set Gainshare Type from the drop down list
	When I enter a value more than $999.99 to Set flat amount field 
	Then Set flat amount field should not accept a value more than $999.99

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Verify the functionality of save button on Set Individual Accessorials modal 
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I have selected a customer
	And I selected one or more Carriers from the Master Carrier Rate Settings page <carriers>
	And Clicked on the Set Accessorials Button
	And I set values on Set Individual Accessorials Modal
	When I click on the Save button of Set Individual Accessorials Modal
	Then The Accessorial Gainshare types and associated values will be saved <carriers>

Examples: 
| carriers        |
| SingleCarrier   |
| MultipleCarrier |

Scenario Outline: 48628 : Verify the display of % over cost value on the grid
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I selected a customer
	And I selected a carrier
	And One or more Individual accessorials has been set for the customer <accessorials>
	When % over cost is selected as the Gainshare Type for the individual accessorial <accessorials>
	Then I will see value displayed as xx.xx % on the grid <accessorials>
	And (% over) will be displayed beneath the value <accessorials>

Examples: 
| accessorials        |
| SingleAccessorial   |
| MultipleAccessorial |

 Scenario Outline: 48628 : Verify the display of Flat over cost value on the grid
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I selected a customer
	And I selected a carrier
	And One or more Individual accessorials has been set for the customer <accessorials>
	When Flat over cost is selected as the Gainshare Type for the individual accessorial <accessorials>
	Then I will see the value displayed as $xx.xx on the grid <accessorials>
	And (flat over) will be displayed beneath the value <accessorials>

Examples: 
| accessorials        |
| SingleAccessorial   |
| MultipleAccessorial |

Scenario Outline: 48628 : Verify the display of Set flat amount value on the grid
	Given I am a Pricing config or a Config manager user
	And I am on the Master Carrier Rate Settings page
	And I selected a customer
	And I selected a carrier
	And One or more Individual accessorials has been set for the customer <accessorials>
	When Set flat amount is selected as the Gainshare Type for the individual accessorial <accessorials>
	Then I will see the value displayed as $xx.xx on the grid <accessorials>
	And (flat amt) will be displayed beneath the value <accessorials>

Examples: 
| accessorials        |
| SingleAccessorial   |
| MultipleAccessorial |
	
