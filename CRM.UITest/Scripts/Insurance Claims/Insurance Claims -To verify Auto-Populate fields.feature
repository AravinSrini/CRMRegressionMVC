@Sprint78 @39807 

Feature: Insurance Claims -To verify Auto-Populate fields
	
#-------------------------  Exteranl users- Autopopulate scenario -----------------------------------#

@API @Functional
Scenario Outline:39807-Verify Carrier Information Section fields will be populated -shp.inquiry
Given I am a External User-shp.inquiry
And I am on Submit a Claim page
And I have entered a valid DLSW BOL# <DLSWBOLNumber>
And I click on the Populate Form button,
When I receive the data for the submitted reference number from MG <DLSWBOLNumber>
Then the Carrier Information Section fields  DLSW Bill of Lading # ,DLSW BOL Date,Carrier Name,Carrier PRO,Carrier PRO Date will be populated

Examples: 
| DLSWBOLNumber |
| ZZX00208760   |
| ZZX00209982   |

@API @Functional
Scenario Outline:39807-Verify Shipper Information Section fields will be populated -shp.inquiry
Given I am a External User-shp.inquiry
And I am on Submit a Claim page
And I have entered a valid DLSW BOL# <DLSWBOLNumber>
And I click on the Populate Form button,
When I receive the data for the submitted reference number from MG <DLSWBOLNumber>
Then the Shipper Information Section Name,Address,City,State,Zip,Country will be populated

Examples: 
| DLSWBOLNumber |
| ZZX00208760   |
| ZZX00209982   |

@API @Functional
Scenario Outline:39807-Verify Consignee Information Section fields will be populated -shp.inquiry
Given I am a External User-shp.inquiry
And I am on Submit a Claim page
And I have entered a valid DLSW BOL# <DLSWBOLNumber>
And I click on the Populate Form button,
When I receive the data for the submitted reference number from MG <DLSWBOLNumber>
Then the Consignee Information Section Name,Address,City,State,Zip,Country will be populated

Examples: 
| DLSWBOLNumber |
| ZZX00208760   |
| ZZX00209982   |

#------------------------------  Internal users - Autopopulate scenario --------------------------------------------#

@API @Functional
Scenario Outline:39807-Verify Carrier Information Section fields will be populated -Operations user
Given I am a Internal User-Operational user
And I am on Submit a Claim page
And I have entered a valid DLSW BOL# <DLSWBOLNumber>
And I click on the Populate Form button,
When I receive the data for the submitted reference number from MG <DLSWBOLNumber>
Then the Carrier Information Section fields  DLSW Bill of Lading # ,DLSW BOL Date,Carrier Name,Carrier PRO,Carrier PRO Date will be populated

Examples: 
| DLSWBOLNumber |
| ZZX00208760   |


@API @Functional
Scenario Outline:39807-Verify Shipper Information Section fields will be populated -Operations user
Given I am a Internal User-Operational user
And I am on Submit a Claim page
And I have entered a valid DLSW BOL# <DLSWBOLNumber>
And I click on the Populate Form button,
When I receive the data for the submitted reference number from MG <DLSWBOLNumber>
Then the Shipper Information Section Name,Address,City,State,Zip,Country will be populated

Examples: 
| DLSWBOLNumber |
| ZZX00208760   |

@API @Functional
Scenario Outline:39807-Verify Consignee Information Section fields will be populated -Operations user
Given I am a Internal User-Operational user
And I am on Submit a Claim page
And I have entered a valid DLSW BOL# <DLSWBOLNumber>
And I click on the Populate Form button,
When I receive the data for the submitted reference number from MG <DLSWBOLNumber>
Then the Consignee Information Section Name,Address,City,State,Zip,Country will be populated

Examples: 
| DLSWBOLNumber |
| ZZX00208760   |
| ZZX00209982   |




#-------------------------  Autopopulate scenario  CSA Shipment-----------------------------------#

