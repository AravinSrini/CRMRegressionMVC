@30014 @Regression @Sprint70
Feature: DomesticForwarding_SubmitRateRequest_Zipcodelookup
	
Scenario Outline: Verify the zipcode lookup auto populate functionality in the Origin section
Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
And I am on the Rate Request page for Domestic Forwarding
When I enter valid <Ozipcode> in the origin section
Then Origin Country <OCountry>, State <OState> and City <OCity> fields should be autopopulated

Examples: 
| Username         | Password | Ozipcode | OCountry      | OState | OCity |
| zzzcsa@stage.com | Te$t1234 | 33126    | United States | FL     |Miami  |

Scenario Outline: Verify the zipcode lookup auto populate functionality in the Destination section
Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
And I am on the Rate Request page for Domestic Forwarding
When I enter valid <Dzipcode> in the destination section
Then Destination Country <DCountry>, State <DState> and City <DCity> fields should be autopopulated

Examples: 
| Username         | Password | Dzipcode | DCountry      | DState  | DCity |
| zzzcsa@stage.com | Te$t1234 | 85282    | United States | AZ      |Tempe  |
