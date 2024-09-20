@47691 @Sprint85 
Feature: Shipment (LTL) _All Risk Ins Reminder_PPP and Std Customers

@GUI @Acceptance
Scenario: 47691 - Verify the display of expected All Risk Ins Reminder for PPP customers on Add Shipment(LTL) page
	Given I am a shp.entrynorates, shp.entry, sales, sales management, operations, or station owner user
	And I am associated to a customer with PPP all-risk insurance setting
	And I am creating an LTL shipment
	And I am on the Add Shipment(LTL) page
	When I enter a value greater than $15,000.00 in <Enter insured value...> field
	Then I will receive a error message:'Error'
	And Message will read 'The entered shipment value exceeds $15,000. Please contact your DLS representative.'
	And I have an option to remove the message
	And I will not be able to see <View Rates>

@GUI @Acceptance
Scenario: 47691 - Verify the display of expected All Risk Ins Reminder for PPP customers on Shipment Result(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or station owner user
	And I am associated to a customer with PPP all-risk insurance setting
	And I am creating an LTL shipment
	And I am on the Shipment Results(LTL) page
	When I enter a value greater than $15,000.00 on <Enter insured value:> field
	Then I will receive a message: 'The entered shipment value exceeds $15,000. Please contact your DLS representative.' beneath the Insured value field
	
@GUI @Acceptance
Scenario: 47691 - Verify the display of expected All Risk Ins Reminder for Standard customers on Shipment Result(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or station owner user
	And The customer in which I am associated does not have PPP all-risk insurance setting
	And I am creating an LTL shipment
	And I am on the Shipment Results(LTL) page
	When I enter a Value greater than $100,000.00 on the <Enter insured value:> field
	Then I will receive a message: 'The entered shipment value exceeds $100,000. Please contact your DLS representative.' beneath Insured value field
	
@GUI @Acceptance
Scenario: 47691 - Verify the display of expected All Risk Ins Reminder for PPP customers on Insured rates modal of Shipment Results(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with PPP all-risk insurance setting
	And I am creating an LTL shipment
	And I am on the Shipment Results(LTL) page
	And I did not enter a value in <Enter insured value:> field
	And I Clicked on <Create Shipment> button
	And I entered a value greater than $15,000.00 in <Insured Value> field of the Insured Rates modal
	When I click on <Show Insured Rate> button of Insured Rates modal
	Then I will receive a message: 'The entered shipment value exceeds $15,000. Please contact your DLS representative.' beneath Insured value field of modal
	And I have an option to continue without insured rates.

@GUI @Acceptance
Scenario: 47691 - Verify the display of expected All Risk Ins Reminder for Standard customers on Insured rates modal of Shipment Results(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And The customer in which I am associated does not have PPP all-risk insurance setting
	And I am creating an LTL shipment
	And I am on the Shipment Results(LTL) page
	And I did not enter a value in <Enter insured value:> field
	And I Clicked on <Create Shipment> button
	And I entered a value greater than $100,000.00 on the <Insured Value> field of the Insured Rates modal
	When I click on <Show Insured Rate> button of Insured Rates modal
	Then I will receive a message: 'The entered shipment value exceeds $100,000. Please contact your DLS representative.' beneath Insured value field of the modal
	And I have an option to continue without insured rates.

@GUI
Scenario: 47691 - Verify if All Risk Ins Reminder is displayed when user passes less than the expected insured value for PPP customers on Add Shipment(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with PPP all-risk insurance setting
	And I am creating an LTL shipment
	And I am on the Add Shipment(LTL) page
	When I enter a value less than $15,000.00 in <Enter insured value...> field
	Then All Risk Ins Reminder message will not be displayed on Add Shipment(LTL) page

@GUI
Scenario: 47691 - Verify if All Risk Ins Reminder is displayed when user passes a value equal to the expected insured value for PPP customers on Add Shipment(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with PPP all-risk insurance setting
	And I am creating an LTL shipment
	And I am on the Add Shipment(LTL) page
	When I enter a Value equal to $15,000.00 in <Enter insured value...> field
	Then All Risk Ins Reminder message will not be displayed on Add Shipment(LTL) page

@GUI
Scenario: 47691 - Verify if All Risk Ins Reminder is displayed when user passes less than the expected insured value for PPP customers on Shipment Results page
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with PPP all-risk insurance setting	
	And I am creating an LTL shipment
	And I am on the Shipment Results(LTL) page
	When I enter a Value less than $15,000.00 on <Enter insured value...> field
	Then All Risk Ins Reminder message will not be displayed on Shipment Results (LTL) page

@GUI
Scenario: 47691 - Verify if All Risk Ins Reminder is displayed when user passes a value equal to the expected insured value for PPP customers on Shipment Results page
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with PPP all-risk insurance setting
	And I am creating an LTL shipment
	And I am on the Shipment Results(LTL) page
	When I enter a value equal to $15,000.00 on <Enter insured value...> field
	Then All Risk Ins Reminder message will not be displayed on Shipment Results (LTL) page

@GUI
Scenario: 47691 - Verify if All Risk Ins Reminder is displayed when user passes less than the expected insured value for PPP customers on Insured rates modal 
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with PPP all-risk insurance setting
	And I am creating an LTL shipment
	And I am on the Shipment Results(LTL) page
	When I enter a value less than $15,000.00 in the <Enter insured value...> field of the Insured Rates modal
	Then All Risk Ins Reminder message will not be displayed on Insured Rates modal of Shipment Results page

@GUI
Scenario: 47691 - Verify if All Risk Ins Reminder is displayed when user passes a value equal to the expected insured value for PPP customers on Insured rates modal 
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with PPP all-risk insurance setting	
	And I am creating an LTL shipment
	And I am on the Shipment Results(LTL) page
	When I enter a value equal to $15,000.00 in the <Enter insured value...> field of the Insured Rates modal
	Then All Risk Ins Reminder message will not be displayed on Insured Rates modal of Shipment Results page


	




