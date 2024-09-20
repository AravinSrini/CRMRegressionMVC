@35690 @Sprint76 @Ignore
Feature: InsuredValue_ExcludedCarrier(s)_Shipment
	
@GUI @DBVerification
Scenario Outline: 35690_Verify Insured Rate column for excluded carriers on Shipment Results page by entering insured value on add shipment page
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
And I enter data in add shipment page  <userType>, <customerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I entered <insuredRate> and click on view rates button
Then Insured shipment Cost, Create Insured Shipment option will not be displayed 
And I am displaying with <text> in the insured rate column for the excluded carriers

Examples: 
| Scenario | userName     | password | userType | customerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc   | quantity | weight | desc        | insuredRate | text                                 |
| s1       | crmOperation | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | oname | oadd | 60606 | dname | dadd | 55             | 1234ds | 2        | 1200   | description | 12          | No insured pricing for this carrier. |

@GUI @DBVerfication
Scenario Outline: 35690_Verify Insured Rate column for excluded carriers on Shipment Results page by entering insured value on shipment results page
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
And I enter data in add shipment page  <userType>, <customerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on View rates button in add shipment ltl page
And I enter <insuredRate> in shipment results page
Then Insured shipment Cost, Create Insured Shipment option will not be displayed 
And I am displaying with <text> in the insured rate column for the excluded carriers

Examples: 
| Scenario | userName     | password | userType | customerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc   | quantity | weight | desc        | insuredRate | text                                 |
| s1       | crmOperation | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | oname | oadd | 60606 | dname | dadd | 55             | 1234ds | 2        | 1200   | description | 12          | No insured pricing for this carrier. |

@GUI @DBVerification
Scenario Outline: 35690_Verify Insured Rate column for excluded carriers on Shipment Results page_Guaranteed by entering insured value on add shipment page
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
	And I enter data in add shipment page  <userType>, <customerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	When I entered <insuredRate> and click on view rates button	
	Then Insured shipment Cost, Create Insured Shipment option will not be displayed 
	And I am displaying with <text> in the insured rate column for the excluded carriers in guaranteed grid

Examples: 
| scenario | userName     | password | userType | customerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc   | quantity | weight | desc        | insuredRate | text                                 |
| s1       | crmOperation | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | oname | oadd | 60606 | dname | dadd | 55             | 1234ds | 2        | 1200   | description | 12          | No insured pricing for this carrier. |

@GUI @DBVerification
Scenario Outline: 35690_Verify Insured Rate column for excluded carriers on Shipment Results page_Guaranteed by entering insured value on Shipment results page
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
	And I enter data in add shipment page  <userType>, <customerName>, <oZip>,<oName>, <oAdd>, <dZip>,<dName>,<dAdd>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	When I click on View rates button in add shipment ltl page
	And I enter <insuredRate> in shipment results page
	Then Insured shipment Cost, Create Insured Shipment option will not be displayed 
	And I am displaying with <text> in the insured rate column for the excluded carriers in guaranteed grid

Examples: 
| scenario | userName     | password | userType | customerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc   | quantity | weight | desc        | insuredRate | text                                 |
| s1       | crmOperation | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | oname | oadd | 60606 | dname | dadd | 55             | 1234ds | 2        | 1200   | description | 12          | No insured pricing for this carrier. |

@GUI @DBVerification
Scenario Outline: 35690_Verify Insured Rate column for excluded carriers on Shipment Results page_Rate to Shipment	
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
	When am on the Rateresults page <userType>, <customerName>, <oZip>, <dZip>, <classification>, <weight>, <quantity>and <insuredRate>	
	And I click on createshipment for selected carrier in results page of '<userType>'
	And I am on Add Shipment page <oName>, <oAdd>, <dName>, <dAdd>, <classification>, <nmfc>, <quantity>, <weight>, <desc>		
	And I click on View rates button in add shipment ltl page	
	Then Insured shipment Cost, Create Insured Shipment option will not be displayed 
	And I am displaying with <text> in the insured rate column for the excluded carriers

Examples: 
| scenario | userName     | password | userType | customerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc   | quantity | weight | desc        | insuredRate | text                                 |
| s1       | crmOperation | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | oname | oadd | 60606 | dname | dadd | 55             | 1234ds | 2        | 1200   | description | 12          | No insured pricing for this carrier. |

@GUI @DBVerification
Scenario Outline: 35690_Verify Insured Rate column for excluded carriers on Shipment Results page_Rate to Shipment_Guaranteed
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
	When am on the Rateresults page <userType>, <customerName>, <oZip>, <dZip>, <classification>, <weight>, <quantity>and <insuredRate>
	And I click on createshipment for selected carrier in results page of '<userType>'
	And I am on Add Shipment page <oName>, <oAdd>, <dName>, <dAdd>, <classification>, <nmfc>, <quantity>, <weight>, <desc>		
	And I click on View rates button in add shipment ltl page	
	Then Insured shipment Cost, Create Insured Shipment option will not be displayed 
	And I am displaying with <text> in the insured rate column for the excluded carriers in guaranteed grid

Examples: 
| scenario | userName     | password | userType | customerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc   | quantity | weight | desc        | insuredRate | text                                 |
| s1       | crmOperation | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | oname | oadd | 60606 | dname | dadd | 55             | 1234ds | 2        | 1200   | description | 12          | No insured pricing for this carrier. |

@GUI @DBVerification
Scenario Outline: 35690_Verify Insured Rate column for excluded carriers on Shipment Results_Quote to Shipment
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
	When am on the Rateresults page <userType>, <customerName>, <oZip>, <dZip>, <classification>, <weight>, <quantity>and <insuredRate>
	And I click on save rate as quotelink for selected carrier in results page of '<userType>'
	And I am on Shipment Results page <oName>, <oAdd>, <dName>, <dAdd>, <nmfc>, <desc>	
	Then Insured shipment Cost, Create Insured Shipment option will not be displayed 
	And I am displaying with <text> in the insured rate column for the excluded carriers

Examples: 
| scenario | userName     | password | userType | customerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc   | quantity | weight | desc        | insuredRate | text                                 |
| s1       | crmOperation | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | oname | oadd | 60606 | dname | dadd | 55             | 1234ds | 2        | 1200   | description | 12          | No insured pricing for this carrier. |

@GUI @DBVerification
Scenario Outline: 35690_Verify Insured Rate column for excluded carriers on Shipment Results page_Quote to Shipment_Guaranteed
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <userName> <password>
	When am on the Rateresults page <userType>, <customerName>, <oZip>, <dZip>, <classification>, <weight>, <quantity>and <insuredRate>
	And I click on save rate as quotelink for selected carrier in results page of '<userType>'
	And I am on Shipment Results page <oName>, <oAdd>, <dName>, <dAdd>, <nmfc>, <desc>	
	Then Insured shipment Cost, Create Insured Shipment option will not be displayed 
	And I am displaying with <text> in the insured rate column for the excluded carriers in guaranteed grid

Examples: 
| scenario | userName     | password | userType | customerName           | oZip  | oName | oAdd | dZip  | dName | dAdd | classification | nmfc   | quantity | weight | desc        | insuredRate | text                                 |
| s1       | crmOperation | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | oname | oadd | 60606 | dname | dadd | 55             | 1234ds | 2        | 1200   | description | 12          | No insured pricing for this carrier. |