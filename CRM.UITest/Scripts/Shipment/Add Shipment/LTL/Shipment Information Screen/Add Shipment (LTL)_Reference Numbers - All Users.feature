@28048 @Sprint69 
Feature: Add Shipment (LTL)_Reference Numbers - All Users

@Functional
Scenario Outline: Verify the functionality of Add Additional Reference button (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	Then I should be able to click on Add Additional Reference button

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

@Functional
Scenario Outline: Verify the functionality of Add Additional Reference button (Internal Users)
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment Button
And I arrive and Shipment list page
And I select a customer of TMS type MG or Both from the customer selection dropdown
When I click on Add Shipment button for Internal Users
And I Click on LTL service type
And I arrive on Add shipment LTL page
When I expand Reference number section
Then I should be able to click on Add Additional Reference button

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |

@GUI @Functional
Scenario Outline: Verify the existence and functionality of Reference dropdown list within Reference number section (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	And I click on Add Additional Reference button
	Then I must be able to view Reference number dropdown list
	And I must be able to select a reference from reference dropdown list

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

@Functional
Scenario Outline: Verify the functionality of Reference dropdown list within Reference number section (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	And I click on Add Additional Reference button
	Then I must be able to view Reference number dropdown list
	And I must be able to select a reference from reference dropdown list

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |

@Functional
Scenario Outline: Verify the existence and functionality Reference number text field within Reference number section (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	And I click on Add Additional Reference button
	And I select reference type from reference number dropdown list
	Then I must be able to view Reference number text field
	And I must be able to enter Reference number

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |
 
@Functional
Scenario Outline: Verify the existence and functionality of Reference number text field within Reference number section (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section 
	And I click on Add Additional Reference button
	And I select reference type from reference number dropdown list
	Then I must be able to view Reference number text field
	And I must be able to enter Reference number


Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |

@Functional
Scenario Outline: Verify the existence and functionality of Remove button within Reference number section (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	And I click on Add Additional Reference button
	Then I should be able to view Remove button
	And I should be able to click on remove button
	And The added Additional Reference should be removed

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

@Functional
Scenario Outline: Verify the functionality of Remove button within Reference number section (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	And I click on Add Additional Reference button
	Then I should be able to view Remove button
	And I should be able to click on remove button
	And The added Additional Reference should be removed

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |

Scenario Outline: Try clicking View rates button without adding data to Enter reference number text field (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	And I click on Add Additional Reference button
	And I select Reference type without adding data to enter reference number field
	And I click on View rates button in add shipment ltl page
	Then The Enter reference number field should be highlighted.

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

Scenario Outline: Try clicking View rates button without adding data to Enter reference number text field (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	And I click on Add Additional Reference button
	And I select Reference type without adding data to enter reference number field
	And I click on View rates button in add shipment ltl page
	Then The Enter reference number field should be highlighted.

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |


Scenario Outline: Try entering more than 25 characters to reference number field (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	And I click on Add Additional Reference button
	And I select reference type from reference number dropdown list
	And I try entering more than twenty five characters to reference number field
	Then I should not be able to enter more than twenty five charcters
	

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 | 

Scenario Outline: Try entering more than 25 characters to reference number field (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	When I expand Reference number section
	And I click on Add Additional Reference button
	And I select reference type from reference number dropdown list
	And I try entering more than twenty five characters to reference number field
	Then I should not be able to enter more than twenty five charcters

Examples: 
| Username              | Password | 
| crmOperation@user.com | Te$t1234 | 