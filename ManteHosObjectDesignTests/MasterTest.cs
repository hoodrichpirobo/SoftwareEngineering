using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using ManteHos.Entities;

namespace ManteHosObjectDesignTests
{
    [TestClass]
    public class MasterTest
    {
        [TestMethod]
        public void InheritsFromEmployee()
        {
            Assert.IsTrue(typeof(Employee).IsAssignableFrom(typeof(Master)),
                "Master must inherit from Employee.");
        }

        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            PropertyInfo property = typeof(Master).GetProperty("Area");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Area property should be declared virtual.");
			//property = typeof(Master).GetProperty("ReportedIncidents");
            //Assert.IsNotNull(property, "ReportedIncidents property must be present. Patch the problem by inheriting from :Employee");
            //if (property != null)
            //Assert.IsTrue(property.GetMethod.IsVirtual, "ReportedIncidents property should be declared virtual. Patch the problem by inheriting from :Employee");
		}

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {
            Master mas = new Master();

            Assert.IsNotNull(mas, "Master: default constructor must exist.");
            Assert.IsNotNull(mas.ReportedIncidents, "ReportedIncidents collection not initialized. Call : base()");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, mas.ReportedIncidents.Count,
				"ReportedIncidents should be empty after construction.");

            
        }

        [TestMethod]
        public void ConstructorInitializesProps()
        {
            Master mas = new Master(
                TestData.EXPECTED_EMPLOYEE_FULLNAME,
                TestData.EXPECTED_EMPLOYEE_ID,
                TestData.EXPECTED_EMPLOYEE_PASSWORD
            );

            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, mas.FullName, "FullName not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_ID, mas.Id, "Id not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, mas.Password, "Password not properly initialized.");
            

            Assert.IsNotNull(mas.ReportedIncidents, "ReportedIncidents collection not initialized. \n Patch the problem adding :base(aFullName, aId, aPassword)  to the constructor with parameters");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, mas.ReportedIncidents.Count,
				"ReportedIncidents should be empty after construction.");

      
        }

        
    }
}