@API @Functional @Spring79 @32268
Scenario Outline:32268-Verify Carrier Information Section fields will be populated - CSA Shipment
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
And I am on Submit a Claim page
And I have entered a valid DLSW BOL# <DLSWBOLNumber>
And I click on the Populate Form button,
When I receive the data for the submitted reference number from CSA <DLSWBOLNumber>
Then the Carrier Information Section fields  DLSW Bill of Lading # ,DLSW BOL Date,Carrier Name,Carrier PRO,Carrier PRO Date will be populated

Examples: 
| DLSWBOLNumber |
| 9920495       |

@API @Functional @Spring79 @32268
Scenario Outline:32268-Verify Shipper Information Section fields will be populated - CSA Shipment
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
And I am on Submit a Claim page
And I have entered a valid DLSW BOL# <DLSWBOLNumber>
And I click on the Populate Form button,
When I receive the data for the submitted reference number from CSA <DLSWBOLNumber>
Then the Shipper Information Section Name,Address,City,State,Zip,Country will be populated

Examples: 
| DLSWBOLNumber |
| 9920495       |

@API @Functional @Spring79 @32268
Scenario Outline:32268-Verify Consignee Information Section fields will be populated - CSA Shipment
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
And I am on Submit a Claim page
And I have entered a valid DLSW BOL# <DLSWBOLNumber>
And I click on the Populate Form button,
When I receive the data for the submitted reference number from CSA <DLSWBOLNumber>
Then the Consignee Information Section Name,Address,City,State,Zip,Country will be populated

Examples: 
| DLSWBOLNumber |
| 1255970       |



#------------------------------------Verification of Invalid BOL Number Text Messages for internal Users CSA Shipment----------------------------------------------------#

	


@GUI
	Scenario Outline: 39807 - Verify the Text Message upon entering invalid BOL number for Sales Management Users
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I have entered a Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I clicked on the Populate Form button
	Then I will see the text message notifying user for Invalid BOL number

	Examples: 
	| InvalidDLSWBOLNumber | 
	| ZZZZZZZZZZ8		   |

@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering valid BOL number for Sales Management Users
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered new DLSW BOL# <DLSWBOLNumber>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | DLSWBOLNumber		|
	| ZZZZZZZZZZ8          |       ZZX00208760|

@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering DLSW Ref number for Sales Management User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered any DLSW Refnumber<DLSWRefnumber>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | DLSWRefnumber			    |
	|   ZZZZZZZZZZ8        | ZZX00208760                |

@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Carrier Name for Sales Management User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Carrier Name<carrierName>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | carrierName			    |
	|  ZZZZZZZZZZ8         |  Fedex Priority		    |

