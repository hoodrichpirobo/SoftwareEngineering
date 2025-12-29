using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteHos.Entities;

namespace ManteHosPersistenceTests
{
    [TestClass]
    public class PartTest : BaseTest
    {
        [TestMethod]
        public void StoresInitialData()
        {
            Part part = new Part(TestData.EXPECTED_PART_CODE, TestData.EXPECTED_PART_CURRENTQUANTITY, TestData.EXPECTED_PART_DESCRIPTION, TestData.EXPECTED_PART_MINIMUMQUANTITY, TestData.EXPECTED_PART_UNITOFMEASURE, TestData.EXPECTED_PART_UNITPRICE);
            dal.Insert(part);
            dal.Commit();

            Part partFromDAL = dal.GetAll<Part>().First();

            // Test non virtual properties properly stored
            TestNonVirtualPropertiesProperlyStored(partFromDAL);


            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1


            // They must be initially empty because they are all 0..*
            Assert.IsNotNull(partFromDAL.UsedParts, "UsedParts not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, partFromDAL.UsedParts.Count, "Collection of UsedParts not properly initialized. \n The list should be empty\n");
        }


        [TestMethod]
        public void StoresDataWithRelations()
        {
            Part part = new Part(TestData.EXPECTED_PART_CODE, TestData.EXPECTED_PART_CURRENTQUANTITY, TestData.EXPECTED_PART_DESCRIPTION, TestData.EXPECTED_PART_MINIMUMQUANTITY, TestData.EXPECTED_PART_UNITOFMEASURE, TestData.EXPECTED_PART_UNITPRICE);
            dal.Insert(part);
            dal.Commit();

            UsedPart usedPart = new UsedPart( TestData.EXPECTED_USEDPART_QUANTITY_NOT_ENOUGH, part);
            dal.Insert(usedPart);
            dal.Commit();

            Part partFromDAL = dal.GetAll<Part>().First();

            // Test non virtual properties properly stored
            TestNonVirtualPropertiesProperlyStored(partFromDAL);

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1

            // Verify bidirectional relationships: all collections are not null after inserting one element      
            Assert.AreEqual(partFromDAL.UsedParts.FirstOrDefault(), usedPart, "Bidirectional UsedPart-Part relationship not properly set");

        }

        private static void TestNonVirtualPropertiesProperlyStored(Part partFromDAL)
        {
            Assert.AreEqual(TestData.EXPECTED_PART_CODE, partFromDAL.Code, "Code attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_PART_CURRENTQUANTITY, partFromDAL.CurrentQuantity, "CurrentQuantity attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_PART_DESCRIPTION, partFromDAL.Description, "Description attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_PART_MINIMUMQUANTITY, partFromDAL.MinimunQuantity, "MinimunQuantity attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_PART_UNITOFMEASURE, partFromDAL.UnitOfMeasure, "UnitOfMeasure attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_PART_UNITPRICE, partFromDAL.UnitPrice, "UnitPrice attribute not properly stored.");
        }
    }
}
