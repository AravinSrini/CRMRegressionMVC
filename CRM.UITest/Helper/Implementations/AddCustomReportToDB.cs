using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Interfaces;
using System;


namespace CRM.UITest.Helper.Implementations
{
    public class AddCustomReportToDB : IAddCustomReportToDB
    {
        public void AddCustomReport(CustomReport report)
        {
            DBHelper.AddCustomReportToDb(report);
            int reportId = DBHelper.GetCustomReportId(report.CreatedBy, report.CustomReportName);
            UserCustomReportsMapping userCustomReportsMapping = generateUserCustomReportsMapping(reportId, report.CreatedBy);
            DBHelper.AddUserCustomReportsMappingToDB(userCustomReportsMapping);
        }

        private UserCustomReportsMapping generateUserCustomReportsMapping(int reportId, string createdBy)
        {
            UserCustomReportsMapping userCustomReportsMapping = new UserCustomReportsMapping()
            {
                CreatedBy = createdBy,
                CreatedDate = DateTime.Now,
                CustomReportId = reportId,
                UserEmail = createdBy
            };

            return userCustomReportsMapping;
        }
    }
}
