using CRM.UITest.Helper.DataModels;

namespace CRM.UITest.CommonMethods
{
    public class SurgeAndBumpCaluclationsClass
    {
        public FinalBumpSurgeCalculationModel SurgeBumpCaluclation(BumpSurgeCalculationModel bumpSurgeCalculationModel)
        {
            FinalBumpSurgeCalculationModel finalModel = new FinalBumpSurgeCalculationModel()
            {
                LineHaul = bumpSurgeCalculationModel.BreakOutLineHaul,
                Fuel = bumpSurgeCalculationModel.BreakOutFuel,
                Total = bumpSurgeCalculationModel.BreakOutTotal,
                FuelSurgeCharge = bumpSurgeCalculationModel.FuelSurgeCharge
            };

            if (bumpSurgeCalculationModel.Bump > 0)
            {

                finalModel.Total = bumpSurgeCalculationModel.BumpTotal = bumpSurgeCalculationModel.BreakOutTotal * (1 + bumpSurgeCalculationModel.Bump);

                finalModel.LineHaul = bumpSurgeCalculationModel.BumpLineHaul = (bumpSurgeCalculationModel.BumpTotal - bumpSurgeCalculationModel.BreakOutAccessorialsTotal) / (1 + (bumpSurgeCalculationModel.FuelSurgeCharge / 100));

                finalModel.Fuel = bumpSurgeCalculationModel.BumpFuel = bumpSurgeCalculationModel.BumpLineHaul * (bumpSurgeCalculationModel.FuelSurgeCharge / 100);

            }

            if (bumpSurgeCalculationModel.Surge > 0)
            {
                if (bumpSurgeCalculationModel.Bump > 0)
                {
                    finalModel.Total = bumpSurgeCalculationModel.SurgeBumpTotal = bumpSurgeCalculationModel.BumpTotal * (1 + bumpSurgeCalculationModel.Surge);

                    finalModel.LineHaul = bumpSurgeCalculationModel.SurgeBumpLineHaul = (bumpSurgeCalculationModel.SurgeBumpTotal - bumpSurgeCalculationModel.BreakOutAccessorialsTotal) / (1 + (bumpSurgeCalculationModel.FuelSurgeCharge / 100));

                    finalModel.Fuel = bumpSurgeCalculationModel.SurgeBumpFuel = bumpSurgeCalculationModel.SurgeBumpLineHaul * (bumpSurgeCalculationModel.FuelSurgeCharge / 100);
                }
                else
                {
                    finalModel.Total = bumpSurgeCalculationModel.SurgeTotal = bumpSurgeCalculationModel.BreakOutTotal * (1 + bumpSurgeCalculationModel.Surge);

                    finalModel.LineHaul = bumpSurgeCalculationModel.SurgeLineHaul = (bumpSurgeCalculationModel.SurgeTotal - bumpSurgeCalculationModel.BreakOutAccessorialsTotal) / (1 + (bumpSurgeCalculationModel.FuelSurgeCharge / 100));

                    finalModel.Fuel = bumpSurgeCalculationModel.SurgeFuel = bumpSurgeCalculationModel.SurgeLineHaul * (bumpSurgeCalculationModel.FuelSurgeCharge / 100);

                }
            }

            return finalModel;

        }
    }
}
