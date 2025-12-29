using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using ManteHos.Entities;
namespace ManteHosObjectDesignTests
{
    [TestClass]
    public class IncidentTest
    {
        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            // Virtual properties are Area, WorkOrder, Reporter
            PropertyInfo property = typeof(Incident).GetProperty("Area");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Area property should be declared virtual.");
            property = typeof(Incident).GetProperty("WorkOrder");
            Assert.IsTrue(property.GetMethod.IsVirtual, "WorkOrder property should be declared virtual.");
            property = typeof(Incident).GetProperty("Reporter");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Reporter property should be declared virtual.");
            
        }

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {

            Incident incident = new Incident();
            Assert.AreNotSame(null, incident, "Incident: There must be a constructor without parameters.");

            // Collections (Verify collections are empty after Incident is created): No Collections in this class 
            // Example: Assert.IsNotNull(taughtCourse.Enrollments, "Collection of Enrollments not properly initialized. \n Patch the problem adding:  Enrollment = new List<Enrollment>();");
            //          Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, taughtCourse.Enrollments.Count, "Collection of Enrollments not properly initialized. \n The list should be empty\n");

        }

        [TestMethod]
        public void ConstructorInitializesProps()
        {
            //public Incident(string aDepartment, string aDescription, DateTime aReportDate, Employee aReporter)


            Incident incident = new Incident(TestData.EXPECTED_INCIDENT_DEPARTMENT, TestData.EXPECTED_INCIDENT_DESCRIPTION, TestData.EXPECTED_INCIDENT_REPORTDATE, TestData.EXPECTED_INCIDENT_EMPLOYEE);

            Assert.AreEqual(TestData.EXPECTED_INCIDENT_DEPARTMENT, incident.Department, "Department not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_INCIDENT_DESCRIPTION, incident.Description, "Description not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_INCIDENT_REPORTDATE, incident.ReportDate, "ReportDate not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_INCIDENT_EMPLOYEE, incident.Reporter, "Reporter not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(Status.Created, incident.Status, "Initial status values should be Created");
            // Collections Initialized to empty lists by calling this()
            //Example: Assert.IsNotNull(taughtCourse.Enrollments, "Collection of Enrollments not properly initialized. \n Patch the problem adding: :this() to the constructor with parameters");
            
        }
    }
}
