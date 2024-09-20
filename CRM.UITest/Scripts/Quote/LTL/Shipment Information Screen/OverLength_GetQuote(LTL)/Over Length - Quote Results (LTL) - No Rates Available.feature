@Sprint81
Feature: Over Length - Quote Results (LTL) - No Rates Available
	
@Regression 
Scenario:40960 - Verify if the dimension fields are binding and editable when no rates are available on Quote results page
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station owner user
	And I am on quote results page of a quote, which contains values for Length, Width, Height and Dimension Type
	And I have received a notification that there are no rates available for this shipment
	When I navigate to Get quote(LTL) page by clicking on update shipping information button
	Then CRM will bind the dimension values of the original rate request submission
	And I have the option to edit the values.
