using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoistureContentProject;

namespace MoistureContentTestProject
{
    [TestClass]
    public class WarningMessageTest
    {
        [TestMethod]
        public void TareMassWarningMessage_GenerateWithValidNumber()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareMassWarningMessage;

            // Expected
            WarningMessage expected = new WarningMessage();

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareMassWarningMessage_GenerateWithNull()
        {
            // Actual
            double? tareMass = null;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareMassWarningMessage;

            // Expected
            string message = "Tare mass is expected, a missing tare mass may indicate an issue with the result.";
            string severity = "Warning";
            WarningMessage expected = new WarningMessage(message, severity);

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareMassWarningMessage_GenerateWithZero()
        {
            // Actual
            double tareMass = 0;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareMassWarningMessage;

            // Expected
            string message = "A 0 tare mass may indicate an issue with the result.";
            string severity = "Warning";
            WarningMessage expected = new WarningMessage(message, severity);

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareMassWarningMessage_GenerateWithNegativeNumber()
        {
            // Actual
            double tareMass = -300;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareMassWarningMessage;

            // Expected
            string message = "Tare mass cannot be less than 0.";
            string severity = "Danger";
            WarningMessage expected = new WarningMessage(message, severity);

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareAndMaterialWetMassWarningMessage_GenerateWithValidNumber()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareAndMaterialWetMassWarningMessage;

            // Expected
            WarningMessage expected = new WarningMessage();

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare and material wet mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare and material wet mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareAndMaterialWetMassWarningMessage_GenerateWithNegativeNumber()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = -2859.6;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareAndMaterialWetMassWarningMessage;

            // Expected
            string message = "Tare and material wet mass cannot be less than 0.";
            string severity = "Danger";
            WarningMessage expected = new WarningMessage(message, severity);

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare and material wet mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare and material wet mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareAndMaterialWetMassWarningMessage_GenerateWithNumberLessThanOrEqualToTareMess()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = 100;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareAndMaterialWetMassWarningMessage;

            // Expected
            string message = "Tare and material wet mass must be greater than tare mass.";
            string severity = "Danger";
            WarningMessage expected = new WarningMessage(message, severity);

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare and material wet mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare and material wet mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareAndMaterialDryMassWarningMessage_GenerateWithValidNumber()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareAndMaterialDryMassWarningMessage;

            // Expected
            WarningMessage expected = new WarningMessage();

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare and material dry mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare and material dry mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareAndMaterialDryMassWarningMessage_GenerateWithNegativeNumber()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = -2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareAndMaterialDryMassWarningMessage;

            // Expected
            string message = "Tare and material dry mass cannot be less than 0.";
            string severity = "Danger";
            WarningMessage expected = new WarningMessage(message, severity);

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare and material dry mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare and material dry mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareAndMaterialDryMassWarningMessage_GenerateWithNumberLessOrEqualToTareMess()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 100;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareAndMaterialDryMassWarningMessage;

            // Expected
            string message = "Tare and material dry mass must be greater than tare mass.";
            string severity = "Danger";
            WarningMessage expected = new WarningMessage(message, severity);

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare and material dry mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare and material dry mass warning message not generated correctly");
        }

        [TestMethod]
        public void TareAndMaterialDryMassWarningMessage_GenerateWithNumberLargerThanTareAndMaterialWetMess()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 3525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            WarningMessage actual = moistureContent.TareAndMaterialDryMassWarningMessage;

            // Expected
            string message = "Tare and material dry mass cannot be greater than Tare and material wet mass.";
            string severity = "Danger";
            WarningMessage expected = new WarningMessage(message, severity);

            // Assert
            Assert.AreEqual(expected.Severity, actual.Severity, "Tare and material dry mass warning message not generated correctly");
            Assert.AreEqual(expected.Message, actual.Message, "Tare and material dry mass warning message not generated correctly");
        }
    }
}
