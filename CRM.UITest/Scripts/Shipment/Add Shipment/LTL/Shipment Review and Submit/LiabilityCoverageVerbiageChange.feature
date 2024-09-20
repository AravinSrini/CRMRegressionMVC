@LiabilityCoverageVerbiage_ReviewandSubmitPage @29257 @Sprint70 
Feature: LiabilityCoverageVerbiageChange_ReviewandSubmitPage
	

@GUI 
Scenario Outline: Verify the Liability Coverage verbiage on the review and submit page for the standard rate
      Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  When I click on View rates button in add shipment ltl page
	  And I select any carrier which is associated with Carrier Rate Settings and click on create shipment button <Usertype>
	  Then verify the liability covergae verbiage for carrier which has a Cost per Pound (New) and Cost per Pound (Used) Insured Rate associated in Carrier Rate Settings
Examples:
| Scenario | Username   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc    |
| S1       | Myentryuser| Te$t1234 |          |                        | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Item Single |  
| S2       | stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 55             | 4563 | 6        | 1980   | Item double |

@GUI
Scenario Outline: Verify the Liability Coverage verbiage on the review and submit page for the Insured rate
      Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	  And I enter value in Insured Value <InsuredValue>
	  And I select the Insured Type from  <InsuredType> drop down
	  When I click on View rates button in add shipment ltl page
	  And I select any carrier which is associated with Carrier Rate Settings and click on create Insured shipment button <Usertype>
	  Then verify the liability covergae verbiage for carrier which has a Cost per Pound (New) and Cost per Pound (Used) Insured Rate associated in Carrier Rate Settings for Insured Rates
Examples:
| Scenario | Username  | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | InsuredValue | InsuredType |
| S1       |Myentryuser| Te$t1234 |          |                        | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 50             | 1234 | 5        | 1000   | Itemdesc | 100          | New         |
| S2       |stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 55             | 4563 | 6        | 1980   | Itemdesc | 123          | New         |