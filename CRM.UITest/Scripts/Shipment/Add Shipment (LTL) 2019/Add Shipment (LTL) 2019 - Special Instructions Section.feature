@76036 @Sprint90
Feature: Add Shipment (LTL) 2019 - Special Instructions Section
	
Scenario Outline: 76036_Verify the "Special Instructions" field in Add Shipment (LTL) 2019 when "Default Special Instructions" is not set for a Customer_InternalUsers
	Given I am an operations or station owner user
	And I am associated to a customer in which Default Special Instructions have NOT been saved <Customer Name>
	When I arrive on the Add Shipment (LTL) 2019 page
	Then I will see the Special Instructions text box
	And I will see the watermark verbiage Enter any special instructions... displayed in the Special Instructions text box

Examples: 
| Customer Name                                 |
| 76036 - Customer_NoDefaultSpecialInstructions |

Scenario Outline: 76036_Verify the "Special Instructions" field in Add Shipment (LTL) 2019 when "Default Special Instructions" is saved for a Customer_InternalUsers
	Given I am an operations or station owner user
	And I am associated to a customer in which Default Special Instructions has been saved <Customer Name>
	When I arrive on the Add Shipment (LTL) 2019 page
	Then I will see the Special Instructions field with	saved information
	And the Special Instructions field is editable

Examples: 
| Customer Name                                   |
| 76036 - Customer_WithDefaultSpecialInstructions |

Scenario Outline: 76036_Verify the "Special Instructions" field in Add Shipment (LTL) 2019 when "Default Special Instructions" is not set for a Customer_ExternalUsers
	Given I am a shp.entry or shp.entrynorates user <Default Special Instructions>
	And I am associated to a customer in which Default Special Instructions have NOT been saved <Customer Name>
	When I arrive on the Add Shipment (LTL) 2019 page
	Then I will see the Special Instructions text box
	And I will see the watermark verbiage Enter any special instructions... displayed in the Special Instructions text box

Examples: 
| Customer Name                                 | Default Special Instructions |
| 76036 - Customer_NoDefaultSpecialInstructions | No                           |

Scenario Outline: 76036_Verify the "Special Instructions" field in Add Shipment (LTL) 2019 when "Default Special Instructions" is saved for a Customer_ExternalUsers
	Given I am a shp.entry or shp.entrynorates user <Default Special Instructions>
	And I am associated to a customer in which Default Special Instructions has been saved <Customer Name>
	When I arrive on the Add Shipment (LTL) 2019 page
	Then I will see the Special Instructions field with	saved information
	And the Special Instructions field is editable

Examples: 
| Customer Name                                   | Default Special Instructions |
| 76036 - Customer_WithDefaultSpecialInstructions | Yes                          |

Scenario Outline: 76036_Verify the "Special Instructions" field in Add Shipment (LTL) 2019 when "Default Special Instructions" is not set for a Customer_SalesUsers
	Given I am a Sales or Sales Management user
	And I am associated to a customer in which Default Special Instructions have NOT been saved <Customer Name>
	When I arrive on the Add Shipment (LTL) 2019 page
	Then I will see the Special Instructions text box
	And I will see the watermark verbiage Enter any special instructions... displayed in the Special Instructions text box

Examples: 
| Customer Name                                 |
| 76036 - Customer_NoDefaultSpecialInstructions |

Scenario Outline: 76036_Verify the "Special Instructions" field in Add Shipment (LTL) 2019 when "Default Special Instructions" is saved for a Customer_SalesUsers
	Given I am a Sales or Sales Management user
	And I am associated to a customer in which Default Special Instructions has been saved <Customer Name>
	When I arrive on the Add Shipment (LTL) 2019 page
	Then I will see the Special Instructions field with	saved information
	And the Special Instructions field is editable

Examples: 
| Customer Name                                   |
| 76036 - Customer_WithDefaultSpecialInstructions |
