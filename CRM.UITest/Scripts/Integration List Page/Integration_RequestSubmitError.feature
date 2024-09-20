@34505 @sprint75
Feature: Integration_RequestSubmitError

@Functional
Scenario Outline: 34505_Verify incomplete fields while subbmitting request
	Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
	When I am on Integration Request page
	And I have not completed all required fields <ComapanyName>,<CompanyContactName>,<CompanyContactPhone>,<CompanyContactEmail>,<DevContactName>,<DevContactPhone>,<DevContactEmail>
	When I click on the Submit button from submit interation request page
	Then the request is not submitted 
	And the incomplete field(s) will be highlighted in red
	And the focus will be on the first incomplete field 

	Examples: 
| Scenario | Username    | Password | ComapanyName | CompanyContactName | CompanyContactPhone  | CompanyContactEmail | DevContactName | DevContactPhone      | DevContactEmail | 
| s1       | systemadmin | Te$t1234 | sdd          | Peter              | 90909012909012000090 | sdd@test.com        | Jhon           | 90909012909012000090 | test1@test.com  | 


