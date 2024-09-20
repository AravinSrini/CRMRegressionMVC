@Regression @Quote @50047 @Sprint86
Feature: MobileDevice_QuoteList_StationUsers
	
Scenario Outline: Verify Navigation to Quote List page under Mobile Testing
Given that I am a sales, sales management, operations, or station owner user<Usertype>
And I am on a mobile device<WindowWidth> and <WindowHeight>
And I logged into CRM
When I click on the Quote navigation pane
Then I will navigate to the Quote List page
Examples: 
| Usertype     | WindowWidth | WindowHeight |
| Internaluser | 320         | 568          |
| Sales        | 320         | 568          |

