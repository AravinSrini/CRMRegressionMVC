﻿using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IFuelCosts
    {
        decimal GetFuelCosts(XElement priceSheetElement, CostComponents costComponents, string nodeValue);
    }
}
