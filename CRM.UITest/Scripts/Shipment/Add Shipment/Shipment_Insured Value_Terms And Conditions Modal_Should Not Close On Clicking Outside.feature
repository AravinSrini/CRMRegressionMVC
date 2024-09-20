@Sprint88 @73476
Feature: Shipment_Insured Value_Terms And Conditions Modal_Should Not Close On Clicking Outside


Scenario Outline:73476_Verify that the Terms and Conditions pop up in Add Shipment LTL page doesn't close on clicking anywhere outside the pop up
Given I am a DLS user and Login to application as a user with access to Shipments
And I Am on Add Shipment LTL page
And I Enter a value in Enter Insured Value field <Insured Value>
And I Click on Terms and Conditions link
When I Click anywhere outside the Terms and Conditions pop up
Then Terms and Conditions pop up should not close

Examples: 
| Insured Value |
| 1000          |  

Scenario Outline:73476_Verify that the Terms and Conditions pop up in Shipment Results LTL page doesn't close on clicking anywhere outside the pop up
Given I am a DLS user and Login to application as a user with access to Shipments
And I Am on Add Shipment LTL page
And I am on Shipment Results LTL page
And I enter a value in Enter Insured Value field <Insured Value>
And I Click on Terms and Conditions link
When I Click anywhere outside the Terms and Conditions pop up
Then Terms and Conditions pop up should not close

Examples: 
| Insured Value |
| 1000          |  

