@Sprint75 @35644 
Feature: Integration Comments _Add Status Comment_Modal

@GUI
Scenario Outline:35644- Verify the existence of expected elements within Status Comment modal
Given I am a System Admin user <Username>, <Password>
When I click on Add Comment Button
Then I will be presented with the Status Comment Modal
And The modal will contain the following - Header Name,Status,Comment field, Private and public radio buttons,Cancel button and Submit Button

Examples: 
| Username    | Password |
| systemadmin | Te$t1234 |

@Functional
Scenario Outline:35644- Validate Comment field by passing a maximum of 500 characters 
Given I am a System Admin user <Username>, <Password>
When I click on Add Comment Button
Then I must be able to pass a maximun of 500 characters to Comment field within Status Comment modal <Comment>

Examples: 
| Username    | Password | Comment                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| systemadmin | Te$t1234 | WSDA 463254 HGDSFHC HFGE YEWG 23JH hdsdh fhegf 635rbe  rhgwef hdgfds bnfvesfd yfgdshc ddsbfyeg 6rre yrt34bd fs feyryehjfsd yy4t dfyewfe 64f dfj 67efe yfgewf gfy ut4357dvcds det4356375632 hsgdhsdhds hsgdufh7t64 fgewjhdfw 6324dbwhjd 763453gefb sd76t5yeedb c ydsc  yu543 56478bs 7864b!@#$% )(*&^ ~!@c 6574  fhg}{">":yfe hgsd 6532 hgdsvfyes6 bghdsahd  46532 hggsvh 13 )(*BGHBCFT 47325 dghgds $$% ysfaw++_)+ wfdy ytdfys yfwqe6r3632 dfewgdv ggfwe 6734t32 6rdhb 63rtyds 7r6wghsgf twefh 67432 6r3rvsj uygduew |

@Functional
Scenario Outline:35644- Validate Comment field by passing more than 500 characters
Given I am a System Admin user <Username>, <Password>
When I click on Add Comment Button
Then I must not be able to pass more than 500 characters to Comment field within Status Comment modal <Comment>

Examples: 
| Username    | Password | Comment                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| systemadmin | Te$t1234 | WSDA 463254 HGDSFHC HFGE YEWG 23JH hdsdh fhegf 635rbe  rhgwef hdgfds bnfvesfd yfgdshc ddsbfyeg 6rre yrt34bd fs feyryehjfsd yy4t dfyewfe 64f dfj 67efe yfgewf gfy ut4357dvcds det4356375632 hsgdhsdhds hsgdufh7t64 fgewjhdfw 6324dbwhjd 763453gefb sd76t5yeedb c ydsc  yu543 56478bs 7864b!@#$% )(*&^ ~!@c 6574  fhg}{">":yfe hgsd 6532 hgdsvfyes6 bghdsahd  46532 hggsvh 13 )(*BGHBCFT 47325 dghgds $$% ysfaw++_)+ wfdy ytdfys yfwqe6r3632 dfewgdv ggfwe 6734t32 6rdhb 63rtyds 7r6wghsgf twefh 67432 6r3rvsj uygduew ywetuwjxc |

@GUI
Scenario Outline:35644- Verify if Private radio button is selected by default within Status Comment modal
Given I am a System Admin user <Username>, <Password>
When I click on Add Comment Button
Then I must be able to view Private radio button been selected by default

Examples: 
| Username    | Password |
| systemadmin | Te$t1234 |

@Functional
Scenario Outline:35644- Verify the functionality of Submit Button within Status Comment modal
Given I am a System Admin user <Username>, <Password>
When I click on Add Comment Button
And I enter value to required field <Comment>
And I click on the Submit Button
Then The comment should be saved with a time stamp - <StationName>,<Comment>

Examples: 
| Username    | Password | Comment    | StationName             |
| systemadmin | Te$t1234 | dsdchsnytr | ZZZ - Web Services List |

@Functional
Scenario Outline: 35644-Verify the functionality of Cancel button within Status Comment modal
Given I am a System Admin user <Username>, <Password>
When I click on Add Comment Button
And I enter value to required field <Comment>
And I click on the cancel button
Then I should return to the Integration Request List page.

Examples: 
| Username    | Password | Comment |
| systemadmin | Te$t1234 | dsdchsn |

@Functional @GUI
Scenario Outline: 35644-Verify Status on Add comments modal
Given I am a System Admin user <Username>, <Password>
When I click on Add Comment Button of the selected request
Then The Status on the comments modal should match with the Integration status

Examples: 
| Username    | Password | 
| systemadmin | Te$t1234 | 