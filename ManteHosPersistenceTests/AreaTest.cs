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
        public class AreaTest : BaseTest
        {
            [TestMethod]
            public void StoresInitialData()
            {
                // string aName, Master aMaster
                Area area = new Area(TestData.EXPECTED_AREA_NAME, TestData.EXPECTED_AREA_MASTER);
                dal.Insert(area);
                dal.Commit();

                Area areaFromDAL = dal.GetAll<Area>().First();

                // Test non virtual properties properly stored
                Assert.AreEqual(TestData.EXPECTED_AREA_NAME, areaFromDAL.Name, "Name attribute not properly stored.");
            
                // Test virtual properties properly stored
                // They must be initially instanced because they are all 1
                Assert.AreEqual(TestData.EXPECTED_AREA_MASTER, areaFromDAL.Master, "Master not properly initialized.");
            
                // They must be initially empty because they are all 0..*
                 Assert.IsNotNull(areaFromDAL.Incidents, "Incidents not properly stored.");
                 Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, areaFromDAL.Incidents.Count, "Collection of Incidents not properly initialized. \n The list should be empty\n");
        }

        [TestMethod]
            public void StoresDataWithRelations()
            {
                Master m = new Master(TestData.EXPECTED_MASTER_FULLNAME, TestData.EXPECTED_MASTER_ID, TestData.EXPECTED_MASTER_PASSWORD);
                dal.Insert(m);
                dal.Commit();
             
                Area area = new Area(TestData.EXPECTED_AREA_NAME, m);
                dal.Insert(area);
                dal.Commit();

                // string aFullName, string aId, string aPassword
                Employee e = new Employee(TestData.EXPECTED_EMPLOYEE_FULLNAME, TestData.EXPECTED_EMPLOYEE_ID, TestData.EXPECTED_EMPLOYEE_PASSWORD);
                dal.Insert(e);
                dal.Commit();

                Incident i = new Incident(TestData.EXPECTED_INCIDENT_DEPARTMENT, TestData.EXPECTED_INCIDENT_DESCRIPTION, TestData.EXPECTED_INCIDENT_REPORTDATE, e)
                { Area = area };
                dal.Insert(i);
                dal.Commit();


                Area areaFromDAL = dal.GetAll<Area>().First();

                // Test non virtual properties properly stored
                Assert.AreEqual(TestData.EXPECTED_AREA_NAME, areaFromDAL.Name, "Name attribute not properly stored.");

                // Test virtual properties properly stored
                // They must be initially instanced because they are all 1
                Assert.AreEqual(m, areaFromDAL.Master, "Master not properly initialized.");

            // Verify bidirectional relationships: all collections are not null after inserting one element      
         //   Assert.AreEqual(e.ReportedIncidents.FirstOrDefault(), incidentFromDAL, "Bidirectional Incident-Employee relationship not properly set");

        }
    }
    }

