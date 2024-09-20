@60031 @Sprint94
Feature: Terminal Information - LTL Shipment Details
	

Scenario Outline: 60031 Verify the Option to Display Terminal Information in Shipment Details page
Given I'm a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user<UserType>,<UserName>,<Password>
When I am on the Shipment Details page of an LTL shipment<UserType>,<Customername>
Then I will have an option to display Terminal Information
Examples: 
| UserType | UserName								 | Password								 | Customername						  |
| Sales    |  username-CurrentSprintSales		     | password-CurrentSprintSales	         | ZZZ - GS Customer Test             |
| Internal |  username-CurrentSprintOperations       | password-CurrentSprintOperations      |  ZZZ - GS Customer Test            |
| External |  username-CurrentSprintshpentry		 | password-CurrentSprintshpentry        |  ZZZ - GS Customer Test            |


Scenario Outline: 60031 Verify the Loading Icon and Terminal Information fields in Shipment Details page

Given I'm a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user<UserType>,<UserName>,<Password>
And I am on the shipment Details page of an LTL shipment<UserType>,<Customername>
When I click on the option to display terminal Information
Then I should see page level loading icon
And a popup modal is launched to display the terminal information for selected record
And the page level loading icon will be closed
And the modal will display the Original Terminal Fields as "Name", "Address1", "Address2", "City", "State", "Zip", "Country", "Contact Name", "Phone", "Email"
And the modal will display the Destination Terminal Fields as "Name", "Address1", "Address2", "City", "State", "Zip", "Country", "Contact Name", "Phone", "Email"
And I will see <Close> button
Examples: 
| UserType | UserName								 | Password								 | Customername						  |
| Sales    |  username-CurrentSprintSales		     | password-CurrentSprintSales	         | ZZZ - GS Customer Test             |
| Internal |  username-CurrentSprintOperations       | password-CurrentSprintOperations      |  ZZZ - GS Customer Test            |
| External |  username-CurrentSprintshpentry		 | password-CurrentSprintshpentry        |  ZZZ - GS Customer Test            |

Scenario Outline: 60031 Verify the Terminal Information Modal closes when i click on the Close button from the Terminal Information Modal in Shipment Details page
Given I'm a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user<UserType>,<UserName>,<Password>
And I am on the shipment Details page of an LTL shipment<UserType>,<Customername>
And I clicked on the Terminal Info Link
And I am in Terminal Information modal
When I click Close button
Then the Terminal Information modal will close
Examples: 
| UserType | UserName								 | Password								 | Customername						  |
| Sales    |  username-CurrentSprintSales		     | password-CurrentSprintSales	         | ZZZ - GS Customer Test             |
| Internal |  username-CurrentSprintOperations       | password-CurrentSprintOperations      |  ZZZ - GS Customer Test            |
| External |  username-CurrentSprintshpentry		 | password-CurrentSprintshpentry        |  ZZZ - GS Customer Test            |