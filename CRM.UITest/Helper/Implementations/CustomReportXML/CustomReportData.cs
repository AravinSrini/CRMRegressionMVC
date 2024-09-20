using CRM.UITest.Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CRM.UITest.Helper.Implementations.CustomReportXML
{
    public class CustomReportData
    {
        public CustomReportViewModel GetCustomReportList(string Useremail, string ServiceType, string RefNumber, string StardDate, string Enddate, string OrgCity, string DestCity, string Status, string APIReport)
        {
            List<string> _status = new List<string>() { Status };
            List<string> _serviceType = new List<string>() { ServiceType };
            
            CultureInfo ci = CultureInfo.InvariantCulture;
            DateTime _startdate = DateTime.ParseExact(StardDate, "MM/dd/yyyy", ci);
            DateTime _Enddate = DateTime.ParseExact(Enddate, "MM/dd/yyyy", ci);

            CustomReportViewModel li = new CustomReportViewModel()
            {
                UserEmail = Useremail,
                ReportName = APIReport,
                OriginCity = OrgCity,
                DestinationCity = DestCity,
                ReferenceNumbers = RefNumber,
                PickUpDateStart = _startdate,
                PickUpDateEnd = _Enddate,
                Status = _status,
                ShipmentServiceTypes = _serviceType
            };

            return li;
        }
    }
}
