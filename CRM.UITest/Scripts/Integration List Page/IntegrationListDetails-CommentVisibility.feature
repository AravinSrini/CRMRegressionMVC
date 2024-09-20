@36758 @Sprint75
Feature: IntegrationListDetails-CommentVisibility
	
@GUI
Scenario Outline: 36758_Verify the CommentVisibility 'Public' only
	Given I am an operations,sales or station owner user <userName>, <password>
	When I am on Integration Request List Page with title
	And I click all requests
	And I expanded the Integration Request	
	Then I will be displayed withonly public integration notes for logged in user <claim>

Examples: 
| scenario | userName     | password | claim |
| s1       | crmoperation | Te$t1234 |       |
| s2       | stationown   | Te$t1234 |       |

@GUI
Scenario Outline: 36758_Verify the CommentVisibility 'Public or Private'
	Given I am system admin or sales management user <userName>, <password>
	When I am on Integration Request List Page with title
	And I click all requests
	And I expanded the Integration Request
	Then I will be displayed withpublic or private integration notes for logged in user <claim>

Examples: 
| scenario | userName     | password | claim                              |
| s1       | systemadmin  | Te$t1234 | IntegrationNotesCommentsVisibility |
| s2       | salesmanager | Te$t1234 | IntegrationNotesCommentsVisibility |
