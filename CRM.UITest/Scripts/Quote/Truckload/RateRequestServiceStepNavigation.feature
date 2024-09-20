@Rate Request Service Step Navigation @17528 @Sprint59
Feature: Rate Request Service Step Navigation

@Regression 
Scenario Outline: Verify User Navigated to Shipment service page from Shipment Information page
Given I am a DLS user and login into application with valid <Username> and <Password>
And User click on the Quote module will be redirected to Quote list page and upon click on submit rate request button Will be Navigated to new Shipment service tile page
And User selects services '<Service>' type '<Type>' level '<Level>' will be Navigated to Shipment Information page '<ShipmentInformationPageText>'
When User Clicks on service bubble in the step wizard
Then User should be Navigated to new Shipment service tile page '<GetQuoteText>'

Examples: 
| Scenario |  	  Username									| Password   | Service   	 		|Type 			|  Level				|ShipmentInformationPageText| GetQuoteText		   |
| S1       |    testshipentry@gmail.com						| Te$t1234	 | International		|Air - Import	|  Air Consolidation	|Shipment Information		| Get Quote			   |
| S2       |    testshipentry@gmail.com						| Te$t1234	 | Truckload			|				|  			 			|Shipment Information		| Get Quote			   |	
| S3       |    testshipentry@gmail.com						| Te$t1234	 | Partial Truckload	|				|  						|Shipment Information		| Get Quote			   |
| S4       |    testshipentry@gmail.com						| Te$t1234	 | Intermodal			|				|  						|Shipment Information		| Get Quote			   |
| S5       |    testshpinquiryboth123@test.com				| Te$t1234	 | Truckload			|				|  			 			|Shipment Information		| Get Quote			   |	
| S6       |    testshpinquiryboth123@test.com				| Te$t1234	 | Partial Truckload	|				|  						|Shipment Information		| Get Quote			   |
| S7       |    testshpinquiryboth123@test.com				| Te$t1234	 | Intermodal			|				|  						|Shipment Information		| Get Quote			   |
| S8       |    testshpinquiryboth123@test.com				| Te$t1234	 | International		|Air - Import	|  Air Consolidation	|Shipment Information		| Get Quote			   |		

@Regression 
Scenario Outline: Verify User Navigated to ShpService page from ShpLocation and Dates page
Given I am a DLS user and login into application with valid <Username> and <Password>
And User click on the Quote module will be redirected to Quote list page and upon click on submit rate request button Will be Navigated to new Shipment service tile page
And User selects Domestic Forwarding service with type '<Type>' will be Navigated to Shipment Location and Dates page '<ShipmentLocationAndDatesPageText>'
When User Clicks on service Navigation bar
Then User should be Navigated to new Shipment service tile page '<GetQuoteText>'

Examples: 
| Scenario | Username						| Password | Type    | ShipmentLocationAndDatesPageText     | GetQuoteText		   |
| S1       | testshipentry@gmail.com        | Te$t1234 | Economy | Shipment Locations and Dates			| Get Quote			   |
| S2       | testshpinquiryboth123@test.com | Te$t1234 | Economy | Shipment Locations and Dates			| Get Quote			   |	
