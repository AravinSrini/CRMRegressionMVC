@SubmitCSR @Sprint67 @Regression
Feature: SubmitCSR


#-------------------------------------------------------Submit CSR CSA Flow---------------------------------------------------------------------------------------------------------------------------



@Functional
Scenario Outline:  : Verify User able to Submit CSR with TMS Type CSA with Templates Uploaded
Given I LogIn to the application as SystemAdmin
And I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page<AccountInformation_text>
And I enter the Account Information details for CSA Type SubAccount and Click on Save and Continue will be Navigated to Locations and Contact Page<Station_Id>,<SalesRep>,<Select_PrimaryAccount_ForThis_CSR>,<EnterpriseType>,<UserType>,<CustomerAccountName>,<CSA_CustomerNumber>,<ShipmentNotification_Email>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I enter Gainshare pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page<PricingType>,<percentage>,<MinThreshold_Charge>,<MinAmount_Added>,<carriersExcluded>,<Household_Goods>,<Rating_Instructions>
And I Click on browse for a file to Upload link in Item section and upload Item Template<ItemPath>
And I Click on browse for a file to Upload link in Address section and upload Address Template<AddressPath>
And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
And Click on browse for a file to Upload link in Portal Users section and upload Portal Users Template<PortalUsersPath>
And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
And I able to see Account Information details in Review and Submit Page<Station_Id>,<SalesRep>,<EnterpriseType>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I able to see Location and Contact details in Review and Submit Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I able to see Gainshare Pricing details in Review and Submit Page<PricingType>,<percentage>,<MinThreshold_Charge>,<MinAmount_Added>,<carriersExcluded>,<Household_Goods>,<Rating_Instructions>
And I able to See Templates Uploaded in Review and Submit Page
When I click on the Submit button leads to Submit CSR
Then I will see the PopUp denotes that CSR been submitted<CSRSubmitted_Text>

Examples:
| Username | Password | Station_Id | SalesRep | EnterpriseType | CustomerInvoiceMethod | CustomerInvoiceBackUp | CreditCard | Name | Address1 | Address2 | City | State | Zip | Country | PhoneNumber | Email | FaxNumber | Website | Residential_Location | Comments | PricingType | percentage | MinThreshold_Charge | MinAmount_Added | carriersExcluded | Household_Goods | Rating_Instructions | CSRSubmitted_Text | ItemPath | AddressPath | PortalUsers_Text | PortalUsersPath | ReviewAndSubmitText | AccountInformation_text | Select_PrimaryAccount_ForThis_CSR | UserType | CustomerAccountName | CSA_CustomerNumber | ShipmentNotification_Email |
 |Admin	|  | 123        | House Acct | Station Sales  | Print                 | BOL                   | No         | Marques | Mint     | Mint     | Montgomery | AL    | 90001 | United States | 8056436283  | t@t.com | 8056436283 | web@web.com | Yes                  | check    | Gainshare   | 27         | 90					| 43			  | N/A              | No              | ratera                   | This CSR has been submitted | ..\\..\\Scripts\\TestData\\SubmitCSR\\ItemTemplate\\Template_Item.xlsx | ..\\..\\Scripts\\TestData\\SubmitCSR\\AddressTemplate\\Template_Address.xlsx | Portal Users     | ..\\..\\Scripts\\TestData\\SubmitCSR\\UsersTemplate\\Template_PortalUSer.xlsx | Review and Submit   | Account Information		  | Sliver Creek                         | Admin	| Leonalship			  | 790854344          | ship@emt.com                |


