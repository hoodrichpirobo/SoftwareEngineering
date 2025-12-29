using ManteHos.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace ManteHosObjectDesignTests
{
	[TestClass]
	public class HeadTest
	{
		[TestMethod]
		public void InheritsFromEmployee()
		{
			Assert.IsTrue(typeof(Employee).IsAssignableFrom(typeof(Head)),
				"Head must inherit from Employee.");
		}

		[TestMethod]
		public void VirtualPropertiesDefined()
		{
			//PropertyInfo property = typeof(Head).GetProperty("ReportedIncidents");
			//Assert.IsNotNull(property, "ReportedIncidents property must be present. Patch the problem by inheriting from :Employee");
			//if (property!=null ) 
			//Assert.IsTrue(property.GetMethod.IsVirtual, "ReportedIncidents property should be declared virtual.");
		}

		[TestMethod]
		public void NoParamsConstructorInitializesCollections()
		{
			Head head = new Head();

			Assert.IsNotNull(head, "Head: default constructor must exist.");
			Assert.IsNotNull(head.ReportedIncidents, "ReportedIncidents collection not initialized. Patch the problem calling :base()");
			Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, head.ReportedIncidents.Count,
				"ReportedIncidents should be empty after construction.");
		}

		[TestMethod]
		public void ConstructorInitializesProps()
		{
			Head head = new Head(
				TestData.EXPECTED_EMPLOYEE_FULLNAME,
				TestData.EXPECTED_EMPLOYEE_ID,
				TestData.EXPECTED_EMPLOYEE_PASSWORD
			);

			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, head.FullName, "FullName not properly initialized.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_ID, head.Id, "Id not properly initialized.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, head.Password, "Password not properly initialized.");

			Assert.IsNotNull(head.ReportedIncidents, "ReportedIncidents collection not initialized. \n Patch the problem calling :base(aFullName, aId, aPassword)");
			Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, head.ReportedIncidents.Count,
				"ReportedIncidents should be empty after construction.");
		}
	}
}
