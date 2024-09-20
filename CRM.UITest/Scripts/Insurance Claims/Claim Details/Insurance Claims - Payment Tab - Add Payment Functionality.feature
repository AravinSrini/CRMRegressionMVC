@Sprint84 @40718 
Feature: Insurance Claims - Payment Tab - Add Payment Functionality
	
@GUI
Scenario: 40718 - Verify the display and validations of expected fields on Add Payment modal
Given I am a claims specialist user
And I am on the Claims List page
And I clicked on the hyperlink of a displayed claim
And I arrive on the Details tab of the selected claim
And Clicked on the Payments Tab
When I click on Add Payment button
Then The Add Payment modal will open
And I will be able to see Payment Type
And I will be able to see Payment Amount
And I will be able to see Payment Date
And I will be able to see Check Number
And I will be able to see Check Date
And I will be able to see Comments
And I will be able to see 'Cancel' button
And I will be able to see 'Add' button
And The following will be required fields : Payment Type, Payment Amount, Payment Date, Check Number, Check Date, Comments
And The PaymentType will be a selectable dropdown list 
And The Payment Amount field format will be currency
And The Payment Amount field will allow upto two decimal places
And The Payment Amount field will auto fill with $ and two decimal places
And Payment Date calender will not allow to select a future date 
And The Payment Date field will be editable with the format -  mm/dd/yyyy
And The Check Number field will be free form text - allowing a max length of 50 alpha-numeric and special characters
And Check Date calender will not allow to select a future date 
And The Check Date field will be editable with the format -  mm/dd/yyyy
And The Comments field format will be free form text - allowing a max length of 500 alpha-numeric and special characters


@GUI @DB
Scenario: 40718 - Verify the existence of Payment Type dropdown values on Add Payment modal
Given I am a claims specialist user
And I am on the Claims List page
And I clicked on the hyperlink of a displayed claim
And I arrive on the Details tab of the selected claim
And Clicked on the Payments Tab
And I clicked on the Add Payment button
And The Add Payment modal opened
When I click in the  Payment Type field
Then I will see a list of payment types <Carrier Direct Pay To Claimant>, <Carrier Payment To DLSW>, <Credit>, <Debit>, <DLSW Payment to Claimant>, <Expected Recovery>, <Expense>, <Insurance Direct Pay To Claimant>, <Other, See Comment>, <Reimbursement>, <Salvage Allowance>, <Subrogation>
And The payment type list is configurable

@GUI
Scenario Outline: 40718 - Verify the display of optional fields on Add Payment modal when user selects either 'Expected Recovery' or 'Salvage Allowance' as Payment Type
Given I am a claims specialist user
And I am on the Claims List page
And I clicked on the hyperlink of a displayed claim
And I arrive on the Details tab of the selected claim
And I clicked on the Payments Tab
And Arrived on the Payments Tab
And I clicked on the Add Payment button
And The Add Payment modal opened
When I select <PaymentType>
Then Payment Date is optional
And Check Number is optional
And Check Date is optional

Examples: 
| PaymentType       |
| Expected Recovery |
| Salvage Allowance |

@Functional
Scenario: 40718 - Verify the functionality of Cancel button on Add Payment modal
Given I am a claims specialist user
And I am on the Claims List page
And I clicked on the hyperlink of a displayed claim
And I arrive on the Details tab of the selected claim
And I clicked on the Payments Tab
And Arrived on Payments Tab
And I clicked on the Add Payment button
And The Add Payment modal opened
When I click on Cancel button of Add Payemnt Modal
Then The modal will close
And No new payment entry is created.

@Functional
Scenario: 40718 - Verify the functionality of Save button on Add Payment modal when user passes values to all required fields
Given I am a claims specialist user
And I am on the Claims List page
And I clicked on the hyperlink of a displayed claim
And I arrive on the Details tab of the selected claim
And I clicked on the Payments Tab
And Arrived on the Payments Tab
And I clicked on the Add Payment button
And The Add Payment modal opened
And I entered all required information
When I click on Save button
Then The modal will close
And The new payment entry will be displayed in the Payment grid.

@Functional
Scenario: 40718 - Verify the functionality of Save button on Add Payment modal when user doesn't pass values to all required fields 
Given I am a claims specialist user
And I am on the Claims List page
And I clicked on the hyperlink of a displayed claim
And I arrive on the Details tab of the selected claim
And I clicked on the Payments Tab
And Arrived on the Payments Tab
And I clicked on the Add Payment button
And The Add Payment modal opened
And I did not enter all required information
When I click on Save button
Then I will receive message <Please complete all required information>
And The required fields missing information will be highlighted in red.






