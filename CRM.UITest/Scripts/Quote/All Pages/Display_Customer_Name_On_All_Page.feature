@NinjaSprint21 @44620
Feature: Display Customer Name On All Pages - Station Users

@Regression
Scenario: 44620_Verify Verbiage is displayed in the Quote List grid
	Given that I am a sales, sales management, operations, or station owner user,
	When I arrive on the Quote List page,
	Then I will see the customer list selection field positioned centered at the top of the Quote List page,
	And the customer list is positioned centered beneath the rrd dls world wide banner,
	And the customer list selection field will be defaulted to "Select an account to display...",
	And I will see the following verbiage in the Quote List grid: "Please select a station or customer to view quotes".

@Regression
Scenario: 44620_Verify Customers are listed in hierarchy format and sorted alphabetically in the Select an account field
	Given that I am a sales, sales management, operations, or station owner user,
	And I am on the Quote List page,
	When I click in the customer list selection field,
	Then the customers will be listed in hierarchy format,(Station -> Primary Account -> Sub Account) 
	And the customers will be listed alphabetically.

@Regression
Scenario: 44620_Verify All Customers is not a selectable option when the customer selection field is clicked
	Given that I am a sales, sales management, operations, or station owner user,
	And I am on the Quote List page,
	When I click in the customer list selection field,
	Then I will no longer have the option to select All Customers.

@Regression
Scenario: 44620_Verify Correct Verbiage is displayed beneath the customer list when a customer is selected
	Given that I am a sales, sales management, operations, or station owner user,
	And I am on the Quote List page,
	When I select a customer from the customer drop down list,
	Then I will see the following verbiage displayed directly beneath the customer list: "Submitted rate requests within the past 30 days are shown."

@Regression
Scenario: 44620_Verify Station-Primary Account-Customer Name displayed and are not editable on the Get Quote selection page
	Given that I am a sales, sales management, operations, or station owner user,
	And I am on the Quote List page,
	And I selected a customer,
	And I clicked on the Submit Rate Request button,
	When I arrive on the Get Quote selection page,
	Then I will see the Station-Primary Account-Customer Name displayed,
	And the Station-Primary Account-Customer Name is not editable for get quote selection page.

@Regression
Scenario: 44620_Verify Station-Primary Account-Customer Name displayed and are not editable on the Get Quote(LTL) page
	Given that I am a sales, sales management, operations, or station owner user,
	And I am on the Quote List page,
	And I selected a customer,
	And I clicked on the Submit Rate Request button,
	And I clicked on the LTL tile on the Get Quote page,
	When I arrive on the Get Quote (LTL) page,
	Then I will see the Station-Primary Account-Customer Name displayed,
	And the Station-Primary Account-Customer Name is not editable for get quote page.

@Regression
Scenario: 44620_Verify Station-Primary Account-Customer Name displayed and are not editable on the Quote Results(LTL) page
	Given that I am a sales, sales management, operations, or station owner user,
	When I am on the Quote Results (LTL) page,
	Then I will see the Station-Primary Account-Customer Name displayed,
	And the Station-Primary Account-Customer Name is not editable for quote results page.

@Regression
Scenario: 44620_Verify Station-Primary Account-Customer Name displayed and are not editable on the Quote Confirmation(LTL) page
	Given that I am a sales, sales management, operations, or station owner user,
	When I am on the Quote Confirmation (LTL) page,
	Then I will see the Station-Primary Account-Customer Name displayed,
	And the Station-Primary Account-Customer Name is not editable for quote confirmation page.

@Regression
Scenario: 44620_Verify Station-Primary Account-Customer Name displayed and are not editable on the Get Quote(LTL) page after clicking the Re-quote button
	Given that I am a sales, sales management, operations, or station owner user,
	And I am on the Quote List page,
	And I expanded the quote details of an expired LTL quote,
	And I clicked on the Re-quote button,
	When I arrive on the Get Quote (LTL) page,
	Then I will see the Station - Primary Account - Customer Name of the expired quote displayed on the page,
	And the displayed Station - Primary Account - Customer Name is not editable.