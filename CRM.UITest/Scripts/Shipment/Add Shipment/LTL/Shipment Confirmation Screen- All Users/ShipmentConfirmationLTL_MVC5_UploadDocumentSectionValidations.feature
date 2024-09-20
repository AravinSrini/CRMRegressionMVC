@32163 @Sprint71 @Ignore
Feature: ShipmentConfirmationLTL_MVC5_UploadDocumentSectionValidations

@GUI
Scenario Outline: 32163_Verify the error message when user tried to upload the invalid file format
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I am uploading the invalid file <invalidfilepath> 
Then I should be displayed with an error message
And the file should not get uploaded

Examples: 
| Usertype | oAdd2 | oZip  | oName  | oAdd1     | dAdd2 | dName  | dAdd1     | Customer_Name       | oComments | dComments | dZip  | classification | nmfc    | quantity | weight | desc | invalidfilepath                                           |
| External | sdwd  | 60606 | OrName | OrAddress |       | DeName | DeAddress |                     |           |           | 60606 | 55             | qaz123  | 5        | 57     | desc | ../../Scripts/TestData/Testfiles_confirmationupload/1.tif |

@GUI
Scenario Outline: 32163_Verify the error message when user tried to enter more than 70 characters as file name
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I upload the invalid file with name conatins more than the limit <invalidfilepath> 
Then I should be displayed with an error message

Examples: 
| Usertype | oAdd2 | oZip  | oName | oAdd1    | dAdd2 | dName | dAdd1    | Customer_Name            | oComments | dComments | dZip  | classification | nmfc    | quantity | weight | desc | invalidfilepath                                                                                                                                     |
| External | asd   | 77006 | OName | OAddress |       | DName | Daddress |                          |           |           | 60490 | 55             | q123asd | 1        | 1      | desc | ../../Scripts/TestData/Testfiles_confirmationupload/Testinginvalidddddddddddddddddddddddddddddd6788999999999999999sssssssssseeeeeeeeeeedtyrtrt.xlsx |

@GUI
Scenario Outline: 32163_Verify the error message when user tried to upload the file with more than given size
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I tried to upload the invalid file with the limit of more than ten MB <invalidfilepath> 
Then I should be displayed with an error message 
And the file should not get uploaded

Examples: 
| Usertype | oAdd2 | oZip  | oName | oAdd1    | dAdd2 | dName | dAdd1    | Customer_Name       | oComments | dComments | dZip  | classification | nmfc    | quantity | weight | desc | invalidfilepath                                                   |
| External | asd   | 60606 | OName | OAddress |       | DName | Daddress |                     |           |           | 74464 | 55             | q123asd | 1        | 1      | desc | ../../Scripts/TestData/Testfiles_confirmationupload/Edited_v3.mp3 |

@GUI
Scenario Outline: 32163_Verify the upload functionality when user uploaded valid files
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I am uploading valid file <validfilepath>
Then files should get uploaded <filename>
And remove uploaded file <filename>

Examples: 
| Usertype | oAdd2 | oZip  | oName | oAdd1    | dAdd2 | dName | dAdd1    | Customer_Name       | oComments | dComments | dZip  | classification | nmfc    | quantity | weight | desc | validfilepath                                                             | filename              |
| External | asd   | 60606 | OName | OAddress |       | DName | Daddress |                     |           |           | 60606 | 55             | q123asd | 1        | 1      | desc | ../../Scripts/TestData/Testfiles_confirmationupload/ErrorMessagesSwa.docx | ErrorMessagesSwa.docx |

@GUI
Scenario Outline: 32163_Verify the upload functionality when user tried to upload more than the max limit of valid files
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I am uploading valid files more than the limit <files> 
Then I should be displayed with an error message of Maximum file limit
And The files will not be uploaded when they are greater than ten in count
And remove files from docrepodb after the execution '<files>'

Examples: 
| Usertype | oAdd2   | oZip  | oName | oAdd1    | dAdd2 | dName | dAdd1    | Customer_Name | oComments | dComments | dZip  | classification | nmfc   | quantity | weight | desc | files                                                                                                                                                                                                  |
| External | wduewif | 33126 | OName | OAddress |       | DName | Daddress |               |           |           | 60606 | 65             | ii7678 | 4        | 10     | desc | 2016 year in review.pdf,Book1.xls,ClaimsforShipment.PNG,Email BOL_Email.pdf,ErrorMessagesSwa.docx,Tulips.jpg,image.jpg,image001.png,clarification.png,testiiiiiiingCon.doc,Upload Document Errors.docx |

@GUI
Scenario Outline: 32163_Verify the Duplicate file upload functionality
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I upload the valid file <validfilepath>
And Again i am trying to upload the same file with same name in CRM <validfilepath>
Then I should be displayed with an error message
And the file that was previously uploaded in CRM will not be uploaded <filename>
And remove uploaded file '<filename>'

Examples: 
| Usertype | oAdd2   | oZip  | oName | oAdd1    | dAdd2 | dName | dAdd1    | Customer_Name       | oComments | dComments | dZip  | classification | nmfc    | quantity | weight | desc | validfilepath                                                                   | filename                    |
| External | wduewif | 33126 | OName | OAddress |       | DName | Daddress |                     |           |           | 60606 | 65             | ii7678  | 4        | 10     | desc | ../../Scripts/TestData/Testfiles_confirmationupload/Upload Document Errors.docx | Upload Document Errors.docx |
