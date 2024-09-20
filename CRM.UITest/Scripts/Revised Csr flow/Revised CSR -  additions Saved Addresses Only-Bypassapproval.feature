@37019 @Sprint75 @Regression
Feature: Revised CSR -  additions Saved Addresses Only-Bypassapproval

@Functional @Regression
Scenario Outline:Bypass approval for revised CSR flow by adding saved addresses template and modal for systemAdmin
	Given I LogIn to the application as SystemAdmin
	And I am on the customer profile page
	And I have Clicked on any customer <customer> from the customer profile page
	And I have navigated to saved items and addresses page of revised CSR flow
	And I Click Create a Saved Address button and Enter Address Details<Name>,<Address1>,<Address2>,<City>,<Country>,<State>,<Zip>
	#And I Click on browse for a file to Upload link in Address section and upload Address Template<AddressPath>
	And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
	And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
	And I should be displayed with added Addresses and uploaded address template in Review and Submit Page
	When I click on the Submit button on review and submit page
    Then CSR should be completed <customer>

Examples: 
| customer                  | Name | Address1 | Address2 | City  | Country       | State | Zip   | AddressPath                                                                  | PortalUsers_Text | ReviewAndSubmitText |
| BypassforaddressmodalAut| CSR  | TestAd1  | TestAd2  | Miami | United States | FL    | 33126 | ..\\..\\Scripts\\TestData\\SubmitCSR\\AddressTemplate\\Template_Address.xlsx | Portal Users     | Review and Submit   |
