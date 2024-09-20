@Sprint90 @76035 @Regression
Feature: AddShipment(LTL)2019-PickupDateSection
	

Scenario Outline: 76035 - Verify Default today's date in datepicker, along with Default Ready and Close Time, Time intervals and selection
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
When I arrive to the Add Shipment (LTL) page
Then today's date will be the default selection in the "Pickup Date" section
And "Ready 08:00 AM" will be the default Ready selection in the "Pickup Date" section
And I have the option to select another Ready time from the drop down list
And the Ready options are displayed in 30 minute intervals beginning at "12:00 AM" and ending at "11:30 PM"
And "Close 05:00 PM" will be the default Close selection in the "Pickup Date" section
And I have the option to select another Close time from the drop down list
And the Close options are displayed in 30 minute intervals beginning at "12:00 AM" and ending at "11:30 PM"
Examples: 
| UserType |
| External |
| Internal |
| Sales    |



Scenario Outline: 76035 - Verify Calendar Popup and toggle options for navigating Future and Previous months
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
When I arrive to the Add Shipment (LTL) page
When I click on the Date Picker icon in the Pickup Date section
Then a popup calendar will appear
And I am Unable to select a date prior to today
And I am Unable to toggle backward to any month prior to the current month
And I have the option to toggle to future months
And I have the option to toggle backward to previous months
Examples: 
|UserType|
| External |
| Internal |
| Sales    |

Scenario Outline: 76035 - Verify Date Picker Calendar closes and selected date displayed in the Pickup Date selection up on selecting any allowable date from calendar
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrived to the Add Shipment (LTL) page
And I clicked on the Date Picker icon in the Pickup Date section
When I Select any allowable day from the calendar
Then the date picker calendar will close
And the selected date will be displayed in the Pickup Date section
Examples: 
|UserType|
| External |
| Internal |
| Sales    |

Scenario Outline: 76035 - Verify the Alert Message and option to close the Alert Message upon selecting Close time earlier than the Ready time
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrived to the Add Shipment (LTL) page
When I Select a Close time "02:00 AM" in the Pickup Date section that is earlier than the Ready time "03:00 AM"
Then I will receive an error message: Error "Please select a Pickup Date Close time that is after the Pickup Date Ready time."
And I have the option to close the error message
Examples: 
|UserType|
| External |
| Internal |
| Sales    |

Scenario Outline: 76035 - Verify the Alert Message and option to close the Alert Message When i click on View Rates button for the selected Close time earlier than the Ready time
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrived to the Add Shipment (LTL) page
And  I fill the required fields in shipping From section
And  I fill the required fileds in shipping To section
And I selected a Close time "02:00 AM" in the Pickup Date section that is earlier than the Ready time "03:00 AM"
And I closed the Error "Please select a Pickup Date Close time that is after the Pickup Date Ready time. message
When I have click the View Rates button
Then the Error  "Please select a Pickup Date Ready time that is before the Pickup Date Close time., Please select a Pickup Date Close time that is after the Pickup Date Ready time." message will displayed
Examples: 
|UserType|
| External |
| Internal |
| Sales    |

Scenario Outline: 76035 - Verify the Alert Message and option to close the Alert Message upon selecting Ready time later than the Close time
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrived to the Add Shipment (LTL) page
When I Select a Ready time "02:00 AM" in the Pickup Date section that is later than the Close time "01:00 AM"
Then I Will receive error message: Error "Please select a Pickup Date Ready time that is before the Pickup Date Close time."
And I've the option to close the error message
Examples: 
|UserType|
| External |
| Internal |
| Sales    |

Scenario Outline: 76035 - Verify the Alert Message and option to close the Alert Message When i click on View Rates button for the selected Ready time later than the Close time
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrived to the Add Shipment (LTL) page
And  I fill the required fields in shipping From section
And  I fill the required fileds in shipping To section
And I selected a Ready time "02:00 AM" in the Pickup Date section that is later than the Close time "01:00 AM"
And I closed the Error "Please select a Pickup Date Ready time that is before the Pickup Date Close time. message
When I have click the View Rates button
Then the Error  "Please select a Pickup Date Ready time that is before the Pickup Date Close time., Please select a Pickup Date Close time that is after the Pickup Date Ready time." message will displayed
Examples: 
|UserType|
| External |
| Internal |
| Sales    |

Scenario Outline: 76035 - Verify the Absence of Alert Message when Close time later than the Ready time
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrived to the Add Shipment (LTL) page
When I Select a Close time "02:00 AM" in the Pickup Date section that is later than the Ready time "01:00 AM"
Then I will not receive an error message: Error "Please select a Pickup Date Close time that is after the Pickup Date Ready time."
Examples: 
|UserType|
| External |
| Internal |
| Sales    |

Scenario Outline: 76035 - Verify the Alert Message when Ready time equal to Close time
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrived to the Add Shipment (LTL) page
When I Select a Ready time "01:00 AM" in the Pickup Date section that is equal to the Close time "01:00 AM"
Then I Will receive error message: Error "Please select a Pickup Date Ready time that is before the Pickup Date Close time."
And I will receive an error message: Error "Please select a Pickup Date Close time that is after the Pickup Date Ready time."
Examples: 
|UserType|
| External |
| Internal |
| Sales    |

Scenario Outline: 76035 - Verify the Alert Message When i click on View Rates button for the selected Ready time equal to Close time
Given I am a shp.entry shp.entrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrived to the Add Shipment (LTL) page
And  I fill the required fields in shipping From section
And  I fill the required fileds in shipping To section
And I selected a Ready time "02:00 AM" in the Pickup Date section that is equal to the Close time "02:00 AM"
And I closed the Error "Please select a Pickup Date Ready time that is before the Pickup Date Close time. message
And I closed the Error "Please select a Pickup Date Close time that is after the Pickup Date Ready time. message
When I have click the View Rates button
Then the Error  "Please select a Pickup Date Ready time that is before the Pickup Date Close time., Please select a Pickup Date Close time that is after the Pickup Date Ready time." message will displayed
Examples:
|UserType|
| External |
| Internal |
| Sales    |