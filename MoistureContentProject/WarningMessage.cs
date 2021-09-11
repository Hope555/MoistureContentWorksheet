using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoistureContentProject
{
    public class WarningMessage
    {
        private string _message = "";
        private string _severity = "No";
        
        public WarningMessage() { }

        public WarningMessage(string message, string severity)
        {
            _message = message;
            _severity = severity;
        }

        public WarningMessage(string fieldName, double? tareMass, double? tareAndMaterialWetMass, double? tareAndMaterialDryMass)
        {
            switch (fieldName)
            {
                case "TareMass":
                    GenerateTareMassWarningMessage(tareMass, tareAndMaterialWetMass, tareAndMaterialDryMass);
                    break;
                case "TareAndMaterialWetMass":
                    GenerateTareAndMaterialWetMassWarningMessage(tareMass, tareAndMaterialWetMass);
                    break;
                case "TareAndMaterialDryMass":
                    GenerateTareAndMaterialDryMassWarningMessage(tareMass, tareAndMaterialWetMass, tareAndMaterialDryMass);
                    break;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
        }

        public string Severity
        {
            get
            {
                return _severity;
            }
        }

        private void GenerateTareMassWarningMessage(double? tareMass, double? tareAndMaterialWetMass, double? tareAndMaterialDryMass)
        {
            if (tareMass == null)
            {
                if (tareAndMaterialWetMass != null || tareAndMaterialDryMass != null)
                {
                    _message = "Tare mass is expected, a missing tare mass may indicate an issue with the result.";
                    _severity = "Warning";
                }
            }
            else
            {
                if (tareMass == 0)
                {
                    _message = "A 0 tare mass may indicate an issue with the result.";
                    _severity = "Warning";
                }
                else if (tareMass < 0)
                {
                    _message = "Tare mass cannot be less than 0.";
                    _severity = "Danger";
                }
            }
        }

        private void GenerateTareAndMaterialWetMassWarningMessage(double? tareMass, double? tareAndMaterialWetMass)
        {
            if (tareAndMaterialWetMass < 0)
            {
                _message = "Tare and material wet mass cannot be less than 0.";
                _severity = "Danger";
            }
            else
            {
                if (tareAndMaterialWetMass <= tareMass)
                {
                    _message = "Tare and material wet mass must be greater than tare mass.";
                    _severity = "Danger";
                }
            }
        }

        private void GenerateTareAndMaterialDryMassWarningMessage(double? tareMass, double? tareAndMaterialWetMass, double? tareAndMaterialDryMass)
        {
            if (tareAndMaterialDryMass < 0)
            {
                _message = "Tare and material dry mass cannot be less than 0.";
                _severity = "Danger";
            }
            else
            {
                if (tareAndMaterialDryMass <= tareMass)
                {
                    _message = "Tare and material dry mass must be greater than tare mass.";
                    _severity = "Danger";
                    return;
                }
                if (tareAndMaterialDryMass > tareAndMaterialWetMass)
                {
                    _message = "Tare and material dry mass cannot be greater than Tare and material wet mass.";
                    _severity = "Danger";
                }
            }
        }
    }
}
