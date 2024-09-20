@76047 @Sprint90

Feature: 76047_Add Shipment (LTL) 2019 - Shipping FromTo - Search_Select Saved Address

@Regression
Scenario Outline: 76047-Verify the option to select and search any saved address from the Select or search for a saved origin field in the Shipping From section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
When I arrive on the <Customer> Add Shipment (LTL) page for <UserType> user
Then I have option to select saved address from the Select or search for a saved origin in the Shipping From section
Examples: 
| UserType | Customer                 |
| External | ZZZ - GS Customer Test   |
| Internal | ZZZ - Czar Customer Test |
| Sales    | ZZZ - GS Demo            |

@Regression
Scenario Outline: 76047-Verify the first 100 saved adddresses associated to the customer are displayed when I click in the Select or search for a saved origin field in the Shipping From section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrive on the <Customer> Add Shipment - (LTL) page for <UserType> user
When I click the Select or search for a saved origin field in the Shipping From section
Then I should see first hundred saved addresses associated to the customer in ascending order <Customer>
Examples: 
| UserType | Customer                 |
| External | ZZZ - GS Customer Test   |
| Internal | ZZZ - Czar Customer Test |
| Sales    | ZZZ - GS Demo            |

@Regression
Scenario Outline: 76047-Verify the first 100 saved adddresses associated to the customer are displayed when I enter a value in the Select or search for a saved origin field in the Shipping From section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrive on the <Customer> Add Shipment - (LTL) page for <UserType> user
When I enter a value on the Select or search for a saved origin field as <Searchtext> in the Shipping From section
Then I should see the first hundred saved addresses that contains the value entered <Customer>,<Searchtext>
Examples: 
| UserType | Customer                 | Searchtext |
| External | ZZZ - GS Customer Test   |            |
| Internal | ZZZ - Czar Customer Test |            |
| Sales    | ZZZ - GS Demo            |            |

@Regression
Scenario Outline: 76047-Verify the auto population of data when I select a saved address from the Select or search for a saved origin field in the Shipping From section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrive on the <Customer> Add Shipment - (LTL) page for <UserType> user
When a saved address is selected from the Select or search for a saved origin field in the Shipping From section
Then all the fields in the Shipping From section should be auto populated with the saved address information associated to the <Customer>
And I should be unable to select another saved address in the Shipping From section
And I am able to edit all other fields in the Shipping From section <Originname>,<OriginAddr1>,<OriginAddr2>,<Originzipcode>,<OriginCity>,<OriginCountry>,<OriginState>,<OriginContactName>,<OriginContactEmail>,<OriginPhoneNumber>,<OriginFaxNumber>
Examples: 
| UserType | Customer                 | Originname | OriginAddr1  | OriginAddr2  | Originzipcode | OriginCity | OriginCountry | OriginState | OriginContactName | OriginContactEmail   | OriginPhoneNumber | OriginFaxNumber |
| External | ZZZ - GS Customer Test   | HoneyPark  | Addressline1 | Addressline2 | 33126         | Miami      | United States | FL          | czarTestingName   | czarTesting@test.com | (777) 777-7777    | (777) 123-7777  |
| Internal | ZZZ - Czar Customer Test |Go Shopping | 123 S Rodeo Dr  | Parkway      | 85282         | Tempe      | United States | AZ          | GsTestingName     | GsTesting@test.com   | (888) 888-8888    | (888) 000-8888  |
| Sales    | ZZZ - GS Demo            | 1231        | 123 street lane | Waterpark    | 94538         | Fremont    | United States | CA          | DemoTestingname   | DemoTesting@test.com | (888) 888-1234    | (235) 888-1234  |           

@Regression
Scenario Outline: 76047-Verify the option to select and search any saved address from the Select or search for a saved origin field in the Shipping To section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
When I arrive on the <Customer> Add Shipment (LTL) page for <UserType> user
Then I have option to select saved address from the Select or search for a saved destination in the Shipping To section
Examples: 
| UserType | Customer                 |
| External | ZZZ - GS Customer Test   |
| Internal | ZZZ - Czar Customer Test |
| Sales    | ZZZ - GS Demo            |

@Regression
Scenario Outline: 76047-Verify the first 100 saved adddresses associated to the customer are displayed when I click in the Select or search for a saved destination field in the Shipping To section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrive on the <Customer> Add Shipment - (LTL) page for <UserType> user
When I click the Select or search for a saved destination field in the Shipping To section
Then I should see first hundred saved addresses in the Shipping To section associated to the customer in ascending order <Customer> 
Examples: 
| UserType | Customer                 |
| External | ZZZ - GS Customer Test   |
| Internal | ZZZ - Czar Customer Test |
| Sales    | ZZZ - GS Demo            |

@Regression
Scenario Outline: 76047-Verify the first 100 saved adddresses associated to the customer are displayed when I enter a value in the Select or search for a saved destination field in the Shipping To section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrive on the <Customer> Add Shipment - (LTL) page for <UserType> user
When I enter a value on the Select or search for a saved destination field as <Searchtext> in the Shipping To section
Then I should see the first hundred saved addresses in the Shipping To section that contains the value entered  <Customer>,<Searchtext> 
Examples: 
| UserType | Customer                 | Searchtext |
| External | ZZZ - GS Customer Test   |            |
| Internal | ZZZ - Czar Customer Test |            |
| Sales    | ZZZ - GS Demo            |            |


@Regression
Scenario Outline: 76047-Verify the auto population of data when I select a saved address from the Select or search for a saved destination field in the Shipping To section
Given I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner <UserType> user
And I arrive on the <Customer> Add Shipment - (LTL) page for <UserType> user
When a saved address is selected from the Select or search for a saved destination field in the Shipping To section
Then all the fields in the Shipping To section should be auto populated with the saved address information associated to the <Customer>
And I should be unable to select another saved address in the Shipping To section
And I am able to edit all other fields in the Shipping To section <Destname>,<DestAddr1>,<DestAddr2>,<Destzipcode>,<DestCity>,<DestCountry>,<DestState>,<DestContactName>,<DestContactEmail>,<DestPhoneNumber>,<DestFaxNumber>,<DestComments>
Examples: 
| UserType | Customer                 | Destname    | DestAddr1       | DestAddr2    | Destzipcode | DestCity | DestCountry   | DestState | DestContactName | DestContactEmail     | DestPhoneNumber | DestFaxNumber  | DestComments |
| External | ZZZ - GS Customer Test   | HoneyPark   | Addressline1    | Addressline2 | 33126       | Miami    | United States | FL        | czarTestingName | czarTesting@test.com | (777) 777-7777  | (777) 123-7777 | Testing      |
| Internal | ZZZ - Czar Customer Test | Go Shopping | 123 S Rodeo Dr  | Parkway      | 85282       | Tempe    | United States | AZ        | GsTestingName   | GsTesting@test.com   | (888) 888-8888  | (888) 000-8888 | Testing      |
| Sales    | ZZZ - GS Demo            | 1231        | 123 street lane | Waterpark    | 94538       | Fremont  | United States | CA        | DemoTestingname | DemoTesting@test.com | (888) 888-1234  | (235) 888-1234 | Testing      |
