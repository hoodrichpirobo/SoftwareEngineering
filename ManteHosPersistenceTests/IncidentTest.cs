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
        public class IncidentTest : BaseTest
        {
            [TestMethod]
            public void StoresInitialData()
            {

            // public Incident(string aDepartment, string aDescription, DateTime aReportDate, Employee aReporter)

            Incident incident = new Incident(TestData.EXPECTED_INCIDENT_DEPARTMENT, TestData.EXPECTED_INCIDENT_DESCRIPTION, TestData.EXPECTED_INCIDENT_REPORTDATE, TestData.EXPECTED_INCIDENT_EMPLOYEE);
            dal.Insert(incident);
            dal.Commit();

            Incident incidentFromDAL = dal.GetAll<Incident>().First();

            // Test non virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_INCIDENT_DEPARTMENT, incidentFromDAL.Department, "Department attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_INCIDENT_DESCRIPTION, incidentFromDAL.Description, "Description attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_INCIDENT_REPORTDATE, incidentFromDAL.ReportDate, "ReportDate attribute not properly stored.");
            
            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1

            Assert.AreEqual(TestData.EXPECTED_INCIDENT_EMPLOYEE, incidentFromDAL.Reporter, "Reporter not properly initialized.");
            
            
            // They must be initially empty because they are all 0..*
            // Assert.IsNotNull(enrollmentFromDAL.Absence, "Absences not properly stored.");
            // Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, enrollmentFromDAL.Absences.Count, "Collection of Absences not properly initialized. \n The list should be empty\n");


        }

        [TestMethod]
            public void StoresDataWithRelations()
            {

            Employee e= TestData.EXPECTED_INCIDENT_EMPLOYEE;
            dal.Insert(e);
            dal.Commit();

            Area a = new Area(TestData.EXPECTED_AREA_NAME, TestData.EXPECTED_AREA_MASTER);
            dal.Insert(a);
            dal.Commit();            

            Incident incident = new Incident(TestData.EXPECTED_INCIDENT_DEPARTMENT, TestData.EXPECTED_INCIDENT_DESCRIPTION, TestData.EXPECTED_INCIDENT_REPORTDATE, e)
            { Area = a};
           
            dal.Insert(incident);
            dal.Commit();

            WorkOrder wo = new WorkOrder(TestData.EXPECTED_WORKORDER_START_DATE, incident);
            dal.Insert(wo);
            dal.Commit();

            Incident incidentFromDAL = dal.GetAll<Incident>().First();

            // Test non virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_INCIDENT_DEPARTMENT, incidentFromDAL.Department, "Department attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_INCIDENT_DESCRIPTION, incidentFromDAL.Description, "Description attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_INCIDENT_REPORTDATE, incidentFromDAL.ReportDate, "ReportDate attribute not properly stored.");

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1
            Assert.AreEqual(e, incidentFromDAL.Reporter, "Reporter not properly initialized.");
            
            // Verify bidirectional relationships: all collections are not null after inserting one element      
            Assert.AreEqual(e.ReportedIncidents.FirstOrDefault(), incidentFromDAL, "Bidirectional Incident-Employee relationship not properly set");
            Assert.AreEqual(a.Incidents.FirstOrDefault(), incidentFromDAL, "Bidirectional Incident-Area relationship not properly set");
            Assert.AreEqual(incidentFromDAL.WorkOrder,wo, "Bidirectional Incident-WorkOrder relationship not properly set");
        }
    }
    }

