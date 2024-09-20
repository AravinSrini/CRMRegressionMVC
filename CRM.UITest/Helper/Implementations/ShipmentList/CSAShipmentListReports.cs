using CRM.UITest.CsaServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations.ShipmentList
{
    public class CSAShipmentListReports
    {
        
        CSAShipmentListReports csaShipment=null;

        //To get status for standard report based on report type
        public string StatusParameter(string reportName)
        {
            string status = string.Empty;
            switch (reportName.ToLower())
            {
                case "shipments booked not in transit":
                    status = "DPU";
                    break;
                case "shipments in transit":
                    status = "ALR,COB,COC,DBV,ENR,INT,OHC,OHD,OHO,ADL,OFD,PUP";
                    break;

                case "shipments pending":
                    status = "APT,DPU,NEW,PEN,WEB";
                    break;
            }

            return status;
        }

        //To get start date for standard report
        public string StartDateRange(string reportName)
        {
            DateTime currentDate = DateTime.UtcNow;
            string requiredDate = string.Empty;

            switch (reportName.ToLower())
            {
                case "todays shipments":
                    requiredDate = currentDate.ToString("yyyy-MM-ddT00:00:00");
                    break;
                case "yesterdays shipments":
                    requiredDate = currentDate.AddDays(-1).ToString("yyyy-MM-ddT00:00:00");
                    break;
                case "shipments from current month":
                    requiredDate = new DateTime(currentDate.Year, currentDate.Month, 1).ToString("yyyy-MM-ddT00:00:00");
                    break;
                case "shipments from current week":
                    requiredDate = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday).ToString("yyyy-MM-ddT00:00:00");
                    break;
                case "shipments from previous month":
                    requiredDate = new DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(-1).ToString("yyyy-MM-ddT00:00:00");
                    break;
                case "shipments from previous week":
                    requiredDate = currentDate.AddDays(-(int)(currentDate.DayOfWeek) + (int)DayOfWeek.Monday).AddDays(-7).ToString("yyyy-MM-ddT00:00:00");
                    break;
                case "shipments booked not in transit":
                case "shipments pending":
                case "shipments in transit":
                    requiredDate = currentDate.AddDays(-180).ToString("yyyy-MM-ddT00:00:00");
                    break;
            }
            return requiredDate;

        }

        //To get stop date for standard report
        public string stopDateRange(string reportName)
        {
            DateTime currentDate = DateTime.UtcNow;
            string requiredDate = string.Empty;

            switch (reportName.ToLower())
            {
                case "todays shipments":
                    requiredDate = currentDate.ToString("yyyy-MM-ddT23:59:00");
                    break;
                case "yesterdays shipments":
                    requiredDate = currentDate.AddDays(-1).ToString("yyyy-MM-ddT23:59:00");
                    break;
                case "shipments from current month":
                    requiredDate = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month)).ToString("yyyy-MM-ddT23:59:00");
                    break;
                case "shipments from current week":
                    requiredDate = currentDate.AddDays(-(int)currentDate.DayOfWeek + 1 + (int)DayOfWeek.Saturday).ToString("yyyy-MM-ddT23:59:00");
                    break;
                case "shipments from previous month":
                    requiredDate = new DateTime(currentDate.Year, currentDate.Month, 1).AddDays(-1).ToString("yyyy-MM-ddT23:59:00");
                    break;
                case "shipments from previous week":
                    requiredDate = currentDate.AddDays(-(int)(currentDate.DayOfWeek) + (int)DayOfWeek.Sunday).ToString("yyyy-MM-ddT23:59:00");
                    break;
                case "shipments booked not in transit":
                case "shipments pending":
                    requiredDate = currentDate.AddDays(+60).ToString("yyyy-MM-ddT23:59:00");
                    break;
                case "shipments in transit":
                    requiredDate = currentDate.AddDays(+10).ToString("yyyy-MM-ddT23:59:00");
                    break;
            }

            return requiredDate;
        }

        public ShipmentListReponse GetCSAShipmentListStandardReport(int CSAcustomerNumber, out string errorMessage,string reportName)
        {
            ShipmentListReponse results = null;
            errorMessage = string.Empty;

            //reportName = "CRM-Shipments Unscheduled Agent";
            
            if (reportName.Contains("Shipments In Transit"))
            {
                reportName = "Shipments In Transit";
            }
            else if (reportName.Contains("Shipments Pending"))
            {
                reportName = "Shipments Pending";
            }
            else if(reportName.Contains("Shipments Rated not Tendered"))
            {
                reportName = "Shipments Rated not Tendered";
            }
            else if(reportName.Contains("Shipments Scheduled not Rated"))
            {
                reportName = "Shipments Scheduled not Rated";
            }
            else if(reportName.Contains("Shipments Tendered not Booked"))
            {
                reportName = "Shipments Tendered not Booked";
            }
            else if(reportName.Contains("Shipments Unscheduled"))
            {
                reportName = "Shipments Unscheduled";
            }
            else if(reportName.Contains("Shipments from Current Month"))
            {
                reportName = "Shipments from Current Month";
            }
            else if(reportName.Contains("Shipments from Current Week"))
            {
                reportName = "Shipments from Current Week";
            }
            else if(reportName.Contains("Shipments Booked Not In Transit"))
            {
                reportName = "Shipments Booked Not In Transit";
            }
            else if(reportName.Contains("Shipments from Previous Month"))
            {
                reportName = "Shipments from Previous Month";
            }
            else if(reportName.Contains("Shipments from Previous Week"))
            {
                reportName = "Shipments from Previous Week";
            }
            else if(reportName.Contains("Todays Shipment"))
            {
                reportName = "Todays Shipment";
            }
            else if(reportName.Contains("Yesterdays Shipments"))
            {
                reportName = "Yesterdays Shipments";
            }


            try
            {
                using (ShipmentsSoapClient csaClient = new ShipmentsSoapClient())
                {
                    if (reportName.Contains("CRM-ShpPrev30Days"))
                    {
                        results = csaClient.ShipmentListLast30DaysByCustomer(CSAcustomerNumber);
                    }
                    else
                    {
                        csaShipment = new CSAShipmentListReports();
                        string requiredPickUpDate = csaShipment.StartDateRange(reportName);
                        string requiredDropOffDate = csaShipment.stopDateRange(reportName);
                        string reportstatus = csaShipment.StatusParameter(reportName);

                        //Calling standard reports
                        results = csaClient.ShipmentListParm(CSAcustomerNumber.ToString(), requiredPickUpDate.ToString(), requiredDropOffDate.ToString(), "", "", "", reportstatus, "", "", "", "");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return results;
        }
    }
}
