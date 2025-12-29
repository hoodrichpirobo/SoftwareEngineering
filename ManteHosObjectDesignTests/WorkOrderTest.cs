using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using ManteHos.Entities;
namespace ManteHosObjectDesignTests
{
    [TestClass]
    public class WorkOrderTest
    {
        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            // Virtual properties are Incident, Operator, UsedPart
            PropertyInfo property = typeof(WorkOrder).GetProperty("Incident");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Incident property should be declared virtual.");
            property = typeof(WorkOrder).GetProperty("Operators");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Operators property should be declared virtual.");
            property = typeof(WorkOrder).GetProperty("UsedParts");
            Assert.IsTrue(property.GetMethod.IsVirtual, "UsedPart property should be declared virtual.");
        }

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {

            WorkOrder workOrder = new WorkOrder();
            Assert.AreNotSame(null, workOrder, "WorkOrder: There must be a constructor without parameters.");

            Assert.IsNotNull(workOrder.Operators, "Collection of Operators not properly initialized. \n Patch the problem adding:  Operators = new List<Operator>(); in the constructor without parameters");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, workOrder.Operators.Count, "Collection of Operators not properly initialized. \n The list should be empty\n");

            Assert.IsNotNull(workOrder.UsedParts, "Collection of UsedParts not properly initialized. \n Patch the problem adding:  UsedParts = new List<UsedPart>(); in the constructor without parameters");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, workOrder.UsedParts.Count, "Collection of UsedParts not properly initialized. \n The list should be empty\n");

        }

        [TestMethod]
        public void ConstructorInitializesProps()
        {

            // public WorkOrder(DateTime aStartDate, Incident aIncidence)

            WorkOrder workOrder = new WorkOrder(TestData.EXPECTED_WORKORDER_START_DATE, TestData.EXPECTED_WORKORDER_INCIDENT);

            Assert.AreEqual(TestData.EXPECTED_WORKORDER_START_DATE, workOrder.StartDate, "StartDate not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_WORKORDER_INCIDENT, workOrder.Incident, "Incident not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            
            Assert.IsNotNull(workOrder.Operators, "Collection of Operators not properly initialized. \n Patch the problem adding: :this() to the constructor with parameters");
            Assert.IsNotNull(workOrder.UsedParts, "Collection of UsedParts not properly initialized. \n Patch the problem adding: :this() to the constructor with parameters");

        }
    }
}
