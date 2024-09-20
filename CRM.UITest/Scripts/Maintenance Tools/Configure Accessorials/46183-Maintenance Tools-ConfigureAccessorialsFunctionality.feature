@Sprint85 @46183
Feature: 46183-Maintenance Tools-ConfigureAccessorialsFunctionality
	
@GUI
Scenario:46183-Verify the Configure Accessorials button and verbiage next to the Configure Accessorial button on Maintenance Tools page
Given that I am a Config Manager user
When I am on the Maintenance Tools page
Then I will see Configure Accessorials button
And the verbiage <Add, edit or remove accessorials> is displayed next to the Configure Accessorial button



@GUI
Scenario:46183-Verify Configure Accessorials page UI Elements
Given that I am a Config Manager user
And I am on the Maintenance Tools page
When I click on the Configure Accessorials Button
Then I will arrive on the Configure Accessorials page 
And The list of current accessorials will include the following columns: Name,Service Code,MG Description(s),Service Type(s),Direction
And the default display will be based on the Name column (alphabetically)
#And following columns will have a sort option: Name,Service Code,Direction
And I will see an Edit button associated with each displayed accessorial
And I will see a Delete button associated with each displayed accessorial
And I will see an Add Accessorial Button
And I will see a Back to Maintenance Tools Button
And I will see a Filter accessorials... field
And I will see grid display options


@Functional
Scenario:46183-Verify the list of accessorial within Configure Accessorials grid
Given that I am a Config Manager user
And I am on the Maintenance Tools page
When I click on the Configure Accessorials Button
Then I will arrive on the Configure Accessorials page
And I will see a list of current accessorials


@GUI @Functional
Scenario:46183-Verify the message displayed in Configure Accessorials grid if no accessorials to display
Given that I am a Config Manager user
And I am on the Maintenance Tools page
And I clicked On the Configure Accessorials Button
And I am on the Configure Accessorials page
When there are no accessorials to display
Then I will see the  <No accessorials to display.> message displayed in the Configure Accessorials grid


@GUI 
Scenario:46183-Verify the Configure Accessorials grid options - UI Elements
Given that I am a Config Manager user
And I am on the Maintenance Tools page
And I clicked On the Configure Accessorials Button
When I arrive on the Configure Accessorials page
Then the accessorial grid display will default to 10
And I have option to change the grid display the options are: 10,20,60,100,All
And I have the option to advance to the next page
And I have the option to return to a Previous page
And the grid options are displayed at the top and bottom of the grid



@Functional
Scenario Outline:46183-Verify the Configure Accessorials grid options
Given that I am a Config Manager user
And I am on the Maintenance Tools page
And I clicked On the Configure Accessorials Button
When I arrive on the Configure Accessorials page
Then I have the option to change the grid display <ViewOption>

Examples: 
| ViewOption |
| 10         |
| 20         |
| 60         |
| 100        |
| ALL        |


@Functional
Scenario Outline:46183-Verify sorting functionality to sort the Configure Accessorials grid results
Given that I am a Config Manager user
And I am on the Maintenance Tools page
And I clicked On the Configure Accessorials Button
And I am on the Configure Accessorials page
When I click on the sort arrow of any column <SortableColumn>
Then the grid will be sorted numerically lowest to highest or alphabetically A to Z
And clicking on the same column a second time will sort the grid numerically highest to lowest or alphabetically Z to A
Examples: 
| SortableColumn |
| Name           |
| Service Code   |
| Direction      |

@Functional
Scenario: 46183-Verify the search functionality to filter the Configure Accessorials grid results
Given that I am a Config Manager user
And I am on the Maintenance Tools page
And I clicked On the Configure Accessorials Button
And I am on the Configure Accessorials page
When I click in the <Filter accessorials...> field
Then I have the option to type in any value
And grid will show rows that contain the values 
And entered text will be highlighted

@Functional
Scenario:46183-Verify the functionality of Back to Maintenance Tools button
Given that I am a Config Manager user
And I am on the Maintenance Tools page
And I clicked On the Configure Accessorials Button
And I am on the Configure Accessorials page
When I click on the Back to Maintenance Tools Button
Then I will arrive on the Maintenance Tools page












 