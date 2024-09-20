@LTLQuotesEstimateClassModalVerbiageEdit @19260 @Sprint61 @22761 @Sprint64 @GUI

Feature: Quotes_EstimateClassModal_Verbiage_Edit

@Regression
Scenario Outline: 19260-Verify the Estimated Classs Modal
	Given I logIn as Nat@Ext
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon	
	Then I will be able to see Estimated class modal <Estimated_Classs_Modal>
	And  I will be able to see verbiage under Estimated Class header <Estimated_Classs_Modal_Verbiage>

Examples: 
| Username | Password | Service | Estimated_Classs_Modal | Estimated_Classs_Modal_Verbiage |
| zzzext   |          | LTL     | Estimated Class Lookup | The results provided are an estimated class based on the information provided. The class may differ based on actual shipment characteristics. |

@Regression
Scenario Outline: Verify the fields Verbiage within Estimated Classs Modal
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon
	Then I will be able to see Estimated class modal <Estimated_Classs_Modal>
	And I will be able to see all fields within Estimated Class Modal <Length>,<Width>,<Height>,<Weight>,<Quantity>,<ESTIMATED_CLASS>

Examples: 
| Scenario | Username        | Password | Service | Estimated_Classs_Modal | Length      | Width      | Height      | Weight       | Quantity |  ESTIMATED_CLASS |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Estimated Class Lookup | LENGTH (IN) | WIDTH (IN) | HEIGHT (IN) | WEIGHT (LBS) | QUANTITY |  ESTIMATED CLASS |


@Regression
Scenario Outline: Verify Density verbiage above the Density calculation field
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon
	Then I will be able to see Estimated class modal <Estimated_Classs_Modal>
	And I will Density verbiage above the Density calculation field <Density>

Examples: 
| Scenario | Username        | Password | Service | Estimated_Classs_Modal |  Density            | 
| S1       | nat@extuser.com | Te$t1234 | LTL     | Estimated Class Lookup |  DENSITY (LBS/CBFT) |

@Regression
Scenario Outline: Verify Density verbiage above the Density Class Table
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon
	And I click on SHOW DENSITY CLASS TABLE link
	Then I will be able to see Estimated class modal <Estimated_Classs_Modal>
	And I will be able to see the Estimated class Commodity Table Verbiage '<Estimated_Classs_Commodity_Table>'
	And I will be able to see Density verbiage above the Density Class Table <Density_Under_table>,<Class>


Examples: 
| Scenario | Username        | Password | Service | Estimated_Classs_Modal | Density_Under_table | Class | Estimated_Classs_Commodity_Table         |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Estimated Class Lookup | DENSITY (LBS/CBFT)  | CLASS | ESTIMATED COMMODITY CLASSIFICATION TABLE |