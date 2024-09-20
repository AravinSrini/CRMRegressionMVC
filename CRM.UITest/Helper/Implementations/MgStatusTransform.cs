
using CRM.UITest.Helper.Interfaces;

namespace CRM.UITest.Helper.Implementations
{
    public class MgStatusTransform : IMgStatusTransform
	{
		/// <summary>
		/// Transform the MG Shipment Status
		/// </summary>
		/// <param name="status"></param>
		/// <returns>The Transformed Status</returns>
		public string Transform(string status)
		{
			switch (status.ToUpper())
			{
				case "CANCELLED":
					{
						status = "Cancelled";
						break;
					}
				case "DELIVERED":
					{
						status = "Delivered";
						break;
					}
				case "IN TRANSIT":
					{
						status = "In Transit";
						break;
					}
				case "BOOKED":
					{
						status = "Booked";
						break;
					}
				case "PENDING":
				case "RATED":
				case "REJECTED":
				case "TENDERED":
				case "PRE-PLAN":
					{
						status = "Pending";
						break;
					}
			}

			return status;
		}
	}
}