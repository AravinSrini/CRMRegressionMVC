@Sprint2_Ninja @30367
Feature: CRMLoginPage_Remove_BecomePartnerLink

@GUI
Scenario Outline: Verify the link in login page for different url
	Given I am any user and launch <URL>
	When I am on the landing page '<HomepageText>'
	Then I will no longer see the Become a DLS Worldwide Partner Today Link <URL>

Examples: 
| Scenario | URL                         | HomepageText                                 |
| S1       | http://dlsw-test.rrd.com/   | Track Up to 10 Shipments by Reference Number |
| S2       | http://dlsww-test.rrd.com/  | Track Up to 10 Shipments by Reference Number |
| S3       | http://dls-ww-test.rrd.com/ | Track Up to 10 Shipments by Reference Number |
