@35261 @Sprint74
Feature: MasterCarrierRateSettings_ExcludedCarriers_NoRateResults
	
@Functional @DBVerification
Scenario Outline: 35261_Verify the excluded carriers not displaying in Rate results page
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
When I am on the Rate Results page <userType>, <customerName>, <oZip>, <dZip>, <classification> and <weight>
Then Rate results will not include the carriers that were excluded for the mapped customer <customerName>

Examples: 
| Scenario | userName     | password | userType | customerName             | oZip  | dZip  | classification | weight |
| s1       | zzzext       | Te$t1234 | External | ZZZ - Czar Customer Test | 33126 | 85282 | 50             | 200    |
| s2       | crmoperation | Te$t1234 | Internal | ZZZ - Czar Customer Test | 90001 | 60606 | 50             | 250    |

@Functional @DBVerification
Scenario Outline: 35261_Verify the excluded carriers not displaying in Shipment results page
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
When  am on the Shipment results page <userType>, <customerName>, <oName>, <oAdd1>, <oZip>, <dName>, <dAdd1>, <dZip>, <classification>, <nmfc>, <quantity>, <weight> and <desc> 
Then Shipment results will not include the carriers that were excluded for the mapped customer <customerName>

Examples: 
| Scenario | userName     | password | userType | customerName             | oName  | oAdd1  | oZip  | dName  | dAdd1  | dZip  | classification | nmfc  | quantity | weight | desc            |
| s1       | zzzext       | Te$t1234 | External | ZZZ - Czar Customer Test | TestON | TestOA | 90001 | TestDN | TestDA | 60606 | 50             | 200hf | 4        | 250    | testRateResults |
| s2       | crmoperation | Te$t1234 | Internal | ZZZ - Czar Customer Test | TestON | TestOA | 33126 | TestDN | TestDA | 85282 | 50             | 200hf | 4        | 350    | testRateResults |