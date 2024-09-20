@Sprint83 @44541
Feature: Quote Confirmation (LTL) - New Accessorial - Notification
	
@Regression
Scenario Outline: Verify Notification is displayed in the Ship From field of Services and Accessorials section of Quote Details section on Quote Confirmation page when I submit Save Rate as Quote
        Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
		And I passed all mandatory information on the Get Quote LTL page 
		And I selected <Notification> in the Click to add services and accessorials field of the Shipping From Section
		And I Clicked on the <Quote_Type> on the Quote Results LTL pag
		And I arrive on the Quote Confirmation LTL page
		When I expand the Show Quote Details section
	    Then I will see Notification displayed in the Ship From field of the Services and Accessorials section

Examples: 
| Quote_Type                       |
| Rate As Quote                    |
| Insured Rate As Quote            |
| Guaranteed Rate As Quote         |
| Guaranteed Insured Rate As Quote |




@Regression
Scenario Outline: Verify Notification is displayed in the Ship To field of Services and Accessorials section of Quote Details section on Quote Confirmation page when I submit Save Rate as Quote
        Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
		And I passed all mandatory information on the Get Quote LTL page 
		And I selected <Notification> in the Click to add services and accessorials field of the Shipping To Section
		And I Clicked on the <Quote_Type> on the Quote Results LTL pag
		And I arrive on the Quote Confirmation LTL page
		When I expand the Show Quote Details section
	    Then I will see Notification displayed in the Ship To field of the Services and Accessorials section
Examples: 
| Quote_Type                       |
| Rate As Quote                    |
| Insured Rate As Quote            |
| Guaranteed Rate As Quote         |
| Guaranteed Insured Rate As Quote |


