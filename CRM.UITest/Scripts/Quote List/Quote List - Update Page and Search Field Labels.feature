@Sprint87 @50644
Feature: Quote List - Update Page and Search Field Labels
	
@GUI
Scenario Outline: 50644_Verify the Quote List page label
	Given I am a shp.inquiry, shp.entry, operations, sales, sales management, or station owner user <userType>
	When I arrive on the Quotes page
	Then the page label will be <QuoteList>

Examples: 
| userType | QuoteList  |
| Internal | Quote List |
| External | Quote List |

@GUI
Scenario: 50644_Verify the Search invoices renamed with search quotes in Quote List Page
	Given I am a shp.inquiry or shp.entry user
	When I arrive on the Quote List page
	Then the <Search invoices...> field will be renamed <Search quotes...>.