@Functional
Scenario Outline:  : Verify created CSR of Type CSA present in CSR List Page
Given I LogIn to the application as SystemAdmin
And I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page<AccountInformation_text>
And I enter the Account Information details for CSA Type SubAccount and Click on Save and Continue will be Navigated to Locations and Contact Page<Station_Id>,<SalesRep>,<Select_PrimaryAccount_ForThis_CSR>,<EnterpriseType>,<UserType>,<CustomerAccountName>,<CSA_CustomerNumber>,<ShipmentNotification_Email>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I enter Gainshare pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page<PricingType>,<percentage>,<MinThreshold_Charge>,<MinAmount_Added>,<carriersExcluded>,<Household_Goods>,<Rating_Instructions>
And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
When I click on the Submit button leads to Submit CSR
Then I click on the close button will be navigated to CSR list page
And verify for the created CSR present in CSR list page by entering the Customer Account name in the search box from CSR list page<CustomerAccountName>

Examples:
| Username| Password | Station_Id | SalesRep   | EnterpriseType | CustomerInvoiceMethod | CustomerInvoiceBackUp | CreditCard | Name    | Address1 | Address2 | City		| State | Zip   | Country       | PhoneNumber | Email   | FaxNumber  | Website     | Residential_Location | Comments | PricingType | percentage | MinThreshold_Charge | MinAmount_Added | carriersExcluded | Household_Goods | Rating_Instructions | PortalUsers_Text	 |ReviewAndSubmitText   | AccountInformation_text | Select_PrimaryAccount_ForThis_CSR  | UserType | CustomerAccountName    | CSA_CustomerNumber| ShipmentNotification_Email |
| admin| Te$t1234 | 123        | House Acct | Station Sales  | Print                 | BOL                   | No         | lopez   | Mint     | Mint     | Birmingham | AL    | 90001 | United States | 8056436283  | t@t.com | 8056436283 | web@web.com | Yes                  | check    | Gainshare   | 27         | 90                  | 43              | N/A              | No              | ratea               | Portal Users        |  Review and Submit   | Account Information     | Sliver Creek                       | Admin    | Aeronalship			   | 790982744         | ship@emt.com               |

@DBVerification
Scenario Outline:  : Verify created CSR of Type CSA is Saved in Database

Given I LogIn to the application as SystemAdmin
And I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page<AccountInformation_text>
And I enter the Account Information details for CSA Type SubAccount and Click on Save and Continue will be Navigated to Locations and Contact Page<Station_Id>,<SalesRep>,<Select_PrimaryAccount_ForThis_CSR>,<EnterpriseType>,<UserType>,<CustomerAccountName>,<CSA_CustomerNumber>,<ShipmentNotification_Email>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I enter Gainshare pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page<PricingType>,<percentage>,<MinThreshold_Charge>,<MinAmount_Added>,<carriersExcluded>,<Household_Goods>,<Rating_Instructions>
And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
When I click on the Submit button leads to Submit CSR
Then I click on the close button will be navigated to CSR list page
Then the CSR will be created successfully and saved in Database<CustomerAccountName>

Examples:
| Username| Password | Station_Id | SalesRep   | EnterpriseType | CustomerInvoiceMethod | CustomerInvoiceBackUp | CreditCard | Name    | Address1 | Address2 | City		 | State | Zip   | Country       | PhoneNumber | Email   | FaxNumber  | Website     | Residential_Location | Comments | PricingType | percentage | MinThreshold_Charge | MinAmount_Added | carriersExcluded | Household_Goods | Rating_Instructions | PortalUsers_Text	    |ReviewAndSubmitText   | AccountInformation_text | Select_PrimaryAccount_ForThis_CSR  | UserType | CustomerAccountName    | CSA_CustomerNumber| ShipmentNotification_Email |
| admin| Te$t1234 | 123        | House Acct | Station Sales  | Print                 | BOL                   | No         | lopez   | Mint     | Mint     | Birmingham | AL    | 90001 | United States | 8056436283  | t@t.com | 8056436283 | web@web.com | Yes                  | check    | Gainshare   | 27         | 90                  | 43              | N/A              | No              | ratea               | Portal Users          |  Review and Submit   | Account Information     | Sliver Creek                       | Admin    | Cheronalship			  | 790833704         | ship@emt.com               |

