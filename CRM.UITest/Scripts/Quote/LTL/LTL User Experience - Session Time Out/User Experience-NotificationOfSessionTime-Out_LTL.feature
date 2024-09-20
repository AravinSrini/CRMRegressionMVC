@UserExperienceNotificationofSessionTimeOut_LTL @19220 @Sprint62
Feature: UserExperienceNotificationofSessionTimeOut_LTL

#
#@GUI @Acceptance 
#Scenario Outline: Verify warning Notification Session Time-Out PopUp at 14th minute
#    Given I am a DLS user and login into application with valid <Username> and <Password>
#	And I clicked on <Service> button on the select type screen of rate request process
#	When   I am inactive for Fourteen minutes
#	Then  I will receive a notification saying that my session will terminate in one minute due to inactivity 
#
#	Examples: 
#| Scenario | Username            | Password | Service | 
#| S1       | zzz				 | Te$t1234 | LTL	  |


@Regression 
Scenario Outline: Verify warning Notification Session Time-Out PopUp at 14th minute and the Yes or Cancel button present on LTL page
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When   I am inactive for Fourteen minutes
	Then  I will receive a notification saying that my session will terminate in one minute due to inactivity
	And   I will be able to see Yes and Cancel button in the PopUp

	Examples: 
| Scenario | Username            | Password | Service | 
| S1       | zzz				 | Te$t1234 | LTL	  |


@Regression 
Scenario Outline: Verify User redirected to the CRM Landing Page when Click on Yes button in warning Time-Out PopUp inorder to terminate the session on LTL page
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When   I am inactive for Fourteen minutes 
	Then  I will receive a notification saying that my session will terminate in one minute due to inactivity
	And   I Click on Yes button in the Notification PopUp
	And   I will be redirecting to CRM Landing Page

	Examples: 
| Scenario | Username            | Password | Service | 
| S1       | zzz				 | Te$t1234 | LTL	  |

@Regression 
Scenario Outline: Verify User remains in same active page when Click on Cancel button in the warning Notification Session Time-Out PopUp  
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When   I am inactive for Fourteen minutes 
	Then  I will receive a notification saying that my session will terminate in one minute due to inactivity
	And   I Click on No button in the Notification PopUp 
	And   I will remain in the same active page and my session will be continued in Shipment Information Page

	Examples: 
| Scenario | Username            | Password | Service | 
| S1       | zzz				 | Te$t1234 | LTL	  |

@Regression 
Scenario Outline: Verify the text message in the warning Notification Session Time-Out PopUp
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When   I am inactive for Fourteen minutes 
	Then  I will receive a notification saying that my session will terminate in one minute due to inactivity
	And   I can see warning message which notify to user that session is going to expire in one minute
	Then   I am inactive for another one more minute
	And  I will receive a logout popup says that session has been expired due to inactivity 

	Examples: 
| Scenario | Username            | Password | Service | 
| S1       | zzz				 | Te$t1234 | LTL	  |

#@GUI @Acceptance 
#Scenario Outline: Verify logout PopUp at 15th minute if the user does not select any option 
#    Given I am a DLS user and login into application with valid <Username> and <Password>
#	And I clicked on <Service> button on the select type screen of rate request process
#	When   I am inactive for Fourteen minutes
#	Then   I am inactive for another one more minute
#	And  I will receive a logout popup says that session has been expired due to inactivity 
#
#	Examples: 
#| Scenario | Username            | Password | Service | 
#| S1       | zzz				 | Te$t1234 | LTL	  |

@Regression 
Scenario Outline: Verify the Ok button in logout PopUp and its functionality
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When   I am inactive for Fourteen minutes
	Then   I am inactive for another one more minute
	And  I will receive a notification says that session has been expired due to inactivity 
	And   I will be able to see OK button in pop up
	And  I have clicked on OK button
	And   I will be redirecting to CRM Landing Page

	Examples: 
| Scenario | Username            | Password | Service | 
| S1       | zzz				 | Te$t1234 | LTL	  |