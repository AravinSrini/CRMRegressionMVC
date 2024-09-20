@32308 @Sprint79
Feature:Saved Quote to Shipment - Multiple Rates Returned (MVC5 ShipEntry User)

@Functional 

Scenario: 32308_Test to verify the Rates Returned (MVC5 ShipEntry User)_Saved Quote to Shipment
Given I am a shp.entry user
When I am on shipment results page of saved quote to shipment process
Then I should be displayed with the only one carrier which i saved in quote process


@Functional 
Scenario: 32308_Test to verify Show Insured Rates functionality_Saved standard Quote to Shipment
Given I am a shp.entry user
And I am on shipment results page of saved standard quote to shipment process
And I Enter an insured Value
When I click on the Show Insured Rate Button
Then insured rate for selected carrier should be displayed


@Functional
Scenario: 32308_Test to verify Show Insured Rates functionality_Saved insured Quote to Shipment
Given I am a shp.entry user
When I am on shipment results page of saved insured quote to shipment process
Then insured Value textbox will be non-editable
And Show Insured Rate Button will be non-clickable

