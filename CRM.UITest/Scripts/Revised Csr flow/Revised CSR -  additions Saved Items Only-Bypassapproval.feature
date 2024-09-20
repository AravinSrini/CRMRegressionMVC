@36313 @Sprint75 @Regression
Feature: Revised CSR -  additions Saved Items Only-Bypassapproval

@Functional @Regression
Scenario Outline:36313-Bypass approval for revised CSR flow by adding saved items template and modalfor systemadmin
	Given I LogIn to the application as SystemAdmin
	And I am on the customer profile page
	And I have Clicked on any customer <customer> from the customer profile page
	And I have navigated to saved items and addresses page of revised CSR flow	
	And I Click on Create a Saved Item button and Enter Item Details<Classification>,<NMFC>,<ItemDescription>,<HazardousMaterials>
	#And I Click on browse for a file to Upload link in Item section and upload Item Template<ItemPath>
	And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
	And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
	When I click on the Submit button on review and submit page
	Then Revised CSR should be completed <customer>
	
Examples: 
| customer        | Classification | NMFC | ItemDescription | HazardousMaterials | ItemPath                                                              |
|testingbypass232 |          50    | 1823 |  Test75         |  No                |..\\..\\Scripts\\TestData\\SubmitCSR\\ItemTemplate\\Template_Item.xlsx |

@Functional @Regression
Scenario Outline:36313-Bypass approval for revised CSR flow by adding saved items and addresses both template and modal for sysadmin
	Given I LogIn to the application as SystemAdmin
	And I am on the customer profile page
	And I have Clicked on any customer <customer> from the customer profile page
	And I have navigated to saved items and addresses page of revised CSR flow	
	And I Click on Create a Saved Item button and Enter Item Details<Classification>,<NMFC>,<ItemDescription>,<HazardousMaterials>
	#And I Click on browse for a file to Upload link in Item section and upload Item Template<ItemPath>
	And I Click Create a Saved Address button and Enter Address Details<Name>,<Address1>,<Address2>,<City>,<Country>,<State>,<Zip>
	#And I Click on browse for a file to Upload link in Address section and upload Address Template<AddressPath>
	And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
	And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
	When I click on the Submit button on review and submit page
	Then Revised CSR should be completed <customer>
	
Examples: 
| customer        | Classification | NMFC | ItemDescription | HazardousMaterials | ItemPath                                                               | Name     | Address1 | City     | Country       | State | Zip   | AddressPath                                                                    |
| testingbypass232| 50             | 1823 | Test75          | No                 | ..\\..\\Scripts\\TestData\\SubmitCSR\\ItemTemplate\\Template_Item.xlsx | Sprint75 | Sprint75 | Sprint75 | United States | CA    | 90001 |..\\..\\Scripts\\TestData\\SubmitCSR\\AddressTemplate\\Template_Address.xlsx    |

