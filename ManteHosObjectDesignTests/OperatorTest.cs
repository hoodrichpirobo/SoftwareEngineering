using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using ManteHos.Entities;

namespace ManteHosObjectDesignTests
{
    [TestClass]
    public class OperatorTest
    {
        [TestMethod]
        public void InheritsFromEmployee()
        {
            Assert.IsTrue(typeof(Employee).IsAssignableFrom(typeof(Operator)),
                "Operator must inherit from Employee.");
        }

        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            PropertyInfo property = typeof(Operator).GetProperty("WorkOrders");
            Assert.IsTrue(property.GetMethod.IsVirtual, "WorkOrders property should be declared virtual.");
			//property = typeof(Operator).GetProperty("ReportedIncidents");
            //Assert.IsNotNull(property, "ReportedIncidents property must be present. Patch the problem by inheriting from :Employee");
            //if (property != null)
            //Assert.IsTrue(property.GetMethod.IsVirtual, "ReportedIncidents property should be declared virtual. Patch the problem by inheriting from :Employee");
		}

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {
            Operator op = new Operator();

            Assert.IsNotNull(op, "Operator: default constructor must exist.");
            Assert.IsNotNull(op.ReportedIncidents, "ReportedIncidents collection not initialized. Call : base()");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, op.ReportedIncidents.Count,
				"ReportedIncidents should be empty after construction.");

            Assert.IsNotNull(op.WorkOrders, "WorkOrders collection not initialized in the constructor without parameters.");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, op.WorkOrders.Count,
                "WorkOrders should be empty after construction.");
        }

        [TestMethod]
        public void ConstructorInitializesProps()
        {
            Operator op = new Operator(
                TestData.EXPECTED_EMPLOYEE_FULLNAME,
                TestData.EXPECTED_EMPLOYEE_ID,
                TestData.EXPECTED_EMPLOYEE_PASSWORD,
                TestData.EXPECTED_SHIFT
            );

            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, op.FullName, "FullName not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_ID, op.Id, "Id not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, op.Password, "Password not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_SHIFT, op.Shift, "Shift not properly initialized.");

            Assert.IsNotNull(op.ReportedIncidents, "ReportedIncidents collection not initialized. \n Patch the problem adding :base(aFullName, aId, aPassword)  to the constructor with parameters");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, op.ReportedIncidents.Count,
				"ReportedIncidents should be empty after construction.");

            Assert.IsNotNull(op.WorkOrders, "WorkOrders collection not initialized. \n Patch the problem adding WorkOrders = new List<WorkOrder>() to the constructor with parameters");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, op.WorkOrders.Count,
                "WorkOrders should be empty after construction.");
        }

        [TestMethod]
        public void ShiftPropertyAcceptsAllEnumValues()
        {
            foreach (Shift shift in (Shift[])Enum.GetValues(typeof(Shift)))
            {
                Operator op = new Operator(
                    TestData.EXPECTED_EMPLOYEE_FULLNAME,
                    TestData.EXPECTED_EMPLOYEE_ID,
                    TestData.EXPECTED_EMPLOYEE_PASSWORD,
                    shift
                );

                Assert.AreEqual(shift, op.Shift, $"Shift not properly assigned for value {shift}.");
            }
        }
    }
}
