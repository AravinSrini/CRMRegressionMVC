@Sprint78 @41371
Feature:New CRM User - Claims Specialist

@Functional @Acceptance
Scenario: 41371_Verify the new user with only claim specialist role
Given I am a Claims Specialist user
When I do not belong to any other CRM Roles
Then I will arrive on the Claims List page

@Functional 
Scenario: 41371_Verify the new user of both claim specialist and crm roles_Externalusers
Given I am a Claims Specialist user with external user roles
When I belong to other CRM external user Roles
Then I will arrive on CRM Dashboard page for shipments

@Functional 
Scenario: 41371_Verify the new user of both claim specialist and crm roles_Internalusers
Given I am a Claims Specialist user with internal user roles
When I belong to other CRM internal user Roles
Then I will arrive on CRM Dashboard page for CSR's
