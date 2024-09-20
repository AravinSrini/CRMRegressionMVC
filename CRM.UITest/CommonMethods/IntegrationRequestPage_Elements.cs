using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.CommonMethods
{
    public class IntegrationRequestPage_Elements :Integration
    {
        public void IntegrationRequstPagePassElements(string Station, string CompanyName, string CompanyContactName, string CompanyContactPhone, string CompanyContactEmail, string ITDeveloperContactName, string ITDeveloperContactPhone, string ITDeveloperContactEmail, string TypeOfIntegration)
        {
            Click(attributeName_id, IntegrationStaionDropdown_Id);
            SelectDropdownValueFromList(attributeName_xpath, IntegrationStationDropdownValues_Xpath, Station);
            SendKeys(attributeName_id, IntegrationCompanyName_Textbox_Id, CompanyName);
            Report.WriteLine("Passed valid Company name to Company name Field");
            SendKeys(attributeName_id, IntegrationCompanyContactName_Textbox_Id, CompanyContactName);
            Report.WriteLine("Passed valid Company contact name to Company contact name Field");
            SendKeys(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, CompanyContactPhone);
            Report.WriteLine("Passed valid Contact Phone number to Company contact phone Field");
            SendKeys(attributeName_id, IntegrationDevContactName_Textbox_Id, ITDeveloperContactName);
            Report.WriteLine("Passed valid IT/DEV Contact name to IT/DEV Contact name Field");
            SendKeys(attributeName_id, IntegrationDevContactPhone_Textbox_Id, ITDeveloperContactPhone);
            Report.WriteLine("Passed valid Contact Phone number Id to  IT/DEV Contact Phone Field");
            Click(attributeName_id, IntegrationStartDatePicker_Id);
            DatePickerFromCalander(attributeName_xpath, IntegrationDateSelection_Xpath, 3, IntegrationDateMonth_Xpath);
            Report.WriteLine("Date is selected");
            Click(attributeName_id, IntegrationTypeOfIntegration_MultiSelectBox_Id);
            SelectDropdownValueFromList(attributeName_xpath, IntegrationTypeOfIntegration_DropdownValues_Xpath, TypeOfIntegration);
            Report.WriteLine("Selected Integration type from multi select dropdown list");
        }
    }
}
