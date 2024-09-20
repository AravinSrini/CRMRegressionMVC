@RevampLTLRateRequestShippingInfoPageElements_Desktop @22577 @Sprint64
Feature: RevampLTLRateRequestShippingInfoPage-PageElements_Desktop

@Regression 
Scenario Outline: Verify the Page Elements in the LTL Rate Request Shipping Info Page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And I should see the text '<GetQuotetext>', '<BacktoQuoteListBtn>' button in the Quotes landing page
	And I must see the LTL '<LTL>' tile in the Quotes landing page
	And  I click on the LTL tile
	Then I should be arraive on the Get Quote LTL '<LTLPagetitle>' screen 
	And I must see the the '<ShippingFrom>', '<zip>', '<city>', '<country>', '<state>', '<services>', '<ShippingTo>', '<FreightDescription>', '<SelectClassorSavedItem>', '<EnterWeight>', '<Quantity>', '<QuantityType>', '<InsuredValue>', '<InsuredValueNew>' and '<PickupDate>'
	And I must also see the clear address buttons for '<clear>' both Shipping From and Shipping To also Density Calculator, '<AddAdditionalItem>', Calendar, '<BacktoQuoteList>', '<ViewQuoteResults>'
	And I must see the tool tip '<message>' when mousehover on the Question mark icon

	Examples: 
	| Scenario | Username         | Password | GetQuotetext | BacktoQuoteListBtn | LTL | LTLPagetitle | ShippingFrom | zip | city | country | state | services | ShippingTo | FreightDescription | SelectClassorSavedItem | EnterWeight | Quantity | QuantityType | InsuredValue | InsuredValueNew | PickupDate | clear | AddAdditionalItem | BacktoQuoteList | ViewQuoteResults | message |
	| S1       | test01@entry.com | Te$t1234 | Get Quote    | Back to Quote List | LTL | Get Quote (LTL) | Shipping From | Enter zip/postal code... | Enter city... | United States | Select state/province... | Click to add services & accessorials... | Shipping To | Freight Description | Select or search for a class or saved item... | Enter a weight... | Enter a quantity... | Skids        | Enter insured value... | New             | Pickup Date | Clear Address | Add Additional Item | Back to Quote List | View Quote Results | Normal method to determine insured value: Invoice Cost, plus Insurance Cost, plus any prepaid freight charges, all plus 10% |


@Regression 
Scenario Outline: Verify the LTL Rate Request Shipping Info Page when data is not passed in required fields
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And  I click on the LTL tile
	And I click on view quote results button 
	Then All the Required fields should be highlight in the pink color

	Examples: 
	| Scenario | Username         | Password |
	| S1       | test01@entry.com | Te$t1234 |
