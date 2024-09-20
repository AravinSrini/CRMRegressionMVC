@34387 @Sprint75
Feature: Carrier Results - Terms And Condition Disclaimer
	

@GUI @Funtional
Scenario Outline: 34387_Verify Terms And Condition Disclaimer and hyperlink
Given I am a DLS user and login into application with valid <Username> and <Password>
And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
When I click on View rates button in add shipment ltl page
Then I will be presented with a Disclaimer noting that "By creating an Insured Shipment you agree to the Terms & Conditions.
And the verbiage Terms & Conditions should be hyperlinked

Examples:
| Scenario | Username   | Password | Usertype     | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | classification | nmfc | quantity | weight | itemdesc    |
| S1       | shp.entry  | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | test       | address     | 33126         | Dname           | Desaddress       | 85282              | 50             | 1234 | 1        | 1      | 100         |
@GUI @Funtional 
Scenario Outline: 34387_Verify the Terms and Condition modal
Given I am a DLS user and login into application with valid <Username> and <Password>
And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
When I click on View rates button in add shipment ltl page
And I click on the 'Terms & Conditions' hyperlink
Then I will be presented with the T&C modal <ExpectedText>

Examples:
| Scenario | Username  | Password | Usertype     | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | classification | nmfc | quantity | weight | itemdesc | ExpectedText                     |
| S1       | shp.entry | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | test       | address     | 33126         | Dname           | Desaddress       | 85282              | 50             | 1234 | 1        | 1      | 100      | Terms And Conditions Of Coverage |

@GUI @Funtional
Scenario Outline: 34387_Verify the Terms and Condition modal from quote results page
Given I am a DLS user and login into application with valid <Username> and <Password>
When I am on Rate Resultspage <userType>, <customerName>, <oZip>, <dZip>, <classification> and <weight>
And  I click on the 'Terms & Conditions' hyperlink from quote result page
Then I will be presented with the T&C modal from quote result page

Examples:
| Scenario | Username                 | Password | Account                  | userType | customerName             | oZip  | dZip  | classification | weight | 
| S1       | crmOperation             | Te$t1234 | ZZZ - GS Customer Test   | Internal | ZZZ - GS Customer Test   | 33126 | 85282 | 50             | 200    | 


