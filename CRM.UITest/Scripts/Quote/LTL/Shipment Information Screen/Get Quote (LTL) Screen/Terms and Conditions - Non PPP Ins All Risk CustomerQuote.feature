@Sprint64 @24134
Feature: Terms and Conditions - Non PPP Ins All Risk CustomerQuote

@Regression 
Scenario Outline: Verify the Terms and Conditions link under Freight Description for Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
Then Terms and Conditions link should be displayed

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue |
| s1       | nat               | Te$t1234 | LTL     | 1000         |

@Regression 
Scenario Outline: Verify the Terms and Conditions modal when user clicks on it under Freight Description for Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
And I click on Terms and Conditions link
Then terms and conditions popup should be displayed

Examples: 
| Scenario | Username        | Password | Service | Insuredvalue |
| s1       | nat             | Te$t1234 | LTL     | 100          |

@Regression  
Scenario Outline: Verify the download DLSW Claim Form in Terms and Conditions modal for  Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
And I click on Terms and Conditions link
And Click on Download DLSW Claim Form displaying in Terms and Conditions modal
Then DLSW Claim Form is downloaded

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue |
| s1       | nat               | Te$t1234 | LTL     | 100          |

@Regression 
Scenario Outline: Verify the functionality of close button inside the terms and conditions popup
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
| Scenario | Username| Password | Service | Insuredvalue |
| s1       | nat     | Te$t1234 | LTL     | 100          |

@Regression  
Scenario Outline: Verify the Text inside the terms and conditions popup
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
And I click on Terms and Conditions link
Then terms and conditions popup should be displayed
And I should display with valid text in terms and conditions popup

Examples: 
| Scenario | Username| Password | Service | Insuredvalue |
| s1       | nat     | Te$t1234 | LTL     | 100          |


@Regression  
Scenario Outline: Verify the Terms and Conditions link for default customer on results page 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I click on view quote results button
And I clicks on the Terms and Conditions link
Then I should be displayed with the Terms and Conditions Modal


Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | 
| s1       | FREIGHT INFORMATION | Quote Confirmation        | nat                 | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |


@Regression 
Scenario Outline: Verify the Terms and Conditions link for default customer on results page_insuredvaluepassedinresultspage
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
Then I Enter valid data in <EnterInsuredValue> field
When I clicks on the Terms and Conditions link
Then I should be displayed with the Terms and Conditions Modal


Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | EnterInsuredValue |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | nat      | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | 100               |

@Regression  
Scenario Outline: Verify the Terms and Conditions link for default customer on results page_insuredvaluepassedincreateshipmentmodal
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
Then I Enter valid data in <EnterInsuredVal> field of insured modal pop up
And I click on Show Insured Rates button in the modal pop up
When I clicks on the Terms and Conditions link
Then I should be displayed with the Terms and Conditions Modal

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username              | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | EnterInsuredVal |
| s1       | FREIGHT INFORMATION | Quote Confirmation        | shipmodal@nonppp.com  | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          | 100             |

@Regression 
Scenario Outline: Verify the Terms and Conditions Popup for default customer on results page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I click on view quote results button
And I clicks on the Terms and Conditions link
Then I should be displayed with the Terms and Conditions Modal

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username    | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | 
| s1       | FREIGHT INFORMATION | Quote Confirmation        | nat         | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |

@Regression 
Scenario Outline: Verify the Text in Terms and Conditions Popup for default customer on results page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I click on view quote results button
And I clicks on the Terms and Conditions link
Then I should be displayed with the Terms and Conditions Modal
And I should display with valid text in terms and conditions popup on results page

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username    | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | 
| s1       | FREIGHT INFORMATION | Quote Confirmation        | nat         | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |

@Regression 
Scenario Outline: Verify the Terms and Conditions download functionality for default customer on results page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I click on view quote results button
And I clicks on the Terms and Conditions link
And Click on Download DLSW Claim Form displaying in Terms and Conditions modal results page 
Then DLSW Claim Form is downloaded

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username      | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | 
| s1       | FREIGHT INFORMATION | Quote Confirmation        | nat           | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |

@Regression 
Scenario Outline: Verify the functionality of close button inside the terms and conditions popup on results page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I enter data in <Insuredvalue> field 
And I click on view quote results button
And I clicks on the Terms and Conditions link
Then I click on the Close button Modal should close

Examples:
| Scenario | FreightInformation  | QuoteConfirmationpageText | Username   | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | WeightColumnText | ClassColumnText | InsuredValueColumnText | InsuredTypeColumnText | HazmatColumnText | 
| s1       | FREIGHT INFORMATION | Quote Confirmation        | nat        | Te$t1234 | LTL     | 90001         | 60606         | 50             | 120    | 100          | New              | WT               | CLASS           | VALUE                  | INSURED TYPE          | HAZMAT?          |

