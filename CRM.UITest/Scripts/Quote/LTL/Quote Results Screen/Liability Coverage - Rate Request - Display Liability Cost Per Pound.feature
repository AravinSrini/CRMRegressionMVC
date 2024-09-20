@19258 @Sprint66 
Feature: Liability Coverage - Rate Request - Display Liability Cost Per Pound

@Regression
 Scenario Outline:Verification of  Cost per Pound (New) and Cost per Pound (Used) fields with dollar symbol on results screen in get quote_nonguaranteed
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I click on view quote results button
   Then I should displayed with Cost per PoundNew and Cost per PoundUsed fields above Max Liability field 
   And the verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier
   And I should displayed with Cost per PoundNew and Cost per PoundUsed fields with prefix of dollar 
    
Examples: 
| scenario | Username  | Password | Service | SFZiporpostal | STZiporPostal | classification | weight |
| s1       | shp.entry | Te$t1234 | LTL     | 90001         | 60606         | 50             | 10     |

@Regression 
Scenario Outline: Verification of Cost per Pound (New) and Cost per Pound (Used) field values in get quote_DB verification_nonguaranteed
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I click on view quote results button
   Then I should displayed with Cost per PoundNew and Cost per PoundUsed field values should match with the DB for Nonguaranteed grid       

Examples: 
| scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | 
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 
  
@Regression
Scenario Outline:Verification of Cost per Pound (New) and Cost per Pound (Used) fields with dollar symbol on results screen in get quote_guaranteed
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I click on view quote results button
   Then I should displayed with Cost per PoundNew and Cost per PoundUsed fields above Max Liability field for guaranteed
   And the verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for guaranteed carrier
   And I should displayed with Cost per PoundNew and Cost per PoundUsed fields with prefix of dollar for guaranteed
       
Examples: 
| scenario | Username  | Password | Service | SFZiporpostal | STZiporPostal | classification | weight |
| s1       | shp.entry | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    |

@Regression
Scenario Outline:Verification of  Cost per Pound (New) and Cost per Pound (Used) fields values in get quote_DB verification_guaranteed
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I click on view quote results button
   Then I should displayed with Cost per PoundNew and Cost per PoundUsed field values should match with the DB for guaranteed grid 
      
Examples: 
| scenario | Username  | Password | Service | SFZiporpostal | STZiporPostal | classification | weight |
| s1       | shipentry | Te$t1234 | LTL     | 90001         | 60606         | 50             | 150    | 

@Regression
Scenario Outline:Verification CostPerPound(New) and CostPerPound(Used) values in get quote_DB verification_insuredtype_New
   Given I login as Ship entry user
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I enter data in <Insuredvalue> field 
   And I select New insured type from '<InsuredvalueType>' dropdown
   And I click on view quote results button   
   Then I should displayed with Cost per PoundNew and Cost per PoundUsed fields with prefix of dollar 
   And I should displayed with Cost per PoundNew and Cost per PoundUsed field values should match with the DB for Nonguaranteed grid   
       
Examples: 
| Username | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType | 
 | shipentry|  | LTL     | 90001         | 60606         | 50             | 150    | 100          | New              | 

@Regression
Scenario Outline: Verification CostPerPound(New) and CostPerPound(Used) values in get quote_DB verification_insuredtype_Used
   Given I login as Ship entry user
   And I clicked on <Service> button on the select type screen of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I enter valid data in Shipping From Section <SFZiporpostal>
   And I enter valid data in Shipping To Section <STZiporPostal>
   And I enter valid data in Freight Description Section <classification>, <weight>
   And I enter data in <Insuredvalue> field 
   And I select New insured type from '<InsuredvalueType>' dropdown
   And I click on view quote results button
   Then I should displayed with Cost per PoundNew and Cost per PoundUsed fields with prefix of dollar  
   And I should displayed with Cost per PoundNew and Cost per PoundUsed field values should match with the DB for Nonguaranteed grid  
       
Examples: 
| Username| Password | Service | SFZiporpostal | STZiporPostal | classification | weight | Insuredvalue | InsuredvalueType  | 
| shipentry|  | LTL     | 90001         | 60606         | 50             | 150    | 100          | Used              | 
