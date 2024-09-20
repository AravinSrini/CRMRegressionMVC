@27967 @Sprint69 
Feature: Add Shipment (LTL)_ Pickup Date and Time - All Users
	
@GUI
Scenario Outline: Verify default Pickup date in Add shipment LTL page (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	When I click on Add Shipment Button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I should be able to view Pickup Date defaulted to the current date
	And I click on Date Picker
	And I should not be able to select a date prior to the current defaulted date

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

@GUI
Scenario Outline: Verify default Pickup date in Add shipment LTL page (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I should be able to view Pickup Date defaulted to the current date
	And I click on Date Picker
	And I should not be able to select a date prior to the current defaulted date

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |


@Functional
Scenario Outline: Verify the functionality of PickUp date picker in Add Shipment LTL page (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	When I click on Add Shipment Button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I click on Date Picker
	And I should be able to select PickUp date 

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

@Functional
Scenario Outline: Verify the functionality of PickUp date picker in Add Shipment LTL page (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I click on Date Picker
	And I should be able to select PickUp date 

Examples: 
| Username              | Password |
| crmOperation@user.com | Te$t1234 |


@Functional
Scenario Outline: Verify the functionality of Pickup date Ready time and Pickup date Close time(External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	When I click on Add Shipment Button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I should be able to select Pickup date <Readytime>
	And I must be able to select Pickup date <Closetime>

Examples: 
| Username        | Password | Readytime | Closetime |
| zzzext@user.com | Te$t1234 | 5:00 AM   | 6:00 AM   |

@Functional
Scenario Outline: Verify the functionality of Pickup date Ready time and Pickup date Close time(Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I should be able to select Pickup date <Readytime>
	And I must be able to select Pickup date <Closetime>

Examples: 
| Username              | Password | Readytime | Closetime |
| crmOperation@user.com | Te$t1234 | 5:00 AM   | 6:00 AM   |


@Functional
Scenario Outline: Try selecting Pickup date close time which is after Pickup Date Ready time (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	When I click on Add Shipment Button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I select Pickup date <Readytime>
	And I should be able to choose PickUp date <Closetime> that is after PickUp Date Ready time
	
Examples: 
| Username        | Password | Readytime | Closetime |
| zzzext@user.com | Te$t1234 | 5:00 AM   | 6:00 AM   |


@Functional
Scenario Outline: Try selecting Pickup date close time which is after Pickup Date Ready time (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I select Pickup date <Readytime>
	And I should be able to choose PickUp date <Closetime> that is after PickUp Date Ready time
	
Examples: 
| Username              | Password | Readytime | Closetime |
| crmOperation@user.com | Te$t1234 | 5:00 AM   | 6:00 AM   |

@Functional
Scenario Outline: Try selecting Pickup date Close time which is before Pickup Date Ready time (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	When I click on Add Shipment Button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I select Pickup date <Readytime>
	And I select PickUp date <Closetime> that is before PickUp date Ready time
	And Then i should recieve a message stating - Please select a Pickup Date Close time that is after the Pickup Date Ready time.

Examples: 
| Username        | Password | Readytime | Closetime |
| zzzext@user.com | Te$t1234 | 5:00 AM   | 4:00 AM   |


@Functional
Scenario Outline: Try selecting Pickup date Close time which is before Pickup Date Ready time (Internal Users)
Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I select Pickup date <Readytime>
	And I select PickUp date <Closetime> that is before PickUp date Ready time
	And Then i should recieve a message stating - Please select a Pickup Date Close time that is after the Pickup Date Ready time.

Examples: 
| Username              | Password | Readytime | Closetime |
| crmOperation@user.com | Te$t1234 | 5:00 AM   | 6:00 AM   |


@Functional
Scenario Outline: Try selecting Pickup date Ready time which is before Pickup Date Close time (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	When I click on Add Shipment Button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I select Pickup date <Closetime>
	And I should be able to select PickUp date <Readytime> that is before Pickup Date Close time
	
Examples: 
| Username        | Password | Readytime | Closetime |
| zzzext@user.com | Te$t1234 | 5:00 AM   | 7:00 AM   |

@Functional
Scenario Outline: Try selecting Pickup date Ready time which is before Pickup Date Close time (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I select Pickup date <Closetime>
	And I should be able to select PickUp date <Readytime> that is before Pickup Date Close time
	
Examples: 
| Username              | Password | Readytime | Closetime |
| crmOperation@user.com | Te$t1234 | 5:00 AM   | 7:00 AM   |

@Functional
Scenario Outline: Try selecting Pickup Date Ready time which is after the Pickup Date Close time (External Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	When I click on Add Shipment Button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I select Pickup date <Closetime>
	And I select PickUp date <Readytime> that is after Pickup Date Close time
	And Then i should receive message stating - Please select a Pickup Date Ready time that is before the Pickup Date Close time.

Examples: 
| Username        | Password | Readytime | Closetime |
| zzzext@user.com | Te$t1234 | 2:00 AM   | 1:00 AM   |


@Functional
Scenario Outline: Try selecting Pickup Date Ready time which is after the Pickup Date Close time (Internal Users)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	Then I select Pickup date <Closetime>
	And I select PickUp date <Readytime> that is after Pickup Date Close time
	And Then i should receive message stating - Please select a Pickup Date Ready time that is before the Pickup Date Close time.

Examples: 
| Username              | Password | Readytime | Closetime |
| crmOperation@user.com | Te$t1234 | 2:00 AM   | 1:00 AM   |

