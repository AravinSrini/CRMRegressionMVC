using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
   public class CaptureTotalRateRequests : ICaptureTotalRateRequests
    {
        private readonly ILogErrorMessage _logErrorMessage;
        private readonly IIncrementTotalRateRequestCount _incrementTotalRateRequestCount;
        private readonly IInsertTotalRateRequestMetrics _insertTotalRateRequestMetrics;
        private readonly IValidateSetupIdInQuoteMetrics _validateSetupIdInQuoteMetrics;
        private readonly IGetCustomerSetupId _getCustomerSetupId;
        private const string errorMessage = "Error occurred while capturing the total rate request";
        public CaptureTotalRateRequests(IIncrementTotalRateRequestCount incrementTotalRateRequestCount,
           IInsertTotalRateRequestMetrics insertTotalRateRequestMetrics,
           IValidateSetupIdInQuoteMetrics validateSetupIdInQuoteMetrics, IGetCustomerSetupId getCustomerSetupId,
           ILogErrorMessage logErrorMessage)
        {
            _incrementTotalRateRequestCount = incrementTotalRateRequestCount;
            _insertTotalRateRequestMetrics = insertTotalRateRequestMetrics;
            _validateSetupIdInQuoteMetrics = validateSetupIdInQuoteMetrics;
            _getCustomerSetupId = getCustomerSetupId;
            _logErrorMessage = logErrorMessage;
        }

        public void CaptureRateRequest(string customerName, string userEmail)
        {
            try
            {
                int setupId = _getCustomerSetupId.GetSetupIdValue(customerName);

                if (setupId > 0)
                {
                    // Check if row exist in "MetricsTransactionTable" for customerSetupId
                    bool isRowExists = _validateSetupIdInQuoteMetrics.ValidateSetupId(setupId);

                    if (isRowExists)
                    {
                        _incrementTotalRateRequestCount.IncrementRateRequestCount(setupId, userEmail);
                    }
                    else
                    {
                        _insertTotalRateRequestMetrics.InsertRateRequest(setupId, userEmail);
                    }
                }
            }
            catch (Exception ex)
            {
                _logErrorMessage.LogMessage(errorMessage, ex.StackTrace);
            }
        }
    }
}