#-----------------------------------------------------------------------------------Submit CSR MG Flow-----------------------------------------------------------------------------------------------------------

@Functional
Scenario Outline:  : Verify User able to Submit CSR with TMS Type MG with Items, Address, Portal Users created Manually
Given I LogIn to the application as SystemAdmin
And I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page<AccountInformation_text>
And I enter the Account Information details for MG Type Primary Account and Click on Save and Continue will be Navigated to Locations and Contact Page<Station_Id>,<SalesRep>,<OtherValue>,<EnterpriseType>,<CustomerAccountName>,<ShipmentNotification_Email>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I enter Tariff pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page<PricingType>,<TariffType>,<Discount>,<Minimum>,<carriersExcluded>,<Household_Goods>,<SpecialRate>
And I Click on Create a Saved Item button and Enter Item Details<Classification>,<NMFC>,<ItemDescription>,<HazardousMaterials>
And I Click Create a Saved Address button and Enter Address Details<Name>,<Address1>,<Address2>,<City>,<Country>,<State>,<Zip>
And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
And I Click on Create a Portal User button and Enter User Details<FirstName>,<LastName>,<Email>,<ExternalUserType>,<TMSType>,<OfficeNumber>
And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
And I able to see Account Information details for MG TMS Type with Sales Rep Other in Review and Submit Page<Station_Id>,<OtherValue>,<EnterpriseType>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I able to see Location and Contact details in Review and Submit Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I able to see Tariff Pricing details in Review and Submit Page<PricingType>,<TariffType>,<Discount>,<Minimum>,<carriersExcluded>,<Household_Goods>,<SpecialRate>
And I able to see manually created Item details in Review and Submit Page<Classification>,<NMFC>,<ItemDescription>,<HazardousMaterials>
And I able to see manually created Address details in Review and Submit Page<Name>,<City>,<State>,<Zip>
And I able to see manually created Portal Users details in Review and Submit Page<FirstName>,<LastName>,<ExternalUserType>,<TMSType>
When I click on the Submit button leads to Submit CSR
Then I will see the PopUp denotes that CSR been submitted<CSRSubmitted_Text>



Examples:
| Username| Password | Station_Id | SalesRep | OtherValue | EnterpriseType | CustomerAccountName | ShipmentNotification_Email | CustomerInvoiceMethod | CustomerInvoiceBackUp | CreditCard | Name	    | Address1 | Address2 | City    | State | Zip   | Country       | PhoneNumber | Email	   | FaxNumber  | Website     | Residential_Location | Comments | PricingType | TariffType         | Discount | Minimum | carriersExcluded | Household_Goods | SpecialRate | Classification | NMFC | ItemDescription| HazardousMaterials | PortalUsers_Text | FirstName   | LastName  | ExternalUserType | TMSType | OfficeNumber | CSRSubmitted_Text           | ReviewAndSubmitText | AccountInformation_text |
| admin| Te$t1234 | 123        | Other    | testings   | Station Sales  | Ioranalship			| bik@bk.com                | Print                 | BOL                   | No         | testnaamey  | Mint     | Mint     | Miami   | AL    | 90001 | United States | 8056436283  | tgbs@t.com | 8056436283 | web@web.com | Yes                  | check    | Tariff      | Czarlite 9/14/2015 | 37       | 39      | N/A              | No              | tedss       | 50             | 1823 | uaship          | No                 | Portal Users     | Soo         | Seooba    | Shp.Entry        | MG      | 8156436239   | This CSR has been submitted | Review and Submit   | Account Information     |


