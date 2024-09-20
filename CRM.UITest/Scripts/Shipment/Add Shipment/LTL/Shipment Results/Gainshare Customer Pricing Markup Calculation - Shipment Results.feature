@Sprint72 @33799 @Ignore
Feature: Gainshare Customer Pricing Markup Calculation - Shipment Results
	
@Functional
Scenario Outline: Verify Customer charges for Shipment Request are calculated based on new rating calculation
Given I am a DLS user belongs to Gainshare Customer and login into application with valid <Username> and <Password>
When I am on the Shipment results page<CustomerName><UserType><pickUpCityName><pickUpZipCode><pickUpStateCode><pickUpCountry><dropUpCityName><dropUpZipCode><dropUpStateCode><dropUpCountry><OAccessorial><DAccessorial><freightClass><quantity><quantityUnit><weight><weightUnit><oName><oAdd1><dName><dAdd1><nmfc><desc>
Then the Customer charges will be calculated based on Bump and Surge and verified in the Shipment results page<CustomerName><UserType><CalculationType>


Examples:
|CustomerName|UserType|pickUpCityName|pickUpZipCode|pickUpStateCode|pickUpCountry|dropUpCityName|dropUpZipCode|dropUpStateCode|dropUpCountry|OAccessorial|DAccessorial|freightClass|quantity|quantityUnit|weight|weightUnit|oName|oAdd1|dName|dAdd1|nmfc|desc|CalculationType|