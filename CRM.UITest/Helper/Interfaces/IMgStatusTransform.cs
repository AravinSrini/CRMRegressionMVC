namespace CRM.UITest.Helper.Interfaces
{
    public interface IMgStatusTransform
    {
        /// <summary>
        /// Transform the MG Shipment Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>The Transformed Status</returns>
        string Transform(string status);
    }
}
