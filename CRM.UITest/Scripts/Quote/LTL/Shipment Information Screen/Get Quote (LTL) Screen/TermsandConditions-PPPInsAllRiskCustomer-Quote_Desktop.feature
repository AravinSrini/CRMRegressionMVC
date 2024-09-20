@Sprint65 @TermsandConditions-PPPInsAllRiskCustomer-Quote @24138
Feature: TermsandConditions-PPPInsAllRiskCustomer-Quote_Desktop

@Regression 
Scenario Outline: Verify the Terms and Conditions link under Freight Description for Non Default customer
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter data in <Insuredvalue> field 
	Then Terms and Conditions link should be displayed

	Examples: 
	| Scenario | Username          | Password | Service | Insuredvalue |
	| s1       | awg@shipentry.com | Te$t1234 | LTL     | 1000         |

@Regression 
Scenario Outline: Verify the Terms and Conditions modal when user clicks on it under Freight Description for Non Default customer
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter data in <Insuredvalue> field 
	And I click on Terms and Conditions link
	Then terms and conditions popup should be displayed

	Examples: 
	| Scenario | Username          | Password | Service | Insuredvalue |
	| s1       | awg@shipentry.com | Te$t1234 | LTL     | 100          |

@Regression 
Scenario Outline: Verify the new verbiage in Terms and Conditions modal for Non Default customer
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter data in <Insuredvalue> field 
	And I click on Terms and Conditions link
	Then User should see the new '<verbiage>' in Terms and Conditions modal in Get Quote screen

	Examples: 
	| Scenario | Username          | Password | Service | Insuredvalue | verbiage                                                                                             |
	| s1       | awg@shipentry.com | Te$t1234 | LTL     | 100          | If proper exception is not made on the delivery receipt by the consignee, all risk coverage is void. |

@Regression 
Scenario Outline: Verify the functionality of close button inside the terms and conditions popup for Non Default customer
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter data in <Insuredvalue> field 
	And I click on Terms and Conditions link
	Then terms and conditions popup should be displayed
	And Close button should be displayed in modal
	And I click on close button 
	Then popup should be closed and user should remain in shipment information page

	Examples: 
	| Scenario | Username          | Password | Service | Insuredvalue |
	| s1       | awg@shipentry.com | Te$t1234 | LTL     | 100          |

@Regression  
Scenario Outline: Verify the Terms and Conditions link for Non default customer on results page 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data in Shipping From Section <SFZiporpostal>
	And I enter valid data in Shipping To Section <STZiporPostal>
	And I enter valid data in Freight Description Section <classification>, <weight>
	And I have not entered data in '<Insuredvalue>' field of Freight Description section
	And I have not selected any of the type from '<InsuredvalueType>' dropdown
	And I click on view quote results button
	Then I should be displayed with the Terms and Conditions link in the LTL Results page


	Examples:
	| Scenario | Username         | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType |
	| s1       | test01@entry.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              |


@Regression 
Scenario Outline: Verify the Terms and Conditions Popup for Non default customer on results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data in Shipping From Section <SFZiporpostal>
	And I enter valid data in Shipping To Section <STZiporPostal>
	And I enter valid data in Freight Description Section <classification>, <weight>
	And I have not entered data in '<Insuredvalue>' field of Freight Description section
	And I have not selected any of the type from '<InsuredvalueType>' dropdown
	And I click on view quote results button
	And I clicks on the Terms and Conditions link in results page
	Then I should be displayed with the Terms and Conditions Modal

	Examples:
	| Scenario | Username         | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType |
	| s1       | test01@entry.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              |


@Regression 
Scenario Outline: Verify the the new verbiage Terms and Conditions for Non default customer on results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data in Shipping From Section <SFZiporpostal>
	And I enter valid data in Shipping To Section <STZiporPostal>
	And I enter valid data in Freight Description Section <classification>, <weight>
	And I have not entered data in '<Insuredvalue>' field of Freight Description section
	And I have not selected any of the type from '<InsuredvalueType>' dropdown
	And I click on view quote results button
	And I clicks on the Terms and Conditions link in results page
	Then User should see the new '<verbiage>' in Terms and Conditions modal in Quote Results screen

	Examples:
	| Scenario | Username         | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | verbiage                                                                                             |
	| s1       | test01@entry.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | If proper exception is not made on the delivery receipt by the consignee, all risk coverage is void. |

@Regression 
Scenario Outline: Verify the functionality of close button inside the terms and conditions popup on results page for Non default customer
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data in Shipping From Section <SFZiporpostal>
	And I enter valid data in Shipping To Section <STZiporPostal>
	And I enter valid data in Freight Description Section <classification>, <weight>
	And I have not entered data in '<Insuredvalue>' field of Freight Description section
	And I have not selected any of the type from '<InsuredvalueType>' dropdown
	And I click on view quote results button
	And I clicks on the Terms and Conditions link in results page
	Then I click on the Close button Modal should close

	Examples:
	| Scenario | Username         | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType |
	| s1       | test01@entry.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              |


