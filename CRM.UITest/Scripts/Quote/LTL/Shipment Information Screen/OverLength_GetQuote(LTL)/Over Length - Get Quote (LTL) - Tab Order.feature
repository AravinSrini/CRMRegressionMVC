@Sprint81 @40779
Feature: Over Length - Get Quote (LTL) - Tab Order

Background: Login to CRM application
Given I am a shp.inquiry,shp.entry, operations, sales, sales management, or station owner user
And I am on get Quote LTL page

@Regression 
Scenario: 40779_Verify the Tab Order functionality when user selects Overlength in Shipping From section 
When I have selected Overlength in Shipping From section
Then Tab order will be from Shipping From, Shipping To zip/postal code, classification, weight, length, width, height and View Quote Results button
And Tab order for additional Item from classification, weight, length, width, height and View Quote Results button

@Regression 
Scenario: 40779_Verify the Tab Order functionality when user selects Overlength in Shipping To section
When I have selected Overlength in Shipping To section
Then Tab order will be from Shipping From, Shipping To zip/postal code, classification, weight, length, width, height and View Quote Results button

@Regression 
Scenario: 40779_Verify Back Tab Order functionality when user selects Overlength Shipping From section
When I have selected Overlength in Shipping From section
Then Back Tab order will be from View Quote Results button, Height, Width, Length, Weight, Classification, ShippingTo and shippingFrom zip/postal code
And Back Tab order for additional Item from View Quote Results Button, Height, Width, Length, Weight, classification

@Regression 
Scenario: 40779_Verify Back Tab Order functionality when user selects Overlength Shipping To section
When I have selected Overlength in Shipping To section
Then Back Tab order will be from View Quote Results button, Height, Width, Length, Weight, Classification, ShippingTo and shippingFrom zip/postal code
And Back Tab order for additional Item from View Quote Results Button, Height, Width, Length, Weight, classification

@Regression 
Scenario: 40779_Verify the Tab order functionality when user not select Overlength Shipping From section
When I have not selected Overlength services and accessorials in Shipping From section
Then Tab order will be from Shipping From, Shipping To zip/postal code, classification, weight and View Quote Results button
And Additional Item tab order will be from classification, weight and View Quote Results button

@Regression 
Scenario: 40779_Verify the Tab order functionality when user not select Overlength Shipping To section
When I have not selected Overlength services and accessorials in Shipping To section
Then Tab order will be from Shipping From, Shipping To zip/postal code, classification, weight and View Quote Results button
And Additional Item tab order will be from classification, weight and View Quote Results button

@Regression 
Scenario: 40779_Verify Back Tab order functionality when user not select Overlength Shipping From section
When I have not selected Overlength services and accessorials in Shipping From section
Then Back Tab order will be from View Quote Results button, Weight, Classification, Shipping To and shipping From zip/postal code
And Back Tab order for additional Item from View Quote Results Button, Weight, classification 

@Regression 
Scenario: 40779_Verify Back Tab order functionality when user not select Overlength Shipping To section
When I have not selected Overlength services and accessorials in Shipping To section
Then Back Tab order will be from View Quote Results button, Weight, Classification, Shipping To and shipping From zip/postal code
And Back Tab order for additional Item from View Quote Results Button, Weight, classification 

@Regression 
Scenario: 40779_Verify the Tab order functionality when user not select any services and accessorials-Shipping From section
When I have not selected any services and accessorials in Shipping From section
Then Tab order will be from Shipping From, Shipping To zip/postal code, classification, weight and View Quote Results button
And Additional Item tab order will be from classification, weight and View Quote Results button

@Regression 
Scenario: 40779_Verify the Tab order functionality when user not select any services and accessorials-Shipping To section
When I have not selected any services and accessorials in Shipping To section
Then Tab order will be from Shipping From, Shipping To zip/postal code, classification, weight and View Quote Results button
And Additional Item tab order will be from classification, weight and View Quote Results button

@Regression 
Scenario: 40779_Verify Back Tab order functionality when user not select any services and accessorials-Shipping From
When I have not selected any services and accessorials in Shipping From section
Then Back Tab order will be from View Quote Results button, Weight, Classification, Shipping To and shipping From zip/postal code
And Back Tab order for additional Item from View Quote Results Button, Weight, classification 

@Regression 
Scenario: 40779_Verify Back Tab order functionality when user not select any services and accessorials-Shipping To
When I have not selected any services and accessorials in Shipping To section
Then Back Tab order will be from View Quote Results button, Weight, Classification, Shipping To and shipping From zip/postal code
And Back Tab order for additional Item from View Quote Results Button, Weight, classification 
