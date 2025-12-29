using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using ManteHos.Entities;

namespace ManteHosObjectDesignTests
{
    [TestClass]
    public class PartTest
    {
        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            PropertyInfo property = typeof(Part).GetProperty("UsedParts");
            Assert.IsTrue(property.GetMethod.IsVirtual, "UsedParts property should be declared virtual.");

        }

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {
            Part part = new Part();
            Assert.IsNotNull(part, "Part: default constructor must exist.");

            Assert.IsNotNull(part.UsedParts, "UsedParts collection not initialized. Call : base()");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, part.UsedParts.Count,
                "UsedParts should be empty after construction.");
        }

        [TestMethod]
        public void ConstructorInitializesProps()
        {

            //Part(string aCode, int aCurrentQuantity, string aDescription, int aMinimunQuantity, string aUnitOfMeasure, float aUnitPrice)
            Part part = new Part(
                TestData.EXPECTED_PART_CODE,
                TestData.EXPECTED_PART_CURRENTQUANTITY,
                TestData.EXPECTED_PART_DESCRIPTION,
                TestData.EXPECTED_PART_MINIMUMQUANTITY,
                TestData.EXPECTED_PART_UNITOFMEASURE,
                TestData.EXPECTED_PART_UNITPRICE
            );

            Assert.AreEqual(TestData.EXPECTED_PART_CODE, part.Code, "Code not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_PART_CURRENTQUANTITY, part.CurrentQuantity, "CurrentQuantity not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_PART_DESCRIPTION, part.Description, "Description not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_PART_MINIMUMQUANTITY, part.MinimunQuantity, "MinimunQuantity not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_PART_UNITOFMEASURE, part.UnitOfMeasure, "UnitOfMeasure not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_PART_UNITPRICE, part.UnitPrice, "UnitPrice not properly initialized.");


            Assert.IsNotNull(part.UsedParts, "UsedParts collection not initialized. \n Patch the problem adding :base(aFullName, aId, aPassword)  to the constructor with parameters");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, part.UsedParts.Count,
                "UsedParts should be empty after construction.");


        }

    }
}
