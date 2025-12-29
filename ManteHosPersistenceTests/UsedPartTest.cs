using ManteHos.Entities;
using ManteHos.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ManteHosPersistenceTests
{
    [TestClass]
    public class UsedPartTest : BaseTest
    {
        private UsedPart InitModel(out string error)
        {
            var part = TestData.CreateExpectedPart();
            dal.Insert(part);
            dal.Commit();

            var usedPart = TestData.CreateUsedPart(
                TestData.EXPECTED_USEDPART_NEEDED_TRUE, // asignamos verdadero para comprobar que se almacena porque falso es el valor por defecto
                TestData.EXPECTED_USEDPART_QUANTITY_NOT_ENOUGH,
                part,
                out error
            );

            if (usedPart == null)
            {
                error = $"Error creating UsedPart: {error}";
                return null;
            }

            dal.Insert(usedPart);
            dal.Commit();
            return usedPart;
        }

        [TestMethod]
        public void StoresInitialDataConstructor()
        {
            var usedPart = InitModel(out var error);
            if (usedPart == null) 
                Assert.Fail(error);

            var usedPartFromDAL = dal.GetById<UsedPart>(usedPart.Id);

            // Test non-virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_USEDPART_QUANTITY_NOT_ENOUGH, usedPartFromDAL.Quantity, "Quantity not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_USEDPART_NEEDED_TRUE, usedPartFromDAL.Needed, "Needed not properly stored.");

            // Test virtual properties properly stored
            Assert.IsNotNull(usedPartFromDAL.Part, "Part not properly initialized.");
        }

        [TestMethod]
        public void StoresDataWithRelations()
        {
            var usedPart = InitModel(out var error);
            if (usedPart == null) 
                Assert.Fail(error);

            var usedPartFromDAL = dal.GetById<UsedPart>(usedPart.Id);

            // Test bidirectional relationships
            Assert.AreEqual(usedPart.Part, usedPartFromDAL.Part, "Part not properly linked from UsedPart.");
            Assert.AreEqual(usedPart, usedPartFromDAL.Part.UsedParts.FirstOrDefault(x => x.Id == usedPart.Id), "UsedPart not properly linked from Part.");
        }
    }
}