@Functional
Scenario Outline:  : Verify created CSR of Type MG present in CSR List Page
Given I LogIn to the application as SystemAdmin
And I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page<AccountInformation_text>
And I enter the Account Information details for MG Type Primary Account and Click on Save and Continue will be Navigated to Locations and Contact Page<Station_Id>,<SalesRep>,<OtherValue>,<EnterpriseType>,<CustomerAccountName>,<ShipmentNotification_Email>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I enter Tariff pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page<PricingType>,<TariffType>,<Discount>,<Minimum>,<carriersExcluded>,<Household_Goods>,<SpecialRate>
And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
When I click on the Submit button leads to Submit CSR
Then I click on the close button will be navigated to CSR list page
And verify for the created CSR present in CSR list page by entering the Customer Account name in the search box from CSR list page<CustomerAccountName>

Examples:
| Username | Password | Station_Id | SalesRep | OtherValue   | EnterpriseType | CustomerAccountName		  | ShipmentNotification_Email | CustomerInvoiceMethod | CustomerInvoiceBackUp | CreditCard	   | Name				| Address1 | Address2 | City     | State | Zip   | Country       | PhoneNumber | Email   | FaxNumber  | Website     | Residential_Location | Comments | PricingType | TariffType         | Discount | Minimum | carriersExcluded | Household_Goods | SpecialRate | PortalUsers_Text | ReviewAndSubmitText | AccountInformation_text |
| Admin	| Te$t1234 | 123        | Other    | tstman	   | Station Sales  | Noronalship                  | byk@byk.com                | Print                 | BOL                   | No            | testMonapasinameb  | Mint     | Mint     | Miami	 | AL    | 90001 | United States | 8056436283  | t@t.com | 8056436283 | web@web.com | Yes                  | check    | Tariff      | Czarlite 9/14/2015 | 20       | 32      | N/A              | No              | tedss       | Portal Users     | Review and Submit   | Account Information     |

@DBVerification
Scenario Outline:  : Verify created CSR of Type MG is Saved in Database
Given I LogIn to the application as SystemAdmin
And I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page<AccountInformation_text>
And I enter the Account Information details for MG Type Primary Account and Click on Save and Continue will be Navigated to Locations and Contact Page<Station_Id>,<SalesRep>,<OtherValue>,<EnterpriseType>,<CustomerAccountName>,<ShipmentNotification_Email>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I enter Tariff pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page<PricingType>,<TariffType>,<Discount>,<Minimum>,<carriersExcluded>,<Household_Goods>,<SpecialRate>
And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
When I click on the Submit button leads to Submit CSR
Then I click on the close button will be navigated to CSR list page
And the CSR will be created successfully and saved in Database<CustomerAccountName>

Examples:
| Username| Password | Station_Id | SalesRep | OtherValue		  | EnterpriseType | CustomerAccountName  | ShipmentNotification_Email | CustomerInvoiceMethod | CustomerInvoiceBackUp | CreditCard	   | Name				| Address1 | Address2 | City    | State | Zip   | Country       | PhoneNumber | Email   | FaxNumber  | Website     | Residential_Location | Comments | PricingType | TariffType         | Discount | Minimum | carriersExcluded | Household_Goods | SpecialRate | PortalUsers_Text | ReviewAndSubmitText | AccountInformation_text |
| Admin	| Te$t1234 | 123        | Other    | psbman			  | Station Sales  | Roronalship			  | bike@bk.com                  | Print                 | BOL                   | No          | testponapasinamea  | Mint     | Mint     | Miami   | AL    | 90001 | United States | 8056436283  | t@t.com | 8056436283 | web@web.com | Yes                  | check    | Tariff      | Czarlite 9/14/2015 | 27       | 34      | N/A              | No              | tedss       | Portal Users     | Review and Submit   | Account Information     |



#----------------------------Submit CSR BOTH TMS type flow ----------------------------

