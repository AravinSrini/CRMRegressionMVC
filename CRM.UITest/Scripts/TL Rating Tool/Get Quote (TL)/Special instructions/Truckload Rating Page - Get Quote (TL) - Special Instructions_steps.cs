using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Special_instructions
{
    [Binding]
    public sealed class Truckload_Rating_Page___Get_Quote__TL____Special_Instructions_steps : TruckloadRatingTool
    {
        
        [Then(@"I must be able to pass (.*) to the Special Instructions free form text field")]
        public void ThenIMustBeAbleToPassToTheSpecialInstructionsFreeFormTextField(string Data)
        {
            Report.WriteLine("Passing values to Special Instructions field");
            SendKeys(attributeName_xpath, TL_SpecialInstructions_Xpath, Data);
        }

    }
}
