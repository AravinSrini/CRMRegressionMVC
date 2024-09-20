@52035 @NinjaCreditHold @Regression
Feature: 52035 - Credit Hold - Display Credit Hold Verbiage on Dashboard and List pages

Scenario: 52035_Verify Verbiage is Displayed on the Quote List Page When I am a Customer on Credit Hold
Given I am a shp.inquiry or shp.entry user who is associated with a customer on Credit Hold "username-CreditHoldShipEntry" "password-CreditHoldShipEntry"
When I Navigate to the Quote List page
Then The verbiage Account currently on credit hold will be displayed beneath the Quotes List label on the Quote List Page

Scenario: 52035_Verify Verbiage is not Displayed on the Quote List Page When I am a Customer not on Credit Hold
Given I am a shp.inquiry or shp.entry user who is associated with a customer not on Credit Hold "username-shipentry" "password-shipentry"
When I Navigate to the Quote List page
Then The verbiage Account currently on credit hold will not be present beneath the Quotes label on the Quote List Page

Scenario: 52035_Verify Verbiage is Displayed on the Shipment List Page When I am a Customer on Credit Hold
Given I am a shp.inquiry shp.inquirynorates shp.entry or shp.entrynorates user associated with a customer on Credit Hold "username-CreditHoldShipEntry" "password-CreditHoldShipEntry"
When I Navigate to the Shipment List page
Then The verbiage Account currently on credit hold will be displayed beneath the Shipment List label on the Shipment List Page

Scenario: 52035_Verify Verbiage is not Displayed on the Shipment List Page When I am a Customer not on Credit Hold
Given I am a shp.inquiry shp.inquirynorates shp.entry or shp.entrynorates user associated with a customer not on Credit Hold "username-shipentry" "password-shipentry"
When I Navigate to the Shipment List page
Then The verbiage Account currently on credit hold will not be present beneath the Shipment List label on the Shipment List Page

Scenario: 52035_Verify Verbiage is Displayed on the Quote List Page When I Select a Customer On Credit Hold
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Quote List page
When I choose a quote customer that is on Credit Hold "July4 (credit hold)"
Then The verbiage Account currently on credit hold will be displayed beneath the Quotes List label on the Quote List Page

Scenario: 52035_Verify Verbiage is Displayed on the Shipment List Page When I Select a Customer on Credit Hold
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Shipment List page
When I choose a shipment customer that is on Credit Hold "July4 (credit hold)"
Then The verbiage Account currently on credit hold will be displayed beneath the Shipment List label on the Shipment List Page

Scenario: 52035_Verify Verbiage is Displayed on the Quote List Page When I Select a Customer on Credit Hold on the Shipment List and Navigate to the Quote Page
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Shipment List page
When I choose a shipment customer that is on Credit Hold "July4 (credit hold)"
And I Navigate to the Quote List page
Then The verbiage Account currently on credit hold will be displayed beneath the Quotes List label on the Quote List Page

Scenario: 52035_Verify Verbiage is Displayed on the Shipment List Page When I Select a Customer On Credit Hold on the Quote List and Navigate to the Shipment Page
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Quote List page
When I choose a quote customer that is on Credit Hold "July4 (credit hold)"
And I Navigate to the Shipment List page
Then The verbiage Account currently on credit hold will be displayed beneath the Shipment List label on the Shipment List Page

Scenario: 52035_Verify Verbiage is not Displayed on the Quote List Page When I Select a Customer not on Credit Hold on the Shipment List and Navigate to the Quote Page
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Shipment List page
When I choose a customer that is not on Credit Hold from the shipment customer drop down list "Bob"
And I Navigate to the Quote List page
Then I will not see the verbiage Account currently on credit hold displayed beneath the Quotes label on the Quote List Page

Scenario: 52035_Verify Verbiage is not Displayed on the Shipment List Page When I Select a Customer not on Credit Hold on the Quote List and Navigate to the Shipment Page
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Quote List page
When I choose a customer that is not on Credit Hold from the quote customer drop down list "Bob"
And I Navigate to the Shipment List page
Then I will not see the verbiage Account currently on credit hold displayed beneath the Shipment List label on the Shipment List Page

Scenario: 52035_Verify Verbiage is not Displayed on the Quote List Page When I Select a Customer On Credit Hold then Select a Customer not on Credit Hold
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Quote List page
And I've selected a customer that is on Credit Hold from the quote customer drop down list "July4 (credit hold)"
When I choose a customer that is not on Credit Hold from the quote customer drop down list "Bob"
Then I will no longer see the verbiage Account currently on credit hold displayed beneath the Quotes label on the Quote List Page

Scenario: 52035_Verify Verbiage is not Displayed on the Quote List Page When I Select a Customer on Credit Hold then Select no Customer
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Quote List page
And I've selected a customer that is on Credit Hold from the quote customer drop down list "July4 (credit hold)"
When I choose no customer from the quote customer drop down list "Select an account to display..."
Then I will no longer see the verbiage Account currently on credit hold displayed beneath the Quotes label on the Quote List Page

Scenario: 52035_Verify Verbiage is not Displayed on the Shipment List Page When I Select a Customer on Credit Hold then Select a Customer not on Credit Hold
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Shipment List page
And I've selected a customer that is on Credit Hold from the shipment customer drop down list "July4 (credit hold)"
When I choose a customer that is not on Credit Hold from the shipment customer drop down list "Bob"
Then I will no longer see the verbiage Account currently on credit hold displayed beneath the Shipment List label on the Shipment List Page

Scenario: 52035_Verify Verbiage is not Displayed on the Shipment List Page When I Select a Customer on Credit Hold then Select no customer
Given that I am a sales sales management operation or station owner user "username-CreditHoldInternalUser" "password-CreditHoldInternalUser"
And I Navigate to the Shipment List page
And I've selected a customer that is on Credit Hold from the shipment customer drop down list "July4 (credit hold)"
When I choose no customer from the shipment customer drop down list "Select an account to display..."
Then I will no longer see the verbiage Account currently on credit hold displayed beneath the Shipment List label on the Shipment List Page