@Functional
Scenario Outline:  : Verify User able to Submit CSR with TMS Type Both with Templates Uploaded
Given I LogIn to the application as SystemAdmin
And I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page<AccountInformation_text>
And I enter the Account Information details for Both Type SubAccount and Click on Save and Continue will be Navigated to Locations and Contact Page<Station_Id>,<SalesRep>,<Select_PrimaryAccount_ForThis_CSR>,<EnterpriseType>,<UserType>,<CustomerAccountName>,<CSA_CustomerNumber>,<ShipmentNotification_Email>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I enter Gainshare pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page<PricingType>,<percentage>,<MinThreshold_Charge>,<MinAmount_Added>,<carriersExcluded>,<Household_Goods>,<Rating_Instructions>
And I Click on browse for a file to Upload link in Item section and upload Item Template<ItemPath>
And I Click on browse for a file to Upload link in Address section and upload Address Template<AddressPath>
And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
And Click on browse for a file to Upload link in Portal Users section and upload Portal Users Template<PortalUsersPath>
And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
And I able to see Account Information details in Review and Submit Page<Station_Id>,<SalesRep>,<EnterpriseType>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I able to see Location and Contact details in Review and Submit Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I able to see Gainshare Pricing details in Review and Submit Page<PricingType>,<percentage>,<MinThreshold_Charge>,<MinAmount_Added>,<carriersExcluded>,<Household_Goods>,<Rating_Instructions>
And I able to See Templates Uploaded in Review and Submit Page
When I click on the Submit button leads to Submit CSR
Then I will see the PopUp denotes that CSR been submitted<CSRSubmitted_Text>

Examples:
| Username| Password | Station_Id | SalesRep   | EnterpriseType | CustomerInvoiceMethod | CustomerInvoiceBackUp | CreditCard | Name	 | Address1 | Address2 | City       | State | Zip   | Country       | PhoneNumber | Email   | FaxNumber  | Website     | Residential_Location | Comments | PricingType | percentage | MinThreshold_Charge	| MinAmount_Added | carriersExcluded | Household_Goods | Rating_Instructions	  | CSRSubmitted_Text           | ItemPath                                                               | AddressPath                                                                  | PortalUsers_Text | PortalUsersPath                                                               | ReviewAndSubmitText | AccountInformation_text	  | Select_PrimaryAccount_ForThis_CSR    | UserType	| CustomerAccountName | CSA_CustomerNumber | ShipmentNotification_Email  |
| Admin| Te$t1234 | 123        | House Acct | Station Sales  | Print                 | BOL                   | No         | Marques | Mint     | Mint     | Montgomery | AL    | 90001 | United States | 8056436283  | t@t.com | 8056436283 | web@web.com | Yes                  | check    | Gainshare   | 27         | 90					| 43			  | N/A              | No              | ratera                   | This CSR has been submitted | ..\\..\\Scripts\\TestData\\SubmitCSR\\ItemTemplate\\Template_Item.xlsx | ..\\..\\Scripts\\TestData\\SubmitCSR\\AddressTemplate\\Template_Address.xlsx | Portal Users     | ..\\..\\Scripts\\TestData\\SubmitCSR\\UsersTemplate\\Template_PortalUSer.xlsx | Review and Submit   | Account Information		  | Zamborelli Enterprises               | Admin	| Acsr_accountfrtrt	  | 111990923          | ship@emt.com                |


@Functional
Scenario Outline:  : Verify created CSR of Type Both present in CSR List Page
Given I LogIn to the application as SystemAdmin
And I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page<AccountInformation_text>
And I enter the Account Information details for Both Type SubAccount and Click on Save and Continue will be Navigated to Locations and Contact Page<Station_Id>,<SalesRep>,<Select_PrimaryAccount_ForThis_CSR>,<EnterpriseType>,<UserType>,<CustomerAccountName>,<CSA_CustomerNumber>,<ShipmentNotification_Email>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I enter Gainshare pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page<PricingType>,<percentage>,<MinThreshold_Charge>,<MinAmount_Added>,<carriersExcluded>,<Household_Goods>,<Rating_Instructions>
And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
When I click on the Submit button leads to Submit CSR
Then I click on the close button will be navigated to CSR list page
And verify for the created CSR present in CSR list page by entering the Customer Account name in the search box from CSR list page<CustomerAccountName>

