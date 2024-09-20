@30609 @Sprint72 
Feature: Carrier Website Logins Edit_Password

@GUI @Fixed
Scenario Outline: 30609-Verify the functionality of edit password text field on Carrier Website Logins Edit Password page
	Given I am a System Admin or Pricing Configuration user
	And I am on the Carrier Website Logins Edit Password page
	When I click inside the text field
	Then I will be able to type my new Password value - <NPassoword>

Examples: 
| NPassoword      |
| SysAdmin@123    |

@GUI @Fixed
Scenario Outline: 30609-Verify the functionality of Cancel button on Carrier Website Logins Edit Password page
	Given I am a System Admin or Pricing Configuration user
	And I am on the Carrier Website Logins Edit Password page
	When I select the option to Cancel
	Then I will return to the Carrier Website Logins page - <CarrierPageTitle>

Examples: 
| CarrierPageTitle             |
| Admin Carrier Website Logins |

@GUI @Fixed
Scenario Outline: 30609-Verify the functionality of Save button on Carrier Website Logins Edit Password page
	Given I am a System Admin or Pricing Configuration user
	And I am on the Carrier Website Logins Edit Password page
	And I have entered my new Password value into the input field - <NPassword>
	When I select the option to Save
	Then my new Password value will be saved - <NPassword>
	And I will return to the Carrier Website Logins page - <CarrierPageTitle>

Examples: 
| NPassword       | CarrierPageTitle             |
| SysAdmin@123    | Admin Carrier Website Logins |

@GUI @Fixed
Scenario: 30609-Verify the functionality of Save button when Password field is empty
	Given I am a System Admin or Pricing Configuration user
	And I am on the Carrier Website Logins Edit Password page
	And my new Password value is empty
	When I select the option to Save
	Then I will see an error message displaying - Password Field is Required.
	And The field will be highlighted in red