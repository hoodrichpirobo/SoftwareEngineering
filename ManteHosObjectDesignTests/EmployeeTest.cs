using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using ManteHos.Entities;

namespace ManteHosObjectDesignTests
{
	[TestClass]
	public class EmployeeTest
	{

		[TestMethod]
		public void VirtualPropertiesDefined()
		{
			PropertyInfo property = typeof(Employee).GetProperty("ReportedIncidents");
			Assert.IsTrue(property.GetMethod.IsVirtual, "ReportedIncidents property should be declared virtual.");
		}

		[TestMethod]
		public void NoParamsConstructorInitializesCollections()
		{
			Employee employee = new Employee();

			Assert.IsNotNull(employee, "Employee: default constructor must exist.");
			Assert.IsNotNull(employee.ReportedIncidents, "ReportedIncidents collection not initialized.");
			Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, employee.ReportedIncidents.Count,
				"ReportedIncidents should be empty after construction.");
		}

		[TestMethod]
		public void ConstructorInitializesProps()
		{
			Employee employee = new Employee(
				TestData.EXPECTED_EMPLOYEE_FULLNAME,
				TestData.EXPECTED_EMPLOYEE_ID,
				TestData.EXPECTED_EMPLOYEE_PASSWORD
			);

			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, employee.FullName, "FullName not properly initialized.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_ID, employee.Id, "Id not properly initialized.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, employee.Password, "Password not properly initialized.");

			Assert.IsNotNull(employee.ReportedIncidents, "ReportedIncidents collection not initialized. \n Patch the problem adding: :this() to the constructor with parameters");
			Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, employee.ReportedIncidents.Count,
				"ReportedIncidents should be empty after construction.");
		}
	}
}
