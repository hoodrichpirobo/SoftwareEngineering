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
	public class EmployeeTest : BaseTest
	{
		[TestMethod]
		public void StoresInitialData()
		{

			// public Employee(string FullName, string Id, string Password)
			Employee employee = new Employee(TestData.EXPECTED_EMPLOYEE_FULLNAME, TestData.EXPECTED_EMPLOYEE_ID, TestData.EXPECTED_EMPLOYEE_PASSWORD);
			dal.Insert(employee);
			dal.Commit();

			Employee employeeFromDAL = dal.GetById<Employee>(employee.Id);

			// Test non virtual properties properly stored
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, employeeFromDAL.FullName, "FullName attribute not properly stored.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_ID, employeeFromDAL.Id, "Id attribute not properly stored.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, employeeFromDAL.Password, "Password attribute not properly stored.");

			// Test virtual properties properly stored
			// They must be initially empty because they are all 0..*
			Assert.IsNotNull(employeeFromDAL.ReportedIncidents, "Collection of ReportedIncidents not properly stored.");
			Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, employeeFromDAL.ReportedIncidents.Count, "ReportedIncidents should be initially empty.");
		
		}

		[TestMethod]
		public void StoresDataWithRelations()
		{

			Employee employee = new Employee(TestData.EXPECTED_EMPLOYEE_FULLNAME, TestData.EXPECTED_EMPLOYEE_ID, TestData.EXPECTED_EMPLOYEE_PASSWORD);
			dal.Insert(employee);
			dal.Commit();

			Incident incident = new Incident(TestData.EXPECTED_INCIDENT_DEPARTMENT, TestData.EXPECTED_INCIDENT_DESCRIPTION, TestData.EXPECTED_INCIDENT_REPORTDATE, employee);
			dal.Insert(incident);
			dal.Commit();

			Employee employeeFromDAL = dal.GetById<Employee>(employee.Id);

			// Test non virtual properties properly stored
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, employeeFromDAL.FullName, "FullName attribute not properly stored.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_ID, employeeFromDAL.Id, "Id attribute not properly stored.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, employeeFromDAL.Password, "Password attribute not properly stored.");

			// Verify bidirectional relationships: all collections are not null after inserting one element      
			Assert.IsNotNull(employeeFromDAL.ReportedIncidents, "Collection of ReportedIncidents not properly stored.");
			Assert.AreEqual(TestData.EXPECTED_ONE_ELEMENT_LIST_COUNT, employeeFromDAL.ReportedIncidents.Count, "ReportedIncidents should have one element after assigning an Incident.");
			Assert.AreEqual(incident, employeeFromDAL.ReportedIncidents.FirstOrDefault(), "ReportedIncidents relationship not properly created.");
			Assert.AreEqual(incident.Reporter, employeeFromDAL, "Bidirectional Incident-Reporter relationship not properly set");

		}
	}
}
