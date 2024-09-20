@51434
Feature: EditShipment_AccessorialGainshareType_CRMRatingLogic
	
Scenario: 51434 Verify that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer of the Shipment has a Set Individual Accessorial 
Given I am a sales, sales management, operations, or station owner user
And I am Editing an LTL shipment
And the customer of the shipment being edited has a Set Individual Accessorial
And the CRM Rating Logic = Yes for the customer of the shipment being edited
And the Accessorial Gainshare Type is "% over cost"
When CRM receives a rate request response from MG that includes the Set Individual Accessorial
Then CRM will calculate the accessorial-cost using the formula "CRM accessorial cost = MG accessorial cost + (MG accessorial cost * <% over cost>(%))"

Scenario: 51434 Verify that the CRM will apply accessorial cost as per flat over cost calculation when the gain share type is flat over cost and customer of the Shipment has a Set Individual Accessorial
Given I am a sales, sales management, operations, or station owner user
And I am Editing an LTL shipment
And the customer of the shipment being edited has a Set Individual Accessorial
And the CRM Rating Logic = Yes for the customer of the shipment being edited
And the Accessorial Gainshare Type is "Flat over cost"
When CRM receives a rate request response from MG that includes the Set Individual Accessorial
Then CRM will calculate the accessorial-cost using the formula "CRM accessorial cost = MG accessorial cost + flat over cost"

Scenario: 51434 Verify that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer of the Shipment has a Set Individual Accessorial
Given I am a sales, sales management, operations, or station owner user
And I am Editing an LTL shipment
And the customer of the shipment being edited has a Set Individual Accessorial
And the CRM Rating Logic = Yes for the customer of the shipment being edited
And the Accessorial Gainshare Type is "Set flat amount"
When CRM receives a rate request response from MG that includes the Set Individual Accessorial
Then CRM will apply the "Set flat amount" as the accessorial cost

Scenario: 51434 Verify that the CRM will apply accessorial cost as per % over cost calculation when the gain share type is % over cost and customer of the Shipment has carrier-specific set individual accessorial
Given I am a sales, sales management, operations, or station owner user
And I am Editing an LTL shipment
And the customer of the shipment being edited has a Carrier-Specific Set Individual Accessorial,
And the CRM Rating Logic = Yes for the customer of the shipment being edited
And the Accessorial Gainshare Type is "% over cost"
When CRM receives a rate request response from MG for the carrier with specific pricing that includes the Set Individual Accessorial
Then CRM will calculate the accessorial-cost using the formula "CRM accessorial cost = MG accessorial cost + (MG accessorial cost * <% over cost>(%))"

Scenario: 51434 Verify that the CRM will apply accessorial cost as per Flat over cost calculation when the gain share type is Flat over cost and customer of the Shipment has carrier-specific set individual accessorial 
Given I am a sales, sales management, operations, or station owner user
And I am Editing an LTL shipment
And the customer of the shipment being edited has a Carrier-Specific Set Individual Accessorial,
And the CRM Rating Logic = Yes for the customer of the shipment being edited
And the Accessorial Gainshare Type is "Flat over cost"
When CRM receives a rate request response from MG for the carrier with specific pricing that includes the Set Individual Accessorial
Then CRM will calculate the accessorial-cost using the formula "CRM accessorial cost = MG accessorial cost + flat over cost"

Scenario: 51434 Verify that the CRM will apply accessorial cost as Set flat amount when the gain share type is Set flat amount and customer of the Shipment has carrier-specific set individual accessorial
Given I am a sales, sales management, operations, or station owner user
And I am Editing an LTL shipment
And the customer of the shipment being edited has a Carrier-Specific Set Individual Accessorial,
And the CRM Rating Logic = Yes for the customer of the shipment being edited
And the Accessorial Gainshare Type is "Set flat amount"
When CRM receives a rate request response from MG for the carrier with specific pricing that includes the Set Individual Accessorial
Then CRM will apply the "Set flat amount" as the accessorial cost