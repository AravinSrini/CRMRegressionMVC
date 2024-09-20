@23036 @LTLQuoteresultspage @Sprint65
Feature: Revamp LTL Rate Request - Rate Results Page - Insured Value Type

@Regression
Scenario Outline:Verifcation of insured rate type on rate results sceen when user selects 'new' in get quote_nonguaranteed
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I enter data in <Insuredvalue> field 
   And I Select New insured type from '<InsuredvalueType>' dropdown
   And I Click On view quote results button
   Then I should be display with the rates for new type only for all carriers on results page 
 
Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | nat                 | Te$t1234 | LTL     | 90001         | 90001         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user selects 'Used' in get quote_nonguaranteed
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I enter data in <Insuredvalue> field 
   And I Select Used insured type from '<InsuredvalueType>' dropdown
   And I Click On view quote results button
   Then I should be display with the rates for used type only for all carriers on results page 

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | nat                 | Te$t1234 | LTL     | 90001         | 90001         | 50             | 150    | 100          | Used              | Quote Confirmation        | FREIGHT INFORMATION | New         |


@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user not enters the insured value_nonguaranteed
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And I clicked on <Service> button on the select type screen of rate request process
    When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Shipping From Section <SFZiporpostal>
    And I enter valid data in Shipping To Section <STZiporPostal>
    And I enter valid data in Freight Description Section <classification>, <weight>
    And I Click On view quote results button
    Then I should be display with the rates for new and  used types for all carriers on  results page 

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | nat                 | Te$t1234 | LTL     | 90001         | 90001         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline:Verifcation of insured rate type on rate results sceen when user selects 'new' in get quote_guaranteed
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I enter data in <Insuredvalue> field 
   And I Select New insured type from '<InsuredvalueType>' dropdown
   And I Click On view quote results button
   Then I should be display with the rates for new type only for all carriers on guaranteed grid results page 
 
Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | nat                 | Te$t1234 | LTL     | 90001         | 90001         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user selects 'Used' in get quote_guaranteed
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I enter data in <Insuredvalue> field 
   And I Select Used insured type from '<InsuredvalueType>' dropdown
   And I Click On view quote results button
    Then I should be display with the rates for used type only for all carriers on guaranteed grid results page 

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType  | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | nat                 | Te$t1234 | LTL     | 90001         | 90001         | 50             | 150    | 100          | Used              | Quote Confirmation        | FREIGHT INFORMATION | New         |


@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user not enters the insured value_guaranteed
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And I clicked on <Service> button on the select type screen of rate request process
    When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Shipping From Section <SFZiporpostal>
    And I enter valid data in Shipping To Section <STZiporPostal>
    And I enter valid data in Freight Description Section <classification>, <weight>
    And I Click On view quote results button
    Then I should be display with the rates for new and  used types for all carriers on guaranteed grid results page 

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | nat                 | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |

@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user renters the insured value on results page_new
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And I clicked on <Service> button on the select type screen of rate request process
    When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Shipping From Section <SFZiporpostal>
    And I enter valid data in Shipping To Section <STZiporPostal>
    And I enter valid data in Freight Description Section <classification>, <weight>
	And I enter data in <Insuredvalue> field 
    And I Select Used insured type from '<InsuredvalueType>' dropdown
    And I Click On view quote results button
    Then I should be display with the rates for used type only for all carriers on results page 
	And I Enter valid data in <EnterInsuredValue> field
    And I must be displayed with <InsuredType> dropdown
    And I click on Show Insured Rate button 
	And I should be display with the rates for new type only for all carriers on results page 
	And I should be display with the rates for new type only for all carriers on guaranteed grid results page 
Examples: 
| scenario | Username | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType | EnterInsuredValue |
| s1       | nat      | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100          |Used              | Quote Confirmation        | FREIGHT INFORMATION | New         | 1000              |


@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user renters the insured value on results page_used
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And I clicked on <Service> button on the select type screen of rate request process
    When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Shipping From Section <SFZiporpostal>
    And I enter valid data in Shipping To Section <STZiporPostal>
    And I enter valid data in Freight Description Section <classification>, <weight>
	And I enter data in <Insuredvalue> field 
    And I Select New insured type from '<InsuredvalueType>' dropdown
    And I Click On view quote results button
    Then I should be display with the rates for new type only for all carriers on results page  
	And I Enter valid data in <EnterInsuredValue> field
    And I must be displayed with <InsuredType> dropdown
    And I click on Show Insured Rate button 
	And I should be display with the rates for used type only for all carriers on results page 
	And I should be display with the rates for used type only for all carriers on guaranteed grid results page 
