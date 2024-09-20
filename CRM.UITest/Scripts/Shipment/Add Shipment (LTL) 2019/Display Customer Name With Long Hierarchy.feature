@Sprint90 @76522 @Regression
Feature: Display Customer Name With Long Hierarchy
	
Scenario Outline: 76522_Verify the Customer Name hierarchy on Add Shipment (LTL) 2019 for sales user_Customer of more than one Level
Given I am a sales user,
And I am creating an LTL shipment
And I selected a <CustomerName> that is more than one level
When I am on the Add Shipment (LTL) page
Then I will display with a customer label below the header
And the customer label will now display Station ID - Primary Account...Final Customer Name <CustomerName> on Add Shipment LTL page

Examples: 
| CustomerName              |
| testOVLSwa1               |
| Seafood Wholesalers, Inc. |

Scenario Outline: 76522_Verify the Customer Name hierarchy on Add Shipment (LTL) 2019 for station users except sales user_Customer of more than one Level
Given I am a sales management, operations, or station owner user,
And I am creating an LTL shipment
And I selected a <CustomerName> that is more than one level
When I am on the Add Shipment (LTL) page
Then I will display with a customer label below the header
And the customer label will now display Station ID - Primary Account...Final Customer Name <CustomerName> on Add Shipment LTL page

Examples: 
| CustomerName      |
| checkhirarchy     |
| Runner's Edge Inc |

Scenario Outline: 76522_Verify the Hover Over message for the Customer Name hierarchy on Add Shipment (LTL) 2019 for sales user_Customer of more than one Level
Given I am a sales user,
And I am creating an LTL shipment
And I selected a <CustomerName> that is more than one level
And I am on the Add Shipment (LTL) page
When I hover over the customer name on Add Shipment LTL page
Then the entire station, hierarchies, and customer name <PopOverText> will be displayed in the hover over message on Add Shipment LTL page

Examples: 
| CustomerName        | PopOverText                                                                                 |
| Sub account testttt | ZZZ - Web Services Test - Prakashshipentry - Primary account test - Sub account testttt     |
| Bobby Sue's Nuts    | ZZZ - Web Services Test - Superior Nut and Candy Company - SAHALE SNACKS - Bobby Sue's Nuts |

Scenario Outline: 76522_Verify the Hover Over message for the Customer Name hierarchy on Add Shipment (LTL) 2019 for station users except sales user_Customer of more than one Level
Given I am a sales management, operations, or station owner user,
And I am creating an LTL shipment
And I selected a <CustomerName> that is more than one level
And I am on the Add Shipment (LTL) page
When I hover over the customer name on Add Shipment LTL page
Then the entire station, hierarchies, and customer name <PopOverText> will be displayed in the hover over message on Add Shipment LTL page

Examples: 
| CustomerName                 | PopOverText                                                                                                                                                        |
| Bobby Sue's Nuts             | ZZZ - Web Services Test - Superior Nut and Candy Company - SAHALE SNACKS - Bobby Sue's Nuts                                                                        |
| V-sub-sub-sub-sub-testing-GS | ZZZ - Web Services Test - sub of sub account testtt - SUB account testtt - SUB of Sub account testing - Sub of sub2 account testing - V-sub-sub-sub-sub-testing-GS |

Scenario Outline: 76522_Verify the Customer Name hierarchy on Add Shipment (LTL) 2019 for sales user - Customer of one Level
Given I am a sales user,
And I am creating an LTL shipment
And I selected a one level primary <CustomerName>
When I am on the Add Shipment (LTL) page
Then I will display with a customer label below the header
And the customer label will now display Station ID - Primary Account <CustomerName> on Add Shipment LTL page

Examples: 
| CustomerName                        |
| Orange & dade county, solutions.Inc |

Scenario Outline: 76522_Verify the Customer Name hierarchy on Add Shipment (LTL) 2019 for station users except sales user - Customer of one Level
Given I am a sales management, operations, or station owner user,
And I am creating an LTL shipment
And I selected a one level primary <CustomerName>
When I am on the Add Shipment (LTL) page
Then I will display with a customer label below the header
And the customer label will now display Station ID - Primary Account <CustomerName> on Add Shipment LTL page

Examples:
| CustomerName                |
| 53499SowTestingOn12/10/2018 |

