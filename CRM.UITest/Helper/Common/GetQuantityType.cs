using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Common
{
    public class GetQuantityType
    {
        string quantity = null;
        public string Getquantity(string quanValue)
        {
            if (quanValue == "BAG")
            {
                return quantity = "Bag";
            }
            else if (quanValue == "BDL")
            {
                return quantity = "Bundles";
            }
            else if (quanValue == "BOX")
            {
                return quantity = "Boxes";
            }
            else if (quanValue == "CAB")
            {
                return quantity = "Cabinets";
            }
            else if (quanValue == "CAN")
            {
                return quantity = "Cans";
            }
            else if (quanValue == "CAS")
            {
                return quantity = "Cases";
            }
            else if (quanValue == "CRT")
            {
                return quantity = "Crates";
            }
            else if (quanValue == "CTN")
            {
                return quantity = "Cartons";
            }
            else if (quanValue == "CYL")
            {
                return quantity = "Cylinders";
            }
            else if (quanValue == "DRM")
            {
                return quantity = "Drums";
            }
            else if (quanValue == "PAL")
            {
                return quantity = "Pails";
            }
            else if (quanValue == "PCS")
            {
                return quantity = "Pieces";
            }
            else if (quanValue == "PLT")
            {
                return quantity = "Pallets";
            }
            else if (quanValue == "RCK")
            {
                return quantity = "Flat Racks";
            }
            else if (quanValue == "REL")
            {
                return quantity = "Reels";
            }
            else if (quanValue == "ROL")
            {
                return quantity = "Rolls";
            }
            else if (quanValue == "SKD")
            {
                return quantity = "Skids";
            }
            else if (quanValue == "SLP")
            {
                return quantity = "Slip Sheets";
            }
            else if (quanValue == "STK")
            {
                return quantity = "Stacks";
            }
            else if (quanValue == "TBN")
            {
                return quantity = "Totes";
            }
            else
            {
                return null;
            }
        }
    }
}

