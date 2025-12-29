using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using ManteHos.Entities;

namespace ManteHosObjectDesignTests
{
    [TestClass]
    public class AreaTest
    {
        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            PropertyInfo property = typeof(Area).GetProperty("Incidents");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Incidents property should be declared virtual.");

            PropertyInfo property1 = typeof(Area).GetProperty("Master");
            Assert.IsTrue(property1.GetMethod.IsVirtual, "Master property should be declared virtual.");

        }
       

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {
            Area area = new Area();

            Assert.IsNotNull(area.Incidents, "Incidents collection not initialized.");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, area.Incidents.Count, "Incidents should be empty after construction.");

        }

        [TestMethod]
        public void ConstructorInitializesProps()
        {
            //public Area(string aName, Master aMaster) 

            Area area = new Area(
                TestData.EXPECTED_AREA_NAME,
                TestData.EXPECTED_AREA_MASTER
                
            );

            Assert.AreEqual(TestData.EXPECTED_AREA_NAME, area.Name, "Name not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_AREA_MASTER, area.Master, "Master not properly initialized.");
            Assert.IsNotNull(area.Incidents, "Incidents collection not initialized. \n Patch the problem adding: :this() to the constructor with parameters");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, area.Incidents.Count,"Incidents should be empty after construction.");

        }

    }
}
