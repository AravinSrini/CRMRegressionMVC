using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.CommonMethods
{
    public class BumpSurgeAllStationDisplay : MaintenaceTools
    {
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();

        public void GetBumpSurgeAllStationDisplay()
        {

            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            List<string> ExpStations = new List<string>();
            List<string> Stations = DBHelper.GetAllStationName();
            foreach (var v in Stations)
            {
                ExpStations.Add(v);
            }
            for (int j = 0; j <= ExpStations.Count; j++)
            {
                BumpSurgeStationSetUp setup = DBHelper.GetSurgeBumpStationDB(OneCarrierUI, ExpStations[j]);
                bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
                bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
                if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
                {

                    Report.WriteLine("Bump value is saved in Station Database");
                    string BumpUI = Gettext(attributeName_xpath, FirstBumpValue_Xpath);
                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpUI);
                    Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");


                    Report.WriteLine("Surge value is saved in Station Database");
                    string SurgeUI = Gettext(attributeName_xpath, FirstSurgeValue_Xpath);
                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeUI);
                    Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");

                }
                else if ((bumpSurgeCalculationModel.Bump == 0 && bumpSurgeCalculationModel.Surge == 0))
                {
                    string BumpUI = Gettext(attributeName_xpath, FirstBumpValue_Xpath);
                    string SurgeUI = Gettext(attributeName_xpath, FirstSurgeValue_Xpath);

                    if (BumpUI == "NONE" && SurgeUI == "NONE")
                    {
                        Report.WriteLine("Bump and Surge value does not exists for the carrier");
                    }
                    else if (BumpUI == "NONE" || SurgeUI == "NONE")
                    {
                        Report.WriteLine("Bump or Surge value does not exists for the carrier");
                    }
                    else
                    {
                        IsElementDisabled(attributeName_xpath, CarrierOne_Xpath, OneCarrierUI);
                        Report.WriteLine("Bump and Surge value is not updated since its excluded carrier");
                    }
                }

                else
                {
                    Report.WriteFailure("The entered Bump or surge values does not exists in database");
                    Assert.Fail();
                }
            }
        }
    }
}
