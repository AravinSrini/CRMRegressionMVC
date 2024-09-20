@Sprint85 @47690 
Feature: Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers

@Regression 
Scenario: 47690 - Verify the display of expected All Risk Ins Reminder for standard customers on Get Quote(LTL) page
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station owner user
	And The customer in which I am associated does not have a PPP all-risk insurance setting
	And I am submitting an LTL quote
	And I am on Get Quote (LTL) Page
	When I enter a value greater than $100,000 in the <Enter insured value...> field
	Then I will receive a message: 'Error'
	And The error message will read 'The entered shipment value exceeds $100,000. Please contact your DLS representative.'
	
@Regression 
Scenario: 47690 - Verify the display of expected All Risk Ins Reminder for PPP customers on Get Quote(LTL) page
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station owner user
	And I am associated to a customer with a PPP all-risk insurance setting
	And I am submitting an LTL quote
	And I am on Get Quote (LTL) Page
	When I enter a value greater than $15,000.00 in the <Enter insured value...>field
	Then I will receive a message: 'Error'
	And The error message will read 'The entered shipment value exceeds $15,000. Please contact your DLS representative.'
	And I have the option to remove the message
	And I am unable to <View Quote Results>

@Regression 
Scenario: 47690 - Verify the display of expected All Risk Ins Reminder for Standard customers on Quote Results(LTL) page
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station owner user
	And The customer in which I am associated does not have a PPP all-risk insurance setting
	And I am submitting an LTL quote
	And I am on Quote Results (LTL) page
	When I enter value greater than $100,000 in the <Enter insured value:> field
	Then I will receive a message:'The entered shipment value exceeds $100,000. Please contact your DLS representative.' beneath insured value field of Quote results page

@Regression 
Scenario: 47690 - Verify the display of expected All Risk Ins Reminder for PPP customers on Quote Results(LTL) page
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station owner user
	And I am associated to a customer with a PPP all-risk insurance setting
	And I am submitting an LTL quote
	And I did not enter an insured value on the Get Quote (LTL) page
	And I am on Quote Results (LTL) page
	When I enter value greater than $15,000.00 in the <Enter insured value:>field
	Then I will receive a message:'The entered shipment value exceeds $15,000. Please contact your DLS representative.' beneath insured value field of Quote results page

@Regression 
Scenario: 47690 - Verify the display of expected All Risk Ins Reminder for Standard customers on Insured rates modal of Quote Results(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And The customer in which I am associated does not have a PPP all-risk insurance setting
	And I am submitting an LTL quote
	And I am on Quote Results (LTL) page
	And I did not enter a value on <Enter insured value:> field
	And I clicked on <Create Shipment>button
	And I entered value greater than $100,000.00 in the <Insured Value> field of the Insured Rates modal
	When I click on <Show Insured Rate>button
	Then I will receive a message:'The entered shipment value exceeds $100,000. Please contact your DLS representative.' beneath the Insured value field of modal
	And I have the option to continue without insured rates.

@Regression 
Scenario: 47690 - Verify the display of expected All Risk Ins Reminder for PPP customers on Insured rates modal of Quote Results(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with a PPP all-risk insurance setting
	And I am submitting an LTL quote
	And I am on Quote Results (LTL) page
	And I did not enter a value in the <Enter insured value:> field
	And I clicked on <Create Shipment>button
	And I entered value greater than $15,000.00 in the <Insured Value> field of the Insured rates modal
	When I click on <Show Insured Rate>button
	Then I will receive a message:'The entered shipment value exceeds $15,000. Please contact your DLS representative.' beneath the Insured value field of modal
	And I have the option to continue without insured rates.

@Regression 
Scenario: 47690 - Verify if All Risk Ins Reminder is displayed when user passes less than the expected insured value for PPP customers on Get Quote(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or station owner user
	And I am associated to a customer with a PPP all-risk insurance setting	
	And I am submitting an LTL quote
	And I am on Get Quote (LTL) Page
	When I enter a value less than $15,000.00 in the <Enter insured value...>field
	Then All Risk Ins Reminder message will not be displayed on Get Quote (LTL) page

@Regression 
Scenario: 47690 - Verify if All Risk Ins Reminder is displayed when user passes a value equal to the expected insured value for PPP customers on Get Quote(LTL) page
	Given I am a shp.entry, sales, sales management, operations, or station owner user
	And I am associated to a customer with a PPP all-risk insurance setting	
	And I am submitting an LTL quote
	And I am on Get Quote (LTL) Page
	When I enter a value equal to $15,000.00 in <Enter insured value...>field
	Then All Risk Ins Reminder message will not be displayed on Get Quote (LTL) page

@Regression 
Scenario: 47690 - Verify if All Risk Ins Reminder is displayed when user passes less than the expected insured value for PPP customers on Quote Results page
	Given I am a shp.entry, sales, sales management, operations, or station owner user
	And I am associated to a customer with a PPP all-risk insurance setting	
	And I am submitting an LTL quote
	And I am on Quote Results (LTL) page
	When I enter a value less than $15,000.00 on <Enter insured value...>field
	Then All Risk Ins Reminder message will not be displayed on Quote results page

@Regression 
Scenario: 47690 - Verify if All Risk Ins Reminder is displayed when user passes a value equal to the expected insured value for PPP customers on Quote Results page
	Given I am a shp.entry, sales, sales management, operations, or station owner user
	And I am associated to a customer with a PPP all-risk insurance setting	
	And I am submitting an LTL quote
	And I am on Quote Results (LTL) page
	When I enter a value equal to $15,000.00 on the <Enter insured value...>field
	Then All Risk Ins Reminder message will not be displayed on Quote results page

@Regression 
Scenario: 47690 - Verify if All Risk Ins Reminder is displayed when user passes less than the expected insured value for PPP customers on Insured rates modal 
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with a PPP all-risk insurance setting	
	And I am submitting an LTL quote
	And I am on Quote Results (LTL) page
	When I enter value less than $15,000.00 in the <Enter insured value...>field of Insured Rates modal
	Then All Risk Ins Reminder message will not be displayed on Insured Rates modal of Quote Results page

@Regression 
Scenario: 47690 - Verify if All Risk Ins Reminder is displayed when user passes a value equal to the expected insured value for PPP customers on Insured rates modal 
	Given I am a shp.entry, sales, sales management, operations, or a stationowner user
	And I am associated to a customer with a PPP all-risk insurance setting	
	And I am submitting an LTL quote
	And I am on Quote Results (LTL) page
	When I enter a value equal to $15,000.00 in <Enter insured value...>field of Insured Rates modal
	Then All Risk Ins Reminder message will not be displayed on Insured Rates modal of Quote Results page