@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering DLSW Ship Date for Sales Management User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered DLSW Ship Date
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | 
	|ZZZZZZZZZZ8           |


	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Carrier Pro field for Sales Management User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Carrier Pro field<CarrierProvalue>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | CarrierProvalue |
	| ZZZZZZZZZZ8          | sd45245		 |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Carrier Pro Date for Sales Management User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Carrier Pro Date
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | 
	| ZZZZZZZZZZ8		   |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Name for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Shipper Name<Name>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Name			    |
	|  ZZZZZZZZZZ8         | Tester             |


	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Address for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Shipper Address<Address>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Address			               |
	| ZZZZZZZZZZ8          | Park Avenue                       |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Address2 for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper Address two <Address>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Address			    |
	|  ZZZZZZZZZZ8         | Marine Park            |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Zip/postal for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper Zip/Postal <zip>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | zip		   |
	|  ZZZZZZZZZZ8         |  90001        |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Country for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper Country <country>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | country			    |
	| ZZZZZZZZZZ8          | Turkey			        |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper State for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper State <state>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | state			    |
	|ZZZZZZZZZZ8           | AL                 |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper City for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper City <city>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | city  |
	| InvalidDLSWBOLNumber | Miami |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee Name for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Consignee Name<Name>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Name			    |
	|       ZZZZZZZZZZ8    |      Tester        |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee Address for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Consignee Address<Address>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Address			    |
	| ZZZZZZZZZZ8          |   Highways			    |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee Address2 for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee Address two <Address>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Address			    |
	|  ZZZZZZZZZZ8         |  St Annes				|

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee Zip/postal for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee Zip/Postal <zip>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | zip			    |
	|  ZZZZZZZZZZ8         |  90001			    |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee Country for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee Country <country>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | country			    |
	|  ZZZZZZZZZZ8         |   Turkey				|

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee State for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee State <state>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | state			    |
	|  ZZZZZZZZZZ8         |      AL			|
	
	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee City for SalesManagement User
	Given I am Sales Management User
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee City <city>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | city  |
	| ZZZZZZZZZZ8		   | Miami |

	#--------------------------------------Verification of Invalid BOL Number Text Messages for Customer Users----------------------#

	@GUI
	Scenario Outline: 39807 - Verify the Text Message upon entering invalid BOL number for Shipment Entry Users
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I have entered a Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I clicked on the Populate Form button
	Then I will see the text message notifying user for Invalid BOL number

	Examples: 
	| InvalidDLSWBOLNumber | 
	|ZZZZZZZZZZ8		   |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering valid BOL number for Shipment Entry Users
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered new DLSW BOL# <DLSWBOLNumber>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | DLSWBOLNumber		|
	|  ZZZZZZZZZZ8         | ZZX00208760|

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering DLSW Ref number for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered any DLSW Refnumber<DLSWRefnumber>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | DLSWRefnumber			    |
	|   ZZZZZZZZZZ8        | ZZX00208760                |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Carrier Name for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Carrier Name<carrierName>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | carrierName			    |
	|  ZZZZZZZZZZ8         |  Fedex Priority		    |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering DLSW Ship Date for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered DLSW Ship Date
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | 
	|ZZZZZZZZZZ8           |


	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Carrier Pro field for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Carrier Pro field<CarrierProvalue>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | CarrierProvalue |
	| ZZZZZZZZZZ8          | sd45245		 |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Carrier Pro Date for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Carrier Pro Date
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | 
	| ZZZZZZZZZZ8		   |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Name for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Shipper Name<Name>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Name			    |
	|  ZZZZZZZZZZ8         | Tester             |


	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Address for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Shipper Address<Address>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Address			               |
	| ZZZZZZZZZZ8          | Park Avenue                       |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Address2 for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper Address two <Address>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Address			    |
	|  ZZZZZZZZZZ8         | Marine Park            |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Zip/postal for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper Zip/Postal <zip>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | zip		   |
	|  ZZZZZZZZZZ8         |  90001        |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper Country for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper Country <country>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | country			    |
	| ZZZZZZZZZZ8          | Turkey			        |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper State for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper State <state>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | state			    |
	|ZZZZZZZZZZ8           | AL                 |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Shipper City for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Shipper City <city>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | city  |
	| InvalidDLSWBOLNumber | Miami |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee Name for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Consignee Name<Name>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Name			    |
	|       ZZZZZZZZZZ8    |      Tester        |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee Address for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I entered Consignee Address<Address>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Address			    |
	| ZZZZZZZZZZ8          |   Highways			    |

	@GUI
	Scenario Outline: Verify the absence of invalid BOL number Text Message up on entering Consignee Address2 for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee Address two <Address>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | Address			    |
	|  ZZZZZZZZZZ8         |  St Annes				|

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee Zip/postal for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee Zip/Postal <zip>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | zip			    |
	|  ZZZZZZZZZZ8         |  90001			    |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee Country for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee Country <country>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | country			    |
	|  ZZZZZZZZZZ8         |   Turkey			    |

	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee State for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee State <state>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | state			    |
	|  ZZZZZZZZZZ8         |      AL			|
	
	@GUI
	Scenario Outline: 39807 - Verify the absence of invalid BOL number Text Message up on entering Consignee City for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	And I am on Submit a Claim page
	And I received a message for Invalid DLSW BOL# <InvalidDLSWBOLNumber>
	When I have entered Consignee City <city>
	Then the Invalid BOL number text message will be removed

	Examples: 
	| InvalidDLSWBOLNumber | city  |
	| InvalidDLSWBOLNumber | Miami |



