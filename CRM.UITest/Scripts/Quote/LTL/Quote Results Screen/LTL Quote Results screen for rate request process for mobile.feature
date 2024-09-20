@LTLQuoteResultsformobile @17390 @Sprint59
Feature: LTL Quote Results screen for rate request process for mobile

@Regression
Scenario Outline: Test to verify that all the required fields present in the LTL Quote Results Page on a mobile browser
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And  I enter valid data origin zip in Origin section <OriginZip>
And  I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then user should be displayed with Carrier Name, Carrier Logo, Guaranteed Rate Available Link, Service, Distance, Rate, Save Rate As Quote link, Insured Rate and Save Insured Rate as Quote link

Examples: 
| Scenario | Username				| Password | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue | WindowWidth | WindowHeight | url                        |
| s1       | zzz					| Te$t1234 | LTL     | 90001     | 90087          | 50             | 70     | 1000          | 768         | 640          | http://dlscrm-dev.rrd.com/ |
| s2       | nat@extuser.com		| Te$t1234 | LTL     | 85001     | 90087          | 50             | 70     | 1000          | 768         | 992          | http://dlscrm-dev.rrd.com/ |
| s3       | shipentry@gmail.com    | Te$t1234 | LTL     | 33126     | 90087          | 50             | 70     | 1000          | 992         | 1200         | http://dlscrm-dev.rrd.com/ |

#------------Sprint 64 Insured Value and Insured Type---------------

@Regression
Scenario Outline: Test to verify that all the required button are hidden in the LTL Quote Results Page on a mobile browser
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data in Shipping From Section <SFZiporpostal>
And I enter valid data in Shipping To Section <STZiporPostal>
And I enter valid data in Freight Description Section <classification>, <weight>
And I click on view quote results button
Then user should not be visible with Enter insured value label, filtering options, sorting, Extra rate info (Fuel, line haul, accessorials), Extra insured rate info (New, Used), Back to Quote List button and export button 

Examples: 
| Scenario | Username            | Password | Service | SFZiporpostal | STZiporPostal | classification | weight | WindowWidth | WindowHeight |
| s1       | shipentry@gmail.com | Te$t1234 | LTL     | 90001         | 60606         | 50             | 70     | 320         | 568          |

#------------End of Sprint 64 Insured Value and Insured Type---------------
@Regression
Scenario Outline: Test to verify Save Rate as Quote functionality on a mobile browser
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then user should be displayed with Carrier Name, Carrier Logo, Guaranteed Rate Available Link, Service, Distance, Rate, Save Rate As Quote link, Insured Rate and Save Insured Rate as Quote link
And I click on save rate as quote link  for selected carrier
And I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'

Examples: 
| Scenario | Username            | Password | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue | WindowWidth | WindowHeight | url                        | QuoteConfirmationpageText |
| s1       | zzz                 | Te$t1234 | LTL     | 90001     | 90087          | 50             | 70     | 1000          | 768         | 640          | http://dlscrm-dev.rrd.com/ | Quote Confirmation        |
| s2       | nat@extuser.com     | Te$t1234 | LTL     | 85001     | 90087          | 50             | 70     | 1000          | 768         | 992          | http://dlscrm-dev.rrd.com/ | Quote Confirmation        |
| s3       | shipentry@gmail.com | Te$t1234 | LTL     | 33126     | 90087          | 50             | 70     | 1000          | 992         | 1200         | http://dlscrm-dev.rrd.com/ | Quote Confirmation        |

@Regression
Scenario Outline: Test to verify Save Insured Rate as Quote functionality on a mobile browser
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then user should be displayed with Carrier Name, Carrier Logo, Guaranteed Rate Available Link, Service, Distance, Rate, Save Rate As Quote link, Insured Rate and Save Insured Rate as Quote link
And I click on save insured rate as quote link  for selected carrier
And I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'

Examples: 
| Scenario | Username            | Password | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue | WindowWidth | WindowHeight | url                        | QuoteConfirmationpageText |
| s1       | zzz                 | Te$t1234 | LTL     | 90001     | 90087          | 50             | 70     | 1000          | 768         | 640          | http://dlscrm-dev.rrd.com/ | Quote Confirmation        |
| s2       | nat@extuser.com     | Te$t1234 | LTL     | 85001     | 90087          | 50             | 70     | 1000          | 768         | 992          | http://dlscrm-dev.rrd.com/ | Quote Confirmation        |
| s3       | shipentry@gmail.com | Te$t1234 | LTL     | 33126     | 90087          | 50             | 70     | 1000          | 992         | 1200         | http://dlscrm-dev.rrd.com/ | Quote Confirmation        |

@Regression
Scenario Outline: Test to verify the save your quote hyperlink and update your shipping information link in the Quote Results when there is No Quote Results for the given combination on mobile browser
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I will be displayed with Save your quote hyperlink and update your shipping information link

Examples: 
| Scenario | Username            | Password | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue | WindowWidth | WindowHeight | url                        | 
| s1       | zzz                 | Te$t1234 | LTL     | 90001     | 99501          | 50             | 70     | 1000          | 768         | 640          | http://dlscrm-dev.rrd.com/ | 
| s2       | nat@extuser.com     | Te$t1234 | LTL     | 99501     | 90087          | 50             | 70     | 1000          | 768         | 992          | http://dlscrm-dev.rrd.com/ | 
| s3       | shipentry@gmail.com | Te$t1234 | LTL     | 33126     | 99501          | 50             | 70     | 1000          | 992         | 1200         | http://dlscrm-dev.rrd.com/ | 

@Regression
Scenario Outline: Test to verify the functionality of save your quote hyperlink in the Quote Results when there is No Quote Results for the given combination on mobile browser
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I will be displayed with Save your quote hyperlink and update your shipping information link
And I click on save your quote link when there are no rate results
And I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'

Examples: 
| Scenario | Username            | Password | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue | WindowWidth | WindowHeight | url                        | QuoteConfirmationpageText |
| s1       | zzz                 | Te$t1234 | LTL     | 90001     | 99501          | 50             | 70     | 1000          | 768         | 640          | http://dlscrm-dev.rrd.com/ | Quote Confirmation        |
| s2       | nat@extuser.com     | Te$t1234 | LTL     | 99501     | 90087          | 50             | 70     | 1000          | 768         | 992          | http://dlscrm-dev.rrd.com/ | Quote Confirmation        |
| s3       | shipentry@gmail.com | Te$t1234 | LTL     | 33126     | 99501          | 50             | 70     | 1000          | 992         | 1200         | http://dlscrm-dev.rrd.com/ | Quote Confirmation        |

@Regression
Scenario Outline: Test to verify the functionality of update your shipping information hyperlink in the Quote Results when there is No Quote Results for the given combination on mobile browser
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process from mobile device
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates <url>
Then I will be displayed with Save your quote hyperlink and update your shipping information link
And I click on update your shipping information link when there are no rate results
And I will be navigated to LTL Shipment Information screen

Examples: 
| Scenario | Username            | Password | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue | WindowWidth | WindowHeight | url                        | 
| s1       | zzz                 | Te$t1234 | LTL     | 99501     | 90087          | 50             | 70     | 1000          | 768         | 640          | http://dlscrm-dev.rrd.com/ | 
| s2       | nat@extuser.com     | Te$t1234 | LTL     | 99501     | 90087          | 50             | 70     | 1000          | 768         | 992          | http://dlscrm-dev.rrd.com/ | 
| s3       | shipentry@gmail.com | Te$t1234 | LTL     | 33126     | 99501          | 50             | 70     | 1000          | 992         | 1200         | http://dlscrm-dev.rrd.com/ | 