Examples: 
| scenario | Username | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType | EnterInsuredValue |
| s1       | nat      | Te$t1234 | LTL     | 90001         | 90001         | 50             | 150    | 100          | New             | Quote Confirmation         | FREIGHT INFORMATION | Used         | 1000              |

@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user enters the insured value on results page only_new
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And I clicked on <Service> button on the select type screen of rate request process
    When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Shipping From Section <SFZiporpostal>
    And I enter valid data in Shipping To Section <STZiporPostal>
    And I enter valid data in Freight Description Section <classification>, <weight>
    And I Click On view quote results button
   	Then I Enter valid data in <EnterInsuredValue> field
     And I click on Show Insured Rate button
    And I should be display with the rates for new type only for all carriers on results page 
	And I should be display with the rates for new type only for all carriers on guaranteed grid results page 
Examples: 
| scenario | Username    | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | EnterInsuredValue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | nat         | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 100               | New              | Quote Confirmation        | FREIGHT INFORMATION | New         |


@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user enters the insured value on results page only_used
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And I clicked on <Service> button on the select type screen of rate request process
    When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Shipping From Section <SFZiporpostal>
    And I enter valid data in Shipping To Section <STZiporPostal>
    And I enter valid data in Freight Description Section <classification>, <weight>
    And I Click On view quote results button
	Then I Enter valid data in <EnterInsuredValue> field
	And I selected '<InsuredType>' on Rate Results Page
    And I click on Show Insured Rate button
	And I should be display with the rates for used type only for all carriers on results page 
	And I should be display with the rates for used type only for all carriers on guaranteed grid results page 
Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | EnterInsuredValue | InsuredvalueType | QuoteConfirmationpageText | FreightInformation  | InsuredType | 
| s1       | nat                 | Te$t1234 | LTL     | 90001         | 90001         | 50             | 150    | 100               | Used             | Quote Confirmation        | FREIGHT INFORMATION | Used        |

@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user enters the insured value on creteshipment modalpopup_new
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And I clicked on <Service> button on the select type screen of rate request process
    When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Freight Description Section <classification>, <weight>
	And I enter valid data in Shipping From Section <SFZiporpostal>
    And I enter valid data in Shipping To Section <STZiporPostal>
    And I Click On view quote results button
	When I click on create shipment
    Then I Will be displayed with pop up modal
    And I Enter valid data in <EnterInsuredVal> field of insured modal pop up
    And I select '<InsuredType>' on the Create shipment modal
    And I click on Show Insured Rates button in the modal pop up
    And I should be display with the rates for new type only for all carriers on results page 
	And I should be display with the rates for new type only for all carriers on guaranteed grid results page 

Examples: 
| scenario | Username                 | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | EnterInsuredVal | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | popuponresults@cship.com | Te$t1234 | LTL     | 90001         | 90001         | 50             | 150    | 100             | Quote Confirmation        | FREIGHT INFORMATION | New         | 

@Regression
Scenario Outline:Verifcation of  insured rate type on rate results sceen when user enters the insured value on creteshipment modalpopup_used
    Given I am a DLS user and login into application with valid <Username> and <Password>
    And I clicked on <Service> button on the select type screen of rate request process
    When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Freight Description Section <classification>, <weight>
    And I Click On view quote results button
	When I click on create shipment
    Then I Will be displayed with pop up modal
    And I Enter valid data in <EnterInsuredVal> field of insured modal pop up
   	And I select '<InsuredType>' on the Create shipment modal
    And I click on Show Insured Rates button in the modal pop up
    And I should be display with the rates for used type only for all carriers on results page 
	And I should be display with the rates for used type only for all carriers on guaranteed grid results page
Examples: 
| scenario | Username                 | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | EnterInsuredVal | QuoteConfirmationpageText | FreightInformation  | InsuredType |
| s1       | popuponresults@cship.com | Te$t1234 | LTL     | 90001         | 90001         | 50             | 150    | 100             | Quote Confirmation        | FREIGHT INFORMATION | Used         |        