using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoistureContentProject;

namespace MoistureContentTestProject
{
    [TestClass]
    public class MoistureContentTest
    {
        [TestMethod]
        public void MaterialWetMass_CalculateWithValidNumber()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = 2859.6;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            double actual = (double)moistureContent.MaterialWetMass;
            
            // Expected
            double expected = 2559.6;

            // Assert
            Assert.AreEqual(expected, actual, 0.1, "Material wet mass not calculated correctly");
        }

        [TestMethod]
        public void MaterialWetMass_CalculateWithNull()
        {
            // Actual
            double tareMass = 300;
            double? tareAndMaterialWetMass = null;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            double? actual = moistureContent.MaterialWetMass;

            // Assert
            Assert.IsNull(actual, "Material wet mass not calculated correctly");
        }

        [TestMethod]
        public void MaterialDryMass_CalculateWithValidNumber()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            double actual = (double)moistureContent.MaterialDryMass;

            // Expected
            double expected = 2225.7;

            // Assert
            Assert.AreEqual(expected, actual, 0.1, "Material dry mass not calculated correctly");
        }

        [TestMethod]
        public void MaterialDryMass_CalculateWithNull()
        {
            // Actual
            double tareMass = 300;
            double? tareAndMaterialDryMass = null;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            double? actual = moistureContent.MaterialDryMass;

            // Assert
            Assert.IsNull(actual, "Material dry mass not calculated correctly");
        }

        [TestMethod]
        public void WaterContent_CalculateWithValidNumber()
        {
            // Actual
            double tareMass = 300;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            double actual = (double)moistureContent.WaterContent;

            // Expected
            double expected = 15.0;

            // Assert
            Assert.AreEqual(expected, actual, 0.1, "Water content mass not calculated correctly");
        }

        [TestMethod]
        public void WaterContent_CalculateWithNull()
        {
            // Actual
            double? tareMass = null;
            double tareAndMaterialWetMass = 2859.6;
            double tareAndMaterialDryMass = 2525.7;
            MoistureContent moistureContent = new MoistureContent();
            moistureContent.TareMass = tareMass;
            moistureContent.TareAndMaterialWetMass = tareAndMaterialWetMass;
            moistureContent.TareAndMaterialDryMass = tareAndMaterialDryMass;
            double? actual = moistureContent.MaterialDryMass;

            // Assert
            Assert.IsNull(actual, "Water content mass not calculated correctly");
        }
    }
}
