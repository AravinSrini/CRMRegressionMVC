@30284 @Sprint76 
Feature: Insurance All RiskProduct Protection Settings Page Customer List and Search Function

@Functional @GUI
Scenario Outline: 30284_Verify if the customers are listed in hierarchical order in the Insurance All Risk page
	Given I am a system admin user <Username> and <Password>
	And I am on the Insurance All Risk/Product Protection Settings page of Maintenance Tools
	And I am on the Insurance All Risk tab
	And I clicked on the Add Customer-Specific Insurance All Risk Settings button
	And I selected a station <Station>
	When I click in the Customer Account field
	Then The customers will be listed in hierarchy format <Station>,
	
Examples: 
| Scenario | Username    | Password | Station        |
| S1       | systemadmin | Te$t1234 | TestStation013 |

@Functional @GUI
Scenario Outline: 30284_Verify if the customers are listed in Alphabetical order in the Insurance All Risk page
	Given I am a system admin user <Username> and <Password>
	And I am on the Insurance All Risk/Product Protection Settings page of Maintenance Tools
	And I am on the Insurance All Risk tab
	And I clicked on the Add Customer-Specific Insurance All Risk Settings button
	And I selected a station <Station>
	When I click in the Customer Account field
	Then The customers will be listed in alphabetical order in the Insurance All Risk page <Station>

Examples: 
| Scenario | Username    | Password | Station |
| S1       | systemadmin | Te$t1234 | Bessie  |

@GUI
Scenario Outline: 30284_Verify if the customers are displayed in alphabetical order in the details section of Insurance all risk page
	Given I am a system admin user <Username> and <Password>
	And I am on the Insurance All Risk/Product Protection Settings page of Maintenance Tools
	And I am on the Insurance All Risk tab
	When I click on the details icon (+) of any displayed station with customer-specific insurance all risk,
	Then The customers will be displayed alphabetically.

Examples: 
| Scenario | Username    | Password |
| S1       | systemadmin | Te$t1234 |

@Functional @GUI
Scenario Outline: 30284_Verify if the customers are listed in hierarchical order when user clicks on Select Customer account field on the Product Protection page
	Given I am a system admin user <Username> and <Password>
	And I am on the Insurance All Risk Or Product Protection Settings page of Maintenance Tools
	And I am on the Product Protection tab,
	And I select station for Product Protection Page <Station>
	When I click in the Select Customer account field
	Then The customers in PPP will be listed in hierarchy format <Station>,


Examples: 
| Scenario | Username    | Password | Station        |
| S1       | systemadmin | Te$t1234 | TestStation013 |

@Functional @GUI
Scenario Outline: 30284_Verify if the customers are listed in Alphabetical order when user clicks on Select Customer account field on the Product Protection page
	Given I am a system admin user <Username> and <Password>
	And I am on the Insurance All Risk Or Product Protection Settings page of Maintenance Tools
	And I am on the Product Protection tab,
	And I select station for Product Protection Page <Station>
	When I click in the Select Customer account field
	Then The PPP customers will be listed in alphabetical order <Station>

Examples: 
| Scenario | Username    | Password | Station |
| S1       | systemadmin | Te$t1234 | Bessie  |

@GUI
Scenario Outline: 30284_Verify the existence of search option in the Customers With Product Protection section
	Given I am a system admin user <Username> and <Password>
	And I am on the Insurance All Risk Or Product Protection Settings page of Maintenance Tools
	When  I am on the Product Protection tab,
	Then I will have a search option in the Customers With Product Protection section.

Examples: 
| Scenario | Username    | Password |
| S1       | systemadmin | Te$t1234 |

@Functional @GUI
Scenario Outline: 30284_Verify the search functionality in the Product Protection tab
	Given I am a system admin user <Username> and <Password>
	And I am on the Insurance All Risk Or Product Protection Settings page of Maintenance Tools
	And I am on the Product Protection tab,
	When I enter any value in the Search field in the Customers With Product Protection section <SearchVal>
	Then any records matching the search criteria will be displayed as I enter values in the search field <SearchVal>.

Examples: 
| Scenario | Username    | Password | SearchVal  |
| S1       | systemadmin | Te$t1234 | myCRMlogic |





