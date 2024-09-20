@Sprint88 @73476
Feature: 73476_Quote_Insured Value_Terms And Conditions Modal_Should Not Close On Clicking Outside
	
Scenario Outline:73476_Verify that the Terms and Conditions pop up in Get Quote LTL page doesn't close on clicking anywhere outside the pop up
Given I am a DLS user and Login to application as a user with access to Quotes
And I am on Get Quote LTL page 
And I enter a value in Enter Insured Value field <Insured Value>
And I Click on Terms and Conditions link
When I Click anywhere outside the Terms and Conditions pop up
Then Terms and Conditions pop up should not close

Examples: 
| Insured Value |
| 1000          |  

Scenario Outline:73476_Verify that the Terms and Conditions pop up in Quote Results LTL page doesn't close on clicking anywhere outside the pop up
Given I am a DLS user and Login to application as a user with access to Quotes
And I am on Get Quote LTL page 
And I am on Quote Results LTL page
And I enter a value in Enter Insured Value field <Insured Value>
And I Click on Terms and Conditions link
When I click anywhere outside the Terms and Conditions Popup
Then Terms and Conditions pop up should not close

Examples: 
| Insured Value |
| 1000          |  