Examples:
| Username| Password | Station_Id | SalesRep   | EnterpriseType | CustomerInvoiceMethod | CustomerInvoiceBackUp | CreditCard | Name    | Address1 | Address2 | City		| State | Zip   | Country       | PhoneNumber | Email   | FaxNumber  | Website     | Residential_Location | Comments | PricingType | percentage | MinThreshold_Charge | MinAmount_Added | carriersExcluded | Household_Goods | Rating_Instructions | PortalUsers_Text	 |ReviewAndSubmitText   | AccountInformation_text | Select_PrimaryAccount_ForThis_CSR  | UserType | CustomerAccountName   | CSA_CustomerNumber| ShipmentNotification_Email |
| admin	| Te$t1234 | 123        | House Acct | Station Sales  | Print                 | BOL                   | No         | lopez   | Mint     | Mint     | Birmingham | AL    | 90001 | United States | 8056436283  | t@t.com | 8056436283 | web@web.com | Yes                  | check    | Gainshare   | 27         | 90                  | 43              | N/A              | No              | ratea               | Portal Users        |  Review and Submit   | Account Information     | Zamborelli Enterprises             | Admin    | Acsr_accounthyuu      | 333877903         | ship@emt.com               |


@DBVerification
Scenario Outline:  : Verify created CSR of Type Both is Saved in Database

Given I LogIn to the application as SystemAdmin
And I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page<AccountInformation_text>
And I enter the Account Information details for Both Type SubAccount and Click on Save and Continue will be Navigated to Locations and Contact Page<Station_Id>,<SalesRep>,<Select_PrimaryAccount_ForThis_CSR>,<EnterpriseType>,<UserType>,<CustomerAccountName>,<CSA_CustomerNumber>,<ShipmentNotification_Email>,<CustomerInvoiceMethod>,<CustomerInvoiceBackUp>,<CreditCard>
And I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page<Name>,<Address1>,<Address2>,<City>,<State>,<Zip>,<Country>,<PhoneNumber>,<Email>,<FaxNumber>,<Website>,<Residential_Location>,<Comments>
And I enter Gainshare pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page<PricingType>,<percentage>,<MinThreshold_Charge>,<MinAmount_Added>,<carriersExcluded>,<Household_Goods>,<Rating_Instructions>
And I Click on Save and Continue button will be Navigated to Portal Users Page<PortalUsers_Text>
And I Click on Save and Continue button will be Navigated to Review and Submit Page<ReviewAndSubmitText>
When I click on the Submit button leads to Submit CSR
Then I click on the close button will be navigated to CSR list page
Then the CSR will be created successfully and saved in Database<CustomerAccountName>

Examples:
| Username| Password | Station_Id | SalesRep   | EnterpriseType | CustomerInvoiceMethod | CustomerInvoiceBackUp | CreditCard | Name	 | Address1 | Address2 | City	    | State | Zip   | Country       | PhoneNumber | Email   | FaxNumber  | Website     | Residential_Location | Comments | PricingType | percentage | MinThreshold_Charge | MinAmount_Added | carriersExcluded | Household_Goods | Rating_Instructions | PortalUsers_Text	   |ReviewAndSubmitText   | AccountInformation_text | Select_PrimaryAccount_ForThis_CSR  | UserType | CustomerAccountName  | CSA_CustomerNumber | ShipmentNotification_Email |
| admin	| Te$t1234 | 123        | House Acct | Station Sales  | Print                 | BOL                   | No         | lopez  | Mint     | Mint     | Birmingham | AL    | 90001 | United States | 8056436283  | t@t.com | 8056436283 | web@web.com | Yes                  | check    | Gainshare   | 27         | 90                  | 43              | N/A              | No              | ratea               | Portal Users          |  Review and Submit   | Account Information     | Zamborelli Enterprises             | Admin    | Acsr_accounteww      | 556694932          | ship@emt.com               |

