@46203 @NinjaSprint22
Feature: AccessRRDUser - Search Option For Customer Invoices

@Acceptance @GUI
Scenario: 46203_Verify the search drop down, text box, radio buttons, Station ,Accounts and Search Invoices button on the Customer Invoice page
	Given I am an Access RRD User
	When I arrive on the Customer Invoice page
	Then I will have search drop down selections
	And the search options for the drop down selection available are:
	| options                     |
	| Select a field to search... |
	| Invoice Number              |
	| Customer Number             |
	| Customer Name               |
	| DAGRT                       |
	And I will see a text box field next to the search options
	And there will be a radio button for open
	And there will be a radio button for close
	And the station field is NOT required
	And the accounts field is NOT required
	And I will see a search invoices button in the access rrd search area


 @Functional @GUI
Scenario Outline: 46203_When chosing an option from the "Select a field to search" dropdown and entering 3 or more characters the search invoice button will be active 
	Given I am an Access RRD User
	When I arrive on the Customer Invoice page
	And I have selected an <Option> from the drop down list
	And I enter data in the field <Search Text>
	Then the Search Invoices button will be <Enabled or Disabled>
	Examples: 
	| Option                      | Search Text        | Enabled or Disabled |
	| Select a field to search... | ab                 | Disabled            |
	| Select a field to search... | abc                | Disabled            |
	| Select a field to search... | Example text input | Disabled            |
	| Invoice Number              | ab                 | Disabled            |
	| Invoice Number              | abc                | Enabled             |
	| Invoice Number              | Example text input | Enabled             |
	| Customer Number             | ab                 | Disabled            |
	| Customer Number             | abc                | Enabled             |
	| Customer Number             | Example text input | Enabled             |
	| Customer Name               | ab                 | Disabled            |
	| Customer Name               | abc                | Enabled             |
	| Customer Name               | Example text input | Enabled             |
	| DAGRT                       | ab                 | Disabled            |
	| DAGRT                       | abc                | Enabled             |
	| DAGRT                       | Example text input | Enabled             |

@Acceptance @Functional @GUI
Scenario Outline: 46203_Given an option is selected from the drop down list and data is entered in the search input text and the search button is clicked then results will show in the grid
	Given I am an Access RRD User
	And I am on the Customer Invoices Page
	And I have selected an <Option> from the drop down list
	And I choose the <open or closed> radio button
	And I enter data in the field <Search Text>
	When I click on the button search invoices
	Then CRM will search for invoices that contains the values entered <Option> <Search Text> <open or closed>
	Examples: 
	| Option         | Search Text      | open or closed |
	| Invoice Number | 0637749108       | o              |
    | Customer Number | 13345           | o              |
	| Customer Name   | Auto            | o              |
	| DAGRT           | 82222           | o              |
	| Invoice Number  | 0101010101      | c              |
	| Customer Number | 000000011100222 | c              |
	| Customer Name   | AutoCheck11     | c              |
	| DAGRT           | 82222           | c              |