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
	public class HeadTest : BaseTest
	{
		[TestMethod]
		public void StoresInitialData()
		{

			Head head = new Head(TestData.EXPECTED_EMPLOYEE_FULLNAME, TestData.EXPECTED_EMPLOYEE_ID, TestData.EXPECTED_EMPLOYEE_PASSWORD);
			dal.Insert(head);
			dal.Commit();

			Head headFromDAL = dal.GetById<Head>(head.Id);

			// Test non virtual properties properly stored
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, headFromDAL.FullName);
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_ID, headFromDAL.Id);
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, headFromDAL.Password);

			// Verify bidirectional relationships: all collections are not null after inserting one element      
			Assert.IsNotNull(headFromDAL.ReportedIncidents);
			Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, headFromDAL.ReportedIncidents.Count);

		}

		[TestMethod]
		public void StoresDataWithRelations()
		{

			Head head = new Head(TestData.EXPECTED_EMPLOYEE_FULLNAME, TestData.EXPECTED_EMPLOYEE_ID, TestData.EXPECTED_EMPLOYEE_PASSWORD);
			dal.Insert(head);
			dal.Commit();

			Incident incident = new Incident(TestData.EXPECTED_INCIDENT_DEPARTMENT, TestData.EXPECTED_INCIDENT_DESCRIPTION, TestData.EXPECTED_INCIDENT_REPORTDATE, head);
			dal.Insert(incident);
			dal.Commit();

			Head headFromDAL = dal.GetById<Head>(head.Id);

			// Esto es redundante porque ya se testea en Employee
			// Test non virtual properties properly stored
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_FULLNAME, headFromDAL.FullName, "FullName attribute not properly stored.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_ID, headFromDAL.Id, "Id attribute not properly stored.");
			Assert.AreEqual(TestData.EXPECTED_EMPLOYEE_PASSWORD, headFromDAL.Password, "Password attribute not properly stored.");

			// Verify bidirectional relationships: all collections are not null after inserting one element      
			Assert.IsNotNull(headFromDAL.ReportedIncidents, "Collection of ReportedIncidents not properly stored.");
			Assert.AreEqual(TestData.EXPECTED_ONE_ELEMENT_LIST_COUNT, headFromDAL.ReportedIncidents.Count, "ReportedIncidents not properly initialized.");
			Assert.AreEqual(incident, headFromDAL.ReportedIncidents.FirstOrDefault(), "ReportedIncidents relationship not properly created.");
			Assert.AreEqual(incident.Reporter, headFromDAL, "Bidirectional Incident-Reporter relationship not properly set");

		}

		[TestMethod]
		public void StoresHeadAsEmployeePolymorphism()
		{
			Head head = new Head(TestData.EXPECTED_EMPLOYEE_FULLNAME, TestData.EXPECTED_EMPLOYEE_ID, TestData.EXPECTED_EMPLOYEE_PASSWORD);
			dal.Insert(head);
			dal.Commit();

			Employee employeeFromDAL = dal.GetById<Employee>(head.Id);
			Assert.IsInstanceOfType(employeeFromDAL, typeof(Head), "Head must inherit from Employee.");
		}
	}
}
