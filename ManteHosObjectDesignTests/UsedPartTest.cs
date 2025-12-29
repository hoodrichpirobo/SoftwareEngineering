using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using ManteHos.Entities;

namespace ManteHosObjectDesignTests
{
    [TestClass]
    public class UsedPartTest
    {
        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            PropertyInfo property = typeof(UsedPart).GetProperty("Part");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Part property should be declared virtual.");

            property = typeof(UsedPart).GetProperty("WorkOrder");
            Assert.IsNull(property, "WorkOrder property should NOT exist in UsedPart.");
        }

        [TestMethod]
        public void NoParamsConstructorWorks()
        {
            UsedPart usedPart = new UsedPart();
            Assert.IsNotNull(usedPart, "UsedPart: default constructor must exist.");
        }

        [TestMethod]
        public void ConstructorTwoParamsExists()
        {
            
            var ctorIntPart = typeof(UsedPart).GetConstructor(new[] { typeof(int), typeof(Part) });

            bool exists = (ctorIntPart != null);
            Assert.IsTrue(exists, "UsedPart must implement constructor (int, Part).");
        }


        [TestMethod]
        public void ConstructorIntPart_SetsNeededFalse_WhenEnoughStock()
        {
            var ctor = typeof(UsedPart).GetConstructor(new[] { typeof(int), typeof(Part) });
            bool exists = (ctor != null);
            Assert.IsTrue(exists, "UsedPart must implement constructor (int, Part).");

            Part part = TestData.CreateExpectedPart();
            int initialQuantity = part.CurrentQuantity;

            UsedPart usedPart = (UsedPart)ctor.Invoke(new object[] { TestData.EXPECTED_USEDPART_QUANTITY_ENOUGH, part });

            Assert.IsFalse(usedPart.Needed, "Needed should be false when enough stock exists.");
            Assert.AreEqual(initialQuantity - TestData.EXPECTED_USEDPART_QUANTITY_ENOUGH, part.CurrentQuantity);
        }

        [TestMethod]
        public void ConstructorIntPart_SetsNeededTrue_WhenNotEnoughStock()
        {
            var ctor = typeof(UsedPart).GetConstructor(new[] { typeof(int), typeof(Part) });
            bool exists = (ctor != null);
            Assert.IsTrue(exists, "UsedPart must implement constructor (int, Part).");

            Part part = TestData.CreateExpectedPart();
            int initialQuantity = part.CurrentQuantity;

            UsedPart usedPart = (UsedPart)ctor.Invoke(new object[] { TestData.EXPECTED_USEDPART_QUANTITY_NOT_ENOUGH, part });

            Assert.IsTrue(usedPart.Needed, "Needed should be true when not enough stock exists.");
            Assert.AreEqual(initialQuantity, part.CurrentQuantity, "CurrentQuantity should not be reduced when insufficient stock.");
        }
    }
}
