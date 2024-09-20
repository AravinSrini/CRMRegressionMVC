@46938 @Sprint85 @Functional

Feature: 46938_ConfigureAccessorials-LTL_DisplayAccessorial_Quote
	
@Regression
Scenario:46938-Verify accessorial under accessorial drop down list in the Shipping From section on the Get Quote (LTL) page when accessorial was added and designated to be applied in the Shipping From
Given that I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And An accessorial was added on the Configure Accessorials page
And the accessorial was designated to be applied to <LTL> service types
And the accessorial was designated to be applied in the <Ship From> section
And I am on the Get Quote (LTL) page
When I click in the <Click to add services & accessorials...> field in the <Ship From> section
Then I will see the accessorial displayed in the drop down list <Ship From>

@Regression
Scenario:46938-Verify accessorial under accessorial drop down list in the Shipping To section on the Get Quote (LTL) page when accessorial was added and designated to be applied in the Shipping To
Given that I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And An accessorial was added on the Configure Accessorials page
And the accessorial was designated to be applied to <LTL> service types
And the accessorial was designated to be applied in the <Ship To> section
And I am on the Get Quote (LTL) page
When I click in the <Click to add services & accessorials...> field in the <Ship To> section
Then I will see the accessorial displayed in the drop down list <Ship To>

@Regression
Scenario:46938-Verify accessorial will not be displayed under accessorial drop down list in the Shipping To section on the Get Quote (LTL) page when accessorial was added and designated to be applied in the Shipping From
Given that I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And An accessorial was added on the Configure Accessorials page
And the accessorial was designated to be applied to <LTL> service types
And the accessorial was designated to be applied in the <Ship From> section
And I am on the Get Quote (LTL) page
When I click in the <Click to add services & accessorials...> field in the <Ship To> section
Then I will not see the accessorial displayed in the drop down list <Ship To>

@Regression
Scenario:46938-Verify accessorial will not be displayed under accessorial drop down list in the Shipping From section on the Get Quote (LTL) page when accessorial was added and designated to be applied in the Shipping To
Given that I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And An accessorial was added on the Configure Accessorials page
And the accessorial was designated to be applied to <LTL> service types
And the accessorial was designated to be applied in the <Ship To> section
And I am on the Get Quote (LTL) page
When I click in the <Click to add services & accessorials...> field in the <Ship From> section
Then I will not see the accessorial displayed in the drop down list <Ship From>

@Regression
Scenario:46938-Verify accessorial under accessorial drop down list on the Get Quote (LTL) page when accessorial was added and designated to be applied in Both
Given that I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And An accessorial was added on the Configure Accessorials page
And the accessorial was designated to be applied to <LTL> service types
And the accessorial was designated to be applied in the <Both> section
And I am on the Get Quote (LTL) page
When I click in the <Click to add services & accessorials...> field in the <Both> section
Then I will see the accessorial displayed in the drop down list <Both>


@Regression
Scenario:LAst)46938-Verify CRM will send new Service Code to MG and will receive one of the associated EDI Codes in response
Given that I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user
And An accessorial was added on the Configure Accessorials page
And the accessorial was designated to be applied to <LTL> service types
And I am submitting an LTL quote <Ship To>
And I selected an accessorial that was created on the Configure Accessorials page
When I click on the <View Quote Results> button on the Get Quote (LTL) page
Then CRM will send the new Service Code
And CRM will receive one of the associated EDI Codes in response
