
@Sprint84 @40165 
Feature: Insurance Claims - Payment Tab - Elements
	

@GUI
Scenario: 40165 - Verify the Payment grid columns
	Given I am a sales, sales management, operations, station owner, claims specialist user
	And I am on the Claims List page
	And I clicked on the hyper link of a displayed claim to arrive on the Details tab
	When I click on the Payment tab
	Then I will see a Payment grid with the following  columns : PAYMENT TYPE,PAYMENT DATE,COMMENT,CHECK NUMBER,CHECK DATE,PAYMENT AMOUNT
	And Payment Date format should be mm/dd/yyyy
	And Check Date format should be mm/dd/yyyy
	And Payment Amount currency format should be $x,xxx.xx
	And I will see a field on the tab <Outstanding Amount>

@GUI
Scenario: 40165 - Verify the comment field by entering more than 25 characters
	Given I am a sales, sales management, operations, station owner, claims specialist user
	And I am on the Claims List page
	And I clicked on the hyper link of a displayed claim to arrive on the Details tab
	And I clicked on the Payment tab
	When the comment of any displayed payment entry is greater than 25 characters
	Then I will see three dots<...> 
	And mouse over will show the details

@GUI
Scenario: 40165 - Verify the Add Payment button from payment tab
	Given I am a claims specialist user
	And I am on the Claims List page
	And I clicked on the hyper link of a displayed claim to arrive on the Details tab
	And I arrive on the Details tab of the selected claim
	When I click on the Payment tab
	Then I will see an <Add Payment> button