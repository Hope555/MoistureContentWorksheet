using System;

namespace MoistureContentProject
{
    public class MoistureContent
    {
        public MoistureContent() { }
        
        public string Balance { get; set; }

        public string TareID { get; set; }

        public double? TareMass { get; set; }

        public double? TareAndMaterialWetMass { get; set; }

        public string DryMassBalance
        {
            get
            {
                return Balance;
            }
        }

        public double? TareAndMaterialDryMass { get; set; }

        public WarningMessage TareMassWarningMessage
        {
            get
            {
                WarningMessage tareMassWarningMessage = new WarningMessage("TareMass", TareMass, TareAndMaterialWetMass, TareAndMaterialDryMass);
                return tareMassWarningMessage;
            }
        }

        public WarningMessage TareAndMaterialWetMassWarningMessage
        {
            get
            {
                WarningMessage tareAndMaterialWetMassWarningMessage = new WarningMessage("TareAndMaterialWetMass", TareMass, TareAndMaterialWetMass, TareAndMaterialDryMass);
                return tareAndMaterialWetMassWarningMessage;
            }
        }

        public WarningMessage TareAndMaterialDryMassWarningMessage
        {
            get
            {
                WarningMessage tareAndMaterialDryMassWarningMessage = new WarningMessage("TareAndMaterialDryMass", TareMass, TareAndMaterialWetMass, TareAndMaterialDryMass);
                return tareAndMaterialDryMassWarningMessage;
            }
        }

        public double? MaterialWetMass
        {
            get
            {
                if (IsDanger())
                {
                    return null;
                }
                else
                {
                    return CalculateMaterialWetMass();
                }
            }
        }

        public double? MaterialDryMass
        {
            get
            {
                if (IsDanger())
                {
                    return null;
                }
                else
                {
                    return CalculateMaterialDryMass();
                }
            }
        }

        public double? WaterContent
        {
            get
            {
                if (IsDanger())
                {
                    return null;
                }
                else
                {
                    return CalculateWaterContent();
                }
            }
        }

        private bool IsDanger()
        {
            if (TareMassWarningMessage.Severity == "Danger"
                || TareAndMaterialWetMassWarningMessage.Severity == "Danger"
                || TareAndMaterialDryMassWarningMessage.Severity == "Danger")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double? CalculateMaterialWetMass()
        {
            return TareAndMaterialWetMass - TareMass;
        }

        private double? CalculateMaterialDryMass()
        {
            return TareAndMaterialDryMass - TareMass;
        }

        private double? CalculateWaterContent()
        {
            double? result = (TareAndMaterialWetMass - TareAndMaterialDryMass) / MaterialDryMass * 100;
            return Math.Round((double)result, 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
