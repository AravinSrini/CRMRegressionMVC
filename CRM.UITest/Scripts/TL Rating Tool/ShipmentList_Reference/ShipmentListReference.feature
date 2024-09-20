Feature:

 
@mytag
Scenario Outline: Verify reference number search
Given I am a user and login into application with valid <Username> and <Password> 
And I am landed on the Shipment List page 
And I entered the '<Ref>' in Reference Number lookup field
When I clicked on search arrow of Reference Number lookup
Then I should be displayed with results for the entered valid reference numbers '<Ref>'

Examples: 
| Scenario | Username     | Password | Ref          |
| s1       | zzzext       | Te$t1234 | ZZX002010090 |


